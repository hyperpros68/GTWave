using Antlr.Runtime.Tree;
using AnyBoBu;
using AnyBoBu.dialog;
using AnyBoBu.info;
using AnyBoBu.utils;
using AnyLosk.widget;
using Awool.info;
using Awool.library;
using BoBuAI.info;
using GTWave.gui;
using GTWave.IconNodes;
using GTWave.info;
using GTFinder;
using HyperBase;
using iTextSharp.text.pdf.draw;
using iTextSharp.text.pdf;
using MindFusion.Diagramming;
using MindFusion.Diagramming.WinForms;
using MindFusion.Svg;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Windows.Media;
using static Community.CsharpSqlite.Sqlite3;
using UserInfo = AnyBoBu.info.UserInfo;
using iTextSharp.text;
using System.util;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static OpenQA.Selenium.BiDi.Modules.Session.ProxyConfiguration;
using GTWave.Properties;
using System.Text.RegularExpressions;
using ceTe.DynamicPDF.Printing;
using Aspose.CAD.FileFormats.Cgm.Commands;
using System.Net.NetworkInformation;
using Microsoft.Win32;

/*
 * ----------------------------------------------------------------------------
장비 등록 목록 또는 아이콘 선택후 오른쪽마우스 클릭
  - 장비 정보 수정 ( 시스템 등록 화면 팝업)
    장비 삭제
  - 장비 상태 정보 보기
  - 장비 접속 
     WEB(https or http)
     SSH접속(Teraterm, Putty와 같은외부 프로그램 필요함): 후순위로 추가
  - 시스템 체크( Ping or Tcping Test) : tcping은 장비추가시 등록된 포트번호로 체크  
--------------------------------------------------------------------------------------------------------------------
   4-9 무선 연결 선 자동으로 그리기
        무선 연결정보에서 BSSID 이용하여 무선 연결 선 자동으로 그리기 
         ( 기능 활성화 무선과 무선 수동으로 그린 선 자동 삭제, 스위치와 무선을 연결한 선은 삭제 안함)
            1) 무선동작모드 : Access Point(AP), Access Point_WDS(AP_WDS)인지 확인
            2) AP, AP_WDS의 BSSID 확인
            3) 무선동작모드 Station, Station_WDS 확인한 후 연결 BSSID확인
            4) Station, Station_WDS의 BSSID와 같은 AP, AP_WDS와 무선 선 연결
             
         자동 선그리기 체크 주기 (Default : 10sec)
 */

namespace Awool
{
	public partial class MainFormV1 : Form {
		static	readonly HttpClient httpClient = new HttpClient();
		static	public string 	trans_result	= "";

		public	EmailInfo	mEmailInfo 	= null;

		public	UserInfo	mUserInfo 	= null;
		public	DeviceInfo	mDeviceInfo 	= null;
		public	SystemInfo	mSystemInfo 	= null;
		public	ProfilInfo	profilInfo 	= null;

		public	string 		mSystemMode 	= "add";

		// ----------------------- for Network diagram 
		private System.Drawing.Color mLinkColor = System.Drawing.Color.Black;
		private int mSegment = 2;
		private System.Drawing.Drawing2D.DashStyle mLinkStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
		private float mLinkThick = 0.25f;
		private int mLinkDirect = 0; // 0: None, 1: Only, 2: Both
		private System.Drawing.Image mBackgroundBkImage = null;
		private string mBkImagePath = "";
		// ----------------------- for Network diagram 

		// ----------------------- for Status Monitoring
		private bool isMonitoring = false;
		private Thread monitoringThread = null;
		private Dictionary<string, int> dictFailCount = new Dictionary<string, int>();
		public List<DeviceInfo> mTotDevice = new List<DeviceInfo>();

		private int monitorInterval 	= 5000;
		private int monitorTimeout 		= 2000;
		private int monitorCheckTimes 	= 5;
		private int monitorPacketSize 	= 32;

		private System.Windows.Forms.Timer monitoringAnimationTimer;
		private float gradientOffset = 0;
		// ----------------------- for Status Monitoring
		private System.Windows.Forms.Timer statusTimeTimer;

		private string curWorkPath = "C:\\";


		private iTextSharp.text.Font fontS;
		private Paragraph lineSeparator;
		private static bool isScan = false;
		private static string scanIp = "";
		private static int scanPort = 80;

		private static string scan_id = "";
		private static string scan_pw = "";

		private static string mSaveFile = "";
		private static StreamWriter mSaveHandle = null;
		private static bool mHeadWrite = false;

		private static IWebDriver driver = null;
		private Thread scanThread = null;


		private TreeNode mCurGroupNode = null;
		private ToolTip btnToolTip = null;

		public MainFormV1() {
			InitializeComponent();
			this.statusStrip1.BringToFront();
			this.sc_main.SendToBack();
			this.menuStrip1.SendToBack();
			if (Global.mAppIcon != null)
			{
				this.Icon = (System.Drawing.Icon)Global.mAppIcon.Clone();
			}
			this.MaximizedBounds = Screen.FromControl(this).WorkingArea;
			Microsoft.Win32.SystemEvents.UserPreferenceChanged += (s, e) => {
				this.MaximizedBounds = Screen.FromControl(this).WorkingArea;
			};
			sc_main_Resize(null, null);

			// overview1 Border Fix
			Panel ovPanel = new Panel();
			ovPanel.BorderStyle = BorderStyle.FixedSingle;
			ovPanel.Bounds = overview1.Bounds;
			ovPanel.Anchor = overview1.Anchor;
			
			//overview1.Parent.Controls.Add(ovPanel);
			panel3.Controls.Add(ovPanel);
			ovPanel.Controls.Add(overview1);
			overview1.Dock = DockStyle.Fill;
			overview1.FitAll = true;


			// ------------ Diagram 초기화 ----------
			main_diagram.MeasureUnit = MindFusion.Diagramming.MeasureUnit.Pixel;
			main_diagram.Bounds = new RectangleF(0, 0, 800, 600);
			main_diagram.AutoResize = AutoResize.None;
			cb_link_style.SelectedIndex = 3;
			cb_line_thick.SelectedIndex = 0;
			cb_line_thick.SelectedIndexChanged += cb_line_thick_SelectedIndexChanged;
			cb_link_style.SelectedIndexChanged += cb_link_style_SelectedIndexChanged;
			cb_line_direct.SelectedIndexChanged += cb_line_direct_SelectedIndexChanged;
			tb_diagram_w.TextChanged += tb_diagram_w_TextChanged;
			tb_diagram_h.TextChanged += tb_diagram_h_TextChanged;

			bt_link_color.BackColor = mLinkColor;

			tb_diagram_w.Text = main_diagram.Bounds.Width.ToString();
			tb_diagram_h.Text = main_diagram.Bounds.Height.ToString();

			// [수정] 이미 생성자 초반에 Global.mAppIcon을 통해 설정되므로 중복 설정 제거 (잘못된 아이콘 추출 방지)
			// try { this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath); } catch { }

			// 애니메이션 타이머 초기화
			monitoringAnimationTimer = new System.Windows.Forms.Timer();
			monitoringAnimationTimer.Interval = 50; 
			monitoringAnimationTimer.Tick += monitoringAnimationTimer_Tick;

			// [추가] 가로형 커스텀 줌 컨트롤러 이벤트 바인딩
			this.dv_netview.ZoomFactorChanged += dv_netview_ZoomFactorChanged;

			// [추가] 실시간 상태 표시 시간 타이머 초기화
			statusTimeTimer = new System.Windows.Forms.Timer();
			statusTimeTimer.Interval = 1000; // 1초
			statusTimeTimer.Tick += statusTimeTimer_Tick;
			statusTimeTimer.Start();
		}

		// [추가] 가로형 커스텀 줌 컨트롤러 이벤트 핸들러
		private void dv_netview_ZoomFactorChanged(object sender, EventArgs e) {
			try {
				int zoomVal = (int)Math.Round(this.dv_netview.ZoomFactor);
				this.lbl_zoom.Text = zoomVal + "%";
				if (zoomVal >= this.track_zoom.Minimum && zoomVal <= this.track_zoom.Maximum) {
					this.track_zoom.Value = zoomVal;
				}
			} catch { }
		}

		private void track_zoom_Scroll(object sender, EventArgs e) {
			try {
				this.dv_netview.ZoomFactor = this.track_zoom.Value;
			} catch { }
		}

		private void btn_zoom_out_Click(object sender, EventArgs e) {
			try {
				float step = 10f;
				float newZoom = (float)Math.Max(this.track_zoom.Minimum, this.dv_netview.ZoomFactor - step);
				this.dv_netview.ZoomFactor = newZoom;
			} catch { }
		}

		private void btn_zoom_in_Click(object sender, EventArgs e) {
			try {
				float step = 10f;
				float newZoom = (float)Math.Min(this.track_zoom.Maximum, this.dv_netview.ZoomFactor + step);
				this.dv_netview.ZoomFactor = newZoom;
			} catch { }
		}

		private void monitoringAnimationTimer_Tick(object sender, EventArgs e) {
			if (!isMonitoring) {
				monitoringAnimationTimer.Stop();
				return;
			}

			gradientOffset += 5;
			if (gradientOffset > bt_status_mon.Width) gradientOffset = 0;

			int w = bt_status_mon.Width;
			int h = bt_status_mon.Height;
			if (w <= 0 || h <= 0) return;

			Bitmap bmp = new Bitmap(w, h);
			using (Graphics g = Graphics.FromImage(bmp)) {
				// 움직이는 효과를 위해 그려지는 범위를 조정함
				using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
					new System.Drawing.Rectangle((int)gradientOffset - w, 0, w * 2, h),
					System.Drawing.Color.DeepSkyBlue,
					System.Drawing.Color.RoyalBlue,
					0f)) {
					brush.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
					g.FillRectangle(brush, 0, 0, w, h);
				}
			}

