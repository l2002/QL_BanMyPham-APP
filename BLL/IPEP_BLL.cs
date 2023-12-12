using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class IPEP_BLL
    {
        IP_EPAccess access = new IP_EPAccess();
        public int backupDatabase(string path)
        {
            return access.backupDatabase(path);
        }
        public int importDatabase(string path)
        { 
            return access.importDatabase(path);
        }
    }
}
