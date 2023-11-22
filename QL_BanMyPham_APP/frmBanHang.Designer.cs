namespace QL_BanMyPham_APP
{
    partial class frmBanHang
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
            this.btnThemHD = new System.Windows.Forms.Button();
            this.cboMaKH = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNgayDat = new System.Windows.Forms.DateTimePicker();
            this.btnTaoHD = new System.Windows.Forms.Button();
            this.txtSĐTKH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiaChiKH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvDH = new System.Windows.Forms.DataGridView();
            this.btnHuyHD = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDH)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThemHD
            // 
            this.btnThemHD.Enabled = false;
            this.btnThemHD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThemHD.Location = new System.Drawing.Point(994, 126);
            this.btnThemHD.Name = "btnThemHD";
            this.btnThemHD.Size = new System.Drawing.Size(290, 49);
            this.btnThemHD.TabIndex = 23;
            this.btnThemHD.Text = "THÊM HÓA ĐƠN";
            this.btnThemHD.UseVisualStyleBackColor = true;
            this.btnThemHD.Click += new System.EventHandler(this.btnThemHD_Click);
            // 
            // cboMaKH
            // 
            this.cboMaKH.FormattingEnabled = true;
            this.cboMaKH.Location = new System.Drawing.Point(629, 34);
            this.cboMaKH.Name = "cboMaKH";
            this.cboMaKH.Size = new System.Drawing.Size(263, 21);
            this.cboMaKH.TabIndex = 12;
            this.cboMaKH.TextChanged += new System.EventHandler(this.cboMaKH_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNgayDat);
            this.groupBox1.Controls.Add(this.btnTaoHD);
            this.groupBox1.Controls.Add(this.btnThemHD);
            this.groupBox1.Controls.Add(this.txtSĐTKH);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboMaKH);
            this.groupBox1.Controls.Add(this.txtDiaChiKH);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTenKH);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaHD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1362, 236);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông rin chung(Hóa đơn bán)";
            // 
            // txtNgayDat
            // 
            this.txtNgayDat.Enabled = false;
            this.txtNgayDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayDat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtNgayDat.Location = new System.Drawing.Point(151, 93);
            this.txtNgayDat.Margin = new System.Windows.Forms.Padding(2);
            this.txtNgayDat.Name = "txtNgayDat";
            this.txtNgayDat.Size = new System.Drawing.Size(263, 27);
            this.txtNgayDat.TabIndex = 40;
            // 
            // btnTaoHD
            // 
            this.btnTaoHD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTaoHD.Location = new System.Drawing.Point(994, 34);
            this.btnTaoHD.Name = "btnTaoHD";
            this.btnTaoHD.Size = new System.Drawing.Size(290, 49);
            this.btnTaoHD.TabIndex = 26;
            this.btnTaoHD.Text = "TẠO HÓA ĐƠN";
            this.btnTaoHD.UseVisualStyleBackColor = true;
            this.btnTaoHD.Click += new System.EventHandler(this.btnTaoHD_Click);
            // 
            // txtSĐTKH
            // 
            this.txtSĐTKH.Enabled = false;
            this.txtSĐTKH.Location = new System.Drawing.Point(629, 198);
            this.txtSĐTKH.Name = "txtSĐTKH";
            this.txtSĐTKH.Size = new System.Drawing.Size(263, 20);
            this.txtSĐTKH.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(567, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "SĐT:";
            // 
            // txtDiaChiKH
            // 
            this.txtDiaChiKH.Enabled = false;
            this.txtDiaChiKH.Location = new System.Drawing.Point(629, 145);
            this.txtDiaChiKH.Name = "txtDiaChiKH";
            this.txtDiaChiKH.Size = new System.Drawing.Size(263, 20);
            this.txtDiaChiKH.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(567, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Địa chỉ:";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Enabled = false;
            this.txtTenKH.Location = new System.Drawing.Point(629, 91);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(263, 20);
            this.txtTenKH.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(567, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tên KH:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(567, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mã KH:";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(151, 144);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(263, 20);
            this.textBox3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên NV:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày bán:";
            // 
            // txtMaHD
            // 
            this.txtMaHD.BackColor = System.Drawing.Color.Cyan;
            this.txtMaHD.Enabled = false;
            this.txtMaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHD.ForeColor = System.Drawing.Color.Black;
            this.txtMaHD.Location = new System.Drawing.Point(151, 34);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(263, 29);
            this.txtMaHD.TabIndex = 1;
            this.txtMaHD.TextChanged += new System.EventHandler(this.txtMaHD_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã HĐ:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(1092, 712);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(263, 29);
            this.txtTongTien.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Yellow;
            this.label8.Location = new System.Drawing.Point(1031, 723);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Tổng tiền:";
            // 
            // dgvDH
            // 
            this.dgvDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDH.Location = new System.Drawing.Point(13, 276);
            this.dgvDH.Name = "dgvDH";
            this.dgvDH.Size = new System.Drawing.Size(1342, 408);
            this.dgvDH.TabIndex = 43;
            this.dgvDH.Click += new System.EventHandler(this.dgvDH_Click);
            // 
            // btnHuyHD
            // 
            this.btnHuyHD.Enabled = false;
            this.btnHuyHD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnHuyHD.Location = new System.Drawing.Point(583, 712);
            this.btnHuyHD.Name = "btnHuyHD";
            this.btnHuyHD.Size = new System.Drawing.Size(187, 49);
            this.btnHuyHD.TabIndex = 25;
            this.btnHuyHD.Text = "HỦY HÓA ĐƠN";
            this.btnHuyHD.UseVisualStyleBackColor = true;
            // 
            // frmBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1367, 773);
            this.Controls.Add(this.dgvDH);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnHuyHD);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBanHang";
            this.Text = "frmBanHang";
            this.Load += new System.EventHandler(this.frmBanHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnThemHD;
        private System.Windows.Forms.ComboBox cboMaKH;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSĐTKH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiaChiKH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTaoHD;
        private System.Windows.Forms.DateTimePicker txtNgayDat;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvDH;
        private System.Windows.Forms.Button btnHuyHD;
    }
}