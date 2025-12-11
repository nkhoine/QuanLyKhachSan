using System;
using System.Data;
using System.IO; // Để thao tác với file Key
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client; // Thư viện Oracle

namespace Nhom5_QuanLyKhachSan
{
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();

            // Giả lập đăng nhập nếu chạy Form này độc lập để test
            if (string.IsNullOrEmpty(Session.MaNV))
            {
                Session.MaNV = "NV01"; // Mặc định là NV01 (Quản lý) hoặc user test
            }
            lblMaNV.Text = $"Nhân viên thực hiện: {Session.MaNV}";
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            // Kiểm tra kết nối trước khi tải dữ liệu
            if (Database.Connect())
            {
                LoadMaDP();
                LoadHoaDon();
            }
        }

        // --- CÁC HÀM TẢI DỮ LIỆU ---

        private void LoadMaDP()
        {
            // Lấy danh sách Mã Đặt Phòng từ DB
            string sql = "SELECT MADP FROM DATPHONG ORDER BY MADP";
            DataTable dt = Database.GetData(sql);
            cboMaDP.DataSource = dt;
            cboMaDP.DisplayMember = "MADP";
            cboMaDP.ValueMember = "MADP";
        }

        // --- HÀM LoadHoaDon ĐÃ ĐƯỢC CẬP NHẬT CONTEXT BẢO MẬT ---
        private void LoadHoaDon()
        {
            try
            {
                using (OracleConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    // ==========================================================
                    // BƯỚC QUAN TRỌNG: Thiết lập Context (VPD/RLS) trước khi Select
                    // ==========================================================

                    string maNV = Session.MaNV; // Lấy mã nhân viên đang đăng nhập

                    // Kiểm tra null để tránh lỗi SQL, nếu null thì gán mặc định (ví dụ NV01)
                    if (string.IsNullOrEmpty(maNV)) maNV = "NV01";

                    // Gọi Procedure để set User ID cho Session hiện tại
                    string sqlContext = $"BEGIN PKG_SECURITY.SET_USER_ID('{maNV}'); END;";

                    using (OracleCommand cmdContext = new OracleCommand(sqlContext, conn))
                    {
                        cmdContext.ExecuteNonQuery();
                    }

                    // ==========================================================
                    // SAU ĐÓ MỚI THỰC HIỆN SELECT
                    // ==========================================================

                    // Chỉ lấy các cột hiển thị cơ bản
                    string sql = "SELECT MAHD, MADP, MANV, NGAYLAP, TONGTIEN FROM HOADON ORDER BY MAHD";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        new OracleDataAdapter(cmd).Fill(dt);
                        dgvHoaDon.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hóa đơn: " + ex.Message);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
            txtGhiChuBaoMat.Clear();
            txtMaHD.Clear();
            txtTongTien.Clear();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells["MAHD"].Value.ToString();
                cboMaDP.Text = row.Cells["MADP"].Value.ToString();
                txtTongTien.Text = row.Cells["TONGTIEN"].Value.ToString();

                // Khi chọn dòng mới, xóa nội dung bảo mật cũ để tránh nhầm lẫn
                txtGhiChuBaoMat.Clear();
            }
        }

        // --- CHỨC NĂNG 1: TẠO HÓA ĐƠN ---

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text.Trim();
            string maDP = cboMaDP.Text;
            string tongTienStr = txtTongTien.Text.Trim();

            if (string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(tongTienStr))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.");
                return;
            }

            // Sử dụng Parameter để tránh lỗi định dạng số/ngày và SQL Injection
            using (OracleConnection conn = Database.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO HOADON (MAHD, MADP, MANV, NGAYLAP, TONGTIEN) " +
                                 "VALUES (:maHD, :maDP, :maNV, SYSDATE, :tongTien)";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add("maHD", maHD);
                        cmd.Parameters.Add("maDP", maDP);
                        cmd.Parameters.Add("maNV", Session.MaNV);
                        cmd.Parameters.Add("tongTien", decimal.Parse(tongTienStr));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tạo hóa đơn thành công!");
                        LoadHoaDon();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tạo hóa đơn: " + ex.Message);
                }
            }
        }

        // --- CHỨC NĂNG 2: BẢO MẬT RSA (KÝ SỐ) ---

        private void btnTaoKhoaRSA_Click(object sender, EventArgs e)
        {
            try
            {
                string pubKey, privKey;
                // 1. Sinh khóa bằng RSAHelper
                RSAHelper.GenerateKeys(out pubKey, out privKey);

                // 2. Lưu Private Key vào file cá nhân (Chỉ nhân viên giữ)
                string fileName = $"private_key_{Session.MaNV}.xml";
                File.WriteAllText(fileName, privKey);

                // 3. Lưu Public Key vào Database (Công khai)
                using (OracleConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE NHANVIEN SET PUBLIC_KEY = :pubKey WHERE MANV = :maNV";
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add("pubKey", OracleDbType.Varchar2).Value = pubKey;
                        cmd.Parameters.Add("maNV", Session.MaNV);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                            MessageBox.Show($"Đã tạo và lưu cặp khóa thành công!\nPrivate Key lưu tại: {Path.GetFullPath(fileName)}");
                        else
                            MessageBox.Show("Không tìm thấy nhân viên để cập nhật khóa.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo khóa: " + ex.Message);
            }
        }

        private void btnKyHoaDon_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text;
            if (string.IsNullOrEmpty(maHD)) return;

            // 1. Kiểm tra file Private Key
            string privKeyPath = $"private_key_{Session.MaNV}.xml";
            if (!File.Exists(privKeyPath))
            {
                MessageBox.Show("Bạn chưa có Private Key. Hãy tạo khóa trước.");
                return;
            }

            try
            {
                // 2. Lấy dữ liệu gốc từ DB để ký (Đảm bảo chính xác)
                DataRow row = GetFullInvoiceData(maHD);
                if (row == null) return;

                string dataToSign = BuildDataString(row);
                string privKeyXML = File.ReadAllText(privKeyPath);

                // 3. Ký số (Trả về Base64)
                string signatureBase64 = RSAHelper.SignData(dataToSign, privKeyXML);

                // 4. Chuyển Base64 -> Byte[] để lưu vào cột RAW trong Oracle
                byte[] signatureBytes = Convert.FromBase64String(signatureBase64);

                // 5. Lưu chữ ký vào DB
                using (OracleConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE HOADON SET CHUKY_SO = :sig WHERE MAHD = :maHD";
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add("sig", OracleDbType.Raw).Value = signatureBytes;
                        cmd.Parameters.Add("maHD", maHD);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã ký hóa đơn thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ký số: " + ex.Message);
            }
        }

        private void btnKiemTraToanVen_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text;
            if (string.IsNullOrEmpty(maHD)) return;

            try
            {
                // 1. Lấy dữ liệu hóa đơn + Chữ ký + Mã NV
                DataRow row = GetFullInvoiceData(maHD);
                if (row == null) return;

                if (row["CHUKY_SO"] == DBNull.Value)
                {
                    MessageBox.Show("Hóa đơn này chưa được ký.");
                    return;
                }

                // 2. Lấy Public Key của nhân viên đã lập hóa đơn
                string manvLapHD = row["MANV"].ToString();
                string pubKey = GetPublicKey(manvLapHD);

                if (string.IsNullOrEmpty(pubKey))
                {
                    MessageBox.Show($"Nhân viên {manvLapHD} chưa có Public Key trên hệ thống.");
                    return;
                }

                // 3. Chuẩn bị dữ liệu để verify
                string originalData = BuildDataString(row);

                // Chuyển từ Byte[] (DB) -> Base64 (để dùng RSAHelper)
                byte[] sigBytes = (byte[])row["CHUKY_SO"];
                string sigBase64 = Convert.ToBase64String(sigBytes);

                // 4. Gọi hàm Verify
                bool isValid = RSAHelper.VerifyData(originalData, sigBase64, pubKey);

                if (isValid)
                    MessageBox.Show("HÓA ĐƠN TOÀN VẸN - Chữ ký hợp lệ!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("CẢNH BÁO: Hóa đơn đã bị thay đổi hoặc chữ ký giả mạo!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra: " + ex.Message);
            }
        }

        // --- CHỨC NĂNG 3: MÃ HÓA ĐỐI XỨNG (GHI CHÚ) ---

        private void btnMaHoaGhiChu_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text;
            string noiDung = txtGhiChuBaoMat.Text;

            if (string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(noiDung))
            {
                MessageBox.Show("Cần chọn hóa đơn và nhập ghi chú.");
                return;
            }

            try
            {
                // 1. Mã hóa: Text -> HexString (SymmetricHelper)
                string encryptedHex = SymmetricHelper.Encrypt(noiDung);

                // 2. Chuyển HexString -> Byte[] để lưu vào BLOB
                byte[] blobData = ConvertHexToBytes(encryptedHex);

                // 3. Lưu vào DB
                using (OracleConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE HOADON SET GHI_CHU_BAOMAT = :blobData WHERE MAHD = :maHD";
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add("blobData", OracleDbType.Blob).Value = blobData;
                        cmd.Parameters.Add("maHD", maHD);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã mã hóa và lưu ghi chú bảo mật.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mã hóa ghi chú: " + ex.Message);
            }
        }

        private void btnGiaiMaGhiChu_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text;
            if (string.IsNullOrEmpty(maHD)) return;

            try
            {
                // 1. Lấy dữ liệu BLOB từ DB
                DataRow row = GetFullInvoiceData(maHD);
                if (row == null) return;

                if (row["GHI_CHU_BAOMAT"] == DBNull.Value)
                {
                    MessageBox.Show("Hóa đơn này không có ghi chú bảo mật.");
                    txtGhiChuBaoMat.Clear();
                    return;
                }

                // 2. Chuyển Byte[] -> HexString
                byte[] blobData = (byte[])row["GHI_CHU_BAOMAT"];
                string hexString = BitConverter.ToString(blobData).Replace("-", "");

                // 3. Giải mã: HexString -> Text (SymmetricHelper)
                string plainText = SymmetricHelper.Decrypt(hexString);

                txtGhiChuBaoMat.Text = plainText;
                MessageBox.Show("Đã giải mã ghi chú thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi giải mã: " + ex.Message);
            }
        }

        // --- CÁC HÀM HỖ TRỢ (PRIVATE HELPERS) ---

        // Lấy tất cả thông tin kể cả cột BLOB/RAW
        private DataRow GetFullInvoiceData(string maHD)
        {
            string sql = $"SELECT * FROM HOADON WHERE MAHD = '{maHD}'";
            DataTable dt = Database.GetData(sql);
            if (dt.Rows.Count > 0) return dt.Rows[0];
            return null;
        }

        // Tạo chuỗi dữ liệu chuẩn để ký/kiểm tra (Format: MAHD|MADP|MANV|TONGTIEN)
        private string BuildDataString(DataRow row)
        {
            // Lưu ý: Định dạng ngày tháng và số phải thống nhất giữa lúc ký và lúc kiểm tra
            return $"{row["MAHD"]}|{row["MADP"]}|{row["MANV"]}|{row["TONGTIEN"]}";
        }

        // Lấy Public Key của nhân viên từ DB
        private string GetPublicKey(string maNV)
        {
            using (OracleConnection conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT PUBLIC_KEY FROM NHANVIEN WHERE MANV = :maNV";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("maNV", maNV);
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }

        // Hàm hỗ trợ chuyển Hex String sang Byte Array
        private byte[] ConvertHexToBytes(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private void groupBoxAES_Enter(object sender, EventArgs e)
        {
            // Sự kiện chưa dùng
        }
    }
}