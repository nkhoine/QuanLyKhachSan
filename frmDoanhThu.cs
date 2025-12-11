using System;
using System.Data;
using System.Windows.Forms;

namespace Nhom5_QuanLyKhachSan
{
    public partial class frmDoanhThu : Form
    {
        public frmDoanhThu()
        {
            InitializeComponent();
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            // CÁCH SỬA: Lấy khoảng thời gian rộng hơn để bao quát dữ liệu cũ
            // Ví dụ: Lấy từ đầu năm 2024 đến hiện tại
            dtpTuNgay.Value = new DateTime(2024, 1, 1);
            dtpDenNgay.Value = DateTime.Now;

            // Tự động load dữ liệu luôn khi mở form
            LoadDoanhThu();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadDoanhThu();
        }

        // --- HÀM ĐÃ ĐƯỢC CẬP NHẬT LOGIC BẢO MẬT ---
        private void LoadDoanhThu()
        {
            try
            {
                string tuNgay = dtpTuNgay.Value.ToString("yyyy-MM-dd");
                string denNgay = dtpDenNgay.Value.ToString("yyyy-MM-dd");

                // ==================================================================
                // BƯỚC 1: Thiết lập Context User (VPD/RLS) trước khi truy vấn
                // ==================================================================

                // Lấy Mã NV từ Session đăng nhập (nếu null thì fallback về NV01 để test)
                string maNV = Session.MaNV;
                if (string.IsNullOrEmpty(maNV))
                {
                    maNV = "NV01";
                }

                // Gọi thủ tục hoặc khối lệnh PL/SQL để set context
                string sqlSetContext = $"BEGIN PKG_SECURITY.SET_USER_ID('{maNV}'); END;";

                // Lưu ý: Đảm bảo class Database của bạn có hàm ExecuteNonQuery
                Database.ExecuteNonQuery(sqlSetContext);

                // ==================================================================
                // BƯỚC 2: Thực hiện truy vấn dữ liệu
                // ==================================================================

                string sql = "SELECT hd.MAHD, dp.SOPHONG, kh.HOTEN AS KHACHHANG, " +
                             "nv.HOTEN AS NHANVIEN, hd.NGAYLAP, hd.TONGTIEN " +
                             "FROM HOADON hd " +
                             "JOIN DATPHONG dp_goc ON hd.MADP = dp_goc.MADP " +
                             "JOIN PHONG dp ON dp_goc.MAPHONG = dp.MAPHONG " +
                             "JOIN NHANVIEN nv ON hd.MANV = nv.MANV " +
                             "JOIN KHACHHANG kh ON dp_goc.MAKH = kh.MAKH " +
                             "WHERE hd.NGAYLAP >= TO_DATE('" + tuNgay + "', 'YYYY-MM-DD') " +
                            // Đổi dấu <= thành < và cộng thêm 1 ngày (+1)
                            "AND hd.NGAYLAP < TO_DATE('" + denNgay + "', 'YYYY-MM-DD') + 1 " +
                             "ORDER BY hd.NGAYLAP DESC";

                DataTable dt = Database.GetData(sql);
                dgvDoanhThu.DataSource = dt;

                // Format cột Tiền tệ (Giữ lại phần này cho đẹp giao diện)
                if (dgvDoanhThu.Columns["TONGTIEN"] != null)
                {
                    dgvDoanhThu.Columns["TONGTIEN"].DefaultCellStyle.Format = "N0"; // Có dấu phẩy ngăn cách
                    dgvDoanhThu.Columns["TONGTIEN"].HeaderText = "Tổng tiền (VNĐ)";
                }

                // Tính tổng doanh thu hiển thị ra Label
                TinhTongDoanhThu(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu doanh thu: " + ex.Message);
            }
        }

        private void TinhTongDoanhThu(DataTable dt)
        {
            decimal tongTien = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["TONGTIEN"] != DBNull.Value)
                    {
                        tongTien += Convert.ToDecimal(row["TONGTIEN"]);
                    }
                }
            }

            // Hiển thị ra Label màu đỏ
            lblTongDoanhThu.Text = tongTien.ToString("N0") + " VNĐ";
        }
    }
}