using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoHang_BLL
    {
        DatabaseAccess dbAccess = new DatabaseAccess();
        LoHangAccess lohang = new LoHangAccess();
        public string GetFieldtalues(string str)
        {
            return dbAccess.GetFieldValues(str);
        }
        public List<LoHang> getListLoHang()
        {
            return lohang.getListLoHang();
        }
        public DataTable getLoHang(string malo)
        {
            return lohang.getLoHang(malo);
        }
        public int getLoHangCount()
        {
            return lohang.demLoHang();
        }
        public int themLoHang(LoHang lo)
        {
            return lohang.themLoHang(lo);
        }
        public int suaLoHang(LoHang lo, string malo)
        {
            return lohang.suaLoHang(lo, malo);
        }
        public int xoaLoHang(string malo, string masp)
        {
            return lohang.xoaLoHang(malo, masp);
        }
        public int timLoHang(string malo)
        {
            return lohang.timLoHang(malo);
        }
        public string getMaLoBangMaSP(string masp)
        {
            return lohang.getMaLoBangMaSP(masp);
        }
    }
}
