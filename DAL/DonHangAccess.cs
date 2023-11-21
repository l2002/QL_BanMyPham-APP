using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DonHangAccess
    {
        DatabaseAccess database = new DatabaseAccess();

        public DataTable getHoaDonOnl()
        {
            DataTable dt = database.fillTable("select MaDH,MaKH,NgayDat,NgayGiao,TinhTrang,TongTien from DonHang");
            dt.Columns[0].ColumnName = "Mã đơn hàng";
            dt.Columns[1].ColumnName = "Mã khách hàng";
            dt.Columns[2].ColumnName = "Ngày đặt";
            dt.Columns[3].ColumnName = "Ngày giao";
            dt.Columns[4].ColumnName = "Trạng thái";
            dt.Columns[5].ColumnName = "Tổng tiền";
            return dt;
        }
        public DataTable getHoaDon()
        {
            DataTable dt = database.fillTable("select MaDH,MaKH,NgayDat,TongTien from DonHang");
            dt.Columns[0].ColumnName = "Mã đơn hàng";
            dt.Columns[1].ColumnName = "Mã khách hàng";
            dt.Columns[2].ColumnName = "Ngày đặt";
            dt.Columns[3].ColumnName = "Tổng tiền";
            return dt;
        }
        public int themHD(DonHang dh)
        {
            string sql = "INSERT INTO DonHang(MaDH, NgayDat, MaKH, TongTien) VALUES (N'" + dh.MaDH.Trim() + "'," +
                "" + "'" + database.ConvertDateTime(dh.NgayDat.Trim()) + "',N'" + dh.MaKH + "'," + dh.TongTien + ")";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int updateTrangThai(DonHang dh)
        {
            string sql = "update DonHang set TinhTrang=N'" + dh.TinhTrang + "'where MaDH = '" + dh.MaDH + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int updateNgayGiao(DonHang dh)
        {
            string sql = "update DonHang set NgayGiao='" + dh.NgayGiao + "' where MaDH = '" + dh.MaDH + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int xoaDonHang(string madh)
        {
            string sql = "delete DonHang where MaDH = '" + madh + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
    }
}
