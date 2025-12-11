namespace Nhom5_QuanLyKhachSan
{
    partial class frmHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMaDP = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnTaoHoaDon = new System.Windows.Forms.Button();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.groupBoxRSA = new System.Windows.Forms.GroupBox();
            this.btnKiemTraToanVen = new System.Windows.Forms.Button();
            this.btnKyHoaDon = new System.Windows.Forms.Button();
            this.btnTaoKhoaRSA = new System.Windows.Forms.Button();
            this.groupBoxAES = new System.Windows.Forms.GroupBox();
            this.btnGiaiMaGhiChu = new System.Windows.Forms.Button();
            this.btnMaHoaGhiChu = new System.Windows.Forms.Button();
            this.txtGhiChuBaoMat = new System.Windows.Forms.TextBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.groupBoxRSA.SuspendLayout();
            this.groupBoxAES.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(12, 230);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.Size = new System.Drawing.Size(950, 300);
            this.dgvHoaDon.TabIndex = 0;
            this.dgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã HĐ:";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(90, 22);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(150, 26);
            this.txtMaHD.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã ĐP:";
            // 
            // cboMaDP
            // 
            this.cboMaDP.FormattingEnabled = true;
            this.cboMaDP.Location = new System.Drawing.Point(90, 62);
            this.cboMaDP.Name = "cboMaDP";
            this.cboMaDP.Size = new System.Drawing.Size(150, 28);
            this.cboMaDP.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tổng Tiền:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(90, 102);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(150, 26);
            this.txtTongTien.TabIndex = 6;
            // 
            // btnTaoHoaDon
            // 
            this.btnTaoHoaDon.Location = new System.Drawing.Point(15, 145);
            this.btnTaoHoaDon.Name = "btnTaoHoaDon";
            this.btnTaoHoaDon.Size = new System.Drawing.Size(110, 35);
            this.btnTaoHoaDon.TabIndex = 7;
            this.btnTaoHoaDon.Text = "Tạo Hóa Đơn";
            this.btnTaoHoaDon.UseVisualStyleBackColor = true;
            this.btnTaoHoaDon.Click += new System.EventHandler(this.btnTaoHoaDon_Click);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Location = new System.Drawing.Point(131, 145);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(110, 35);
            this.btnTaiLai.TabIndex = 8;
            this.btnTaiLai.Text = "Tải Lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // groupBoxRSA
            // 
            this.groupBoxRSA.Controls.Add(this.btnKiemTraToanVen);
            this.groupBoxRSA.Controls.Add(this.btnKyHoaDon);
            this.groupBoxRSA.Controls.Add(this.btnTaoKhoaRSA);
            this.groupBoxRSA.Location = new System.Drawing.Point(260, 12);
            this.groupBoxRSA.Name = "groupBoxRSA";
            this.groupBoxRSA.Size = new System.Drawing.Size(200, 170);
            this.groupBoxRSA.TabIndex = 9;
            this.groupBoxRSA.TabStop = false;
            this.groupBoxRSA.Text = "Chữ ký số (RSA)";
            // 
            // btnKiemTraToanVen
            // 
            this.btnKiemTraToanVen.BackColor = System.Drawing.Color.LightGreen;
            this.btnKiemTraToanVen.Location = new System.Drawing.Point(20, 120);
            this.btnKiemTraToanVen.Name = "btnKiemTraToanVen";
            this.btnKiemTraToanVen.Size = new System.Drawing.Size(160, 35);
            this.btnKiemTraToanVen.TabIndex = 2;
            this.btnKiemTraToanVen.Text = "3. Kiểm Tra Toàn Vẹn";
            this.btnKiemTraToanVen.UseVisualStyleBackColor = false;
            this.btnKiemTraToanVen.Click += new System.EventHandler(this.btnKiemTraToanVen_Click);
            // 
            // btnKyHoaDon
            // 
            this.btnKyHoaDon.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnKyHoaDon.Location = new System.Drawing.Point(20, 75);
            this.btnKyHoaDon.Name = "btnKyHoaDon";
            this.btnKyHoaDon.Size = new System.Drawing.Size(160, 35);
            this.btnKyHoaDon.TabIndex = 1;
            this.btnKyHoaDon.Text = "2. Ký Hóa Đơn";
            this.btnKyHoaDon.UseVisualStyleBackColor = false;
            this.btnKyHoaDon.Click += new System.EventHandler(this.btnKyHoaDon_Click);
            // 
            // btnTaoKhoaRSA
            // 
            this.btnTaoKhoaRSA.BackColor = System.Drawing.Color.LightCoral;
            this.btnTaoKhoaRSA.Location = new System.Drawing.Point(20, 30);
            this.btnTaoKhoaRSA.Name = "btnTaoKhoaRSA";
            this.btnTaoKhoaRSA.Size = new System.Drawing.Size(160, 35);
            this.btnTaoKhoaRSA.TabIndex = 0;
            this.btnTaoKhoaRSA.Text = "1. Tạo Khoa RSA";
            this.btnTaoKhoaRSA.UseVisualStyleBackColor = false;
            this.btnTaoKhoaRSA.Click += new System.EventHandler(this.btnTaoKhoaRSA_Click);
            // 
            // groupBoxAES
            // 
            this.groupBoxAES.Controls.Add(this.btnGiaiMaGhiChu);
            this.groupBoxAES.Controls.Add(this.btnMaHoaGhiChu);
            this.groupBoxAES.Controls.Add(this.txtGhiChuBaoMat);
            this.groupBoxAES.Location = new System.Drawing.Point(480, 12);
            this.groupBoxAES.Name = "groupBoxAES";
            this.groupBoxAES.Size = new System.Drawing.Size(480, 170);
            this.groupBoxAES.TabIndex = 10;
            this.groupBoxAES.TabStop = false;
            this.groupBoxAES.Text = "Ghi chú bảo mật (AES)";
            this.groupBoxAES.Enter += new System.EventHandler(this.groupBoxAES_Enter);
            // 
            // btnGiaiMaGhiChu
            // 
            this.btnGiaiMaGhiChu.Location = new System.Drawing.Point(340, 120);
            this.btnGiaiMaGhiChu.Name = "btnGiaiMaGhiChu";
            this.btnGiaiMaGhiChu.Size = new System.Drawing.Size(120, 35);
            this.btnGiaiMaGhiChu.TabIndex = 2;
            this.btnGiaiMaGhiChu.Text = "Giải mã";
            this.btnGiaiMaGhiChu.UseVisualStyleBackColor = true;
            this.btnGiaiMaGhiChu.Click += new System.EventHandler(this.btnGiaiMaGhiChu_Click);
            // 
            // btnMaHoaGhiChu
            // 
            this.btnMaHoaGhiChu.Location = new System.Drawing.Point(340, 75);
            this.btnMaHoaGhiChu.Name = "btnMaHoaGhiChu";
            this.btnMaHoaGhiChu.Size = new System.Drawing.Size(120, 35);
            this.btnMaHoaGhiChu.TabIndex = 1;
            this.btnMaHoaGhiChu.Text = "Mã hóa && Lưu";
            this.btnMaHoaGhiChu.UseVisualStyleBackColor = true;
            this.btnMaHoaGhiChu.Click += new System.EventHandler(this.btnMaHoaGhiChu_Click);
            // 
            // txtGhiChuBaoMat
            // 
            this.txtGhiChuBaoMat.Location = new System.Drawing.Point(20, 30);
            this.txtGhiChuBaoMat.Multiline = true;
            this.txtGhiChuBaoMat.Name = "txtGhiChuBaoMat";
            this.txtGhiChuBaoMat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGhiChuBaoMat.Size = new System.Drawing.Size(300, 125);
            this.txtGhiChuBaoMat.TabIndex = 0;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.Location = new System.Drawing.Point(12, 195);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(106, 22);
            this.lblMaNV.TabIndex = 11;
            this.lblMaNV.Text = "Nhân viên:";
            // 
            // frmHoaDon
            // 
            this.ClientSize = new System.Drawing.Size(984, 541);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.groupBoxAES);
            this.Controls.Add(this.groupBoxRSA);
            this.Controls.Add(this.btnTaiLai);
            this.Controls.Add(this.btnTaoHoaDon);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboMaDP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaHD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHoaDon);
            this.Name = "frmHoaDon";
            this.Text = "Quản lý Hóa Đơn (Bảo mật)";
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.groupBoxRSA.ResumeLayout(false);
            this.groupBoxAES.ResumeLayout(false);
            this.groupBoxAES.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMaDP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Button btnTaoHoaDon;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.GroupBox groupBoxRSA;
        private System.Windows.Forms.Button btnKiemTraToanVen;
        private System.Windows.Forms.Button btnKyHoaDon;
        private System.Windows.Forms.Button btnTaoKhoaRSA;
        private System.Windows.Forms.GroupBox groupBoxAES;
        private System.Windows.Forms.Button btnGiaiMaGhiChu;
        private System.Windows.Forms.Button btnMaHoaGhiChu;
        private System.Windows.Forms.TextBox txtGhiChuBaoMat;
        private System.Windows.Forms.Label lblMaNV;
    }
}