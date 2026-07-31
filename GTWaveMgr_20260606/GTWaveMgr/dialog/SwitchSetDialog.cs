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
    public partial class SwitchSetDialog : Form
    {
        public	DeviceInfo	dInfo       = null;
		public	SwitchInfo	sInfo		= null;

        public  MainFormV1  mForm       = null;

        public	SwitchSetDialog()
        {
            InitializeComponent();
		}

		private void SnmpSetDialog_Load(object sender, EventArgs e) {
			Refresh();
			DispInfo();
		}

		override
		public void    Refresh() {
			//cb_verion.Items.Clear();
			var results = GlobalHelpers.mSwitchTb.Query()
				.Where(x => x.deviceId.Equals(dInfo.id))
				//.OrderBy(x => x.name)
				//.Select(x => new { x.site, NameUpper = x.site.ToUpper() })
				//.Limit(10)
				.ToList();

			if (results.Count > 0) {
				sInfo = results[0];
				DispInfo();
			} else {
				sInfo	= new SwitchInfo(dInfo.id);
				GlobalHelpers.mSwitchTb.Insert(sInfo);
			}
		}

		public void    DispInfo() {
			tb_num_poe.Text		= sInfo.numPoe.ToString();
			tb_num_eth.Text		= sInfo.numEth.ToString();
			tb_num_sfp.Text		= sInfo.numSfp.ToString();
			tb_num_combo.Text	= sInfo.numCombo.ToString();
			cb_is_watch.Checked = sInfo.isWatch;
			tb_idx_first.Text	= sInfo.idxFirst.ToString();

			tb_switch_desc.Text	= sInfo.desc;
		}

		private void bt_apply_Click(object sender, EventArgs e)
        {
			sInfo.numPoe	= Int32.Parse(tb_num_poe.Text);
			sInfo.numEth	= Int32.Parse(tb_num_eth.Text);
			sInfo.numSfp	= Int32.Parse(tb_num_sfp.Text);
			sInfo.numCombo	= Int32.Parse(tb_num_combo.Text);

			sInfo.isWatch	= cb_is_watch.Checked;
			sInfo.idxFirst	= Int32.Parse(tb_idx_first.Text);

			sInfo.desc		= tb_switch_desc.Text;

			GlobalHelpers.mSwitchTb.Update(sInfo);

			Close();
		}

		private void bt_close_Click(object sender, EventArgs e) {
			Close();
		}

		private void DeviceDialog_Shown(object sender, EventArgs e) {
			tb_num_poe.Focus();
		}
	}
}
