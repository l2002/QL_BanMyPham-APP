using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoHang_BLL
    {
        DatabaseAccess dbAccess = new DatabaseAccess();
        public string GetFieldValues(string str)
        {
            return dbAccess.GetFieldValues(str);
        }
    }
}
