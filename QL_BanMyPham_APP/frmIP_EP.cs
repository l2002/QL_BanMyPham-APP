using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanMyPham_APP
{
    public partial class frmIP_EP : Form
    {
        IPEP_BLL ipep = new IPEP_BLL();
        public frmIP_EP()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Backup File|*.bak";
            string sfdname = saveFileDialog1.FileName;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = Path.GetFullPath(sfd.FileName);
                if(ipep.backupDatabase(path) != -1)
                {
                    MessageBox.Show("Xuất dữ liệu thành công");
                }    
                else
                {
                    MessageBox.Show("Xuất dữ liệu thất bại");
                }    
            }
            
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Backup File|*.bak";
            string sfdname = saveFileDialog1.FileName;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = Path.GetFullPath(ofd.FileName);
                if(ipep.importDatabase(path) != -1)
                {
                    MessageBox.Show("Nhập dữ liệu thành công");
                }
                else
                {
                    MessageBox.Show("Nhập dữ liệu thất bại");
                }
            }
        }
    }
}
