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
    public partial class frmThuongHieu : Form
    {
        ThuongHieu thDTO = new ThuongHieu();
        ThuongHieu_BLL thBLL = new ThuongHieu_BLL();
        NhaCC nccDTO = new NhaCC();
        NhaCC_BLL nccBLL = new NhaCC_BLL();
        public frmThuongHieu()
        {
            InitializeComponent();
            txtMaTH.Enabled = false;
            txtMaNCC.Enabled = false;
        }
        private void frmThuongHieu_Load(object sender, EventArgs e)
        {
            loadTable();
        }
        private void loadTable()
        {
            dgvThuongHieu.DataSource = thBLL.GetListThuongHieu();
            dgvNCC.DataSource = nccBLL.getListNCC();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkTextBox())
                MessageBox.Show("Vui lòng nhập tên thương hiệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                int stt = dgvThuongHieu.RowCount;
                string math;
                if (stt < 10)
                {
                    math = "TH" + "0" + stt.ToString();
                }
                else
                {
                    math = "TH" + stt.ToString();
                }
                thDTO.MaTH = math;
                thDTO.TenTH = txtTenTH.Text;
                if (thBLL.themThuongHieu(thDTO) != -1)
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
            if (txtTenTH.Text == "" )
                return true;
            return false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaTH.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                thDTO.MaTH = txtMaTH.Text;
                thDTO.TenTH = txtTenTH.Text;
                if (thBLL.suaThuongHieu(thDTO) != -1)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                    txtMaTH.Clear();
                    txtTenTH.Clear();
                    txtTenTH.Focus();
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
            if (txtMaTH.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var n = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (n == DialogResult.Yes)
                {
                    if (thBLL.xoaThuongHieu(txtMaTH.Text) != -1)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                        txtMaTH.Clear();
                        txtTenTH.Clear();
                        txtTenTH.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK);
                    }
                    loadTable();
                }
            }
        }

        private void dgvThuongHieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThuongHieu.SelectedRows.Count > 0)
            {
                txtMaTH.Text = dgvThuongHieu.SelectedRows[0].Cells[0].Value.ToString();
                txtTenTH.Text = dgvThuongHieu.SelectedRows[0].Cells[1].Value.ToString();
                
            }
            dgvThuongHieu.ReadOnly = true;
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            if (checkTextBox1())
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                int stt = dgvNCC.RowCount;
                string mancc;
                if (stt < 10)
                {
                    mancc = "NCC" + "0" + stt.ToString();
                }
                else
                {
                    mancc = "NCC" + stt.ToString();
                }
                nccDTO.MaNCC = mancc;
                nccDTO.TenNCC = txtTenNCC.Text;
                if (nccBLL.themNhaCC(nccDTO) != -1)
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
        private bool checkTextBox1()
        {
            if (txtTenNCC.Text == "")
                return true;
            return false;
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                nccDTO.MaNCC = txtMaNCC.Text;
                nccDTO.TenNCC = txtTenNCC.Text;
                if (nccBLL.suaNhaCC(nccDTO) != -1)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                    txtMaNCC.Clear();
                    txtTenNCC.Clear();
                    txtTenNCC.Focus();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK);
                }
                loadTable();
            }
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var n = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (n == DialogResult.Yes)
                {
                    if (nccBLL.xoaNhaCC(txtMaNCC.Text) != -1)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                        txtMaNCC.Clear();
                        txtTenNCC.Clear();
                        txtTenNCC.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK);
                    }
                    loadTable();
                }
            }
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNCC.SelectedRows.Count > 0)
            {
                txtMaNCC.Text = dgvNCC.SelectedRows[0].Cells[0].Value.ToString();
                txtTenNCC.Text = dgvNCC.SelectedRows[0].Cells[1].Value.ToString();

            }
            dgvNCC.ReadOnly = true;
        }
    }
}
