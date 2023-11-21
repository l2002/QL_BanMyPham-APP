using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanMyPham_APP
{
    public partial class frmCTDH : Form
    {
        CTDonHang ctdhDTO = new CTDonHang();
        CTDH_BLL ctdhBLL = new CTDH_BLL();
        SanPham_BLL spBLL = new SanPham_BLL();

        private string _maDH;
        public frmCTDH(string maDH) : this()
        {
            _maDH = maDH;
            txtMaDH.Text = _maDH;
        }
        public frmCTDH()
        {
            InitializeComponent();
        }

        private void loadCombo()
        {
            spBLL.FillCombo("SELECT MaSP,TenSP FROM SanPham", cboMaSP, "MaSP", "MaSP");
            cboMaSP.SelectedIndex = -1;
        }

        private void loadTable()
        {
            dgvDS.DataSource = ctdhBLL.getCTDH(ctdhDTO);
        }
        private void frmCTDH_Load(object sender, EventArgs e)
        {
            loadCombo();
        }

        private void cboMaSP_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaSP.Text == "")
            {
                txtTenSP.Text = "";
            }
            str = "SELECT TenSP FROM SanPham WHERE MaSP = N'" + cboMaSP.SelectedValue + "'";
            txtTenSP.Text = spBLL.GetFieldValues(str);
            str = "SELECT HSD FROM SanPham WHERE MaSP = N'" + cboMaSP.SelectedValue + "'";
            txtHSD.Text = spBLL.GetFieldValues(str);
            str = "SELECT GiaBan FROM SanPham WHERE MaSP = N'" + cboMaSP.SelectedValue + "'";
            txtGiaBan.Text = spBLL.GetFieldValues(str);
            str = "select KhuyenMai.TenKM from SanPham,KhuyenMai WHERE MaSP = N'" + cboMaSP.SelectedValue + "' and SanPham.MaKM=KhuyenMai.MaKM";
            txtKhuyenMai.Text = spBLL.GetFieldValues(str);
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = double.Parse(txtSoLuong.Text);

            if (txtGiaBan.Text == "")
                dg = 0;
            else
                dg = double.Parse(txtGiaBan.Text);
            tt = sl * dg;
            txtThanhTien.Text = tt.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            ctdhDTO.MaDH = txtMaDH.Text;
            ctdhDTO.MaSP = cboMaSP.SelectedValue.ToString();
            ctdhDTO.SoLuongMua = int.Parse(txtSoLuong.Text);
            ctdhDTO.ThanhTien = double.Parse(txtThanhTien.Text);

            if (ctdhBLL.ktraSPDaCo(ctdhDTO) == 0)
            {
                if (ctdhBLL.themCTHD(ctdhDTO) != -1)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK);
                }
                loadTable();
            }
            else
            {
                MessageBox.Show("Sản phẩm này đã có!");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
