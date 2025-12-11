namespace Nhom5_QuanLyKhachSan
{
    partial class frmNhatKyHeThong
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.btnTaiLog = new System.Windows.Forms.Button();
            this.cboTable = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(267, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Nhật ký hệ thống (Audit Log)";
            // 
            // dgvLog
            // 
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvLog.Location = new System.Drawing.Point(0, 221);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.RowHeadersWidth = 62;
            this.dgvLog.RowTemplate.Height = 28;
            this.dgvLog.Size = new System.Drawing.Size(1161, 292);
            this.dgvLog.TabIndex = 1;
            // 
            // btnTaiLog
            // 
            this.btnTaiLog.Location = new System.Drawing.Point(12, 72);
            this.btnTaiLog.Name = "btnTaiLog";
            this.btnTaiLog.Size = new System.Drawing.Size(139, 45);
            this.btnTaiLog.TabIndex = 2;
            this.btnTaiLog.Text = "Tải nhật ký";
            this.btnTaiLog.UseVisualStyleBackColor = true;
            this.btnTaiLog.Click += new System.EventHandler(this.btnTaiLog_Click);
            // 
            // cboTable
            // 
            this.cboTable.FormattingEnabled = true;
            this.cboTable.Items.AddRange(new object[] {
            "(Tất cả)",
            "NHANVIEN",
            "HOADON"});
            this.cboTable.Location = new System.Drawing.Point(12, 133);
            this.cboTable.Name = "cboTable";
            this.cboTable.Size = new System.Drawing.Size(215, 28);
            this.cboTable.TabIndex = 3;
            this.cboTable.SelectedIndexChanged += new System.EventHandler(this.cboTable_SelectedIndexChanged);
            // 
            // frmNhatKyHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 513);
            this.Controls.Add(this.cboTable);
            this.Controls.Add(this.btnTaiLog);
            this.Controls.Add(this.dgvLog);
            this.Controls.Add(this.textBox1);
            this.Name = "frmNhatKyHeThong";
            this.Text = "frmNhatKyHeThong";
            this.Load += new System.EventHandler(this.frmNhatKyHeThong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.Button btnTaiLog;
        private System.Windows.Forms.ComboBox cboTable;
    }
}