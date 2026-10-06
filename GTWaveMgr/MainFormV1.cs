using Antlr.Runtime.Tree;
using AnyBoBu;
using AnyBoBu.dialog;
using AnyBoBu.info;
using AnyBoBu.utils;
using AnyLosk.widget;
using Awool.info;
using Awool.library;
using BoBuAI.info;
using FireFly.utils;
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
using System.Drawing.Printing;
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
		private bool isDiagramLocked = false;
		// ----------------------- for Network diagram 

		// ----------------------- for Status Monitoring
		private bool isMonitoring = false;
		private Thread monitoringThread = null;
		private Dictionary<string, int> dictFailCount = new Dictionary<string, int>();
		private Dictionary<string, bool> dictLastDownState = new Dictionary<string, bool>();
		private System.DateTime? mMonitorStartTime = null;
		private System.DateTime? mMonitorStopTime = null;
		public List<DeviceInfo> mTotDevice = new List<DeviceInfo>();

		// Device Log memory list & lock
		private readonly List<DeviceLogItem> mDeviceLogs = new List<DeviceLogItem>();
		private readonly object mLogLock = new object();

		// Ping Monitoring stats list & lock
		private readonly Dictionary<string, DevicePingStat> dictPingStats = new Dictionary<string, DevicePingStat>();
		private readonly object mPingStatLock = new object();

		private Bitmap imgMonStartActive = null;
		private Bitmap imgMonStartInactive = null;
		private Bitmap imgMonStopActive = null;
		private Bitmap imgMonStopInactive = null;
		private System.Drawing.Image imgTbMonStartActive = null;
		private System.Drawing.Image imgTbMonStartDisabled = null;
		private System.Drawing.Image imgTbMonStopActive = null;
		private System.Drawing.Image imgTbMonStopDisabled = null;

		private int monitorInterval 	= 5000;
		private int monitorTimeout 		= 2000;
		private int monitorCheckTimes 	= 5;
		private int monitorPacketSize 	= 32;

		private System.Windows.Forms.Timer monitoringAnimationTimer;
		private float gradientOffset = 0;
		// ----------------------- for Status Monitoring
		private System.Windows.Forms.Timer statusTimeTimer;
		private ErrorPopupDialog mErrorPopupDlg = null;

		// ----------------------- 하단 커스텀 상태바 컨트롤
		private ToolStripStatusLabel lbl_status_check_result = null;   // 직전 시스템 체크 결과
		private ToolStripStatusLabel lbl_status_mon_time = null;       // 모니터링 시작 및 종료 시간
		private ToolStripStatusLabel lbl_status_countdown = null;      // 다음 시스템 체크시작 남은 시간
		private ToolStripStatusLabel lbl_status_spring_sep = null;     // 여백
		private ToolStripStatusLabel lbl_status_network = null;        // 네트워크 상태 아이콘
		private ToolStripStatusLabel lbl_status_clock = null;          // 시스템 시간

		private Bitmap bmpNetworkOk = null;
		private Bitmap bmpNetworkError = null;
		private NetworkErrorDialog mNetErrorDialog = null;
		private bool isNetworkConnected = true;
		private bool isPausedByNetwork = false;

		// ----------------------- 10 Toolbar Shortcuts
		private Button btn_tb_fullscreen = null;
		private Button btn_tb_dev_search = null;
		private Button btn_tb_dev_add = null;
		private Button btn_tb_dev_edit = null;
		private Button btn_tb_dev_del = null;
		private Button btn_tb_diagram_lock = null;
		private Button btn_tb_mon_start = null;
		private Button btn_tb_mon_stop = null;
		private Button btn_tb_report_print = null;
		private Button btn_tb_settings = null;

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
			DisableMindFusionTrialWatermark();
			LogUtil.LogI("MAINFORM", "MainFormV1 constructor starting...");
			InitializeComponent();
			LogUtil.LogI("MAINFORM", "InitializeComponent completed.");
			this.statusStrip1.BringToFront();
			this.sc_main.SendToBack();
			this.menuStrip1.SendToBack();
			if (Global.mAppIcon != null)
			{
				this.Icon = (System.Drawing.Icon)Global.mAppIcon.Clone();
			}

			// 항상 메인 모니터(PrimaryScreen) 기준으로 위치 및 크기 설정
			Screen primary = Screen.PrimaryScreen;
			this.StartPosition = FormStartPosition.Manual;
			this.Location = primary.WorkingArea.Location;
			this.MaximizedBounds = primary.WorkingArea;
			Microsoft.Win32.SystemEvents.UserPreferenceChanged += (s, e) => {
				try {
					this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
				} catch { }
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
			InitCustomStatusBar();
			LogUtil.LogI("MAINFORM", "MainFormV1 constructor finished.");
		}

		/// <summary>
		/// 다이어그램을 현재 뷰 영역에 정비율(종횡비 유지)로 최대한 꽉 차게 확대 맞춤합니다.
		/// </summary>
		public void FitDiagramToView() {
			try {
				if (dv_netview == null || main_diagram == null) return;
				if (dv_netview.ClientSize.Width <= 10 || dv_netview.ClientSize.Height <= 10) return;

				RectangleF bounds = main_diagram.Bounds;
				if (bounds.Width <= 0 || bounds.Height <= 0) return;

				// 정비율 화면 맞춤 실행
				dv_netview.ZoomToRect(bounds);

				// 스크롤 위치를 다이어그램 좌상단(0, 0)으로 정렬
				try {
					dv_netview.ScrollTo(new System.Drawing.PointF(bounds.X, bounds.Y));
				} catch { }

				dv_netview.Invalidate();
				dv_netview.Refresh();
			} catch (Exception ex) {
				LogUtil.LogException("MAINFORM", ex, "FitDiagramToView error");
			}
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
				if (btn_tb_mon_start != null && !btn_tb_mon_start.IsDisposed) {
					btn_tb_mon_start.FlatAppearance.BorderSize = 0;
					btn_tb_mon_start.BackColor = System.Drawing.Color.Transparent;
				}
				return;
			}

			gradientOffset += 5;
			if (gradientOffset > 10000) gradientOffset = 0;

			// [추가] 모니터링 시작 버튼 더 밝고 선명한 펄스(Glow) 애니메이션
			if (btn_tb_mon_start != null && !btn_tb_mon_start.IsDisposed) {
				double pulse = (Math.Sin(gradientOffset * 0.15) + 1.0) / 2.0; // 0.0 ~ 1.0
				int r = (int)(60 + 180 * pulse);  // 60 ~ 240
				int g = (int)(150 + 95 * pulse);  // 150 ~ 245
				int b = 255;
				btn_tb_mon_start.FlatAppearance.BorderSize = 1;
				btn_tb_mon_start.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb((int)(30 + 180 * pulse), (int)(120 + 120 * pulse), 255);
				btn_tb_mon_start.BackColor = System.Drawing.Color.FromArgb(r, g, b);
			}

			if (bt_status_mon != null && bt_status_mon.Visible) {
				int w = bt_status_mon.Width;
				int h = bt_status_mon.Height;
				if (w > 0 && h > 0) {
					Bitmap bmp = new Bitmap(w, h);
					using (Graphics g = Graphics.FromImage(bmp)) {
						using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
							new System.Drawing.Rectangle((int)(gradientOffset % w) - w, 0, w * 2, h),
							System.Drawing.Color.DeepSkyBlue,
							System.Drawing.Color.RoyalBlue,
							0f)) {
							brush.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
							g.FillRectangle(brush, 0, 0, w, h);
						}
					}

					var oldImg = bt_status_mon.BackgroundImage;
					bt_status_mon.BackgroundImage = bmp;
					if (oldImg != null) oldImg.Dispose();
				}
			}
		}

		private void sc_main_Resize(object sender, EventArgs e) {
			pb_panel_left.Left = sc_context.Panel1.Width + 6;
			pn_top_info.Left = pb_panel_left.Left + pb_panel_left.Width + 10;
			sc_main.SplitterDistance = pb_drawer.Height + 14;
			//sc_mem_list.SplitterDistance = tb_mem_search.Height + 6;
		}

		private void MainFormV1_Load(object sender, EventArgs e) {
			LogUtil.LogI("MAINFORM", "MainFormV1_Load started.");
			// [수정] 아이콘 강제 재설정 (작업표시줄 아이콘 깨짐 방지)
			if (Global.mAppIcon != null)
			{
				this.Icon = null; // 한번 초기화 후 재설정
				this.Icon = (System.Drawing.Icon)Global.mAppIcon.Clone();
			}

			// 항상 메인 모니터(PrimaryScreen) 기준으로 위치 및 최대화
			Screen primary = Screen.PrimaryScreen;
			this.Location = primary.WorkingArea.Location;
			this.MaximizedBounds = primary.WorkingArea;
			this.WindowState = FormWindowState.Normal;
			this.Bounds = primary.WorkingArea;
			this.WindowState = FormWindowState.Maximized;

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

				if (bt_mon_start != null) bt_mon_start.BackColor = System.Drawing.Color.Transparent;
				if (bt_mon_stop != null) bt_mon_stop.BackColor = System.Drawing.Color.Transparent;

				InitMonitoringIcons();
				UpdateMonitoringButtonsUI(false);
				InitDeviceLogUI();
				InitPingMonitorUI();
				InitToolbarShortcuts();

				btnToolTip = new ToolTip();
				btnToolTip.SetToolTip(bt_finder, "장비 찾기");
				//btnToolTip.SetToolTip(bt_form_ncd, "구성도 관리");
				btnToolTip.SetToolTip(pb_full_screen, "전체 화면");
				btnToolTip.SetToolTip(bt_status_mon, "상태 감시");
				if (bt_mon_start != null) btnToolTip.SetToolTip(bt_mon_start, "모니터링 시작");
				if (bt_mon_stop != null) btnToolTip.SetToolTip(bt_mon_stop, "모니터링 중지");
				if (bt_log_save != null) btnToolTip.SetToolTip(bt_log_save, "로그 결과 파일로 저장");
				if (bt_log_print != null) btnToolTip.SetToolTip(bt_log_print, "로그결과 인쇄");
				if (bt_log_search != null) btnToolTip.SetToolTip(bt_log_search, "검색");
				if (bt_log_clear != null) btnToolTip.SetToolTip(bt_log_clear, "로그 초기화");
				if (bt_ping_save != null) btnToolTip.SetToolTip(bt_ping_save, "시스템 리스트 모니터링 결과 파일로 저장");
				if (bt_ping_print != null) btnToolTip.SetToolTip(bt_ping_print, "시스템 리스트 모니터링 결과 인쇄");
				if (bt_ping_search != null) btnToolTip.SetToolTip(bt_ping_search, "저장 인쇄 미리보기");
				if (bt_ping_clear != null) btnToolTip.SetToolTip(bt_ping_clear, "모니터링 결과 초기화");
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "Button Image Load Error");
			}

			try
			{
				LogUtil.LogI("MAINFORM", "Loading group tree...");
				tv_group.Nodes.Clear();
				LoadTree(tv_group, "group.mvia");

				if (tv_group.Nodes.Count == 0)
				{
					TreeNode defaultNode = tv_group.Nodes.Add("전체 그룹");
					GroupInfo defaultGroup = new GroupInfo(defaultNode.Text);
					defaultNode.Tag = defaultGroup;
					defaultGroup.node = defaultNode;
				}
				LogUtil.LogI("MAINFORM", $"Group tree loaded. Root nodes: {tv_group.Nodes.Count}");
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "Group tree load error");
			}

			try
			{
				ProgressForm.Start();
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "ProgressForm.Start error");
			}

			try
			{
				LogUtil.LogI("MAINFORM", "Loading devices and groups...");
				LoadTotalDevices();
				RefreshGroup();
				RefreshSystem();

				if (tv_group.Nodes.Count > 0)
				{
					mCurGroupNode = tv_group.Nodes[0];
					string group_name = GetNodePath(mCurGroupNode);
					DispDeviceList(group_name);
				}
				
				cb_view_mode.SelectedIndex = 0; // 이름으로 보기 (기본)
				LogUtil.LogI("MAINFORM", "Devices and groups loaded successfully.");
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "Devices/groups load error");
			}
			
			// 멤버 리스트
			//RefreshMember();

			//한글 폰트를 읽어온다.
			try
			{
				string fontPath = @"C:\Windows\Fonts\malgun.ttf";
				if (File.Exists(fontPath))
				{
					iTextSharp.text.pdf.BaseFont bf = iTextSharp.text.pdf.BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
					fontS = new iTextSharp.text.Font(bf, 14.0f);
					fontS.SetStyle(1);
					fontS.SetColor(0, 0, 0);
				}
				else
				{
					LogUtil.LogW("MAINFORM", $"Font file not found: {fontPath}");
				}
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "Font load error");
			}

			try
			{
				lineSeparator = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, CMYKColor.BLACK, Element.ALIGN_LEFT, 1)));
				// Set gap between line paragraphs.
				lineSeparator.SetLeading(0.5F, 0.5F);
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "lineSeparator init error");
			}

			try
			{
				LogUtil.LogI("MAINFORM", "Initializing Diagram...");
				DiagramInit();
				LogUtil.LogI("MAINFORM", "Loading Config...");
				LoadConfig();
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "DiagramInit / LoadConfig error");
			}

			// 구성도 자동 로드
			try {
				string defaultMfPath = System.IO.Path.Combine(Global.mAppPath, @"..\data\default.mf");
				LogUtil.LogI("MAINFORM", $"Loading default diagram: {defaultMfPath} (Exists: {System.IO.File.Exists(defaultMfPath)})");
				if (System.IO.File.Exists(defaultMfPath)) {
					dv_netview.LoadFromFile(defaultMfPath);
					if (!isDiagramLocked) {
						dv_netview.Behavior = MindFusion.Diagramming.Behavior.Modify;
						dv_netview.AllowInplaceEdit = true;
					}

					// 로드 후 모든 노드의 테두리 색상 업데이트
					foreach (DiagramNode node in main_diagram.Nodes) {
						UpdateNodeAppearance(node);
						UpdateNodeLabel(node); // [추가] 라벨 위치 및 텍스트 업데이트 강제 실행
					}
					foreach (DiagramLink link in main_diagram.Links) {
						link.ShadowOffsetX = 0;
						link.ShadowOffsetY = 0;
					}
					LogUtil.LogI("MAINFORM", "Default diagram loaded successfully.");
					FitDiagramToView();
				}
			} catch (Exception ex) {
				LogUtil.LogException("MAINFORM", ex, "구성도 로드 실패");
			}

			tb_group_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		

			scanIp = cb_ip.Text;
			int.TryParse(tb_port.Text, out int port);
			scanPort = port;

			DispClear();

			try
			{
				ProgressForm.Close(this);
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "ProgressForm.Close error");
			}

			// [추가] 폼이 완전히 표시된 후 아이콘 다시 한 번 강제 설정 및 메인 화면 활성화
			this.Shown += (s, ev) => {
				try {
					if (Global.mAppIcon != null) this.Icon = (System.Drawing.Icon)Global.mAppIcon.Clone();
					Screen primaryScreen = Screen.PrimaryScreen;
					if (!primaryScreen.WorkingArea.Contains(this.Bounds.Location)) {
						this.Location = primaryScreen.WorkingArea.Location;
						this.WindowState = FormWindowState.Maximized;
					}
					this.Activate();
					this.BringToFront();
					LogUtil.LogI("MAINFORM", $"MainForm shown on PrimaryScreen: {primaryScreen.DeviceName}, Bounds: {this.Bounds}");

					// [추가] 폼 렌더링 완료 후 다이어그램 정비율 화면 꽉 차게 맞춤
					this.BeginInvoke(new System.Action(() => {
						FitDiagramToView();
					}));
				} catch (Exception ex) {
					LogUtil.LogException("MAINFORM", ex, "Shown event error");
				}
			};
			LogUtil.LogI("MAINFORM", "MainFormV1_Load completed.");
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

			if (m_lv_system_sort_col >= 0) {
				UpdateLvSystemHeaderSortIndicator(m_lv_system_sort_col, m_lv_system_sort_order);
				lv_system.ListViewItemSorter = new ListViewItemComparer(m_lv_system_sort_col, m_lv_system_sort_order);
				lv_system.Sort();
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
			if (isMonitoring || isDiagramLocked) {
				MessageBox.Show(isMonitoring ? "모니터링 중에는 장비 정보를 수정할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 장비 정보를 수정할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

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
			if (lv_device_list.SelectedItems.Count == 0) return;

			ListViewItem item = lv_device_list.SelectedItems[0];
			if (item.Tag is DeviceInfo dev && dev != null) {
				FocusDiagramNodeByDevice(dev);
			}
		}

		private void FocusDiagramNodeByDevice(DeviceInfo dev) {
			if (dev == null || main_diagram == null) return;

			main_diagram.Selection.Clear();
			DiagramNode targetNode = null;

			foreach (DiagramNode node in main_diagram.Nodes) {
				DeviceInfo nodeDev = GetDeviceInfoFromNode(node);
				if (nodeDev != null) {
					if ((dev.id > 0 && nodeDev.id == dev.id) || dev.Equals(nodeDev)) {
						targetNode = node;
						break;
					}
				}
			}

			if (targetNode != null) {
				targetNode.Selected = true;
				try {
					dv_netview.BringIntoView(targetNode);
				} catch { }
				UpdateAllNodesSelectionStyle();
			} else {
				UpdateAllNodesSelectionStyle();
			}
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
			if (isMonitoring || isDiagramLocked) {
				MessageBox.Show(isMonitoring ? "모니터링 중에는 그룹을 추가할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 그룹을 추가할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			MenuItem menu = (MenuItem)sender;

			GroupDialog dlg = new GroupDialog(tv_group);
			dlg.gInfo = (GroupInfo)menu.Tag;
			dlg.mForm = this;
			dlg.ShowDialog();
		}

		private void ExitToolStripMenuItem_fix_Click(object sender, EventArgs e) {
			Debug.WriteLine("ExitToolStripMenuItem_fix_Click");
			if (isMonitoring || isDiagramLocked) {
				MessageBox.Show(isMonitoring ? "모니터링 중에는 그룹을 수정할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 그룹을 수정할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

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

					tree.TreeViewNodeSorter = new GroupNodeSorter();
					tree.Sort();
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
			if (isMonitoring || isDiagramLocked) {
				MessageBox.Show(isMonitoring ? "모니터링 중에는 장비를 등록할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 장비를 등록할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
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
			if (isMonitoring || isDiagramLocked) {
				MessageBox.Show(isMonitoring ? "모니터링 중에는 그룹을 삭제할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 그룹을 삭제할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

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
				if (isMonitoring || isDiagramLocked) {
					MessageBox.Show(isMonitoring ? "모니터링 중에는 그룹 및 장비를 추가/수정/삭제할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 그룹 및 장비를 추가/수정/삭제할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
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
			using (AnyBoBu.dialog.AboutDialog dlg = new AnyBoBu.dialog.AboutDialog()) {
				dlg.ShowDialog(this);
			}
		}

		private void bt_system_add_Click(object sender, EventArgs e) {
			if (isMonitoring || isDiagramLocked) {
				MessageBox.Show(isMonitoring ? "모니터링 중에는 장비 종류를 추가할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 장비 종류를 추가할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

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
			if (isMonitoring || isDiagramLocked) {
				MessageBox.Show(isMonitoring ? "모니터링 중에는 이미지를 설정할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 이미지를 설정할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

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
				} catch (Exception) { }
				tb_system_image_path.Text = tPath;
			}
		}

		private void bt_system_del_Click(object sender, EventArgs e) {
			if (isMonitoring || isDiagramLocked) {
				MessageBox.Show(isMonitoring ? "모니터링 중에는 장비 종류를 삭제할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 장비 종류를 삭제할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

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
			if (isMonitoring || isDiagramLocked) {
				MessageBox.Show(isMonitoring ? "모니터링 중에는 장비 종류를 수정할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 장비 종류를 수정할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

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
			} catch (Exception) {
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
			} catch (Exception) {
				pb_system_image.Image = global::GTWave.Properties.Resources.no_image;
			}

			// 이름은 수정을 하지 못하게
			tb_system_name.Enabled = false;
			tb_system_spec.Focus();

			mSystemMode = "fix";
		}

		private int m_lv_system_sort_col = 0;
		private SortOrder m_lv_system_sort_order = SortOrder.Ascending;
		private readonly string[] m_lv_system_col_names = new string[] { "No", "이름", "규 격", "설명" };

		private void UpdateLvSystemHeaderSortIndicator(int sortCol, SortOrder order) {
			for (int i = 0; i < lv_system.Columns.Count && i < m_lv_system_col_names.Length; i++) {
				string baseName = m_lv_system_col_names[i];
				if (i == sortCol) {
					lv_system.Columns[i].Text = (order == SortOrder.Ascending) ? $"{baseName} ▲" : $"{baseName} ▼";
				} else {
					lv_system.Columns[i].Text = $"{baseName} ▲▼";
				}
			}
		}

		private void lv_system_ColumnClick(object sender, ColumnClickEventArgs e) {
			if (e.Column == m_lv_system_sort_col) {
				m_lv_system_sort_order = (m_lv_system_sort_order == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
			} else {
				m_lv_system_sort_col = e.Column;
				m_lv_system_sort_order = SortOrder.Ascending;
			}

			UpdateLvSystemHeaderSortIndicator(e.Column, m_lv_system_sort_order);

			this.lv_system.ListViewItemSorter = new ListViewItemComparer(e.Column, m_lv_system_sort_order);
			this.lv_system.Sort();
		}

		public class ListViewItemComparer : System.Collections.IComparer {
			private int col;
			private SortOrder order;

			public ListViewItemComparer() {
				col = 0;
				order = SortOrder.Ascending;
			}

			public ListViewItemComparer(int column, SortOrder order) {
				col = column;
				this.order = order;
			}

			public int Compare(object x, object y) {
				int returnVal = -1;
				ListViewItem itemX = x as ListViewItem;
				ListViewItem itemY = y as ListViewItem;
				if (itemX == null || itemY == null) return 0;

				string textX = itemX.SubItems.Count > col ? itemX.SubItems[col].Text : "";
				string textY = itemY.SubItems.Count > col ? itemY.SubItems[col].Text : "";

				if (col == 0) {
					if (int.TryParse(textX, out int numX) && int.TryParse(textY, out int numY)) {
						returnVal = numX.CompareTo(numY);
					} else {
						returnVal = String.Compare(textX, textY);
					}
				} else {
					returnVal = String.Compare(textX, textY);
				}

				if (order == SortOrder.Descending) {
					returnVal *= -1;
				}
				return returnVal;
			}
		}

		public class GroupNodeSorter : System.Collections.IComparer {
			[System.Runtime.InteropServices.DllImport("shlwapi.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode, ExactSpelling = true)]
			private static extern int StrCmpLogicalW(string psz1, string psz2);

			public int Compare(object x, object y) {
				TreeNode tx = x as TreeNode;
				TreeNode ty = y as TreeNode;
				if (tx == null || ty == null) return 0;
				try {
					return StrCmpLogicalW(tx.Text, ty.Text);
				} catch {
					return string.Compare(tx.Text, ty.Text, StringComparison.OrdinalIgnoreCase);
				}
			}
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

		private bool IsNodeLinkedToDevice(DiagramNode node) {
			if (node == null) return false;
			if (node.Tag is DeviceInfo d && d.isDumy) return true;

			DeviceInfo dev = GetDeviceInfoFromNode(node);
			if (dev == null) return false; // 연결된 장비 정보가 없음 -> 연결 끊김

			// 1. 메모리의 장비 목록(mTotDevice)에서 일치 여부 확인
			if (mTotDevice != null && mTotDevice.Count > 0) {
				lock (mTotDevice) {
					bool match = mTotDevice.Any(x =>
						(dev.id > 0 && x.id == dev.id) ||
						(!string.IsNullOrEmpty(dev.addr) && !string.IsNullOrEmpty(x.addr) && dev.addr.Trim() == x.addr.Trim()) ||
						(!string.IsNullOrEmpty(dev.name) && !string.IsNullOrEmpty(x.name) && dev.name.Trim() == x.name.Trim())
					);
					if (match) return true;
				}
			}

			// 2. DB(GlobalHelpers.mDeviceTb)에서 일치 여부 확인
			try {
				if (GlobalHelpers.mDeviceTb != null) {
					if (dev.id > 0) {
						var found = GlobalHelpers.mDeviceTb.FindById(dev.id);
						if (found != null) return true;
					}
					if (!string.IsNullOrEmpty(dev.addr)) {
						string cleanAddr = dev.addr.Trim();
						var found = GlobalHelpers.mDeviceTb.FindOne(x => x.addr == cleanAddr);
						if (found != null) return true;
					}
					if (!string.IsNullOrEmpty(dev.name)) {
						string cleanName = dev.name.Trim();
						var found = GlobalHelpers.mDeviceTb.FindOne(x => x.name == cleanName);
						if (found != null) return true;
					}
				}
			} catch { }

			return false;
		}

		private void DrawDisconnectedNodeMarks(MindFusion.Drawing.IGraphics g) {
			if (main_diagram == null || main_diagram.Nodes == null) return;

			using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(230, 230, 30, 30), 2.5f)) {
				pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
				pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

				foreach (DiagramNode node in main_diagram.Nodes) {
					if (node is ShapeNode shapeNode) {
						if (shapeNode.Tag is DeviceInfo dev && dev.isDumy) continue;

						// 왼쪽의 Device(등록된 장비 정보)와 연결이 끊어진 노드만 X 표시
						if (!IsNodeLinkedToDevice(shapeNode)) {
							RectangleF bounds = shapeNode.Bounds;
							float padX = bounds.Width * 0.22f;
							float padY = bounds.Height * 0.22f;
							float x1 = bounds.X + padX;
							float y1 = bounds.Y + padY;
							float x2 = bounds.Right - padX;
							float y2 = bounds.Bottom - padY;

							g.DrawLine(pen, x1, y1, x2, y2);
							g.DrawLine(pen, x1, y2, x2, y1);
						}
					}
				}
			}
		}

		private void DrawMonitoringStatusBorders(MindFusion.Drawing.IGraphics g) {
			if (!isMonitoring || main_diagram == null || main_diagram.Nodes == null) return;

			foreach (DiagramNode node in main_diagram.Nodes) {
				if (node is ShapeNode shapeNode) {
					if (shapeNode.Tag is DeviceInfo dev && !dev.isDumy) {
						int failCount = -1;
						lock (dictFailCount) {
							string k = dev.id.ToString();
							if (dictFailCount.ContainsKey(k)) failCount = dictFailCount[k];
							else if (!string.IsNullOrEmpty(dev.addr) && dictFailCount.ContainsKey(dev.addr.Trim())) failCount = dictFailCount[dev.addr.Trim()];
							else if (!string.IsNullOrEmpty(dev.name) && dictFailCount.ContainsKey(dev.name.Trim())) failCount = dictFailCount[dev.name.Trim()];
						}

						if (failCount >= 0) {
							System.Drawing.Color borderColor = GetStatusBorderColor(failCount);
							using (var pen = new System.Drawing.Pen(borderColor, 2.5f)) {
								RectangleF bounds = shapeNode.Bounds;
								g.DrawRectangle(pen, bounds.X, bounds.Y, bounds.Width, bounds.Height);
							}
						}
					}
				}
			}
		}

		private void DiagramInit() {
			main_diagram.NodeCreated += main_diagram_NodeCreated;
			main_diagram.NodeClicked += main_diagram_NodeClicked;
			main_diagram.DrawBackground += (s, e) => {
				DrawCustomBackground(e.Graphics);
			};
			main_diagram.DrawForeground += (s, e) => {
				DrawDisconnectedNodeMarks(e.Graphics);
				DrawMonitoringStatusBorders(e.Graphics);
			};
			main_diagram.LinkDeleted += (s, e) => {
				dv_netview.Invalidate();
				dv_netview.Refresh();
			};
			main_diagram.UndoManager.UndoEnabled = true;
			main_diagram.ActionUndone += Main_diagram_ActionUndone;
			main_diagram.ActionRedone += Main_diagram_ActionRedone;
			main_diagram.ShadowsStyle = ShadowsStyle.None;
			main_diagram.SelectionChanged += Main_diagram_SelectionChanged;
			dv_netview.Behavior = MindFusion.Diagramming.Behavior.Modify;
			dv_netview.ControlHandlesStyle = MindFusion.Diagramming.HandlesStyle.InvisibleMove;
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
				} catch (Exception) { }
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
				} catch (Exception) { }
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

		private readonly System.Drawing.Color mNodeSelectedBorderColor = System.Drawing.Color.Blue;
		private readonly System.Drawing.Color mNodeSelectedBackColor = System.Drawing.Color.FromArgb(215, 235, 255);

		private void Main_diagram_SelectionChanged(object sender, EventArgs e)
		{
			UpdateAllNodesSelectionStyle();
		}

		private void UpdateAllNodesSelectionStyle()
		{
			foreach (DiagramNode node in main_diagram.Nodes)
			{
				UpdateNodeAppearance(node);
			}
			dv_netview.Invalidate();
			dv_netview.Refresh();
		}

		private System.Drawing.Color GetStatusBorderColor(int failCount)
		{
			try
			{
				if (failCount == -1)
				{
					// 대기 상태 (회색)
					string hex = Global.mConfigInfo?.colorBack_1_1;
					if (!string.IsNullOrEmpty(hex)) return System.Drawing.ColorTranslator.FromHtml(hex);
					return System.Drawing.Color.Gray;
				}
				else if (failCount == 0)
				{
					// 정상 (<= Timeout, 녹색)
					string hex = Global.mConfigInfo?.colorBack_1_2;
					if (!string.IsNullOrEmpty(hex)) return System.Drawing.ColorTranslator.FromHtml(hex);
					return System.Drawing.Color.FromArgb(0, 255, 0);
				}
				else if (failCount <= monitorCheckTimes)
				{
					// 지연/타임아웃 발생 중 (1~4 Timeout, 주황색)
					string hex = Global.mConfigInfo?.colorBack_2_1;
					if (!string.IsNullOrEmpty(hex)) return System.Drawing.ColorTranslator.FromHtml(hex);
					return System.Drawing.Color.Orange;
				}
				else
				{
					// 장애 (>= Timeout, 적색)
					string hex = Global.mConfigInfo?.colorBack_2_2;
					if (!string.IsNullOrEmpty(hex)) return System.Drawing.ColorTranslator.FromHtml(hex);
					return System.Drawing.Color.Red;
				}
			}
			catch
			{
				return failCount == 0 ? System.Drawing.Color.Green : (failCount > monitorCheckTimes ? System.Drawing.Color.Red : System.Drawing.Color.Orange);
			}
		}

		private void UpdateNodeAppearance(DiagramNode node) {
			if (node is ShapeNode shapeNode) {
				node.ZTop(false);
				
				// [추가] 그림자 제거
				shapeNode.ShadowOffsetX = 0;
				shapeNode.ShadowOffsetY = 0;

				if (shapeNode.Selected) {
					// 선택된 노드: 바탕색(연청색), 테두리색(청색)
					shapeNode.Transparent = false;
					shapeNode.Brush = new MindFusion.Drawing.SolidBrush(mNodeSelectedBackColor);
					shapeNode.Pen = new MindFusion.Drawing.Pen(mNodeSelectedBorderColor, 2.0f);
				} else {
					// 비선택 노드는 항상 완전 투명 유지 (배경 회색 방지)
					shapeNode.Transparent = true;
					shapeNode.Pen = new MindFusion.Drawing.Pen(System.Drawing.Color.Transparent, 0f);
				}

				if (shapeNode.Tag is DeviceInfo device) {
					// 이미지 업데이트
					SystemInfo sysInfo = SystemInfo.Find(lv_system, device);
					if (sysInfo != null && !string.IsNullOrEmpty(sysInfo.imagePath) && System.IO.File.Exists(sysInfo.imagePath)) {
						try {
							shapeNode.Image = System.Drawing.Image.FromFile(sysInfo.imagePath);
						} catch {
							if (shapeNode.Image == null) shapeNode.Image = global::GTWave.Properties.Resources.no_image;
						}
					} else {
						if (shapeNode.Image == null) shapeNode.Image = global::GTWave.Properties.Resources.no_image;
					}
				}
			}
		}
		
		private void main_diagram_NodeClicked(object sender, NodeEventArgs e) {
			if (e.MouseButton == MindFusion.Diagramming.MouseButton.Left) {
				main_diagram.Selection.Clear();
				e.Node.Selected = true;
				UpdateAllNodesSelectionStyle();
			} else if (e.MouseButton == MindFusion.Diagramming.MouseButton.Right) {
				DiagramNode targetNode = e.Node;
				DeviceInfo dev = GetDeviceInfoFromNode(targetNode);

				ContextMenuStrip contextMenu = new ContextMenuStrip();

				// 1. Device 상태보기
				ToolStripMenuItem miStatus = new ToolStripMenuItem("Device 상태보기");
				miStatus.Click += (s, ev) => {
					if (dev == null) {
						MessageBox.Show("연결된 장비 정보가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					SystemInfo sysInfo = SystemInfo.Find(lv_system, dev);
					int type = (sysInfo != null) ? sysInfo.GetType() : -1;
					string devTypeLower = (dev.type ?? "").ToLower();

					bool isWireless = (type == 2) || devTypeLower.Contains("무선") || devTypeLower.Contains("wireless") || devTypeLower.Contains("wifi") || devTypeLower.Contains("ap");

					if (isWireless) {
						WifiStatusForm wifiStatus = new WifiStatusForm();
						wifiStatus.cb_ip.Text = dev.addr;
						wifiStatus.tb_port.Text = dev.connPort > 0 ? dev.connPort.ToString() : "80";
						wifiStatus.scanProtocol = (!string.IsNullOrWhiteSpace(dev.connType) && dev.connType.Trim().ToLower() == "https") ? "https" : "http";
						wifiStatus.ShowDialog();
					} else {
						StatusSwitch statusSwitch = new StatusSwitch(dev);
						statusSwitch.ShowDialog();
					}
				};

				// 2. Device 접속 (웹브라우저 실행)
				ToolStripMenuItem miConn = new ToolStripMenuItem("Device 접속");
				miConn.Click += (s, ev) => {
					if (dev == null || string.IsNullOrWhiteSpace(dev.addr)) {
						MessageBox.Show("장비 IP 정보가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					string scheme = (!string.IsNullOrWhiteSpace(dev.connType) && dev.connType.Trim().ToLower() == "https") ? "https" : "http";
					int port = dev.connPort > 0 ? dev.connPort : (scheme == "https" ? 443 : 80);
					string url = $"{scheme}://{dev.addr}:{port}";

					try {
						System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo {
							FileName = url,
							UseShellExecute = true
						});
					} catch (Exception ex) {
						MessageBox.Show($"웹 브라우저를 실행할 수 없습니다.\nURL: {url}\n{ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				};

				// 3. Ping 명령 (CMD 실행)
				ToolStripMenuItem miPing = new ToolStripMenuItem("Ping 명령");
				miPing.Click += (s, ev) => {
					if (dev == null || string.IsNullOrWhiteSpace(dev.addr)) {
						MessageBox.Show("장비 IP 정보가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					bool isTcping = !string.IsNullOrWhiteSpace(dev.checkType) && dev.checkType.Trim().ToLower().Contains("tcping");
					string cmdArgs = "";
					if (isTcping) {
						int port = dev.checkPort > 0 ? dev.checkPort : 80;
						cmdArgs = $"/K tcping -t {dev.addr} {port}";
					} else {
						cmdArgs = $"/K ping -t {dev.addr}";
					}

					try {
						System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo {
							FileName = "cmd.exe",
							Arguments = cmdArgs,
							UseShellExecute = true
						});
					} catch (Exception ex) {
						MessageBox.Show($"CMD 명령을 실행할 수 없습니다.\n{ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				};

				bool canModify = !isMonitoring && !isDiagramLocked;

				// 4. Device 수정
				ToolStripMenuItem miEdit = new ToolStripMenuItem("Device 수정");
				miEdit.Enabled = canModify;
				miEdit.Click += (s, ev) => {
					if (isMonitoring || isDiagramLocked) {
						MessageBox.Show(isMonitoring ? "모니터링 중에는 장비를 수정할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 장비를 수정할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					if (dev == null) {
						MessageBox.Show("연결된 장비 정보가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					DeviceDialog dialog = new DeviceDialog(dev);
					dialog.mViewMode = "fix";
					dialog.mForm = this;
					if (dialog.ShowDialog() == DialogResult.OK) {
						DeviceInfo updatedDev = DeviceInfo.Load2Db(dev.id, GlobalHelpers.mDeviceTb);
						if (updatedDev != null) {
							FixDevice2Diagram(updatedDev, dev);
						} else {
							UpdateNodeLabel(targetNode);
							UpdateNodeAppearance(targetNode);
							dv_netview.Refresh();
						}
						string group_name = GetNodePath(mCurGroupNode);
						DispDeviceList(group_name);
					}
				};

				// 5. Device 삭제
				ToolStripMenuItem miDelete = new ToolStripMenuItem("Device 삭제");
				miDelete.Enabled = canModify;
				miDelete.Click += (s, ev) => {
					if (isMonitoring || isDiagramLocked) {
						MessageBox.Show(isMonitoring ? "모니터링 중에는 장비를 삭제할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 장비를 삭제할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					if (dev == null) {
						MessageBox.Show("연결된 장비 정보가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					if (MessageBox.Show($"'{dev.name}' 장비를 삭제하시겠습니까?", "장비 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
						main_diagram.Nodes.Remove(targetNode);
						GlobalHelpers.mDeviceTb.DeleteMany(x => x.id.Equals(dev.id));
						LoadTotalDevices();
						string group_name = GetNodePath(mCurGroupNode);
						DispDeviceList(group_name);
						dv_netview.Refresh();
					}
				};

				contextMenu.Items.Add(miStatus);
				contextMenu.Items.Add(new ToolStripSeparator());
				contextMenu.Items.Add(miConn);
				contextMenu.Items.Add(miPing);
				contextMenu.Items.Add(new ToolStripSeparator());
				contextMenu.Items.Add(miEdit);
				contextMenu.Items.Add(miDelete);

				contextMenu.Show(Cursor.Position);
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
			dv_netview.Invalidate();
			dv_netview.Refresh();
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
			if (isMonitoring) return;
			main_diagram.UndoManager.Undo();
		}

		private void	bt_redo_Click(object sender, EventArgs e) {
			if (isMonitoring) return;
			main_diagram.UndoManager.Redo();
		}

		private void Main_diagram_ActionUndone(object sender, MindFusion.Diagramming.UndoEventArgs e) {
			try {
				ProcessDiagramCommand(e.Command, isUndo: true);
			} catch (Exception ex) {
				Debug.WriteLine("ActionUndone error: " + ex.Message);
			}
		}

		private void Main_diagram_ActionRedone(object sender, MindFusion.Diagramming.UndoEventArgs e) {
			try {
				ProcessDiagramCommand(e.Command, isUndo: false);
			} catch (Exception ex) {
				Debug.WriteLine("ActionRedone error: " + ex.Message);
			}
		}

		private void ProcessDiagramCommand(MindFusion.Diagramming.Commands.Command cmd, bool isUndo) {
			if (cmd == null) return;

			if (cmd is MindFusion.Diagramming.Commands.RemoveItemCmd removeCmd) {
				if (removeCmd.Item is DiagramNode node) {
					DeviceInfo dev = GetDeviceInfoFromNode(node);
					if (dev != null) {
						if (isUndo) {
							// 삭제 취소(Undo) -> DB 복원 및 UI 갱신
							GlobalHelpers.mDeviceTb.Upsert(dev);
						} else {
							// 다시 삭제(Redo) -> DB 삭제 및 UI 갱신
							GlobalHelpers.mDeviceTb.DeleteMany(x => x.id.Equals(dev.id));
						}
						RefreshDeviceUI();
					}
				}
			} else if (cmd is MindFusion.Diagramming.Commands.AddItemCmd addCmd) {
				if (addCmd.Item is DiagramNode node) {
					DeviceInfo dev = GetDeviceInfoFromNode(node);
					if (dev != null) {
						if (isUndo) {
							// 추가 취소(Undo) -> DB 삭제 및 UI 갱신
							GlobalHelpers.mDeviceTb.DeleteMany(x => x.id.Equals(dev.id));
						} else {
							// 다시 추가(Redo) -> DB 복원 및 UI 갱신
							GlobalHelpers.mDeviceTb.Upsert(dev);
						}
						RefreshDeviceUI();
					}
				}
			} else if (cmd is MindFusion.Diagramming.Commands.CompositeCmd compositeCmd) {
				foreach (MindFusion.Diagramming.Commands.Command subCmd in compositeCmd.SubCommands) {
					ProcessDiagramCommand(subCmd, isUndo);
				}
			}
		}

		private DeviceInfo GetDeviceInfoFromNode(DiagramNode node) {
			if (node == null) return null;
			if (node.Tag is DeviceInfo dev) return dev;
			if (node.Tag != null) {
				try {
					int nodeId = Convert.ToInt32(node.Tag);
					return DeviceInfo.Load2Db(nodeId, GlobalHelpers.mDeviceTb);
				} catch { }
			}
			return null;
		}

		private void RefreshDeviceUI() {
			LoadTotalDevices();
			if (mCurGroupNode != null) {
				string group_name = GetNodePath(mCurGroupNode);
				DispDeviceList(group_name);
			}
		}

		private void	bt_load_ncd_Click(object sender, EventArgs e) {
			if (isMonitoring) {
				MessageBox.Show("모니터링 실행 중에는 구성도를 불러올 수 없습니다.\n먼저 모니터링을 중지해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			System.Windows.Forms.OpenFileDialog f = new System.Windows.Forms.OpenFileDialog();
			f.Filter = "구성도 패키지 파일|*.gtw;*.mf|모든 파일|*.*";

			if (f.ShowDialog() == DialogResult.OK) {
				if (GTWave.utils.DiagramPackageUtil.LoadPackage(f.FileName, out byte[] diagramBytes, out var groups, out var devices, out System.Drawing.Image loadedBgImage)) {
					// 1. 장비 DB 복원
					GlobalHelpers.mDeviceTb.DeleteAll();
					if (devices != null && devices.Count > 0) {
						// [대비책] 현재 시스템에 등록되지 않은 디바이스 종류 확인 및 자동 등록/보완
						try {
							var registeredSystems = GlobalHelpers.mSystemTb.Query().ToList();
							var registeredTypeNames = new HashSet<string>(registeredSystems.Select(x => x.name ?? ""), StringComparer.OrdinalIgnoreCase);

							List<string> missingTypes = new List<string>();
							foreach (var dev in devices) {
								if (!string.IsNullOrWhiteSpace(dev.type) && !registeredTypeNames.Contains(dev.type)) {
									if (!missingTypes.Contains(dev.type)) {
										missingTypes.Add(dev.type);
									}
								}
							}

							if (missingTypes.Count > 0) {
								foreach (var mType in missingTypes) {
									SystemInfo newSys = new SystemInfo {
										name = mType,
										spec = "자동 등록 (구성도 가져오기)",
										desc = "구성도 파일에서 불러온 디바이스 종류",
										imagePath = ""
									};
									GlobalHelpers.mSystemTb.Insert(newSys);
									registeredTypeNames.Add(mType);
								}
								RefreshSystem();
							}
						} catch (Exception ex) {
							Debug.WriteLine("디바이스 종류 동기화 오류: " + ex.Message);
						}

						GlobalHelpers.mDeviceTb.InsertBulk(devices);
					}
					LoadTotalDevices();

					// 2. 그룹 트리 UI 복원
					GTWave.utils.DiagramPackageUtil.ImportTreeNodes(tv_group.Nodes, groups);
					if (tv_group.Nodes.Count == 0) {
						TreeNode defaultNode = tv_group.Nodes.Add("전체 그룹");
						GroupInfo defaultGroup = new GroupInfo(defaultNode.Text);
						defaultNode.Tag = defaultGroup;
						defaultGroup.node = defaultNode;
					}
					tv_group.ExpandAll();
					SaveTree(tv_group, "group.mvia");

					if (tv_group.Nodes.Count > 0) {
						mCurGroupNode = tv_group.Nodes[0];
						tv_group.SelectedNode = mCurGroupNode;
						string group_name = GetNodePath(mCurGroupNode);
						DispDeviceList(group_name);
					}

					// 3. 다이어그램 복원
					if (diagramBytes != null && diagramBytes.Length > 0) {
						using (MemoryStream ms = new MemoryStream(diagramBytes)) {
							dv_netview.LoadFromStream(ms);
						}
					}

					// 4. 배경 이미지 복원
					if (loadedBgImage != null) {
						mBackgroundBkImage = loadedBgImage;
						mBkImagePath = "";
					} else {
						mBackgroundBkImage = null;
						mBkImagePath = "";
					}
				} else {
					// 기존 단일 .mf 파일 하위 호환성 유지
					dv_netview.LoadFromFile(f.FileName);
					mBackgroundBkImage = main_diagram.BackgroundImage;
				}

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

				if (!isDiagramLocked) {
					dv_netview.Behavior = MindFusion.Diagramming.Behavior.Modify;
					dv_netview.AllowInplaceEdit = true;
				}

				//File = Image.FromFile(f.FileName);
				//main_diagram.BackgroundImage = File;
			}
		}

		private void bt_save_ncd_Click(object sender, EventArgs e) {
			if (isMonitoring) {
				MessageBox.Show("모니터링 실행 중에는 구성도를 저장할 수 없습니다.\n먼저 모니터링을 중지해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

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

				List<DeviceInfo> devices = GlobalHelpers.mDeviceTb.Query().ToList();
				bool success = GTWave.utils.DiagramPackageUtil.SavePackage(saveFileDialog1.FileName, dv_netview, tv_group, devices, mBackgroundBkImage);

				if (success) {
					MessageBox.Show("구성도가 성공적으로 저장되었습니다.", "저장 완료");
				} else {
					MessageBox.Show("구성도 저장 실패", "오류");
				}
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
					FitDiagramToView();
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
					FitDiagramToView();
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

				// [추가] 장비 추가 요청 시 창을 닫지 않고 즉시 DeviceDialog 호출
				finder.OnDevicesAdd = (selectedDevices) => {
					foreach (var d in selectedDevices) {
						DeviceInfo dInfo = new DeviceInfo(-1);
						dInfo.addr = d.Ip;
						dInfo.name = d.Name;
						dInfo.type = d.Model.ToUpper().Contains("SWITCH") ? "스위치" : "무선";
						dInfo.groupNm = d.Group;

						// 장비 등록 다이얼로그 호출
						DeviceDialog dialog = new DeviceDialog(dInfo);
						dialog.mViewMode = "add";
						dialog.mForm = this;
						dialog.ShowDialog(finder);

						// 장비 등록 후 리스트 새로고침
						DispDeviceList(dInfo.groupNm);
					}
				};
				
				finder.ShowDialog();

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

		/// <summary>
		/// tv_group 의 전체 그룹 경로 목록을 수집합니다. (DeviceDialog 에서 그룹 콤보박스 채우기용)
		/// </summary>
		public void CollectGroupPaths(TreeNodeCollection nodes, List<string> paths) {
			foreach (TreeNode node in nodes) {
				paths.Add(GetNodePath(node));
				if (node.Nodes.Count > 0) {
					CollectGroupPaths(node.Nodes, paths);
				}
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

		private void InitMonitoringIcons()
		{
			try
			{
				if (imgMonStartActive != null) imgMonStartActive.Dispose();
				if (imgMonStartInactive != null) imgMonStartInactive.Dispose();
				if (imgMonStopActive != null) imgMonStopActive.Dispose();
				if (imgMonStopInactive != null) imgMonStopInactive.Dispose();

				imgMonStartActive = CreateMonIcon("play", true);
				imgMonStartInactive = CreateMonIcon("play", false);
				imgMonStopActive = CreateMonIcon("stop", true);
				imgMonStopInactive = CreateMonIcon("stop", false);
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "InitMonitoringIcons Error");
			}
		}

		private static Bitmap CreateMonIcon(string type, bool active, int width = 24, int height = 21)
		{
			Bitmap bmp = new Bitmap(width, height);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
				g.Clear(System.Drawing.Color.Transparent);

				int size = Math.Min(width, height) - 2;
				int x = (width - size) / 2;
				int y = (height - size) / 2;
				System.Drawing.Rectangle rect = new System.Drawing.Rectangle(x, y, size, size);

				if (type == "play")
				{
					System.Drawing.Color circleColor = active ? System.Drawing.Color.FromArgb(0, 122, 255) : System.Drawing.Color.FromArgb(215, 218, 222);
					System.Drawing.Color iconColor = active ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(160, 165, 170);

					using (SolidBrush brush = new SolidBrush(circleColor))
					{
						g.FillEllipse(brush, rect);
					}

					float cx = rect.X + rect.Width * 0.52f;
					float cy = rect.Y + rect.Height * 0.5f;
					float r = size * 0.26f;

					System.Drawing.PointF[] points = new System.Drawing.PointF[]
					{
						new System.Drawing.PointF(cx - r * 0.7f, cy - r),
						new System.Drawing.PointF(cx + r * 1.0f, cy),
						new System.Drawing.PointF(cx - r * 0.7f, cy + r)
					};

					using (SolidBrush iconBrush = new SolidBrush(iconColor))
					{
						g.FillPolygon(iconBrush, points);
					}
				}
				else if (type == "stop")
				{
					System.Drawing.Color circleColor = active ? System.Drawing.Color.FromArgb(235, 60, 60) : System.Drawing.Color.FromArgb(215, 218, 222);
					System.Drawing.Color iconColor = active ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(160, 165, 170);

					using (SolidBrush brush = new SolidBrush(circleColor))
					{
						g.FillEllipse(brush, rect);
					}

					int stopSize = (int)(size * 0.40f);
					int sx = rect.X + (rect.Width - stopSize) / 2;
					int sy = rect.Y + (rect.Height - stopSize) / 2;

					using (SolidBrush iconBrush = new SolidBrush(iconColor))
					{
						g.FillRectangle(iconBrush, new System.Drawing.Rectangle(sx, sy, stopSize, stopSize));
					}
				}
			}
			return bmp;
		}

		private System.Drawing.Image LoadToolbarIcon(string filename)
		{
			try
			{
				// 1. 실행파일 내장 리소스(Embedded Resource)에서 우선 로드
				var asm = System.Reflection.Assembly.GetExecutingAssembly();
				string resName = "GTWave.Resources.toolbar." + filename;
				var stream = asm.GetManifestResourceStream(resName);
				if (stream == null)
				{
					string found = Array.Find(asm.GetManifestResourceNames(), n => n.EndsWith("." + filename, StringComparison.OrdinalIgnoreCase));
					if (!string.IsNullOrEmpty(found))
					{
						stream = asm.GetManifestResourceStream(found);
					}
				}

				if (stream != null)
				{
					using (stream)
					{
						using (var temp = System.Drawing.Image.FromStream(stream))
						{
							return new System.Drawing.Bitmap(temp);
						}
					}
				}

				// 2. 외부 파일 경로에서 로드 (기존 로직 유지)
				string[] tryPaths = new string[]
				{
					System.IO.Path.Combine(Application.StartupPath, "Resources", "toolbar", filename),
					System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "toolbar", filename),
					System.IO.Path.Combine(Application.StartupPath, "..", "..", "Resources", "toolbar", filename),
					System.IO.Path.Combine(@"C:\GTWave\bin", "Resources", "toolbar", filename),
					System.IO.Path.Combine(curWorkPath, "Resources", "toolbar", filename),
					System.IO.Path.Combine(curWorkPath, "GTWaveMgr", "Resources", "toolbar", filename)
				};

				foreach (string p in tryPaths)
				{
					if (System.IO.File.Exists(p))
					{
						byte[] bytes = System.IO.File.ReadAllBytes(p);
						using (System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes))
						{
							return System.Drawing.Image.FromStream(ms);
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, $"LoadToolbarIcon Error: {filename}");
			}
			return null;
		}

		private static System.Drawing.Image CreateDisabledImage(System.Drawing.Image original)
		{
			if (original == null) return null;
			Bitmap bmp = new Bitmap(original.Width, original.Height);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				System.Drawing.Imaging.ColorMatrix matrix = new System.Drawing.Imaging.ColorMatrix(new float[][]
				{
					new float[] { 0.3f, 0.3f, 0.3f, 0, 0 },
					new float[] { 0.59f, 0.59f, 0.59f, 0, 0 },
					new float[] { 0.11f, 0.11f, 0.11f, 0, 0 },
					new float[] { 0, 0, 0, 0.35f, 0 },
					new float[] { 0, 0, 0, 0, 1 }
				});
				using (System.Drawing.Imaging.ImageAttributes attr = new System.Drawing.Imaging.ImageAttributes())
				{
					attr.SetColorMatrix(matrix);
					g.DrawImage(original, new System.Drawing.Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attr);
				}
			}
			return bmp;
		}

		private void InitToolbarShortcuts()
		{
			try
			{
				if (pn_top_info == null) return;

				// 기존 4개의 작은 버튼들은 숨김 처리 (기존 참조는 그대로 보존)
				if (bt_finder != null) bt_finder.Visible = false;
				if (pb_full_screen != null) pb_full_screen.Visible = false;
				if (bt_mon_start != null) bt_mon_start.Visible = false;
				if (bt_mon_stop != null) bt_mon_stop.Visible = false;
				if (bt_status_mon != null) bt_status_mon.Visible = false;

				pn_top_info.Height = 44;

				if (btnToolTip == null) btnToolTip = new ToolTip();
				btnToolTip.InitialDelay = 200;
				btnToolTip.AutoPopDelay = 5000;
				btnToolTip.ReshowDelay = 100;

				int btnSize = 27;
				int btnY = 4;
				int curX = 10;
				int spacing = 6;

				Button CreateBtn(string iconName, string tooltipText, EventHandler onClick)
				{
					Button btn = new Button();
					btn.Size = new System.Drawing.Size(btnSize, btnSize);
					btn.Location = new System.Drawing.Point(curX, btnY);
					btn.FlatStyle = FlatStyle.Flat;
					btn.FlatAppearance.BorderSize = 0;
					btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(220, 230, 245);
					btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(190, 210, 235);
					btn.BackColor = System.Drawing.Color.Transparent;
					btn.Cursor = Cursors.Hand;
					btn.BackgroundImageLayout = ImageLayout.Zoom;
					btn.BackgroundImage = LoadToolbarIcon(iconName);
					if (onClick != null) btn.Click += onClick;
					btnToolTip.SetToolTip(btn, tooltipText);
					pn_top_info.Controls.Add(btn);
					btn.BringToFront();
					curX += btnSize + spacing;
					return btn;
				}

				void AddSeparator()
				{
					Panel sep = new Panel();
					sep.Size = new System.Drawing.Size(1, 20);
					sep.Location = new System.Drawing.Point(curX + 2, 7);
					sep.BackColor = System.Drawing.Color.FromArgb(195, 195, 195);
					pn_top_info.Controls.Add(sep);
					sep.BringToFront();
					curX += 9;
				}

				// 그룹 1: 전체화면, Device 검색
				btn_tb_fullscreen = CreateBtn("01_fullscreen.png", "전체화면", (s, e) => pb_full_screen_Click(s, e));
				btn_tb_dev_search = CreateBtn("02_device_search.png", "Device 검색", (s, e) => bt_finder_Click(s, e));

				AddSeparator();

				// 그룹 2: Device 추가, 수정, 삭제
				btn_tb_dev_add = CreateBtn("03_device_add.png", "Device 추가", (s, e) => 시스템추가ToolStripMenuItem_Click(s, e));
				btn_tb_dev_edit = CreateBtn("04_device_edit.png", "Device 수정", (s, e) => 시스템수정ToolStripMenuItem_Click(s, e));
				btn_tb_dev_del = CreateBtn("05_device_delete.png", "Device 삭제", (s, e) => 시스템삭제ToolStripMenuItem_Click(s, e));

				AddSeparator();

				// 그룹 3: 구성도 잠금
				btn_tb_diagram_lock = CreateBtn("06_diagram_lock.png", isDiagramLocked ? "구성도 잠금해제" : "구성도 잠금", (s, e) =>
				{
					if (isMonitoring)
					{
						MessageBox.Show("모니터링 중에는 구성도 잠금 상태를 변경할 수 없습니다.\n먼저 모니터링을 중지해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					ApplyDiagramLockUI(!isDiagramLocked, true);
				});

				AddSeparator();

				// 그룹 4: 모니터링 시작, 모니터링 중지
				imgTbMonStartActive = LoadToolbarIcon("07_monitor_start.png");
				imgTbMonStartDisabled = CreateDisabledImage(imgTbMonStartActive);
				imgTbMonStopActive = LoadToolbarIcon("08_monitor_stop.png");
				imgTbMonStopDisabled = CreateDisabledImage(imgTbMonStopActive);

				btn_tb_mon_start = CreateBtn("07_monitor_start.png", "모니터링 시작", (s, e) => bt_mon_start_Click(s, e));
				btn_tb_mon_stop = CreateBtn("08_monitor_stop.png", "모니터링 중지", (s, e) => bt_mon_stop_Click(s, e));

				AddSeparator();

				// 그룹 5: 보고서 출력, 환경설정
				btn_tb_report_print = CreateBtn("09_report_print.png", "보고서 출력", (s, e) =>
				{
					ContextMenuStrip reportMenu = new ContextMenuStrip();
					ToolStripMenuItem miMon = new ToolStripMenuItem("모니터링 결과 보고서", null, (ms, me) => bt_ping_print_Click(ms, me));
					ToolStripMenuItem miLog = new ToolStripMenuItem("로그 보고서", null, (ms, me) => bt_log_print_Click(ms, me));
					reportMenu.Items.Add(miMon);
					reportMenu.Items.Add(miLog);
					reportMenu.Show(btn_tb_report_print, new System.Drawing.Point(0, btn_tb_report_print.Height));
				});
				btn_tb_settings = CreateBtn("10_settings.png", "환경설정", (s, e) => 환경세팅ToolStripMenuItem_Click(s, e));

				UpdateMonitoringButtonsUI(isMonitoring);
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "InitToolbarShortcuts Error");
			}
		}

		public void UpdateMonitoringButtonsUI(bool monitoring)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new System.Action(() => UpdateMonitoringButtonsUI(monitoring)));
				return;
			}

			if (bt_mon_start != null)
			{
				bt_mon_start.Enabled = !monitoring;
				bt_mon_start.BackgroundImage = !monitoring ? imgMonStartActive : imgMonStartInactive;
				bt_mon_start.Cursor = !monitoring ? Cursors.Hand : Cursors.Default;
			}

			if (bt_mon_stop != null)
			{
				bt_mon_stop.Enabled = monitoring;
				bt_mon_stop.BackgroundImage = monitoring ? imgMonStopActive : imgMonStopInactive;
				bt_mon_stop.Cursor = monitoring ? Cursors.Hand : Cursors.Default;
			}

			if (btn_tb_mon_start != null)
			{
				btn_tb_mon_start.Enabled = !monitoring;
				if (imgTbMonStartActive != null && imgTbMonStartDisabled != null)
				{
					btn_tb_mon_start.BackgroundImage = !monitoring ? imgTbMonStartActive : imgTbMonStartDisabled;
				}
				btn_tb_mon_start.Cursor = !monitoring ? Cursors.Hand : Cursors.Default;
				if (!monitoring)
				{
					btn_tb_mon_start.BackColor = System.Drawing.Color.Transparent;
				}
			}

			if (btn_tb_mon_stop != null)
			{
				btn_tb_mon_stop.Enabled = monitoring;
				if (imgTbMonStopActive != null && imgTbMonStopDisabled != null)
				{
					btn_tb_mon_stop.BackgroundImage = monitoring ? imgTbMonStopActive : imgTbMonStopDisabled;
				}
				btn_tb_mon_stop.Cursor = monitoring ? Cursors.Hand : Cursors.Default;
			}
		}

		private void bt_mon_start_Click(object sender, EventArgs e)
		{
			if (isMonitoring) return;

			LoadMonitorConfig(); // [추가] 설정 파일 로드
			LoadTotalDevices();  // 최신 장비 목록 로드
			isMonitoring = true;
			if (main_diagram != null) {
				main_diagram.Selection.Clear();
				UpdateAllNodesSelectionStyle();
			}
			dv_netview.Behavior = MindFusion.Diagramming.Behavior.DoNothing;
			dv_netview.AllowInplaceEdit = false;
			SetMonitoringLockUI(true);
			dictFailCount.Clear();
			dictLastDownState.Clear();
			mMonitorStartTime = System.DateTime.Now;
			mMonitorStopTime = null;
			InitOrResetPingStats();

			UpdateMonitoringButtonsUI(true);
			AddDeviceLog("PROGRAM", "", "", "", "모니터링을 시작합니다.");
			if (lbl_status_mon_time != null)
			{
				lbl_status_mon_time.Text = $"시작 일시: {mMonitorStartTime:yyyy-MM-dd HH:mm:ss}";
			}

			if (lbl_status_check_result != null)
			{
				int validCount = mTotDevice != null ? mTotDevice.Count(dev => !dev.isDumy && !string.IsNullOrWhiteSpace(dev.addr) && dev.addr != "0.0.0.0" && System.Net.IPAddress.TryParse(dev.addr, out _) && !dev.addr.Contains(":")) : 0;
				lbl_status_check_result.Text = $"[모니터링 요약]  전체: {validCount} | 정상: 0, 대기: {validCount}, 실패: 0 | 소요시간: -";
			}

			// [추가] 모니터링 시작 버튼 애니메이션 타이머 시작
			gradientOffset = 0;
			monitoringAnimationTimer.Start();

			// 비동기 루프 기동 (백그라운드 실행)
			Task.Run(async () => await MonitoringLoopAsync());
		}

		private void bt_mon_stop_Click(object sender, EventArgs e)
		{
			if (!isMonitoring) return;

			isMonitoring = false;
			if (!isDiagramLocked) {
				dv_netview.Behavior = MindFusion.Diagramming.Behavior.Modify;
				dv_netview.AllowInplaceEdit = true;
			}
			SetMonitoringLockUI(false);
			mMonitorStopTime = System.DateTime.Now;
			monitoringAnimationTimer.Stop();
			if (btn_tb_mon_start != null && !btn_tb_mon_start.IsDisposed) {
				btn_tb_mon_start.FlatAppearance.BorderSize = 0;
				btn_tb_mon_start.BackColor = System.Drawing.Color.Transparent;
			}
			UpdateMonitoringButtonsUI(false);
			UpdateAllNodesSelectionStyle();
			AddDeviceLog("PROGRAM", "", "", "", "모니터링을 종료합니다.");
			if (lbl_status_mon_time != null)
			{
				lbl_status_mon_time.Text = $"종료 일시: {mMonitorStopTime.Value:yyyy-MM-dd HH:mm:ss}";
			}
			if (lbl_status_countdown != null)
			{
				lbl_status_countdown.Text = "-";
			}
		}

		private void bt_status_mon_Click(object sender, EventArgs e)
		{
			if (isMonitoring)
			{
				bt_mon_stop_Click(sender, e);
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
				bt_mon_start_Click(sender, e);
				bt_status_mon.Text = "모니터링 중";
				
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
				var swCheck = System.Diagnostics.Stopwatch.StartNew();
				// Create a copy to avoid modification exceptions during iteration
				List<DeviceInfo> checkList;
				lock (mTotDevice)
				{
					checkList = new List<DeviceInfo>(mTotDevice);
				}

				List<DeviceInfo> cycleNewDownDevices = new List<DeviceInfo>();
				object cycleDownLock = new object();

				var tasks = checkList.Select(async dev =>
				{
					if (!isMonitoring) return;
					if (string.IsNullOrWhiteSpace(dev.addr) || dev.addr == "0.0.0.0") return;
					if (dev.isDumy) return;

					// IPv4 format validation
					if (!System.Net.IPAddress.TryParse(dev.addr, out System.Net.IPAddress _) || dev.addr.Contains(":")) return;

					try
					{
						bool isTcping = !string.IsNullOrWhiteSpace(dev.checkType) && dev.checkType.Trim().ToLower().Contains("tcping");
						bool isSuccess = false;
						long roundtripTime = 0;
						string statusMsg = "";

						if (isTcping)
						{
							int targetPort = dev.checkPort > 0 ? dev.checkPort : (dev.connPort > 0 ? dev.connPort : 80);
							var swTcp = System.Diagnostics.Stopwatch.StartNew();
							try
							{
								using (var tcpClient = new System.Net.Sockets.TcpClient())
								{
									var connectTask = tcpClient.ConnectAsync(dev.addr, targetPort);
									var delayTask = Task.Delay(monitorTimeout);
									var completedTask = await Task.WhenAny(connectTask, delayTask);
									swTcp.Stop();
									roundtripTime = swTcp.ElapsedMilliseconds;

									if (completedTask == connectTask && tcpClient.Connected)
									{
										isSuccess = true;
										statusMsg = $"Success: {roundtripTime}ms";
									}
									else
									{
										isSuccess = false;
										statusMsg = "TimeOut";
									}
								}
							}
							catch
							{
								swTcp.Stop();
								roundtripTime = swTcp.ElapsedMilliseconds;
								isSuccess = false;
								statusMsg = "TimeOut";
							}
						}
						else
						{
							using (Ping pingSender = new Ping())
							{
								byte[] buffer = new byte[monitorPacketSize];
								new Random().NextBytes(buffer); // 더미 데이터 채움
								PingReply reply = await pingSender.SendPingAsync(dev.addr, monitorTimeout, buffer);
								roundtripTime = reply.RoundtripTime;
								if (reply.Status == IPStatus.Success)
								{
									isSuccess = true;
									statusMsg = $"Success: {roundtripTime}ms";
								}
								else
								{
									isSuccess = false;
									statusMsg = reply.Status.ToString();
								}
							}
						}
							
						string key = dev.id.ToString();
						int failCount = 0;
						bool stateChanged = false;
						bool recovered = false;

						lock (dictFailCount)
						{
							if (isSuccess)
							{
								dictFailCount[key] = 0;
								if (!string.IsNullOrEmpty(dev.addr)) dictFailCount[dev.addr.Trim()] = 0;
								if (!string.IsNullOrEmpty(dev.name)) dictFailCount[dev.name.Trim()] = 0;
								if (!dictLastDownState.ContainsKey(key) || dictLastDownState[key])
								{
									dictLastDownState[key] = false;
									recovered = true;
								}
								Console.WriteLine($"{(isTcping ? "Tcping" : "Ping")} Success: {dev.name} ({dev.addr})");
							}
							else
							{
								if (dictFailCount.ContainsKey(key))
									dictFailCount[key]++;
								else
									dictFailCount[key] = 1;

								failCount = dictFailCount[key];
								if (!string.IsNullOrEmpty(dev.addr)) dictFailCount[dev.addr.Trim()] = failCount;
								if (!string.IsNullOrEmpty(dev.name)) dictFailCount[dev.name.Trim()] = failCount;

								if (failCount >= monitorCheckTimes)
								{
									if (!dictLastDownState.ContainsKey(key) || !dictLastDownState[key])
									{
										dictLastDownState[key] = true;
										stateChanged = true;
									}
								}
								Console.WriteLine($"{(isTcping ? "Tcping" : "Ping")} Fail: {dev.name} ({dev.addr}), Count: {failCount}, Status: {statusMsg}");
							}
						}

						// 통계 누적 기록
						lock (mPingStatLock)
						{
							if (!dictPingStats.ContainsKey(key))
							{
								dictPingStats[key] = new DevicePingStat
								{
									Index = dictPingStats.Count + 1,
									DeviceId = dev.id,
									GroupName = dev.groupNm ?? "",
									SystemName = dev.name ?? "",
									IpAddress = dev.addr ?? ""
								};
							}

							var stat = dictPingStats[key];
							stat.Sent++;
							if (isSuccess)
							{
								stat.Receive++;
								stat.IsSuccess = true;
								stat.Status = statusMsg;
								if (!stat.MaxMs.HasValue || roundtripTime > stat.MaxMs.Value) stat.MaxMs = roundtripTime;
								if (!stat.MinMs.HasValue || roundtripTime < stat.MinMs.Value) stat.MinMs = roundtripTime;
							}
							else
							{
								stat.Lost++;
								stat.IsSuccess = false;
								stat.Status = "TimeOut";
							}
						}

						if (stateChanged)
						{
							AddDeviceLog("SYSTEM", dev.groupNm, dev.name, dev.addr, $"\"{dev.name}({dev.addr})\" 시스템에 장애가 발생(Down)...");
							lock (cycleDownLock)
							{
								cycleNewDownDevices.Add(dev);
							}
						}
						else if (recovered)
						{
							AddDeviceLog("SYSTEM", dev.groupNm, dev.name, dev.addr, $"\"{dev.name}({dev.addr})\" 시스템이 정상 복구되었습니다(Up)...");
						}

						// Update diagram node border if it exists
						UpdateNodeStatusByDevice(dev, failCount);
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Ping Exception ({dev.addr}): {ex.Message}");
					}
				}).ToList();

				await Task.WhenAll(tasks);
				swCheck.Stop();
				UpdatePingStatusListUI();

				// 직전 시스템 체크 결과 집계 및 상태바 갱신
				var validList = checkList.Where(dev =>
					!dev.isDumy &&
					!string.IsNullOrWhiteSpace(dev.addr) &&
					dev.addr != "0.0.0.0" &&
					System.Net.IPAddress.TryParse(dev.addr, out _) &&
					!dev.addr.Contains(":")).ToList();

				int totalCount = validList.Count;
				int successCount = 0;
				int totalFailCount = 0;
				int waitCount = 0;

				lock (mPingStatLock)
				{
					foreach (var dev in validList)
					{
						string key = dev.id.ToString();
						if (dictPingStats.TryGetValue(key, out var stat))
						{
							if (stat.Sent == 0) waitCount++;
							else if (stat.IsSuccess) successCount++;
							else totalFailCount++;
						}
						else
						{
							waitCount++;
						}
					}
				}

				double elapsedSeconds = swCheck.Elapsed.TotalSeconds;

				this.BeginInvoke(new System.Action(() =>
				{
					if (lbl_status_check_result != null)
					{
						lbl_status_check_result.Text = $"[모니터링 요약]  전체: {totalCount} | 정상: {successCount}, 대기: {waitCount}, 실패: {totalFailCount} | 소요시간: {elapsedSeconds:F2}초";
					}
				}));

				// 장애 발생시 장애창 보이기
				if (cycleNewDownDevices.Count > 0 && Global.mConfigInfo.errorWindow)
				{
					List<DeviceInfo> popupList = new List<DeviceInfo>(cycleNewDownDevices);
					this.BeginInvoke(new System.Action(() =>
					{
						ShowErrorPopup(popupList);
					}));
				}

				if (isMonitoring)
				{
					Console.WriteLine($"Monitoring Loop Sleeping for {monitorInterval}ms...");
					int totalMs = monitorInterval;
					int elapsedMs = 0;
					while (elapsedMs < totalMs && isMonitoring)
					{
						// 네트워크 단절로 인한 일시 멈춤 처리
						while (isPausedByNetwork && isMonitoring)
						{
							this.BeginInvoke(new System.Action(() => {
								if (lbl_status_countdown != null) lbl_status_countdown.Text = "일시정지";
							}));
							await Task.Delay(500);
						}

						int remainingSec = Math.Max(0, (totalMs - elapsedMs + 999) / 1000);
						this.BeginInvoke(new System.Action(() => {
							if (lbl_status_countdown != null) lbl_status_countdown.Text = remainingSec.ToString();
						}));

						await Task.Delay(100);
						elapsedMs += 100;
					}
				}
			}
			this.BeginInvoke(new System.Action(() => {
				if (lbl_status_countdown != null) lbl_status_countdown.Text = "-";
			}));
			UpdateMonitoringButtonsUI(false);
			Console.WriteLine("Async Monitoring Loop Stopped.");
		}

		private void ShowErrorPopup(List<DeviceInfo> errorDevices)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new System.Action(() => ShowErrorPopup(errorDevices)));
				return;
			}

			try
			{
				if (mErrorPopupDlg != null && !mErrorPopupDlg.IsDisposed)
				{
					mErrorPopupDlg.Close();
					mErrorPopupDlg = null;
				}

				if (Global.mConfigInfo.errorSound)
				{
					try
					{
						System.Media.SystemSounds.Exclamation.Play();
					}
					catch { }
				}

				int autoCloseSec = Global.mConfigInfo.errorAutoClose <= 0
					? Math.Max(1, Global.mConfigInfo.sysTimeCheck - 2)
					: Global.mConfigInfo.errorAutoClose;

				mErrorPopupDlg = new ErrorPopupDialog(errorDevices, autoCloseSec, System.DateTime.Now);
				mErrorPopupDlg.Show(this);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ShowErrorPopup Error: {ex.Message}");
			}
		}

		private void LoadMonitorConfig() {
			// 1. 메모리의 환경설정 객체에서 우선 동기화
			if (Global.mConfigInfo != null) {
				if (Global.mConfigInfo.sysTimeCheck > 0)
					monitorInterval = Global.mConfigInfo.sysTimeCheck * 1000; // 초(sec) -> 밀리초(ms) 변환!
				if (Global.mConfigInfo.sysTimeout > 0)
					monitorTimeout = Global.mConfigInfo.sysTimeout;
				if (Global.mConfigInfo.sysPacketSize > 0)
					monitorPacketSize = Global.mConfigInfo.sysPacketSize;
			}

			// 2. CFG 파일이 있으면 파일의 최신값도 확인
			string path = @"C:\GTWave\cfg\GTWave.cfg";
			if (!File.Exists(path)) {
				path = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, HyperBase.Const.gCfgFile));
			}
			if (File.Exists(path)) {
				try {
					string[] lines = File.ReadAllLines(path);
					foreach (string line in lines) {
						if (string.IsNullOrWhiteSpace(line)) continue;
						if (line.StartsWith("[")) continue; // 섹션 헤더 무시

						string[] parts = line.Split('=');
						if (parts.Length < 2) continue;

						string key = parts[0].Trim();
						string val = parts[1].Trim();

						if (key == "체크간격" && int.TryParse(val, out int sec) && sec > 0)
							monitorInterval = sec * 1000; // 초(sec) -> 밀리초(ms) 변환!
						else if (key == "타임아웃" && int.TryParse(val, out int to) && to > 0)
							monitorTimeout = to;
						else if (key == "CheckTimes" && int.TryParse(val, out int ct) && ct > 0)
							monitorCheckTimes = ct;
						else if (key == "패킷크기" && int.TryParse(val, out int ps) && ps > 0)
							monitorPacketSize = ps;
					}
				} catch (Exception ex) {
					Console.WriteLine("LoadMonitorConfig Error: " + ex.Message);
				}
			}

			if (monitorInterval < 1000) monitorInterval = 5000; // 최소 1초 이상 보장
			Console.WriteLine($"Config Loaded: Interval={monitorInterval}ms, Timeout={monitorTimeout}ms, Times={monitorCheckTimes}, Size={monitorPacketSize}");
		}

		private void UpdateNodeStatusByDevice(DeviceInfo targetDev, int failCount)
		{
			if (targetDev == null) return;
			if (this.InvokeRequired)
			{
				this.Invoke(new System.Action(() => UpdateNodeStatusByDevice(targetDev, failCount)));
				return;
			}

			foreach (DiagramNode node in main_diagram.Nodes)
			{
				DeviceInfo nodeDev = GetDeviceInfoFromNode(node);
				if (nodeDev != null)
				{
					bool matched = false;
					if (targetDev.id > 0 && nodeDev.id == targetDev.id) matched = true;
					else if (!string.IsNullOrEmpty(targetDev.addr) && !string.IsNullOrEmpty(nodeDev.addr) && targetDev.addr.Trim() == nodeDev.addr.Trim()) matched = true;
					else if (!string.IsNullOrEmpty(targetDev.name) && !string.IsNullOrEmpty(nodeDev.name) && targetDev.name.Trim() == nodeDev.name.Trim()) matched = true;

					if (matched)
					{
						UpdateNodeStatus(node, failCount);
						break;
					}
				}
				else if (node.Tag is int id && id == targetDev.id)
				{
					UpdateNodeStatus(node, failCount);
					break;
				}
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
				DeviceInfo nodeDev = GetDeviceInfoFromNode(node);
				if (nodeDev != null && nodeDev.id == deviceId)
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

			// DrawForeground(DrawMonitoringStatusBorders)를 통해 노드 내부 변색 없이 외곽 테두리만 깔끔하게 렌더링
			dv_netview.Invalidate();
			dv_netview.Refresh();
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
								} catch (Exception) {
									encryption = "none";
								}
								try {
									frequency = network["frequency"].ToString();
								} catch (Exception) {
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

		#region Main Menu Event Handlers
		private void 새로운구성도ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (isMonitoring) {
				MessageBox.Show("모니터링 실행 중에는 새로운 구성도를 생성할 수 없습니다.\n먼저 모니터링을 중지해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (MessageBox.Show("현재 작업 중인 구성도와 장비 목록이 초기화됩니다.\n계속 진행하시겠습니까?", "새로운 구성도", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
				return;
			}

			// 1. 다이어그램 초기화
			main_diagram.ClearAll();

			// [추가] 구성도 배경 이미지 초기화
			mBackgroundBkImage = null;
			mBkImagePath = "";
			main_diagram.BackgroundImage = null;

			// 2. 장비 DB 초기화
			GlobalHelpers.mDeviceTb.DeleteAll();
			LoadTotalDevices();

			// 3. 그룹 트리 초기화
			tv_group.Nodes.Clear();
			TreeNode defaultNode = tv_group.Nodes.Add("전체 그룹");
			GroupInfo defaultGroup = new GroupInfo(defaultNode.Text);
			defaultNode.Tag = defaultGroup;
			defaultGroup.node = defaultNode;
			tv_group.ExpandAll();
			SaveTree(tv_group, "group.mvia");

			mCurGroupNode = defaultNode;
			tv_group.SelectedNode = mCurGroupNode;
			string group_name = GetNodePath(mCurGroupNode);
			DispDeviceList(group_name);

			// 4. 모니터링 및 상태 뷰 초기화
			InitOrResetPingStats();
			lock (mLogLock) {
				mDeviceLogs.Clear();
			}
			RefreshDeviceLogList();
			dictFailCount.Clear();
			dictLastDownState.Clear();

			dv_netview.Invalidate();
			dv_netview.Refresh();
		}

		private void 구성도열기ToolStripMenuItem_Click(object sender, EventArgs e) {
			bt_load_ncd_Click(sender, e);
		}

		private void 구성도저장ToolStripMenuItem_Click(object sender, EventArgs e) {
			bt_save_ncd_Click(sender, e);
		}

		public void ApplyDiagramLockUI(bool locked, bool showMsg = false) {
			isDiagramLocked = locked;
			if (isDiagramLocked) {
				dv_netview.Behavior = MindFusion.Diagramming.Behavior.DoNothing;
				dv_netview.AllowInplaceEdit = false;
				if (btn_tb_diagram_lock != null) {
					btnToolTip.SetToolTip(btn_tb_diagram_lock, "구성도 잠금해제");
				}
				if (showMsg) {
					MessageBox.Show("구성도가 잠금 처리되었습니다.\n(장비 위치 변경 및 그룹/장비 추가/삭제가 제한됩니다.)", "구성도 잠금", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			} else {
				dv_netview.Behavior = MindFusion.Diagramming.Behavior.Modify;
				dv_netview.AllowInplaceEdit = true;
				if (btn_tb_diagram_lock != null) {
					btnToolTip.SetToolTip(btn_tb_diagram_lock, "구성도 잠금");
				}
				if (showMsg) {
					MessageBox.Show("구성도 잠금이 해제되었습니다.", "구성도 잠금 해제", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}

			if (btn_tb_dev_add != null) btn_tb_dev_add.Enabled = !isDiagramLocked;
			if (btn_tb_dev_edit != null) btn_tb_dev_edit.Enabled = !isDiagramLocked;
			if (btn_tb_dev_del != null) btn_tb_dev_del.Enabled = !isDiagramLocked;

			if (시스템추가ToolStripMenuItem != null) 시스템추가ToolStripMenuItem.Enabled = !isDiagramLocked;
			if (시스템수정ToolStripMenuItem != null) 시스템수정ToolStripMenuItem.Enabled = !isDiagramLocked;
			if (시스템삭제ToolStripMenuItem != null) 시스템삭제ToolStripMenuItem.Enabled = !isDiagramLocked;
			if (그룹추가ToolStripMenuItem != null) 그룹추가ToolStripMenuItem.Enabled = !isDiagramLocked;
			if (그룹수정ToolStripMenuItem != null) 그룹수정ToolStripMenuItem.Enabled = !isDiagramLocked;
			if (그룹삭ㅈToolStripMenuItem != null) 그룹삭ㅈToolStripMenuItem.Enabled = !isDiagramLocked;

			if (bt_system_apply != null) bt_system_apply.Enabled = !isDiagramLocked;
			if (bt_system_add != null) bt_system_add.Enabled = !isDiagramLocked;
			if (bt_system_del != null) bt_system_del.Enabled = !isDiagramLocked;
			if (bt_system_image != null) bt_system_image.Enabled = !isDiagramLocked;
		}

		public void SetMonitoringLockUI(bool isLock) {
			if (this.InvokeRequired) {
				this.BeginInvoke(new System.Action(() => SetMonitoringLockUI(isLock)));
				return;
			}

			// 1. 툴바 바로가기 버튼 제어
			if (btn_tb_dev_add != null) btn_tb_dev_add.Enabled = !isLock && !isDiagramLocked;
			if (btn_tb_dev_edit != null) btn_tb_dev_edit.Enabled = !isLock && !isDiagramLocked;
			if (btn_tb_dev_del != null) btn_tb_dev_del.Enabled = !isLock && !isDiagramLocked;
			if (btn_tb_diagram_lock != null) btn_tb_diagram_lock.Enabled = !isLock;
			if (btn_tb_settings != null) btn_tb_settings.Enabled = !isLock;

			// 2. 상단 메인 메뉴 제어
			if (새로운구성도ToolStripMenuItem != null) 새로운구성도ToolStripMenuItem.Enabled = !isLock;
			if (구성도열기ToolStripMenuItem != null) 구성도열기ToolStripMenuItem.Enabled = !isLock;
			if (구성도저장ToolStripMenuItem != null) 구성도저장ToolStripMenuItem.Enabled = !isLock;
			if (구성도잠금수정불가ToolStripMenuItem != null) 구성도잠금수정불가ToolStripMenuItem.Enabled = !isLock;
			if (구성도잠금해제ToolStripMenuItem != null) 구성도잠금해제ToolStripMenuItem.Enabled = !isLock;

			if (optionToolStripMenuItem != null) optionToolStripMenuItem.Enabled = !isLock; // 모니터링 시작
			if (모니터링중지ToolStripMenuItem != null) 모니터링중지ToolStripMenuItem.Enabled = isLock; // 모니터링 중지

			if (시스템추가ToolStripMenuItem != null) 시스템추가ToolStripMenuItem.Enabled = !isLock && !isDiagramLocked;
			if (시스템수정ToolStripMenuItem != null) 시스템수정ToolStripMenuItem.Enabled = !isLock && !isDiagramLocked;
			if (시스템삭제ToolStripMenuItem != null) 시스템삭제ToolStripMenuItem.Enabled = !isLock && !isDiagramLocked;
			if (그룹추가ToolStripMenuItem != null) 그룹추가ToolStripMenuItem.Enabled = !isLock && !isDiagramLocked;
			if (그룹수정ToolStripMenuItem != null) 그룹수정ToolStripMenuItem.Enabled = !isLock && !isDiagramLocked;
			if (그룹삭ㅈToolStripMenuItem != null) 그룹삭ㅈToolStripMenuItem.Enabled = !isLock && !isDiagramLocked;

			if (구성도배경ToolStripMenuItem != null) 구성도배경ToolStripMenuItem.Enabled = !isLock;
			if (구성도배경삭제ToolStripMenuItem != null) 구성도배경삭제ToolStripMenuItem.Enabled = !isLock;
			if (환경세팅ToolStripMenuItem != null) 환경세팅ToolStripMenuItem.Enabled = !isLock;

			// 3. 다이어그램 제어 패널(ecp_diagram) 컨트롤 제어
			if (bt_load_ncd != null) bt_load_ncd.Enabled = !isLock;
			if (bt_save_ncd != null) bt_save_ncd.Enabled = !isLock;
			if (bt_set_bk_image != null) bt_set_bk_image.Enabled = !isLock;
			if (bt_cls_bk_image != null) bt_cls_bk_image.Enabled = !isLock;
			if (bt_undo != null) bt_undo.Enabled = !isLock;
			if (bt_redo != null) bt_redo.Enabled = !isLock;
			if (bt_link_color != null) bt_link_color.Enabled = !isLock;
			if (cb_line_thick != null) cb_line_thick.Enabled = !isLock;
			if (cb_link_segment != null) cb_link_segment.Enabled = !isLock;
			if (cb_line_direct != null) cb_line_direct.Enabled = !isLock;
			if (cb_link_style != null) cb_link_style.Enabled = !isLock;
			if (tb_diagram_w != null) tb_diagram_w.Enabled = !isLock;
			if (tb_diagram_h != null) tb_diagram_h.Enabled = !isLock;

			// 4. Device 종류 관리 패널(ecp_system_kind) 제어
			if (bt_system_apply != null) bt_system_apply.Enabled = !isLock && !isDiagramLocked;
			if (bt_system_add != null) bt_system_add.Enabled = !isLock && !isDiagramLocked;
			if (bt_system_del != null) bt_system_del.Enabled = !isLock && !isDiagramLocked;
			if (bt_system_image != null) bt_system_image.Enabled = !isLock && !isDiagramLocked;
			if (tb_system_name != null) tb_system_name.ReadOnly = isLock;
			if (tb_system_spec != null) tb_system_spec.ReadOnly = isLock;
			if (tb_system_desc != null) tb_system_desc.ReadOnly = isLock;

			// 5. 모니터링 종료 시 기존 구성도 잠금 상태 유지 복원
			if (!isLock) {
				ApplyDiagramLockUI(isDiagramLocked, false);
			}
		}

		private void 구성도잠금ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (isMonitoring) {
				MessageBox.Show("모니터링 중에는 구성도 잠금 상태를 변경할 수 없습니다.\n먼저 모니터링을 중지해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			ApplyDiagramLockUI(true, true);
		}

		private void 구성도잠금해제ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (isMonitoring) {
				MessageBox.Show("모니터링 중에는 구성도 잠금 상태를 변경할 수 없습니다.\n먼저 모니터링을 중지해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			ApplyDiagramLockUI(false, true);
		}

		private void 모니터링결과출력ToolStripMenuItem_Click(object sender, EventArgs e) {
			bt_ping_print_Click(sender, e);
		}

		private void 로그결과출력ToolStripMenuItem_Click(object sender, EventArgs e) {
			bt_log_print_Click(sender, e);
		}

		private void 종료ToolStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		private void 모니터링시작ToolStripMenuItem_Click(object sender, EventArgs e) {
			bt_mon_start_Click(sender, e);
		}

		private void 모니터링중지ToolStripMenuItem_Click(object sender, EventArgs e) {
			bt_mon_stop_Click(sender, e);
		}

		private void 장비검색ToolStripMenuItem_Click(object sender, EventArgs e) {
			bt_finder_Click(sender, e);
		}

		private void 시스템추가ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (isMonitoring || isDiagramLocked) {
				MessageBox.Show(isMonitoring ? "모니터링 중에는 장비를 추가할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 장비를 추가할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string group_name = mCurGroupNode != null ? GetNodePath(mCurGroupNode) : (tv_group.Nodes.Count > 0 ? GetNodePath(tv_group.Nodes[0]) : "전체 그룹");
			DeviceInfo dInfo = new DeviceInfo(-1);
			dInfo.groupNm = group_name;

			DeviceDialog dialog = new DeviceDialog(dInfo);
			dialog.mViewMode = "add";
			dialog.mForm = this;
			if (dialog.ShowDialog() == DialogResult.OK) {
				LoadTotalDevices();
				DispDeviceList(group_name);
			}
		}

		private void 시스템수정ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (isMonitoring || isDiagramLocked) {
				MessageBox.Show(isMonitoring ? "모니터링 중에는 장비를 수정할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 장비를 수정할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DiagramNode selNode = main_diagram.Selection.Nodes.FirstOrDefault();
			DeviceInfo dev = null;
			if (selNode != null && selNode.Tag is DeviceInfo d) {
				dev = d;
			} else if (lv_device_list.SelectedItems.Count > 0 && lv_device_list.SelectedItems[0].Tag is DeviceInfo ld) {
				dev = ld;
			}

			if (dev == null) {
				MessageBox.Show("수정할 장비를 구성도나 목록에서 선택해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			DeviceDialog dialog = new DeviceDialog(dev);
			dialog.mViewMode = "fix";
			dialog.mForm = this;
			if (dialog.ShowDialog() == DialogResult.OK) {
				DeviceInfo updatedDev = DeviceInfo.Load2Db(dev.id, GlobalHelpers.mDeviceTb);
				if (updatedDev != null && selNode != null) {
					FixDevice2Diagram(updatedDev, dev);
				} else if (selNode != null) {
					UpdateNodeLabel(selNode);
					UpdateNodeAppearance(selNode);
					dv_netview.Refresh();
				}
				string group_name = mCurGroupNode != null ? GetNodePath(mCurGroupNode) : "";
				DispDeviceList(group_name);
			}
		}

		private void 시스템삭제ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (isMonitoring || isDiagramLocked) {
				MessageBox.Show(isMonitoring ? "모니터링 중에는 장비를 삭제할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 장비를 삭제할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DiagramNode selNode = main_diagram.Selection.Nodes.FirstOrDefault();
			DeviceInfo dev = null;
			if (selNode != null && selNode.Tag is DeviceInfo d) {
				dev = d;
			} else if (lv_device_list.SelectedItems.Count > 0 && lv_device_list.SelectedItems[0].Tag is DeviceInfo ld) {
				dev = ld;
			}

			if (dev == null) {
				MessageBox.Show("삭제할 장비를 구성도나 목록에서 선택해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (MessageBox.Show($"'{dev.name}' 장비를 삭제하시겠습니까?", "장비 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				if (selNode != null) {
					main_diagram.Nodes.Remove(selNode);
				} else {
					foreach (DiagramNode node in main_diagram.Nodes) {
						if (node.Tag is DeviceInfo nodeDev && nodeDev.id == dev.id) {
							main_diagram.Nodes.Remove(node);
							break;
						}
					}
				}
				GlobalHelpers.mDeviceTb.DeleteMany(x => x.id.Equals(dev.id));
				LoadTotalDevices();
				string group_name = mCurGroupNode != null ? GetNodePath(mCurGroupNode) : "";
				DispDeviceList(group_name);
			}
		}

		private void 그룹추가ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (isMonitoring || isDiagramLocked) {
				MessageBox.Show(isMonitoring ? "모니터링 중에는 그룹을 추가할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 그룹을 추가할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			TreeNode selNode = tv_group.SelectedNode ?? (tv_group.Nodes.Count > 0 ? tv_group.Nodes[0] : null);
			GroupInfo gInfo = selNode != null ? (GroupInfo)selNode.Tag : null;
			GroupDialog dlg = new GroupDialog(tv_group);
			dlg.gInfo = gInfo;
			dlg.mForm = this;
			dlg.ShowDialog();
		}

		private void 그룹수정ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (isMonitoring || isDiagramLocked) {
				MessageBox.Show(isMonitoring ? "모니터링 중에는 그룹을 수정할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 그룹을 수정할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			TreeNode selNode = tv_group.SelectedNode;
			if (selNode == null || selNode.Tag == null) {
				MessageBox.Show("수정할 그룹을 선택해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			GroupDialog dlg = new GroupDialog(tv_group);
			dlg.gInfo = (GroupInfo)selNode.Tag;
			dlg.mViewMode = "fix";
			dlg.mForm = this;
			dlg.ShowDialog();
			if (mCurGroupNode != null) {
				string group_name = GetNodePath(mCurGroupNode);
				DispDeviceList(group_name);
			}
		}

		private void 그룹삭제ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (isMonitoring || isDiagramLocked) {
				MessageBox.Show(isMonitoring ? "모니터링 중에는 그룹을 삭제할 수 없습니다.\n먼저 모니터링을 중지해 주세요." : "구성도가 잠겨 있어 그룹을 삭제할 수 없습니다.\n먼저 구성도 잠금을 해제해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			TreeNode selNode = tv_group.SelectedNode;
			if (selNode == null || selNode.Tag == null) {
				MessageBox.Show("삭제할 그룹을 선택해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (selNode.Parent == null && tv_group.Nodes.Count <= 1) {
				MessageBox.Show("기본 그룹은 삭제할 수 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			MenuItem dummyMenu = new MenuItem();
			dummyMenu.Tag = selNode.Tag;
			ExitToolStripMenuItem_del_Click(dummyMenu, EventArgs.Empty);
		}

		private void 네트워크설정ToolStripMenuItem_Click(object sender, EventArgs e) {
			AnyBoBu.dialog.NetworkConfigDialog dialog = new AnyBoBu.dialog.NetworkConfigDialog();
			dialog.ShowDialog();
		}

		private void 이름으로ToolStripMenuItem_Click(object sender, EventArgs e) {
			cb_view_mode.SelectedIndex = 0;
		}

		private void iP주소로ToolStripMenuItem_Click(object sender, EventArgs e) {
			cb_view_mode.SelectedIndex = 1;
		}

		private void 구성도배경ToolStripMenuItem_Click(object sender, EventArgs e) {
			bt_set_bk_image_Click(sender, e);
		}

		private void 구성도배경삭제ToolStripMenuItem_Click(object sender, EventArgs e) {
			bt_cls_bk_image_Click(sender, e);
		}

		private void sNMPOIDTempleteToolStripMenuItem_Click(object sender, EventArgs e) {
			OidListDialog dlg = new OidListDialog();
			dlg.mForm = this;
			dlg.ShowDialog();
		}

		private void 관리자설정ToolStripMenuItem_Click(object sender, EventArgs e) {
			UserDialog dlg = new UserDialog();
			dlg.ShowDialog();
		}

		private void 도움말ToolStripMenuItem_Click(object sender, EventArgs e) {
			MessageBox.Show("1. 구성도 편집: 좌측 장비 목록에서 장비를 배치하거나 메뉴를 통해 장비/그룹을 추가할 수 있습니다.\n\n" +
							"2. 모니터링: [모니터링 시작] 메뉴로 실시간 Ping 상태를 감시합니다.\n\n" +
							"3. 잠금 설정: 모니터링 중이거나 관제 중 구성도 위치 변경을 방지하려면 [구성도 잠금]을 설정하세요.\n\n" +
							"4. 보고서 출력: 모니터링 결과 및 로그 결과를 인쇄할 수 있습니다.",
							"도움말", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		#endregion

		private void dv_netview_ControlRemoved(object sender, ControlEventArgs e) {
			Debug.WriteLine("dv_netview_ControlRemoved");
		}

		private void main_diagram_NodeDeleted(object sender, NodeEventArgs e) {

		}

		private void main_diagram_NodeDeleting(object sender, NodeValidationEventArgs e) {
			try {
				if (isDiagramLocked || isMonitoring) {
					e.Cancel = true;
					return;
				}
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
			try
			{
				if (main_ruler == null) return;
				if (main_ruler.Parent == null) return;

				Form fsForm = new Form();
				string topGroupName = (tv_group != null && tv_group.Nodes.Count > 0) ? tv_group.Nodes[0].Text : "전체화면";
				fsForm.Text = topGroupName;
				fsForm.Icon = this.Icon;
				var currentScreen = Screen.FromControl(this);
				fsForm.StartPosition = FormStartPosition.Manual;
				fsForm.Location = currentScreen.WorkingArea.Location;
				fsForm.WindowState = FormWindowState.Maximized;
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

				bool restored = false;
				// 폼이 닫힐 때 원래 위치로 복구
				fsForm.FormClosing += (s, fe) => {
					if (restored) return;
					restored = true;
					try
					{
						main_ruler.Dock = DockStyle.None;
						main_ruler.Anchor = System.Windows.Forms.AnchorStyles.None;
						originalParent.Controls.Add(main_ruler);
						originalParent.Controls.SetChildIndex(main_ruler, originalIndex);
						main_ruler.Location = originalLocation;
						main_ruler.Size = originalSize;
						main_ruler.Dock = originalDock;
						main_ruler.Anchor = originalAnchor;
						FitDiagramToView();
					}
					catch { }
				};

				fsForm.Shown += (s, se) => {
					FitDiagramToView();
				};

				fsForm.ShowDialog(this);
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "pb_full_screen_Click error");
			}
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
			if (isMonitoring) {
				MessageBox.Show("모니터링 실행 중에는 배경 이미지를 설정할 수 없습니다.\n먼저 모니터링을 중지해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

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
			if (isMonitoring) {
				MessageBox.Show("모니터링 실행 중에는 배경 이미지를 제거할 수 없습니다.\n먼저 모니터링을 중지해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			mBackgroundBkImage = null;
			mBkImagePath = "";
			main_diagram.BackgroundImage = null;
			dv_netview.Invalidate();
			dv_netview.Refresh();
		}

		private void statusTimeTimer_Tick(object sender, EventArgs e) {
			try {
				if (lbl_status_clock != null && !lbl_status_clock.IsDisposed) {
					lbl_status_clock.Text = System.DateTime.Now.ToString("yyyy-MM-dd tt h:mm:ss", new System.Globalization.CultureInfo("ko-KR"));
				}
				if (lblTime != null && !lblTime.IsDisposed && lblTime.Visible) {
					lblTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd tt h:mm:ss", new System.Globalization.CultureInfo("ko-KR"));
				}
				CheckNetworkAvailability();
			} catch { }
		}

		private void InitCustomStatusBar()
		{
			try
			{
				if (statusStrip1 == null) return;

				// 기존 기본 아이템 숨김
				if (lblStatusText != null) lblStatusText.Visible = false;
				if (pbStatusProgress != null) pbStatusProgress.Visible = false;
				if (lblSpring != null) lblSpring.Visible = false;
				if (lblEncoding != null) lblEncoding.Visible = false;
				if (lblTime != null) lblTime.Visible = false;

				// 상태바 전체 스타일 설정 (밝은 회색/화이트 톤)
				statusStrip1.BackColor = System.Drawing.Color.FromArgb(245, 245, 247);
				statusStrip1.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
				statusStrip1.Height = 32;
				statusStrip1.AutoSize = false;
				statusStrip1.Font = new System.Drawing.Font("맑은 고딕", 9f);
				statusStrip1.ShowItemToolTips = true;

				// 네트워크 아이콘 생성
				bmpNetworkOk = CreateNetworkStatusIcon(true);
				bmpNetworkError = CreateNetworkStatusIcon(false);

				// 1. 모니터링 시작 및 종료 시간 (맨 앞쪽)
				lbl_status_mon_time = new ToolStripStatusLabel();
				lbl_status_mon_time.Name = "lbl_status_mon_time";
				lbl_status_mon_time.Text = "모니터링 대기";
				lbl_status_mon_time.BorderSides = ToolStripStatusLabelBorderSides.All;
				lbl_status_mon_time.BorderStyle = Border3DStyle.Etched;
				lbl_status_mon_time.Margin = new Padding(4, 2, 4, 2);
				lbl_status_mon_time.AutoSize = true;

				// 2. 좌측 여백 (Spring) - 가운데 영역 분할용
				lbl_status_spring_sep = new ToolStripStatusLabel();
				lbl_status_spring_sep.Name = "lbl_status_spring_sep";
				lbl_status_spring_sep.Spring = true;

				// 3. 직전 시스템 체크 결과 (가운데 요약 표시)
				lbl_status_check_result = new ToolStripStatusLabel();
				lbl_status_check_result.Name = "lbl_status_check_result";
				lbl_status_check_result.Text = "[모니터링 요약]  전체: 0 | 정상: 0, 대기: 0, 실패: 0 | 소요시간: 0.00초";
				lbl_status_check_result.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Bold);
				lbl_status_check_result.BorderSides = ToolStripStatusLabelBorderSides.All;
				lbl_status_check_result.BorderStyle = Border3DStyle.Etched;
				lbl_status_check_result.Margin = new Padding(4, 2, 4, 2);
				lbl_status_check_result.AutoSize = true;

				// 4. 우측 여백 (Spring) - 가운데 영역 분할용
				ToolStripStatusLabel lbl_status_spring_right = new ToolStripStatusLabel();
				lbl_status_spring_right.Name = "lbl_status_spring_right";
				lbl_status_spring_right.Spring = true;

				// 5. 다음 시스템 체크시작 남은 시간 (청록색 박스)
				lbl_status_countdown = new ToolStripStatusLabel();
				lbl_status_countdown.Name = "lbl_status_countdown";
				lbl_status_countdown.Text = "-";
				lbl_status_countdown.BackColor = System.Drawing.Color.FromArgb(0, 206, 209);
				lbl_status_countdown.ForeColor = System.Drawing.Color.White;
				lbl_status_countdown.Font = new System.Drawing.Font("맑은 고딕", 9.5f, System.Drawing.FontStyle.Bold);
				lbl_status_countdown.BorderSides = ToolStripStatusLabelBorderSides.All;
				lbl_status_countdown.BorderStyle = Border3DStyle.Flat;
				lbl_status_countdown.AutoSize = false;
				lbl_status_countdown.Size = new System.Drawing.Size(28, 22);
				lbl_status_countdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				lbl_status_countdown.Margin = new Padding(2, 2, 4, 2);

				// 6. 네트워크 상태 아이콘
				lbl_status_network = new ToolStripStatusLabel();
				lbl_status_network.Name = "lbl_status_network";
				lbl_status_network.Image = bmpNetworkOk;
				lbl_status_network.ToolTipText = "네트워크 연결 정상";
				lbl_status_network.BorderSides = ToolStripStatusLabelBorderSides.All;
				lbl_status_network.BorderStyle = Border3DStyle.Etched;
				lbl_status_network.AutoSize = false;
				lbl_status_network.Size = new System.Drawing.Size(32, 22);
				lbl_status_network.Margin = new Padding(2, 2, 4, 2);

				// 7. 시스템 시간
				lbl_status_clock = new ToolStripStatusLabel();
				lbl_status_clock.Name = "lbl_status_clock";
				lbl_status_clock.Text = System.DateTime.Now.ToString("yyyy-MM-dd tt h:mm:ss", new System.Globalization.CultureInfo("ko-KR"));
				lbl_status_clock.BorderSides = ToolStripStatusLabelBorderSides.All;
				lbl_status_clock.BorderStyle = Border3DStyle.Etched;
				lbl_status_clock.Margin = new Padding(2, 2, 6, 2);
				lbl_status_clock.AutoSize = true;

				statusStrip1.Items.AddRange(new ToolStripItem[] {
					lbl_status_mon_time,
					lbl_status_spring_sep,
					lbl_status_check_result,
					lbl_status_spring_right,
					lbl_status_countdown,
					lbl_status_network,
					lbl_status_clock
				});
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "InitCustomStatusBar Error");
			}
		}

		private Bitmap CreateNetworkStatusIcon(bool isOk)
		{
			Bitmap bmp = new Bitmap(24, 20);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

				// 모니터 1 (좌측)
				using (System.Drawing.SolidBrush screenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(41, 128, 185)))
				{
					g.FillRectangle(screenBrush, 1, 1, 9, 7);
				}
				g.DrawRectangle(System.Drawing.Pens.DarkSlateGray, 1, 1, 9, 7);
				g.FillRectangle(System.Drawing.Brushes.Gray, 4, 8, 3, 3);
				g.FillRectangle(System.Drawing.Brushes.DarkGray, 2, 11, 7, 2);

				// 모니터 2 (우측)
				using (System.Drawing.SolidBrush screenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(41, 128, 185)))
				{
					g.FillRectangle(screenBrush, 13, 1, 9, 7);
				}
				g.DrawRectangle(System.Drawing.Pens.DarkSlateGray, 13, 1, 9, 7);
				g.FillRectangle(System.Drawing.Brushes.Gray, 16, 8, 3, 3);
				g.FillRectangle(System.Drawing.Brushes.DarkGray, 14, 11, 7, 2);

				// 연결 허브 / 케이블 라인
				using (System.Drawing.Pen linePen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(100, 100, 100), 2f))
				{
					g.DrawLine(linePen, 5, 14, 5, 17);
					g.DrawLine(linePen, 5, 17, 18, 17);
					g.DrawLine(linePen, 18, 17, 18, 14);
				}
				g.FillRectangle(System.Drawing.Brushes.DarkSlateGray, 9, 15, 5, 4);

				// 장애 상태인 경우 빨간색 X 표시
				if (!isOk)
				{
					using (System.Drawing.Pen redPen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(220, 20, 20), 3.5f))
					{
						redPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
						redPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
						g.DrawLine(redPen, 3, 3, 20, 17);
						g.DrawLine(redPen, 20, 3, 3, 17);
					}
				}
			}
			return bmp;
		}

		private void CheckNetworkAvailability()
		{
			try
			{
				bool available = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
				if (available != isNetworkConnected)
				{
					isNetworkConnected = available;
					this.BeginInvoke(new System.Action(() =>
					{
						if (!isNetworkConnected)
						{
							if (lbl_status_network != null)
							{
								lbl_status_network.Image = bmpNetworkError;
								lbl_status_network.ToolTipText = "네트워크 연결 장애발생";
							}
							if (isMonitoring)
							{
								isPausedByNetwork = true;
							}
							ShowNetworkErrorDialog();
						}
						else
						{
							if (lbl_status_network != null)
							{
								lbl_status_network.Image = bmpNetworkOk;
								lbl_status_network.ToolTipText = "네트워크 연결 정상";
							}
							CloseNetworkErrorDialog();
							if (isPausedByNetwork)
							{
								isPausedByNetwork = false;
							}
						}
					}));
				}
			}
			catch { }
		}

		private void ShowNetworkErrorDialog()
		{
			try
			{
				if (mNetErrorDialog == null || mNetErrorDialog.IsDisposed)
				{
					mNetErrorDialog = new NetworkErrorDialog();
					mNetErrorDialog.Show(this);
				}
			}
			catch { }
		}

		private void CloseNetworkErrorDialog()
		{
			try
			{
				if (mNetErrorDialog != null && !mNetErrorDialog.IsDisposed)
				{
					mNetErrorDialog.Close();
					mNetErrorDialog = null;
				}
			}
			catch { }
		}

		/// <summary>
		/// 하단 상태 표시줄의 텍스트 메시지를 설정합니다 (스레드 안전).
		/// </summary>
		public void SetStatusText(string text) {
			try {
				if (this.InvokeRequired) {
					this.BeginInvoke(new System.Action<string>(SetStatusText), text);
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
					this.BeginInvoke(new System.Action<int, bool>(SetProgress), value, visible);
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
					this.BeginInvoke(new System.Action<string>(SetEncodingText), text);
					return;
				}
				if (lblEncoding != null && !lblEncoding.IsDisposed) {
					lblEncoding.Text = text;
				}
			} catch { }
		}

		private void statusStrip1_Paint(object sender, PaintEventArgs e) {
			try {
				// 상태 바의 상단 경계선 테두리를 그림 (부드러운 밝은 회색선)
				using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(210, 210, 215), 1f)) {
					e.Graphics.DrawLine(pen, 0, 0, statusStrip1.Width, 0);
				}
			} catch { }
		}

		#region Device Log Management

		public class DeviceLogItem
		{
			public int No { get; set; } = 0;
			public string DateTimeStr { get; set; } = "";
			public string Date { get; set; } = "";
			public string Time { get; set; } = "";
			public string LogType { get; set; } = "";
			public string GroupName { get; set; } = "";
			public string SystemName { get; set; } = "";
			public string IpAddress { get; set; } = "";
			public string Message { get; set; } = "";

			public ListViewItem ToListViewItem()
			{
				ListViewItem item = new ListViewItem(No.ToString());
				item.SubItems.Add(DateTimeStr);
				item.SubItems.Add(IpAddress);
				item.SubItems.Add(SystemName);
				item.SubItems.Add(LogType);
				item.SubItems.Add(Message);
				return item;
			}
		}

		private void InitDeviceLogUI()
		{
			try
			{
				if (cb_log_filter != null && cb_log_filter.Items.Count > 0)
				{
					cb_log_filter.SelectedIndex = 0; // "내용" 기본 선택
				}

				if (bt_log_save != null && bt_log_save.BackgroundImage == null)
				{
					bt_log_save.BackgroundImage = global::GTWave.Properties.Resources.save_images;
				}

				if (bt_log_print != null && bt_log_print.BackgroundImage == null)
				{
					bt_log_print.BackgroundImage = CreatePrinterIcon();
				}

				if (bt_log_search != null && bt_log_search.BackgroundImage == null)
				{
					bt_log_search.BackgroundImage = global::GTWave.Properties.Resources.search;
				}

				if (bt_log_clear != null && bt_log_clear.BackgroundImage == null)
				{
					bt_log_clear.BackgroundImage = CreateTrashIcon();
				}

				// 프로그램 시작 로그 초기 기록
				AddDeviceLog("PROGRAM", "", "", "", "RFNMS 프로그램이 시작되었습니다.");
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "InitDeviceLogUI Error");
			}
		}

		private System.Drawing.Image CreatePrinterIcon()
		{
			Bitmap bmp = new Bitmap(24, 24);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.SmoothingMode = SmoothingMode.AntiAlias;
				using (System.Drawing.Brush brush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(70, 70, 70)))
				{
					g.FillRectangle(brush, 4, 8, 16, 10);
				}
				using (System.Drawing.Brush pBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(240, 240, 240)))
				{
					g.FillRectangle(pBrush, 7, 3, 10, 6);
					g.DrawRectangle(System.Drawing.Pens.Gray, 7, 3, 10, 6);

					g.FillRectangle(pBrush, 7, 13, 10, 7);
					g.DrawRectangle(System.Drawing.Pens.Gray, 7, 13, 10, 7);
				}
				using (System.Drawing.Pen lPen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(120, 120, 120), 1f))
				{
					g.DrawLine(lPen, 9, 15, 15, 15);
					g.DrawLine(lPen, 9, 17, 15, 17);
				}
			}
			return bmp;
		}

		private System.Drawing.Image CreateTrashIcon()
		{
			System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(24, 24);
			using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp))
			{
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				g.Clear(System.Drawing.Color.Transparent);

				using (System.Drawing.SolidBrush blueBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(14, 122, 178)))
				using (System.Drawing.SolidBrush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White))
				using (System.Drawing.Pen bluePen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(14, 122, 178), 1.0f))
				{
					// 배경 원형
					g.FillEllipse(blueBrush, 1.5f, 1.5f, 21f, 21f);

					// 손잡이
					g.FillRectangle(whiteBrush, 10.5f, 4.5f, 3f, 1.5f);

					// 뚜껑
					g.FillRectangle(whiteBrush, 6.5f, 6.5f, 11f, 2f);

					// 몸체 (사다리꼴)
					System.Drawing.PointF[] pts = new System.Drawing.PointF[]
					{
						new System.Drawing.PointF(7.5f, 9f),
						new System.Drawing.PointF(16.5f, 9f),
						new System.Drawing.PointF(15.5f, 18.5f),
						new System.Drawing.PointF(8.5f, 18.5f)
					};
					g.FillPolygon(whiteBrush, pts);

					// 세로 슬롯 선 3개
					g.DrawLine(bluePen, 10f, 11f, 10f, 16.5f);
					g.DrawLine(bluePen, 12f, 11f, 12f, 16.5f);
					g.DrawLine(bluePen, 14f, 11f, 14f, 16.5f);
				}
			}
			return bmp;
		}

		private int mLogSeq = 0;

		public void AddDeviceLog(string logType, string groupName, string sysName, string ip, string msg)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new System.Action(() => AddDeviceLog(logType, groupName, sysName, ip, msg)));
				return;
			}

			mLogSeq++;
			string nowDate = System.DateTime.Now.ToString("yyyy-MM-dd");
			string nowTime = System.DateTime.Now.ToString("HH:mm:ss");
			string nowDateTime = $"{nowDate} {nowTime}";

			DeviceLogItem logItem = new DeviceLogItem
			{
				No = mLogSeq,
				Date = nowDate,
				Time = nowTime,
				DateTimeStr = nowDateTime,
				LogType = logType ?? "",
				GroupName = groupName ?? "",
				SystemName = sysName ?? "",
				IpAddress = ip ?? "",
				Message = msg ?? ""
			};

			lock (mLogLock)
			{
				mDeviceLogs.Insert(0, logItem);
				if (mDeviceLogs.Count > 5000)
				{
					mDeviceLogs.RemoveAt(mDeviceLogs.Count - 1);
				}
			}

			if (lv_device_log != null && IsMatchFilter(logItem))
			{
				lv_device_log.Items.Insert(0, logItem.ToListViewItem());
				if (lv_device_log.Items.Count > 5000)
				{
					lv_device_log.Items.RemoveAt(lv_device_log.Items.Count - 1);
				}
			}
		}

		private bool IsMatchFilter(DeviceLogItem item)
		{
			if (tb_log_search == null) return true;
			string search = tb_log_search.Text.Trim();
			if (string.IsNullOrEmpty(search)) return true;

			string filter = cb_log_filter?.SelectedItem?.ToString() ?? "내용";
			switch (filter)
			{
				case "내용":
					return item.Message.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0;
				case "발생일자":
					return item.Date.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0;
				case "발생시간":
					return item.Time.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0;
				case "Log 구분":
					return item.LogType.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0;
				case "그룹 이름":
					return item.GroupName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0;
				case "시스템 이름":
					return item.SystemName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0;
				case "IP 주소":
					return item.IpAddress.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0;
				default:
					return item.Message.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0;
			}
		}

		private void RefreshDeviceLogList()
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new System.Action(RefreshDeviceLogList));
				return;
			}

			if (lv_device_log == null) return;

			lv_device_log.BeginUpdate();
			lv_device_log.Items.Clear();

			lock (mLogLock)
			{
				foreach (var log in mDeviceLogs)
				{
					if (IsMatchFilter(log))
					{
						lv_device_log.Items.Add(log.ToListViewItem());
					}
				}
			}
			lv_device_log.EndUpdate();
		}

		private void bt_log_search_Click(object sender, EventArgs e)
		{
			RefreshDeviceLogList();
		}

		private void bt_log_clear_Click(object sender, EventArgs e)
		{
			try
			{
				if (System.Windows.Forms.MessageBox.Show("로그 목록을 초기화하시겠습니까?", "로그 초기화", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				{
					lock (mLogLock)
					{
						mDeviceLogs.Clear();
						mLogSeq = 0;
					}
					RefreshDeviceLogList();
				}
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "bt_log_clear_Click Error");
			}
		}

		private void tb_log_search_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Enter)
			{
				RefreshDeviceLogList();
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void cb_log_filter_SelectedIndexChanged(object sender, EventArgs e)
		{
			RefreshDeviceLogList();
		}

		private void bt_log_save_Click(object sender, EventArgs e)
		{
			try
			{
				using (System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog())
				{
					sfd.Title = "로그 결과 저장";
					sfd.Filter = "CSV 파일 (*.csv)|*.csv|텍스트 파일 (*.txt)|*.txt";
					sfd.FileName = $"DeviceLog_{System.DateTime.Now:yyyyMMdd_HHmmss}.csv";

					if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
					{
						var sb = new StringBuilder();
						if (sfd.FilterIndex == 1) // CSV (엑셀 호환)
						{
							sb.AppendLine("발생일자,발생시간,Log 구분,그룹 이름,시스템 이름,IP 주소,내용");
							lock (mLogLock)
							{
								foreach (var item in mDeviceLogs)
								{
									if (IsMatchFilter(item))
									{
										string msgEscaped = item.Message.Replace("\"", "\"\"");
										sb.AppendLine($"\"{item.Date}\",\"{item.Time}\",\"{item.LogType}\",\"{item.GroupName}\",\"{item.SystemName}\",\"{item.IpAddress}\",\"{msgEscaped}\"");
									}
								}
							}
						}
						else // TXT
						{
							sb.AppendLine(string.Format("{0,-12}\t{1,-10}\t{2,-10}\t{3,-12}\t{4,-15}\t{5,-18}\t{6}",
								"발생일자", "발생시간", "Log 구분", "그룹 이름", "시스템 이름", "IP 주소", "내용"));
							sb.AppendLine(new string('-', 120));
							lock (mLogLock)
							{
								foreach (var item in mDeviceLogs)
								{
									if (IsMatchFilter(item))
									{
										sb.AppendLine(string.Format("{0,-12}\t{1,-10}\t{2,-10}\t{3,-12}\t{4,-15}\t{5,-18}\t{6}",
											item.Date, item.Time, item.LogType, item.GroupName, item.SystemName, item.IpAddress, item.Message));
									}
								}
							}
						}

						File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
						System.Windows.Forms.MessageBox.Show("로그 파일이 성공적으로 저장되었습니다.", "저장 완료", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
					}
				}
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show($"로그 저장 중 오류가 발생했습니다.\n{ex.Message}", "오류", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
			}
		}

		private void bt_log_print_Click(object sender, EventArgs e)
		{
			try
			{
				using (System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument())
				{
					int printIndex = 0;
					List<DeviceLogItem> printItems;
					lock (mLogLock)
					{
						printItems = mDeviceLogs.Where(IsMatchFilter).ToList();
					}

					pd.PrintPage += (s, pe) =>
					{
						float yPos = pe.MarginBounds.Top;
						System.Drawing.Font titleFont = new System.Drawing.Font("맑은 고딕", 13, FontStyle.Bold);
						System.Drawing.Font headerFont = new System.Drawing.Font("맑은 고딕", 9, FontStyle.Bold);
						System.Drawing.Font bodyFont = new System.Drawing.Font("맑은 고딕", 8.5f, FontStyle.Regular);
						float baseLineHeight = bodyFont.GetHeight(pe.Graphics) + 4;

						pe.Graphics.DrawString("Device Log Report", titleFont, System.Drawing.Brushes.Black, pe.MarginBounds.Left, yPos);
						yPos += 28;

						pe.Graphics.DrawLine(System.Drawing.Pens.Gray, pe.MarginBounds.Left, yPos, pe.MarginBounds.Right, yPos);
						yPos += 4;

						float left = pe.MarginBounds.Left;
						float wDate = 80;
						float wTime = 65;
						float wType = 65;
						float wGroup = 85;
						float wSys = 110;
						float wIp = 95;
						float wMsg = pe.MarginBounds.Right - (left + wDate + wTime + wType + wGroup + wSys + wIp);
						if (wMsg < 150) wMsg = 150;

						float xDate = left;
						float xTime = xDate + wDate;
						float xType = xTime + wTime;
						float xGroup = xType + wType;
						float xSys = xGroup + wGroup;
						float xIp = xSys + wSys;
						float xMsg = xIp + wIp;

						using (System.Drawing.StringFormat sfCenter = new System.Drawing.StringFormat { Alignment = System.Drawing.StringAlignment.Center, LineAlignment = System.Drawing.StringAlignment.Near })
						using (System.Drawing.StringFormat sfLeft = new System.Drawing.StringFormat { Alignment = System.Drawing.StringAlignment.Near, LineAlignment = System.Drawing.StringAlignment.Near, Trimming = System.Drawing.StringTrimming.Word })
						{
							// 헤더 그리기
							pe.Graphics.DrawString("발생일자", headerFont, System.Drawing.Brushes.Black, new System.Drawing.RectangleF(xDate, yPos, wDate, baseLineHeight), sfCenter);
							pe.Graphics.DrawString("발생시간", headerFont, System.Drawing.Brushes.Black, new System.Drawing.RectangleF(xTime, yPos, wTime, baseLineHeight), sfCenter);
							pe.Graphics.DrawString("구분", headerFont, System.Drawing.Brushes.Black, new System.Drawing.RectangleF(xType, yPos, wType, baseLineHeight), sfCenter);
							pe.Graphics.DrawString("그룹", headerFont, System.Drawing.Brushes.Black, new System.Drawing.RectangleF(xGroup, yPos, wGroup, baseLineHeight), sfLeft);
							pe.Graphics.DrawString("시스템", headerFont, System.Drawing.Brushes.Black, new System.Drawing.RectangleF(xSys, yPos, wSys, baseLineHeight), sfLeft);
							pe.Graphics.DrawString("IP주소", headerFont, System.Drawing.Brushes.Black, new System.Drawing.RectangleF(xIp, yPos, wIp, baseLineHeight), sfCenter);
							pe.Graphics.DrawString("내용", headerFont, System.Drawing.Brushes.Black, new System.Drawing.RectangleF(xMsg, yPos, wMsg, baseLineHeight), sfLeft);

							yPos += baseLineHeight + 2;
							pe.Graphics.DrawLine(System.Drawing.Pens.Black, pe.MarginBounds.Left, yPos, pe.MarginBounds.Right, yPos);
							yPos += 4;

							while (printIndex < printItems.Count)
							{
								var item = printItems[printIndex];
								string msg = item.Message ?? "";

								// 내용 높이 측정 (줄바꿈 고려)
								System.Drawing.SizeF msgSize = pe.Graphics.MeasureString(msg, bodyFont, (int)wMsg, sfLeft);
								float rowHeight = Math.Max(baseLineHeight, msgSize.Height);

								if (yPos + rowHeight > pe.MarginBounds.Bottom)
								{
									pe.HasMorePages = true;
									return;
								}

								// 각 컬럼 정렬 출력
								pe.Graphics.DrawString(item.Date ?? "", bodyFont, System.Drawing.Brushes.Black, new System.Drawing.RectangleF(xDate, yPos, wDate, baseLineHeight), sfCenter);
								pe.Graphics.DrawString(item.Time ?? "", bodyFont, System.Drawing.Brushes.Black, new System.Drawing.RectangleF(xTime, yPos, wTime, baseLineHeight), sfCenter);
								pe.Graphics.DrawString(item.LogType ?? "", bodyFont, System.Drawing.Brushes.Black, new System.Drawing.RectangleF(xType, yPos, wType, baseLineHeight), sfCenter);
								pe.Graphics.DrawString(item.GroupName ?? "", bodyFont, System.Drawing.Brushes.Black, new System.Drawing.RectangleF(xGroup, yPos, wGroup, baseLineHeight), sfLeft);
								pe.Graphics.DrawString(item.SystemName ?? "", bodyFont, System.Drawing.Brushes.Black, new System.Drawing.RectangleF(xSys, yPos, wSys, baseLineHeight), sfLeft);
								pe.Graphics.DrawString(item.IpAddress ?? "", bodyFont, System.Drawing.Brushes.Black, new System.Drawing.RectangleF(xIp, yPos, wIp, baseLineHeight), sfCenter);
								pe.Graphics.DrawString(msg, bodyFont, System.Drawing.Brushes.Black, new System.Drawing.RectangleF(xMsg, yPos, wMsg, rowHeight), sfLeft);

								yPos += rowHeight + 3;
								printIndex++;
							}
						}

						pe.HasMorePages = false;
					};

					using (System.Windows.Forms.PrintPreviewDialog ppd = new System.Windows.Forms.PrintPreviewDialog())
					{
						ppd.Document = pd;
						ppd.Width = 850;
						ppd.Height = 650;
						ppd.ShowDialog(this);
					}
				}
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show($"인쇄 준비 중 오류가 발생했습니다.\n{ex.Message}", "오류", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
			}
		}

		#endregion

		#region Ping Monitor Management

		public class DevicePingStat
		{
			public int Index { get; set; } = 0;
			public int DeviceId { get; set; } = 0;
			public string GroupName { get; set; } = "";
			public string SystemName { get; set; } = "";
			public string IpAddress { get; set; } = "";
			public int Sent { get; set; } = 0;
			public string Status { get; set; } = "-";
			public bool IsSuccess { get; set; } = false;
			public int Receive { get; set; } = 0;
			public long? MaxMs { get; set; } = null;
			public long? MinMs { get; set; } = null;
			public int Lost { get; set; } = 0;
			public double LossRate => Sent > 0 ? ((double)Lost / Sent) * 100.0 : 0.0;

			public System.Windows.Forms.ListViewItem ToListViewItem()
			{
				System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem(Index.ToString());
				item.SubItems.Add(GroupName);
				item.SubItems.Add(SystemName);
				item.SubItems.Add(IpAddress);
				item.SubItems.Add(Sent > 0 ? Sent.ToString() : "");
				item.SubItems.Add(Status);
				item.SubItems.Add(Receive > 0 ? Receive.ToString() : (Sent > 0 ? "0" : ""));
				item.SubItems.Add(MaxMs.HasValue ? MaxMs.Value.ToString() : "");
				item.SubItems.Add(MinMs.HasValue ? MinMs.Value.ToString() : "");
				item.SubItems.Add(Lost > 0 ? Lost.ToString() : (Sent > 0 ? "0" : ""));
				item.SubItems.Add(Sent > 0 ? $"{LossRate:F2}%" : "");
				item.Tag = this;
				return item;
			}
		}

		private void InitPingMonitorUI()
		{
			try
			{
				if (bt_ping_save != null && bt_ping_save.BackgroundImage == null)
				{
					bt_ping_save.BackgroundImage = global::GTWave.Properties.Resources.save_images;
				}
				if (bt_ping_print != null && bt_ping_print.BackgroundImage == null)
				{
					bt_ping_print.BackgroundImage = CreatePrinterIcon();
				}
				if (bt_ping_search != null && bt_ping_search.BackgroundImage == null)
				{
					bt_ping_search.BackgroundImage = global::GTWave.Properties.Resources.search;
				}
				if (bt_ping_clear != null && bt_ping_clear.BackgroundImage == null)
				{
					bt_ping_clear.BackgroundImage = CreateTrashIcon();
				}
				InitOrResetPingStats();
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "InitPingMonitorUI Error");
			}
		}

		private void InitOrResetPingStats()
		{
			lock (mPingStatLock)
			{
				dictPingStats.Clear();
				int idx = 1;
				lock (mTotDevice)
				{
					foreach (var dev in mTotDevice)
					{
						if (string.IsNullOrWhiteSpace(dev.addr) || dev.addr == "0.0.0.0" || dev.isDumy) continue;
						string key = dev.id.ToString();
						if (!dictPingStats.ContainsKey(key))
						{
							dictPingStats[key] = new DevicePingStat
							{
								Index = idx++,
								DeviceId = dev.id,
								GroupName = dev.groupNm ?? "",
								SystemName = dev.name ?? "",
								IpAddress = dev.addr ?? ""
							};
						}
					}
				}
			}
			UpdatePingStatusListUI();
		}

		private void UpdatePingStatusListUI()
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new System.Action(UpdatePingStatusListUI));
				return;
			}

			if (lv_ping_status == null) return;

			lv_ping_status.BeginUpdate();
			try
			{
				bool includeOnly = chk_ping_include != null && chk_ping_include.Checked;
				List<DevicePingStat> list;
				lock (mPingStatLock)
				{
					list = dictPingStats.Values.OrderBy(x => x.Index).ToList();
				}

				if (includeOnly)
				{
					list = list.Where(x => x.Sent > 0).ToList();
				}

				// 기존 아이템 갯수와 비교하여 갱신 또는 재구성
				if (lv_ping_status.Items.Count != list.Count)
				{
					lv_ping_status.Items.Clear();
					foreach (var stat in list)
					{
						lv_ping_status.Items.Add(stat.ToListViewItem());
					}
				}
				else
				{
					for (int i = 0; i < list.Count; i++)
					{
						var stat = list[i];
						var item = lv_ping_status.Items[i];
						item.Text = stat.Index.ToString();
						item.SubItems[1].Text = stat.GroupName;
						item.SubItems[2].Text = stat.SystemName;
						item.SubItems[3].Text = stat.IpAddress;
						item.SubItems[4].Text = stat.Sent > 0 ? stat.Sent.ToString() : "";
						item.SubItems[5].Text = stat.Status;
						item.SubItems[6].Text = stat.Receive > 0 ? stat.Receive.ToString() : (stat.Sent > 0 ? "0" : "");
						item.SubItems[7].Text = stat.MaxMs.HasValue ? stat.MaxMs.Value.ToString() : "";
						item.SubItems[8].Text = stat.MinMs.HasValue ? stat.MinMs.Value.ToString() : "";
						item.SubItems[9].Text = stat.Lost > 0 ? stat.Lost.ToString() : (stat.Sent > 0 ? "0" : "");
						item.SubItems[10].Text = stat.Sent > 0 ? $"{stat.LossRate:F2}%" : "";
						item.Tag = stat;
					}
				}
			}
			finally
			{
				lv_ping_status.EndUpdate();
			}
		}

		private void lv_ping_status_DrawColumnHeader(object sender, System.Windows.Forms.DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}

		private void lv_ping_status_DrawSubItem(object sender, System.Windows.Forms.DrawListViewSubItemEventArgs e)
		{
			e.DrawBackground();

			System.Drawing.Color textColor = System.Drawing.Color.Black;
			if (e.ColumnIndex == 5) // Status 컬럼
			{
				string statusText = e.SubItem.Text ?? "";
				if (statusText.IndexOf("TimeOut", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					textColor = System.Drawing.Color.Red;
				}
				else if (statusText.IndexOf("Success", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					textColor = System.Drawing.Color.Blue;
				}
			}

			System.Windows.Forms.TextFormatFlags flags = System.Windows.Forms.TextFormatFlags.VerticalCenter;
			switch (e.Header.TextAlign)
			{
				case System.Windows.Forms.HorizontalAlignment.Center:
					flags |= System.Windows.Forms.TextFormatFlags.HorizontalCenter;
					break;
				case System.Windows.Forms.HorizontalAlignment.Right:
					flags |= System.Windows.Forms.TextFormatFlags.Right;
					break;
				default:
					flags |= System.Windows.Forms.TextFormatFlags.Left;
					break;
			}

			System.Windows.Forms.TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.Font, e.Bounds, textColor, flags);
		}

		private void chk_ping_include_CheckedChanged(object sender, EventArgs e)
		{
			UpdatePingStatusListUI();
		}

		private void bt_ping_search_Click(object sender, EventArgs e)
		{
			ShowPingPrintPreview();
		}

		private void bt_ping_clear_Click(object sender, EventArgs e)
		{
			try
			{
				if (System.Windows.Forms.MessageBox.Show("모니터링 결과를 초기화하시겠습니까?", "모니터링 결과 초기화", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				{
					InitOrResetPingStats();
				}
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "bt_ping_clear_Click Error");
			}
		}

		private void bt_ping_save_Click(object sender, EventArgs e)
		{
			try
			{
				using (System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog())
				{
					sfd.Title = "시스템 리스트 모니터링 결과 저장";
					sfd.Filter = "CSV 파일 (*.csv)|*.csv|텍스트 파일 (*.txt)|*.txt";
					sfd.FileName = $"PingMonitor_{System.DateTime.Now:yyyyMMdd_HHmmss}.csv";

					if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
					{
						var sb = new StringBuilder();
						List<DevicePingStat> list;
						lock (mPingStatLock)
						{
							list = dictPingStats.Values.OrderBy(x => x.Index).ToList();
						}

						if (chk_ping_include != null && chk_ping_include.Checked)
						{
							list = list.Where(x => x.Sent > 0).ToList();
						}

						if (sfd.FilterIndex == 1) // CSV
						{
							sb.AppendLine("Index,그룹 이름,시스템 이름,IP 주소,Sent,Status,Receive,Max(ms),Min(ms),Lost,Loss(%)");
							foreach (var item in list)
							{
								string maxStr = item.MaxMs.HasValue ? item.MaxMs.Value.ToString() : "";
								string minStr = item.MinMs.HasValue ? item.MinMs.Value.ToString() : "";
								string lossStr = item.Sent > 0 ? $"{item.LossRate:F2}%" : "0.00%";
								sb.AppendLine($"\"{item.Index}\",\"{item.GroupName}\",\"{item.SystemName}\",\"{item.IpAddress}\",\"{item.Sent}\",\"{item.Status}\",\"{item.Receive}\",\"{maxStr}\",\"{minStr}\",\"{item.Lost}\",\"{lossStr}\"");
							}
						}
						else // TXT
						{
							sb.AppendLine(string.Format("{0,-6}\t{1,-12}\t{2,-14}\t{3,-16}\t{4,-6}\t{5,-14}\t{6,-8}\t{7,-8}\t{8,-8}\t{9,-6}\t{10,-8}",
								"Index", "그룹 이름", "시스템 이름", "IP 주소", "Sent", "Status", "Receive", "Max(ms)", "Min(ms)", "Lost", "Loss(%)"));
							sb.AppendLine(new string('-', 130));
							foreach (var item in list)
							{
								string maxStr = item.MaxMs.HasValue ? item.MaxMs.Value.ToString() : "-";
								string minStr = item.MinMs.HasValue ? item.MinMs.Value.ToString() : "-";
								string lossStr = item.Sent > 0 ? $"{item.LossRate:F2}%" : "0.00%";
								sb.AppendLine(string.Format("{0,-6}\t{1,-12}\t{2,-14}\t{3,-16}\t{4,-6}\t{5,-14}\t{6,-8}\t{7,-8}\t{8,-8}\t{9,-6}\t{10,-8}",
									item.Index, item.GroupName, item.SystemName, item.IpAddress, item.Sent, item.Status, item.Receive, maxStr, minStr, item.Lost, lossStr));
							}
						}

						File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
						System.Windows.Forms.MessageBox.Show("시스템 모니터링 결과가 성공적으로 저장되었습니다.", "저장 완료", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
					}
				}
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show($"모니터링 결과 저장 중 오류가 발생했습니다.\n{ex.Message}", "오류", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
			}
		}

		private void bt_ping_print_Click(object sender, EventArgs e)
		{
			ShowPingPrintPreview();
		}

		private void ShowPingPrintPreview()
		{
			try
			{
				using (System.Drawing.Printing.PrintDocument pd = CreatePingPrintDocument())
				using (System.Windows.Forms.PrintPreviewDialog ppd = new System.Windows.Forms.PrintPreviewDialog())
				{
					ppd.Document = pd;
					ppd.Width = 850;
					ppd.Height = 650;
					ppd.ShowDialog(this);
				}
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show($"인쇄 미리보기 준비 중 오류가 발생했습니다.\n{ex.Message}", "오류", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
			}
		}

		private System.Drawing.Printing.PrintDocument CreatePingPrintDocument()
		{
			System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
			int printIndex = 0;
			List<DevicePingStat> printItems = null;

			pd.BeginPrint += (s, e) =>
			{
				printIndex = 0;
				lock (mPingStatLock)
				{
					printItems = dictPingStats.Values.OrderBy(x => x.Index).ToList();
				}

				if (chk_ping_include != null && chk_ping_include.Checked)
				{
					printItems = printItems.Where(x => x.Sent > 0).ToList();
				}
			};

			pd.PrintPage += (s, pe) =>
			{
				if (printItems == null) return;
				float yPos = pe.MarginBounds.Top;
				float left = pe.MarginBounds.Left;
				float right = pe.MarginBounds.Right;
				System.Drawing.Font dateFont = new System.Drawing.Font("맑은 고딕", 9.5f, FontStyle.Regular);
				System.Drawing.Font itemHeaderFont = new System.Drawing.Font("맑은 고딕", 9.5f, FontStyle.Bold);
				System.Drawing.Font itemBodyFont = new System.Drawing.Font("맑은 고딕", 9f, FontStyle.Regular);
				float lineHeight = itemBodyFont.GetHeight(pe.Graphics) + 3;

				// 첫 페이지 상단에 시작/종료 일시 출력
				if (printIndex == 0)
				{
					string startStr = mMonitorStartTime.HasValue ? mMonitorStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
					string endStr = mMonitorStopTime.HasValue ? mMonitorStopTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

					pe.Graphics.DrawString($"시작 일시: {startStr}", dateFont, System.Drawing.Brushes.Black, left, yPos);
					yPos += 18;
					pe.Graphics.DrawString($"종료 일시: {endStr}", dateFont, System.Drawing.Brushes.Black, left, yPos);
					yPos += 24;
				}

				// 각 장비 모니터링 결과 블록 출력
				while (printIndex < printItems.Count)
				{
					float blockHeight = 65; // 블록 필요 높이
					if (yPos + blockHeight > pe.MarginBounds.Bottom)
					{
						pe.HasMorePages = true;
						return;
					}

					var item = printItems[printIndex];

					// 상단 더블 라인
					pe.Graphics.DrawLine(System.Drawing.Pens.Black, left, yPos, right, yPos);
					pe.Graphics.DrawLine(System.Drawing.Pens.Black, left, yPos + 2, right, yPos + 2);
					yPos += 6;

					// 그룹 및 시스템명(IP) 결과
					string headerTitle = $"{item.GroupName}\t{item.SystemName}({item.IpAddress}) 결과";
					pe.Graphics.DrawString(headerTitle, itemHeaderFont, System.Drawing.Brushes.Black, left, yPos);
					yPos += lineHeight + 2;

					// 중간 대시 라인
					using (System.Drawing.Pen dashPen = new System.Drawing.Pen(System.Drawing.Color.Gray, 1f) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
					{
						pe.Graphics.DrawLine(dashPen, left, yPos, right, yPos);
					}
					yPos += 5;

					// Packets 정보
					string lossRateStr = item.Sent > 0 ? $"{item.LossRate:F0}%" : "0%";
					string statLine1 = $"  Packets: Sent = {item.Sent} Received = {item.Receive} Lost = {item.Lost} ({lossRateStr} loss)";
					pe.Graphics.DrawString(statLine1, itemBodyFont, System.Drawing.Brushes.Black, left, yPos);
					yPos += lineHeight;

					// Min/Max ms 정보
					string minStr = item.MinMs.HasValue ? item.MinMs.Value.ToString() : "0";
					string maxStr = item.MaxMs.HasValue ? item.MaxMs.Value.ToString() : "0";
					string statLine2 = $"  Minimum = {minStr}ms, Maximum = {maxStr}ms";
					pe.Graphics.DrawString(statLine2, itemBodyFont, System.Drawing.Brushes.Black, left, yPos);
					yPos += lineHeight + 2;

					// 하단 더블 라인
					pe.Graphics.DrawLine(System.Drawing.Pens.Black, left, yPos, right, yPos);
					pe.Graphics.DrawLine(System.Drawing.Pens.Black, left, yPos + 2, right, yPos + 2);
					yPos += 10;

					printIndex++;
				}

				pe.HasMorePages = false;
			};

			return pd;
		}

		private static void DisableMindFusionTrialWatermark()
		{
			try
			{
				var asmLic = typeof(MindFusion.Licensing.LicenseManager).Assembly;
				var licMgr = typeof(MindFusion.Licensing.LicenseManager);

				var fieldC87 = licMgr.GetField("c877ef10111737dd42f98d35c6ef90bfd", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
				if (fieldC87 == null) return;
				var c87Val = fieldC87.GetValue(null);
				if (c87Val == null) return;

				var fieldDict = c87Val.GetType().GetField("c121771552520bb8f782665e6858a9468", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
				var dict = fieldDict?.GetValue(c87Val) as System.Collections.IDictionary;

				var c38Type = asmLic.GetType("A.c38ae3e30e88d1636137f81b3325e9fb2");
				var propLicenses = c38Type?.GetProperty("Licenses", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
				var listLicenses = propLicenses?.GetValue(null) as System.Collections.IList;

				var licObjType = asmLic.GetType("A.c0c1edfc207d8938e7732fa20dc29032f");
				if (licObjType == null || dict == null || listLicenses == null) return;

				var fProd = licObjType.GetField("cfe7d377343a92efd112c4f61583090d9", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
				var fExp = licObjType.GetField("ceb5cb7fa6b53da97404fb5f9dae15925", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

				string[] products = new string[] {
					"MindFusion.Diagramming.WinForms",
					"MindFusion.Pack.WinForms",
					"MindFusion.Pack.Diagramming"
				};

				foreach (var p in products)
				{
					var item = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(licObjType);
					fProd?.SetValue(item, p);
					fExp?.SetValue(item, System.DateTime.MaxValue);
					dict[p] = item;
					listLicenses.Add(item);
				}
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAINFORM", ex, "DisableMindFusionTrialWatermark Error");
			}
		}

		#endregion
	}
}

