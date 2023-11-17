using BLL;
using DTO;
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
    public partial class frmGiaoHang : Form
    {
        DonHang dhDTO = new DonHang();
        HoaDon_BLL nvBLL = new HoaDon_BLL();
        public frmGiaoHang()
        {
            InitializeComponent();
        }
        private void loadTable()
        {
            dgvHD.DataSource = nvBLL.getHoaDon();
        }

        private void frmGiaoHang_Load(object sender, EventArgs e)
        {
            loadTable();
        }
    }
}
