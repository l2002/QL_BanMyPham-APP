using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhuyenMaiAccess
    {
        DatabaseAccess database = new DatabaseAccess();
        public List<KhuyenMai> getListKhuyenMai()
        {
            List<KhuyenMai> list = new List<KhuyenMai>();
            DataTable dt = database.fillTable("select * from KhuyenMai");
            foreach (DataRow dr in dt.Rows)
            {
                KhuyenMai ncc = new KhuyenMai();
                ncc.MaKM = dr[0].ToString();
                ncc.TenKM = int.Parse(dr[1].ToString());
                list.Add(ncc);
            }
            return list;
        }
        public DataTable getKhuyenMaiTheoMa(string makm)
        {
            KhuyenMai km = new KhuyenMai();
            DataTable dt = database.fillTable("select km.makm,masp,tensp,tenkm from KhuyenMai km, SanPham sp where sp.makm = km.makm and km.makm = '"+makm+"'");
            dt.Columns[0].ColumnName = "Mã Khuyến mãi";
            dt.Columns[1].ColumnName = "Mã sản phẩm";
            dt.Columns[2].ColumnName = "Tên sản phẩm";
            dt.Columns[3].ColumnName = "Giá trị khuyến mãi";
            return dt;
        }
        public int themKhuyenMai(KhuyenMai km)
        {
            string sql = "insert into KhuyenMai values('" + km.MaKM + "'," + km.TenKM + ")";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int suaKhuyenMai(KhuyenMai km, string makm)
        {
            string sql = "update KhuyenMai set makm = '"+km.MaKM+"', tenkm=" + km.TenKM + " where makm = '" + makm + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int xoaKhuyenMai(string makm)
        {
            string sql = "delete KhuyenMai where makm = '" + makm + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
    }
}
