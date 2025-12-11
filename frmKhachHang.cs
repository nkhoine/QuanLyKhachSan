using System;
using System.Data;
using System.Windows.Forms;

namespace Nhom5_QuanLyKhachSan
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // =================================================================================
        // PHẦN 1: HIỂN THỊ DỮ LIỆU (READ & DECRYPT)
        // =================================================================================
        private void LoadData()
        {
            try
            {
                // QUERY: Lấy cả dữ liệu GỐC và dữ liệu MÃ HÓA (chuyển sang HEX để C# đọc được)
                string sql = "SELECT MAKH, HOTEN, SDT, DIACHI, CCCD_GOC, " +
                             "RAWTOHEX(CCCD_ENC) AS CCCD_ENCRYPTED_HEX " +
                             "FROM KHACHHANG ORDER BY MAKH";

                DataTable dt = Database.GetData(sql);

                if (dt != null)
                {
                    // Tạo thêm cột ảo để chứa kết quả giải mã
                    dt.Columns.Add("CCCD_HIENTHI", typeof(string));

                    foreach (DataRow row in dt.Rows)
                    {
                        // 1. Lấy chuỗi Hex từ database
                        object cccdEncValue = row["CCCD_ENCRYPTED_HEX"];
                        string cccdHex = (cccdEncValue == DBNull.Value) ? "" : cccdEncValue.ToString();

                        string ketQuaHienThi = "";

                        // 2. Nếu có dữ liệu mã hóa -> Tiến hành GIẢI MÃ
                        if (!string.IsNullOrEmpty(cccdHex))
                        {
                            ketQuaHienThi = SymmetricHelper.Decrypt(cccdHex);
                        }

                        // 3. Fallback: Nếu giải mã ra rỗng (do dữ liệu cũ chưa mã hóa), lấy tạm cột CCCD_GOC
                        if (string.IsNullOrEmpty(ketQuaHienThi))
                        {
                            ketQuaHienThi = row["CCCD_GOC"] != DBNull.Value ? row["CCCD_GOC"].ToString() : "";
                        }

                        // 4. Gán vào cột hiển thị
                        row["CCCD_HIENTHI"] = ketQuaHienThi;
                    }

                    dgvKhachHang.DataSource = dt;
                    FormatGrid();
                }

                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void FormatGrid()
        {
            // Đặt tiêu đề tiếng Việt
            if (dgvKhachHang.Columns.Contains("MAKH")) dgvKhachHang.Columns["MAKH"].HeaderText = "Mã KH";
            if (dgvKhachHang.Columns.Contains("HOTEN")) dgvKhachHang.Columns["HOTEN"].HeaderText = "Họ Tên";
            if (dgvKhachHang.Columns.Contains("SDT")) dgvKhachHang.Columns["SDT"].HeaderText = "SĐT";
            if (dgvKhachHang.Columns.Contains("DIACHI")) dgvKhachHang.Columns["DIACHI"].HeaderText = "Địa Chỉ";
            if (dgvKhachHang.Columns.Contains("CCCD_HIENTHI")) dgvKhachHang.Columns["CCCD_HIENTHI"].HeaderText = "CCCD (Giải mã)";

            // Ẩn các cột kỹ thuật để bảo mật và gọn giao diện
            if (dgvKhachHang.Columns.Contains("CCCD_GOC")) dgvKhachHang.Columns["CCCD_GOC"].Visible = false;
            if (dgvKhachHang.Columns.Contains("CCCD_ENCRYPTED_HEX")) dgvKhachHang.Columns["CCCD_ENCRYPTED_HEX"].Visible = false;

            // Căn chỉnh độ rộng
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ClearInput()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtCCCD.Clear();

            txtMaKH.ReadOnly = false; // Mở khóa mã KH để nhập mới
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKhachHang.Rows.Count - 1)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

                txtMaKH.Text = row.Cells["MAKH"].Value.ToString();
                txtHoTen.Text = row.Cells["HOTEN"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtDiaChi.Text = row.Cells["DIACHI"].Value.ToString();

                // Lấy dữ liệu từ cột ĐÃ GIẢI MÃ đưa lên textbox
                if (dgvKhachHang.Columns.Contains("CCCD_HIENTHI"))
                    txtCCCD.Text = row.Cells["CCCD_HIENTHI"].Value.ToString();

                txtMaKH.ReadOnly = true; // Cấm sửa mã KH
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        // =================================================================================
        // PHẦN 2: THÊM - XÓA - SỬA (CUD)
        // =================================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtMaKH.Text) || string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã KH và CCCD!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Mã hóa số CCCD sang chuỗi HEX
            string cccdEncrypted = SymmetricHelper.Encrypt(txtCCCD.Text.Trim());

            if (cccdEncrypted == null)
            {
                MessageBox.Show("Lỗi mã hóa dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Tạo câu lệnh SQL
            // Lưu ý: Dùng HEXTORAW để Oracle hiểu chuỗi Hex và lưu vào cột RAW
            string sql = string.Format("INSERT INTO KHACHHANG (MAKH, HOTEN, SDT, DIACHI, CCCD_GOC, CCCD_ENC) " +
                                       "VALUES ('{0}', N'{1}', '{2}', N'{3}', '{4}', HEXTORAW('{5}'))",
                                       txtMaKH.Text.Trim(),
                                       txtHoTen.Text.Trim(),
                                       txtSDT.Text.Trim(),
                                       txtDiaChi.Text.Trim(),
                                       "BAO_MAT", // Ẩn dữ liệu gốc ngay từ đầu
                                       cccdEncrypted);

            // 3. Thực thi
            if (Database.ExecuteNonQuery(sql))
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo");
                LoadData();
            }
            // Lưu ý: Nếu lỗi ORA-00001 xảy ra, Database.ExecuteNonQuery sẽ hiện Popup thông báo lỗi đó.
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text)) return;

            // 1. Mã hóa lại số CCCD mới
            string cccdEncrypted = SymmetricHelper.Encrypt(txtCCCD.Text.Trim());

            // 2. Câu lệnh Update
            string sql = string.Format("UPDATE KHACHHANG SET HOTEN = N'{0}', SDT = '{1}', DIACHI = N'{2}', " +
                                       "CCCD_ENC = HEXTORAW('{3}'), CCCD_GOC = 'BAO_MAT' WHERE MAKH = '{4}'",
                                       txtHoTen.Text.Trim(),
                                       txtSDT.Text.Trim(),
                                       txtDiaChi.Text.Trim(),
                                       cccdEncrypted,
                                       txtMaKH.Text.Trim());

            if (Database.ExecuteNonQuery(sql))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text)) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng " + txtMaKH.Text + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Xử lý riêng cho Xóa để bắt lỗi ràng buộc khóa ngoại (ORA-02292)
                try
                {
                    string sql = "DELETE FROM KHACHHANG WHERE MAKH = '" + txtMaKH.Text.Trim() + "'";

                    // Gọi hàm ExecuteNonQuery. Nếu bên Database.cs có try-catch hiện lỗi thì nó sẽ hiện lỗi ORA.
                    // Nếu bạn muốn xử lý custom, bạn cần sửa bên Database.cs hoặc check dữ liệu trước.
                    if (Database.ExecuteNonQuery(sql))
                    {
                        MessageBox.Show("Đã xóa khách hàng!", "Thông báo");
                        LoadData();
                        ClearInput();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa. Lỗi: " + ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadData();
        }

        // =================================================================================
        // PHẦN 3: CHỨC NĂNG ĐẶC BIỆT - ĐỒNG BỘ DỮ LIỆU CŨ (MIGRATE DATA)
        // =================================================================================
        // Bạn hãy gán sự kiện Click của nút "Đồng bộ" vào hàm này
        private void btnDongBo_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Chức năng này sẽ quét các khách hàng cũ chưa được mã hóa và tiến hành mã hóa họ.\nBạn có muốn tiếp tục?", "Xác nhận Đồng bộ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                PerformDataMigration();
            }
        }

        private void PerformDataMigration()
        {
            try
            {
                // 1. Tìm các dòng có CCCD_GOC nhưng chưa có CCCD_ENC (NULL)
                string sqlGetOldData = "SELECT MAKH, CCCD_GOC FROM KHACHHANG WHERE CCCD_ENC IS NULL AND CCCD_GOC IS NOT NULL";
                DataTable dtOld = Database.GetData(sqlGetOldData);

                if (dtOld == null || dtOld.Rows.Count == 0)
                {
                    MessageBox.Show("Dữ liệu đã đồng bộ hoàn toàn. Không cần chạy lại.", "Thông báo");
                    return;
                }

                int countSuccess = 0;

                // 2. Duyệt từng dòng và update lại
                foreach (DataRow row in dtOld.Rows)
                {
                    string maKH = row["MAKH"].ToString();
                    string cccdRaw = row["CCCD_GOC"].ToString();

                    // Mã hóa
                    string encryptedHex = SymmetricHelper.Encrypt(cccdRaw);

                    if (!string.IsNullOrEmpty(encryptedHex))
                    {
                        // Update ngược lại vào DB
                        string sqlUpdate = string.Format("UPDATE KHACHHANG SET CCCD_ENC = HEXTORAW('{0}') WHERE MAKH = '{1}'",
                                                         encryptedHex, maKH);

                        if (Database.ExecuteNonQuery(sqlUpdate))
                        {
                            countSuccess++;
                        }
                    }
                }

                MessageBox.Show($"Đã mã hóa bổ sung thành công cho {countSuccess} khách hàng!", "Kết quả");
                LoadData(); // Load lại để thấy dữ liệu hiển thị đúng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình đồng bộ: " + ex.Message);
            }
        }
    }
}