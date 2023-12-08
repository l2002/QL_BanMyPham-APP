using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanMyPham_APP
{
    public partial class frmHDReport : Form
    {
        public frmHDReport()
        {
            InitializeComponent();
        }

        private void frmHDReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QL_MyPham_DADataSet.CTDonHang' table. You can move, or remove it, as needed.
            this.CTDonHangTableAdapter.Fill(this.QL_MyPham_DADataSet.CTDonHang);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
