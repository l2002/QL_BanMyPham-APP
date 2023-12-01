using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ThuongHieu_BLL
    {
        ThuongHieuAccess thAccess = new ThuongHieuAccess();
        public List<ThuongHieu> GetListThuongHieu()
        {
            return thAccess.getListThuongHieu();
        }
        public int themThuongHieu(ThuongHieu th)
        {
            return thAccess.themThuongHieu(th);
        }
        public int suaThuongHieu(ThuongHieu th)
        {
            return thAccess.suaThuongHieu(th);
        }
        public int xoaThuongHieu(string math)
        {
            return thAccess.xoaThuongHieu(math);
        }
    }
}
