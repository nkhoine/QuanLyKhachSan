using System;
using System.Windows.Forms;

namespace Nhom5_QuanLyKhachSan
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Sự kiện khi bấm nút Login (Kết nối Database)
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassWork.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin kết nối Oracle!");
                return;
            }

            // 2. Set thông tin kết nối vào Class Database
            // Lưu ý: Đây là thông tin để kết nối tới Oracle server
            Database.Set_Database(txtHost.Text, txtPort.Text, txtSid.Text, txtUser.Text, txtPassWork.Text);

            // 3. Thử kết nối
            if (Database.Connect())
            {
                MessageBox.Show("Kết nối Database thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // --- PHẦN CHỈNH SỬA: CHUYỂN SANG FORM ĐĂNG NHẬP ---

                // Ẩn form cấu hình kết nối (frmLogin) đi
                this.Hide();

                // Khởi tạo form Đăng Nhập nhân viên (frmDangNhap)
                frmDangNhap formDN = new frmDangNhap();

                // Hiển thị form Đăng Nhập
                // Sử dụng ShowDialog để khi tắt form Đăng Nhập, code mới chạy tiếp xuống dòng this.Close()
                formDN.ShowDialog();

                // Đóng form kết nối này lại sau khi form Đăng nhập đã tắt
                this.Close();
            }
            else
            {
                MessageBox.Show("Kết nối thất bại. Kiểm tra lại Host, Port, SID hoặc User/Pass Oracle!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassWork.Clear();
                txtPassWork.Focus();
            }
        }
    }
}