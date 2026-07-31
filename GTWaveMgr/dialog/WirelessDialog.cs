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
    public partial class WirelessDialog : Form
    {
        public	DeviceInfo		dInfo       = null;
		public	WirelessInfo	wInfo		= null;
        public  string			mViewMode   = "add";
        public  MainFormV1		mForm       = null;

        public WirelessDialog()
        {
            InitializeComponent();
		}

		private void WirelessDialog_Load(object sender, EventArgs e) {

			DispInfo();

			cb_system_kind.Items.Clear();
			var results = GlobalHelpers.mSystemTb.Query()
				//.Where(x => x.groupName.Equals(group_name))
				.OrderBy(x => x.name)
				//.Select(x => new { x.site, NameUpper = x.site.ToUpper() })
				//.Limit(10)
				.ToList();

			foreach (var system in results) {
				Debug.WriteLine(system.name);
				cb_system_kind.Items.Add(system.name);
				//user.dispListView(lv_user_list);
			}

			cb_system_kind.SelectedIndex = 0;
			cb_check_type.SelectedIndex = 0;
			cb_conn_type.SelectedIndex = 0;
		}

		/*
		public void    Refresh() {
			var results = GlobalHelpers.mUserTb.Query()
				//.Where(x => x.site.StartsWith("J"))
				.OrderBy(x => x.mMemNm)
				//.Select(x => new { x.site, NameUpper = x.site.ToUpper() })
				//.Limit(10)
				.ToList();

			lv_user_list.Items.Clear();
			foreach (var user in results) {
				Debug.WriteLine(user.mMemNm);
				lv_user_list.Items.Add(user.getItem());

				//user.dispListView(lv_user_list);
			}
		}
		*/

        public  void    DispInfo() {
			cb_system_kind.Text	= dInfo.type;
			tb_group_nm.Text	= $"{dInfo.groupNm}";
			tb_device_nm.Text   = dInfo.name;
			cb_is_dumy.Checked	= dInfo.isDumy;
			mtb_addr.Text		= dInfo.addr;
			cb_check_type.Text  = dInfo.checkType;
			tb_check_port.Text  = dInfo.checkPort.ToString();
			cb_conn_type.Text	= dInfo.connType;
			tb_conn_port.Text	= dInfo.connPort.ToString();

			tb_desc.Text        = dInfo.desc;
		}

		private void	bt_apply_Click(object sender, EventArgs e)
        {
			// 중복체크
			if ("add".Equals(mViewMode)) {
				var results = GlobalHelpers.mDeviceTb.Query()
					.Where(x => x.groupNm.Equals(tb_group_nm.Text) && x.name.Equals(tb_device_nm.Text))
					.OrderBy(x => x.name)
					//.Select(x => new { x.site, NameUpper = x.site.ToUpper() })
					//.Limit(10)
					.ToList();

				if (results.Count() > 0) {
					Debug.WriteLine($"{tb_group_nm.Text} -> {tb_device_nm.Text}");
					MessageBox.Show("같은 그룹에 같은 이름이 존재 합니다.", "알림창");
					return;
				}

				DeviceInfo info = new DeviceInfo(-1);
				info.type		= cb_system_kind.Text;
				info.groupNm	= tb_group_nm.Text;
				info.name		= tb_device_nm.Text;
				info.isDumy		= cb_is_dumy.Checked;
				info.addr		= mtb_addr.Text;
				info.checkType	= cb_check_type.Text;
				info.checkPort	= Int32.Parse(tb_check_port.Text);
				info.connType	= cb_conn_type.Text;
				info.connPort	= Int32.Parse(tb_conn_port.Text);
				info.desc		= tb_desc.Text;

				GlobalHelpers.mDeviceTb.Insert(info);
			} else if ("fix".Equals(mViewMode)) {

				var results = GlobalHelpers.mDeviceTb.Query()
					.Where(x => x.groupNm.Equals(tb_group_nm.Text) && x.name.Equals(tb_device_nm.Text))
					.OrderBy(x => x.name)
					//.Select(x => new { x.site, NameUpper = x.site.ToUpper() })
					//.Limit(10)
					.ToList();

				if (results.Count() > 0 && results[0].id != dInfo.id) {
					Debug.WriteLine($"{tb_group_nm.Text} -> {tb_device_nm.Text}");
					MessageBox.Show("같은 그룹에 같은 이름이 존재 합니다.", "알림창");
					return;
				}

				dInfo.type		= cb_system_kind.Text;
				dInfo.groupNm	= tb_group_nm.Text;
				dInfo.name		= tb_device_nm.Text;
				dInfo.isDumy	= cb_is_dumy.Checked;
				dInfo.addr		= mtb_addr.Text;
				dInfo.checkType = cb_check_type.Text;
				dInfo.checkPort = Int32.Parse(tb_check_port.Text);
				dInfo.connType	= cb_conn_type.Text;
				dInfo.connPort	= Int32.Parse(tb_conn_port.Text);
				dInfo.desc		= tb_desc.Text;

				GlobalHelpers.mDeviceTb.Update(dInfo);
			} else {
				MessageBox.Show("알수 없는 오류로 작업을 중지합니다\n다시 시도해 주세요.", "알림창");
			}
			Close();
		}

		private void bt_close_Click(object sender, EventArgs e)
        {
			Close();
		}

		private void bt_url_link_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(tb_url.Text);
        }


		private void DeviceDialog_Shown(object sender, EventArgs e) {
			tb_device_nm.Focus();
		}

		private void bt_set_snmp_Click(object sender, EventArgs e) {
			SnmpSetDialog setDialog = new SnmpSetDialog();
			setDialog.dInfo = dInfo;
			setDialog.ShowDialog();
		}
	}
}
