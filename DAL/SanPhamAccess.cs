using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPhamAccess
    {
        DatabaseAccess database = new DatabaseAccess();
        private void datTenTable(DataTable dt)
        {
            
            dt.Columns[0].ColumnName = "Mã sản phẩm";
            dt.Columns[1].ColumnName = "Tên sản phẩm";
            dt.Columns[2].ColumnName = "Mã loại";
            dt.Columns[3].ColumnName = "Mã khuyến mãi";
            dt.Columns[4].ColumnName = "Mã thương hiệu";
            dt.Columns[5].ColumnName = "Hạn sử dụng";
            dt.Columns[6].ColumnName = "Hình ảnh";
            dt.Columns[7].ColumnName = "Giá bán";
            dt.Columns[8].ColumnName = "Mô tả";
        }
        public DataTable getSanPham()
        {
            DataTable dt = database.fillTable("select * from SanPham");
            datTenTable(dt);
            return dt;
        }
        public int themSanPham(SanPham sp)
        {
            string sql = "insert into SanPham(masp,tensp,maloai,math,hsd,hinhanh,giaban,mota) values('" + sp.MaSP + "',N'" + sp.TenSP + "','" + sp.MaLoai + "','" + sp.MaTH + "','" + sp.HSD + "','" + sp.HinhAnh + "','" + sp.GiaBan + "',N'" + sp.MoTa + "')";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int suaSanPham(SanPham sp)
        {
            string sql = "update SanPham set tensp=N'" + sp.TenSP + "',maloai=N'" + sp.MaLoai + "',math=N'" + sp.MaTH + "',hsd='" + sp.HSD + "',hinhanh='" + sp.HinhAnh + "',giaban='" + sp.GiaBan + "',mota=N'" + sp.MoTa + "' where masp = '" + sp.MaSP + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int xoaSanPham(string masp)
        {
            string sql = "delete SanPham where masp = '" + masp + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int timSanPham(string masp)
        {
            string sql = "select count(*) from SanPham where masp = '" + masp + "'";
            int kq = database.executeScalar(sql);
            return kq;
        }
        public int updateKM(string masp, string makm)
        {
            string sql = "update SanPham set makm = '"+makm+"' where masp = '" + masp + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int suaKM(string makm, string makmsua)
        {
            string sql = "update SanPham set makm = '" + makm + "' where makm = '" + makmsua + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int xoakm(string masp)
        {
            string sql = "update SanPham set makm = " + "null" + " where masp = '" + masp + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public DataTable timSP_NhieuGiaTri(string tensp, float giaban, bool chuakm)
        {
            DataTable dt = new DataTable();
            if (chuakm)
            {
                string sql = "select * from SanPham where makm is null";
                dt = database.fillTable(sql);
                datTenTable(dt);
            }
            else if (giaban != 0)
            {
                string sql = "select * from SanPham where giaban <= "+giaban+"";
                dt = database.fillTable(sql);
                datTenTable(dt);
            }
            else if (tensp != null)
            {
                string sql = "select * from SanPham where tensp like N'%" + tensp + "%'";
                dt = database.fillTable(sql);
                datTenTable(dt);
            }
            if (giaban != 0)
            {
                DataRow[] rows = dt.Select("[Giá bán]<=" + giaban + "");
                cloneTable(dt, rows);
            }
            if (tensp != null)
            {
                DataRow[] rows = dt.Select("[Tên sản phẩm] = '"+tensp+"' ");
                cloneTable(dt, rows);
            }

            return dt;
        }
        private void cloneTable(DataTable dt, DataRow[] rows)
        {
            DataTable newdt = dt.Clone();
            foreach (DataRow row in rows)
            {
                DataRow newRow = newdt.NewRow();
                newRow.ItemArray = row.ItemArray;
                newdt.Rows.Add(newRow);
            }
            dt = newdt;
        }

    }
}
