using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_QuanLyKhachSan
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Session.HoTen))
            {
                lblStatusTenNV.Text = "Xin chào: " + Session.HoTen + " (" + Session.ChucVu + ")";
            }

            string role = (Session.ChucVu ?? "").Trim().ToUpper();

            // Chỉ ADMIN mới thấy quản lý nhân viên + nhật ký hệ thống
            mnNhanVien.Visible = (role == "ADMIN");
            mnNhatKyHeThong.Visible = (role == "ADMIN");

            LoadDanhSachPhong();
        }

        private void LoadDanhSachPhong()
        {
            try
            {
                pnlSoDoPhong.Controls.Clear(); // Xóa các nút cũ nếu có

                // Truy vấn lấy danh sách phòng và loại phòng
                string sql = "SELECT P.MAPHONG, P.SOPHONG, P.TINHTRANG, L.TENLOAI, L.GIA_COBAN " +
                             "FROM QUANLYKS.PHONG P " + 
                             "JOIN QUANLYKS.LOAIPHONG L ON P.MALOAIPHONG = L.MALOAIPHONG " +
                             "ORDER BY P.MAPHONG";

                DataTable dt = Database.GetData(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        // Tạo Button cho mỗi phòng
                        Button btnRoom = new Button();
                        btnRoom.Width = 120;
                        btnRoom.Height = 120;
                        btnRoom.Margin = new Padding(10);

                        string soPhong = row["SOPHONG"].ToString();
                        string trangThai = row["TINHTRANG"].ToString();
                        string tenLoai = row["TENLOAI"].ToString();

                        btnRoom.Text = $"Phòng {soPhong}\n{tenLoai}\n({trangThai})";
                        btnRoom.Tag = row["MAPHONG"].ToString(); // Lưu mã phòng vào Tag để dùng sau này

                        // Tô màu dựa trên TRANGTHAI
                        switch (trangThai)
                        {
                            case "Trong":
                                btnRoom.BackColor = Color.PaleGreen;
                                break;
                            case "Dang o":
                                btnRoom.BackColor = Color.LightSalmon;
                                break;
                            case "Da dat":
                                btnRoom.BackColor = Color.Khaki;
                                break;
                            default:
                                btnRoom.BackColor = Color.LightGray;
                                break;
                        }

                        // Gán sự kiện Click để xem chi tiết phòng
                        btnRoom.Click += BtnRoom_Click;

                        // Thêm vào FlowLayoutPanel
                        pnlSoDoPhong.Controls.Add(btnRoom);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phòng: " + ex.Message);
            }
        }

        // --- SỰ KIỆN CLICK VÀO TỪNG PHÒNG TRÊN SƠ ĐỒ ---
        private void BtnRoom_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string maPhong = btn.Tag.ToString();

            // Mở form đặt phòng và truyền mã phòng được chọn sang
            // Lưu ý: Bên frmDatPhong cần có constructor: public frmDatPhong(string maPhong)
            frmDatPhong f = new frmDatPhong(maPhong); 
            
            // ShowDialog để đóng băng form chính cho đến khi form con tắt
            f.ShowDialog();

            // Sau khi tắt form con, load lại sơ đồ để cập nhật trạng thái (VD: Trống -> Đang ở)
            LoadDanhSachPhong();
        }

        // --- CÁC MENU HỆ THỐNG ---
        private void mnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Xóa Session
                Session.MaNV = "";
                Session.HoTen = "";

                // Mở lại form đăng nhập
                frmDangNhap f = new frmDangNhap();
                f.Show();
                this.Hide();
            }
        }

        private void mnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // --- CÁC MENU QUẢN LÝ ---
        private void mnNhanVien_Click(object sender, EventArgs e)
        {
            var role = (Session.ChucVu ?? "").ToUpper();
            if (role != "ADMIN")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmNhanVien f = new frmNhanVien();
            f.ShowDialog();
        }

        private void mnKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang f = new frmKhachHang();
            f.ShowDialog();
        }

        private void mnDichVu_Click(object sender, EventArgs e)
        {
            frmDichVu f = new frmDichVu();
            f.ShowDialog();
        }

        // Menu "Phòng" (Mở form đặt phòng mặc định, không chọn trước phòng nào)
        private void mnPhong_Click(object sender, EventArgs e)
        {
            frmDatPhong f = new frmDatPhong(); 
            f.ShowDialog();

            // Load lại sơ đồ phòng sau khi đóng form quản lý phòng
            LoadDanhSachPhong();
        }

        // --- CÁC MENU THỐNG KÊ ---
        private void mnDoanhThu_Click(object sender, EventArgs e)
        {
            frmDoanhThu f = new frmDoanhThu();
            f.ShowDialog();
        }

        private void mnHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon f = new frmHoaDon();
            f.ShowDialog();
        }

        // --- CÁC EVENT KHÁC (GIỮ NGUYÊN HOẶC ĐỂ TRỐNG NẾU CHƯA DÙNG) ---
        private void mnQuanLy_Click(object sender, EventArgs e) { }

        private void pnlSoDoPhong_Paint(object sender, PaintEventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mnNhatKyHeThong_Click(object sender, EventArgs e)
        {
            frmNhatKyHeThong f = new frmNhatKyHeThong();
            f.StartPosition = FormStartPosition.CenterParent;  // cho đẹp
            f.ShowDialog();  // mở form nhật ký
        }
    }
}