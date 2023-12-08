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
        DonHangOnl dhDTO = new DonHangOnl();
        DonHangOnl_BLL dhBLL = new DonHangOnl_BLL();
        public frmGiaoHang()
        {
            InitializeComponent();
        }
        private void loadTable()
        {
            dgvHD.DataSource = dhBLL.getHoaDonOnl();
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
                txtNgayDat.Text = dgvHD.CurrentRow.Cells[1].Value.ToString();
                txtNgayGiao.Text = dgvHD.CurrentRow.Cells[2].Value.ToString();
                cboTrangThai.Text = dgvHD.CurrentRow.Cells[3].Value.ToString();
                txtMaKH.Text = dgvHD.CurrentRow.Cells[4].Value.ToString();
                txtTongTien.Text = dgvHD.CurrentRow.Cells[5].Value.ToString();
            }
            catch
            {
                return;
            }
        }
        bool btnUpdateNgayGiaoClicked = false;
        bool btnUpdateTrangThaiClicked = false;

        private void btnUpdateNgayGiao_Click(object sender, EventArgs e)
        {
            btnUpdateNgayGiaoClicked = true;
            btnLuu.Enabled = true;
            txtNgayGiao.Enabled = true;
        }

        private void btnUpdateTrangThai_Click(object sender, EventArgs e)
        {
            btnUpdateTrangThaiClicked=true;
            btnLuu.Enabled = true;
            cboTrangThai.Enabled= true;
        }

     
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (btnUpdateNgayGiaoClicked)
            {
                dhDTO.NgayGiao = txtNgayGiao.Text;
                dhDTO.Madon = txtMaHD.Text;

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
                btnUpdateNgayGiaoClicked = false;
            }
            else if(btnUpdateTrangThaiClicked)
            {
                dhDTO.TinhTrang = cboTrangThai.Text;
                dhDTO.Madon = txtMaHD.Text;

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
                btnUpdateTrangThaiClicked=false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
        }
    }
}
