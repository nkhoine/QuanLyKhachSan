using System;
using System.Data;
using System.Globalization; // Cần thiết cho định dạng số tiền
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Nhom5_QuanLyKhachSan
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
            // Đảm bảo Form hiển thị ở giữa màn hình khi chạy
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            ApplyPermissions(); // NEW: Áp quyền theo Session.ChucVu
            LoadData();
        }

        /// <summary>
        /// Hàm kiểm tra user hiện tại có phải ADMIN hay không
        /// </summary>
        private bool IsCurrentUserAdmin()
        {
            return string.Equals((Session.ChucVu ?? "").Trim(),
                                 "ADMIN",
                                 StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Áp dụng phân quyền: chỉ ADMIN mới được thêm/sửa/xóa
        /// Nhân viên thường chỉ được xem danh sách
        /// </summary>
        private void ApplyPermissions()
        {
            bool isAdmin = IsCurrentUserAdmin();

            // Chỉ ADMIN mới được thao tác dữ liệu
            btnThem.Enabled = isAdmin;
            btnSua.Enabled = isAdmin;
            btnXoa.Enabled = isAdmin;

            // Nếu muốn: nhân viên thường chỉ xem (không sửa trực tiếp trong lưới)
            dgvNhanVien.ReadOnly = !isAdmin;
            dgvNhanVien.AllowUserToAddRows = isAdmin;
            dgvNhanVien.AllowUserToDeleteRows = isAdmin;
        }

        /// <summary>
        /// Nạp dữ liệu từ bảng NHANVIEN lên DataGridView (Sử dụng cột mã hóa và giải mã)
        /// </summary>
        private void LoadData()
        {
            dgvNhanVien.AutoGenerateColumns = true;
            try
            {
                string sql = "SELECT MANV, HOTEN, CHUCVU, SDT, EMAIL, TENDANGNHAP, LUONG_GOC, " +
                             "RAWTOHEX(LUONG_ENC) AS LUONG_ENCRYPTED_HEX " +
                             "FROM QUANLYKS.NHANVIEN ORDER BY MANV";

                DataTable dt = Database.GetData(sql);

                if (dt != null)
                {
                    dt.Columns.Add("LUONG_DECRYPTED", typeof(string));

                    foreach (DataRow row in dt.Rows)
                    {
                        object luongEncValue = row["LUONG_ENCRYPTED_HEX"];
                        string luongHex = (luongEncValue == null || luongEncValue == DBNull.Value)
                                            ? ""
                                            : luongEncValue.ToString();

                        string luongGiaiMa = "";
                        if (!string.IsNullOrEmpty(luongHex))
                        {
                            // Gọi hàm giải mã từ SymmetricHelper
                            luongGiaiMa = SymmetricHelper.Decrypt(luongHex);

                            // Format lại giá trị số tiền (Thêm dấu phân cách hàng nghìn)
                            if (double.TryParse(luongGiaiMa, NumberStyles.Any,
                                CultureInfo.InvariantCulture, out double luongValue))
                            {
                                luongGiaiMa = luongValue.ToString("N0", new CultureInfo("vi-VN"));
                            }
                        }

                        // Nếu LUONG_ENC là NULL (dữ liệu cũ), hiển thị LUONG_GOC
                        if (string.IsNullOrEmpty(luongGiaiMa) && row["LUONG_GOC"] != DBNull.Value)
                        {
                            luongGiaiMa = Convert.ToDecimal(row["LUONG_GOC"])
                                .ToString("N0", new CultureInfo("vi-VN"));
                        }

                        row["LUONG_DECRYPTED"] = luongGiaiMa;
                    }

                    dgvNhanVien.DataSource = dt;

                    // Thiết lập hiển thị cột
                    dgvNhanVien.Columns["MANV"].HeaderText = "Mã NV";
                    dgvNhanVien.Columns["HOTEN"].HeaderText = "Họ Tên";
                    dgvNhanVien.Columns["CHUCVU"].HeaderText = "Chức Vụ";
                    dgvNhanVien.Columns["SDT"].HeaderText = "SĐT";

                    // Ẩn các cột dữ liệu thô/mã hóa
                    if (dgvNhanVien.Columns.Contains("LUONG_GOC"))
                        dgvNhanVien.Columns["LUONG_GOC"].Visible = false;
                    if (dgvNhanVien.Columns.Contains("LUONG_ENCRYPTED_HEX"))
                        dgvNhanVien.Columns["LUONG_ENCRYPTED_HEX"].Visible = false;

                    // Hiển thị cột đã giải mã
                    dgvNhanVien.Columns["LUONG_DECRYPTED"].HeaderText = "Lương Cơ Bản";
                    dgvNhanVien.Columns["LUONG_DECRYPTED"].DisplayIndex = 4; // Vị trí sau SDT
                }

                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp dữ liệu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xóa nội dung trong các TextBox và mở khóa Mã NV
        /// </summary>
        private void ClearInputFields()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtChucVu.Clear();
            txtLuong.Clear();
            // nếu có txtSDT / txtEmail thì Clear thêm ở đây
            txtMaNV.ReadOnly = false; // Luôn mở khóa khi sẵn sàng cho chức năng Thêm mới
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNhanVien.Rows.Count - 1)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                txtMaNV.Text = row.Cells["MANV"].Value.ToString();
                txtHoTen.Text = row.Cells["HOTEN"].Value.ToString();
                txtChucVu.Text = row.Cells["CHUCVU"].Value.ToString();

                string luongFormatted = row.Cells["LUONG_DECRYPTED"].Value.ToString();
                txtLuong.Text = luongFormatted.Replace(".", "").Replace(",", "");

                txtMaNV.ReadOnly = true;
            }
        }

        /// <summary>
        /// Sự kiện click nút Làm mới: Xóa trắng các ô nhập và load lại dữ liệu
        /// </summary>
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadData();
            txtMaNV.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Chỉ ADMIN mới được mở form đăng ký nhân viên
            if (!IsCurrentUserAdmin())
            {
                MessageBox.Show("Chỉ ADMIN mới có quyền thêm (đăng ký) nhân viên mới!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở form đăng ký nhân viên (form cũ bạn đã làm)
            using (frmDangKy f = new frmDangKy())
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog();   // Đăng ký xong thì đóng lại
            }

            // Sau khi đăng ký xong, load lại danh sách nhân viên
            LoadData();
            ClearInputFields();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Chỉ ADMIN mới được sửa nhân viên
            if (!IsCurrentUserAdmin())
            {
                MessageBox.Show("Chỉ ADMIN mới có quyền sửa thông tin nhân viên!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtLuong.Text, out decimal newLuong))
            {
                MessageBox.Show("Lương nhập vào không hợp lệ! Vui lòng chỉ nhập số.",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string luongMaHoa = SymmetricHelper.Encrypt(newLuong.ToString());
            if (luongMaHoa == null)
            {
                MessageBox.Show("Lỗi mã hóa lương mới!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sql = string.Format(
                "UPDATE QUANLYKS.NHANVIEN " +
                "SET HOTEN = N'{0}', CHUCVU = N'{1}', " +
                "LUONG_ENC = HEXTORAW('{2}'), LUONG_GOC = {3} " +
                "WHERE MANV = '{4}'",
                txtHoTen.Text.Trim().Replace("'", "''"),
                txtChucVu.Text.Trim().Replace("'", "''"),
                luongMaHoa,
                0,
                txtMaNV.Text.Trim().Replace("'", "''"));

            if (Database.ExecuteNonQuery(sql))
            {
                MessageBox.Show("Sửa thông tin nhân viên thành công! Lương mới đã được mã hóa.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInputFields();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Chỉ ADMIN mới được xóa nhân viên
            if (!IsCurrentUserAdmin())
            {
                MessageBox.Show("Chỉ ADMIN mới có quyền xóa nhân viên!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || txtMaNV.ReadOnly == false)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa trong danh sách!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Không cho xóa chính mình (optional)
            if (txtMaNV.Text.Trim().Equals(Session.MaNV, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nhân viên có Mã: {txtMaNV.Text} không?",
                "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                string sql = "DELETE FROM QUANLYKS.NHANVIEN WHERE MANV = '" +
                             txtMaNV.Text.Trim().Replace("'", "''") + "'";

                if (Database.ExecuteNonQuery(sql))
                {
                    MessageBox.Show("Xóa nhân viên thành công!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInputFields();
                }
            }

        }
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

    }

}
