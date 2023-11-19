using DAL;
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

        public DataTable getCTDH()
        {
            return ctdhAccess.getCTDH();
        }
    }
}
