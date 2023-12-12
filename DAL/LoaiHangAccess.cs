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
        public DataTable getDataLoaiHang()
        {
            DataTable dt = database.fillTable("select * from LoaiHang");
            dt.Columns[0].ColumnName = "Mã loại";
            dt.Columns[1].ColumnName = "Tên loại";
            return dt;
        }
        public int themLoaiHang(LoaiHang lh)
        {
            string sql = "insert into LoaiHang values('" + lh.MaLoai + "',N'" + lh.TenLoai + "')";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int suaLoaiHang(LoaiHang lh)
        {
            string sql = "update LoaiHang set tenloai=N'" + lh.TenLoai + "' where maloai = '" + lh.MaLoai + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int xoaLoaiHang(string maloai)
        {
            string sql = "delete LoaiHang where maloai = '" + maloai + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }

    }
}
