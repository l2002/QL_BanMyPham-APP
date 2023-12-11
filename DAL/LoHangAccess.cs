using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoHangAccess
    {
        DatabaseAccess database = new DatabaseAccess();
        public DataTable getLoHang(string malo)
        {
            SanPham nv = new SanPham();
            DataTable dt = database.fillTable("select sp.masp,tensp,tenloai,tenth,HSD,HinhAnh,giaban,tenncc,soluong,ngaynhap from SanPham sp,LoHang lo,LoaiHang lh,ThuongHieu th,NhaCC ncc  where malo='"+malo+"' and sp.masp=lo.masp and lo.mancc=ncc.mancc and lh.maloai=sp.maloai and th.math=sp.math");
            dt.Columns[0].ColumnName = "Mã sản phẩm";
            dt.Columns[1].ColumnName = "Tên sản phẩm";
            dt.Columns[2].ColumnName = "Tên loại";
            dt.Columns[3].ColumnName = "Tên thương hiệu";
            dt.Columns[4].ColumnName = "Hạn sử dụng";
            dt.Columns[5].ColumnName = "Hình ảnh";
            dt.Columns[6].ColumnName = "Giá bán";
            dt.Columns[7].ColumnName = "Tên NCC";
            dt.Columns[8].ColumnName = "Số lượng";
            dt.Columns[9].ColumnName = "Ngày nhập";
            return dt;
        }
        public List<LoHang> getListLoHang()
        {
            List<LoHang> list = new List<LoHang>();
            DataTable dt = database.fillTable("select distinct MaLo from LoHang");
            foreach (DataRow dr in dt.Rows)
            {
                LoHang lh = new LoHang();
                lh.MaLo = dr[0].ToString().Trim();               
                list.Add(lh);
            }
            return list;
        }
        public int themLoHang(LoHang lh)
        {
            string sql = "insert into LoHang values('" + lh.MaLo + "',N'" + lh.MaSP + "','" + lh.MaNCC + "','" + lh.NgayNhap + "','" + lh.SoLuong + "')";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int suaLoHang(LoHang lh, string malo)
        {
            string sql = "update LoHang set malo='"+lh.MaLo+"',masp=N'" + lh.MaSP + "',mancc=N'" + lh.MaNCC + "',ngaynhap=N'" + lh.NgayNhap + "',soluong='" + lh.SoLuong + "' where malo = '" + malo + "' and masp = '"+lh.MaSP+"'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int xoaLoHang(string malo, string masp)
        {
            string sql = "delete LoHang where malo = '" + malo + "' and masp = '"+masp+"'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int demLoHang()
        {
            string sql = "select count(*) from LoHang";
            return database.executeScalar(sql);
        }
        public int timLoHang(string malo)
        {
            string sql = "select count(*) from LoHang where malo = '" + malo + "'";
            int kq = database.executeScalar(sql);
            return kq;
        }
    }
}
