using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5_QuanLyKhachSan
{
    public partial class frmNhatKyHeThong : Form
    {
        public frmNhatKyHeThong()
        {
            InitializeComponent();
        }

        private void frmNhatKyHeThong_Load(object sender, EventArgs e)
        {


            cboTable.Items.Clear();
            cboTable.Items.Add("(Tất cả)");
            cboTable.Items.Add("NHANVIEN");
            cboTable.Items.Add("HOADON");

            cboTable.SelectedIndex = 0;  // chọn mặc định "(Tất cả)"

            LoadLog();  // hàm load dữ liệu mình viết lúc nãy

        }

        private void cboTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTaiLog_Click(object sender, EventArgs e)
        {
            LoadLog();
        }
        private void LoadLog()
        {
            try
            {
                string tableFilter = (cboTable.SelectedItem ?? "(Tất cả)").ToString();

                // SỬA ĐỔI: Sử dụng LEFT JOIN để lấy HOTEN từ bảng NHANVIEN
                // L là viết tắt (alias) của LOG_AUDIT, N là viết tắt của NHANVIEN
                string sql = "SELECT L.ID_LOG, L.MANV, N.HOTEN, L.ACTION_TIME, L.ACTION_TYPE, L.TABLE_NAME, L.OLD_DATA, L.NEW_DATA " +
                             "FROM LOG_AUDIT L " +
                             "LEFT JOIN NHANVIEN N ON L.MANV = N.MANV";

                // Xử lý bộ lọc
                if (tableFilter != "(Tất cả)")
                {
                    // Lưu ý: Thêm 'L.' trước TABLE_NAME để chỉ rõ lấy từ bảng LOG_AUDIT
                    sql += " WHERE L.TABLE_NAME = '" + tableFilter + "'";
                }

                // Sắp xếp giảm dần theo thời gian
                sql += " ORDER BY L.ACTION_TIME DESC";

                DataTable dt = Database.GetData(sql);
                dgvLog.DataSource = dt;

                // --- Đặt tên tiêu đề cột (Header) ---
                if (dgvLog.Columns.Contains("ID_LOG"))
                    dgvLog.Columns["ID_LOG"].HeaderText = "Mã log";

                if (dgvLog.Columns.Contains("MANV"))
                    dgvLog.Columns["MANV"].HeaderText = "Mã NV";

                if (dgvLog.Columns.Contains("HOTEN"))
                    dgvLog.Columns["HOTEN"].HeaderText = "Họ tên NV";

                if (dgvLog.Columns.Contains("ACTION_TIME"))
                {
                    dgvLog.Columns["ACTION_TIME"].HeaderText = "Thời gian";
                    // Định dạng lại hiển thị ngày giờ cho dễ nhìn
                    dgvLog.Columns["ACTION_TIME"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                }

                if (dgvLog.Columns.Contains("ACTION_TYPE"))
                    dgvLog.Columns["ACTION_TYPE"].HeaderText = "Hành động";

                if (dgvLog.Columns.Contains("TABLE_NAME"))
                    dgvLog.Columns["TABLE_NAME"].HeaderText = "Bảng";

                if (dgvLog.Columns.Contains("OLD_DATA"))
                    dgvLog.Columns["OLD_DATA"].HeaderText = "Dữ liệu cũ";

                if (dgvLog.Columns.Contains("NEW_DATA"))
                    dgvLog.Columns["NEW_DATA"].HeaderText = "Dữ liệu mới";

                dgvLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải nhật ký: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

