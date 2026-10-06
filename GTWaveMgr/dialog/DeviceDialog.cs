using AnyBoBu.info;
using Awool;
using GTWave.gui;
using GTWave.info;
using HyperBase;
using SnmpSharpNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static MindFusion.Swf.Tools;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AnyBoBu.dialog
{
    public partial class DeviceDialog : Form
    {
        private	DeviceInfo	dInfo       = null;
		//public	GroupInfo	gInfo		= null;
        public  string      mViewMode   = "add";
        public  MainFormV1  mForm       = null;

        public	DeviceDialog(DeviceInfo dInfo)
        {
            InitializeComponent();
			this.dInfo = dInfo;

			//bt_dup_ck.Visible = false;
		}

		private void DeviceDialog_Load(object sender, EventArgs e) {

			cb_system_kind.Items.Clear();
			var results = GlobalHelpers.mSystemTb.Query()
				//.Where(x => x.groupName.Equals(group_name))
				.OrderBy(x => x.id)
				//.Select(x => new { x.site, NameUpper = x.site.ToUpper() })
				//.Limit(10)
				.ToList();

			ComboboxItem defaultItem = null;
			foreach (var system in results) {
				if (string.IsNullOrWhiteSpace(system.name)) {
					continue;
				}

				ComboboxItem item = new ComboboxItem();
				item.Text	= system.name;
				item.Value	= system;
				//cb_system_kind.Items.Add(system.name);
				cb_system_kind.Items.Add(item);
				//user.dispListView(lv_user_list);

				if (system.id == 0 && defaultItem == null) {
					defaultItem = item;
				}
			}

			if (defaultItem != null) {
				cb_system_kind.SelectedItem = defaultItem;
			} else if (cb_system_kind.Items.Count > 0) {
				cb_system_kind.SelectedIndex = 0;
			}
			cb_check_type.SelectedIndex = 0;
			cb_conn_type.SelectedIndex = 0;

			// 그룹 콤보박스 채우기
			cb_group_nm.Items.Clear();
			if (mForm != null) {
				List<string> groupPaths = new List<string>();
				mForm.CollectGroupPaths(mForm.tv_group.Nodes, groupPaths);
				foreach (var path in groupPaths) {
					cb_group_nm.Items.Add(path);
				}
			} else {
				// mForm이 null인 경우 현재 그룹명만 추가 (fallback)
				if (!string.IsNullOrEmpty(dInfo.groupNm)) {
					cb_group_nm.Items.Add(dInfo.groupNm);
				}
			}

			if (dInfo.id == -1) {
				bt_switch_status.Visible = false;
				bt_delete.Visible = false;
			}

			DispInfo();

			Debug.WriteLine("");
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
			int matchIndex = -1;
			if (!string.IsNullOrEmpty(dInfo.type)) {
				for (int i = 0; i < cb_system_kind.Items.Count; i++) {
					ComboboxItem cItem = cb_system_kind.Items[i] as ComboboxItem;
					string itemText = cItem != null ? cItem.Text : cb_system_kind.Items[i].ToString();
					if (string.Equals(itemText, dInfo.type, StringComparison.OrdinalIgnoreCase)) {
						matchIndex = i;
						break;
					}
				}
			}

			if (matchIndex >= 0) {
				cb_system_kind.SelectedIndex = matchIndex;
			} else if (cb_system_kind.Items.Count > 0) {
				cb_system_kind.SelectedIndex = 0;
			}

			ComboboxItem selItem = cb_system_kind.SelectedItem as ComboboxItem;
			dInfo.type = selItem != null ? selItem.Text : (cb_system_kind.SelectedItem != null ? cb_system_kind.SelectedItem.ToString() : cb_system_kind.Text);
			cb_system_kind.Text	= dInfo.type;
			// 그룹명 콤보박스: 내부 저장값(|)으로 항목 선택
			if (cb_group_nm.Items.Contains(dInfo.groupNm)) {
				cb_group_nm.SelectedItem = dInfo.groupNm;
			} else if (cb_group_nm.Items.Count > 0) {
				cb_group_nm.SelectedIndex = 0;
			}
			tb_device_nm.Text   = dInfo.name;
			cb_is_dumy.Checked	= dInfo.isDumy;
			if (cb_is_dumy.Checked) {
				tb_addr.Enabled = false;
			} else {
				tb_addr.Enabled = true;
			}

			tb_addr.Text		= dInfo.addr;
			cb_check_type.Text  = dInfo.checkType;
			tb_check_port.Text  = dInfo.checkPort.ToString();
			if (string.IsNullOrEmpty(dInfo.connType)) {
				dInfo.connType = "http";
			}
			cb_conn_type.Text	= dInfo.connType;
			tb_conn_port.Text	= dInfo.connPort.ToString();
			if ("JSON".Equals(dInfo.protocolType, StringComparison.OrdinalIgnoreCase)) {
				rb_json.Checked = true;
				bt_set_snmp.Enabled = false;
			} else {
				rb_snmp.Checked = true;
				bt_set_snmp.Enabled = true;
			}

			tb_desc.Text        = dInfo.desc;
		}

		private void bt_apply_Click(object sender, EventArgs e)
        {
			if (string.IsNullOrEmpty(tb_device_nm.Text)) {
				MessageBox.Show("이름이 공백입니다\n 확인해 주세요.", "알림창");
				return;
			}

			if (cb_group_nm.SelectedItem == null) {
				MessageBox.Show("그룹을 선택해 주세요.", "알림창");
				return;
			}

			// 콤보박스에서 선택된 그룹 경로 (내부 저장값 그대로 사용)
			string selectedGroupNm = cb_group_nm.SelectedItem.ToString();

			// 중복체크
			if ("add".Equals(mViewMode)) {
				var results = GlobalHelpers.mDeviceTb.Query()
					.Where(x => x.groupNm.Equals(selectedGroupNm) && x.name.Equals(tb_device_nm.Text))
					.OrderBy(x => x.name)
					.ToList();

				if (results.Count() > 0) {
					MessageBox.Show("같은 그룹에 같은 이름이 존재 합니다.", "알림창");
					return;
				}

				DeviceInfo info = new DeviceInfo(0);
				info.type		= cb_system_kind.Text;
				info.groupNm	= selectedGroupNm;
				info.name		= tb_device_nm.Text;
				info.isDumy		= cb_is_dumy.Checked;
				info.addr		= tb_addr.Text;
				info.checkType	= cb_check_type.Text;
				info.checkPort	= Int32.Parse(tb_check_port.Text);
				info.connType	= cb_conn_type.Text;
				info.connPort	= Int32.Parse(tb_conn_port.Text);
				info.desc		= tb_desc.Text;
				info.isSnmp		= rb_snmp.Checked;
				info.protocolType = rb_json.Checked ? "JSON" : "SNMP";

				GlobalHelpers.mDeviceTb.Insert(info);

				if (mForm != null) {
					mForm.AddDevice2Diagram(info);
				}

			} else if ("fix".Equals(mViewMode)) {

				var results = GlobalHelpers.mDeviceTb.Query()
					.Where(x => x.groupNm.Equals(selectedGroupNm) && x.name.Equals(tb_device_nm.Text))
					.OrderBy(x => x.name)
					.ToList();

				if (results.Count() > 0 && results[0].id != dInfo.id) {
					MessageBox.Show("같은 그룹에 같은 이름이 존재 합니다.", "알림창");
					return;
				}

				DeviceInfo oInfo = dInfo.Clone();

				dInfo.type		= cb_system_kind.Text;
				dInfo.groupNm	= selectedGroupNm; // 콤보박스에서 선택된 그룹으로 변경
				dInfo.name		= tb_device_nm.Text;
				dInfo.isDumy	= cb_is_dumy.Checked;
				dInfo.addr		= tb_addr.Text;
				dInfo.checkType = cb_check_type.Text;
				dInfo.checkPort = Int32.Parse(tb_check_port.Text);
				dInfo.connType	= cb_conn_type.Text;
				dInfo.connPort	= Int32.Parse(tb_conn_port.Text);
				dInfo.isSnmp	= rb_snmp.Checked;
				dInfo.protocolType = rb_json.Checked ? "JSON" : "SNMP";
				dInfo.desc		= tb_desc.Text;

				GlobalHelpers.mDeviceTb.Update(dInfo);

				if (mForm != null) {
					mForm.FixDevice2Diagram(dInfo, oInfo);
				}

			} else {
				MessageBox.Show("알수 없는 오류로 작업을 중지합니다\n다시 시도해 주세요.", "알림창");
			}
			/*
			if (dInfo.id == -1) {
				DeviceDialog_Load(null, null);
			} else {
				Close();
			}
			*/
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
			// 적용을 누르고 
			if (dInfo.id == -1) {
				MessageBox.Show("적용을 해서 DB에 저장을 해야 합니다.");
				return;
			}

			SnmpSetDialog setDialog = new SnmpSetDialog();
			setDialog.dInfo = dInfo;
			setDialog.ShowDialog();
		}

		private void	rb_snmp_CheckedChanged(object sender, EventArgs e) {
			if (rb_snmp.Checked) {
				bt_set_snmp.Enabled = true;
			} else {
				bt_set_snmp.Enabled = false;
			}
		}

		private void	bt_switch_Click(object sender, EventArgs e) {
			// 적용을 누르고 
			if (dInfo.id == -1) {
				MessageBox.Show("적용을 해서 DB에 저장을 해야 합니다.");
				return;
			}

			SwitchSetDialog dialog = new SwitchSetDialog();
			dialog.dInfo = dInfo;
			dialog.ShowDialog();
			/*
			StatusSwitch statusSwitch = new StatusSwitch();
			statusSwitch.dInfo = dInfo;
			statusSwitch.ShowDialog();
			*/
		}

		private void	cb_system_kind_SelectedIndexChanged(object sender, EventArgs e) {
			System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)sender;

			if (comboBox.SelectedItem is ComboboxItem item && item.Value is SystemInfo selected) {
				try {
					pb_system_image.Image = System.Drawing.Image.FromFile(selected.imagePath);
				} catch (Exception) {
				}

				int type = selected.GetType();
				switch(type) {
					case 1:
						bt_switch.Visible = true;
						break;
					case 2:
						bt_switch.Visible = false;
						break;
				}
			}
		}

		private void bt_switch_status_Click(object sender, EventArgs e) {
			string selectedKind = (cb_system_kind.Text ?? "").Trim();
			string selectedKindLower = selectedKind.ToLower();

			int type = -1;
			if (cb_system_kind.SelectedItem is ComboboxItem item && item.Value is SystemInfo sysInfo) {
				type = sysInfo.GetType();
			} else if (cb_system_kind.SelectedItem is SystemInfo sys) {
				type = sys.GetType();
			}

			bool isWireless = (type == 2) || selectedKindLower.Contains("무선") || selectedKindLower.Contains("wireless") || selectedKindLower.Contains("wifi") || selectedKindLower.Contains("ap");
			bool isSwitch = (type == 1) || selectedKindLower.Contains("스위치") || selectedKindLower.Contains("switch");

			if (dInfo != null) {
				dInfo.addr = tb_addr.Text.Trim();
				dInfo.name = tb_device_nm.Text.Trim();
				dInfo.type = selectedKind;
			}

			if (isWireless) {
				WifiStatusForm wifiStatus = new WifiStatusForm();
				wifiStatus.cb_ip.Text	= tb_addr.Text.Trim();
				wifiStatus.tb_port.Text = string.IsNullOrEmpty(tb_conn_port.Text.Trim()) ? "80" : tb_conn_port.Text.Trim();
				wifiStatus.scanProtocol = (!string.IsNullOrWhiteSpace(cb_conn_type.Text) && cb_conn_type.Text.Trim().ToLower() == "https") ? "https" : "http";
				wifiStatus.ShowDialog();
			} else if (isSwitch) {
				StatusSwitch statusSwitch = new StatusSwitch(dInfo);
				statusSwitch.ShowDialog();
			} else {
				if (dInfo != null && !string.IsNullOrEmpty(dInfo.type) && (dInfo.type.Contains("무선") || dInfo.type.ToLower().Contains("wireless"))) {
					WifiStatusForm wifiStatus = new WifiStatusForm();
					wifiStatus.cb_ip.Text	= tb_addr.Text.Trim();
					wifiStatus.tb_port.Text = string.IsNullOrEmpty(tb_conn_port.Text.Trim()) ? "80" : tb_conn_port.Text.Trim();
					wifiStatus.scanProtocol = (!string.IsNullOrWhiteSpace(cb_conn_type.Text) && cb_conn_type.Text.Trim().ToLower() == "https") ? "https" : "http";
					wifiStatus.ShowDialog();
				} else {
					StatusSwitch statusSwitch = new StatusSwitch(dInfo);
					statusSwitch.ShowDialog();
				}
			}
		}

		private void cb_is_dumy_CheckedChanged(object sender, EventArgs e) {
			System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)sender;
			if (checkBox.Checked) {
				tb_addr.Enabled = false;
			} else {
				tb_addr.Enabled = true;
			}
		}

		private void bt_delete_Click(object sender, EventArgs e) {
			// 내용 삭제
			if (MessageBox.Show("현재 장치가 삭제됩니다\n계속 진행 하시겠습니다까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				// Diagram에서 지운다...
				if (mForm != null) {
					mForm.DelDevice2Diagram(dInfo);
				}
				GlobalHelpers.mDeviceTb.DeleteMany(x => x.id.Equals(dInfo.id));

				Close();
			}

		}
	}
}
