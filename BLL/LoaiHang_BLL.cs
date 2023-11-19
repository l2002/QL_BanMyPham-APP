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
    public class LoaiHang_BLL
    {
        LoaiHangAccess lhAccess = new LoaiHangAccess();
        public List<LoaiHang> GetListLoaiHang()
        {
            return lhAccess.getListLoaiHang();
        }
    }
}
