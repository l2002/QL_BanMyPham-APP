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
    public partial class frmMain : Form
    {
        TaiKhoan_BLL tk_bll = new TaiKhoan_BLL();

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

            btnNhanVien.BackColor = Color.DarkSlateBlue;
            btnKhach.BackColor = Color.DarkSlateBlue;
            btnNhapHang.BackColor = Color.DarkSlateBlue;
            btnLoaiHang.BackColor = Color.DarkSlateBlue;
            btnNCCHSX.BackColor = Color.DarkSlateBlue;
            btnHoaDon.BackColor = Color.DarkSlateBlue;
            btnTaiKhoan.BackColor = Color.DarkSlateBlue;
            btnKhuyenMai.BackColor = Color.DarkSlateBlue;
            btnBaoCao.BackColor = Color.DarkSlateBlue;
            button3.BackColor = Color.DarkSlateBlue;
            btnNhap_Xuat.BackColor = Color.DarkSlateBlue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            if (tk_bll.getMaQuyen(_maNV) == "2")
            {
                MessageBox.Show("Bạn không có quyền truy cập trang này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btnNhanVien.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Nhân Viên";
            this.pnLoad.Controls.Clear();
            frmNhanVien frm = new frmNhanVien() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();

            btnHome.BackColor = Color.DarkSlateBlue;
            btnKhach.BackColor = Color.DarkSlateBlue;
            btnNhapHang.BackColor = Color.DarkSlateBlue;
            btnLoaiHang.BackColor = Color.DarkSlateBlue;
            btnNCCHSX.BackColor = Color.DarkSlateBlue;
            btnHoaDon.BackColor = Color.DarkSlateBlue;
            btnTaiKhoan.BackColor = Color.DarkSlateBlue;
            btnKhuyenMai.BackColor = Color.DarkSlateBlue;
            btnBaoCao.BackColor = Color.DarkSlateBlue;
            button3.BackColor = Color.DarkSlateBlue;
            btnNhap_Xuat.BackColor = Color.DarkSlateBlue;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            btnHome_Click(sender, e);
        }

        private void btnNCCHSX_Click(object sender, EventArgs e)
        {
            btnNCCHSX.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Thương hiệu & Nhà cung cấp";
            this.pnLoad.Controls.Clear();
            frmThuongHieu frm = new frmThuongHieu() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();

            btnNhanVien.BackColor = Color.DarkSlateBlue;
            btnKhach.BackColor = Color.DarkSlateBlue;
            btnNhapHang.BackColor = Color.DarkSlateBlue;
            btnLoaiHang.BackColor = Color.DarkSlateBlue;
            btnHome.BackColor = Color.DarkSlateBlue;
            btnHoaDon.BackColor = Color.DarkSlateBlue;
            btnTaiKhoan.BackColor = Color.DarkSlateBlue;
            btnKhuyenMai.BackColor = Color.DarkSlateBlue;
            btnBaoCao.BackColor = Color.DarkSlateBlue;
            button3.BackColor = Color.DarkSlateBlue;
            btnNhap_Xuat.BackColor = Color.DarkSlateBlue;
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

            btnNhanVien.BackColor = Color.DarkSlateBlue;
            btnKhach.BackColor = Color.DarkSlateBlue;
            btnNhapHang.BackColor = Color.DarkSlateBlue;
            btnLoaiHang.BackColor = Color.DarkSlateBlue;
            btnNCCHSX.BackColor = Color.DarkSlateBlue;
            btnHome.BackColor = Color.DarkSlateBlue;
            btnTaiKhoan.BackColor = Color.DarkSlateBlue;
            btnKhuyenMai.BackColor = Color.DarkSlateBlue;
            btnBaoCao.BackColor = Color.DarkSlateBlue;
            button3.BackColor = Color.DarkSlateBlue;
            btnNhap_Xuat.BackColor = Color.DarkSlateBlue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Giao Hàng";
            this.pnLoad.Controls.Clear();
            frmGiaoHang frm = new frmGiaoHang() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();

            btnNhanVien.BackColor = Color.DarkSlateBlue;
            btnKhach.BackColor = Color.DarkSlateBlue;
            btnNhapHang.BackColor = Color.DarkSlateBlue;
            btnLoaiHang.BackColor = Color.DarkSlateBlue;
            btnNCCHSX.BackColor = Color.DarkSlateBlue;
            btnHoaDon.BackColor = Color.DarkSlateBlue;
            btnTaiKhoan.BackColor = Color.DarkSlateBlue;
            btnKhuyenMai.BackColor = Color.DarkSlateBlue;
            btnBaoCao.BackColor = Color.DarkSlateBlue;
            btnHome.BackColor = Color.DarkSlateBlue;
            btnNhap_Xuat.BackColor = Color.DarkSlateBlue;
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            btnNhapHang.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Sản Phẩm";
            this.pnLoad.Controls.Clear();
            frmNhapHang frm = new frmNhapHang() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();

            btnNhanVien.BackColor = Color.DarkSlateBlue;
            btnKhach.BackColor = Color.DarkSlateBlue;
            btnHome.BackColor = Color.DarkSlateBlue;
            btnLoaiHang.BackColor = Color.DarkSlateBlue;
            btnNCCHSX.BackColor = Color.DarkSlateBlue;
            btnHoaDon.BackColor = Color.DarkSlateBlue;
            btnTaiKhoan.BackColor = Color.DarkSlateBlue;
            btnKhuyenMai.BackColor = Color.DarkSlateBlue;
            btnBaoCao.BackColor = Color.DarkSlateBlue;
            button3.BackColor = Color.DarkSlateBlue;
            btnNhap_Xuat.BackColor = Color.DarkSlateBlue;
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

            btnNhanVien.BackColor = Color.DarkSlateBlue;
            btnKhach.BackColor = Color.DarkSlateBlue;
            btnNhapHang.BackColor = Color.DarkSlateBlue;
            btnLoaiHang.BackColor = Color.DarkSlateBlue;
            btnNCCHSX.BackColor = Color.DarkSlateBlue;
            btnHoaDon.BackColor = Color.DarkSlateBlue;
            btnTaiKhoan.BackColor = Color.DarkSlateBlue;
            btnHome.BackColor = Color.DarkSlateBlue;
            btnBaoCao.BackColor = Color.DarkSlateBlue;
            button3.BackColor = Color.DarkSlateBlue;
            btnNhap_Xuat.BackColor = Color.DarkSlateBlue;
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            if (tk_bll.getMaQuyen(_maNV) == "2")
            {
                MessageBox.Show("Bạn không có quyền truy cập trang này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btnTaiKhoan.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Tài Khoản";
            this.pnLoad.Controls.Clear();
            frmTaiKhoan frm = new frmTaiKhoan() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();

            btnNhanVien.BackColor = Color.DarkSlateBlue;
            btnKhach.BackColor = Color.DarkSlateBlue;
            btnNhapHang.BackColor = Color.DarkSlateBlue;
            btnLoaiHang.BackColor = Color.DarkSlateBlue;
            btnNCCHSX.BackColor = Color.DarkSlateBlue;
            btnHoaDon.BackColor = Color.DarkSlateBlue;
            btnHome.BackColor = Color.DarkSlateBlue;
            btnKhuyenMai.BackColor = Color.DarkSlateBlue;
            btnBaoCao.BackColor = Color.DarkSlateBlue;
            button3.BackColor = Color.DarkSlateBlue;
            btnNhap_Xuat.BackColor = Color.DarkSlateBlue;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            btnBaoCao.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Báo Cáo";
            this.pnLoad.Controls.Clear();
            frmBaoCao frm = new frmBaoCao() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();

            btnNhanVien.BackColor = Color.DarkSlateBlue;
            btnKhach.BackColor = Color.DarkSlateBlue;
            btnNhapHang.BackColor = Color.DarkSlateBlue;
            btnLoaiHang.BackColor = Color.DarkSlateBlue;
            btnNCCHSX.BackColor = Color.DarkSlateBlue;
            btnHoaDon.BackColor = Color.DarkSlateBlue;
            btnTaiKhoan.BackColor = Color.DarkSlateBlue;
            btnHome.BackColor = Color.DarkSlateBlue;
            button3.BackColor = Color.DarkSlateBlue;
            btnNhap_Xuat.BackColor = Color.DarkSlateBlue;
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLoaiHang_Click(object sender, EventArgs e)
        {
            btnLoaiHang.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Loại hàng";
            this.pnLoad.Controls.Clear();
            frmLoaiHang frm = new frmLoaiHang() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();

            btnNhanVien.BackColor = Color.DarkSlateBlue;
            btnKhach.BackColor = Color.DarkSlateBlue;
            btnNhapHang.BackColor = Color.DarkSlateBlue;
            btnHome.BackColor = Color.DarkSlateBlue;
            btnNCCHSX.BackColor = Color.DarkSlateBlue;
            btnHoaDon.BackColor = Color.DarkSlateBlue;
            btnTaiKhoan.BackColor = Color.DarkSlateBlue;
            btnKhuyenMai.BackColor = Color.DarkSlateBlue;
            btnBaoCao.BackColor = Color.DarkSlateBlue;
            button3.BackColor = Color.DarkSlateBlue;
            btnNhap_Xuat.BackColor = Color.DarkSlateBlue;
        }

        private void btnNhap_Xuat_Click(object sender, EventArgs e)
        {
            btnNhap_Xuat.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Nhập & Xuất Dữ liệu";
            this.pnLoad.Controls.Clear();
            frmIP_EP frm = new frmIP_EP() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();

            btnNhanVien.BackColor = Color.DarkSlateBlue;
            btnKhach.BackColor = Color.DarkSlateBlue;
            btnNhapHang.BackColor = Color.DarkSlateBlue;
            btnLoaiHang.BackColor = Color.DarkSlateBlue;
            btnNCCHSX.BackColor = Color.DarkSlateBlue;
            btnHoaDon.BackColor = Color.DarkSlateBlue;
            btnTaiKhoan.BackColor = Color.DarkSlateBlue;
            btnKhuyenMai.BackColor = Color.DarkSlateBlue;
            btnBaoCao.BackColor = Color.DarkSlateBlue;
            button3.BackColor = Color.DarkSlateBlue;
            btnHome.BackColor = Color.DarkSlateBlue;
        }

        private void btnKhach_Click(object sender, EventArgs e)
        {
            btnKhach.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Khách Hàng";
            this.pnLoad.Controls.Clear();
            frmKhachHang frm = new frmKhachHang() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.pnLoad.Controls.Add(frm);
            frm.Show();

            btnNhanVien.BackColor = Color.DarkSlateBlue;
            btnHome.BackColor = Color.DarkSlateBlue;
            btnNhapHang.BackColor = Color.DarkSlateBlue;
            btnLoaiHang.BackColor = Color.DarkSlateBlue;
            btnNCCHSX.BackColor = Color.DarkSlateBlue;
            btnHoaDon.BackColor = Color.DarkSlateBlue;
            btnTaiKhoan.BackColor = Color.DarkSlateBlue;
            btnKhuyenMai.BackColor = Color.DarkSlateBlue;
            btnBaoCao.BackColor = Color.DarkSlateBlue;
            button3.BackColor = Color.DarkSlateBlue;
            btnNhap_Xuat.BackColor = Color.DarkSlateBlue;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                frmLogin Child = new frmLogin();
                Child.Show();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
