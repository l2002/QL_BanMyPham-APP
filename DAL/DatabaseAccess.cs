using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using System.Collections;

namespace DAL
{
    public class DatabaseAccess
    {
        protected SqlConnection con = new SqlConnection("Data Source=DESKTOP-J787359;Initial Catalog=QL_MyPham_DA;Integrated Security=true;");
        public void Connect()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            
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
    
        public void Disconnect()
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