			// 기존 이미지 교체 전 Dispose (메모리 누수 방지)
			var oldImg = bt_status_mon.BackgroundImage;
			bt_status_mon.BackgroundImage = bmp;
			if (oldImg != null) oldImg.Dispose();
		}

		private void sc_main_Resize(object sender, EventArgs e) {
			pb_panel_left.Left = sc_context.Panel1.Width + 6;
			pn_top_info.Left = pb_panel_left.Left + pb_panel_left.Width + 10;
			sc_main.SplitterDistance = pb_drawer.Height + 14;
			//sc_mem_list.SplitterDistance = tb_mem_search.Height + 6;
		}

		private void MainFormV1_Load(object sender, EventArgs e) {
			// [수정] 아이콘 강제 재설정 (작업표시줄 아이콘 깨짐 방지)
			if (Global.mAppIcon != null)
			{
				this.Icon = null; // 한번 초기화 후 재설정
				this.Icon = (System.Drawing.Icon)Global.mAppIcon.Clone();
			}
			this.MaximizedBounds = Screen.FromControl(this).WorkingArea;
			WindowState = FormWindowState.Maximized;

			try
			{
				//bt_finder.BackgroundImage = global::GTWave.Properties.Resources.search;
				//bt_form_ncd.BackgroundImage = global::GTWave.Properties.Resources.network;
				//pb_full_screen.BackgroundImage = global::GTWave.Properties.Resources.fullscreen;
				bt_status_mon.BackgroundImage = global::GTWave.Properties.Resources.monitoring;
				bt_status_mon.Text = ""; // 텍스트 대신 아이콘 사용

				bt_finder.BackColor = System.Drawing.Color.Transparent;
				//bt_form_ncd.BackColor = System.Drawing.Color.Transparent;
				pb_full_screen.BackColor = System.Drawing.Color.Transparent;
				bt_status_mon.BackColor = System.Drawing.Color.Transparent;

				btnToolTip = new ToolTip();
				btnToolTip.SetToolTip(bt_finder, "장비 찾기");
				//btnToolTip.SetToolTip(bt_form_ncd, "구성도 관리");
				btnToolTip.SetToolTip(pb_full_screen, "전체 화면");
				btnToolTip.SetToolTip(bt_status_mon, "상태 감시");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Button Image Load Error: " + ex.Message);
			}

			tv_group.Nodes.Clear();
			LoadTree(tv_group, "group.mvia");

			if (tv_group.Nodes.Count == 0)
			{
				TreeNode defaultNode = tv_group.Nodes.Add("전체 그룹");
				GroupInfo defaultGroup = new GroupInfo(defaultNode.Text);
				defaultNode.Tag = defaultGroup;
				defaultGroup.node = defaultNode;
			}

			ProgressForm.Start();

			LoadTotalDevices();
			RefreshGroup();
			RefreshSystem();

			mCurGroupNode = tv_group.Nodes[0];
			string group_name = GetNodePath(mCurGroupNode);
			DispDeviceList(group_name);
			
			cb_view_mode.SelectedIndex = 0; // 이름으로 보기 (기본)
			
			// 멤버 리스트
			//RefreshMember();

			//한글 폰트를 읽어온다.
			iTextSharp.text.pdf.BaseFont bf = iTextSharp.text.pdf.BaseFont.CreateFont(@"C:\Windows\Fonts\malgun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
			//Font font = new Font(bf, 12, Font.BOLD | Font.UNDERLINE, CMYKColor.BLACK);
			fontS = new iTextSharp.text.Font(bf, 14.0f);
			fontS.SetStyle(1);
			fontS.SetColor(0, 0, 0);

			lineSeparator = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, CMYKColor.BLACK, Element.ALIGN_LEFT, 1)));
			// Set gap between line paragraphs.
			lineSeparator.SetLeading(0.5F, 0.5F);

			DiagramInit();
			LoadConfig();

			// 구성도 자동 로드
			try {
				string defaultMfPath = System.IO.Path.Combine(Global.mAppPath, @"..\data\default.mf");
				if (System.IO.File.Exists(defaultMfPath)) {
					dv_netview.LoadFromFile(defaultMfPath);

					// 로드 후 모든 노드의 테두리 색상 업데이트
					foreach (DiagramNode node in main_diagram.Nodes) {
						UpdateNodeAppearance(node);
						UpdateNodeLabel(node); // [추가] 라벨 위치 및 텍스트 업데이트 강제 실행
					}
					foreach (DiagramLink link in main_diagram.Links) {
						link.ShadowOffsetX = 0;
						link.ShadowOffsetY = 0;
					}
				}
			} catch (Exception ex) {
				Console.WriteLine("구성도 로드 실패: " + ex.Message);
			}

			tb_group_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		

			scanIp = cb_ip.Text;
			int.TryParse(tb_port.Text, out int port);
			scanPort = port;

			DispClear();

			ProgressForm.Close(this);

			// [추가] 폼이 완전히 표시된 후 아이콘 다시 한 번 강제 설정
			this.Shown += (s, ev) => {
				if (Global.mAppIcon != null) this.Icon = (System.Drawing.Icon)Global.mAppIcon.Clone();
			};
		}

		public void DispClear() {
			gb_device0.Text = "";
			lb_g_bssid_0.Text = "";
			lb_g_ssid_0.Text = "";
			lb_g_sec_0.Text = "";
			lb_g_freq_0.Text = "";
			lb_g_mode_0.Text = "";

			gb_device1.Text = "";
			lb_g_bssid_1.Text = "";
			lb_g_ssid_1.Text = "";
			lb_g_sec_1.Text = "";
			lb_g_freq_1.Text = "";
			lb_g_mode_1.Text = "";
		}

		public class AssocInfo {
			public string ssid;
			public string mac;
			public string signal;
			public string sigChain;
			public string rxRate;
			public string txRate;
			public string txCcq;
		}

		public Dictionary<string, AssocInfo> list = new Dictionary<string, AssocInfo>();

		public	void	DispDeviceList(string groupNm) {
			tb_group_title.Text = $"그룹 : {groupNm.Replace("|", " -> ")}";
			var results = GlobalHelpers.mDeviceTb.Query()
				.Where(x => x.groupNm.StartsWith(groupNm))
				//				.OrderBy(x => x.groupNm)
				.OrderBy(x => x.name)
				//.Select(x => new { x.site, NameUpper = x.site.ToUpper() })
				//.Limit(10)
				.ToList();

			lv_device_list.Items.Clear();
			foreach (var device in results) {
				//Debug.WriteLine(device.name);
				lv_device_list.Items.Add(device.getItem());
			}
		}

		private void	RefreshSystem() {

			tb_system_name.Text = "";
			tb_system_spec.Text = "";
			tb_system_desc.Text = "";
			pb_system_image.Image = global::GTWave.Properties.Resources.no_image;

			lv_system.Items.Clear();

			var results = GlobalHelpers.mSystemTb.Query()
				//.Where(x => x.groupName.Equals(group_name))
				.OrderBy(x => x.name)
				//.Select(x => new { x.site, NameUpper = x.site.ToUpper() })
				//.Limit(10)
				.ToList();

			// [수정] 디자이너에서 shapeList 컨트롤이 삭제되었으므로 관련 코드 주석 처리 및 null 전달
			// shapeList.ClearNodes();
			foreach (var system in results) {
				//Debug.WriteLine(system.name);
				lv_system.Items.Add(system.getItem());
				try {
					system.image = System.Drawing.Image.FromFile(system.imagePath);
				} catch {
				}

				//user.dispListView(lv_user_list);
				AddSystemNode(null, system);
			}

			if (lv_system.Items.Count > 0)
			{
				lv_system.Items[0].Selected = true;
				lv_system.Items[0].Focused = true;
				lv_system.EnsureVisible(0);
			}
		}

		private void AddSystemNode(MindFusion.Diagramming.WinForms.NodeListView shapeList, SystemInfo system) {

			ShapeNode shapeNode = new ShapeNode(main_diagram);
			//shapeNode.SetBounds(nodeBounds, false, false);

			//SvgNode node = new SvgNode(main_diagram);
			//SvgContent content = new SvgContent();
			//content.LoadImage("../images/Pizza_Pepperoni.svg", nodeBounds);

			shapeNode.Image = system.image;
			shapeNode.Transparent = true;

			var label = shapeNode.AddLabel(system.name);
			label.Font = new System.Drawing.Font("Consolas", 11F, FontStyle.Italic);
			label.SetEdgePosition(2, 0, 1.8f);

			System.Drawing.Rectangle nodeBounds = new System.Drawing.Rectangle(1, 3, 20, 20);
			shapeNode.SetRect(nodeBounds, false);

			if (shapeList != null) {
				shapeList.AddNode(shapeNode);
			}
		}

		private void RefreshGroup() {

			/*
            tv_group.Nodes.Clear();

			TreeNode node1 = tv_group.Nodes.Add("group 1");
			GroupInfo info1 = new GroupInfo(node1.Text);
			node1.Tag   = info1;
			info1.node  = node1;

			TreeNode node2 = tv_group.Nodes.Add("group 2");
			GroupInfo info2 = new GroupInfo(node2.Text);
			node2.Tag   = info2;
			info2.node  = node2;

			TreeNode node3 = tv_group.Nodes.Add("group 3");
			GroupInfo info3 = new GroupInfo(node3.Text);
			node3.Tag   = info3;
			info3.node  = node3;
            */
try {
				//string sql = EmailInfo.Query4Select(null);
				//MySqlCommand command = new MySqlCommand(sql, Global.mMySQL.mysql);
				//table = command.ExecuteReader();
				/*
                lv_email_info.Items.Clear();
                while (table.Read()) {
                    ListViewItem item = new ListViewItem();
                    EmailInfo info = new EmailInfo("");
                    info.setInfo(table);

                    item.Tag = info;
                    item.Text = table["E_IDX"].ToString();
                    item.SubItems.Add(table["KIND"].ToString());
                    item.SubItems.Add(table["EMAIL"].ToString());
                    item.SubItems.Add(table["NAME"].ToString());
                    item.SubItems.Add(table["NICK"].ToString());
                    item.SubItems.Add(table["PHONE"].ToString());
                    item.SubItems.Add(table["RECV_OK"].ToString());
                    item.SubItems.Add(table["VALID"].ToString());
                    item.SubItems.Add(table["REGDATE"].ToString());
                    item.SubItems.Add(table["BIGO"].ToString());

                    lv_email_info.Items.Add(item);
                }
                */
				//table.Close();
			} catch { }
		}

		private void lv_device_list_MouseDoubleClick(object sender, MouseEventArgs e) {
			var senderList = (ListView)sender;
			if (senderList.SelectedItems.Count > 0) {
				ListView.SelectedListViewItemCollection items = senderList.SelectedItems;
				ListViewItem item = items[0];
				DeviceInfo info = (DeviceInfo)(item.Tag);

				DeviceDialog dialog = new DeviceDialog(info);
				//dialog.dInfo = (DeviceInfo)(item.Tag);
				dialog.mViewMode = "fix";
				dialog.mForm	= this;
				//form.setMemberInfo(mInfo);
				dialog.ShowDialog();

				string group_name = GetNodePath(mCurGroupNode);
				DispDeviceList(group_name);
			}
		}

		private void lv_device_list_SelectedIndexChanged(object sender, EventArgs e) {
			/*
            ListView list = (ListView)sender;
            if (list.SelectedItems.Count == 0)
                return;

            ListViewItem item = list.SelectedItems[0];
            memberInfo = (UserInfo)(item.Tag);

            RefreshGoods(memberInfo);
            //RefreshSuzip(memberInfo);

            //SaleMemberSale(memberInfo.mMemIdx, dtp_member_s_date.Value.ToString("yyyy-MM-dd"), dtp_member_e_date.Value.ToString("yyyy-MM-dd"));
            */
		}

		private void pb_drawer_Click(object sender, EventArgs e) {
			if (sc_context.SplitterDistance > sc_context.Panel1MinSize)
				sc_context.SplitterDistance = sc_context.Panel1MinSize;
			else sc_context.SplitterDistance = 300;
		}

		private void sc_context_Panel1_Resize(object sender, EventArgs e) {
			sc_main_Resize(null, null);
		}

		private void pb_panel_left_Click(object sender, EventArgs e) {
			if (sc_body.Panel1Collapsed) sc_body.Panel1Collapsed = false;
			else sc_body.Panel1Collapsed = true;
		}

		private void pb_panel_right_Click(object sender, EventArgs e) {
			if (sc_body.Panel2Collapsed) sc_body.Panel2Collapsed = false;
			else sc_body.Panel2Collapsed = true;
		}

		private void bt_member_Click(object sender, EventArgs e) {
		}

		private void bt_gen_table_Click(object sender, EventArgs e) {
			//ProcUtil.run_static(@"C:\AnyCrawl\exec", "BoBuAI.bat");
			//ProcUtil.run_static(@"C:\AnyCrawl\exec", "BBTrans.bat");
			ProcUtil.run_static(@"C:\AnyCrawl\exec", "BuyMacro.bat");
			//ProcUtil.run_static(@"C:\AnyCrawl\exec", "BBPickBot.bat");
			//ProcUtil.run_static(@"C:\AnyCrawl\exec", "GenTable.bat");
			//ProcUtil.run_static(@"C:\AnyCrawl\exec", "BBLookBot.bat");
		}

		static async Task Exec(string url) {
			HttpClient _httpClient = new HttpClient();

			var parameters = new Dictionary<string, string>();
			var encodedContent = new FormUrlEncodedContent(parameters);

			var response = await _httpClient.PostAsync(url, encodedContent).ConfigureAwait(false);
			var content = await response.Content.ReadAsByteArrayAsync();
			Console.WriteLine(content);
			trans_result = Encoding.UTF8.GetString(content);
			Console.WriteLine(trans_result);
		}

		private void bt_pick_bot_Click(object sender, EventArgs e) {
			/*
            // 1. 키워드 선택
            string keyword = "찢어진 청바지";

            // 1. 우선 번역
            string httpUrl = "http://localhost:9091/trans?str=" + keyword;

            //Console.WriteLine($" -------- HTTPS ------------"); 
            //Test(httpUrl).GetAwaiter().GetResult();  
            // Main함수에서 await Test(httpsUrl) 사용못하므로, 이를 대신함            
            Console.WriteLine($"\n\n\n --------- HTTP ------------");
            Exec(httpUrl).GetAwaiter().GetResult();
            Console.WriteLine($" ---------- END ------------");

            if (!string.IsNullOrEmpty(trans_result)) {

                Console.WriteLine(trans_result);
                JObject obj = JObject.Parse(trans_result);
                keyword = obj.GetValue("trans").ToString();
                            */
			string pickUrl = $"http://localhost:9041/pick?site=tmall&key=keyword&val=" + "撕裂牛仔裤";

			Console.WriteLine($"\n\n\n --------- HTTP -{pickUrl}-----------");
			Exec(pickUrl).GetAwaiter().GetResult();
			Console.WriteLine($" ---------- END ------------");
			//}
		}


		// ---------------------------------------------------------------------
		//  for list view
		// ---------------------------------------------------------------------

		private void bt_gather_text_Click(object sender, EventArgs e) {
			string sourceFilePath = "C:\\Project\\TwinCity\\받은파일\\연세대120주년기념관_평면도\\옥탑02층02바닥구조평면도.dwg";

			HyperCad hyperCad = new HyperCad();
			hyperCad.load(sourceFilePath);

			//HyperCad.SearchTextInDWGAutoCADFile();
			/*
            HMTransForm dialog = new HMTransForm();

            string fix_path = tb_fix_image_path.Text;

            if (string.IsNullOrEmpty(fix_path))
            {
                MessageBox.Show("파일명을 입력해 주세요");
                return;
            }

            // 1. org_file 
            string org_file = Path.GetFileName(fix_path);
            string cnv_path = Path.GetDirectoryName(fix_path);

            //dialog.sInfo = (SuzipInfo)(item.Tag);
            dialog.init(Path.Combine(cnv_path, org_file + ".jpg"),
                Path.Combine(cnv_path, org_file + "_conv", org_file + "_conv.png"),
                Path.Combine(cnv_path, org_file + "_conv", org_file + "_info.txt"));
            //dialog.mViewMode = "fix";

            dialog.ShowDialog();
            */
		}

		private void bt_dwg2pdf_Click(object sender, EventArgs e) {
			using (Aspose.CAD.Image image = Aspose.CAD.Image.Load("C:\\Project\\TwinCity\\받은파일\\연세대120주년기념관_평면도\\지하04층기초바닥구조평면도.dwg")) {
				// PdfOptions의 인스턴스 만들기
				Aspose.CAD.ImageOptions.PdfOptions pdfOptions = new Aspose.CAD.ImageOptions.PdfOptions();

				// CAD를 PDF로 내보내기
				image.Save("result.pdf", pdfOptions);
			}
		}


		private void MainFormV1_FormClosed(object sender, FormClosedEventArgs e) {
			isScan = false;
			try {
				SaveConfig();
			} catch (Exception ex) {
				Console.WriteLine("SaveConfig 오류: " + ex.Message);
			}

			isMonitoring = false;

			// GTFinder 종료
			try {
				Process[] processes = Process.GetProcessesByName("GTFinder");
				foreach (Process p in processes) {
					p.Kill();
				}
			} catch (Exception ex) {
				Console.WriteLine("GTFinder 종료 오류: " + ex.Message);
			}

			// 정보 저장
			try {
				SaveTree(tv_group, "group.mvia");
			} catch (Exception ex) {
				Console.WriteLine("SaveTree 오류: " + ex.Message);
			}

			// 구성도 자동 저장
			try {
				string defaultMfPath = System.IO.Path.Combine(Global.mAppPath, @"..\data\default.mf");
				string dir = System.IO.Path.GetDirectoryName(defaultMfPath);
				if (!System.IO.Directory.Exists(dir)) System.IO.Directory.CreateDirectory(dir);
				dv_netview.SaveToFile(defaultMfPath, true);
			} catch (Exception ex) {
				Console.WriteLine("구성도 저장 실패: " + ex.Message);
			}

			try {
				if (System.Diagnostics.Debugger.IsAttached) {
					System.Diagnostics.Process.GetCurrentProcess().Kill();
				} else {
					Environment.Exit(0);
				}
			} catch {
				System.Diagnostics.Process.GetCurrentProcess().Kill();
			}
		}


		public void DispDevice(DeviceInfo gInfo) {
			//pb_goods_thumb_main.Load(gInfo.thumbnail);
			/*
            pb_goods_thumb_main.Image   = null;
            pb_goods_thumb_sub_0.Image  = null;
            pb_goods_thumb_sub_1.Image  = null;
            pb_goods_thumb_sub_2.Image  = null;
            pb_goods_thumb_sub_3.Image  = null;
            pb_goods_thumb_sub_4.Image  = null;
            pb_goods_thumb_sub_5.Image  = null;
            pb_goods_thumb_sub_6.Image  = null;
            pb_goods_thumb_sub_7.Image  = null;

            pb_goods_thumb_main.ImageLocation = "https:" + gInfo.thumbnail;
            int idx = 0;

            foreach (BGoodsImg img in gInfo.mImgs)
            {
                switch(idx)
                {
                    case 0:
                        pb_goods_thumb_sub_0.ImageLocation  = img.url;
                        break;
                    case 1:
                        pb_goods_thumb_sub_1.ImageLocation = img.url;
                        break;
                    case 2:
                        pb_goods_thumb_sub_2.ImageLocation = img.url;
                        break;
                    case 3:
                        pb_goods_thumb_sub_3.ImageLocation = img.url;
                        break;
                    case 4:
                        pb_goods_thumb_sub_4.ImageLocation = img.url;
                        break;
                    case 5:
                        pb_goods_thumb_sub_5.ImageLocation = img.url;
                        break;
                    case 6:
                        pb_goods_thumb_sub_6.ImageLocation = img.url;
                        break;
                    case 7:
                        pb_goods_thumb_sub_7.ImageLocation = img.url;
                        break;
                }
                //string pb_name = "pb_goods_thumb_sub_" + idx.ToString();
                //FieldInfo _typeField1 = GetType().GetField(pb_name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                //_typeField1.SetValue(this, img);

                idx++;

            }
            */
			//pb_goods_thumb_main.Image
			//Type tp = typeof(Exam);

			//pb_goods_thumb_sub_0
		}

		private void lv_keyword_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) {
			// https://link2me.tistory.com/820
			if ((e.ColumnIndex == 0)) {
				//ListView lv = (ListView)sender;
				CheckBox cck = new CheckBox();
				Text = "";
				//lv_keyword.SuspendLayout();          // 컨트롤의 레이아웃 논리를 임시로 일시 중단    
				e.DrawBackground();                     // 열 머리글의 배경색을 그리기       
				cck.BackColor = System.Drawing.Color.Transparent;
				cck.UseVisualStyleBackColor = true;     // 비주얼 스타일을 사용하여 배경을 그리면 true        
														// 컨트롤의 범위를 지정된 위치와 크기로 설정 (Left x, Top y, width, height)       
				cck.SetBounds(e.Bounds.X, e.Bounds.Y, cck.GetPreferredSize(new Size(e.Bounds.Width, e.Bounds.Height)).Width, cck.GetPreferredSize(new Size(e.Bounds.Width, e.Bounds.Height)).Width);
				// 컨트롤의 높이와 너비를 가져오거나 설정       
				cck.Size = new Size((cck.GetPreferredSize(new Size((e.Bounds.Width - 1), e.Bounds.Height)).Width + 1), e.Bounds.Height);
				cck.Location = new System.Drawing.Point(4, 0); // 왼쪽 위를 기준으로 컨트롤의 왼쪽 위의 좌표를 가져오거나 설정       
															   //lv_keyword.Controls.Add(cck);
				cck.Show();
				//cck.BringToFront();       
				Visible = true;                         // 컨트롤과 모든 해당 자식 컨트롤이 표시되면 true       
				e.DrawText((TextFormatFlags.VerticalCenter | TextFormatFlags.Left));
				cck.Click += new EventHandler(Bink);    // 컨트롤을 클릭하면 발생

				//lv_keyword.ResumeLayout(true);       // 일반 레이아웃 논리를 다시 시작   
			} else {
				e.DrawDefault = true;
			}
		}

		// 컬럼헤더에 있는 체크박스 클릭시 나머지 체크박스들도 자동 체크되도록 하는 로직
		private void Bink(object sender, System.EventArgs e) {
			//ListView lv = (ListView)sender;
			CheckBox cck = sender as CheckBox;
			/*
            for (int i = 0; i < lv_keyword.Items.Count; i++) {
                lv_keyword.Items[i].Checked = cck.Checked;
            }
            */
		}

		private void lv_keyword_DrawSubItem(object sender, DrawListViewSubItemEventArgs e) {
			e.DrawDefault = true;
		}

		private void lv_keyword_DrawItem(object sender, DrawListViewItemEventArgs e) {
			e.DrawDefault = true;
		}

		private void bt_add_suzip_Click(object sender, EventArgs e) {
			// 거래처가 선택되어 있지 않으면....
			if (lv_device_list.SelectedItems.Count < 1) {
				MessageBox.Show("판매처를 선택해 주세요.");
				return;
			}
		}

		private void lv_list_suzip_MouseDoubleClick(object sender, MouseEventArgs e) {
			var senderList = (ListView)sender;
			if (senderList.SelectedItems.Count > 0) {
				ListView.SelectedListViewItemCollection items = senderList.SelectedItems;
				ListViewItem item = items[0];
				/*
                SuzipDialog dialog = new SuzipDialog();
                dialog.mForm    = this;
                dialog.sInfo    = (SuzipInfo)(item.Tag);
                dialog.sInfo.init(memberInfo);
                dialog.mViewMode = "fix";

                dialog.ShowDialog();
                */
			}
		}


		public bool AwoolRequest(string api, NameValueCollection param) {
			/*
				try {
					WebClient myWebClient   = new WebClient();
					myWebClient.Credentials = CredentialCache.DefaultCredentials;
					myWebClient.Encoding    = Encoding.UTF8;

					Uri uri = new Uri(Const.URL_BASE + api);

					//myWebClient.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadProgressCallback);
					//myWebClient.UploadFileCompleted += new UploadFileCompletedEventHandler(ploadFileCompleted);

					byte[] response = myWebClient.UploadValues(uri, param);
					myWebClient.Dispose();

					string  retv    = HttpUtility.UrlDecode(response, Encoding.UTF8);
					Console.WriteLine("response : " + retv);

					JObject json    = JObject.Parse(retv);
					if (json != null && "0000".Equals(json["code"].ToString())) {
						var person = json["person"];
						Console.WriteLine(person.Type);

						//Console.WriteLine("book Count :" + person.Size());
						//JObject person = json["person"].;
						int count = 0;
						foreach (JProperty x in person) {
							count++;
						}

						if (person != null && count > 0) {
							if (MessageBox.Show(person.ToString() + "\n개인정보를 저장 할까요?", "기본 정보", MessageBoxButtons.YesNo) == DialogResult.Yes)
							{
								foreach (JProperty x in person)
								{
									string name = x.Name;
									JToken value = x.Value;

									switch(name) {
										case "이름":
											profilInfo.name = value.ToString();
											tb_profil_name.Text = profilInfo.name;
											break;
										case "전화번호":
											profilInfo.phone = value.ToString();
											tb_profil_phone.Text = profilInfo.phone;
											break;
										case "주소":
											profilInfo.addr1 = value.ToString();
											tb_profil_addr.Text = profilInfo.addr1;
											break;
									}
									//profilInfo.fixInfo(Global.mMySQL.mysql);
								}
							}
						}
						//RefreshProfil(true);
						//RefreshChatBrief(profilInfo);
						//RefreshChatText(profilInfo);
						return  true;
					} else {
						MessageBox.Show(json["msg"].ToString(), "에러코드 :" + json["code"].ToString());
						return  false;
					}
				} catch (Exception ex) {
					Console.WriteLine("\nResponse Exception :\n{0}", ex.ToString());
				}
				*/
			return false;
		}

		private void bt_chat_gpt_Click(object sender, EventArgs e) {
			var engine = IronPython.Hosting.Python.CreateEngine();
			var scope = engine.CreateScope();

			try {
				var source = engine.CreateScriptSourceFromFile(@"test.py");
				source.Execute(scope);

				var getPythonFuncResult = scope.GetVariable<Func<string>>("getPythonFunc");
				Console.WriteLine("def 실행 테스트 : " + getPythonFuncResult());

				var sum = scope.GetVariable<Func<int, int, int>>("sum");
				Console.WriteLine(sum(1, 2));

				//파일을 읽지 않고 스크립트를 바로작성
				var source2 = engine.CreateScriptSourceFromString(@"print('스크립트를 직접작성해 출력 테스트')");
				source2.Execute(scope);
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}

		private void bt_add_profil_Click(object sender, EventArgs e) {
		}

		private void bt_chat_upload_Click(object sender, EventArgs e) {
			/*
            if (reb_chat_text.Text.Length < 20) {
                MessageBox.Show("체팅 내용이 너무 작습니다.");
                return;
            }
            if (profilInfo == null)
            {
                MessageBox.Show("대화 프로필 상대가 정해지지 않았습니다..");
                return;
            }
            NameValueCollection param = new NameValueCollection {
                { "method"  , "hemer"},
                { "p_idx"   , profilInfo.pIdx},
                { "o_chat"  ,  Convert.ToBase64String(Encoding.UTF8.GetBytes(reb_chat_text.Text)) }
            };
            */

			//if (string.TextUtils.)
			/*
            tb_profil_profil.Text = profilInfo.profil;
            tb_profil_agent.Text = profilInfo.agent;
            tb_profil_name.Text = profilInfo.name;
            tb_profil_phone.Text = profilInfo.phone;
            tb_profil_addr.Text = profilInfo.addr1 + " " + profilInfo.addr2;
            tb_profil_memo.Text = profilInfo.memo;
            */

			/*
			if (!string.IsNullOrEmpty(tb_profil_name.Text.Trim())) {
                param.Add("name", tb_profil_name.Text.Trim());
            }
            if (!string.IsNullOrEmpty(tb_profil_phone.Text.Trim())) {
                param.Add("phone", tb_profil_phone.Text.Trim());
            }
            if (!string.IsNullOrEmpty(tb_profil_addr.Text.Trim())) {
                param.Add("addr", tb_profil_addr.Text.Trim());
            }

            if (AwoolRequest("web_woker", param)){
                MessageBox.Show("적용 완료");
            }
            */
		}

		private void lv_profil_DoubleClick(object sender, EventArgs e) {
			var senderList = (ListView)sender;
			if (senderList.SelectedItems.Count > 0) {
				ListView.SelectedListViewItemCollection items = senderList.SelectedItems;
				ListViewItem item = items[0];
				ProfilInfo info = (ProfilInfo)(item.Tag);
				/*
                RegProfilForm form = new RegProfilForm();
                form.pInfo  = info;
                form.mViewMode = "fix";

                form.ShowDialog();
                */
			}
		}

		private void lv_chat_text_MouseDoubleClick(object sender, MouseEventArgs e) {
			var senderList = (ListView)sender;
			if (senderList.SelectedItems.Count > 0) {
				ListView.SelectedListViewItemCollection items = senderList.SelectedItems;
				ListViewItem item = items[0];
				//ChatText info = (ChatText)(item.Tag);

				//reb_chat_text.Text  = info.chatText;
			}
		}

		private void bt_id_upload_Click(object sender, EventArgs e) {
			var fileContent = string.Empty;
			var filePath = string.Empty;

			using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog()) {
				openFileDialog.InitialDirectory = curWorkPath;
				openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;

				if (openFileDialog.ShowDialog() == DialogResult.OK) {
					//Get the path of specified file
					ProgressForm.Start();

					filePath = openFileDialog.FileName;
					curWorkPath = System.IO.Path.GetDirectoryName(filePath);

					//Read the contents of the file into a stream
					var fileStream = openFileDialog.OpenFile();

					using (StreamReader reader = new StreamReader(fileStream)) {
						fileContent = reader.ReadToEnd();

						string aLine = null;
						string sql = "";
						int cnt = 0;
						StringReader strReader = new StringReader(fileContent);
						while (true) {
							aLine = strReader.ReadLine();
							if (aLine != null) {
								Console.WriteLine(aLine);
								var ids = aLine.Split('@');

								if (ids.Length > 0) {
									EmailInfo eInfo = new EmailInfo("");
									eInfo.email = ids[0] + "@naver.com";
									eInfo.kind = "naver cafe";
									//eInfo.addInfo(Global.mMySQL.mysql);
									sql += "\n" + eInfo.Query4Insert();

									if (cnt++ % 1000 == 0) {
										//eInfo.addSql(Global.mMySQL.mysql, sql);
										sql = "";
									}
								}
							} else {
								if (string.IsNullOrEmpty(sql)) {
									EmailInfo eInfo = new EmailInfo("");
									//eInfo.addSql(Global.mMySQL.mysql, sql);
								}
								break;
							}
						}
					}
					ProgressForm.Close(this);
				}
			}
		}

		private void bt_form_ncd_Click(object sender, EventArgs e) {
			ProgressForm.Start();
			NetworkDiagram form = new NetworkDiagram();
			ProgressForm.Close(this);
			form.ShowDialog();
		}

		private void ExitToolStripMenuItem_add_Click(object sender, EventArgs e) {
			Debug.WriteLine("ExitToolStripMenuItem_add_Click");
			MenuItem menu = (MenuItem)sender;

			GroupDialog dlg = new GroupDialog(tv_group);
			dlg.gInfo = (GroupInfo)menu.Tag;
			dlg.mForm = this;
			dlg.ShowDialog();
		}

		private void ExitToolStripMenuItem_fix_Click(object sender, EventArgs e) {
			Debug.WriteLine("ExitToolStripMenuItem_fix_Click");

			MenuItem menu = (MenuItem)sender;
			if (menu == null) {
				MessageBox.Show("null", "noti");
				return;
			}

			if (menu.Tag == null) {
				MessageBox.Show("Tag null", "Tag noti");
				return;
			}

			GroupDialog dlg = new GroupDialog(tv_group);
			dlg.gInfo = (GroupInfo)menu.Tag;
			dlg.mViewMode = "fix";
			dlg.mForm = this;
			dlg.ShowDialog();

			string group_name = GetNodePath(mCurGroupNode);
			DispDeviceList(group_name);
		}

		private void bt_group_save_Click(object sender, EventArgs e) {
			SaveTree(tv_group, "group.mvia");
			tv_group.Nodes.Clear();
			LoadTree(tv_group, "group.mvia");
		}

		public void SaveTree(TreeView tree, string filename) {
			List<String> output = new List<string>();
			foreach (TreeNode tn in tree.Nodes) {
				AddNodeText(tn, output, false);
			}

			using (Stream file = File.Open(filename, FileMode.Create)) {
				BinaryFormatter bf = new BinaryFormatter();
				bf.Serialize(file, tree.Nodes.Cast<TreeNode>().ToList());
			}

			// 저장 후 메모리에 있는 노드들의 Tag를 다시 GroupInfo 객체로 복원
			foreach (TreeNode tn in tree.Nodes) {
				AddNodeText(tn, output, true);
			}
		}

		public void LoadTree(TreeView tree, string filename) {
			try {

				using (Stream file = File.Open(filename, FileMode.Open)) {
					BinaryFormatter bf = new BinaryFormatter();
					object obj = bf.Deserialize(file);

					TreeNode[] nodeList = (obj as IEnumerable<TreeNode>).ToArray();
					tree.Nodes.AddRange(nodeList);

					List<String> output = new List<string>();
					// TreeView의 모든 루트 노드부터 시작
					foreach (TreeNode tn in tree.Nodes) {
						AddNodeText(tn, output, true);
					}
					Debug.WriteLine(output.ToArray());
				}
			} catch { }
		}

		// Load -> true
		// Save -> false
		public void AddNodeText(TreeNode node, List<string> result, bool mode) {
			result.Add(node.Text); // 현재 노드의 텍스트 추가

			if (mode) {
				GroupInfo info = new GroupInfo(node.Text);
				info.setParse((string)node.Tag);
				node.Tag = info;
				info.node = node;
			} else {
				if (node == null || node.Tag == null) {
					Debug.WriteLine($"{node.Text}");
				}
				GroupInfo info = (GroupInfo)node.Tag;
				node.Tag = info.getString();
			}

			// 하위 노드가 있다면 재귀적으로 탐색
			foreach (TreeNode child in node.Nodes) {
				AddNodeText(child, result, mode);
			}
		}

		public string GetNodePath(TreeNode node) {
			if (node == null) return "";

			string parent_name = node.Text;
			if (node.Parent != null) {
				parent_name = GetNodePath(node.Parent) + "|" + parent_name;
				return parent_name;
			}
			return parent_name;
		}

		public void UpdateGroupPath(string oldPath, string newPath) {
			if (string.IsNullOrEmpty(oldPath) || oldPath.Equals(newPath)) return;

			var devices = GlobalHelpers.mDeviceTb.Query()
				.Where(x => x.groupNm.StartsWith(oldPath))
				.ToList();

			foreach (var device in devices) {
				// 정확한 매칭을 위해 체크: 경구가 일치하거나, 하위 경로(|로 시작)인 경우만 처리
				if (device.groupNm.Equals(oldPath) || device.groupNm.StartsWith(oldPath + "|")) {
					string suffix = device.groupNm.Substring(oldPath.Length);
					device.groupNm = newPath + suffix;
					GlobalHelpers.mDeviceTb.Update(device);
				}
			}
			LoadTotalDevices();
		}

		private void ExitToolStripMenuItem_add_device_Click(object sender, EventArgs e) {
			Debug.WriteLine("ExitToolStripMenuItem_del_Click");
			MenuItem menu = (MenuItem)sender;
			if (menu.Tag == null) {
				MessageBox.Show("그룹을 선택해 주세요.", "알림창");
				return;
			}

			GroupInfo gInfo = (GroupInfo)menu.Tag;
			if (gInfo.node == null) {
				MessageBox.Show("그룹을 선택해 주세요.", "알림창");
				return;
			}

			string group_name = GetNodePath(gInfo.node);
			DeviceInfo dInfo = new DeviceInfo(-1);

			dInfo.groupNm = group_name;
			DeviceDialog dialog = new DeviceDialog(dInfo);
			dialog.mForm = this;
			dialog.ShowDialog();

			LoadTotalDevices();
			DispDeviceList(group_name);
		}

		private void ExitToolStripMenuItem_del_Click(object sender, EventArgs e) {
			Debug.WriteLine("ExitToolStripMenuItem_del_Click");
			MenuItem menu = (MenuItem)sender;
			if (menu.Tag == null) {
				MessageBox.Show("그룹을 선택해 주세요.", "알림창");
				return;
			}

			GroupInfo gInfo = (GroupInfo)menu.Tag;
			if (gInfo.node == null) {
				MessageBox.Show("그룹을 선택해 주세요.", "알림창");
				return;
			}

			if (gInfo.node.FirstNode != null) {
				MessageBox.Show("자식 그룹을 먼저 삭제해 주세요.", "알림창");
				return;
			}

			// --- 그룹 내 장비 존재 여부 확인 및 처리 ---
			string groupNm = GetNodePath(gInfo.node);
			var devices = GlobalHelpers.mDeviceTb.Query()
				.Where(x => x.groupNm.Equals(groupNm))
				.ToList();

			if (devices.Count > 0) {
				ContextMenu delMenu = new ContextMenu();

				MenuItem m1 = new MenuItem("1. 장비를 상위 그룹으로 이동");
				m1.Click += (s, ev) => {
					string parentPath = "";
					if (gInfo.node.Parent != null) {
						parentPath = GetNodePath(gInfo.node.Parent);
					}
					MoveDevicesToGroup(devices, parentPath);
					DeleteGroupFinal(gInfo);
				};

				MenuItem m2 = new MenuItem("2. 다른 그룹으로 이동");
				m2.Click += (s, ev) => {
					List<string> allGroups = new List<string>();
					foreach (TreeNode tn in tv_group.Nodes) {
						AddNodesToList(tn, allGroups);
					}
					allGroups.Remove(groupNm); // 현재 그룹 제외

					GTFinder.GroupSelectForm gsForm = new GTFinder.GroupSelectForm(allGroups);
					if (gsForm.ShowDialog() == DialogResult.OK) {
						if (!string.IsNullOrEmpty(gsForm.SelectedGroup)) {
							MoveDevicesToGroup(devices, gsForm.SelectedGroup);
							DeleteGroupFinal(gInfo);
						}
					}
				};

				MenuItem m3 = new MenuItem("3. 장비 모두 삭제");
				m3.Click += (s, ev) => {
					if (MessageBox.Show("그룹 내 모든 장비를 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes) {
						foreach (var d in devices) {
							GlobalHelpers.mDeviceTb.Delete(d.id);
						}
						DeleteGroupFinal(gInfo);
					}
				};

				delMenu.MenuItems.Add(m1);
				delMenu.MenuItems.Add(m2);
				delMenu.MenuItems.Add(m3);

				// 마우스 클릭 위치에 팝업 메뉴 표시
				delMenu.Show(tv_group, tv_group.PointToClient(Cursor.Position));
				return;
			}

			if (MessageBox.Show("그룹 정보를 삭제합니다..", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				DeleteGroupFinal(gInfo);
			}
		}

		private void MoveDevicesToGroup(List<DeviceInfo> devices, string targetGroup) {
			foreach (var d in devices) {
				d.groupNm = targetGroup;
				GlobalHelpers.mDeviceTb.Update(d);
			}
			LoadTotalDevices();
			string groupNm = GetNodePath(mCurGroupNode);
			DispDeviceList(groupNm);
		}

		private void DeleteGroupFinal(GroupInfo gInfo) {
			tv_group.Nodes.Remove(gInfo.node);
			SaveTree(tv_group, "group.mvia");
		}

		private void tv_group_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				Console.WriteLine("tv_group_MouseDown");
				TreeView tree = (TreeView)sender;
				TreeNode node = tree.GetNodeAt(e.Location);

				ContextMenu contextMenu = new ContextMenu();
				MenuItem menuItem = new MenuItem("추가");
				if (node == null) {
					menuItem.Tag = null;
				} else {
					menuItem.Tag = node.Tag;
				}

				menuItem.Click += ExitToolStripMenuItem_add_Click;    // 메뉴에서 등록한 알람 이벤트 처리기 등록
				contextMenu.MenuItems.Add(menuItem);


				//TreeNode node = tree.GetNodeAt(e.X, e.Y);

				var hti = tree.HitTest(e.Location);
				//if (hti.Location == TreeViewHitTestLocations.PlusMinus || node == null) {
				if (hti.Location != TreeViewHitTestLocations.PlusMinus && node != null) {
					// 선택된 Node가 없을 경우

					menuItem = new MenuItem("수정");
					if (node == null) {
						menuItem.Tag = null;
					} else {
						menuItem.Tag = node.Tag;
					}
					menuItem.Click += ExitToolStripMenuItem_fix_Click;   // 메뉴에서 등록한 종료 이벤트처리기 등록
					contextMenu.MenuItems.Add(menuItem);

					menuItem = new MenuItem("삭제");
					if (node == null) {
						menuItem.Tag = null;
					} else {
						menuItem.Tag = node.Tag;
					}
					menuItem.Click += ExitToolStripMenuItem_del_Click;   // 메뉴에서 등록한 종료 이벤트처리기 등록
					contextMenu.MenuItems.Add(menuItem);

					menuItem = new MenuItem("Device 등록");
					if (node == null) {
						menuItem.Tag = null;
					} else {
						menuItem.Tag = node.Tag;
					}
					menuItem.Click += ExitToolStripMenuItem_add_device_Click;   // 메뉴에서 등록한 종료 이벤트처리기 등록
					contextMenu.MenuItems.Add(menuItem);
				}
				contextMenu.Show(this, new Point(e.X + 20, e.Y + 70));    // 마우스가 클릭된 지점에서 콘텍스트 메뉴 Show
			}
		}

		private void tv_group_AfterSelect(object sender, TreeViewEventArgs e) {
			Console.WriteLine($"{tv_group.SelectedNode.Text}");

			// Device List view
			//GroupInfo   info = (GroupInfo)e.Node.Tag;
			mCurGroupNode = e.Node;
			string group_name = GetNodePath(e.Node);
			DispDeviceList(group_name);
		}


		private void 사용자관리ToolStripMenuItem_Click(object sender, EventArgs e) {
			UserDialog dlg = new UserDialog();
			dlg.ShowDialog();
		}

		private void bt_system_add_Click(object sender, EventArgs e) {
			mSystemInfo = new SystemInfo();
			tb_system_name.Text = mSystemInfo.name;
			tb_system_spec.Text = mSystemInfo.spec;
			tb_system_desc.Text = mSystemInfo.name;
			pb_system_image.Image = global::GTWave.Properties.Resources.no_image;

			tb_system_name.Enabled = true;
			tb_system_name.Focus();

			mSystemMode = "add";
		}

		private void bt_system_image_Click(object sender, EventArgs e) {
			System.Drawing.Image image;
			System.Windows.Forms.OpenFileDialog f = new System.Windows.Forms.OpenFileDialog();
			f.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";

			if (f.ShowDialog() == DialogResult.OK) {
				System.IO.FileInfo file = new System.IO.FileInfo(f.FileName);  // Sample file.
				image = System.Drawing.Image.FromFile(f.FileName);
				pb_system_image.Image = image;


				string tPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, @"..\images", file.Name);
				// image 폴더에 qhrtk
				try {
					System.IO.File.Copy(f.FileName, tPath, true);
				} catch (Exception ee) { }
				tb_system_image_path.Text = tPath;
			}
		}

		private void bt_system_del_Click(object sender, EventArgs e) {

			if (lv_system.SelectedItems.Count > 0) {
				if (MessageBox.Show("선택하신 정보가 삭제됩니다", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes) {
					ListView.SelectedListViewItemCollection items = lv_system.SelectedItems;
					ListViewItem item = items[0];
					SystemInfo info = (SystemInfo)(item.Tag);

					//var value = new LiteDB.BsonValue(uInfo.mMemId);//id is an int parameter passed in
					GlobalHelpers.mSystemTb.DeleteMany(x => x.name.Equals(info.name));

					RefreshSystem();
				}
			} else {
				MessageBox.Show("삭제할 내용을 선택해 주세요", "알림창");
			}
		}

		private void bt_system_apply_Click(object sender, EventArgs e) {
			if (mSystemInfo == null) {
				MessageBox.Show("작업(추가, 수정)을 선택해 주세요.", "알림창");
				return;
			}

			try {
				if ("add".Equals(mSystemMode)) {
					// 같은 이름이 있는지
					var results = GlobalHelpers.mSystemTb.Query()
						.Where(x => x.name.Equals(tb_system_name.Text))
						.ToList();

					if (results.Count > 0) {
						MessageBox.Show("같은 이름이 존재 합니다. 이름을 수정해 주세요.", "알림창");
						tb_system_name.Focus();
						return;
					}

					mSystemInfo.name = tb_system_name.Text;
					mSystemInfo.spec = tb_system_spec.Text;
					mSystemInfo.desc = tb_system_desc.Text;
					mSystemInfo.imagePath = tb_system_image_path.Text;
					//pb_system_image.Image = mSystemInfo.image;

					// DB add
					GlobalHelpers.mSystemTb.Insert(mSystemInfo);

					lv_system.Items.Add(mSystemInfo.getItem());
					MessageBox.Show("정상적으로 추가 되었습니다.", "알림창");
				} else if ("fix".Equals(mSystemMode)) {
					/*
					var results = GlobalHelpers.mSystemTb.Query()
						.Where(x => x.name.Equals(tb_system_name.Text))
						.ToList();

					if (results.Count > 0) {
						MessageBox.Show("같은 이름이 존재 합니다. 이름을 수정해 주세요.", "알림창");
						tb_system_name.Focus();
						return;
					}
                    */
					mSystemInfo.spec = tb_system_spec.Text;
					mSystemInfo.desc = tb_system_desc.Text;
					mSystemInfo.imagePath = tb_system_image_path.Text;

					GlobalHelpers.mSystemTb.Update(mSystemInfo);
				}
				// Diagram에 반영
				RefreshSystem();
			} catch (Exception ex) {
				MessageBox.Show("적용이 실패 했습니다. 다시 시도해 주세요.", "알림창");
			}
		}

		private void lv_system_SelectedIndexChanged(object sender, EventArgs e) {

			ListView list = (ListView)sender;
			if (list.SelectedItems.Count == 0)
				return;

			ListViewItem item = list.SelectedItems[0];
			mSystemInfo = (SystemInfo)(item.Tag);

			tb_system_name.Text = mSystemInfo.name;
			tb_system_spec.Text = mSystemInfo.spec;
			tb_system_desc.Text = mSystemInfo.desc;
			tb_system_image_path.Text = mSystemInfo.imagePath;
			try {
				pb_system_image.Image = System.Drawing.Image.FromFile(mSystemInfo.imagePath);
			} catch (Exception ex) {
				pb_system_image.Image = global::GTWave.Properties.Resources.no_image;
			}

			// 이름은 수정을 하지 못하게
			tb_system_name.Enabled = false;
			tb_system_spec.Focus();

			mSystemMode = "fix";
		}



		//
		//
		// -------------------------------------------------------------------------
		//
		//                 Network Diagram
		//
		// -------------------------------------------------------------------------
		//
		//

		private void DiagramInit() {
			main_diagram.NodeCreated += main_diagram_NodeCreated;
			main_diagram.NodeClicked += main_diagram_NodeClicked;
			main_diagram.DrawBackground += (s, e) => {
				DrawCustomBackground(e.Graphics);
			};
			main_diagram.UndoManager.UndoEnabled = true;
			main_diagram.ShadowsStyle = ShadowsStyle.None;
			main_diagram.BackBrush = new MindFusion.Drawing.SolidBrush(System.Drawing.Color.FromArgb(170, 170, 170));
			main_diagram.BackgroundImage = new System.Drawing.Bitmap(1, 1);
			dv_netview.BackColor = System.Drawing.Color.FromArgb(170, 170, 170);
			overview1.BackColor = System.Drawing.Color.FromArgb(170, 170, 170);

			/*
			ControlNode controlNode = new ControlNode(dv_netview);
			controlNode.Bounds = new RectangleF(10, 10, 30, 30);
			controlNode.Control = new DataGrid();
			main_diagram.Nodes.Add(controlNode);
			*/

			/*
			System.Drawing.Rectangle nodeBounds = new System.Drawing.Rectangle(30, 30, 20, 20);

			SvgNode node = new SvgNode(main_diagram);
			SvgContent content = new SvgContent();
			content.LoadImage("../images/Pizza_Pepperoni.svg", nodeBounds);
			node.Content = content;
			node.Bounds = new RectangleF(10, 10, 30, 30);

			//controlNode.Control = node;
			main_diagram.Nodes.Add(node);
			*/

			/*
			string roundRect = @"
                r = Min(Width / 2, radius.X);
                MoveTo(r, 0);
                LineTo(Width - r, 0);
                ArcTo(Width, r, false, false, r, r);
                LineTo(Width, Height - r);
                ArcTo(Width - r, Height, false, false, r, r);
                LineTo(r, Height);
                ArcTo(0, Height - r, false, false, r, r);
                LineTo(0, r);
                ArcTo(r, 0, false, false, r, r);
            "; 
            Shape custom = new Shape(roundRect, "custom");

            ShapeNode shapeNode = new ShapeNode(main_diagram);
			shapeNode.Text = "asldfkj";
			shapeNode.Shape = custom;
			shapeList.AddNode(shapeNode);
            */


			/*
			Rectangle nodeBounds = new Rectangle(30, 30, 20, 20);
			SvgNode node = new SvgNode(main_diagram);
			SvgContent content = new SvgContent();
			content.LoadImage("../images/Pizza_Pepperoni.svg", nodeBounds);
			node.Content = content;
			node.Transparent = true;
			shapeList.AddNode(node);
            */

			//Rectangle nodeBounds = new Rectangle(10, 10, 20, 20);
			//var myRect = new ShapeNode(roundRect, "MyRect");

			ShapeNode shapeNode = new ShapeNode(main_diagram);
			//shapeNode.SetBounds(nodeBounds, false, false);

			//SvgNode node = new SvgNode(main_diagram);
			//SvgContent content = new SvgContent();
			//content.LoadImage("../images/Pizza_Pepperoni.svg", nodeBounds);

			/*
			shapeNode.Image = Image.FromFile("../images/btb_ok.png");
			shapeNode.Transparent = true;
			//shapeNode.Text = "asldfkj";

			//var label = shapeNode.AddLabel("Test\nGTWave");
			var label = shapeNode.AddLabel("Test\nGTWave");
			label.Font = new Font("Consolas", 11F, FontStyle.Italic);

            //    0 desigates center of top edge;
            //    1 desigates center of right edge;
            //    2 desigates center of bottom edge;
            //    3 desigates center of left edge;

			label.SetEdgePosition(2, 0, 0);
            //label.SetEdgePosition(1, 0, 0);
            //shapeNode.SetRect(nodeBounds, false);

			shapeList.AddNode(shapeNode);

            shapeList.IconSize = new Size(18, 18);
            */
		}

		public void FixDevice2Diagram(DeviceInfo newDevice, DeviceInfo device) {
			DiagramNode item = null;
			foreach (DiagramNode node in main_diagram.Nodes) {
				try {
					if (node.Tag is DeviceInfo temp) {
						// ID가 있으면 ID로 비교, 없으면 Equals(이름 등)로 비교
						if ((temp.id > 0 && temp.id == newDevice.id) || device.Equals(temp)) {
							item = node;
							break;
						}
					}
				} catch (Exception ex) { }
			}

			if (item != null) {
				item.Tag = newDevice;
				
				UpdateNodeLabel(item);
				UpdateNodeAppearance(item); // 이미지 및 테두리 업데이트
				dv_netview.Refresh();
				LoadTotalDevices();
			}
		}


		public void	DelDevice2Diagram(DeviceInfo device) {
			DiagramNode item	= null;
			DeviceInfo	temp	= null;
			foreach (DiagramNode node in main_diagram.Nodes) {
				try {
					int nodeId = -1;
					if (node.Tag is DeviceInfo devInfo) {
						temp = devInfo;
						nodeId = temp.id;
					} else if (node.Tag != null) {
						try {
							nodeId = Convert.ToInt32(node.Tag);
							temp = DeviceInfo.Load2Db(nodeId, GlobalHelpers.mDeviceTb);
						} catch { }
					}

					if (temp != null && device.Equals(temp)) {
						// 여기서 삭제를 한다....
						Debug.WriteLine($"{device.name} deleted in Diagram");
						item = node;
						break;
					}
				} catch (Exception ex) {
					Debug.WriteLine("DelDevice2Diagram logic error: " + ex.Message);
				}
			}
			if (item != null) {
				main_diagram.Nodes.Remove(item);
				GlobalHelpers.mDeviceTb.DeleteMany(x => x.id.Equals(temp.id));
				LoadTotalDevices();
			}
		}

		public	void	AddDevice2Diagram(DeviceInfo device) {

			float x = 30;
			float y = 30;
			float width = 20;
			float height = 20;

			// 중복 위치 체크 및 오프셋 적용
			while (main_diagram.GetNodeAt(new System.Drawing.PointF(x + width / 2, y + height / 2)) != null) {
				x += 10;
				y += 10;
			}

			System.Drawing.RectangleF nodeBounds = new System.Drawing.RectangleF(x, y, width, height);

			/*
			SvgNode node = new SvgNode(main_diagram);
			SvgContent content = new SvgContent();
			content.LoadImage("../images/Pizza_Pepperoni.svg", nodeBounds);
			node.Content = content;
			node.Bounds = new RectangleF(10, 10, 30, 30);

			//controlNode.Control = node;
			main_diagram.Nodes.Add(node);
			*/

			ShapeNode shapeNode = new ShapeNode(main_diagram);
			shapeNode.SetBounds(nodeBounds, false, false);
			//node.Bounds = new RectangleF(10, 10, 30, 30);
			//SvgNode node = new SvgNode(main_diagram);
			//ShapeContent content = new ShapeContent();
			//content.LoadImage("../images/Pizza_Pepperoni.svg", nodeBounds);
			SystemInfo temp = SystemInfo.Find(lv_system, device);
			if (temp != null) {
				try {
					shapeNode.Image = System.Drawing.Image.FromFile(temp.imagePath);
				} catch (Exception ex) { }
			}

			/*
			foreach (ListViewItem item in lv_system.Items) {
				if (item.Tag != null) {
					mSystemInfo = (SystemInfo)(item.Tag);
					if (mSystemInfo != null) {
						if (device.type.Equals(mSystemInfo.name)) {
							//tb_system_image_path.Text = mSystemInfo.imagePath;
							try {
								shapeNode.Image = System.Drawing.Image.FromFile(mSystemInfo.imagePath);
							} catch (Exception ex) {
							}
						}

					}
				}
			}
			*/
			// (선택사항) 노드 모양
			shapeNode.Shape = Shapes.Rectangle;  // 
			shapeNode.Transparent = false;
			shapeNode.Tag = device;
			UpdateNodeLabel(shapeNode);
			UpdateNodeAppearance(shapeNode);
			/*
			shapeNode.Brush = new MindFusion.Drawing.SolidBrush(System.Drawing.Color.LightBlue);
			System.Windows.Media.Brush brush = new System.Windows.Media.Brush(System.Drawing.Color.LightBlue);
			shapeNode.Pen = new System.Windows.Media.Pen(shapeNode.Brush, 2);
			*/
			//ImageContent content = new SvgContent();
			main_diagram.Nodes.Add(shapeNode);

			//shapeList.AddNode(shapeNode);
		}

		private void UpdateNodeLabel(DiagramNode node) {
			if (!(node.Tag is DeviceInfo device)) return;

			string text = device.name;
			if (cb_view_mode.SelectedIndex == 1) { // IP 로 보기
				text = device.addr;
			}

			// 라벨이 여러 개면 첫 번째 것만 남기고 모두 삭제 (중복 방지)
			if (node.Labels != null) {
				while (node.Labels.Count > 1) {
					node.Labels.RemoveAt(1);
				}

				if (node.Labels.Count > 0) {
					var lb = node.Labels[0];
					lb.Text = text;
					node.Text = ""; // [추가] 기본 텍스트와 겹침 방지
					lb.SetEdgePosition(2, 0.5f, 3.0f); // [수정] 6.0f -> 3.0f
					return; // 기존 라벨 업데이트 완료
				}
			}

			// 기존 라벨이 없거나 Labels가 null인 경우 새로 생성
			node.Text = "";
			var label = node.AddLabel(text);
			if (label != null) {
				label.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Italic);
				label.SetEdgePosition(2, 0.5f, 3.0f); // [수정] 6.0f -> 3.0f
			}
		}

		private void cb_view_mode_SelectedIndexChanged(object sender, EventArgs e) {
			foreach (DiagramNode node in main_diagram.Nodes) {
				UpdateNodeLabel(node);
			}
			dv_netview.Refresh();
		}

		private void main_diagram_NodeCreated(object sender, NodeEventArgs e)
		{
			UpdateNodeAppearance(e.Node);
			e.Node.ZTop(false);
		}

		private void UpdateNodeAppearance(DiagramNode node) {
			if (node is ShapeNode shapeNode) {
				shapeNode.Transparent = true;
				node.ZTop(false);
				
				// [추가] 그림자 제거
				shapeNode.ShadowOffsetX = 0;
				shapeNode.ShadowOffsetY = 0;

				if (shapeNode.Tag is DeviceInfo device) {
					if (device.isDumy) {
						shapeNode.Pen = new MindFusion.Drawing.Pen(System.Drawing.Color.Transparent, 0f);
					} else {
						shapeNode.Pen = new MindFusion.Drawing.Pen(System.Drawing.Color.SkyBlue, 0.5f);
					}

					// 이미지 업데이트
					SystemInfo sysInfo = SystemInfo.Find(lv_system, device);
					if (sysInfo != null) {
						try {
							shapeNode.Image = System.Drawing.Image.FromFile(sysInfo.imagePath);
						} catch { }
					}
				} else {
					shapeNode.Pen = new MindFusion.Drawing.Pen(System.Drawing.Color.Black, 0.5f);
				}
			}
		}
		
		private void main_diagram_NodeClicked(object sender, NodeEventArgs e) {
			if (e.MouseButton == MindFusion.Diagramming.MouseButton.Right) {
				DeviceSelectDialog dlg = new DeviceSelectDialog();
				if (dlg.ShowDialog() == DialogResult.OK) {
					DeviceInfo selected = dlg.SelectedDevice;
					if (selected != null) {
						e.Node.Tag = selected;
						
						UpdateNodeLabel(e.Node);

						// 아이콘 및 테두리 업데이트
						if (e.Node is ShapeNode shapeNode) {
							SystemInfo temp = SystemInfo.Find(lv_system, selected);
							if (temp != null) {
								try {
									shapeNode.Image = System.Drawing.Image.FromFile(temp.imagePath);
								} catch { }
							}

							UpdateNodeAppearance(shapeNode);
						}
						
						dv_netview.Refresh();
					}
				}
			}
		}

		private void	main_diagram_LinkCreated(object sender, LinkEventArgs e) {
			e.Link.Brush = new MindFusion.Drawing.SolidBrush(mLinkColor);

			int.TryParse(cb_link_segment.Text, out int outValue);
			if (outValue > 0 && outValue < 9) {
				e.Link.SegmentCount = outValue;
			}

			e.Link.Style = new DiagramLinkStyle {
				Stroke = new MindFusion.Drawing.SolidBrush(mLinkColor),
				StrokeDashStyle = mLinkStyle
			};
			e.Link.Pen = new MindFusion.Drawing.Pen(new MindFusion.Drawing.SolidBrush(mLinkColor), mLinkThick);
			e.Link.Pen.DashStyle = mLinkStyle;
			e.Link.HeadPen = new MindFusion.Drawing.Pen(new MindFusion.Drawing.SolidBrush(mLinkColor), mLinkThick);
			e.Link.ShadowOffsetX = 0;
			e.Link.ShadowOffsetY = 0;
			e.Link.ZBottom(false);

			UpdateLinkDirection(e.Link);
		}

		private void UpdateLinkDirection(DiagramLink link) {
			switch (mLinkDirect) {
				case 0: // None
					link.HeadShape = null;
					link.BaseShape = null;
					break;
				case 1: // Only
					link.HeadShape = ArrowHeads.Arrow;
					link.BaseShape = null;
					break;
				case 2: // Both
					link.HeadShape = ArrowHeads.Arrow;
					link.BaseShape = ArrowHeads.Arrow;
					break;
			}
		}

		private void cb_line_direct_SelectedIndexChanged(object sender, EventArgs e) {
			ComboBox box = (ComboBox)sender;
			mLinkDirect = box.SelectedIndex;

			foreach (DiagramLink link in main_diagram.Links) {
				if (link.Selected) {
					UpdateLinkDirection(link);
				}
			}
		}

		private void	bt_bk_image_Click(object sender, EventArgs e) {
			System.Drawing.Image File;
			System.Windows.Forms.OpenFileDialog f = new System.Windows.Forms.OpenFileDialog();
			f.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";

			if (f.ShowDialog() == DialogResult.OK) {
				File = System.Drawing.Image.FromFile(f.FileName);
				mBackgroundBkImage = File;
				mBkImagePath = f.FileName;
				main_diagram.BackgroundImage = new System.Drawing.Bitmap(1, 1);
				dv_netview.Invalidate();
				dv_netview.Refresh();
				dv_netview.ZoomToRect(main_diagram.Bounds);
			}
		}

		private void	bt_undo_Click(object sender, EventArgs e) {
			main_diagram.UndoManager.Undo();
		}

		private void	bt_redo_Click(object sender, EventArgs e) {
			main_diagram.UndoManager.Redo();
		}

		private void	bt_load_ncd_Click(object sender, EventArgs e) {

			System.Windows.Forms.OpenFileDialog f = new System.Windows.Forms.OpenFileDialog();
			f.Filter = "구성도 files (*.mf) | *.mf;";

			if (f.ShowDialog() == DialogResult.OK) {
				dv_netview.LoadFromFile(f.FileName);
				mBackgroundBkImage = main_diagram.BackgroundImage;
				main_diagram.BackgroundImage = new System.Drawing.Bitmap(1, 1);
				dv_netview.Invalidate();
				dv_netview.Refresh();
				dv_netview.ZoomToRect(main_diagram.Bounds);

				foreach (DiagramNode node in main_diagram.Nodes) {
					try {
						if (node.Tag == null) continue;
						
						int id = -1;
						if (node.Tag is int) {
							id = (int)node.Tag;
						} else {
							id = Convert.ToInt32(node.Tag);
						}

						if (id != -1) {
							//Int32.TryParse(temp, out int id);
							DeviceInfo item = DeviceInfo.Load2Db(id, GlobalHelpers.mDeviceTb);
							if (item != null) {
								node.Tag = item;
								Debug.WriteLine($"{item.name}");
							}
						} else {
							node.Tag = (DeviceInfo)null;
						}
					} catch (Exception ex) {
						Debug.WriteLine("bt_load_ncd_Click node sync error: " + ex.Message);
					}
				}

				foreach (DiagramLink link in main_diagram.Links) {
					link.ShadowOffsetX = 0;
					link.ShadowOffsetY = 0;
				}

				//File = Image.FromFile(f.FileName);
				//main_diagram.BackgroundImage = File;
			}
		}

		private void bt_save_ncd_Click(object sender, EventArgs e) {
			System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();

			saveFileDialog1.Filter = "구성도 파일|*.mf|모든 파일|*.*";
			saveFileDialog1.FilterIndex = 1;

			// 대화상자를 닫기 전에 디렉토리를 이전에 선택한 디렉토리로
			// 복원한지의 여부를 나타납니다.
			saveFileDialog1.RestoreDirectory = true;

			// 확장명을 입력하지 않을 때, 자동으로 확장자를 추가할 수 있습니다.
			saveFileDialog1.AddExtension = true;
			saveFileDialog1.DefaultExt = "mf";

			// 파일이 이미 존재하면 덮어쓰기 할지를 묻는 대화상자를 표시합니다.
			// 기본값: true
			saveFileDialog1.OverwritePrompt = true;

			// 저장할 위치의 초기 디렉토리를 설정합니다.
			// Environment.CurrentDirectory: 현재 디렉토리를 나타냅니다.
			saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;

			if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
				//this.Text = saveFileDialog1.FileName;
				// Nodes를 

				foreach (DiagramNode node in main_diagram.Nodes) {
					try {
						if (node.Tag is DeviceInfo temp) {
							node.Tag = temp.id;
						} else if (node.Tag is int id) {
							node.Tag = id;
						} else {
							node.Tag = -1;
						}
					} catch (Exception ex) {
						Debug.WriteLine("bt_save_ncd_Click node sync error: " + ex.Message);
					}
				}

				dv_netview.SaveToFile(saveFileDialog1.FileName, true);
				/*
				using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName)) {
					sw.Write(textBox1.Text);
				}
				*/
			}
		}

		private void bt_link_color_Click(object sender, EventArgs e) {
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK) {
				//MindFusion.Drawing.SolidBrush brush = new MindFusion.Drawing.SolidBrush(cd.Color);
				mLinkColor = cd.Color;
				bt_link_color.BackColor = mLinkColor;
				//main_diagram.DiagramLinkStyle.Stroke = brush;
			}
		}

		private void cb_link_style_SelectedIndexChanged(object sender, EventArgs e) {
			ComboBox box = (ComboBox)sender;
			if (box.SelectedIndex >= 0) {
				switch (box.SelectedIndex) {
					case 0:
						mLinkStyle = System.Drawing.Drawing2D.DashStyle.Solid;
						break;
					case 1:
						mLinkStyle = System.Drawing.Drawing2D.DashStyle.Dot;
						break;
					case 2:
						mLinkStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
						break;
					case 3:
						mLinkStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
						break;
					case 4:
						mLinkStyle = System.Drawing.Drawing2D.DashStyle.Dash;
						break;
				}
			}

			foreach (DiagramLink link in main_diagram.Links) {
				if (link.Selected) {
					link.Pen = new MindFusion.Drawing.Pen(new MindFusion.Drawing.SolidBrush(mLinkColor), mLinkThick);
					link.Pen.DashStyle = mLinkStyle;
					link.HeadPen = new MindFusion.Drawing.Pen(new MindFusion.Drawing.SolidBrush(mLinkColor), mLinkThick);
				}
			}
		}

		private void cb_line_thick_SelectedIndexChanged(object sender, EventArgs e) {
			if (cb_line_thick.Text != "") {
				if (float.TryParse(cb_line_thick.Text, out float val)) {
					mLinkThick = val / 4.0f;
				}

				foreach (DiagramLink link in main_diagram.Links) {
					if (link.Selected) {
						link.Pen = new MindFusion.Drawing.Pen(new MindFusion.Drawing.SolidBrush(mLinkColor), mLinkThick);
						link.Pen.DashStyle = mLinkStyle;
						link.HeadPen = new MindFusion.Drawing.Pen(new MindFusion.Drawing.SolidBrush(mLinkColor), mLinkThick);
					}
				}
			}
		}

		private void tb_diagram_w_TextChanged(object sender, EventArgs e) {
			if (int.TryParse(tb_diagram_w.Text, out int width)) {
				if (width < 10) return;
				if (width < 50) width = 50; 

				if (dv_netview.Diagram != null) {
					RectangleF currentBounds = dv_netview.Diagram.Bounds;
					dv_netview.Diagram.Bounds = new RectangleF(0, 0, (float)width, currentBounds.Height);
					
					main_ruler.Refresh();
					dv_netview.Refresh();
				}
			}
		}

		private void tb_diagram_h_TextChanged(object sender, EventArgs e) {
			if (int.TryParse(tb_diagram_h.Text, out int height)) {
				if (height < 10) return;
				if (height < 50) height = 50;

				if (dv_netview.Diagram != null) {
					RectangleF currentBounds = dv_netview.Diagram.Bounds;
					dv_netview.Diagram.Bounds = new RectangleF(0, 0, currentBounds.Width, (float)height);
					
					main_ruler.Refresh();
					dv_netview.Refresh();
				}
			}
		}

		private void expandCollapsePanel1_PanelSave(object sender, MakarovDev.ExpandCollapsePanel.RefreshEventArgs e) {
			Debug.WriteLine(e.ToString());
		}

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		private const int SW_RESTORE = 9;

		private async void bt_finder_Click(object sender, EventArgs e) {
			ProgressForm.Start();
			// 1. 이미 실행 중인지 확인
			Process[] processes = Process.GetProcessesByName("GTFinder");
			if (processes.Length > 0)
			{
				try
				{
					Process p = processes[0];
					IntPtr handle = p.MainWindowHandle;
					if (handle != IntPtr.Zero)
					{
						ShowWindow(handle, SW_RESTORE);
						SetForegroundWindow(handle);
						ProgressForm.Close(this);
						return;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}

			// GTFinder 실행 로직
			// .NET Framework 4.7.1과 .NET 8.0 간의 호환성 문제로 인해 외부 프로세스로 실행합니다.
			// 실행 파일 경로 추론 (배포 환경 및 개발 환경 고려)
			string finderPath = "";
			
			// 1. 배포 환경 (같은 폴더 또는 하위 GTFinder 폴더)
			string[] candidatePaths = {
				System.IO.Path.Combine(Application.StartupPath, "GTFinder.exe"),
				System.IO.Path.Combine(Application.StartupPath, "GTFinder", "GTFinder.exe"),
				// 2. 개발 환경 (절대 경로 또는 상대 경로)
				@"C:\GTWave\bin\GTFinder.exe" 
			};

			foreach (string path in candidatePaths) {
				if (File.Exists(path)) {
					finderPath = path;
					break;
				}
			}

			if (string.IsNullOrEmpty(finderPath)) {
				MessageBox.Show("GTFinder 실행 파일을 찾을 수 없습니다.\n빌드가 되었는지 확인해주세요.", "실행 오류");
				ProgressForm.Close(this);
				return;
			}

			try {
				//this.Enabled = false; // 다른 기능 사용 방지
				//AnyLosk.widget.ProgressForm.Start(); // 로딩 이미지 표시

				// [수정] 외부 프로세스 실행 대신 FinderForm을 직접 다이얼로그로 호출
				FinderForm finder = new FinderForm();
				finder.ExecutionArgs = "FromGTWaveMgr";

				// [추가] 그룹 리스트 전달
				List<string> groups = new List<string>();
				foreach (TreeNode node in tv_group.Nodes) {
					AddNodesToList(node, groups);
				}
				finder.GroupNames = groups;
				
				if (finder.ShowDialog() == DialogResult.OK)
				{
					// OK가 필요할 경우 처리 (현재는 종료 시 파일로 전달하는 방식 유지)
				}

				// [기존 파일 연동 로직 유지] GTFinder에서 전달한 결과 파일 확인
				string resultPath = @"C:\GTWave\cfg\GTFinder_result.cfg";
				if (File.Exists(resultPath))
				{
					string[] lines = File.ReadAllLines(resultPath);
					List<DeviceInfo> devices = new List<DeviceInfo>();
					DeviceInfo current = null;

					foreach (string line in lines)
					{
						if (line == "[DEVICE]")
						{
							if (current != null && !string.IsNullOrEmpty(current.addr)) devices.Add(current);
							current = new DeviceInfo(-1);
							continue;
						}
						
						if (current == null) current = new DeviceInfo(-1); // [호환성] 구버전 포맷 대비

						if (line.StartsWith("MAC=")) { /* MAC은 현재 컬럼이 없으므로 생략 */ }
						else if (line.StartsWith("IP=")) current.addr = line.Substring(3);
						else if (line.StartsWith("NAME=")) current.name = line.Substring(5);
						else if (line.StartsWith("MODEL=")) {
							string m = line.Substring(6);
							current.type = m.ToUpper().Contains("SWITCH") ? "스위치" : "무선";
						}
						else if (line.StartsWith("GROUP=")) current.groupNm = line.Substring(6);
					}
					if (current != null && !string.IsNullOrEmpty(current.addr)) devices.Add(current);
					
					File.Delete(resultPath); // 사용 후 삭제

					foreach (var dInfo in devices)
					{
						// 장비 등록 다이얼로그 호출
						DeviceDialog dialog = new DeviceDialog(dInfo);
						dialog.mViewMode = "add";
						dialog.mForm = this;
						dialog.ShowDialog();

						// 장비 등록 후 리스트 새로고침
						DispDeviceList(dInfo.groupNm);
					}
				}
			} catch (Exception ex) {
				MessageBox.Show("GTFinder 실행 중 오류가 발생했습니다: " + ex.Message);
			} finally {
				ProgressForm.Close(this); // 로딩 종료
				//this.Enabled = true; // 기능 복구
			}
		}

		private void AddNodesToList(TreeNode node, List<string> list) {
			list.Add(GetNodePath(node));
			foreach (TreeNode child in node.Nodes) {
				AddNodesToList(child, list);
			}
		}

		public void LoadTotalDevices()
		{
			try
			{
				mTotDevice = GlobalHelpers.mDeviceTb.Query().OrderBy(x => x.name).ToList();
				Console.WriteLine($"Total Devices Loaded: {mTotDevice.Count}");
			}
			catch (Exception ex)
			{
				Console.WriteLine("LoadTotalDevices Error: " + ex.Message);
			}
		}

		private void bt_status_mon_Click(object sender, EventArgs e)
		{
			if (isMonitoring)
			{
				isMonitoring = false;
				monitoringAnimationTimer.Stop();
				bt_status_mon.Text = "상태감시";
				if (bt_status_mon.BackgroundImage != null) {
					bt_status_mon.BackgroundImage.Dispose();
					bt_status_mon.BackgroundImage = null;
				}
				bt_status_mon.ForeColor = System.Drawing.Color.Black;
				bt_status_mon.UseVisualStyleBackColor = true;
			}
			else
			{
				LoadMonitorConfig(); // [추가] 설정 파일 로드
				LoadTotalDevices();  // 최신 장비 목록 로드
				isMonitoring = true;
				bt_status_mon.Text = "모니터링 중";
				dictFailCount.Clear();
				
				// 비동기 루프 기동 (백그라운드 실행)
				Task.Run(async () => await MonitoringLoopAsync());

				// 애니메이션 시작
				gradientOffset = 0;
				bt_status_mon.ForeColor = System.Drawing.Color.White;
				bt_status_mon.BackgroundImageLayout = ImageLayout.None; // Stretch 대신 None으로 직접 제어
				monitoringAnimationTimer.Start();
			}
		}

		private async Task MonitoringLoopAsync()
		{
			Console.WriteLine("Async Monitoring Loop Started using mTotDevice.");
			while (isMonitoring)
			{
				// Create a copy to avoid modification exceptions during iteration
				List<DeviceInfo> checkList;
				lock (mTotDevice)
				{
					checkList = new List<DeviceInfo>(mTotDevice);
				}

				var tasks = checkList.Select(async dev =>
				{
					if (!isMonitoring) return;
					if (string.IsNullOrWhiteSpace(dev.addr) || dev.addr == "0.0.0.0") return;
					if (dev.isDumy) return;

					// IPv4 format validation
					if (!System.Net.IPAddress.TryParse(dev.addr, out System.Net.IPAddress _) || dev.addr.Contains(":")) return;

					try
					{
						using (Ping pingSender = new Ping())
						{
							byte[] buffer = new byte[monitorPacketSize];
							new Random().NextBytes(buffer); // 더미 데이터 채움
							PingReply reply = await pingSender.SendPingAsync(dev.addr, monitorTimeout, buffer);
							
							string key = dev.id.ToString();
							int failCount = 0;

							lock (dictFailCount)
							{
								if (reply.Status == IPStatus.Success)
								{
									dictFailCount[key] = 0;
									Console.WriteLine($"Ping Success: {dev.name} ({dev.addr})");
								}
								else
								{
									if (dictFailCount.ContainsKey(key))
										dictFailCount[key]++;
									else
										dictFailCount[key] = 1;

									failCount = dictFailCount[key];
									Console.WriteLine($"Ping Fail: {dev.name} ({dev.addr}), Count: {failCount}, Status: {reply.Status}");
								}
							}

							// Update diagram node border if it exists
							UpdateNodeStatusById(dev.id, failCount);
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Ping Exception ({dev.addr}): {ex.Message}");
					}
				}).ToList();

				await Task.WhenAll(tasks);

				if (isMonitoring)
				{
					Console.WriteLine($"Monitoring Loop Sleeping for {monitorInterval}ms...");
					// [수정] 설정된 체크 간격 사용 (100ms 단위로 끊어 체크하며 대기)
					int sleepCycles = monitorInterval / 100;
					for (int i = 0; i < sleepCycles && isMonitoring; i++)
					{
						await Task.Delay(100);
					}
				}
			}
			Console.WriteLine("Async Monitoring Loop Stopped.");
		}

		private void LoadMonitorConfig() {
			string path = @"C:\GTWave\cfg\GTWave.cfg";
			if (!File.Exists(path)) return;

			try {
				string[] lines = File.ReadAllLines(path);
				foreach (string line in lines) {
					if (string.IsNullOrWhiteSpace(line)) continue;
					if (line.StartsWith("[")) continue; // 섹션 헤더 무시

					string[] parts = line.Split('=');
					if (parts.Length < 2) continue;

					string key = parts[0].Trim();
					string val = parts[1].Trim();

					if (key == "체크간격") int.TryParse(val, out monitorInterval);
					else if (key == "타임아웃") int.TryParse(val, out monitorTimeout);
					else if (key == "CheckTimes") int.TryParse(val, out monitorCheckTimes);
					else if (key == "패킷크기") int.TryParse(val, out monitorPacketSize);
				}
				Console.WriteLine($"Config Loaded: Interval={monitorInterval}, Timeout={monitorTimeout}, Times={monitorCheckTimes}, Size={monitorPacketSize}");
			} catch (Exception ex) {
				Console.WriteLine("LoadMonitorConfig Error: " + ex.Message);
			}
		}

		private void UpdateNodeStatusById(int deviceId, int failCount)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new System.Action(() => UpdateNodeStatusById(deviceId, failCount)));
				return;
			}

			foreach (DiagramNode node in main_diagram.Nodes)
			{
				if (node.Tag is DeviceInfo dev && dev.id == deviceId)
				{
					UpdateNodeStatus(node, failCount);
					break;
				}
				else if (node.Tag is int id && id == deviceId)
				{
					UpdateNodeStatus(node, failCount);
					break;
				}
			}
		}

		private void UpdateNodeStatus(DiagramNode node, int failCount)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new System.Action(() => UpdateNodeStatus(node, failCount)));
				return;
			}

			if (node is ShapeNode shapeNode)
			{
				if (shapeNode.Tag is DeviceInfo dev && dev.isDumy) {
					shapeNode.Pen = new MindFusion.Drawing.Pen(System.Drawing.Color.Transparent, 0f);
					dv_netview.Refresh();
					return;
				}

				if (failCount == 0)
				{
					shapeNode.Pen = new MindFusion.Drawing.Pen(System.Drawing.Color.Green, 0.5f);
				}
				else if (failCount <= monitorCheckTimes) // [수정] 하드코딩된 5 대신 설정값 사용
				{
					shapeNode.Pen = new MindFusion.Drawing.Pen(System.Drawing.Color.Yellow, 0.5f);
				}
				else
				{
					shapeNode.Pen = new MindFusion.Drawing.Pen(System.Drawing.Color.Red, 0.5f);
				}
				dv_netview.Refresh();
			}
		}

		public	void	WirelessScan(DeviceInfo dInfo) {
			ecp_diagram.IsExpanded = false;
			ecp_scan_info.IsExpanded = true;
			cb_ip.Text		= dInfo.addr;
			tb_port.Text	= dInfo.connPort.ToString();
			bt_scan.PerformClick();
		}

		private void bt_scan_Click(object sender, EventArgs e) {

			// 무선인지 확인을 한다.
			
			DialogLogin dialogLogin = new DialogLogin();
			dialogLogin.ShowDialog();
			if (!dialogLogin.isOK) {
				return;
			}

			scan_id = Settings.Default.id;
			scan_pw = Settings.Default.pw;

			if (isScan) {
				MessageBox.Show("현재 Scan 진행중...");
				return;
			}

			if (cb_auto_save.Checked) {
				//mSaveFile
				System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
				System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(System.Windows.Forms.Application.StartupPath + @"..\Data");
				saveFileDialog1.InitialDirectory = di.FullName;
				saveFileDialog1.FileName = "WaveLinker_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
				saveFileDialog1.Filter = "sam data|*.csv";
				saveFileDialog1.Title = "Save an Data File";
				if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
					mSaveFile = saveFileDialog1.FileName;
					if (mSaveHandle != null) {
						mSaveHandle.Close();
					}
					Thread.Sleep(200);
					mSaveHandle = new StreamWriter(mSaveFile);

					Debug.WriteLine($"-------{mSaveFile}---------------");
				} else {
					MessageBox.Show("스캔작업을 취소합니다.");
					return;
				}
			}
			scanThread = new Thread(() => Scan(this));
			scanThread.IsBackground = true;
			scanThread.Start();
		}

		public string ParseSigChain(string sigChain) {
			string retv = "";

			retv = sigChain.Replace(System.Environment.NewLine, "");
			Regex reg = new Regex(@"\[(.+)\]");

			MatchCollection resultColl = reg.Matches(retv);
			foreach (Match mm in resultColl) {
				System.Text.RegularExpressions.Group g = mm.Groups[1];
				Debug.WriteLine("  mm.Groups.Count = {0}", mm.Groups.Count);
				Debug.WriteLine("  mm.Groups[0] = {0}", mm.Groups[0]);
				Debug.WriteLine("  mm.Groups[1] = {0}", mm.Groups[1]);

				Debug.WriteLine("{0}=|{1}|=", g.Index, g.Value);
				retv = g.Value;
				break;
			}
			string[] list = retv.Split(',');
			List<int> tuple = new List<int>();
			foreach (string str in list) {
				int.TryParse(str, out int val);
				tuple.Add(val);
			}

			if (tuple != null && tuple.Count > 3) {
				if (tuple[3] > -95) {
					retv = string.Format("{0}, {1}, {2}, {3}", tuple[0], tuple[1], tuple[2], tuple[3]);
				} else {
					if (tuple[2] > -95) {
						retv = string.Format("{0}, {1}, {2}", tuple[0], tuple[1], tuple[2]);
					} else {
						retv = string.Format("{0}, {1}", tuple[0], tuple[1]);
					}
				}
			}

			return retv;
		}

		public void DispScanData(JObject data) {
			Debug.WriteLine("===========================> DispScanData");

			// 파일을 만든다...................
			// 어떤 기준일까????

			list.Clear();
			Invoke(new MethodInvoker(delegate () {
				try {
					Debug.WriteLine(data["uptime"].ToString());
					int.TryParse(data["uptime"].ToString(), out int value);
					TimeSpan time = TimeSpan.FromSeconds(value);
					System.DateTime dateTime = System.DateTime.Today.Add(time);
					lb_uptime.Text = dateTime.ToString("dd일 hh:mm:ss");
					Debug.WriteLine($"lb_uptime => {lb_uptime.Text}");

					//lb_uptime.Text = data["uptime"].ToString();

					//DateTime dt = DateTime.Parse(data["uptime"].ToString());
					//lb_uptime.Text = dt.ToString("HH:mm:ss");

					JArray wifinets = (JArray)data["wifinets"];

					int group = 0;
					foreach (var net in wifinets) {
						string device = net["device"].ToString();
						//string device = net["device"].ToString();

						JArray networks = (JArray)net["networks"];

						string bssid = "";
						string ssid = "";
						string encryption = "";
						string frequency = "";
						string mode = "";

						foreach (var network in networks) {
							if (string.IsNullOrEmpty(bssid)) {
								bssid = network["bssid"].ToString();
								ssid = network["ssid"].ToString();
								try {
									encryption = network["encryption"].ToString();
								} catch (Exception ex) {
									encryption = "none";
								}
								try {
									frequency = network["frequency"].ToString();
								} catch (Exception ex) {
									frequency = "auto";
								}
								mode = network["mode"].ToString();
							}
							JObject assoclist = (JObject)network["assoclist"];
							foreach (var assoc in assoclist) {
								AssocInfo info = new AssocInfo();
								info.mac = assoc.Key;
								JObject detail = JObject.Parse(assoc.Value.ToString());
								info.ssid = ssid;
								info.rxRate = detail["rx_rate"].ToString();
								info.txRate = detail["tx_rate"].ToString();
								info.txCcq = detail["txccq"].ToString();
								info.signal = detail["signal"].ToString();
								info.sigChain = detail["signalchains"].ToString();
								list.Add(assoc.Key, info);
								//Debug.WriteLine(assoc.Value);
							}
						}

						if (group == 0 && !mHeadWrite) {
							gb_device0.Text = device;
							lb_g_bssid_0.Text = bssid;
							lb_g_ssid_0.Text = ssid;
							lb_g_sec_0.Text = encryption;
							lb_g_freq_0.Text = frequency;
							lb_g_mode_0.Text = mode;
							mSaveHandle.WriteLine($"{device} | {bssid} | {ssid} | {encryption} | {frequency} | {mode} | |");
							mSaveHandle.Flush();
						}

						if (group == 1 && !mHeadWrite) {
							gb_device1.Text = device;
							lb_g_bssid_1.Text = bssid;
							lb_g_ssid_1.Text = ssid;
							lb_g_sec_1.Text = encryption;
							lb_g_freq_1.Text = frequency;
							lb_g_mode_1.Text = mode;
							mSaveHandle.WriteLine($"{device} | {bssid} | {ssid} | {encryption} | {frequency} | {mode} | |");
							mSaveHandle.Flush();
						}
						group++;
					}

					if (!mHeadWrite) {
						mSaveHandle.WriteLine($"DATE | SSID | MAC address | signal | signal chain | RxRate | TxRate | TxCCQ");
						mSaveHandle.Flush();
					}

					if (!mHeadWrite) {
						mHeadWrite = true;
					}

					lv_scan_list.Items.Clear();
					foreach (KeyValuePair<string, AssocInfo> items in list) {
						Console.WriteLine("{0} ,  {1}", items.Key, items.Value);
						AssocInfo info = items.Value;

						ListViewItem item = new ListViewItem(info.ssid);
						//item.SubItems.Add(point.date);
						item.SubItems.Add($"{info.mac}");
						item.SubItems.Add($"{info.signal} dBm");

						string sigChain = ParseSigChain(info.sigChain);

						item.SubItems.Add($"{sigChain} dBm");
						float.TryParse(info.rxRate, out float rxRate);
						item.SubItems.Add($"{rxRate / 1000,6:N0}Mbps");
						float.TryParse(info.txRate, out float txRate);
						item.SubItems.Add($"{txRate / 1000,6:N0}Mbps");
						item.SubItems.Add($"{info.txCcq,6} %");
						lv_scan_list.Items.Add(item);

						string date = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

						mSaveHandle.WriteLine($"{date} | {info.ssid} | {info.mac} | {info.signal} | {sigChain} | {rxRate / 1000,6:N0} | {txRate / 1000,6:N0} | {info.txCcq,6}");
						mSaveHandle.Flush();
					}

					Debug.WriteLine(wifinets.Count);
					mSaveHandle.WriteLine($"");
					mSaveHandle.Flush();
				} catch { }
			}));
		}

		public void SaveScanData(JObject data) {
			Debug.WriteLine("===========================> SaveScanData");
		}

		private static void KillProcess(string filePath) {

			string processName = System.IO.Path.GetFileNameWithoutExtension(filePath);

			foreach (Process process in Process.GetProcessesByName(processName)) {
				if (!string.IsNullOrWhiteSpace(filePath)) {
					try {
						if (process.MainModule != null && process.MainModule.FileName != null && string.Compare(process.MainModule.FileName, filePath, true) == 0) {
							process.Kill();
						}
					} catch {
					}
				} else {
					process.Kill();
				}
			}
		}

		private static void Scan(MainFormV1 form) {

			//string filename = "WaveLinker_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
			//StreamWriter sw = new StreamWriter(filename, true, Encoding.UTF8);

			ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
			chromeDriverService.HideCommandPromptWindow = true;

			string Url = $"http://{scanIp}:{scanPort}/cgi-bin/luci/;stok=1e1220bc87983e65395e7344?7344?status=1&_=0.6561156622211763";
			var options = new ChromeOptions();                                  // ChromeOptions 인스턴스 생성
			options.AddArgument("--headless");
			options.AddArgument("ignore-certificate-errors");
			options.AddArgument("--window-position=-32000,-32000");
			driver = new ChromeDriver(chromeDriverService, options);
			//driver.Navigate().GoToUrl(@"http://1.220.20.218:8012/cgi-bin/luci/;stok=1e1220bc87983e65395e7344?7344?status=1&_=0.6561156622211763");

			try {
				//driver.Navigate().GoToUrl(@"http://192.168.10.6:8081/cgi-bin/luci/;stok=1e1220bc87983e65395e7344?7344?status=1&_=0.6561156622211763");
				driver.Navigate().GoToUrl(Url);

				IWebElement pwInput = driver.FindElement(By.ClassName("cbi-input-password"));
				//pwInput.SendKeys("password");
				pwInput.SendKeys(scan_pw);

				IWebElement submit = driver.FindElement(By.ClassName("cbi-button-apply"));
				//*[@id="maincontent"]/form/div[2]/input[1]
				// html / body / div[2] / div[2] / form / div[2] / input[1]
				//*[@id="maincontent"]/form/div[2]/input[1]
				//submit = chrome_driver.FindElement(By.XPath(@"//*[@id='maincontent']/form/div[2]/input[1]"));
				submit.Click();

				isScan = true;
				if (form.InvokeRequired) {
					form.Invoke(new MethodInvoker(delegate () {
						form.bt_scan.BackColor = System.Drawing.Color.Green;
					}));
				}

				while (isScan) {
					WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
					IWebElement body = driver.FindElement(By.CssSelector("body"));
					try {
						JObject data = JObject.Parse(body.Text);
						Debug.WriteLine(data.ToString());

						if (form.InvokeRequired) {
							form.Invoke(new MethodInvoker(delegate () {
								form.DispScanData(data);
								if (form.cb_auto_save.Checked) {
									// header 를 찍는다....
									form.SaveScanData(data);
								}
							}));
						}
						Thread.Sleep(4000);
					} catch { }
					driver.Navigate().Refresh();
				}
				mSaveHandle.Close();
			} catch {
			}

			try {
				KillProcess("chromedriver.exe");
				KillProcess("Google Chrome.exe");

				driver.Quit();      // 크롬 드라이버 종료, 메모리 해제
				driver.Dispose();
				driver.Close();

				//KillProcess(Path.Combine(executingDirectoryPath, "chromedriver.exe"));
			} catch {
			}
			isScan = false;

			//sw.Close();

			if (form.InvokeRequired) {
				form.Invoke(new MethodInvoker(delegate () {
					form.bt_scan.BackColor = System.Drawing.Color.White;
				}));
			}
		}

		private void bt_stop_Click(object sender, EventArgs e) {
			isScan = false;
		}

		private void bt_print_Click(object sender, EventArgs e) {
			string filename = "WaveLinker_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

			// 파일 IO 스트림을 취득한다.
			using (var stream = new FileStream(filename, FileMode.Create, FileAccess.Write)) {
				// Pdf형식의 document를 생성한다.
				Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);

				PdfWriter writer = PdfWriter.GetInstance(doc, stream);
				doc.Open();
				try {
					// Create a Simple table
					PdfPTable table = new PdfPTable(8);
					table.SetTotalWidth(new float[] { 10f, 10f, 30f, 11f, 8f, 8f, 8f, 5f });
					table.WidthPercentage = 100;

					PdfPCell cell = new PdfPCell(new Phrase("WaveLinker Scan List 일지[검사]", fontS));
					cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
					cell.Colspan = 8;
					cell.FixedHeight = 36;
					cell.HorizontalAlignment = Element.ALIGN_CENTER;
					table.AddCell(cell);

					string title = string.Format("Scan 기간 : {0} 부터 {1} 까지", System.DateTime.Now, System.DateTime.Now);
					cell = new PdfPCell(new Phrase(title, fontS));
					cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
					cell.Colspan = 5;
					cell.FixedHeight = 20;
					cell.HorizontalAlignment = Element.ALIGN_LEFT;
					table.AddCell(cell);

					title = string.Format("작성일자 : {0}, 처리건수 : {1}건", System.DateTime.Now, 3);
					cell = new PdfPCell(new Phrase(title, fontS));
					cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
					cell.Colspan = 3;
					cell.FixedHeight = 20;
					cell.HorizontalAlignment = Element.ALIGN_RIGHT;
					table.AddCell(cell);

					table.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

					table.AddCell(new Phrase("SSID", fontS));
					table.AddCell(new Phrase("MAC Addr", fontS));
					table.AddCell(new Phrase("Signal", fontS));
					table.AddCell(new Phrase("Signal Chain", fontS));
					table.AddCell(new Phrase("RxRate", fontS));
					table.AddCell(new Phrase("TxRate", fontS));
					table.AddCell(new Phrase("TxCCQ", fontS));

					/*
					foreach (var notice in notices) {
						// Set First row as header
						//table.He.HeaderRows(1);
						// Add header details
						table.AddCell("Name");
						table.AddCell("Class");
						table.AddCell("Subjects");
						table.AddCell("Result");

						// Add the data
						table.AddCell("Student1");
						table.AddCell("5th");

						table.AddCell("Fail");
					}
					*/

					doc.Add(table);
				} catch (Exception ex) {
					Console.WriteLine(ex.Message);
				} finally {
					doc.Close();
					//PrintJob printJob = new PrintJob("Printer Name", filename);
					//printJob.Print();

					// document Close
					PrintDialog printDlg = new PrintDialog();
					System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
					//printDoc.DocumentName = "Timer_20240824_135104.pdf";
					printDlg.Document = printDoc;
					printDlg.AllowSelection = true;
					printDlg.AllowSomePages = true;
					//Call ShowDialog  
					if (printDlg.ShowDialog() == DialogResult.OK) {
						//printDlg.PrinterSettings.PrinterName.
						PrintJob printJob = new PrintJob(printDlg.PrinterSettings.PrinterName, filename);
						printJob.Print();

						//printDoc.Print();
					}
				}
			}
		}

		private void bt_close_Click(object sender, EventArgs e) {
			Close();
			Environment.Exit(1);
		}

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

		}

		private void dv_netview_ControlRemoved(object sender, ControlEventArgs e) {
			Debug.WriteLine("dv_netview_ControlRemoved");
		}

		private void main_diagram_NodeDeleted(object sender, NodeEventArgs e) {

		}

		private void main_diagram_NodeDeleting(object sender, NodeValidationEventArgs e) {
			try {
				DiagramNode node = (DiagramNode)e.Node;
				if (node.Tag == null) return;

				DeviceInfo info = null;
				int id = -1;

				if (node.Tag is DeviceInfo dInfo) {
					info = dInfo;
					id = info.id;
				} else {
					try {
						id = Convert.ToInt32(node.Tag);
						info = DeviceInfo.Load2Db(id, GlobalHelpers.mDeviceTb);
					} catch { }
				}

				if (id != -1) {
					Debug.WriteLine($"NodeDeleting: {id}");
					GlobalHelpers.mDeviceTb.DeleteMany(x => x.id.Equals(id));

					string group_name = GetNodePath(mCurGroupNode);
					DispDeviceList(group_name);
				}
			} catch (Exception ex) {
				Debug.WriteLine("main_diagram_NodeDeleting error: " + ex.Message);
			}
		}

		private void 환경세팅ToolStripMenuItem_Click(object sender, EventArgs e) {
			ConfigDialog dialog = new ConfigDialog();
			dialog.ShowDialog();
		}

		private void advancedFlowLayoutPanel1_Paint(object sender, PaintEventArgs e) {

		}

		private void lv_scan_list_SelectedIndexChanged(object sender, EventArgs e) {

		}

		private void pb_full_screen_Click(object sender, EventArgs e)
		{
			ProgressForm.Start();

			Form fsForm = new Form();
			fsForm.Text = "전체화면";
			fsForm.StartPosition = FormStartPosition.Manual;
			fsForm.Bounds = Screen.FromControl(this).WorkingArea;
			fsForm.BackColor = System.Drawing.Color.White;

			// 원래 부모 정보 저장
			Control originalParent = main_ruler.Parent;
			int originalIndex = originalParent.Controls.GetChildIndex(main_ruler);
			DockStyle originalDock = main_ruler.Dock;
			System.Windows.Forms.AnchorStyles originalAnchor = main_ruler.Anchor;
			System.Drawing.Size originalSize = main_ruler.Size;
			System.Drawing.Point originalLocation = main_ruler.Location;

			// 새로운 폼으로 이동
			main_ruler.Anchor = System.Windows.Forms.AnchorStyles.None;
			main_ruler.Dock = DockStyle.Fill;
			fsForm.Controls.Add(main_ruler);

			// ESC 키를 누르면 닫히도록 설정
			fsForm.KeyPreview = true;
			fsForm.KeyDown += (s, ke) => {
				if (ke.KeyCode == System.Windows.Forms.Keys.Escape) fsForm.Close();
			};

			// 폼이 닫힐 때 원래 위치로 복구
			fsForm.FormClosing += (s, fe) => {
				main_ruler.Dock = DockStyle.None;
				main_ruler.Anchor = System.Windows.Forms.AnchorStyles.None;
				originalParent.Controls.Add(main_ruler);
				originalParent.Controls.SetChildIndex(main_ruler, originalIndex);
				main_ruler.Location = originalLocation;
				main_ruler.Size = originalSize;
				main_ruler.Dock = originalDock;
				main_ruler.Anchor = originalAnchor;
			};

			ProgressForm.Close(this);

			fsForm.ShowDialog();
		}

		private void SaveConfig() {
			try {
				RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Awool\GTWaveMgr");
				if (key != null) {
					key.SetValue("LinkColor", ColorTranslator.ToHtml(mLinkColor));
					key.SetValue("Segment", cb_link_segment.Text);
					key.SetValue("LinkStyle", cb_link_style.SelectedIndex);
					key.SetValue("LineThick", cb_line_thick.Text);
					key.SetValue("LinkDirect", cb_line_direct.SelectedIndex);
					key.SetValue("DiagramW", tb_diagram_w.Text);
					key.SetValue("DiagramH", tb_diagram_h.Text);
					key.SetValue("ViewMode", cb_view_mode.SelectedIndex);
					key.SetValue("BkImagePath", mBkImagePath);
					key.Close();
				}
			} catch (Exception ex) {
				Debug.WriteLine("설정 저장 실패: " + ex.Message);
			}
		}

		private void LoadConfig() {
			try {
				RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Awool\GTWaveMgr");
				if (key != null) {
					string colorStr = key.GetValue("LinkColor", "Black").ToString();
					mLinkColor = ColorTranslator.FromHtml(colorStr);
					bt_link_color.BackColor = mLinkColor;

					cb_link_segment.Text = key.GetValue("Segment", "2").ToString();
					cb_link_style.SelectedIndex = Convert.ToInt32(key.GetValue("LinkStyle", 3));
					cb_line_thick.Text = key.GetValue("LineThick", "1").ToString();

					tb_diagram_w.Text = key.GetValue("DiagramW", "800").ToString();
					tb_diagram_h.Text = key.GetValue("DiagramH", "600").ToString();
					cb_view_mode.SelectedIndex = Convert.ToInt32(key.GetValue("ViewMode", 0));
					cb_line_direct.SelectedIndex = Convert.ToInt32(key.GetValue("LinkDirect", 0));
					mBkImagePath = key.GetValue("BkImagePath", "").ToString();

					key.Close();

					// 트리거 강제 실행
					cb_link_style_SelectedIndexChanged(cb_link_style, null);
					cb_line_thick_SelectedIndexChanged(cb_line_thick, null);
					cb_line_direct_SelectedIndexChanged(cb_line_direct, null);
					tb_diagram_w_TextChanged(tb_diagram_w, null);
					tb_diagram_h_TextChanged(tb_diagram_h, null);
					cb_view_mode_SelectedIndexChanged(cb_view_mode, null);

					// 배경 이미지 복원
					if (!string.IsNullOrEmpty(mBkImagePath) && System.IO.File.Exists(mBkImagePath)) {
						try {
							mBackgroundBkImage = System.Drawing.Image.FromFile(mBkImagePath);
							main_diagram.BackgroundImage = new System.Drawing.Bitmap(1, 1);
						} catch (Exception ex) {
							Debug.WriteLine("배경 이미지 복원 실패: " + ex.Message);
						}
					}
				}
			} catch (Exception ex) {
				Debug.WriteLine("설정 로드 실패: " + ex.Message);
			}
		}

		private void DrawCustomBackground(MindFusion.Drawing.IGraphics g) {
			using (System.Drawing.SolidBrush grayBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(170, 170, 170))) {
				g.FillRectangle(grayBrush, new System.Drawing.RectangleF(-10000, -10000, 30000, 30000));
			}

			using (System.Drawing.SolidBrush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White)) {
				g.FillRectangle(whiteBrush, main_diagram.Bounds);
			}

			if (mBackgroundBkImage == null) return;

			System.Drawing.Image image = mBackgroundBkImage;
			float targetWidth = main_diagram.Bounds.Width;
			float targetHeight = main_diagram.Bounds.Height;

			if (targetWidth <= 0 || targetHeight <= 0) return;

			float ratioX = targetWidth / image.Width;
			float ratioY = targetHeight / image.Height;
			float ratio = Math.Min(ratioX, ratioY);

			float newWidth = image.Width * ratio;
			float newHeight = image.Height * ratio;

			float posX = (targetWidth - newWidth) / 2f;
			float posY = (targetHeight - newHeight) / 2f;

			g.DrawImage(image, posX, posY, newWidth, newHeight);
		}

		private void bt_set_bk_image_Click(object sender, EventArgs e) {
			System.Drawing.Image File;
			System.Windows.Forms.OpenFileDialog f = new System.Windows.Forms.OpenFileDialog();
			f.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";

			if (f.ShowDialog() == DialogResult.OK) {
				File = System.Drawing.Image.FromFile(f.FileName);
				mBackgroundBkImage = File;
				mBkImagePath = f.FileName;
				main_diagram.BackgroundImage = new System.Drawing.Bitmap(1, 1);
				dv_netview.Invalidate();
				dv_netview.Refresh();
				dv_netview.ZoomToRect(main_diagram.Bounds);
			}
		}

		private void bt_cls_bk_image_Click(object sender, EventArgs e) {
			mBackgroundBkImage = null;
			mBkImagePath = "";
			main_diagram.BackgroundImage = null;
			dv_netview.Invalidate();
			dv_netview.Refresh();
		}

		private void statusTimeTimer_Tick(object sender, EventArgs e) {
			try {
				if (lblEncoding != null && lblEncoding.Visible) {
					lblEncoding.Visible = false;
				}
				if (lblTime != null && !lblTime.IsDisposed) {
					lblTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd tt h:mm:ss", new System.Globalization.CultureInfo("ko-KR"));
				}
			} catch { }
		}

		/// <summary>
		/// 하단 상태 표시줄의 텍스트 메시지를 설정합니다 (스레드 안전).
		/// </summary>
		public void SetStatusText(string text) {
			try {
				if (this.InvokeRequired) {
					this.BeginInvoke(new Action<string>(SetStatusText), text);
					return;
				}
				if (lblStatusText != null && !lblStatusText.IsDisposed) {
					lblStatusText.Text = text;
				}
			} catch { }
		}

		/// <summary>
		/// 하단 상태 표시줄의 진행률 표시줄(ProgressBar) 값과 가시성을 설정합니다 (스레드 안전).
		/// </summary>
		/// <param name="value">진행률 값 (0 ~ 100)</param>
		/// <param name="visible">표시 여부</param>
		public void SetProgress(int value, bool visible = true) {
			try {
				if (this.InvokeRequired) {
					this.BeginInvoke(new Action<int, bool>(SetProgress), value, visible);
					return;
				}
				if (pbStatusProgress != null && !pbStatusProgress.IsDisposed) {
					pbStatusProgress.Visible = visible;
					if (value < pbStatusProgress.Minimum) value = pbStatusProgress.Minimum;
					if (value > pbStatusProgress.Maximum) value = pbStatusProgress.Maximum;
					pbStatusProgress.Value = value;
				}
			} catch { }
		}

		/// <summary>
		/// 하단 상태 표시줄의 인코딩 텍스트를 설정합니다 (스레드 안전).
		/// </summary>
		public void SetEncodingText(string text) {
			try {
				if (this.InvokeRequired) {
					this.BeginInvoke(new Action<string>(SetEncodingText), text);
					return;
				}
				if (lblEncoding != null && !lblEncoding.IsDisposed) {
					lblEncoding.Text = text;
				}
			} catch { }
		}

		private void statusStrip1_Paint(object sender, PaintEventArgs e) {
			try {
				// 상태 바의 상단 경계선 테두리를 그림 (더 명확하고 뚜렷한 밝은 회색선)
				using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(120, 120, 120), 1.5f)) {
					e.Graphics.DrawLine(pen, 0, 0, statusStrip1.Width, 0);
				}
			} catch { }
		}
	}
}

