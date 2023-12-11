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
        LoHang loDTO = new LoHang();
        SanPham_BLL spBLL = new SanPham_BLL();
        LoaiHang_BLL lhBLL = new LoaiHang_BLL();
        ThuongHieu_BLL thBLL = new ThuongHieu_BLL();
        LoHang_BLL lo_BLL = new LoHang_BLL();
        NhaCC_BLL nccBLL = new NhaCC_BLL();
        public frmSanPham()
        {
            InitializeComponent();
            btnTaoLo.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            string masp;
            masp = "SP"  + date.ToString("ddMMyyyyHHmmss");
            txtMaSP.Text = masp;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnTaoLo.Enabled = true;
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            loadData();
            loadLoaiHang();
            loadThuongHieu();
            loadLoHang();
            loadNCC();
        }
        private void loadLoaiHang()
        {
            cboMaLoai.ValueMember = "MaLoai";
            cboMaLoai.DisplayMember = "TenLoai";
            cboMaLoai.DataSource = lhBLL.GetListLoaiHang();
        }
        private void loadNCC()
        {
            cboNCC.ValueMember = "MaNCC";
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.DataSource = nccBLL.getListNCC();
        }
        private void loadThuongHieu()
        {
            cboThuongHieu.DisplayMember = "TenTH";
            cboThuongHieu.ValueMember = "MaTH";
            cboThuongHieu.DataSource = thBLL.GetListThuongHieu();
        }
        private void loadLoHang()
        {
            cboLo.DisplayMember = "MaLo";
            cboLo.ValueMember = "MaLo";
            cboLo.DataSource = lo_BLL.getListLoHang();
            cboMaLo.DisplayMember = "MaLo";
            cboMaLo.ValueMember = "MaLo";
            cboMaLo.DataSource = lo_BLL.getListLoHang();
        }
        private void loadData()
        {
            if(cboLo.SelectedIndex != -1)
            {
                string malo = cboLo.SelectedValue.ToString();
                dgvSanPham.DataSource = lo_BLL.getLoHang(malo);
            }    
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkTextBox())
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    if (dgvSanPham.RowCount == 1)
                        return;
                    else if (dgvSanPham.CurrentRow != null && dgvSanPham.CurrentRow.Index < dgvSanPham.Rows.Count - 1)
                    {
                        spDTO.MaSP = dgvSanPham.CurrentRow.Cells[0].Value.ToString();
                        spDTO.TenSP = txtTenSP.Text;
                        spDTO.MaLoai = cboMaLoai.SelectedValue.ToString();
                        spDTO.MaTH = cboThuongHieu.SelectedValue.ToString();
                        spDTO.HinhAnh = txtHinhAnh.Text;
                        spDTO.HSD = dtpHSD.Text;
                        spDTO.GiaBan = float.Parse(txtGiaBan.Text);
                        loDTO.MaLo = cboMaLo.SelectedValue.ToString();
                        loDTO.MaSP = txtMaSP.Text;
                        loDTO.MaNCC = cboNCC.SelectedValue.ToString();
                        loDTO.NgayNhap = dtpNgayNhap.Text;
                        loDTO.SoLuong = (int)numSL.Value;
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
                        if (cboLo.SelectedValue.ToString() == cboMaLo.SelectedValue.ToString())
                        {
                            lo_BLL.themLoHang(loDTO);

                        }
                        else
                        {
                            lo_BLL.suaLoHang(loDTO, cboLo.SelectedValue.ToString());
                        }

                        btnThem.Enabled = true;
                        btnLuu.Enabled = false;
                        clearTextBox();
                        loadData();
                    }
                }
                catch
                {
                    return;
                }
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
                    cboThuongHieu.Text = dgvSanPham.CurrentRow.Cells[3].Value.ToString();
                    dtpHSD.Text = dgvSanPham.CurrentRow.Cells[4].Value.ToString();
                    txtHinhAnh.Text = dgvSanPham.CurrentRow.Cells[5].Value.ToString();
                    txtGiaBan.Text = dgvSanPham.CurrentRow.Cells[6].Value.ToString();
                    cboNCC.Text = dgvSanPham.CurrentRow.Cells[7].Value.ToString();
                    numSL.Value = int.Parse(dgvSanPham.CurrentRow.Cells[8].Value.ToString());
                    dtpNgayNhap.Text = dgvSanPham.CurrentRow.Cells[9].Value.ToString();
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
                    string malo = cboLo.SelectedValue.ToString();
                    if (lo_BLL.xoaLoHang(malo, txtMaSP.Text)!=-1 && spBLL.xoaSanPham(txtMaSP.Text) != -1)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK);
                    }
                    loadData();
                    loadLoHang();
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


        private void btnTaoLo_Click(object sender, EventArgs e)
        {
            if (checkTextBox())
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                string malo;
                if (lo_BLL.getLoHangCount() < 10)
                {
                    malo = "L0" + (lo_BLL.getLoHangCount()+1).ToString();
                }
                else
                    malo = "L" + (lo_BLL.getLoHangCount()+1).ToString();
                spDTO.MaSP = txtMaSP.Text;
                spDTO.TenSP = txtTenSP.Text;
                spDTO.MaLoai = cboMaLoai.SelectedValue.ToString();
                spDTO.MaTH = cboThuongHieu.SelectedValue.ToString();
                spDTO.HinhAnh = txtHinhAnh.Text;
                spDTO.HSD = dtpHSD.Text;
                spDTO.GiaBan = float.Parse(txtGiaBan.Text);
                spBLL.themSanPham(spDTO);
                loDTO.MaLo = malo;
                loDTO.MaSP = txtMaSP.Text;
                loDTO.MaNCC = cboNCC.SelectedValue.ToString();
                loDTO.NgayNhap = dtpNgayNhap.Text;
                loDTO.SoLuong = (int)numSL.Value;
                if (lo_BLL.themLoHang(loDTO) != -1)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK);
                }
                clearTextBox();
                loadData();
                loadLoHang();
                btnTaoLo.Enabled = false;
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
            }
        }

        private void cboLo_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
