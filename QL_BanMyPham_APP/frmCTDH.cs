using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
           
            ctdhDTO.MaDH = txtMaDH.Text;
            ctdhDTO.MaSP = cboMaSP.SelectedValue.ToString();
            ctdhDTO.SoLuongMua = int.Parse(txtSoLuong.Text);
            ctdhDTO.ThanhTien = double.Parse(txtThanhTien.Text);

            if (checkInput()==1)
            {
                if (ctdhBLL.ktraSPDaCo(ctdhDTO) != 0)
                {
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
            int slcon, sl, SoLuongxoa;

            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaHangxoa = dgvDS.CurrentRow.Cells["Mã SP"].Value.ToString();
                SoLuongxoa = int.Parse(dgvDS.CurrentRow.Cells["Số lượng mua"].Value.ToString());
                thanhTienXoa = float.Parse(dgvDS.CurrentRow.Cells["Thành tiền"].Value.ToString());

                ctdhBLL.xoaSP_CTDH(txtMaDH.Text, MaHangxoa);
                MessageBox.Show("Xóa thành công");

                //// Cập nhật lại số lượng cho các mặt hàng
                sl = int.Parse(ctdhBLL.GetFieldValues("select LoHang.SoLuong from SanPham,LoHang where SanPham.MaSP='"+MaHangxoa+"' and SanPham.MaSP=LoHang.MaSP"));
                slcon = sl + SoLuongxoa;
                ctdhBLL.updateSL_SP(slcon, MaHangxoa);
                txtSLCon.Text = slcon.ToString();

                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = double.Parse(ctdhBLL.GetFieldValues("SELECT TONGTIEN FROM DonHang WHERE MaDH = N'" + txtMaDH.Text + "'"));
                tongmoi = tong - thanhTienXoa;
                ctdhBLL.updateTongTien_Xoa(tongmoi, txtMaDH.Text);
                loadTable();

                //LoadDataGridView();

            }


        }

        private void dgvDS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
