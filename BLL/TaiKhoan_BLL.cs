using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public DataTable getTaiKhoan()
        {
            return access.getTaiKhoan();
        }
        public string GetFieldValues(string str)
        {
            return databaseAccess.GetFieldValues(str);
        }
        public void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            databaseAccess.FillCombo(sql, cbo, ma, ten);
        }
        public int themTaiKhoan(TaiKhoan tk)
        {
            return access.themTaiKhoan(tk);
        }
        public int setIndentity()
        {
            return access.setIndentity();
        }
        public int suaTK(TaiKhoan tk)
        {
            return access.suaTK(tk);
        }
        public int xoaTK(string maTK)
        {
            return access.xoaTK(maTK);
        }
    }
}
