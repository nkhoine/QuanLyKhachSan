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
                // 2. Mã hóa mật khẩu người dùng nhập vào để so sánh với DB
                string passwordHash = CalculateSHA256(txtMatKhau.Text);

                // 3. Tạo câu truy vấn SQL
                // Lưu ý: Cần đảm bảo lớp Database của bạn có phương thức thực thi truy vấn trả về DataTable (ví dụ: GetData, ExecuteQuery...)
                string sql = string.Format("SELECT * FROM NHANVIEN WHERE TENDANGNHAP = '{0}' AND MATKHAU = '{1}'",
                                            txtTenDangNhap.Text, passwordHash);

                // GỌI HÀM LẤY DỮ LIỆU TỪ LỚP DATABASE CỦA BẠN
                // Giả sử lớp Database của bạn có hàm 'GetData' trả về DataTable. 
                // Nếu tên hàm khác (ví dụ: GetDataTable, Read...), hãy sửa lại dòng dưới đây.
                DataTable dt = Database.GetData(sql);

                // 4. Kiểm tra kết quả
                if (dt != null && dt.Rows.Count > 0)
                {
                    // Lấy thông tin nhân viên nếu cần lưu phiên làm việc
                    string tenNhanVien = dt.Rows[0]["HOTEN"].ToString();
                    string quyenHan = dt.Rows[0]["CHUCVU"].ToString();

                    MessageBox.Show("Đăng nhập thành công!\nXin chào: " + tenNhanVien, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở form chính (Form Main) tại đây
                    // frmMain f = new frmMain();
                    // f.Show();

                    this.Hide(); // Ẩn form đăng nhập
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
            MessageBox.Show("Vui lòng liên hệ Admin để cấp tài khoản nhân viên.", "Thông báo");
        }
    }
}
