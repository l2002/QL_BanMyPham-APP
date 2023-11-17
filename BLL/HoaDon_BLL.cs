using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDon_BLL
    {
        HoaDonAccess hdAccess = new HoaDonAccess();

        public DataTable getHoaDon()
        {
            return hdAccess.getHoaDon();
        }
    }
}
