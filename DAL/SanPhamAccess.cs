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
        public DataTable getSanPham()
        {
            SanPham nv = new SanPham();
            DataTable dt = database.fillTable("select * from SanPham");
            dt.Columns[0].ColumnName = "Mã sản phẩm";
            dt.Columns[1].ColumnName = "Tên sản phẩm";
            dt.Columns[2].ColumnName = "Mã loại";
            dt.Columns[3].ColumnName = "Mã khuyến mãi";
            dt.Columns[4].ColumnName = "Mã thương hiệu";
            dt.Columns[5].ColumnName = "Hạn sử dụng";
            dt.Columns[6].ColumnName = "Hình ảnh";
            dt.Columns[7].ColumnName = "Giá bán";
            return dt;
        }
        public int themSanPham(SanPham sp)
        {
            string sql = "insert into SanPham(masp,tensp,maloai,math,hsd,hinhanh,giaban) values('" + sp.MaSP + "',N'" + sp.TenSP + "','" + sp.MaLoai + "','" + sp.MaTH + "','" + sp.HSD + "','" + sp.HinhAnh + "','" + sp.GiaBan + "')";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int suaSanPham(SanPham sp)
        {
            string sql = "update SanPham set tensp=N'" + sp.TenSP + "',maloai=N'" + sp.MaLoai + "',math=N'" + sp.MaTH + "',hsd='" + sp.HSD + "',hinhanh='" + sp.HinhAnh + "',giaban='" + sp.GiaBan + "' where masp = '" + sp.MaSP + "'";
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
    }
}
