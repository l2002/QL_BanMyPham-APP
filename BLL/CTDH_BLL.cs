using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CTDH_BLL
    {
        CTDHAccess ctdhAccess=new CTDHAccess();
        DatabaseAccess databaseAccess=new DatabaseAccess();

        public DataTable getCTDH(CTDonHang ctdh)
        {
            return ctdhAccess.getCTDH(ctdh);
        }
        public int themCTHD(CTDonHang ctdh)
        {
            return ctdhAccess.themCTHD(ctdh);
        }
        public bool checkKey(string str)
        {
            return databaseAccess.CheckKey(str);
        }
        public int ktraSPDaCo(CTDonHang ctdh)
        {         
            return ctdhAccess.ktSPDaCo(ctdh);
        }
        public void xoaCTDH(string madh)
        {
            ctdhAccess.xoaCTDH(madh);
        }
        public int xoaSP_CTDH(string madh,string maSP)
        {
            return ctdhAccess.xoaSP_CTDH(madh,maSP);
        }
        public string GetFieldValues(string str)
        {
            return databaseAccess.GetFieldValues(str);
        }
        public int updateSL_SP(int slcon,string masp)
        {
            return ctdhAccess.updateSL_SP(slcon,masp);
        }
        public int getSLTon(string masp)
        {
            return ctdhAccess.getSLTon(masp);
        }
        public int updateTongTien_Xoa(double tongmoi,string masp)
        {
            return ctdhAccess.updateTongtien_Xoa(tongmoi,masp);
        }
    }
}
