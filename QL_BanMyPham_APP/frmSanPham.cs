using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanMyPham_APP
{
    public partial class frmSanPham : Form
    {
        SanPham spDTO = new SanPham();
        SanPham_BLL spBLL = new SanPham_BLL();
        LoaiHang_BLL lhBLL = new LoaiHang_BLL();
        ThuongHieu_BLL thBLL = new ThuongHieu_BLL();
        public frmSanPham()
        {
            InitializeComponent();
            txtMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtHinhAnh.Enabled = false;
            txtGiaBan.Enabled = false;
            cboMaLoai.Enabled = false;
            cboThuongHieu.Enabled = false;
            dtpHSD.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            string masp;
            if(dgvSanPham.RowCount < 10)
            {
                masp = "SP0" + dgvSanPham.RowCount + date.Date.ToString("ddMMyyyy");
            }    
            else
                masp = "SP" + dgvSanPham.RowCount + date.Date.ToString("ddMMyyyy");
            txtMaSP.Text = masp;
            txtTenSP.Enabled = true;
            txtHinhAnh.Enabled = true;
            txtGiaBan.Enabled = true;
            cboMaLoai.Enabled = true;
            cboThuongHieu.Enabled = true;
            dtpHSD.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            loadData();
            loadLoaiHang();
            loadThuongHieu();
        }
        private void loadLoaiHang()
        {
            cboMaLoai.ValueMember = "MaLoai";
            cboMaLoai.DisplayMember = "TenLoai";
            cboMaLoai.DataSource = lhBLL.GetListLoaiHang();
        }
        private void loadThuongHieu()
        {
            cboThuongHieu.DisplayMember = "TenTH";
            cboThuongHieu.ValueMember = "MaTH";
            cboThuongHieu.DataSource = thBLL.GetListThuongHieu();
        }
        private void loadData()
        {
            dgvSanPham.DataSource = spBLL.getSanPham();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkTextBox())
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                spDTO.MaSP = txtMaSP.Text;
                spDTO.TenSP = txtTenSP.Text;
                spDTO.MaLoai = cboMaLoai.SelectedValue.ToString();
                spDTO.MaTH = cboThuongHieu.SelectedValue.ToString();
                spDTO.HinhAnh = txtHinhAnh.Text;
                spDTO.HSD = dtpHSD.Text;
                spDTO.GiaBan = float.Parse(txtGiaBan.Text);
                if (spBLL.timSanPham(txtMaSP.Text) == 1)
                {
                    if (spBLL.suaSanPham(spDTO) != -1)
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    if (spBLL.themSanPham(spDTO) != -1)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
                clearTextBox();
                loadData();
            }
        }
        private bool checkTextBox()
        {
            if (txtTenSP.Text == "" || txtGiaBan.Text == "" || txtHinhAnh.Text == "")
                return true;
            return false;
        }
        private void clearTextBox()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtHinhAnh.Clear();
            txtGiaBan.Clear();

        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvSanPham.RowCount == 1)
                    return;
                else if (dgvSanPham.CurrentRow != null && dgvSanPham.CurrentRow.Index < dgvSanPham.Rows.Count - 1)
                {
                    txtMaSP.Text = dgvSanPham.CurrentRow.Cells[0].Value.ToString();
                    txtTenSP.Text = dgvSanPham.CurrentRow.Cells[1].Value.ToString();
                    cboMaLoai.Text = dgvSanPham.CurrentRow.Cells[2].Value.ToString();
                    cboThuongHieu.Text = dgvSanPham.CurrentRow.Cells[4].Value.ToString();
                    dtpHSD.Text = dgvSanPham.CurrentRow.Cells[5].Value.ToString();
                    txtHinhAnh.Text = dgvSanPham.CurrentRow.Cells[6].Value.ToString();
                    txtGiaBan.Text = dgvSanPham.CurrentRow.Cells[7].Value.ToString();
                }
            }
            catch
            {
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var n = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (n == DialogResult.Yes)
                {
                    if (spBLL.xoaSanPham(txtMaSP.Text) != -1)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK);
                    }
                    loadData();
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(open.FileName);
                System.IO.File.Copy(open.FileName, open.FileName.Split('.')[0] + "_Copy." + open.FileName.Split('.')[1]);
                string imagename = open.SafeFileName;
                txtHinhAnh.Text = imagename;
                open.RestoreDirectory = true;
            }
        }
    }
}
