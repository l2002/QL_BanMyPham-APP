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
        public int themNhaCC(NhaCC ncc)
        {
            string sql = "insert into NhaCC values('" + ncc.MaNCC + "',N'" + ncc.TenNCC + "')";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int suaNhaCC(NhaCC ncc)
        {
            string sql = "update NhaCC set tenncc=N'" + ncc.TenNCC + "' where mancc = '" + ncc.MaNCC + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int xoaNhaCC(string mancc)
        {
            string sql = "delete NhaCC where mancc = '" + mancc + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
    }
}
