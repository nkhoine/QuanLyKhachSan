namespace Nhom5_QuanLyKhachSan
{
    partial class frmLogin
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
            this.lblLOGIN = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblSid = new System.Windows.Forms.Label();
            this.txtSid = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassWork = new System.Windows.Forms.Label();
            this.txtPassWork = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLOGIN
            // 
            this.lblLOGIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblLOGIN.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLOGIN.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLOGIN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblLOGIN.Location = new System.Drawing.Point(0, 0);
            this.lblLOGIN.Name = "lblLOGIN";
            this.lblLOGIN.Size = new System.Drawing.Size(567, 43);
            this.lblLOGIN.TabIndex = 6;
            this.lblLOGIN.Text = "LOGIN";
            this.lblLOGIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHost
            // 
            this.lblHost.Location = new System.Drawing.Point(78, 63);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(96, 26);
            this.lblHost.TabIndex = 7;
            this.lblHost.Text = "Host:";
            this.lblHost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(197, 64);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(274, 30);
            this.txtHost.TabIndex = 0;
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(78, 95);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(96, 26);
            this.lblPort.TabIndex = 8;
            this.lblPort.Text = "Port:";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(197, 96);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(274, 30);
            this.txtPort.TabIndex = 1;
            // 
            // lblSid
            // 
            this.lblSid.Location = new System.Drawing.Point(78, 127);
            this.lblSid.Name = "lblSid";
            this.lblSid.Size = new System.Drawing.Size(96, 26);
            this.lblSid.TabIndex = 9;
            this.lblSid.Text = "Sid:";
            this.lblSid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSid
            // 
            this.txtSid.Location = new System.Drawing.Point(197, 128);
            this.txtSid.Name = "txtSid";
            this.txtSid.Size = new System.Drawing.Size(274, 30);
            this.txtSid.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(78, 159);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(96, 26);
            this.lblUser.TabIndex = 10;
            this.lblUser.Text = "User:";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(197, 160);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(274, 30);
            this.txtUser.TabIndex = 3;
            // 
            // lblPassWork
            // 
            this.lblPassWork.Location = new System.Drawing.Point(78, 191);
            this.lblPassWork.Name = "lblPassWork";
            this.lblPassWork.Size = new System.Drawing.Size(96, 26);
            this.lblPassWork.TabIndex = 11;
            this.lblPassWork.Text = "Password:";
            this.lblPassWork.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassWork
            // 
            this.txtPassWork.Location = new System.Drawing.Point(197, 192);
            this.txtPassWork.Name = "txtPassWork";
            this.txtPassWork.Size = new System.Drawing.Size(274, 30);
            this.txtPassWork.TabIndex = 4;
            this.txtPassWork.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLogin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogin.Location = new System.Drawing.Point(197, 245);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(144, 41);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "&Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 298);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtPassWork);
            this.Controls.Add(this.lblPassWork);
            this.Controls.Add(this.txtSid);
            this.Controls.Add(this.lblSid);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.lblLOGIN);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLogin";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLOGIN;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblSid;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassWork;
        private System.Windows.Forms.Button btnLogin;
        public System.Windows.Forms.TextBox txtHost;
        public System.Windows.Forms.TextBox txtPort;
        public System.Windows.Forms.TextBox txtSid;
        public System.Windows.Forms.TextBox txtUser;
        public System.Windows.Forms.TextBox txtPassWork;
    }
}