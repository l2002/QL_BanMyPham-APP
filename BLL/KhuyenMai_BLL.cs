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
    public class KhuyenMai_BLL
    {
        KhuyenMaiAccess KhuyenMai = new KhuyenMaiAccess();
        public List<KhuyenMai> getListKhuyenMai()
        {
            return KhuyenMai.getListKhuyenMai();
        }
        public DataTable getKhuyenMaiTheoMa(string makm)
        {
            return KhuyenMai.getKhuyenMaiTheoMa(makm);
        }
        public int themKhuyenMai(KhuyenMai km)
        {
            return KhuyenMai.themKhuyenMai(km);
        }
        public int suaKhuyenMai(KhuyenMai km, string makm)
        {
            return KhuyenMai.suaKhuyenMai(km, makm);
        }
        public int xoaKhuyenMai(string makm)
        {
            return KhuyenMai.xoaKhuyenMai(makm);
        }
    }
}
