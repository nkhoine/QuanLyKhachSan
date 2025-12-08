using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography; // Để dùng SHA256

namespace Nhom5_QuanLyKhachSan
{
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void lblHoTen_Click(object sender, EventArgs e) { }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtTenDangNhap.Text) ||
                string.IsNullOrEmpty(txtMatKhau.Text) || string.IsNullOrEmpty(txtXacNhanMK.Text) ||
                string.IsNullOrEmpty(txtLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin bắt buộc (*)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtMatKhau.Text != txtXacNhanMK.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 2. Kiểm tra tên đăng nhập (Đã thêm QUANLYKS.)
                string sqlCheck = string.Format("SELECT COUNT(*) FROM QUANLYKS.NHANVIEN WHERE TENDANGNHAP = '{0}'", txtTenDangNhap.Text);
                DataTable dtCheck = Database.GetData(sqlCheck);
                if (dtCheck.Rows[0][0].ToString() != "0")
                {
                    MessageBox.Show("Tên đăng nhập này đã có người sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Tự động sinh Mã Nhân Viên
                string maNV = TaoMaNhanVienTuDong();

                // 4. Mã hóa mật khẩu
                string passwordHash = CalculateSHA256(txtMatKhau.Text);

                // 5. Mã hóa Lương bằng AES
                string luongMaHoa = SymmetricHelper.Encrypt(txtLuong.Text);

                if (luongMaHoa == null)
                {
                    MessageBox.Show("Lỗi mã hóa lương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 6. Câu lệnh Insert (Đã thêm QUANLYKS. trước tên bảng) <--- QUAN TRỌNG
                string sqlInsert = string.Format(
                    "INSERT INTO QUANLYKS.NHANVIEN (MANV, HOTEN, TENDANGNHAP, MATKHAU, EMAIL, SDT, CHUCVU, LUONG_ENC, LUONG_GOC) " +
                    "VALUES ('{0}', N'{1}', '{2}', '{3}', '{4}', '{5}', 'NHANVIEN', '{6}', 0)",
                    maNV,
                    txtHoTen.Text,
                    txtTenDangNhap.Text,
                    passwordHash,
                    txtEmail.Text,
                    txtSDT.Text,
                    luongMaHoa
                );

                // 7. Thực thi
                if (Database.ExecuteNonQuery(sqlInsert))
                {
                    MessageBox.Show("Đăng ký thành công!\nMã NV: " + maNV + "\nLương đã được mã hóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- HÀM HỖ TRỢ: TẠO MÃ NV TỰ ĐỘNG ---
        private string TaoMaNhanVienTuDong()
        {
            // Đã thêm QUANLYKS. vào trước tên bảng <--- QUAN TRỌNG
            string sql = "SELECT MANV FROM QUANLYKS.NHANVIEN ORDER BY MANV DESC";
            DataTable dt = Database.GetData(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                string maCuoi = dt.Rows[0]["MANV"].ToString();
                string phanSo = maCuoi.Substring(2);
                int soMoi = int.Parse(phanSo) + 1;

                if (soMoi < 10) return "NV0" + soMoi;
                return "NV" + soMoi;
            }
            return "NV01";
        }

        // --- HÀM MÃ HÓA SHA256 ---
        private string CalculateSHA256(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void txtLuong_TextChanged(object sender, EventArgs e) { }
    }
}