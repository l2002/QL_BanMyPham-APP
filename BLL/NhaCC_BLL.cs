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
        NhaCCAccess nccAccess = new NhaCCAccess();
        public List<NhaCC> getListNCC()
        {
            return nccAccess.getListNhaCC();
        }
        public int themNhaCC(NhaCC ncc)
        {
            return nccAccess.themNhaCC(ncc);
        }
        public int suaNhaCC(NhaCC ncc)
        {
            return nccAccess.suaNhaCC(ncc);
        }
        public int xoaNhaCC(string mancc)
        {
            return nccAccess.xoaNhaCC(mancc);
        }
    }
}
