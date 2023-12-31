﻿using BLL;
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
        CTDH_BLL CTDH_BLL = new CTDH_BLL();

        private string _tenNV;
        private string _maNV;
        public frmBanHang(string tenNV, string maNV) : this()
        {
            _tenNV = tenNV;
            txtTenNV.Text = _tenNV;
            _maNV = maNV;
            txtMaNV.Text = _maNV;
        }
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
        public void ResetValue()
        {
            cboMaKH.SelectedValue = -1;
            txtNgayDat.Text = DateTime.Now.ToString();
            txtTongTien.Text = "0";
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
            DateTime date = DateTime.Now;
            string mahd;
            mahd = "HDB" + date.ToString("ddMMyyyyHHmmss");
            txtMaHD.Text = mahd;
            btnThemHD.Enabled = true;
            btnTaoHDClicked = true;

            ResetValue();

        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            
        }

        bool btnTaoHDClicked = false;
        private void btnThemHD_Click(object sender, EventArgs e)
        {
            if(cboMaKH.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Khách hàng!");
                return;
            }
            dhDTO.MaDH = txtMaHD.Text;
            dhDTO.NgayDat = txtNgayDat.Text;
            dhDTO.MaKH = cboMaKH.SelectedValue.ToString();
            dhDTO.MaNV = txtMaNV.Text;

            if (btnTaoHDClicked)
            {
                if (dhBLL.themHD(dhDTO) != -1)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    frmCTDH Child = new frmCTDH(txtMaHD.Text);
                    Child.Show();
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

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            txtTongTien.Text = dhBLL.getTongTien(txtMaHD.Text).ToString();
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaHD.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn Mã Hóa đơn!");
                    return;
                }
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CTDH_BLL.xoaCTDH(txtMaHD.Text);

                    dhBLL.xoaDH(txtMaHD.Text);
                    MessageBox.Show("Hủy thành công!");
                }
            }
            catch
            {
                MessageBox.Show("Hủy thất bại!");
            }
            loadTable();
        }

        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvDH_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDH.RowCount == 1)
                    return;
                else if (dgvDH.CurrentRow != null && dgvDH.CurrentRow.Index < dgvDH.Rows.Count - 1)
                {
                    txtMaHD.Text = dgvDH.CurrentRow.Cells[0].Value.ToString();
                    cboMaKH.SelectedValue = dgvDH.CurrentRow.Cells[1].Value.ToString();
                    //txtMaNV.Text = dgvDH.CurrentRow.Cells[2].Value.ToString();
                    //txtTenNV.Text = dgvDH.CurrentRow.Cells[3].Value.ToString(); 
                    txtNgayDat.Text = dgvDH.CurrentRow.Cells[4].Value.ToString();
                    txtTongTien.Text = dgvDH.CurrentRow.Cells[5].Value.ToString();
                }
            }
            catch
            {
                return;
            }
        }
    }
}
