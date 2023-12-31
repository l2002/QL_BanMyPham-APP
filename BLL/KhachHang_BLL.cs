﻿using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class KhachHang_BLL
    {
        KhachHangAccesss khAccess = new KhachHangAccesss();
        DatabaseAccess dbAccess=new DatabaseAccess();

        public string GetFieldValues(string str)
        {
            return dbAccess.GetFieldValues(str);
        }
        public void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            dbAccess.FillCombo(sql,cbo,ma,ten);
        }
        public DataTable getKhachHang()
        {
            return khAccess.getKhachHang();
        }
        public int themKhachHang(KhachHang kh)
        {
            return khAccess.themKhachHang(kh);
        }
        public int suaKhachHang(KhachHang kh)
        {
            return khAccess.suaKhachHang(kh);
        }
        public int xoaKhachHang(string makh)
        {
            return khAccess.xoaKhachHang(makh);
        }
    }
}
