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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            btnHome.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Trang Chủ";
            this.pnLoad.Controls.Clear();
            frmTrangChu frm = new frmTrangChu() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            btnHome.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Nhân Viên";
            this.pnLoad.Controls.Clear();
            frmNhanVien frm = new frmNhanVien() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnNCCHSX_Click(object sender, EventArgs e)
        {
            
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            btnHoaDon.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Hóa Đơn";
            this.pnLoad.Controls.Clear();
            frmBanHang frm = new frmBanHang() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnHoaDon.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Giao Hàng";
            this.pnLoad.Controls.Clear();
            frmGiaoHang frm = new frmGiaoHang() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();
        }
    }
}
