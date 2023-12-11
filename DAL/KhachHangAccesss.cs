using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangAccesss
    {
        DatabaseAccess database = new DatabaseAccess();
        public DataTable getKhachHang()
        {
            KhachHang kh = new KhachHang();
            DataTable dt = database.fillTable("select * from KhachHang");
            dt.Columns[0].ColumnName = "Mã khách hàng";
            dt.Columns[1].ColumnName = "Tên khách hàng";
            dt.Columns[2].ColumnName = "Địa chỉ";
            dt.Columns[3].ColumnName = "Điện thoại";
            dt.Columns[4].ColumnName = "Ngày sinh";
            return dt;
        }
        public int themKhachHang(KhachHang kh)
        {
            string sql = "insert into KhachHang values('" + kh.MaKH + "',N'" + kh.TenKH + "',N'" + kh.DiaChi + "','" + kh.DienThoai + "','" + kh.NgaySinh + "')";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int suaKhachHang(KhachHang kh)
        {
            string sql = "update KhachHang set tenkh=N'" + kh.TenKH + "',diachi=N'" + kh.DiaChi + "',dienthoai='" + kh.DienThoai + "',ngaysinh='" + kh.NgaySinh + "' where makh = '" + kh.MaKH + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int xoaKhachHang(string makh)
        {
            string sql = "delete KhachHang where makh = '" + makh + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
    }
     
}
