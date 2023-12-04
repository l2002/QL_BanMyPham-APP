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

        private string _tenNV;
        private string _maNV;

        public frmMain(string tenNV, string maNV) : this()
        {
            _tenNV = tenNV;
            lblName.Text = _tenNV;
            _maNV = maNV;
            lblMaNV.Text = _maNV;
        }
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
            btnNCCHSX.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "NCC&HSX";
            this.pnLoad.Controls.Clear();
            frmThuongHieu frm = new frmThuongHieu() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            btnHoaDon.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Hóa Đơn";
            this.pnLoad.Controls.Clear();
            frmBanHang Child = new frmBanHang(lblName.Text,lblMaNV.Text) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Child.FormBorderStyle = FormBorderStyle.None;

            this.pnLoad.Controls.Add(Child);
            Child.Show();
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

        private void btnSP_Click(object sender, EventArgs e)
        {
            btnSP.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Sản Phẩm";
            this.pnLoad.Controls.Clear();
            frmSanPham frm = new frmSanPham() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            btnKhuyenMai.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Khuyến Mãi";
            this.pnLoad.Controls.Clear();
            frmKhuyenMai frm = new frmKhuyenMai() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            btnTaiKhoan.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Tài Khoản";
            this.pnLoad.Controls.Clear();
            frmTaiKhoan frm = new frmTaiKhoan() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Báo Cáo";
            this.pnLoad.Controls.Clear();
            frmBaoCao frm = new frmBaoCao() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();
        }
    }
}
