using AnyBoBu.info;
using Awool;
using Google.Protobuf.Collections;
using GTWave.info;
using HyperBase;
using iTextSharp.text.log;
using Microsoft.Office.Interop.Excel;
using MindFusion.Vsx;
using SnmpSharpNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IronPython.Modules._ast;
using static MindFusion.Swf.Tools;

namespace AnyBoBu.dialog
{
    public partial class StatusSwitch : Form
    {
        public	DeviceInfo		dInfo       = null;
		public	SwitchInfo		sInfo		= null;

        public  string			mViewMode   = "add";
        public  MainFormV1		mForm       = null;

		SimpleSnmp	mSnmp		= null;

		int			TotPortNum	= 0;        // we need this number!

		Hashtable	mOids		= new Hashtable();

		SortedDictionary<int, SwitchPortInfo> mPortOids	= new SortedDictionary<int, SwitchPortInfo>();
		SortedDictionary<int, SwitchPoeInfo> mPoeOids	= new SortedDictionary<int, SwitchPoeInfo>();
		SortedDictionary<int, SwitchDdmInfo> mDdmOids	= new SortedDictionary<int, SwitchDdmInfo>();
		//Hashtable	mPortOids	= new Hashtable();
		//Hashtable mPoeOids	= new Hashtable();
		//Hashtable	mDdmOids	= new Hashtable();


		public StatusSwitch(DeviceInfo dInfo)
        {
            InitializeComponent();
			this.dInfo = dInfo;
		}

		private void StatusSwitch_Load(object sender, EventArgs e) {
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
				MessageBox.Show("스위치 세팅값이 없습니다.\n스위치 세팅을 해주세요.", "알림창");
				Close();
			}

			TotPortNum = sInfo.numEth + sInfo.numPoe + sInfo.numSfp - sInfo.numCombo;

			LoadOids();

			if (mOids.Count == 0) {
				Console.WriteLine($"SNMP 타겟이 유효하지 않습니다.");
				MessageBox.Show($"SNMP 타겟에 내용이 유효하지 않습니다.", "알 림 창");
				Close();
				return;
			}
			// 
			SetSubOids();

			mSnmp = new SimpleSnmp(dInfo.addr, "public");
			if (!mSnmp.Valid) {
				Console.WriteLine($"SNMP 타겟이 유효하지 않습니다.");
				MessageBox.Show($"SNMP 타겟이 IP:{dInfo.addr} 유효하지 않습니다.", "알 림 창");
				Close();
				return;
			}

			DispInfo();

			//SetPortStatus(5, 1);
			ScanOids("SysInfo");
			ScanArrayOids("PortStatus", lv_port_status);
		}

		// 
		public void SetSubOids() {
			// Port
			// 처음 index -> 2001
			SwitchPortInfo bInfo = new SwitchPortInfo();
			foreach (string key in mPortStatus) {
				OidTuple tuple = (OidTuple)mOids[key];
				if (tuple != null)
					bInfo.SetOid(tuple);
			}
			int firstIdx = bInfo.LastIdx(bInfo.ifAdminStatus.ext);
			for (int idx = 0; idx < TotPortNum; idx++) {
				SwitchPortInfo info = bInfo.Clone(firstIdx, idx);
				mPortOids.Add(idx + 1, info);
			}
			Debug.WriteLine("SetSubOids -> mPortOids done..");

			SwitchPoeInfo eInfo = new SwitchPoeInfo();
			foreach (string key in mPoeStatus) {
				OidTuple tuple = (OidTuple)mOids[key];
				if (tuple != null)
					eInfo.SetOid(tuple);
			}
			firstIdx = eInfo.LastIdx(eInfo.poeAdmin.ext);
			for (int idx = 0; idx < sInfo.numPoe; idx++) {
				SwitchPoeInfo info = eInfo.Clone(firstIdx, idx);
				mPoeOids.Add(idx + 1, info);
			}
			Debug.WriteLine("SetSubOids -> mPoeOids done..");

			SwitchDdmInfo dInfo = new SwitchDdmInfo();
			foreach (string key in mDdmStatus) {
				OidTuple tuple = (OidTuple)mOids[key];
				if (tuple != null)
					dInfo.SetOid(tuple);
			}
			firstIdx = dInfo.LastIdx(dInfo.sfpDeviceName.ext);
			for (int idx = 0; idx < sInfo.numSfp; idx++) {
				SwitchDdmInfo info = dInfo.Clone(firstIdx, idx);
				mDdmOids.Add(idx + 1, info);
			}
			Debug.WriteLine("SetSubOids -> mDdmStatus done..");
		}

