using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using System.Collections;
using System.Windows.Forms;


namespace DAL
{
    public class DatabaseAccess
    {
        protected SqlConnection con = new SqlConnection("Data Source=DESKTOP-D5ACUIJ\\SQL;Initial Catalog=QL_MyPham_DA;Integrated Security=true;");
        public void Connect()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            
        }
        public string GetFieldValues(string sql)
        {
            con = new SqlConnection();   //Khởi tạo đối tượng
            con.ConnectionString = @"Data Source=DESKTOP-D5ACUIJ\SQL;Initial Catalog=QL_MyPham_DA;Integrated Security=true;";
            con.Open();
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader= cmd.ExecuteReader(); 
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
        public void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            dap.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
        }
        public DataTable fillTable(string sql)
        {
            Connect();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            Disconnect();
            return dt;
        }
        public int excuteNonQuery(string sql)
        {
            Connect();
            SqlCommand command = new SqlCommand(sql, con);
            int kq = command.ExecuteNonQuery();
            Disconnect();
            return kq;
        }
        public int executeScalar(string sql)
        {
            Connect();
            SqlCommand command = new SqlCommand(sql, con);
            int kq = (int)command.ExecuteScalar();
            Disconnect();
            return kq;
        }

        public void Disconnect()
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public bool CheckKey(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public string ConvertDateTime(string date)
        {
            string[] elements = date.Split('/');
            string dt = string.Format("{0}/{1}/{2}", elements[0], elements[1], elements[2]);
            return dt;
        }
        
    }
}
