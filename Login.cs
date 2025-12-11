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
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassWork.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin kết nối Oracle!");
                return;
            }

            // 2. Set thông tin kết nối vào Class Database
            Database.Set_Database(txtHost.Text, txtPort.Text, txtSid.Text, txtUser.Text, txtPassWork.Text);

            // 3. Thử kết nối
            if (Database.Connect())
            {
                MessageBox.Show("Kết nối Database thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ❌ BỎ HẾT: this.Hide(), new frmDangNhap, ShowDialog, this.Close()

                // ✅ Chỉ cần báo cho Program.cs biết là OK
                this.DialogResult = DialogResult.OK;
                // Sau đó form sẽ tự đóng, quay lại Program.cs
            }
            else
            {
                MessageBox.Show("Kết nối thất bại. Kiểm tra lại Host, Port, SID hoặc User/Pass Oracle!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassWork.Clear();
                txtPassWork.Focus();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}