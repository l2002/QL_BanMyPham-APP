using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace QL_BanMyPham_APP
{
    public partial class frmNhanVien : Form
    {
        NhanVien nvDTO = new NhanVien();
        NhanVien_BLL nvBLL = new NhanVien_BLL();

        public frmNhanVien()
        {
            InitializeComponent();
            cboGioiTinh.SelectedIndex = 0;
            txtMaNV.Enabled = false;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            loadTable();
        }
        private void loadTable()
        {
            dgvNhanVien.DataSource = nvBLL.getNhanVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkTextBox())
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            else
            {
                int stt = dgvNhanVien.RowCount;
                string manv;
                if (stt < 10)
                {
                    manv = "NV" + "0" + stt.ToString();
                }
                else
                {
                    manv = "NV" + stt.ToString();
                }
                nvDTO.MaNV = manv;
                nvDTO.TenNV = txtTenNV.Text;
                nvDTO.GioiTinh = cboGioiTinh.SelectedItem.ToString();
                nvDTO.DiaChi = txtDiaChi.Text;
                nvDTO.DienThoai = txtDienThoai.Text;
                nvDTO.NgaySinh = dtpNgaySinh.Text;
                if(nvBLL.themNhanVien(nvDTO) != -1)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK);
                }    
                loadTable();
            }    
        }
        private bool checkTextBox()
        {
            if (txtTenNV.Text == "" || txtDiaChi.Text == "" || txtDienThoai.Text == "")
                return true;
            return false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "") 
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            else
            {
                nvDTO.MaNV = txtMaNV.Text;
                nvDTO.TenNV = txtTenNV.Text;
                nvDTO.GioiTinh = cboGioiTinh.SelectedItem.ToString();
                nvDTO.DiaChi = txtDiaChi.Text;
                nvDTO.DienThoai = txtDienThoai.Text;
                nvDTO.NgaySinh = dtpNgaySinh.Text;
                if (nvBLL.suaNhanVien(nvDTO) != -1)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK);
                }
                loadTable();
            }    
                
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var n = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(n == DialogResult.Yes)
                {
                    if (nvBLL.xoaNhanVien(txtMaNV.Text) != -1)
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

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaNV.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
                txtTenNV.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
                cboGioiTinh.Text = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
                txtDienThoai.Text = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();
                dtpNgaySinh.Text = dgvNhanVien.CurrentRow.Cells[5].Value.ToString();
            }
            catch 
            {
                return;
            }
        }
    }
}
