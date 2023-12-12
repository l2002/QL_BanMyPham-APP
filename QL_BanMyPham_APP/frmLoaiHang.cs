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
    public partial class frmLoaiHang : Form
    {
        LoaiHang_BLL loaihang = new LoaiHang_BLL();
        LoaiHang lh = new LoaiHang();
        public frmLoaiHang()
        {
            InitializeComponent();
        }
        private bool checkTextBox()
        {
            if (txtTenLH.Text == "")
                return true;
            return false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkTextBox())
                MessageBox.Show("Vui lòng nhập Tên loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                int stt = dgvLoaiHang.RowCount;
                string maloai;
                if (stt < 10)
                {
                    maloai = "LH0" + stt.ToString();
                }
                else
                {
                    maloai = "LH" + stt.ToString();
                }
                lh.MaLoai = maloai;
                lh.TenLoai = txtTenLH.Text;
                if (loaihang.themLoaiHang(lh) != -1)
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
        private void loadTable()
        {
            dgvLoaiHang.DataSource = loaihang.getDataLoaiHang();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkTextBox())
                MessageBox.Show("Vui lòng nhập Tên loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (dgvLoaiHang.RowCount == 1)
                    return;
                else if (dgvLoaiHang.CurrentRow != null && dgvLoaiHang.CurrentRow.Index < dgvLoaiHang.Rows.Count - 1)
                {
                    lh.MaLoai = dgvLoaiHang.CurrentRow.Cells[0].Value.ToString();
                    lh.TenLoai = txtTenLH.Text;
                    if (loaihang.suaLoaiHang(lh) != -1)
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
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có Chắc muốn xóa?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                if (dgvLoaiHang.RowCount == 1)
                    return;
                else if (dgvLoaiHang.CurrentRow != null && dgvLoaiHang.CurrentRow.Index < dgvLoaiHang.Rows.Count - 1)
                {
                    string maloai = dgvLoaiHang.CurrentRow.Cells[0].Value.ToString();
                    if (loaihang.xoaLoaiHang(maloai) != -1)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    loadTable();
                }
            }
        }

        private void dgvLoaiHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLoaiHang.RowCount == 1)
                return;
            else if (dgvLoaiHang.CurrentRow != null && dgvLoaiHang.CurrentRow.Index < dgvLoaiHang.Rows.Count - 1)
            {
                txtTenLH.Text = dgvLoaiHang.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void frmLoaiHang_Load(object sender, EventArgs e)
        {
            loadTable();
        }
    }
}
