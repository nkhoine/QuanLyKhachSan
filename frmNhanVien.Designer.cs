namespace Nhom5_QuanLyKhachSan
{
    partial class frmNhanVien
    {
        private System.ComponentModel.IContainer components = null;

        // KHAI BÁO CÁC CONTROLS
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;

        // MỚI THÊM: Các Label và nút Làm mới
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.Label lblLuong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.txtLuong = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.lblLuong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Location = new System.Drawing.Point(12, 180);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.RowTemplate.Height = 24;
            this.dgvNhanVien.Size = new System.Drawing.Size(776, 258);
            this.dgvNhanVien.TabIndex = 0;
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);

            // --- CÁC LABEL (MỚI) ---
            // lblMaNV
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(30, 33);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(50, 17);
            this.lblMaNV.Text = "Mã NV:";

            // lblHoTen
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(30, 63);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(59, 17);
            this.lblHoTen.Text = "Họ Tên:";

            // lblChucVu
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Location = new System.Drawing.Point(310, 33);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(65, 17);
            this.lblChucVu.Text = "Chức Vụ:";

            // lblLuong
            this.lblLuong.AutoSize = true;
            this.lblLuong.Location = new System.Drawing.Point(310, 63);
            this.lblLuong.Name = "lblLuong";
            this.lblLuong.Size = new System.Drawing.Size(52, 17);
            this.lblLuong.Text = "Lương:";

            // --- CÁC TEXTBOX (GIỮ NGUYÊN VỊ TRÍ) ---
            // txtMaNV
            this.txtMaNV.Location = new System.Drawing.Point(120, 30);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(150, 22);
            this.txtMaNV.TabIndex = 1;

            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(120, 60);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(150, 22); // Đã chỉnh nhỏ lại chút cho cân đối
            this.txtHoTen.TabIndex = 2;

            // txtChucVu
            // 
            this.txtChucVu.Location = new System.Drawing.Point(400, 30);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(150, 22);
            this.txtChucVu.TabIndex = 3;

            // txtLuong
            // 
            this.txtLuong.Location = new System.Drawing.Point(400, 60);
            this.txtLuong.Name = "txtLuong";
            this.txtLuong.Size = new System.Drawing.Size(150, 22);
            this.txtLuong.TabIndex = 4;

            // --- CÁC BUTTON ---
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(120, 120);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 35);
            this.btnThem.Text = "Thêm";
            this.btnThem.TabIndex = 5;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(220, 120);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 35);
            this.btnSua.Text = "Sửa";
            this.btnSua.TabIndex = 6;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(320, 120);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 35);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // btnLamMoi (MỚI)
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(420, 120); // Nằm bên phải nút Xóa
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 35);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TabIndex = 8;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);

            // Thêm các Control mới vào Form
            this.Controls.Add(this.lblLuong);
            this.Controls.Add(this.lblChucVu);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.btnLamMoi);

            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtLuong);
            this.Controls.Add(this.txtChucVu);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.dgvNhanVien);
            this.Text = "Quản Lý Nhân Viên";
            this.Load += new System.EventHandler(this.frmNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}