		public OidTuple	FindTuple(string oid) {
			foreach (DictionaryEntry entry in mOids) {
				//Is Section the Key?
				OidTuple tuple = (OidTuple)entry.Value;

				if (oid.Equals(tuple.oid)) {
					return	tuple;
				}
			}
			return	null;
		}

		public	void	SetSnmpValue(string oid, string value) {
			foreach (DictionaryEntry entry in mOids) {
				//Is Section the Key?
				OidTuple tuple = (OidTuple)entry.Value;
				if (tuple == null) continue;
				if (tuple.oid.Equals("."+oid)) {
					tuple.scanVal = value;
					return;
				}
			}
		}

		public	void	LoadOids() {
			var results = GlobalHelpers.mOidTupleTb.Query()
				.Where(x => x.deviceId.Equals(dInfo.id))
				.OrderBy(x => x.key)
				//.Select(x => new { x.site, NameUpper = x.site.ToUpper() })
				//.Limit(10)
				.ToList();

			mOids.Clear();
			foreach (var tuple in results) {
				mOids.Add(tuple.key, tuple);
			}
		}

		private	void	SetPortStatus(int num, int level) {
			if (lv_net_1.Items.Count < num) {
				MessageBox.Show("잘못된 포트번호 입니다.", "알 림 참");
				return;
			}

			var data = lv_net_1.Items[num-1].Tag as ItemData;
			data.level = level;
		}

		// kind -> 0 : System Info
		//         4 : 환경 정보	
		// SysInfo, SysStatus, PortStatus, PoeStatus, mDdmStatus
		private void	ScanOids(string kind) {
			/*
			if (Array.Exists(mDdmStatus, x => x == tuple.key)) {
				tuple.kind	= "SysInfo"
			}
			*/

			if (mSnmp == null) {
				MessageBox.Show("스위치 세팅값이 없습니다.\n스위치 세팅을 해주세요.", "알림창");
				Close();
			}

			List<string> list = new List<string>();
			switch (kind) {
				case "All":
					break;
				case "SysInfo":
					foreach (string key in mSysInfo) {
						OidTuple tuple = (OidTuple)mOids[key];
						if (tuple != null)
							list.Add(tuple.oid);
					}
					break;
				case "SysStatus":
					foreach (string key in mSysStatus) {
						OidTuple tuple = (OidTuple)mOids[key];
						if (tuple != null)
							list.Add(tuple.oid);
					}
					break;
				default:
					return;
			}

			Dictionary<Oid, AsnType> result = mSnmp.Get(SnmpVersion.Ver1, list.ToArray());
			if (result == null)		return;

			foreach (KeyValuePair<Oid, AsnType> items in result) {
				Console.WriteLine("{0} ,  {1}", items.Key, items.Value);
				SetSnmpValue(items.Key.ToString(), items.Value.ToString());
			}

			DispScanOids(kind);
		}

