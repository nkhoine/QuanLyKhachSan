namespace Nhom5_QuanLyKhachSan
{
    partial class frmKhachHang
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label lblMaKH, lblHoTen, lblSDT, lblDiaChi, lblCCCD;
        private System.Windows.Forms.Button btnThem, btnSua, btnXoa, btnLamMoi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.SuspendLayout();

            // Setup Labels & TextBoxes locations (Simplified layout)
            this.lblMaKH.Text = "Mã KH:"; this.lblMaKH.Location = new System.Drawing.Point(20, 20);
            this.txtMaKH.Location = new System.Drawing.Point(100, 20);

            this.lblHoTen.Text = "Họ Tên:"; this.lblHoTen.Location = new System.Drawing.Point(20, 50);
            this.txtHoTen.Location = new System.Drawing.Point(100, 50); this.txtHoTen.Size = new System.Drawing.Size(200, 20);

            this.lblSDT.Text = "SĐT:"; this.lblSDT.Location = new System.Drawing.Point(350, 20);
            this.txtSDT.Location = new System.Drawing.Point(420, 20);

            this.lblDiaChi.Text = "Địa Chỉ:"; this.lblDiaChi.Location = new System.Drawing.Point(350, 50);
            this.txtDiaChi.Location = new System.Drawing.Point(420, 50); this.txtDiaChi.Size = new System.Drawing.Size(200, 20);

            this.lblCCCD.Text = "CCCD:"; this.lblCCCD.Location = new System.Drawing.Point(20, 80);
            this.txtCCCD.Location = new System.Drawing.Point(100, 80); this.txtCCCD.Size = new System.Drawing.Size(200, 20);

            // Buttons
            this.btnThem.Text = "Thêm"; this.btnThem.Location = new System.Drawing.Point(100, 120);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Text = "Sửa"; this.btnSua.Location = new System.Drawing.Point(200, 120);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Text = "Xóa"; this.btnXoa.Location = new System.Drawing.Point(300, 120);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Text = "Làm Mới"; this.btnLamMoi.Location = new System.Drawing.Point(400, 120);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // DataGridView
            this.dgvKhachHang.Location = new System.Drawing.Point(20, 170);
            this.dgvKhachHang.Size = new System.Drawing.Size(750, 250);
            this.dgvKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellClick);

            // Form
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvKhachHang);
            this.Controls.Add(this.btnLamMoi); this.Controls.Add(this.btnXoa); this.Controls.Add(this.btnSua); this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtCCCD); this.Controls.Add(this.lblCCCD);
            this.Controls.Add(this.txtDiaChi); this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.txtSDT); this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.txtHoTen); this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtMaKH); this.Controls.Add(this.lblMaKH);
            this.Text = "Quản Lý Khách Hàng (Bảo mật CCCD)";
            this.Load += new System.EventHandler(this.frmKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}