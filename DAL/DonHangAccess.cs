﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DonHangAccess
    {
        DatabaseAccess database = new DatabaseAccess();

       
        public DataTable getHoaDon()
        {
            DataTable dt = database.fillTable("select MaDH,MaKH,DonHang.MaNV,TenNV,NgayDat,TongTien from DonHang,NhanVien where NhanVien.MaNV=DonHang.MaNV");
            dt.Columns[0].ColumnName = "Mã đơn hàng";
            dt.Columns[1].ColumnName = "Mã khách hàng";
            dt.Columns[2].ColumnName = "Mã nhân viên";
            dt.Columns[3].ColumnName = "Tên nhân viên";
            dt.Columns[4].ColumnName = "Ngày mua";
            dt.Columns[5].ColumnName = "Tổng tiền";
            return dt;
        }
        public int themHD(DonHang dh)
        {
            string sql = "INSERT INTO DonHang(MaDH, NgayDat, MaKH,MaNV, TongTien) VALUES (N'" + dh.MaDH.Trim() + "'," +
                "" + "'" + database.ConvertDateTime(dh.NgayDat.Trim()) + "',N'" + dh.MaKH + "',N'" + dh.MaNV + "'," + dh.TongTien + ")";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
       
        public string getTongTien(string madh)
        {
            string sql = "SELECT TONGTIEN FROM DonHang WHERE MaDH = '"+madh+"'";
            string kq = database.GetFieldValues(sql);
            return kq;
        }
        public int xoaHoaDon(string madh)
        {
            string sql;
            sql = "delete FROM DonHang WHERE MaDH = '" + madh + "'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public string getSPBan()
        {
            string sql;
            sql = "SELECT SUM(SoLuongMua) AS SoSanPhamDaBan FROM CTDonHang INNER JOIN SanPham ON CTDonHang.MaSP = SanPham.MaSP";
            string kq = database.GetFieldValues(sql);
            return kq;
        }
        public string getTongDoanhThu()
        {
            string sql;
            sql = "SELECT SUM(TongTien) AS TongDoanhThu FROM DonHang";
            string kq = database.GetFieldValues(sql);
            return kq;
        }
        public string getTongKH()
        {
            string sql;
            sql = "SELECT COUNT(*) AS TongSoKhachHang FROM KhachHang";
            string kq = database.GetFieldValues(sql);
            return kq;
        }
    }
}
