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
    public class DatHang_BLL
    {
        DatHangAccess dhAccess = new DatHangAccess();
        DatabaseAccess dbAccess = new DatabaseAccess();
        public DataTable getHoaDonOnl()
        {
            return dhAccess.getHoaDonOnl();
        }
        public int updateTinhTrang(DatHang dh)
        {
            return dhAccess.updateTrangThai(dh);
        }
        public int updateNgayGiao(DatHang dh)
        {
            return dhAccess.updateNgayGiao(dh);
        }
        public int xoaDonHang(string madh)
        {
            return dhAccess.xoaDatHang(madh);
        }
    }
}
