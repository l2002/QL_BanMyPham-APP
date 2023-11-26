using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoanAccess
    {
        DatabaseAccess database=new DatabaseAccess();
        public string ktraTaiKhoan(string taikhoan)
        {
            string sql = "SELECT sTaiKhoan FROM TaiKHoan WHERE sTaiKhoan = N'" + taikhoan + "' ";
            string kq = database.GetFieldValues(sql);
            return kq;
        }
        public string ktraMatKhau(string matkhau)
        {
            string sql = "SELECT sMatKhau FROM TaiKHoan WHERE sMatKhau = N'" + matkhau + "' ";
            string kq = database.GetFieldValues(sql);
            return kq;
        }
        public string getTenNV(string taikhoan)
        {
            string sql = "select NhanVien.TenNV,NhanVien.MaNV from TAIKHOAN,NhanVien where TAIKHOAN.MaNV=NhanVien.MaNV and TAIKHOAN.sTaiKhoan='"+taikhoan+"'";
            string kq = database.GetFieldValues(sql);
            return kq;
        }
        public string getMaNV(string taikhoan)
        {
            string sql = "select NhanVien.MaNV from TAIKHOAN,NhanVien where TAIKHOAN.MaNV=NhanVien.MaNV and TAIKHOAN.sTaiKhoan='" + taikhoan + "'";
            string kq = database.GetFieldValues(sql);
            return kq;
        }
    }
}
