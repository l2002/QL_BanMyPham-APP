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
    }
}