		// PortStatus, PoeStatus, mDdmStatus
		private void ScanArrayOids(string kind, ListView listView) {
			switch (kind) {
				case "PortStatus":
					lv_port_status.Items.Clear();
					foreach (KeyValuePair<int, SwitchPortInfo> tuple in mPortOids) {
						SwitchPortInfo info = (SwitchPortInfo)tuple.Value;
						string[] oids= info.GetString4Oids();
						/*
						string[] oidss = {
							//".1.3.6.1.2.1.2.1",
							".1.3.6.1.2.1.2.2.1.2.2001",
							".1.3.6.1.2.1.2.2.1.7.2001",
							".1.3.6.1.2.1.2.2.1.8.2001",
							".1.3.6.1.2.1.2.2.1.5.2001",
							".1.3.6.1.2.1.2.2.1.10.2001",
							".1.3.6.1.2.1.2.2.1.16.2001"
						};
						*/
						Dictionary<Oid, AsnType> result = mSnmp.Get(SnmpVersion.Ver1, oids);
						if (result == null) return;
						foreach (KeyValuePair<Oid, AsnType> items in result) {
							Console.WriteLine("{0} ,  {1}", items.Key, items.Value);
							info.SetValue(items.Key.ToString(), items.Value.ToString());
						}
						lv_port_status.Items.Add(info.getItem());

						// 상태 표시
						SetPortStatus((int)tuple.Key, info.GetActive());

						Debug.WriteLine("info.SetValue");
					}
					Debug.WriteLine("PortStatus");
					break;

				case "PoeStatus":
					lv_poe_status.Items.Clear();
					foreach (KeyValuePair<int, SwitchPoeInfo> tuple in mPoeOids) {
						SwitchPoeInfo info = (SwitchPoeInfo)tuple.Value;
						string[] oids = info.GetString4Oids();

						Dictionary<Oid, AsnType> result = mSnmp.Get(SnmpVersion.Ver1, oids);
						if (result == null) return;
						foreach (KeyValuePair<Oid, AsnType> items in result) {
							Console.WriteLine("{0} ,  {1}", items.Key, items.Value);
							info.SetValue(items.Key.ToString(), items.Value.ToString());
						}
						lv_poe_status.Items.Add(info.getItem((int)tuple.Key));
						Debug.WriteLine("info.SetValue");
					}
					Debug.WriteLine("PortStatus");
					break;
				case "DdmStatus":
					lv_ddm_status.Items.Clear();
					foreach (KeyValuePair<int, SwitchDdmInfo> tuple in mDdmOids) {
						SwitchDdmInfo info = (SwitchDdmInfo)tuple.Value;
						string[] oids = info.GetString4Oids();

						Dictionary<Oid, AsnType> result = mSnmp.Get(SnmpVersion.Ver1, oids);
						if (result == null) return;
						foreach (KeyValuePair<Oid, AsnType> items in result) {
							Console.WriteLine("{0} ,  {1}", items.Key, items.Value);
							info.SetValue(items.Key.ToString(), items.Value.ToString());
						}
						lv_ddm_status.Items.Add(info.getItem((int)tuple.Key));
						Debug.WriteLine("info.SetValue");
					}
					Debug.WriteLine("PortStatus");
					break;

				default:
					return;
			}
		}


		private string	GetValue4Tuple(string key) {
			OidTuple tuple = (OidTuple)mOids[key];
			if (tuple != null) {
				return	tuple.scanVal;
			}
			return	"";
		}

		public string[] mSysInfo = {
			"ModelName",
			"ManufactureName",
			"sysUpTime",
			"ipAddress",
			"PhysAddress",
			"softwareVersion"
		};

		public string[] mSysStatus = {
			"industrySystemTemperature",
			"industrySystemTemperatureUpper",
			"industrySystemTemperatureLower",
			"industryAmbientTemperature",
			"industryAmbientTemperatureUpper",
			"industryAmbientTemperatureLower",
			"industryAmbientHumidity",
			"industryAmbientHumidityUpper",
			//"industryAmbientHumidityLower",
			"industryPowerUpper",
			"industryPowerType",
			"industryPowerIn",
			"industrySystemCurrent",
			"industryMasterV1Voltages",
			"industrySlaveV2Voltages",
			"industrySystemPower"
		};

		public string[] mPortStatus = {
			"ifNumber",
			"ifIndex",
			"ifDescr",
			"ifAdminStatus",
			"ifOperStatus",
			"ifSpeed",
			"ifInOctets",
			"ifOutOctets"
		};

		public string[] mPoeStatus = {
			"poeAdmin",
			"operStatus",
			"poeClass",
			"poeVoltage",
			"poePower",
			"poeCurrent"
		};

		public string[] mDdmStatus = {
			"sfpDeviceName",
			"sfpConnectorName",
			"sfpEncodingCode",
			"sfpBitRate",
			"sfpTransmitDistance",
			"sfpLaserWaveLength",
			"sfpTemmperature",
			"sfpVoltage",
			"sfpTxBias",
			"sfpTxPower",
			"sfpRxPower"
		};

