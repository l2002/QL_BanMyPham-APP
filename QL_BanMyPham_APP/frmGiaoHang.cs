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
        DonHang_BLL dhBLL = new DonHang_BLL();
        public frmGiaoHang()
        {
            InitializeComponent();
        }
        private void loadTable()
        {
            dgvHD.DataSource = dhBLL.getHoaDon();
        }

        private void frmGiaoHang_Load(object sender, EventArgs e)
        {
            loadTable();
        }

        private void dgvHD_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaHD.Text = dgvHD.CurrentRow.Cells[0].Value.ToString();
                txtMaKH.Text = dgvHD.CurrentRow.Cells[1].Value.ToString();
                txtNgayDat.Text = dgvHD.CurrentRow.Cells[2].Value.ToString();
                txtNgayGiao.Text = dgvHD.CurrentRow.Cells[3].Value.ToString();
                cboTrangThai.Text = dgvHD.CurrentRow.Cells[4].Value.ToString();
                txtTongTien.Text = dgvHD.CurrentRow.Cells[5].Value.ToString();
            }
            catch
            {
                return;
            }
        }
        private bool btnUpdateNgayGiaoClicked = false;
        private bool btnUpdateTrangThaiClicked = false;

        private void btnUpdateNgayGiao_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtNgayGiao.Enabled = true;
            btnUpdateNgayGiaoClicked = true;
        }

        private void btnUpdateTrangThai_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            cboTrangThai.Enabled= true;
            btnUpdateTrangThaiClicked=true;
        }

     
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            if (btnUpdateNgayGiaoClicked)
            {
                dhDTO.NgayGiao = txtNgayGiao.Text;
                dhDTO.MaDH = txtMaHD.Text;

                if (dhBLL.updateNgayGiao(dhDTO) != -1)
                {
                    MessageBox.Show("Cập nhật thành công ngày giao", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK);
                }
                loadTable();
                btnLuu.Enabled = false;
                txtNgayGiao.Enabled = false;               
            }
            else if(btnUpdateTrangThaiClicked)
            {
                dhDTO.TinhTrang = cboTrangThai.Text;
                dhDTO.MaDH = txtMaHD.Text;

                if (dhBLL.updateTinhTrang(dhDTO) != -1)
                {
                    MessageBox.Show("Cập nhật thành công trạng thái đơn hàng", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK);
                }
                loadTable();
                btnLuu.Enabled = false;
                cboTrangThai.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var n = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (n == DialogResult.Yes)
                {
                    if (dhBLL.xoaDonHang(txtMaHD.Text) != -1)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK);
                    }
                    loadTable();
                }
            }
        }
    }
}
