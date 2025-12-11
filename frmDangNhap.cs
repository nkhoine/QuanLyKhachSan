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
using Oracle.ManagedDataAccess.Client;

namespace Nhom5_QuanLyKhachSan
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // --- THÊM DÒNG NÀY ĐỂ CHE MẬT KHẨU ---
            // Nó sẽ biến các ký tự nhập vào thành dấu chấm đen (●) chuẩn của hệ thống
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            btnTaoTaiKhoan.Visible = false;
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
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenDN = txtTenDangNhap.Text.Trim();
            string matKhauNhap = txtMatKhau.Text.Trim();

            try
            {
                // 2. Lấy nhân viên theo TENDANGNHAP
                string sqlCheck = string.Format(
                    "SELECT MANV, HOTEN, CHUCVU, TENDANGNHAP, MATKHAU, FAILED_LOGIN, LOCK_UNTIL " +
                    "FROM QUANLYKS.NHANVIEN " +
                    "WHERE TENDANGNHAP = '{0}'",
                    tenDN.Replace("'", "''")
                );

                DataTable dt = Database.GetData(sqlCheck);

                if (dt == null || dt.Rows.Count == 0)
                {
                    // Không có user này
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                    return;
                }

                DataRow row = dt.Rows[0];

                string maNV = row["MANV"].ToString();
                string hoTen = row["HOTEN"].ToString();
                string chucVu = row["CHUCVU"].ToString();
                string tenDangNhap = row["TENDANGNHAP"].ToString();
                string matKhauDB = row["MATKHAU"].ToString();

                int failed = 0;
                if (row["FAILED_LOGIN"] != DBNull.Value)
                    failed = Convert.ToInt32(row["FAILED_LOGIN"]);

                // 3. Kiểm tra có đang bị khóa không
                if (row["LOCK_UNTIL"] != DBNull.Value)
                {
                    DateTime lockUntil = Convert.ToDateTime(row["LOCK_UNTIL"]);
                    if (lockUntil > DateTime.Now)
                    {
                        MessageBox.Show(
                            "Tài khoản của bạn đang bị tạm khóa.\n" +
                            "Vui lòng thử lại sau: " + lockUntil.ToString("HH:mm:ss dd/MM/yyyy"),
                            "Tài khoản bị khóa",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning
                        );
                        return;
                    }
                }

                // 4. Kiểm tra mật khẩu
                string hashNhap = CalculateSHA256(matKhauNhap);

                if (hashNhap == matKhauDB)
                {
                    // === ĐÚNG MẬT KHẨU ===

                    // Reset thất bại + mở khóa
                    string sqlReset = string.Format(
                        "UPDATE QUANLYKS.NHANVIEN " +
                        "SET FAILED_LOGIN = 0, LOCK_UNTIL = NULL " +
                        "WHERE MANV = '{0}'",
                        maNV
                    );
                    Database.ExecuteNonQuery(sqlReset);

                    // Lưu Session C#
                    Session.MaNV = maNV;
                    Session.HoTen = hoTen;
                    Session.ChucVu = (chucVu ?? "").Trim().ToUpper();
                    Session.TenDangNhap = tenDangNhap;

                    // --- Xử lý lỗi Context Oracle ---
                    try
                    {
                        // Set context nếu bạn dùng VPD/audit
                        Database.SetCurrentUserInfo(maNV, hoTen);
                    }
                    catch (Exception exContext)
                    {
                        // Nếu lỗi ORA-01031 hoặc lỗi context khác, chỉ hiện thông báo nhỏ
                        // nhưng VẪN CHO ĐĂNG NHẬP tiếp tục.
                        MessageBox.Show("Cảnh báo Database (Context): " + exContext.Message +
                                        "\nBạn vẫn có thể đăng nhập, nhưng tính năng bảo mật nâng cao có thể bị hạn chế.",
                                        "Cảnh báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    // -------------------------------

                    MessageBox.Show("Đăng nhập thành công!\nXin chào: " + hoTen,
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmMain f = new frmMain();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    // === SAI MẬT KHẨU ===

                    failed += 1;

                    if (failed >= 3)
                    {
                        // Khóa 3 phút
                        DateTime lockUntil = DateTime.Now.AddMinutes(3);
                        string lockStr = lockUntil.ToString("dd/MM/yyyy HH:mm:ss");

                        string sqlLock = string.Format(
                            "UPDATE QUANLYKS.NHANVIEN " +
                            "SET FAILED_LOGIN = 0, " +
                            "    LOCK_UNTIL = TO_DATE('{0}','DD/MM/YYYY HH24:MI:SS') " +
                            "WHERE MANV = '{1}'",
                            lockStr, maNV
                        );
                        Database.ExecuteNonQuery(sqlLock);

                        MessageBox.Show(
                            "Bạn đã nhập sai mật khẩu 3 lần liên tiếp.\n" +
                            "Tài khoản bị tạm khóa trong 3 phút.",
                            "Tài khoản bị khóa",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning
                        );
                    }
                    else
                    {
                        // Cập nhật lại số lần sai
                        string sqlUpdateFail = string.Format(
                            "UPDATE QUANLYKS.NHANVIEN " +
                            "SET FAILED_LOGIN = {0} " +
                            "WHERE MANV = '{1}'",
                            failed, maNV
                        );
                        Database.ExecuteNonQuery(sqlUpdateFail);

                        int soLanConLai = 3 - failed;
                        MessageBox.Show(
                            "Sai mật khẩu!\nBạn còn " + soLanConLai + " lần thử trước khi bị khóa 3 phút.",
                            "Đăng nhập thất bại",
                            MessageBoxButtons.OK, MessageBoxIcon.Error
                        );
                    }

                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối hoặc truy vấn: " + ex.Message,
                                "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MessageBox.Show("Tài khoản chỉ được tạo bởi ADMIN bên trong hệ thống.\n" +
                  "Vui lòng liên hệ quản trị viên.",
                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}