		private void	DispScanOids(string kind) {
			switch(kind) {
			case "SysInfo":
				tb_sys_name.Text	= GetValue4Tuple("ManufactureName");
				tb_sys_uptime.Text	= GetValue4Tuple("sysUpTime");
				mtb_sys_addr.Text	= GetValue4Tuple("ipAddress");
				tb_sys_mac.Text		= GetValue4Tuple("PhysAddress");
				tb_version.Text		= GetValue4Tuple("softwareVersion");
				tb_used_ram.Text	= GetValue4Tuple("ManufactureName");
				break;

			case "SysStatus":
				tb_sys_temp.Text	= GetValue4Tuple("industrySystemTemperature");
				tb_sys_up_temp.Text = GetValue4Tuple("industrySystemTemperatureUpper");
				tb_sys_dn_temp.Text = GetValue4Tuple("industrySystemTemperatureLower");
				tb_env_temp.Text	= GetValue4Tuple("industryAmbientTemperature");
				tb_env_up_temp.Text = GetValue4Tuple("industryAmbientTemperatureUpper");
				tb_env_dn_temp.Text = GetValue4Tuple("industryAmbientTemperatureLower");
				tb_env_hum.Text		= GetValue4Tuple("industryAmbientHumidity");
				tb_env_up_hum.Text	= GetValue4Tuple("industryAmbientHumidityUpper");
					//tb_env_dn_hum.Text = GetValue4Tuple("industryAmbientHumidityLower");
				tb_power_up.Text	= GetValue4Tuple("industryPowerUpper");
				tb_power_type.Text	= GetValue4Tuple("industryPowerType");
				tb_power_in.Text	= GetValue4Tuple("industryPowerIn");
				tb_sys_current.Text = GetValue4Tuple("industrySystemCurrent");
				tb_master_vol.Text	= GetValue4Tuple("industryMasterV1Voltages");
				tb_slave_vol.Text	= GetValue4Tuple("industrySlaveV2Voltages");
				tb_sys_power.Text	= GetValue4Tuple("industrySystemPower");
				break;
			}
		}

		public	void	TestSnmp() {
			/*
			// SNMP 타겟 (장치의 IP 주소)
			string targetIp = "192.168.192.168";

			// SNMP 커뮤니티 문자열 (일반적으로 "public" 또는 "private")
			string community = "public";

			// OID (SNMP에서 정보를 가져올 식별자)
			string oid = ".1.3.6.1.2.1.1.3.0"; // 장치의 시스템 설명 (sysDescr)

			// SNMP Agent 설정
			SimpleSnmp snmp = new SimpleSnmp(targetIp, community);

			if (!snmp.Valid) {
				Console.WriteLine("SNMP 타겟이 유효하지 않습니다.");
				return;
			}
			*/
			// list.Add(".1.3.6.1.4.1.12284.5.6.3.0");
			//Dictionary<Oid, AsnType> result = mSnmp.Get(SnmpVersion.Ver1, new string[] { ".1.3.6.1.2.1.1.3.0" });
			//Dictionary<Oid, AsnType> result = mSnmp.Get(SnmpVersion.Ver1, new string[] { ".1.3.6.1.4.1.12284.5.6.3.0" });

			// port
			//string oid = ".1.3.6.1.2.1.2.2.1.2.2001";
			string oid = ".1.3.6.1.2.1.2.1.0";
			//string oid = ".1.3.6.1.4.1.12284.5.2.1.1.8.2001";
			//string oid = ".1.3.6.1.4.1.12284.5.2.1.1.8.2001";
			//string oid = ".1.3.6.1.4.1.12284.5.2.1.1.8.2001";
			//string oid = ".1.3.6.1.4.1.12284.5.2.1.1.8.2001";
			Debug.WriteLine(oid.Substring(0, oid.LastIndexOf(".")));


			Dictionary<Oid, AsnType> result = mSnmp.Get(SnmpVersion.Ver1, new string[] { oid });
			//Dictionary<Oid, AsnType> result = mSnmp.Get.GetBulk().Get(SnmpVersion.Ver1, new string[] { oid });

			Dictionary<Oid, AsnType> test_retv = mSnmp.Get(SnmpVersion.Ver1, new string[] { tb_test_oid.Text });
			if (test_retv == null) return;
			foreach (KeyValuePair<Oid, AsnType> items in test_retv) {
				Console.WriteLine("{0} ,  {1}", items.Key, items.Value);
				tb_test_val.Text = items.Value.ToString();
			}

			Debug.WriteLine("");
		}


