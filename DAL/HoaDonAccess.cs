using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDonAccess
    {
        DatabaseAccess database = new DatabaseAccess();
        public DataTable getHoaDon()
        {
            NhanVien nv = new NhanVien();
            DataTable dt = database.fillTable("select MaDH,MaKH,NgayDat,TinhTrang,TongTien  from DonHang");
            dt.Columns[0].ColumnName = "Mã đơn hàng";
            dt.Columns[1].ColumnName = "Mã khác hàng";
            dt.Columns[2].ColumnName = "Ngày đặt";
            dt.Columns[3].ColumnName = "Tình trạng";
            dt.Columns[4].ColumnName = "Tổng tiền";
            return dt;
        }
    }
}
