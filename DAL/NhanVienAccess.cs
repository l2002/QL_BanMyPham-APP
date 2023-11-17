using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
    public class NhanVienAccess
    {
        DatabaseAccess database = new DatabaseAccess();
        public DataTable getNhanVien()
        {
            NhanVien nv=new NhanVien();
            DataTable dt = database.fillTable("select * from NhanVien");
            dt.Columns[0].ColumnName = "Mã nhân viên";
            dt.Columns[1].ColumnName = "Tên nhân viên";
            dt.Columns[2].ColumnName = "Giới tính";
            dt.Columns[3].ColumnName = "Địa chỉ";
            dt.Columns[4].ColumnName = "Điện thoại";
            dt.Columns[5].ColumnName = "Ngày sinh";
            return dt;
        }
        public int themNhanVien(NhanVien nv)
        {
            string sql = "insert into NhanVien values('" + nv.MaNV + "',N'" + nv.TenNV + "',N'" + nv.GioiTinh + "',N'" + nv.DiaChi + "','" + nv.DienThoai + "','" + nv.NgaySinh + "')";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int suaNhanVien(NhanVien nv)
        {
            string sql = "update NhanVien set tennv=N'" + nv.TenNV + "',gioitinh=N'" + nv.GioiTinh + "',diachi=N'" + nv.DiaChi + "',dienthoai='" + nv.DienThoai + "',ngaysinh='" + nv.NgaySinh + "' where manv = '"+nv.MaNV+"'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int xoaNhanVien(string manv)
        {
            string sql = "delete NhanVien where manv = '" + manv + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
    }
}
