using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiHangAccess
    {
        DatabaseAccess database = new DatabaseAccess();
        public List<LoaiHang> getListLoaiHang()
        {
            List<LoaiHang> list = new List<LoaiHang>();
            DataTable dt = database.fillTable("select * from LoaiHang");
            foreach(DataRow dr in dt.Rows)
            {
                LoaiHang lh = new LoaiHang();
                lh.MaLoai = dr[0].ToString();
                lh.TenLoai = dr[1].ToString();
                list.Add(lh);
            }
            return list;
        }
    }
}
