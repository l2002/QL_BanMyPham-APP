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

       
        public DataTable getHoaDon()
        {
            DataTable dt = database.fillTable("select MaDH,MaKH,NgayDat,TongTien from DonHang");
            dt.Columns[0].ColumnName = "Mã đơn hàng";
            dt.Columns[1].ColumnName = "Mã khách hàng";
            dt.Columns[2].ColumnName = "Ngày mua";
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
       
        public string getTongTien(string madh)
        {
            string sql = "SELECT TONGTIEN FROM DonHang WHERE MaDH = '"+madh+"'";
            string kq = database.GetFieldValues(sql);
            return kq;
        }
        public int xoaDH(string madh)
        {
            string sql = "delete \r\nFROM DonHang\r\nWHERE EXISTS \r\n(SELECT *\r\nFROM CTDonHang\r\nWHERE CTDonHang.MaDH = DonHang.MaDH\r\nAND DonHang.MaDH = '"+madh+"');";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
    }
}
