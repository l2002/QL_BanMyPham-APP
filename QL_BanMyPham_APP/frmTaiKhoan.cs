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
    public partial class frmTaiKhoan : Form
    {
        TaiKhoan_BLL tkBLL=new TaiKhoan_BLL();
        TaiKhoan tkDTO=new TaiKhoan();

        public frmTaiKhoan()
        {
            InitializeComponent();
        }
        public void loadTable()
        {
            dgvDS.DataSource = tkBLL.getTaiKhoan();
        }
        public void loadCombobox()
        {
            tkBLL.FillCombo("SELECT MaNV, TenNV FROM NhanVien", cboTenNV, "MaNV", "TenNV");
            cboTenNV.SelectedIndex = -1;

            tkBLL.FillCombo("SELECT iMaQuyen, sTenQuyen FROM QUYEN", cboQuyen, "iMaQuyen", "sTenQuyen");
            cboTenNV.SelectedIndex = -1;
        }
        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            loadCombobox();
            loadTable();
        }
        public bool checkTextbox()
        {
            if (txtTenTK.Text == "" || txtMatKhau.Text == "" || txtEmal.Text == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!");
                return true;
            }
            else if(cboTenNV.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn tên Nhân viên!");
                return true;
            }
            else if (cboQuyen.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn Quyền!");
                return true;
            }
            return false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkTextbox())
            {
                return;
            }
            int stt = dgvDS.RowCount;
            string maTK;
            try
            {
                if (stt < 10)
                {
                    maTK = "TK" + "0" + stt.ToString();
                }
                else
                {
                    maTK = "TK" + stt.ToString();
                }

                tkDTO.MaTK = maTK;
                tkDTO.TenTK = txtTenTK.Text;
                tkDTO.MatKhau = txtMatKhau.Text;
                tkDTO.Email = txtEmal.Text;
                tkDTO.MaQuyen = cboQuyen.SelectedValue.ToString();
                tkDTO.MaNV = cboTenNV.SelectedValue.ToString();


                if (tkBLL.themTaiKhoan(tkDTO) != -1)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("Mã Tài khoản trùng!");
            }
           
            loadTable();
        }

        private void dgvDS_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaTK.Text = dgvDS.CurrentRow.Cells[0].Value.ToString();
                cboTenNV.SelectedValue = dgvDS.CurrentRow.Cells[5].Value.ToString();
                txtTenTK.Text = dgvDS.CurrentRow.Cells[1].Value.ToString();
                txtMatKhau.Text = dgvDS.CurrentRow.Cells[2].Value.ToString();
                txtEmal.Text = dgvDS.CurrentRow.Cells[3].Value.ToString();
                cboQuyen.SelectedValue = dgvDS.CurrentRow.Cells[4].Value.ToString();
            }
            catch
            {
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaTK.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tkDTO.MaTK = txtMaTK.Text;
                tkDTO.TenTK = txtTenTK.Text;
                tkDTO.MatKhau = txtMatKhau.Text;
                tkDTO.Email = txtEmal.Text;
                tkDTO.MaQuyen = cboQuyen.SelectedValue.ToString();

                if (tkBLL.suaTK(tkDTO) != -1)
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
            if (txtMaTK.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var n = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (n == DialogResult.Yes)
                {
                    string maTK = txtMaTK.Text;
                    if (tkBLL.xoaTK(maTK) != -1)
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
