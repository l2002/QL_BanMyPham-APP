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
        DatabaseAccess dbAccess = new DatabaseAccess();

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
        public List<SanPham> getListSanPham()
        {
            return spAccess.getListSanPham();
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
        public int updateKM(string masp, string makm)
        {
            return spAccess.updateKM(masp, makm);
        }
        public DataTable timSP_NhieuGiaTri(string tensp, float giaban, bool chuakm)
        {
            return spAccess.timSP_NhieuGiaTri(tensp, giaban, chuakm);
        }
        public int suaKM(string makm, string makmsua)
        {
            return spAccess.suaKM(makm, makmsua);
        }
        public int xoakm(string masp)
        {
            return spAccess.xoakm(masp);
        }
        public SanPham getSanPhamTheoMa(string masp)
        {
            return spAccess.getSanPhamTheoMa(masp);
        }
    }
}
