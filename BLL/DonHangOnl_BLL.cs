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
    public class DonHangOnl_BLL
    {
        DonHangOnlAccess dhAccess = new DonHangOnlAccess();
        DatabaseAccess dbAccess = new DatabaseAccess();
        public DataTable getHoaDonOnl()
        {
            return dhAccess.getHoaDonOnl();
        }
        public int updateTinhTrang(DonHangOnl dh)
        {
            return dhAccess.updateTrangThai(dh);
        }
        public int updateNgayGiao(DonHangOnl dh)
        {
            return dhAccess.updateNgayGiao(dh);
        }
        
       
    }
}
