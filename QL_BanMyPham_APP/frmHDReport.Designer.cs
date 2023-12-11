//namespace QL_BanMyPham_APP
//{
//    partial class frmHDReport
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
//            this.QL_MyPham_DADataSet = new QL_BanMyPham_APP.QL_MyPham_DADataSet();
//            this.CTDonHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
//            this.CTDonHangTableAdapter = new QL_BanMyPham_APP.QL_MyPham_DADataSetTableAdapters.CTDonHangTableAdapter();
//            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
//            ((System.ComponentModel.ISupportInitialize)(this.QL_MyPham_DADataSet)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.CTDonHangBindingSource)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // QL_MyPham_DADataSet
//            // 
//            this.QL_MyPham_DADataSet.DataSetName = "QL_MyPham_DADataSet";
//            this.QL_MyPham_DADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
//            // 
//            // CTDonHangBindingSource
//            // 
//            this.CTDonHangBindingSource.DataMember = "CTDonHang";
//            this.CTDonHangBindingSource.DataSource = this.QL_MyPham_DADataSet;
//            // 
//            // CTDonHangTableAdapter
//            // 
//            this.CTDonHangTableAdapter.ClearBeforeFill = true;
//            // 
//            // reportViewer1
//            // 
//            reportDataSource1.Name = "DataSet1";
//            reportDataSource1.Value = this.CTDonHangBindingSource;
//            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
//            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QL_BanMyPham_APP.HoaDon.rdlc";
//            this.reportViewer1.Location = new System.Drawing.Point(12, 177);
//            this.reportViewer1.Name = "reportViewer1";
//            this.reportViewer1.Size = new System.Drawing.Size(867, 374);
//            this.reportViewer1.TabIndex = 0;
//            // 
//            // frmHDReport
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(891, 724);
//            this.Controls.Add(this.reportViewer1);
//            this.Name = "frmHDReport";
//            this.Text = "frmHDReport";
//            this.Load += new System.EventHandler(this.frmHDReport_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.QL_MyPham_DADataSet)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.CTDonHangBindingSource)).EndInit();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.BindingSource CTDonHangBindingSource;
//        private QL_MyPham_DADataSet QL_MyPham_DADataSet;
//        private QL_MyPham_DADataSetTableAdapters.CTDonHangTableAdapter CTDonHangTableAdapter;
//        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
//    }
//}