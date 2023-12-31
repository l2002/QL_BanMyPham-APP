﻿using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanMyPham_APP
{
    public partial class frmLogin : Form
    {
        TaiKhoan_BLL tkBLL=new TaiKhoan_BLL();

        public frmLogin()
        {
            InitializeComponent();
            txtMatKhau.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text.Length <= 0 || txtMatKhau.Text.Length <= 0)
            {
                MessageBox.Show("Vui lòng không bỏ trống Tài khoản và Mật khẩu!");
                return;
            }         
                if(tkBLL.ktraTaiKhoan(txtTaiKhoan.Text)==txtTaiKhoan.Text && tkBLL.ktraMatKhau(txtMatKhau.Text)==txtMatKhau.Text) { 
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
                frmMain Child = new frmMain(tkBLL.getTenNV(txtTaiKhoan.Text), tkBLL.getMaNV(txtTaiKhoan.Text));
                Child.Show();

            }
       
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc Mật khẩu không đúng!");
                return;
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
