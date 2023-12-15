namespace QL_BanMyPham_APP
{
    partial class frmKhuyenMai
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
            this.cboKhuyenMai = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.numKM = new System.Windows.Forms.NumericUpDown();
            this.dgvKM = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.chbTenSP = new System.Windows.Forms.CheckBox();
            this.chbGiaBan = new System.Windows.Forms.CheckBox();
            this.chbChuaKM = new System.Windows.Forms.CheckBox();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKM)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // cboKhuyenMai
            // 
            this.cboKhuyenMai.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhuyenMai.FormattingEnabled = true;
            this.cboKhuyenMai.Location = new System.Drawing.Point(133, 168);
            this.cboKhuyenMai.Margin = new System.Windows.Forms.Padding(2);
            this.cboKhuyenMai.Name = "cboKhuyenMai";
            this.cboKhuyenMai.Size = new System.Drawing.Size(119, 33);
            this.cboKhuyenMai.TabIndex = 22;
            this.cboKhuyenMai.SelectedIndexChanged += new System.EventHandler(this.cboKhuyenMai_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(132, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Giá trị khuyến mãi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(2, 171);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Khuyến mãi";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btSua);
            this.panel1.Controls.Add(this.numKM);
            this.panel1.Controls.Add(this.dgvKM);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboKhuyenMai);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(748, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 710);
            this.panel1.TabIndex = 27;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(271, 160);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(149, 37);
            this.btnThem.TabIndex = 23;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btSua
            // 
            this.btSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.Location = new System.Drawing.Point(439, 160);
            this.btSua.Margin = new System.Windows.Forms.Padding(2);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(149, 37);
            this.btSua.TabIndex = 23;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // numKM
            // 
            this.numKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numKM.Location = new System.Drawing.Point(322, 38);
            this.numKM.Name = "numKM";
            this.numKM.Size = new System.Drawing.Size(157, 31);
            this.numKM.TabIndex = 23;
            // 
            // dgvKM
            // 
            this.dgvKM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKM.Location = new System.Drawing.Point(3, 206);
            this.dgvKM.Name = "dgvKM";
            this.dgvKM.ReadOnly = true;
            this.dgvKM.RowHeadersWidth = 51;
            this.dgvKM.Size = new System.Drawing.Size(585, 501);
            this.dgvKM.TabIndex = 12;
            this.dgvKM.DoubleClick += new System.EventHandler(this.dgvKM_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTim);
            this.panel2.Controls.Add(this.btnTaiLai);
            this.panel2.Controls.Add(this.chbTenSP);
            this.panel2.Controls.Add(this.chbGiaBan);
            this.panel2.Controls.Add(this.chbChuaKM);
            this.panel2.Controls.Add(this.dgvSanPham);
            this.panel2.Controls.Add(this.txtGiaBan);
            this.panel2.Controls.Add(this.txtTenSanPham);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(723, 710);
            this.panel2.TabIndex = 27;
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(275, 160);
            this.btnTim.Margin = new System.Windows.Forms.Padding(2);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(149, 37);
            this.btnTim.TabIndex = 23;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiLai.Location = new System.Drawing.Point(531, 160);
            this.btnTaiLai.Margin = new System.Windows.Forms.Padding(2);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(149, 37);
            this.btnTaiLai.TabIndex = 23;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // chbTenSP
            // 
            this.chbTenSP.AutoSize = true;
            this.chbTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbTenSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.chbTenSP.Location = new System.Drawing.Point(132, 27);
            this.chbTenSP.Name = "chbTenSP";
            this.chbTenSP.Size = new System.Drawing.Size(168, 29);
            this.chbTenSP.TabIndex = 22;
            this.chbTenSP.Text = "Tên sản phẩm";
            this.chbTenSP.UseVisualStyleBackColor = true;
            // 
            // chbGiaBan
            // 
            this.chbGiaBan.AutoSize = true;
            this.chbGiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbGiaBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.chbGiaBan.Location = new System.Drawing.Point(132, 79);
            this.chbGiaBan.Name = "chbGiaBan";
            this.chbGiaBan.Size = new System.Drawing.Size(106, 29);
            this.chbGiaBan.TabIndex = 22;
            this.chbGiaBan.Text = "Giá bán";
            this.chbGiaBan.UseVisualStyleBackColor = true;
            // 
            // chbChuaKM
            // 
            this.chbChuaKM.AutoSize = true;
            this.chbChuaKM.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbChuaKM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.chbChuaKM.Location = new System.Drawing.Point(3, 168);
            this.chbChuaKM.Name = "chbChuaKM";
            this.chbChuaKM.Size = new System.Drawing.Size(253, 27);
            this.chbChuaKM.TabIndex = 22;
            this.chbChuaKM.Text = "Sản phẩm chưa khuyến mãi";
            this.chbChuaKM.UseVisualStyleBackColor = true;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(3, 206);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.Size = new System.Drawing.Size(717, 501);
            this.dgvSanPham.TabIndex = 12;
            this.dgvSanPham.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellDoubleClick);
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaBan.Location = new System.Drawing.Point(310, 77);
            this.txtGiaBan.Margin = new System.Windows.Forms.Padding(2);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(207, 31);
            this.txtGiaBan.TabIndex = 21;
            this.txtGiaBan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGaBan_KeyPress);
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSanPham.Location = new System.Drawing.Point(310, 25);
            this.txtTenSanPham.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(207, 31);
            this.txtTenSanPham.TabIndex = 21;
            // 
            // frmKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1351, 734);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKhuyenMai";
            this.Text = "frmKhuyenMai";
            this.Load += new System.EventHandler(this.frmKhuyenMai_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKM)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cboKhuyenMai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvKM;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.CheckBox chbChuaKM;
        private System.Windows.Forms.CheckBox chbGiaBan;
        private System.Windows.Forms.NumericUpDown numKM;
        private System.Windows.Forms.CheckBox chbTenSP;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Button btnThem;
    }
}