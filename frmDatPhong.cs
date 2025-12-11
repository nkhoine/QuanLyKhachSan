using System;
using System.Data;
using System.Windows.Forms;

namespace Nhom5_QuanLyKhachSan
{
    public partial class frmDatPhong : Form
    {
        private string _selectedMaPhong = null;

        public frmDatPhong(string maPhong = null)
        {
            InitializeComponent();
            _selectedMaPhong = maPhong;
        }

        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxKhachHang();
                LoadComboBoxPhong();
                LoadComboBoxTrangThai(); // Load cứng các trạng thái chuẩn theo DB
                LoadData();
                ResetForm();

                if (!string.IsNullOrEmpty(_selectedMaPhong))
                {
                    cboPhong.SelectedValue = _selectedMaPhong;
                    cboTrangThai.SelectedItem = "Dang o"; // Mặc định nếu chọn từ main là muốn vào ở
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo: " + ex.Message);
            }
        }

        #region 1. Load Dữ Liệu

        private void LoadComboBoxTrangThai()
        {
            // Cập nhật Item cho ComboBox giống với dữ liệu trong file Insert SQL
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Da dat");       // Khách đặt trước
            cboTrangThai.Items.Add("Dang o");       // Khách đang check-in
            cboTrangThai.Items.Add("Da thanh toan"); // Đã trả phòng
            cboTrangThai.Items.Add("Da huy");       // Hủy đơn
        }

