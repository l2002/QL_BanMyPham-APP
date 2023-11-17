using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BLL
{
    public class NhanVien_BLL
    {
        NhanVienAccess nvAccess = new NhanVienAccess();

        public DataTable getNhanVien()
        {
            return nvAccess.getNhanVien();
        }
        public int themNhanVien(NhanVien nv)
        {
            return nvAccess.themNhanVien(nv);
        }
        public int suaNhanVien(NhanVien nv)
        {
            return nvAccess.suaNhanVien(nv);
        }
        public int xoaNhanVien(string manv)
        {
            return nvAccess.xoaNhanVien(manv);
        }
    }
}
