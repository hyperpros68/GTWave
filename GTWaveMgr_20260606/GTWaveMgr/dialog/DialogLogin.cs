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
    public partial class DialogLogin : Form
    {
        public  string  id = "";
        public  string  pw = "";

        public  bool    isOK    = false;

        public DialogLogin()
        {
            InitializeComponent();
        }

        private void CrawlOptionDialog_Load(object sender, EventArgs e)
        {
            //id = WaveLinker.Properties.Settings.Default.id;
            //pw = WaveLinker.Properties.Settings.Default.pw;

            tb_id.Text = id;
            tb_pw.Text = pw;
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
			//WaveLinker.Properties.Settings.Default.id   = tb_id.Text;
			//WaveLinker.Properties.Settings.Default.pw   = tb_pw.Text;

			isOK = true;
			Close();
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            Close();
        }

	}
}
