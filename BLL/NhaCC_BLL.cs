using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhaCC_BLL
    {
        NhaCCAccess ncc = new NhaCCAccess();
        public List<NhaCC> getListNCC()
        {
            return ncc.getListNhaCC();
        }
    }
}