        private void LoadData()
        {
            // Query khớp với bảng DATPHONG, KHACHHANG, PHONG, NHANVIEN
            string sql = @"SELECT dp.MADP, dp.MAKH, kh.HOTEN AS TENKHACH, 
                                  dp.MAPHONG, p.SOPHONG, 
                                  nv.HOTEN AS TENNV, 
                                  dp.NGAYDAT, dp.NGAYDEN, dp.NGAYDI, dp.TRANGTHAI 
                           FROM DATPHONG dp 
                           JOIN KHACHHANG kh ON dp.MAKH = kh.MAKH 
                           JOIN PHONG p ON dp.MAPHONG = p.MAPHONG 
                           JOIN NHANVIEN nv ON dp.MANV = nv.MANV 
                           ORDER BY dp.NGAYDAT DESC";

            DataTable dt = Database.GetData(sql);
            dgvDatPhong.DataSource = dt;

            // Ẩn cột ID, format cột Ngày
            if (dgvDatPhong.Columns["MAKH"] != null) dgvDatPhong.Columns["MAKH"].Visible = false;
            if (dgvDatPhong.Columns["MAPHONG"] != null) dgvDatPhong.Columns["MAPHONG"].Visible = false;
            if (dgvDatPhong.Columns["NGAYDAT"] != null) dgvDatPhong.Columns["NGAYDAT"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvDatPhong.Columns["NGAYDEN"] != null) dgvDatPhong.Columns["NGAYDEN"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvDatPhong.Columns["NGAYDI"] != null) dgvDatPhong.Columns["NGAYDI"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void LoadComboBoxKhachHang()
        {
            DataTable dt = Database.GetData("SELECT MAKH, HOTEN FROM KHACHHANG ORDER BY HOTEN");
            cboKhachHang.DataSource = dt;
            cboKhachHang.DisplayMember = "HOTEN";
            cboKhachHang.ValueMember = "MAKH";
            cboKhachHang.SelectedIndex = -1;
        }

        private void LoadComboBoxPhong()
        {
            // Hiển thị cả Số phòng và Tình trạng để dễ chọn
            DataTable dt = Database.GetData("SELECT MAPHONG, SOPHONG, TINHTRANG FROM PHONG ORDER BY SOPHONG");

            // (Tuỳ chọn) Bạn có thể tạo cột hiển thị gộp: "101 - Trong"
            // Ở đây giữ nguyên SOPHONG
            cboPhong.DataSource = dt;
            cboPhong.DisplayMember = "SOPHONG";
            cboPhong.ValueMember = "MAPHONG";
            cboPhong.SelectedIndex = -1;
        }

        private void ResetForm()
        {
            txtMaDP.Text = "";
            cboKhachHang.SelectedIndex = -1;
            cboPhong.SelectedIndex = -1;
            dtpNgayDen.Value = DateTime.Now;
            dtpNgayDi.Value = DateTime.Now.AddDays(1);
            cboTrangThai.SelectedIndex = -1;
            txtMaDP.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        #endregion

        #region 2. Các Hàm Xử Lý Logic Nghiệp Vụ

        // Hàm cập nhật trạng thái bảng PHONG dựa trên trạng thái ĐẶT PHÒNG
        private void CapNhatTinhTrangPhong(string maPhong, string trangThaiDatPhong)
        {
            string tinhTrangPhong = "Trong"; // Mặc định là Trống

            // Logic ánh xạ từ Booking Status -> Room Status
            if (trangThaiDatPhong == "Dang o")
                tinhTrangPhong = "Dang o";
            else if (trangThaiDatPhong == "Da dat")
                tinhTrangPhong = "Da dat";
            else if (trangThaiDatPhong == "Da thanh toan" || trangThaiDatPhong == "Da huy")
                tinhTrangPhong = "Trong";

            string sql = string.Format("UPDATE PHONG SET TINHTRANG = '{0}' WHERE MAPHONG = '{1}'", tinhTrangPhong, maPhong);
            Database.ExecuteNonQuery(sql);
        }

        // Kiểm tra phòng có đang trống không (trước khi cho check-in)
        private bool KiemTraPhongTrong(string maPhong)
        {
            string sql = "SELECT TINHTRANG FROM PHONG WHERE MAPHONG = '" + maPhong + "'";
            DataTable dt = Database.GetData(sql);
            if (dt.Rows.Count > 0)
            {
                string tinhTrang = dt.Rows[0]["TINHTRANG"].ToString();
                // Nếu phòng đang "Dang o" hoặc "Da dat" thì không cho đặt thêm (với logic đơn giản)
                if (tinhTrang == "Dang o" || tinhTrang == "Da dat") return false;
            }
            return true;
        }

        #endregion

        #region 3. Sự Kiện Click Grid

        private void dgvDatPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDatPhong.Rows[e.RowIndex];

                txtMaDP.Text = row.Cells["MADP"].Value.ToString();

                // Set values safely
                if (row.Cells["MAKH"].Value != DBNull.Value)
                    cboKhachHang.SelectedValue = row.Cells["MAKH"].Value.ToString();

                if (row.Cells["MAPHONG"].Value != DBNull.Value)
                    cboPhong.SelectedValue = row.Cells["MAPHONG"].Value.ToString();

                if (row.Cells["TRANGTHAI"].Value != DBNull.Value)
                    cboTrangThai.Text = row.Cells["TRANGTHAI"].Value.ToString();

                if (row.Cells["NGAYDEN"].Value != DBNull.Value)
                    dtpNgayDen.Value = Convert.ToDateTime(row.Cells["NGAYDEN"].Value);

                if (row.Cells["NGAYDI"].Value != DBNull.Value)
                    dtpNgayDi.Value = Convert.ToDateTime(row.Cells["NGAYDI"].Value);

                txtMaDP.Enabled = false; // Khóa mã
                btnThem.Enabled = false; // Khóa nút thêm
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        #endregion

        #region 4. Chức Năng Thêm - Xóa - Sửa

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu
            if (txtMaDP.Text == "" || cboKhachHang.SelectedValue == null || cboPhong.SelectedValue == null || cboTrangThai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            string maDP = txtMaDP.Text.Trim();
            string maKH = cboKhachHang.SelectedValue.ToString();
            string maPhong = cboPhong.SelectedValue.ToString();

            // Giả lập mã NV nếu chưa có biến Session (Dựa trên file Insert: NV01, NV02...)
            string maNV = "NV02";
            if (Session.MaNV != null) maNV = Session.MaNV;

            string ngayDen = dtpNgayDen.Value.ToString("yyyy-MM-dd");
            string ngayDi = dtpNgayDi.Value.ToString("yyyy-MM-dd");
            string trangThai = cboTrangThai.Text;

            // Kiểm tra trùng khóa chính
            DataTable checkID = Database.GetData("SELECT * FROM DATPHONG WHERE MADP = '" + maDP + "'");
            if (checkID.Rows.Count > 0)
            {
                MessageBox.Show("Mã đặt phòng đã tồn tại!");
                return;
            }

            // Logic nghiệp vụ: Nếu đặt trạng thái là "Dang o" hoặc "Da dat", phải kiểm tra phòng có trống không
            if ((trangThai == "Dang o" || trangThai == "Da dat") && !KiemTraPhongTrong(maPhong))
            {
                MessageBox.Show("Phòng này hiện không TRỐNG. Vui lòng chọn phòng khác hoặc kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insert vào DB
            string sqlInsert = string.Format(
                "INSERT INTO DATPHONG (MADP, MAKH, MAPHONG, MANV, NGAYDAT, NGAYDEN, NGAYDI, TRANGTHAI) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', SYSDATE, TO_DATE('{4}', 'YYYY-MM-DD'), TO_DATE('{5}', 'YYYY-MM-DD'), '{6}')",
                maDP, maKH, maPhong, maNV, ngayDen, ngayDi, trangThai);

            if (Database.ExecuteNonQuery(sqlInsert))
            {
                // Đồng bộ trạng thái phòng
                CapNhatTinhTrangPhong(maPhong, trangThai);

                MessageBox.Show("Thêm đặt phòng thành công!");
                LoadData();
                ResetForm();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaDP.Text == "") return;

            string maDP = txtMaDP.Text.Trim();
            string maKH = cboKhachHang.SelectedValue.ToString();
            string maPhong = cboPhong.SelectedValue.ToString();
            string ngayDen = dtpNgayDen.Value.ToString("yyyy-MM-dd");
            string ngayDi = dtpNgayDi.Value.ToString("yyyy-MM-dd");
            string trangThaiMoi = cboTrangThai.Text;

            // Update DB
            string sqlUpdate = string.Format(
                "UPDATE DATPHONG SET MAKH='{1}', MAPHONG='{2}', " +
                "NGAYDEN=TO_DATE('{3}','YYYY-MM-DD'), NGAYDI=TO_DATE('{4}','YYYY-MM-DD'), TRANGTHAI='{5}' " +
                "WHERE MADP='{0}'",
                maDP, maKH, maPhong, ngayDen, ngayDi, trangThaiMoi);

            if (Database.ExecuteNonQuery(sqlUpdate))
            {
                // Cập nhật lại trạng thái phòng theo trạng thái đặt phòng mới
                // Ví dụ: Đổi từ "Dang o" sang "Da thanh toan" -> Phòng sẽ thành "Trong"
                CapNhatTinhTrangPhong(maPhong, trangThaiMoi);

                MessageBox.Show("Cập nhật thông tin thành công!");
                LoadData();
                ResetForm();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDP.Text == "") return;

            if (MessageBox.Show("Bạn chắc chắn muốn xóa đơn đặt phòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maDP = txtMaDP.Text;

                // Lấy Mã phòng cũ trước khi xóa để trả trạng thái
                string sqlGetPhong = "SELECT MAPHONG FROM DATPHONG WHERE MADP = '" + maDP + "'";
                DataTable dtP = Database.GetData(sqlGetPhong);
                string maPhongCu = "";
                if (dtP.Rows.Count > 0) maPhongCu = dtP.Rows[0]["MAPHONG"].ToString();

                // Kiểm tra ràng buộc khóa ngoại (Bảng HOADON)
                DataTable dtHD = Database.GetData("SELECT COUNT(*) FROM HOADON WHERE MADP = '" + maDP + "'");
                if (Convert.ToInt32(dtHD.Rows[0][0]) > 0)
                {
                    MessageBox.Show("Không thể xóa đơn này vì đã xuất Hóa Đơn. Hãy xóa Hóa đơn trước!");
                    return;
                }

                // Xóa
                string sqlDelete = "DELETE FROM DATPHONG WHERE MADP = '" + maDP + "'";
                if (Database.ExecuteNonQuery(sqlDelete))
                {
                    // Nếu xóa đơn đặt phòng, phòng đó nên trở về trạng thái "Trong"
                    if (!string.IsNullOrEmpty(maPhongCu))
                    {
                        string sqlResetPhong = "UPDATE PHONG SET TINHTRANG = 'Trong' WHERE MAPHONG = '" + maPhongCu + "'";
                        Database.ExecuteNonQuery(sqlResetPhong);
                    }

                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    ResetForm();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadData();
            // Load lại cả combobox phòng để cập nhật tình trạng mới nhất
            LoadComboBoxPhong();
        }

        #endregion
    }
}