		public  void    DispInfo() {

			lv_net_1.Items.Clear();
			for (int i = 1; i < TotPortNum + 1; i++) {
				ListViewItem item = new ListViewItem(i.ToString());
				item.SubItems.Add(i.ToString());
				item.UseItemStyleForSubItems = false;
				item.BackColor = Color.Red;
				item.Tag = new ItemData(0);
				lv_net_1.Items.Add(item);
			}

		/*
			cb_system_kind.Text	= dInfo.type;
			tb_uptime.Text	= $"{dInfo.groupNm}";
			tb_system_nm.Text   = dInfo.name;
			cb_is_dumy.Checked	= dInfo.isDumy;
			mtb_addr.Text		= dInfo.addr;
			cb_check_type.Text  = dInfo.checkType;
			tb_check_port.Text  = dInfo.checkPort.ToString();
			cb_conn_type.Text	= dInfo.connType;
			tb_conn_port.Text	= dInfo.connPort.ToString();

			tb_desc.Text        = dInfo.desc;
			*/
		}

		private void bt_scan_Click(object sender, EventArgs e)
        {
			TestSnmp();
			//ScanOids("SysInfo");
		}

		private void bt_close_Click(object sender, EventArgs e)
        {
			Close();
		}

		private void DeviceDialog_Shown(object sender, EventArgs e) {
			tb_sys_name.Focus();
		}

		private void bt_set_snmp_Click(object sender, EventArgs e) {
			SnmpSetDialog setDialog = new SnmpSetDialog();
			setDialog.dInfo = dInfo;
			setDialog.ShowDialog();
		}

		private class ItemData {
			public	int		level	{ get; set; }
			public	Color	color	{ get; set; }
			//public	Brush	Brush	{ get; }

			public ItemData(int level) {
				this.level = level;
			}
		}

		private void lv_net_1_DrawItem(object sender, DrawListViewItemEventArgs e) {
			Debug.WriteLine(".. ");
			var item	= e.Item;
			var bounds	= item.Bounds;

			var data = item.Tag as ItemData;
			var text = item.Text;

			var g = e.Graphics;
			g.Clip = new Region(bounds);

			switch(data.level) {
				case 0:
					data.color = Color.White;
					break;
				case 1:
					data.color = Color.DodgerBlue;
					break;
				case 2:
					data.color = Color.Yellow;
					break;
			}
			System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Black);
			Size size = new Size(bounds.Width - 1, bounds.Height - 1);
			g.DrawRectangle(myPen, new System.Drawing.Rectangle(bounds.Location, size));

			g.FillRectangle(new SolidBrush(data.color), new System.Drawing.Rectangle(bounds.X + 1, bounds.Y + 1, bounds.Width - 2, bounds.Height - 2));

			SizeF str_size = g.MeasureString(text, item.Font);
			int x = (int)((bounds.Width - str_size.Width) / 2);
			int y = (int)((bounds.Height - str_size.Height) / 2);
			bounds.Offset(x+0, y + 2);

			g.DrawString(text, item.Font, Brushes.Black, bounds);
		}

		private void button5_Click(object sender, EventArgs e) {
			DispInfo();
		}

		private void tabPage4_Click(object sender, EventArgs e) {
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
			int current = (sender as TabControl).SelectedIndex;
			Debug.WriteLine(current);
			switch (current) {
				case 3:
					ScanOids("SysStatus");
					break;
				case 0:
					ScanArrayOids("PortStatus", lv_port_status);
					break;
				case 1:
					ScanArrayOids("DdmStatus", lv_ddm_status);
					break;
				case 2:
					ScanArrayOids("PoeStatus", lv_poe_status);
					break;
			}
		}

	}
}
