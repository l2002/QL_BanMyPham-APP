using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanMyPham_APP
{
    public partial class frmBaoCao : Form
    {
        DonHang_BLL dhBLL = new DonHang_BLL();

        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            try
            {
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                string kq = double.Parse(dhBLL.getTongDoanhThu()).ToString("#,###" + ' ' + "VNĐ", cul.NumberFormat);
                lbl1.Text = dhBLL.getSPBan().ToString();
                lbl2.Text = String.Format("{0:0.00}", kq);
                lbl3.Text = dhBLL.getTongKH().ToString();
            }
            catch
            {
                MessageBox.Show("Chưa có dữ liệu để hiển thị!");
                return;
            }
            fillChart();
        }
        private void fillChart()
        {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-J787359;Initial Catalog=QL_MyPham_DA;Integrated Security=true;");
                DataSet ds = new DataSet();
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT TOP 10 KhachHang.TenKH as Ten, SUM(TongTien) as TongTien FROM DonHang,KhachHang where KhachHang.MaKH=DonHang.MaKH GROUP BY KhachHang.TenKH ORDER BY TongTien DESC", con);
                adapt.Fill(ds);
                chart.DataSource = ds;
                chart.Series["DonHang"].XValueMember = "Ten";
                chart.Series["DonHang"].YValueMembers = "TongTien";
                chart.Titles.Add("TOP 10 KHÁCH HÀNG CÓ TỔNG TIỀN MUA NHIỀU NHẤT");
                con.Close();
        }   
    }
}
