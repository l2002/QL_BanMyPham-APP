using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatHangAccess
    {
        DatabaseAccess database = new DatabaseAccess();

        public DataTable getHoaDonOnl()
        {
            DataTable dt = database.fillTable("select * from DatHang");
            dt.Columns[0].ColumnName = "Mã đơn hàng";
            dt.Columns[1].ColumnName = "Mã khách hàng";
            dt.Columns[2].ColumnName = "Ngày đặt";
            dt.Columns[3].ColumnName = "Ngày giao";
            dt.Columns[4].ColumnName = "Trạng thái";
            dt.Columns[5].ColumnName = "Tổng tiền";
            return dt;
        }
        public int updateTrangThai(DatHang dh)
        {
            string sql = "update DatHang set TrangThai=N'" + dh.TinhTrang + "'where MaDH = '" + dh.MaDH + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int updateNgayGiao(DatHang dh)
        {
            string sql = "update DatHang set NgayGiao='" + dh.NgayGiao + "' where MaDH = '" + dh.MaDH + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int xoaDatHang(string madh)
        {
            string sql = "delete DatHang where MaDH = '" + madh + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
    }
}
