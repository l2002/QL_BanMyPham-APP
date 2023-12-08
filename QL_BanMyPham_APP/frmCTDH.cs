using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanMyPham_APP
{
    public partial class frmCTDH : Form
    {

        CTDonHang ctdhDTO = new CTDonHang();
        CTDH_BLL ctdhBLL = new CTDH_BLL();
        SanPham_BLL spBLL = new SanPham_BLL();
        LoHang_BLL lhBLL= new LoHang_BLL();

        DonHang dhDTO = new DonHang();
        DonHang_BLL dhBLL = new DonHang_BLL();

        private string _maDH;
        public frmCTDH(string maDH) : this()
        {
            _maDH = maDH;
            txtMaDH.Text = _maDH;
        }
        public frmCTDH()
        {
            InitializeComponent();
            dgvDS.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void loadCombo()
        {
            spBLL.FillCombo("SELECT MaSP,TenSP FROM SanPham", cboMaSP, "MaSP", "TenSP");
            cboMaSP.SelectedIndex = -1;
        }

        private void loadTable()
        {
            dgvDS.DataSource = ctdhBLL.getCTDH(ctdhDTO);
            txtTongTien.Text = dhBLL.getTongTien(txtMaDH.Text).ToString();

            txtSoLuong.Text = "0";
            txtGiaBan.Text = "0";
            txtThanhTien.Text = "0";
        }
        private void frmCTDH_Load(object sender, EventArgs e)
        {
            loadCombo();
            this.CenterToScreen();
            loadTable();

        }

        private void cboMaSP_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaSP.Text == "")
            {
                txtMaSP.Text = "";
            }
            str = "SELECT MaSP FROM SanPham WHERE MaSP = N'" + cboMaSP.SelectedValue + "'";
            txtMaSP.Text = spBLL.GetFieldValues(str);
            str = "SELECT HSD FROM SanPham WHERE MaSP = N'" + cboMaSP.SelectedValue + "'";
            txtHSD.Text = spBLL.GetFieldValues(str);
            str = "SELECT GiaBan FROM SanPham WHERE MaSP = N'" + cboMaSP.SelectedValue + "'";
            txtGiaBan.Text = spBLL.GetFieldValues(str);
            str = "select KhuyenMai.TenKM from SanPham,KhuyenMai WHERE MaSP = N'" + cboMaSP.SelectedValue + "' and SanPham.MaKM=KhuyenMai.MaKM";
            txtKhuyenMai.Text = spBLL.GetFieldValues(str);

            str = "select LoHang.SoLuong from SanPham,LoHang where SanPham.MaSP='" + cboMaSP.SelectedValue + "' and SanPham.MaSP=LoHang.MaSP\r\n";
            txtSLCon.Text = ctdhBLL.GetFieldValues(str);     
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, km;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = double.Parse(txtSoLuong.Text);
            if (txtKhuyenMai.Text == "")
                km = 0;
            else
                km = double.Parse(txtKhuyenMai.Text);
            if (txtGiaBan.Text == "")
                dg = 0;
            else
                dg = double.Parse(txtGiaBan.Text);
            tt = sl * dg - sl * dg * km / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public int checkInput()
        {
            if (txtSoLuong.Text == "" || txtSoLuong.Text=="0")
            {
                MessageBox.Show("Vui lòng nhập số lượng!");
                return 0;
            }
            if (cboMaSP.SelectedValue == null)
            {
                MessageBox.Show("Vui chọn sản phẩm!");
                return 0;
            }
            return 1;
        }
        public void resetValue()
        {
            txtMaSP.Text = "";
            txtSoLuong.Text = "0";
            txtGiaBan.Text = "0";
            txtThanhTien.Text = "0";
            txtHSD.Text = "";
        }
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Vui lòng chọn Mã Sản phẩm!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            ctdhDTO.MaDH = txtMaDH.Text;
            ctdhDTO.MaSP = cboMaSP.SelectedValue.ToString();
            ctdhDTO.SoLuongMua = int.Parse(txtSoLuong.Text);
            ctdhDTO.ThanhTien = double.Parse(txtThanhTien.Text);

            if (checkInput()==1)
            {
                if (ctdhBLL.ktraSPDaCo(ctdhDTO) != 0)
                {
                    if (ctdhDTO.SoLuongMua > int.Parse(txtSLCon.Text))
                    {
                        MessageBox.Show("Số lượng mua vượt quá Số lượng tồn", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    if (ctdhBLL.themCTHD(ctdhDTO) != -1)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK);
                    }
                    loadTable();
                    resetValue();
                }
                else
                {
                    MessageBox.Show("Sản phẩm này đã có!");
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvDS_DoubleClick(object sender, EventArgs e)
        {
            string MaHangxoa, sql;
            double thanhTienXoa, tong, tongmoi;

            if (txtMaSP.Text=="")
            {
                MessageBox.Show("Vui lòng chọn Sản phẩm cần xóa!");
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaHangxoa = dgvDS.CurrentRow.Cells["Mã SP"].Value.ToString();
                thanhTienXoa = float.Parse(dgvDS.CurrentRow.Cells["Thành tiền"].Value.ToString());

                ctdhBLL.xoaSP_CTDH(txtMaDH.Text, MaHangxoa);
                MessageBox.Show("Xóa thành công");

                //// Cập nhật lại số lượng cho các mặt hàng(TRIGGER)
                string str;
                str = "select LoHang.SoLuong from SanPham,LoHang where SanPham.MaSP='" + cboMaSP.SelectedValue + "' and SanPham.MaSP=LoHang.MaSP\r\n";
                txtSLCon.Text = ctdhBLL.GetFieldValues(str);

                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = double.Parse(ctdhBLL.GetFieldValues("SELECT TONGTIEN FROM DonHang WHERE MaDH = N'" + txtMaDH.Text + "'"));
                tongmoi = tong - thanhTienXoa;
                ctdhBLL.updateTongTien_Xoa(tongmoi, txtMaDH.Text);
                loadTable();

                //LoadDataGridView();

            }


        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {

        }

        private void dgvDS_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cboMaSP.SelectedValue= dgvDS.CurrentRow.Cells[1].Value.ToString();
                txtMaSP.Text = dgvDS.CurrentRow.Cells[2].Value.ToString();
                txtSoLuong.Text = dgvDS.CurrentRow.Cells[3].Value.ToString();
                txtHSD.Text = dgvDS.CurrentRow.Cells[4].Value.ToString();
                txtGiaBan.Text = dgvDS.CurrentRow.Cells[5].Value.ToString();
                txtKhuyenMai.Text = dgvDS.CurrentRow.Cells[6].Value.ToString();
                txtThanhTien.Text = dgvDS.CurrentRow.Cells[7].Value.ToString();

                string str = "select LoHang.SoLuong from SanPham,LoHang where SanPham.MaSP='" + cboMaSP.SelectedValue + "' and SanPham.MaSP=LoHang.MaSP\r\n";
                txtSLCon.Text = ctdhBLL.GetFieldValues(str);
            }
            catch
            {
                return;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmHDReport frm=new frmHDReport();
            frm.Show();


        }
    }
}
