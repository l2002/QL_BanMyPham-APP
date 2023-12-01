using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoanAccess
    {
        DatabaseAccess database=new DatabaseAccess();

        private void datTenTable(DataTable dt)
        {

            dt.Columns[0].ColumnName = "Mã Tài khoản";
            dt.Columns[1].ColumnName = "Tên Tài khoản";
            dt.Columns[2].ColumnName = "Mật Khẩu";
            dt.Columns[3].ColumnName = "Email";
            dt.Columns[4].ColumnName = "Quyền";
            dt.Columns[5].ColumnName = "Mã NV";
        }
        public DataTable getTaiKhoan()
        {
            DataTable dt = database.fillTable("select * from TaiKhoan");
            datTenTable(dt);
            return dt;
        }

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
        public int setIndentity()
        {
            string sql;
            int kq;
            sql = "set IDENTITY_INSERT TAIKHOAN ON";
            kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int themTaiKhoan(TaiKhoan tk)
        {
            string sql;
            int kq;
            sql = "insert into TAIKHOAN(sMaTK,sTaiKhoan,sMatKhau,Email,iMaQuyen,MaNV) values('" + tk.MaTK + "',N'" + tk.TenTK + "','" + tk.MatKhau + "','" + tk.Email + "','" + tk.MaQuyen + "','" + tk.MaNV + "')";
            kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int suaTK(TaiKhoan tk)
        {
            string sql = "update TAIKHOAN set sTaiKhoan=N'" + tk.TenTK + "',sMatKhau=N'" + tk.MatKhau + "',Email=N'" + tk.Email + "',iMaQuyen='" + tk.MaQuyen + "' where sMaTK = '" + tk.MaTK + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int xoaTK(string maTK)
        {
            string sql = "delete TAIKHOAN where sMaTK = '" + maTK + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
    }
}
