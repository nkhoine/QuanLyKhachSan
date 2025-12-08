using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Nhom5_QuanLyKhachSan
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(txtTenDangNhap.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Mã hóa mật khẩu người dùng nhập vào
                string passwordHash = CalculateSHA256(txtMatKhau.Text);

                // 3. Tạo câu truy vấn SQL (Thêm QUANLYKS. để tránh lỗi không tìm thấy bảng)
                string sql = string.Format("SELECT * FROM QUANLYKS.NHANVIEN WHERE TENDANGNHAP = '{0}' AND MATKHAU = '{1}'",
                                            txtTenDangNhap.Text, passwordHash);

                // Gọi hàm lấy dữ liệu
                DataTable dt = Database.GetData(sql);

                // 4. Kiểm tra kết quả
                // Sau khi có DataTable (dt) từ Database:
                if (dt != null && dt.Rows.Count > 0)
                {
                    // 1. LƯU THÔNG TIN VÀO SESSION (Bắt buộc)
                    Session.MaNV = dt.Rows[0]["MANV"].ToString();
                    Session.HoTen = dt.Rows[0]["HOTEN"].ToString();
                    Session.ChucVu = dt.Rows[0]["CHUCVU"].ToString();
                    Session.TenDangNhap = dt.Rows[0]["TENDANGNHAP"].ToString();

                    MessageBox.Show("Đăng nhập thành công!\nXin chào: " + Session.HoTen, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 2. MỞ FORM PROFILE (Thay vì mở frmMain)
                    frmProfile f = new frmProfile();
                    f.Show();

                    this.Hide(); // Ẩn form đăng nhập đi
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối hoặc truy vấn: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // --- HÀM HỖ TRỢ MÃ HÓA SHA256 ---
        private string CalculateSHA256(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            // Mới: Mở form đăng ký
            frmDangKy f = new frmDangKy();
            this.Hide();     // Ẩn form đăng nhập tạm thời
            f.ShowDialog();  // Hiện form đăng ký (chờ xử lý xong)
            this.Show();     // Hiện lại form đăng nhập sau khi tắt form đăng ký
        }
    }
}
