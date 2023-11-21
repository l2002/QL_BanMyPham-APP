using BLL;
using DTO;
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
    public partial class frmBanHang : Form
    {
        DonHang dhDTO = new DonHang();
        DonHang_BLL dhBLL = new DonHang_BLL();
        KhachHang_BLL khBLL = new KhachHang_BLL();
       

        public frmBanHang()
        {
            InitializeComponent();
        }

        private void loadCombo()
        {
            khBLL.FillCombo("SELECT MaKH, TenKH FROM KhachHang", cboMaKH, "MaKH", "MaKH");
            cboMaKH.SelectedIndex = -1;
            //khBLL.FillCombo("SELECT MaSP, TenSP FROM SanPham", cboMaSP, "MaSP", "MaSP");
            //cboMaSP.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void loadTable()
        {
            dgvDH.DataSource = dhBLL.getHoaDon();
        }
        private void frmBanHang_Load(object sender, EventArgs e)
        {
            loadTable();
            loadCombo();           
        }
    
        private void cboMaKH_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaKH.Text == "")
            {
                txtTenKH.Text = "";
            }
            str = "SELECT TenKH FROM KhachHang WHERE MaKH = N'" + cboMaKH.SelectedValue + "'";
            txtTenKH.Text = khBLL.GetFieldValues(str);
            str = "SELECT DiaChi FROM KhachHang WHERE MaKH = N'" + cboMaKH.SelectedValue + "'";
            txtDiaChiKH.Text = khBLL.GetFieldValues(str);
            str = "SELECT DienThoai FROM KhachHang WHERE MaKH= N'" + cboMaKH.SelectedValue + "'";
            txtSĐTKH.Text = khBLL.GetFieldValues(str);
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = dhBLL.taoMaDH();
            btnThemHD.Enabled = true;
            btnThemSP.Enabled = true;
            btnTaoHDClicked = true;          
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            frmCTDH Child = new frmCTDH(txtMaHD.Text);
            Child.Show();
        }

        bool btnTaoHDClicked = false;
        private void btnThemHD_Click(object sender, EventArgs e)
        {
            dhDTO.MaDH = txtMaHD.Text;
            dhDTO.NgayDat = txtNgayDat.Text;
            dhDTO.TongTien = 0;
            dhDTO.MaKH = cboMaKH.SelectedValue.ToString();
          
            if (btnTaoHDClicked)
            {
                if (dhBLL.themHD(dhDTO) != -1)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK);
                }
            }          
            else
            {
                MessageBox.Show("Vui lòng tạo đơn hàng trước khi thêm!");
            }
            loadTable();
            btnThemHD.Enabled = false;
        }
    }
}
