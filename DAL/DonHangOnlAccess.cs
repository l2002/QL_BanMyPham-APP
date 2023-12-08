using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DonHangOnlAccess
    {
        DatabaseAccess database = new DatabaseAccess();

        public DataTable getHoaDonOnl()
        {
            DataTable dt = database.fillTable("select * from DonhangOnl");
            dt.Columns[0].ColumnName = "Mã đơn hàng";
            dt.Columns[1].ColumnName = "Ngày đặt";
            dt.Columns[2].ColumnName = "Ngày giao";
            dt.Columns[3].ColumnName = "Trạng thái";
            dt.Columns[4].ColumnName = "Mã người dùng";
            dt.Columns[5].ColumnName = "Tổng tiền";
            return dt;
        }
        public int updateTrangThai(DonHangOnl dh)
        {
            string sql = "update DonHangOnl set Tinhtrang=N'" + dh.TinhTrang + "'where Madon = '" + dh.Madon + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int updateNgayGiao(DonHangOnl dh)
        {
            string sql = "update DonHangOnl set NgayGiao='" + dh.NgayGiao + "' where Madon = '" + dh.Madon + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        
    }
}
