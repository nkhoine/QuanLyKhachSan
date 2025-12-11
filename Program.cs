using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_QuanLyKhachSan
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var fLogin = new frmLogin())
            {
                if (fLogin.ShowDialog() == DialogResult.OK)
                {
                    // Bước 2: nếu kết nối Oracle OK thì vào form đăng nhập nhân viên
                    Application.Run(new frmDangNhap());
                }
                else
                {
                    // Người dùng thoát hoặc không kết nối được
                    Application.Exit();
                }
            }
        }
    }
}
