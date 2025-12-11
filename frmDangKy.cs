using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography; // Để dùng SHA256
using System.Collections.Generic; // Cần thiết cho HashSet

namespace Nhom5_QuanLyKhachSan
{
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // 1. Khởi tạo và Load dữ liệu cho ComboBox chức vụ TRƯỚC khi set Index loại TK
            LoadChucVu();

            // 2. Khởi tạo ComboBox loại tài khoản
            cboLoaiTaiKhoan.Items.Add("Nhân viên");
            cboLoaiTaiKhoan.Items.Add("Khách hàng");
            cboLoaiTaiKhoan.SelectedIndex = 0; // Mặc định chọn Nhân viên

            // 3. Gọi ShowHideControls lần đầu để thiết lập giao diện cho 'Nhân viên'
            ShowHideControls(cboLoaiTaiKhoan.SelectedItem.ToString());
        }

        private void lblHoTen_Click(object sender, EventArgs e) { }

        // --- HÀM HỖ TRỢ: LOAD CHỨC VỤ CHO COMBOBOX (Đã tối ưu hóa chống trùng lặp) ---
        private void LoadChucVu()
        {
            cboChucVu.Items.Clear(); // Xóa các mục cũ nếu có

            // Lấy danh sách chức vụ DISTINCT từ bảng NHANVIEN 
            string sql = "SELECT DISTINCT CHUCVU FROM QUANLYKS.NHANVIEN WHERE CHUCVU IS NOT NULL ORDER BY CHUCVU";
            DataTable dt = Database.GetData(sql);

            // Danh sách các chức vụ mặc định/cơ bản
            string[] defaultChucVu = { "LETAN", "QUANLY", "KETOAN", "NHANVIEN" };

            // Thêm các chức vụ từ DB vào danh sách tạm thời (chống trùng lặp)
            HashSet<string> uniqueChucVu = new HashSet<string>(defaultChucVu);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string chucVu = row["CHUCVU"].ToString().Trim().ToUpper();
                    uniqueChucVu.Add(chucVu);
                }
            }

            // Thêm tất cả các chức vụ duy nhất vào ComboBox và sắp xếp
            var sortedChucVu = uniqueChucVu.OrderBy(c => c).ToList();
            foreach (var chucVu in sortedChucVu)
            {
                cboChucVu.Items.Add(chucVu);
            }

            if (cboChucVu.Items.Count > 0)
            {
                cboChucVu.SelectedIndex = 0;
            }
        }


        // --- HÀM ẨN/HIỆN CÁC TRƯỜNG DỮ LIỆU ---
        private void ShowHideControls(string type)
        {
            // Reset nhãn và thiết lập hiển thị ban đầu
            lblUser.Text = "Tên đăng nhập (*):";
            lblPass.Text = "Mật khẩu (*):";
            lblConfirm.Text = "Nhập lại mật khẩu (*):";

            bool isNhanVien = (type == "Nhân viên");

            // --- Ẩn/hiện các trường chung ---
            lblUser.Visible = isNhanVien;
            txtTenDangNhap.Visible = isNhanVien;
            lblPass.Visible = isNhanVien;
            txtMatKhau.Visible = isNhanVien;
            lblConfirm.Visible = isNhanVien;
            txtXacNhanMK.Visible = isNhanVien;
            lblEmail.Visible = isNhanVien;
            txtEmail.Visible = isNhanVien;

            // --- Ẩn/hiện các trường đặc trưng ---

            // Nhân viên
            lblLuongCoBan.Visible = isNhanVien;
            txtLuong.Visible = isNhanVien;
            lblChucVu.Visible = isNhanVien;
            cboChucVu.Visible = isNhanVien;

            // Khách hàng
            lblCCCD.Visible = !isNhanVien;
            txtCCCD.Visible = !isNhanVien;
            lblDiaChi.Visible = !isNhanVien;
            txtDiaChi.Visible = !isNhanVien;

            // --- Điều chỉnh vị trí controls ---
            if (isNhanVien)
            {
                // Vị trí Mặc định cho Nhân viên: SDT -> Lương -> Chức vụ
                // Lương
                lblLuongCoBan.Location = new Point(12, 369);
                txtLuong.Location = new Point(227, 378);
                // Chức vụ
                lblChucVu.Location = new Point(12, 411);
                cboChucVu.Location = new Point(227, 420);

                // Nút Đăng ký (ở cuối)
                btnDangKy.Location = new Point(96, 483);
                btnThoat.Location = new Point(363, 483);
            }
            else
            {
                // Vị trí Mặc định cho Khách hàng: SDT -> CCCD -> Địa chỉ

                // CCCD (Thay thế vị trí Lương)
                lblCCCD.Location = new Point(12, 369);
                txtCCCD.Location = new Point(227, 378);

                // Địa chỉ (Thay thế vị trí Chức vụ)
                lblDiaChi.Location = new Point(12, 411);
                txtDiaChi.Location = new Point(227, 420);

                // Nút Đăng ký (ở cuối)
                btnDangKy.Location = new Point(96, 483);
                btnThoat.Location = new Point(363, 483);
            }

            // Đảm bảo cboChucVu có mục được chọn khi hiển thị
            if (isNhanVien && cboChucVu.SelectedIndex == -1 && cboChucVu.Items.Count > 0)
            {
                cboChucVu.SelectedIndex = 0;
            }
        }

        // --- SỰ KIỆN KHI CHỌN LOẠI TÀI KHOẢN KHÁC NHAU ---
        private void cboLoaiTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowHideControls(cboLoaiTaiKhoan.SelectedItem.ToString());
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (cboLoaiTaiKhoan.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản đăng ký.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string loaiTaiKhoan = cboLoaiTaiKhoan.SelectedItem.ToString();

            try
            {
                if (loaiTaiKhoan == "Nhân viên")
                {
                    // 1. Kiểm tra dữ liệu bắt buộc cho Nhân viên
                    if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtTenDangNhap.Text) ||
                        string.IsNullOrEmpty(txtMatKhau.Text) || string.IsNullOrEmpty(txtXacNhanMK.Text) ||
                        string.IsNullOrEmpty(txtLuong.Text) || string.IsNullOrEmpty(txtSDT.Text) ||
                        cboChucVu.SelectedItem == null)
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ các thông tin bắt buộc (*)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (txtMatKhau.Text != txtXacNhanMK.Text)
                    {
                        MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2. Kiểm tra tên đăng nhập
                    string sqlCheck = string.Format("SELECT COUNT(*) FROM QUANLYKS.NHANVIEN WHERE TENDANGNHAP = '{0}'", txtTenDangNhap.Text);
                    DataTable dtCheck = Database.GetData(sqlCheck);
                    if (dtCheck.Rows[0][0].ToString() != "0")
                    {
                        MessageBox.Show("Tên đăng nhập này đã có người sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 3. Tự động sinh Mã Nhân Viên
                    string maNV = TaoMaNhanVienTuDong();

                    // 4. Mã hóa mật khẩu, Lương và lấy Chức vụ
                    string passwordHash = CalculateSHA256(txtMatKhau.Text);
                    string luongMaHoa = SymmetricHelper.Encrypt(txtLuong.Text);
                    string chucVu = cboChucVu.SelectedItem.ToString();

                    if (luongMaHoa == null)
                    {
                        MessageBox.Show("Lỗi mã hóa lương! Kiểm tra SymmetricHelper.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 5. Câu lệnh Insert Nhân viên (Sử dụng HEXTORAW cho cột LUONG_ENC kiểu RAW)
                    string sqlInsert = string.Format(
                        "INSERT INTO QUANLYKS.NHANVIEN (MANV, HOTEN, TENDANGNHAP, MATKHAU, EMAIL, SDT, CHUCVU, LUONG_ENC, LUONG_GOC) " +
                        "VALUES ('{0}', N'{1}', '{2}', '{3}', '{4}', '{5}', '{8}', HEXTORAW('{6}'), {7})",
                        maNV,
                        txtHoTen.Text,
                        txtTenDangNhap.Text,
                        passwordHash,
                        txtEmail.Text,
                        txtSDT.Text,
                        luongMaHoa,
                        0, // LƯƠNG_GOC (Giữ 0 theo mục tiêu bảo mật)
                        chucVu // CHUCVU
                    );

                    // 6. Thực thi
                    if (Database.ExecuteNonQuery(sqlInsert))
                    {
                        MessageBox.Show("Đăng ký Nhân viên thành công!\nMã NV: " + maNV + "\nLương đã được mã hóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký Nhân viên thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (loaiTaiKhoan == "Khách hàng")
                {
                    // 1. Kiểm tra dữ liệu bắt buộc cho Khách hàng
                    if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtSDT.Text) ||
                        string.IsNullOrEmpty(txtCCCD.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ các thông tin bắt buộc (*)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 2. Tự động sinh Mã Khách Hàng
                    string maKH = TaoMaKhachHangTuDong();

                    // 3. Mã hóa CCCD/Passport bằng AES
                    string cccdMaHoa = SymmetricHelper.Encrypt(txtCCCD.Text);
                    if (cccdMaHoa == null)
                    {
                        MessageBox.Show("Lỗi mã hóa CCCD! Kiểm tra SymmetricHelper.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 4. Câu lệnh Insert Khách hàng (Sử dụng HEXTORAW cho cột CCCD_ENC kiểu RAW)
                    string sqlInsert = string.Format(
                        "INSERT INTO QUANLYKS.KHACHHANG (MAKH, HOTEN, SDT, DIACHI, CCCD_ENC, CCCD_GOC) " +
                        "VALUES ('{0}', N'{1}', '{2}', N'{3}', HEXTORAW('{4}'), '{5}')",
                        maKH,
                        txtHoTen.Text,
                        txtSDT.Text,
                        txtDiaChi.Text,
                        cccdMaHoa,
                        txtCCCD.Text // Lưu bản gốc vào cột CCCD_GOC
                    );

                    // 5. Thực thi
                    if (Database.ExecuteNonQuery(sqlInsert))
                    {
                        MessageBox.Show("Đăng ký Khách hàng thành công!\nMã KH: " + maKH + "\nCCCD đã được mã hóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký Khách hàng thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            string sql = "SELECT MANV FROM QUANLYKS.NHANVIEN ORDER BY MANV DESC";
            DataTable dt = Database.GetData(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                string maCuoi = dt.Rows[0]["MANV"].ToString();
                if (maCuoi.Length >= 3 && maCuoi.StartsWith("NV"))
                {
                    string phanSo = maCuoi.Substring(2);
                    if (int.TryParse(phanSo, out int soMoi))
                    {
                        soMoi += 1;
                        return "NV" + soMoi.ToString("D2"); // D2: Định dạng 2 chữ số (01, 02,...)
                    }
                }
            }
            return "NV01";
        }

        // --- HÀM HỖ TRỢ: TẠO MÃ KH TỰ ĐỘNG ---
        private string TaoMaKhachHangTuDong()
        {
            string sql = "SELECT MAKH FROM QUANLYKS.KHACHHANG ORDER BY MAKH DESC";
            DataTable dt = Database.GetData(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                string maCuoi = dt.Rows[0]["MAKH"].ToString();
                if (maCuoi.Length >= 3 && maCuoi.StartsWith("KH"))
                {
                    string phanSo = maCuoi.Substring(2);
                    if (int.TryParse(phanSo, out int soMoi))
                    {
                        soMoi += 1;
                        return "KH" + soMoi.ToString("D2");
                    }
                }
            }
            return "KH01";
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