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
        public DataTable getDataLoaiHang()
        {
            return lhAccess.getDataLoaiHang();
        }
        public int themLoaiHang(LoaiHang lh)
        {
            return lhAccess.themLoaiHang(lh);
        }
        public int suaLoaiHang(LoaiHang lh)
        {
            return lhAccess.suaLoaiHang(lh);
        }
        public int xoaLoaiHang(string maloai)
        {
            return lhAccess.xoaLoaiHang(maloai);
        }
    }
}
