using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class SanPham_BLL
    {
        SanPhamAccess spAccess = new SanPhamAccess();
        DatabaseAccess dbAccess=new DatabaseAccess();

        public string GetFieldValues(string str)
        {
            return dbAccess.GetFieldValues(str);
        }
        public void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            dbAccess.FillCombo(sql, cbo, ma, ten);
        }
        public DataTable getSanPham()
        {
            return spAccess.getSanPham();
        }
        public int themSanPham(SanPham sp)
        {
            return spAccess.themSanPham(sp);
        }
        public int suaSanPham(SanPham sp)
        {
            return spAccess.suaSanPham(sp);
        }
        public int xoaSanPham(string masp)
        {
            return spAccess.xoaSanPham(masp);
        }
        public int timSanPham(string masp)
        {
            return spAccess.timSanPham(masp);
        }
    }
}
