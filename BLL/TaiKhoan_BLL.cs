using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TaiKhoan_BLL
    {
        DatabaseAccess databaseAccess = new DatabaseAccess();
        TaiKhoanAccess access = new TaiKhoanAccess();
        public string ktraTaiKhoan(string taikhoan)
        {
            return access.ktraTaiKhoan(taikhoan);
        }
        public string ktraMatKhau(string matkhau)
        {
            return access.ktraMatKhau(matkhau);
        }
        public string getTenNV(string tennv)
        {
            return access.getTenNV(tennv);
        }
        public string getMaNV(string manv)
        {
            return access.getMaNV(manv);
        }
    }
}
