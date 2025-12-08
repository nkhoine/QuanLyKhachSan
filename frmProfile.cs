using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Nhom5_QuanLyKhachSan
{
    public partial class frmProfile : Form
    {
        public frmProfile()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmProfile_Load(object sender, EventArgs e) // Tên hàm có thể là Load_1, kệ nó
        {
            // 1. Kiểm tra xem hàm có chạy không
            MessageBox.Show("Hàm Load ĐANG CHẠY! Mã NV: " + Session.MaNV);

            try
            {
                if (string.IsNullOrEmpty(Session.MaNV)) return;

                // 2. Điền thông tin (Dùng cách đơn giản nhất để test)
                lblValMaNV.Text = Session.MaNV;
                lblValHoTen.Text = Session.HoTen;
                lblValChucVu.Text = Session.ChucVu;

                // 3. Lấy dữ liệu
                string sql = "SELECT LUONG_ENC FROM QUANLYKS.NHANVIEN WHERE MANV = '" + Session.MaNV + "'";

                // Hiện câu SQL ra để kiểm tra
                // MessageBox.Show("SQL: " + sql); 

                DataTable dt = Database.GetData(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    string luongEnc = dt.Rows[0]["LUONG_ENC"].ToString();

                    // 4. Kiểm tra dữ liệu lấy được
                    if (string.IsNullOrEmpty(luongEnc))
                        MessageBox.Show("Cảnh báo: Cột LUONG_ENC trong Database đang rỗng!");
                    else
                        txtLuongMaHoa.Text = luongEnc;

                    txtLuongThuc.Text = "**********";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dòng dữ liệu nào trong DB!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LỖI CHẾT NGƯỜI: " + ex.Message);
            }
        }

        private void btnGiaiMa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu ô mã hóa trống
                if (string.IsNullOrEmpty(txtLuongMaHoa.Text) || txtLuongMaHoa.Text.StartsWith("("))
                {
                    MessageBox.Show("Không có dữ liệu mã hóa để giải mã!", "Thông báo");
                    return;
                }

                // Gọi hàm giải mã
                string luongThuc = SymmetricHelper.Decrypt(txtLuongMaHoa.Text);

                if (luongThuc == "[Lỗi giải mã]" || luongThuc == null)
                {
                    MessageBox.Show("Giải mã thất bại! Dữ liệu bị lỗi hoặc sai khóa bảo mật.", "Lỗi Giải Mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Hiển thị kết quả thành công
                    txtLuongThuc.UseSystemPasswordChar = false; // Hiện số rõ ràng

                    double luongSo;
                    if (double.TryParse(luongThuc, out luongSo))
                    {
                        txtLuongThuc.Text = luongSo.ToString("N0") + " VNĐ"; // Format tiền tệ đẹp (VD: 20,000,000 VNĐ)
                    }
                    else
                    {
                        txtLuongThuc.Text = luongThuc; // Nếu không phải số thì hiện nguyên văn
                    }

                    txtLuongThuc.ForeColor = Color.Red; // Đổi màu đỏ cho nổi bật
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình giải mã: " + ex.Message);
            }
        }
    }
}