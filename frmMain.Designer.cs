namespace Nhom5_QuanLyKhachSan
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDichVu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusTenNV = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlSoDoPhong = new System.Windows.Forms.FlowLayoutPanel();
            this.lblChuThich = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNoteDatTruoc = new System.Windows.Forms.Button();
            this.btnNoteDangO = new System.Windows.Forms.Button();
            this.btnNoteTrong = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mnNhatKyHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnHeThong,
            this.mnQuanLy,
            this.mnThongKe});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1330, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnHeThong
            // 
            this.mnHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnDoiMatKhau,
            this.mnDangXuat,
            this.mnThoat});
            this.mnHeThong.Name = "mnHeThong";
            this.mnHeThong.Size = new System.Drawing.Size(103, 29);
            this.mnHeThong.Text = "Hệ thống";
            // 
            // mnDoiMatKhau
            // 
            this.mnDoiMatKhau.Name = "mnDoiMatKhau";
            this.mnDoiMatKhau.Size = new System.Drawing.Size(221, 34);
            this.mnDoiMatKhau.Text = "Đổi mật khẩu";
            // 
            // mnDangXuat
            // 
            this.mnDangXuat.Name = "mnDangXuat";
            this.mnDangXuat.Size = new System.Drawing.Size(221, 34);
            this.mnDangXuat.Text = "Đăng xuất";
            this.mnDangXuat.Click += new System.EventHandler(this.mnDangXuat_Click);
            // 
            // mnThoat
            // 
            this.mnThoat.Name = "mnThoat";
            this.mnThoat.Size = new System.Drawing.Size(221, 34);
            this.mnThoat.Text = "Thoát";
            this.mnThoat.Click += new System.EventHandler(this.mnThoat_Click);
            // 
            // mnQuanLy
            // 
            this.mnQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnNhanVien,
            this.mnKhachHang,
            this.mnDichVu,
            this.mnPhong,
            this.mnNhatKyHeThong});
            this.mnQuanLy.Name = "mnQuanLy";
            this.mnQuanLy.Size = new System.Drawing.Size(89, 29);
            this.mnQuanLy.Text = "Quản lý";
            this.mnQuanLy.Click += new System.EventHandler(this.mnQuanLy_Click);
            // 
            // mnNhanVien
            // 
            this.mnNhanVien.Name = "mnNhanVien";
            this.mnNhanVien.Size = new System.Drawing.Size(270, 34);
            this.mnNhanVien.Text = "Nhân viên";
            this.mnNhanVien.Click += new System.EventHandler(this.mnNhanVien_Click);
            // 
            // mnKhachHang
            // 
            this.mnKhachHang.Name = "mnKhachHang";
            this.mnKhachHang.Size = new System.Drawing.Size(270, 34);
            this.mnKhachHang.Text = "Khách hàng";
            this.mnKhachHang.Click += new System.EventHandler(this.mnKhachHang_Click);
            // 
            // mnDichVu
            // 
            this.mnDichVu.Name = "mnDichVu";
            this.mnDichVu.Size = new System.Drawing.Size(270, 34);
            this.mnDichVu.Text = "Dịch vụ";
            this.mnDichVu.Click += new System.EventHandler(this.mnDichVu_Click);
            // 
            // mnPhong
            // 
            this.mnPhong.Name = "mnPhong";
            this.mnPhong.Size = new System.Drawing.Size(270, 34);
            this.mnPhong.Text = "Phòng";
            this.mnPhong.Click += new System.EventHandler(this.mnPhong_Click);
            // 
            // mnThongKe
            // 
            this.mnThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnDoanhThu,
            this.mnHoaDon});
            this.mnThongKe.Name = "mnThongKe";
            this.mnThongKe.Size = new System.Drawing.Size(102, 29);
            this.mnThongKe.Text = "Thống kê";
            // 
            // mnDoanhThu
            // 
            this.mnDoanhThu.Name = "mnDoanhThu";
            this.mnDoanhThu.Size = new System.Drawing.Size(270, 34);
            this.mnDoanhThu.Text = "Doanh thu";
            this.mnDoanhThu.Click += new System.EventHandler(this.mnDoanhThu_Click);
            // 
            // mnHoaDon
            // 
            this.mnHoaDon.Name = "mnHoaDon";
            this.mnHoaDon.Size = new System.Drawing.Size(270, 34);
            this.mnHoaDon.Text = "Hóa đơn";
            this.mnHoaDon.Click += new System.EventHandler(this.mnHoaDon_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusTenNV});
            this.statusStrip1.Location = new System.Drawing.Point(0, 784);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1330, 32);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusTenNV
            // 
            this.lblStatusTenNV.Name = "lblStatusTenNV";
            this.lblStatusTenNV.Size = new System.Drawing.Size(101, 25);
            this.lblStatusTenNV.Text = "Xin chào: ...";
            // 
            // pnlSoDoPhong
            // 
            this.pnlSoDoPhong.AutoScroll = true;
            this.pnlSoDoPhong.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlSoDoPhong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSoDoPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSoDoPhong.Location = new System.Drawing.Point(0, 114);
            this.pnlSoDoPhong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSoDoPhong.Name = "pnlSoDoPhong";
            this.pnlSoDoPhong.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.pnlSoDoPhong.Size = new System.Drawing.Size(1330, 670);
            this.pnlSoDoPhong.TabIndex = 2;
            this.pnlSoDoPhong.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSoDoPhong_Paint);
            // 
            // lblChuThich
            // 
            this.lblChuThich.AutoSize = true;
            this.lblChuThich.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChuThich.Location = new System.Drawing.Point(65, 20);
            this.lblChuThich.Name = "lblChuThich";
            this.lblChuThich.Size = new System.Drawing.Size(356, 29);
            this.lblChuThich.TabIndex = 0;
            this.lblChuThich.Text = "SƠ ĐỒ TRẠNG THÁI PHÒNG";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNoteDatTruoc);
            this.panel1.Controls.Add(this.btnNoteDangO);
            this.panel1.Controls.Add(this.btnNoteTrong);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblChuThich);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1330, 81);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnNoteDatTruoc
            // 
            this.btnNoteDatTruoc.BackColor = System.Drawing.Color.Khaki;
            this.btnNoteDatTruoc.Enabled = false;
            this.btnNoteDatTruoc.Location = new System.Drawing.Point(994, 25);
            this.btnNoteDatTruoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNoteDatTruoc.Name = "btnNoteDatTruoc";
            this.btnNoteDatTruoc.Size = new System.Drawing.Size(28, 29);
            this.btnNoteDatTruoc.TabIndex = 2;
            this.btnNoteDatTruoc.UseVisualStyleBackColor = false;
            // 
            // btnNoteDangO
            // 
            this.btnNoteDangO.BackColor = System.Drawing.Color.LightSalmon;
            this.btnNoteDangO.Enabled = false;
            this.btnNoteDangO.Location = new System.Drawing.Point(842, 25);
            this.btnNoteDangO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNoteDangO.Name = "btnNoteDangO";
            this.btnNoteDangO.Size = new System.Drawing.Size(28, 29);
            this.btnNoteDangO.TabIndex = 2;
            this.btnNoteDangO.UseVisualStyleBackColor = false;
            // 
            // btnNoteTrong
            // 
            this.btnNoteTrong.BackColor = System.Drawing.Color.PaleGreen;
            this.btnNoteTrong.Enabled = false;
            this.btnNoteTrong.Location = new System.Drawing.Point(702, 25);
            this.btnNoteTrong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNoteTrong.Name = "btnNoteTrong";
            this.btnNoteTrong.Size = new System.Drawing.Size(28, 29);
            this.btnNoteTrong.TabIndex = 2;
            this.btnNoteTrong.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1029, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Đặt trước";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(876, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đang ở";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(737, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Trống";
            // 
            // mnNhatKyHeThong
            // 
            this.mnNhatKyHeThong.Name = "mnNhatKyHeThong";
            this.mnNhatKyHeThong.Size = new System.Drawing.Size(270, 34);
            this.mnNhatKyHeThong.Text = "Nhật ký hệ thống";
            this.mnNhatKyHeThong.Click += new System.EventHandler(this.mnNhatKyHeThong_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 816);
            this.Controls.Add(this.pnlSoDoPhong);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm Quản lý Khách sạn - Nhóm 5";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnQuanLy;
        private System.Windows.Forms.ToolStripMenuItem mnThongKe;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusTenNV;
        private System.Windows.Forms.ToolStripMenuItem mnDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem mnDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnThoat;
        private System.Windows.Forms.ToolStripMenuItem mnNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnDichVu;
        private System.Windows.Forms.ToolStripMenuItem mnPhong;
        private System.Windows.Forms.ToolStripMenuItem mnDoanhThu;
        private System.Windows.Forms.FlowLayoutPanel pnlSoDoPhong;
        private System.Windows.Forms.Label lblChuThich;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNoteDatTruoc;
        private System.Windows.Forms.Button btnNoteDangO;
        private System.Windows.Forms.Button btnNoteTrong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem mnHoaDon;
        private System.Windows.Forms.ToolStripMenuItem mnNhatKyHeThong;
    }
}