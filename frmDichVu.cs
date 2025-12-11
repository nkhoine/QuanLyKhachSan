using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Nhom5_QuanLyKhachSan
{
    public partial class frmDichVu : Form
    {
        public frmDichVu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoadDichVu()
        {
            string sql = "SELECT MADV, TENDV, DONGIA FROM DICHVU ORDER BY MADV";
            DataTable dt = Database.GetData(sql); // Giả định Database.GetData là một phương thức truy vấn dữ liệu
            dgvDichVu.DataSource = dt;
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            LoadDichVu();
        }

        private void dgvDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDichVu.CurrentRow != null)
            {
                txtMaDV.Text = dgvDichVu.CurrentRow.Cells["MADV"].Value.ToString();
                txtTenDV.Text = dgvDichVu.CurrentRow.Cells["TENDV"].Value.ToString();
                txtDonGia.Text = dgvDichVu.CurrentRow.Cells["DONGIA"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string madv = txtMaDV.Text.Trim();
            string tendv = txtTenDV.Text.Trim();
            string dongiaStr = txtDonGia.Text.Trim();

            if (string.IsNullOrEmpty(madv) || string.IsNullOrEmpty(tendv) || string.IsNullOrEmpty(dongiaStr))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (!decimal.TryParse(dongiaStr, out decimal dongia))
            {
                MessageBox.Show("Đơn giá không hợp lệ.");
                return;
            }

            using (OracleConnection conn = Database.GetConnection()) // Giả định Database.GetConnection cung cấp kết nối Oracle
            {
                conn.Open();
                string sql = "INSERT INTO DICHVU(MADV, TENDV, DONGIA) VALUES(:madv, :tendv, :dongia)";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":madv", OracleDbType.Varchar2).Value = madv;
                    cmd.Parameters.Add(":tendv", OracleDbType.NVarchar2).Value = tendv;
                    cmd.Parameters.Add(":dongia", OracleDbType.Decimal).Value = dongia;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm dịch vụ thành công.");
                        LoadDichVu();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi thêm dịch vụ: " + ex.Message);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string madv = txtMaDV.Text.Trim();
            string tendv = txtTenDV.Text.Trim();
            string dongiaStr = txtDonGia.Text.Trim();

            if (string.IsNullOrEmpty(madv))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần sửa.");
                return;
            }

            if (!decimal.TryParse(dongiaStr, out decimal dongia))
            {
                MessageBox.Show("Đơn giá không hợp lệ.");
                return;
            }

            using (OracleConnection conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE DICHVU SET TENDV = :tendv, DONGIA = :dongia WHERE MADV = :madv";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":tendv", OracleDbType.NVarchar2).Value = tendv;
                    cmd.Parameters.Add(":dongia", OracleDbType.Decimal).Value = dongia;
                    cmd.Parameters.Add(":madv", OracleDbType.Varchar2).Value = madv;

                    try
                    {
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Cập nhật dịch vụ thành công.");
                            LoadDichVu();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dịch vụ để cập nhật.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi cập nhật dịch vụ: " + ex.Message);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string madv = txtMaDV.Text.Trim();
            if (string.IsNullOrEmpty(madv))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa dịch vụ này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            using (OracleConnection conn = Database.GetConnection())
            {
                conn.Open();

                // Xóa chi tiết trước (ràng buộc FK)
                string sql = "DELETE FROM CHITIET_DICHVU WHERE MADV = :madv";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":madv", OracleDbType.Varchar2).Value = madv;
                    cmd.ExecuteNonQuery();
                }

                // Xóa dịch vụ
                sql = "DELETE FROM DICHVU WHERE MADV = :madv2";
                using (OracleCommand cmd2 = new OracleCommand(sql, conn))
                {
                    cmd2.Parameters.Add(":madv2", OracleDbType.Varchar2).Value = madv;
                    try
                    {
                        int rows = cmd2.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Xóa dịch vụ thành công.");
                            LoadDichVu();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dịch vụ để xóa.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa dịch vụ: " + ex.Message);
                    }
                }
            }
        }


        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDichVu();
        }
    }
}