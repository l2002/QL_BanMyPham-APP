using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhaCCAccess
    {
        DatabaseAccess database = new DatabaseAccess();
        public List<NhaCC> getListNhaCC()
        {
            List<NhaCC> list = new List<NhaCC>();
            DataTable dt = database.fillTable("select * from NhaCC");
            foreach (DataRow dr in dt.Rows)
            {
                NhaCC ncc = new NhaCC();
                ncc.MaNCC = dr[0].ToString();
                ncc.TenNCC = dr[1].ToString();
                list.Add(ncc);
            }
            return list;
        }
    }
}
