using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class IP_EPAccess
    {
        DatabaseAccess database = new DatabaseAccess();
        public int backupDatabase(string path)
        {
            string sql = "USE QL_MyPham_DA BACKUP DATABASE QL_MyPham_DA TO DISK = '"+path+"'   WITH FORMAT,     MEDIANAME = 'QLMyPhamBackups',    NAME = 'Full Backup of QL_MyPham_DA';";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
        public int importDatabase(string path)
        {
            string sql = "use master alter database QL_MyPham_DA set single_user with rollback immediate IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'QL_MyPham_DA') DROP DATABASE QL_MyPham_DA RESTORE DATABASE QL_MyPham_DA FROM DISK = '" + path+"'";
            int kq = database.excuteNonQuery(sql);
            return kq;
        }
    }
}
