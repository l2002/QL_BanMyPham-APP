using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CTDHAccess
    {
        DatabaseAccess database = new DatabaseAccess();
        public DataTable getCTDH(CTDonHang ctdh)
        {
            DataTable dt = database.fillTable("select * from LOAD_CTHD_FUNC ('" + ctdh.MaDH + "')");
            dt.Columns[0].ColumnName = "Mã đơn hàng";
            dt.Columns[1].ColumnName = "Mã SP";
            dt.Columns[2].ColumnName = "Tên SP";
            dt.Columns[3].ColumnName = "Số lượng mua";
            dt.Columns[4].ColumnName = "Hạn sử dụng";
            dt.Columns[5].ColumnName = "Giá bán";
            dt.Columns[6].ColumnName = "Khuyến mãi";
            dt.Columns[7].ColumnName = "Thành tiền";
            return dt;
        }
        public int themCTHD(CTDonHang ctdh)
        {
            string sql = "INSERT INTO CTDonHang(MaDH, MaSP, SoLuongMua, DonGia, ThanhTien) VALUES (N'" + ctdh.MaDH.Trim() + "'," +
                "N'" + ctdh.MaSP + "'," + ctdh.SoLuongMua + "," + ctdh.DonGia + "," + ctdh.ThanhTien + ")";

            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int ktSPDaCo(CTDonHang ctdh)
        {
            string sql = "SELECT MaSP FROM CTDonHang WHERE MaSP=N'" + ctdh.MaSP + "' AND MaDH = N'" + ctdh.MaDH + "'";
            if (database.CheckKey(sql))
            {
                return 0;
            }
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int xoaCTDH(string madh)
        {
            string sql = "delete from CTDonHang where MaDH = '" + madh + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int xoaSP_CTDH(string madh,string maSPXoa)
        {
            string sql = "exec Delete_CTHDBAN_Func '" + madh + "' , N'" + maSPXoa + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int updateSL_SP(int slcon, string maSPXoa)
        {
            string sql = "UPDATE LoHang SET SoLuong =" + slcon + " WHERE MaSP= N'" + maSPXoa + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int getSLTon(string maSP)
        {
            string sql = "select LoHang.SoLuong from SanPham,LoHang where SanPham.MaSP='"+maSP+"' and SanPham.MaSP=LoHang.MaSP";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int updateTongtien_Xoa(double tongmoi,string maSP)
        {
            string sql = "UPDATE DonHang SET TONGTIEN ='" + tongmoi +"' WHERE MaDH = N'" + maSP + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }

    }
}
