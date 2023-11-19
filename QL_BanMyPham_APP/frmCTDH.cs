using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanMyPham_APP
{
    public partial class frmCTDH : Form
    {
        CTDH_BLL ctdhBLL=new CTDH_BLL();
        public frmCTDH()
        {
            InitializeComponent();
        }
        private void loadTable()
        {
            dgvDS.DataSource = ctdhBLL.getCTDH();
        }
        private void frmCTDH_Load(object sender, EventArgs e)
        {
            loadTable();
        }
    }
}
