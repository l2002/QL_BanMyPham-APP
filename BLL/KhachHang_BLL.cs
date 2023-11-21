using DAL;
using DTO;
using System;
using System.Collections.Generic;
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
    }
}
