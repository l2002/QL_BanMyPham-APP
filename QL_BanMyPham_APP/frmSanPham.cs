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
    public partial class frmSanPham : Form
    {
        SanPham spDTO = new SanPham();
        SanPham_BLL spBLL = new SanPham_BLL();
        LoaiHang_BLL lhBLL = new LoaiHang_BLL();
        ThuongHieu_BLL thBLL = new ThuongHieu_BLL();
        public frmSanPham()
        {
            InitializeComponent();
            picSanPham.SizeMode = PictureBoxSizeMode.StretchImage;
            cboMaLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThuongHieu.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public frmSanPham(string masp)
        {
            InitializeComponent();
            picSanPham.SizeMode = PictureBoxSizeMode.StretchImage;
            spDTO = spBLL.getSanPhamTheoMa(masp);
        }
        private bool checkTextBox()
        {
            if (txtTenSP.Text == "" || txtGiaBan.Text == "" || txtHinhAnh.Text == "" || txtMoTa.Text == "")
                return true;
            return false;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (checkTextBox())
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    spDTO.MaSP = txtMaSP.Text;
                    spDTO.TenSP = txtTenSP.Text;
                    spDTO.MaLoai = cboMaLoai.SelectedValue.ToString();
                    spDTO.MaTH = cboThuongHieu.SelectedValue.ToString();
                    spDTO.HinhAnh = txtHinhAnh.Text;
                    spDTO.MoTa = txtMoTa.Text;
                    spDTO.HSD = dtpHSD.Text;
                    spDTO.GiaBan = float.Parse(txtGiaBan.Text);
                    if (spBLL.timSanPham(txtMaSP.Text) == 1)
                    {
                        if (spBLL.suaSanPham(spDTO) != -1)
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (spBLL.themSanPham(spDTO) != -1)
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                catch
                {
                    return;
                }
                this.Close();
            }
        }

        private void picSanPham_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(open.FileName);
                picSanPham.Image = img;
                string imagename = open.SafeFileName;
                txtHinhAnh.Text = imagename;
                open.RestoreDirectory = true;
            }
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

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            
            if(spDTO.MaSP == null)
            {
                DateTime date = DateTime.Now;
                string masp;
                masp = "SP" + date.ToString("ddMMyyyyHHmm");
                txtMaSP.Text = masp;
            }
            else
            {
                loadForm();
            }
            loadData();
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
        private void loadForm()
        {
            txtMaSP.Text = spDTO.MaSP;
            txtTenSP.Text = spDTO.TenSP;
            cboMaLoai.Text = spDTO.MaLoai;
            cboThuongHieu.Text = spDTO.MaTH;
            dtpHSD.Text = spDTO.HSD;
            txtHinhAnh.Text = spDTO.HinhAnh;
            txtGiaBan.Text = spDTO.GiaBan.ToString();
            txtMoTa.Text = spDTO.MoTa;
        }
        private void loadData()
        {
            loadLoaiHang();
            loadThuongHieu();
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn chắc muốn đóng?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(kq == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
