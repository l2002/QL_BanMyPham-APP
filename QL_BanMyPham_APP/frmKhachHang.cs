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
    public partial class frmKhachHang : Form
    {
        KhachHang khDTO = new KhachHang();
        KhachHang_BLL khBLL = new KhachHang_BLL();
        public frmKhachHang()
        {
            InitializeComponent();
            txtMaKH.Enabled = false;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            loadTable();
        }
        private void loadTable()
        {
            dgvKhachHang.DataSource = khBLL.getKhachHang();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkTextBox())
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                int stt = dgvKhachHang.RowCount;
                string makh;
                if (stt < 10)
                {
                    makh = "KH" + "0" + stt.ToString();
                }
                else
                {
                    makh = "KH" + stt.ToString();
                }
                khDTO.MaKH = makh;
                khDTO.TenKH = txtTenKH.Text;
                khDTO.DiaChi = txtDiaChi.Text;
                khDTO.DienThoai = txtDienThoai.Text;
                khDTO.NgaySinh = dtpNgaySinh.Value;
                if (khBLL.themKhachHang(khDTO) != -1)
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
            if (txtTenKH.Text == "" || txtDiaChi.Text == "" || txtDienThoai.Text == "")
                return true;
            return false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                khDTO.MaKH = txtMaKH.Text;
                khDTO.TenKH = txtTenKH.Text;
                khDTO.DiaChi = txtDiaChi.Text;
                khDTO.DienThoai = txtDienThoai.Text;
                khDTO.NgaySinh = dtpNgaySinh.Value;
                if (khBLL.suaKhachHang(khDTO) != -1)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                    txtMaKH.Clear();
                    txtTenKH.Clear();
                    txtDienThoai.Clear();
                    txtDiaChi.Clear();
                    dtpNgaySinh.Value = DateTime.Now;
                    txtTenKH.Focus();
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
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var n = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (n == DialogResult.Yes)
                {
                    if (khBLL.xoaKhachHang(txtMaKH.Text) != -1)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                        txtMaKH.Clear();
                        txtTenKH.Clear();
                        txtDienThoai.Clear();
                        txtDiaChi.Clear();
                        dtpNgaySinh.Value = DateTime.Now;
                        txtTenKH.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK);
                    }
                    loadTable();
                }
            }
        }

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhachHang.RowCount == 1)
                return;
            else if (dgvKhachHang.CurrentRow != null && dgvKhachHang.CurrentRow.Index < dgvKhachHang.Rows.Count - 1)
            {
                txtMaKH.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
                txtTenKH.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
                txtDienThoai.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
                dtpNgaySinh.Text = dgvKhachHang.CurrentRow.Cells[4].Value.ToString();
            }
            dgvKhachHang.ReadOnly = true;
        }
    }
}
