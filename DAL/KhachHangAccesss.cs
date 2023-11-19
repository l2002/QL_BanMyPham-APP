using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangAccesss
    {
        DatabaseAccess database = new DatabaseAccess();
        public List<KhachHang> getListKhachHang()
        {
            List<KhachHang> list = new List<KhachHang>();
            DataTable dt = database.fillTable("select MaKH,TenKH from KhachHang");
            foreach (DataRow dr in dt.Rows)
            {
                KhachHang kh = new KhachHang();
                kh.MaKH = dr[0].ToString();
                kh.TenKH = dr[1].ToString();
                list.Add(kh);
            }
            return list;
        }
    }
}
