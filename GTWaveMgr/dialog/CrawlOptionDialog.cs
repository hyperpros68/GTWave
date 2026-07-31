using HyperBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyBoBu.dialog
{
    public partial class CrawlOptionDialog : Form
    {
        public  int min_price = 0;
        public  int max_price = 0;

        public CrawlOptionDialog()
        {
            InitializeComponent();
        }

        private void CrawlOptionDialog_Load(object sender, EventArgs e)
        {
            min_price = (int)GetPrivateProfileInt("CrawlOption", "MinPrice", 0, Const.gIniFile);
            max_price = (int)GetPrivateProfileInt("CrawlOption", "MaxPrice", 0, Const.gIniFile);

            tb_min_price.Text = min_price.ToString("#,##0");
            tb_max_price.Text = max_price.ToString("#,##0");
        }
        [DllImport("kernel32")]
        public static extern uint GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);

        private void bt_ok_Click(object sender, EventArgs e)
        {
            Int32.TryParse(tb_min_price.Text, out min_price);
            Int32.TryParse(tb_max_price.Text, out max_price);

            Close();
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            min_price = -1;
            Close();
        }
    }
}
