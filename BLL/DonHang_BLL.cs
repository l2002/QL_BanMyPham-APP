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

        public DataTable getHoaDon()
        {
            return dhAccess.getHoaDon();
        }
        public int updateTinhTrang(DonHang dh)
        {
            return dhAccess.updateTrangThai(dh);
        }
        public int updateNgayGiao(DonHang dh)
        {
            return dhAccess.updateNgayGiao(dh);
        }
        public int xoaDonHang(string madh)
        {
            return dhAccess.xoaDonHang(madh);
        }
    }
}
