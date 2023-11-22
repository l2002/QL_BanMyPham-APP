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
    public class DonHang_BLL
    {
        DonHangAccess dhAccess = new DonHangAccess();
        DatabaseAccess dbAccess = new DatabaseAccess();

        public string taoMaDH()
        {
            return dbAccess.CreateKey("HDB");
        }
        public int themHD(DonHang dh)
        {
            return dhAccess.themHD(dh);
        }
       
        public DataTable getHoaDon()
        {
            return dhAccess.getHoaDon();
        }
        
        public string getTongTien(string madh)
        {
            return dhAccess.getTongTien(madh);
        }
    }
}
