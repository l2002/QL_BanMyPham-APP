using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CTDHAccess
    {
        DatabaseAccess database = new DatabaseAccess();
        public DataTable getCTDH()
        {
            CTDonHang ctdh = new CTDonHang();
            DataTable dt = database.fillTable("select * from LOAD_CTHD_FUNC ('" + ctdh.MaDH + "')");
            dt.Columns[0].ColumnName = "Mã đơn hàng";
            dt.Columns[1].ColumnName = "Mã SP";
            dt.Columns[2].ColumnName = "Tên SP";
            dt.Columns[3].ColumnName = "Số lượng";
            dt.Columns[4].ColumnName = "Giá bán";
            dt.Columns[5].ColumnName = "Khuyến mãi";
            dt.Columns[6].ColumnName = "Thành tiền";
            return dt;
        }
    }
}
