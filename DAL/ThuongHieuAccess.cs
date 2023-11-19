using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThuongHieuAccess
    {
        DatabaseAccess database = new DatabaseAccess();
        public List<ThuongHieu> getListThuongHieu()
        {
            List<ThuongHieu> list = new List<ThuongHieu>();
            DataTable dt = database.fillTable("select * from ThuongHieu");
            foreach (DataRow dr in dt.Rows)
            {
                ThuongHieu th = new ThuongHieu();
                th.MaTH = dr[0].ToString();
                th.TenTH = dr[1].ToString();
                list.Add(th);
            }
            return list;
        }
    }
}
