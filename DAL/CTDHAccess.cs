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
            dt.Columns[3].ColumnName = "Số lượng";
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
    }
}
