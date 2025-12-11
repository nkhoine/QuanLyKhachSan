namespace Nhom5_QuanLyKhachSan
{
    partial class frmDangKy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtXacNhanMK = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtLuong = new System.Windows.Forms.TextBox();
            this.lblLuongCoBan = new System.Windows.Forms.Label();
            this.lblLoaiTaiKhoan = new System.Windows.Forms.Label();
            this.cboLoaiTaiKhoan = new System.Windows.Forms.ComboBox();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblHoTen
            // 
            this.lblHoTen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Location = new System.Drawing.Point(12, 116);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(166, 30);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ và tên (*):";
            this.lblHoTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHoTen.Click += new System.EventHandler(this.lblHoTen_Click);
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(12, 154);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(166, 42);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Tên đăng nhập (*):";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPass
            // 
            this.lblPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(12, 196);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(166, 42);
            this.lblPass.TabIndex = 0;
            this.lblPass.Text = "Mật khẩu (*):";
            this.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(140, 9);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(402, 42);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "ĐĂNG KÝ TÀI KHOẢN";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(12, 280);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(166, 42);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSDT
            // 
            this.lblSDT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(12, 322);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(166, 42);
            this.lblSDT.TabIndex = 0;
            this.lblSDT.Text = "Số điện thoại (*):";
            this.lblSDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblConfirm
            // 
            this.lblConfirm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirm.Location = new System.Drawing.Point(12, 238);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(166, 42);
            this.lblConfirm.TabIndex = 0;
            this.lblConfirm.Text = "Nhập lại mật khẩu (*):";
            this.lblConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(227, 116);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(328, 27);
            this.txtHoTen.TabIndex = 2;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(227, 163);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(328, 27);
            this.txtTenDangNhap.TabIndex = 3;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(227, 205);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '•';
            this.txtMatKhau.Size = new System.Drawing.Size(328, 27);
            this.txtMatKhau.TabIndex = 4;
            // 
            // txtXacNhanMK
            // 
            this.txtXacNhanMK.Location = new System.Drawing.Point(227, 247);
            this.txtXacNhanMK.Name = "txtXacNhanMK";
            this.txtXacNhanMK.PasswordChar = '•';
            this.txtXacNhanMK.Size = new System.Drawing.Size(328, 27);
            this.txtXacNhanMK.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(227, 289);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(328, 27);
            this.txtEmail.TabIndex = 6;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(227, 331);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(328, 27);
            this.txtSDT.TabIndex = 7;
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.Gold;
            this.btnDangKy.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDangKy.Location = new System.Drawing.Point(96, 483);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(179, 48);
            this.btnDangKy.TabIndex = 11;
            this.btnDangKy.Text = "Đăng Ký";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(363, 483);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(179, 48);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "Quay lại";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtLuong
            // 
            this.txtLuong.Location = new System.Drawing.Point(227, 378);
            this.txtLuong.Name = "txtLuong";
            this.txtLuong.Size = new System.Drawing.Size(328, 27);
            this.txtLuong.TabIndex = 8;
            this.txtLuong.TextChanged += new System.EventHandler(this.txtLuong_TextChanged);
            // 
            // lblLuongCoBan
            // 
            this.lblLuongCoBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuongCoBan.Location = new System.Drawing.Point(12, 369);
            this.lblLuongCoBan.Name = "lblLuongCoBan";
            this.lblLuongCoBan.Size = new System.Drawing.Size(166, 42);
            this.lblLuongCoBan.TabIndex = 3;
            this.lblLuongCoBan.Text = "Lương cơ bản (*):";
            this.lblLuongCoBan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLoaiTaiKhoan
            // 
            this.lblLoaiTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiTaiKhoan.Location = new System.Drawing.Point(12, 69);
            this.lblLoaiTaiKhoan.Name = "lblLoaiTaiKhoan";
            this.lblLoaiTaiKhoan.Size = new System.Drawing.Size(166, 30);
            this.lblLoaiTaiKhoan.TabIndex = 5;
            this.lblLoaiTaiKhoan.Text = "Loại tài khoản (*):";
            this.lblLoaiTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboLoaiTaiKhoan
            // 
            this.cboLoaiTaiKhoan.FormattingEnabled = true;
            this.cboLoaiTaiKhoan.Location = new System.Drawing.Point(227, 69);
            this.cboLoaiTaiKhoan.Name = "cboLoaiTaiKhoan";
            this.cboLoaiTaiKhoan.Size = new System.Drawing.Size(328, 27);
            this.cboLoaiTaiKhoan.TabIndex = 1;
            this.cboLoaiTaiKhoan.SelectedIndexChanged += new System.EventHandler(this.cboLoaiTaiKhoan_SelectedIndexChanged);
            // 
            // lblCCCD
            // 
            this.lblCCCD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCCD.Location = new System.Drawing.Point(12, 369);
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.Size = new System.Drawing.Size(166, 42);
            this.lblCCCD.TabIndex = 7;
            this.lblCCCD.Text = "CCCD/Passport (*):";
            this.lblCCCD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCCCD.Visible = false;
            // 
            // txtCCCD
            // 
            this.txtCCCD.Location = new System.Drawing.Point(227, 378);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(328, 27);
            this.txtCCCD.TabIndex = 8;
            this.txtCCCD.Visible = false;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.Location = new System.Drawing.Point(12, 411);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(166, 42);
            this.lblDiaChi.TabIndex = 8;
            this.lblDiaChi.Text = "Địa chỉ:";
            this.lblDiaChi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDiaChi.Visible = false;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(227, 420);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(328, 27);
            this.txtDiaChi.TabIndex = 9;
            this.txtDiaChi.Visible = false;
            // 
            // lblChucVu
            // 
            this.lblChucVu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChucVu.Location = new System.Drawing.Point(12, 411);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(166, 42);
            this.lblChucVu.TabIndex = 13;
            this.lblChucVu.Text = "Chức vụ (*):";
            this.lblChucVu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblChucVu.Visible = true;
            // 
            // cboChucVu
            // 
            this.cboChucVu.FormattingEnabled = true;
            this.cboChucVu.Location = new System.Drawing.Point(227, 420);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(328, 27);
            this.cboChucVu.TabIndex = 9;
            this.cboChucVu.Visible = true;
            // 
            // frmDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(633, 549);
            this.Controls.Add(this.cboChucVu);
            this.Controls.Add(this.lblChucVu);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.txtCCCD);
            this.Controls.Add(this.lblCCCD);
            this.Controls.Add(this.cboLoaiTaiKhoan);
            this.Controls.Add(this.lblLoaiTaiKhoan);
            this.Controls.Add(this.txtLuong);
            this.Controls.Add(this.lblLuongCoBan);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtXacNhanMK);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblHoTen);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDangKy";
            this.Text = "frmDangKy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtXacNhanMK;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.Label lblLuongCoBan;
        private System.Windows.Forms.Label lblLoaiTaiKhoan;
        private System.Windows.Forms.ComboBox cboLoaiTaiKhoan;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.ComboBox cboChucVu;
    }
}