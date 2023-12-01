using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanMyPham_APP
{
    public partial class frmKhuyenMai : Form
    {
        KhuyenMai_BLL km = new KhuyenMai_BLL();
        SanPham_BLL sp = new SanPham_BLL();
        public frmKhuyenMai()
        {
            InitializeComponent();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            loadDataSP();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(!checkEmpty())
            {
                int giatrikm = (int)numKM.Value;
                string makm = "KM" + giatrikm;
                KhuyenMai khuyenMai = new KhuyenMai();
                khuyenMai.MaKM = makm;
                khuyenMai.TenKM = giatrikm;
                if (km.themKhuyenMai(khuyenMai) == -1) 
                {
                    MessageBox.Show("Đã có chương trình khuyến mãi này");
                }
                else
                {
                    MessageBox.Show("Thêm thành công");
                }
                loadKM();
            }   
        }
        private bool checkEmpty()
        {
            if(numKM.Value == 0)
            {
                return true;
            }    
            return false;
        }
        private void btSua_Click(object sender, EventArgs e)
        {
            if (!checkEmpty())
            {
                int giatrikm = (int)numKM.Value;
                string makm = "KM" + giatrikm;
                string makmsua = cboKhuyenMai.SelectedValue.ToString();
                KhuyenMai khuyenMai = new KhuyenMai();
                khuyenMai.MaKM = makm;
                khuyenMai.TenKM = giatrikm;
                km.themKhuyenMai(khuyenMai);
                sp.suaKM(makm, makmsua);
                km.xoaKhuyenMai(makmsua);
                loadKM();
            }
        }

        private void cboKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDataKM();
        }
        private void loadDataKM()
        {
            if (cboKhuyenMai.SelectedIndex != -1)
            {
                string makm = cboKhuyenMai.SelectedValue.ToString();
                dgvKM.DataSource = km.getKhuyenMaiTheoMa(makm);
            }
        }
        private void loadKM()
        {
            cboKhuyenMai.DisplayMember = "TenKM";
            cboKhuyenMai.ValueMember = "MaKM";
            cboKhuyenMai.DataSource = km.getListKhuyenMai();
        }

        private void frmKhuyenMai_Load(object sender, EventArgs e)
        {
            loadKM();
            loadDataSP();
        }
        private void loadDataSP()
        {
            dgvSanPham.DataSource = sp.getSanPham();
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSanPham.RowCount == 1)
                return;
            else if (dgvSanPham.CurrentRow != null && dgvSanPham.CurrentRow.Index < dgvSanPham.Rows.Count - 1)
            {
                string masp = dgvSanPham.CurrentRow.Cells[0].Value.ToString();
                string makm = cboKhuyenMai.SelectedValue.ToString();
                sp.updateKM(masp, makm);
                loadDataKM();
                loadDataSP();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            float giaban = 0;
            string tensp = txtTenSanPham.Text;
            if(txtGiaBan.Text != "")
                giaban = float.Parse(txtGiaBan.Text);
            bool chuakm = chbChuaKM.Checked;
            if (chbTenSP.Checked && !chbGiaBan.Checked)
            {
                dgvSanPham.DataSource = sp.timSP_NhieuGiaTri(tensp, 0, chuakm);
            }
            else if (!chbTenSP.Checked && chbGiaBan.Checked)
            {
                dgvSanPham.DataSource = sp.timSP_NhieuGiaTri(null, giaban, chuakm);
            }
            else if (!chbTenSP.Checked && !chbGiaBan.Checked)
            {
                dgvSanPham.DataSource = sp.timSP_NhieuGiaTri(null, 0, chuakm);
            }
            else
            {
                dgvSanPham.DataSource = sp.timSP_NhieuGiaTri(tensp, giaban, chuakm);
            } 
                
        }

        private void txtGaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dgvKM_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSanPham.RowCount == 1)
                return;
            else if (dgvSanPham.CurrentRow != null && dgvSanPham.CurrentRow.Index < dgvSanPham.Rows.Count - 1)
            {
                DialogResult = MessageBox.Show("Bạn có chắc muốn xóa giá trị khuyến mãi của sản phẩm này?","Thông báo",MessageBoxButtons.YesNo);
                if(DialogResult == DialogResult.Yes)
                {
                    string masp = dgvKM.CurrentRow.Cells[1].Value.ToString();
                    sp.xoakm(masp);
                    loadDataKM();
                    loadDataSP();
                }
            }
        }
    }
}
