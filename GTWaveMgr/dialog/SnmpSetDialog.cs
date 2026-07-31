using AnyBoBu.info;
using Awool;
using GTWave.info;
using HyperBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MindFusion.Swf.Tools;

namespace AnyBoBu.dialog
{
    public partial class SnmpSetDialog : Form
    {
        public	DeviceInfo	dInfo       = null;
		public	SnmpInfo	sInfo		= null;
        //public  string      mViewMode   = "add";
        public  MainFormV1  mForm       = null;

        public	SnmpSetDialog()
        {
            InitializeComponent();
		}

		private void SnmpSetDialog_Load(object sender, EventArgs e) {
			cb_verion.SelectedIndex = 0;
			Refresh();
			DispInfo();
		}

		override
		public void    Refresh() {
			//cb_verion.Items.Clear();
			var results = GlobalHelpers.mSnmpTb.Query()
				.Where(x => x.deviceId.Equals(dInfo.id))
				//.OrderBy(x => x.name)
				//.Select(x => new { x.site, NameUpper = x.site.ToUpper() })
				//.Limit(10)
				.ToList();

			if (results.Count > 0) {
				sInfo = results[0];
				DispInfo();
			} else {
				sInfo	= new SnmpInfo(dInfo.id);
				GlobalHelpers.mSnmpTb.Insert(sInfo);
			}
		}

		public void    DispInfo() {
			tb_snmp_port.Text	= sInfo.port.ToString();
			cb_verion.Text		= sInfo.version;
			tb_v2c_read.Text	= sInfo.readComm;
			tb_v2c_write.Text	= sInfo.writeComm;

			tb_v3_user.Text		= sInfo.v3Username;
			tb_v3_auth_alg.Text = sInfo.v3AuthAlg;
			tb_v3_auth_pw.Text	= sInfo.v3AuthPw;
			tb_v3_pri_alg.Text	= sInfo.v3PriAlg;
			tb_v3_pri_pw.Text	= sInfo.v3PriPw;

			//oidTempFile.Text = sInfo.oidTempFile;

			tb_desc.Text        = dInfo.desc;
		}

		private void bt_apply_Click(object sender, EventArgs e)
        {
			sInfo.port		= Int32.Parse(tb_snmp_port.Text);
			sInfo.version	= cb_verion.Text;
			sInfo.readComm	= cb_verion.Text;
			sInfo.v3Username = tb_v3_user.Text;
			sInfo.v3AuthAlg = tb_v3_auth_alg.Text;
			sInfo.v3AuthPw	= tb_v3_auth_pw.Text;
			sInfo.v3PriAlg	= tb_v3_pri_alg.Text;
			sInfo.v3PriPw	= tb_v3_pri_pw.Text;

			sInfo.desc		= tb_desc.Text;

			GlobalHelpers.mSnmpTb.Update(sInfo);

			Close();
		}

		private void bt_close_Click(object sender, EventArgs e) {
			Close();
		}

		private void DeviceDialog_Shown(object sender, EventArgs e) {
			tb_snmp_port.Focus();
		}

		private void bt_oid_list_Click(object sender, EventArgs e) {
			OidListDialog dialog = new OidListDialog();
			dialog.dInfo	= dInfo;
			dialog.ShowDialog();
		}
	}
}
