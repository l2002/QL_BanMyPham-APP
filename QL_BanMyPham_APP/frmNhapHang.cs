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
using System.Windows.Controls;
using System.Windows.Forms;

namespace QL_BanMyPham_APP
{
    public partial class frmNhapHang : Form
    {
        SanPham spDTO = new SanPham();
        LoHang loDTO = new LoHang();
        SanPham_BLL spBLL = new SanPham_BLL();
        LoaiHang_BLL lhBLL = new LoaiHang_BLL();
        ThuongHieu_BLL thBLL = new ThuongHieu_BLL();
        LoHang_BLL lo_BLL = new LoHang_BLL();
        NhaCC_BLL nccBLL = new NhaCC_BLL();
        public frmNhapHang()
        {
            InitializeComponent();
            cboLo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaLo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSanPham.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNCC.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmSanPham frmsp = new frmSanPham();
            frmsp.Show();

        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            loadSanPham();
            loadData();
            loadLoHang();
            loadNCC();
        }
        private void loadNCC()
        {
            cboNCC.ValueMember = "MaNCC";
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.DataSource = nccBLL.getListNCC();
        }
        private void loadSanPham()
        {
            cboSanPham.DisplayMember = "TenSP";
            cboSanPham.ValueMember = "MaSP";
            cboSanPham.DataSource = spBLL.getListSanPham();
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
                dgvSanPham.AutoResizeColumns();
                dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }    
        }


        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvSanPham.RowCount == 1)
                    return;
                else if (dgvSanPham.CurrentRow != null && dgvSanPham.CurrentRow.Index < dgvSanPham.Rows.Count - 1)
                {
                    cboNCC.Text = dgvSanPham.CurrentRow.Cells[8].Value.ToString();
                    cboSanPham.Text = dgvSanPham.CurrentRow.Cells[1].Value.ToString();
                    numSL.Value = int.Parse(dgvSanPham.CurrentRow.Cells[9].Value.ToString());
                    dtpNgayNhap.Text = dgvSanPham.CurrentRow.Cells[10].Value.ToString();
                }
            }
            catch
            {
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.RowCount == 1)
                return;
            else if (dgvSanPham.CurrentRow != null && dgvSanPham.CurrentRow.Index < dgvSanPham.Rows.Count - 1)
            {
                string masp = dgvSanPham.CurrentRow.Cells[0].Value.ToString();
                if (masp == "")
                {
                    MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var n = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (n == DialogResult.Yes)
                    {
                        string malo = cboLo.SelectedValue.ToString();
                        if (lo_BLL.xoaLoHang(malo, masp) != -1 && spBLL.xoaSanPham(masp) != -1)
                        {
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        loadData();
                        loadLoHang();
                    }
                }
            }
        }
        private void btnTaoLo_Click(object sender, EventArgs e)
        {
            string malo;
            if (lo_BLL.getLoHangCount() < 10)
            {
                malo = "L0" + (lo_BLL.getLoHangCount() + 1).ToString();
            }
            else
                malo = "L" + (lo_BLL.getLoHangCount() + 1).ToString();
            loDTO.MaLo = malo;
            loDTO.MaSP = cboSanPham.SelectedValue.ToString();
            loDTO.MaNCC = cboNCC.SelectedValue.ToString();
            loDTO.NgayNhap = dtpNgayNhap.Text;
            loDTO.SoLuong = (int)numSL.Value;
            if (lo_BLL.getMaLoBangMaSP(cboSanPham.SelectedValue.ToString()) == "")
            {
                if (lo_BLL.themLoHang(loDTO) != -1)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Đã có sản phẩm này trong lô khác bạn có muốn chuyển sản phẩm đến lô này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    
                    if (lo_BLL.themLoHang(loDTO) != -1 && lo_BLL.xoaLoHang(lo_BLL.getMaLoBangMaSP(cboSanPham.SelectedValue.ToString()),cboSanPham.SelectedValue.ToString()) != -1)
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            
            loadData();
            loadLoHang();
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
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmSanPham frmsp = new frmSanPham(cboSanPham.SelectedValue.ToString());
            frmsp.Show();
            
        }

        private void btnThemLo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSanPham.RowCount == 1)
                    return;
                else if (dgvSanPham.CurrentRow != null && dgvSanPham.CurrentRow.Index < dgvSanPham.Rows.Count - 1)
                {
                    string malo = lo_BLL.getMaLoBangMaSP(cboSanPham.SelectedValue.ToString());
                    loDTO.MaLo = cboMaLo.SelectedValue.ToString();
                    loDTO.MaSP = cboSanPham.SelectedValue.ToString();
                    loDTO.MaNCC = cboNCC.SelectedValue.ToString();
                    loDTO.NgayNhap = dtpNgayNhap.Text;
                    loDTO.SoLuong = (int)numSL.Value;
                    if (malo == "")
                    {
                        if (lo_BLL.themLoHang(loDTO) != -1)
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Đã có sản phẩm này trong lô khác bạn có muốn chuyển sản phẩm đến lô này không?","Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                        if(result == DialogResult.Yes)
                        {
                            if (lo_BLL.suaLoHang(loDTO, malo) != -1)
                            {
                                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }    
                    }
                    loadData();
                }
            }
            catch
            {
                return;
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            loadSanPham();
        }
    }
}
