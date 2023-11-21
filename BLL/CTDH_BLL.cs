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
    }
}
