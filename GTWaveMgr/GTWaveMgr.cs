
using FireFly.utils;
using AnySCL;

using AnySCL.library;
using AnySCL.network;
using AnySCL.network.payload;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


using BoBuAI.info;
using AnyBoBu.library;


using AnyBoBu.info;
using Awool;
using GTWave.gui;
using LiteDB;
using GTWave.info;
using MySqlX.XDevAPI.Common;
using System.Web.UI.WebControls;
using AnyBoBu.dialog;
using GTWave;
using System.Drawing;

namespace HyperBase
{
	static	class	AwoolMgr
	{
		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// 전역 미처리 예외 핸들러 등록
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.ThreadException += (sender, args) => {
				LogUtil.LogException("CRASH_THREAD", args.Exception, "UI Thread Exception");
				try {
					MessageBox.Show("오류가 발생했습니다: " + args.Exception.Message + "\r\n로그 폴더: " + LogUtil.GetLogDirectory(), "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} catch { }
			};
			AppDomain.CurrentDomain.UnhandledException += (sender, args) => {
				Exception ex = args.ExceptionObject as Exception;
				LogUtil.LogException("CRASH_DOMAIN", ex, "AppDomain Unhandled Exception");
				try {
					MessageBox.Show("치명적인 오류가 발생했습니다: " + (ex != null ? ex.Message : "알 수 없는 오류") + "\r\n로그 폴더: " + LogUtil.GetLogDirectory(), "치명적 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} catch { }
			};
			TaskScheduler.UnobservedTaskException += (sender, args) => {
				LogUtil.LogException("CRASH_TASK", args.Exception, "Task Unobserved Exception");
				args.SetObserved();
			};

			LogUtil.LogI("MAIN", "==================================================");
			LogUtil.LogI("MAIN", $"GTWaveMgr Starting... Version: {Const.mVersion}");
			LogUtil.LogI("MAIN", $"BaseDirectory: {AppDomain.CurrentDomain.BaseDirectory}");
			LogUtil.LogI("MAIN", $"LogDirectory: {LogUtil.GetLogDirectory()}");
			LogUtil.LogI("MAIN", "==================================================");

			try
			{
				LogUtil.LogI("MAIN", "Initializing Global settings...");
				Global.Init();
				LogUtil.LogI("MAIN", "Global.Init() completed successfully.");

				LogUtil.LogI("MAIN", "Creating MainFormV1 instance...");
				Global.mMainForm = new MainFormV1();
				LogUtil.LogI("MAIN", "MainFormV1 instance created successfully.");

				LogUtil.LogI("MAIN", "Opening LoginForm...");
				using (LoginForm login = new LoginForm())
				{
					DialogResult dr = login.ShowDialog();
					LogUtil.LogI("MAIN", $"LoginForm result: {dr}");
					if (dr == DialogResult.OK)
					{
						Global.mMainForm.mUserInfo = login.LoggedUserInfo;
						LogUtil.LogI("MAIN", $"Logged in user: {(login.LoggedUserInfo != null ? login.LoggedUserInfo.mMemId : "null")}");
						LogUtil.LogI("MAIN", "Starting Application.Run(Global.mMainForm)...");
						Application.Run(Global.mMainForm);
						LogUtil.LogI("MAIN", "Application.Run finished cleanly.");
					}
					else
					{
						LogUtil.LogI("MAIN", "Login cancelled or closed.");
					}
				}
			}
			catch (Exception ex)
			{
				LogUtil.LogException("MAIN", ex, "Fatal error in Main()");
				try {
					MessageBox.Show("프로그램 실행 중 오류가 발생했습니다:\r\n" + ex.Message + "\r\n\r\n상세 내용은 로그 파일을 확인하세요:\r\n" + LogUtil.GetLogDirectory(), "실행 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} catch { }
			}
		}

		private class ItemData {
			public string Name { get; set; }
			public Color Color { get; set; }
			public Brush Brush { get; }

			public ItemData(Color color) {
				Name = color.Name;
				Color = color;

				Brush = new SolidBrush(Color);
			}
		}

		private static Form CreateForm() {
			var form = new Form() {
				Width = 600,
				Height = 480,

				StartPosition = FormStartPosition.CenterScreen,
			};

			var control = CreateListView();
			form.Controls.Add(control);

			return form;
		}

		private static ListView CreateListView() {
			var control = new ListView() {
				Dock = DockStyle.Fill,
				View = System.Windows.Forms.View.Details,

				OwnerDraw = true,
				FullRowSelect = true,
			};

			control.Columns.Add("Number", 100);
			control.Columns.Add("Color Name", 200);

			var index = 1;

			AddItemData(control, index++, new ItemData(Color.Orange));
			AddItemData(control, index++, new ItemData(Color.Yellow));
			AddItemData(control, index++, new ItemData(Color.Red));
			AddItemData(control, index++, new ItemData(Color.Blue));
			AddItemData(control, index++, new ItemData(Color.Green));
			AddItemData(control, index++, new ItemData(Color.LightSkyBlue));

			control.DrawColumnHeader += Control_DrawColumnHeader;
			control.DrawSubItem += Control_DrawSubItem;

			return control;
		}

		private static void AddItemData(ListView list, int number, ItemData data) {
			var item = list.Items.Add(number.ToString());

			item.SubItems.Add(""); //No text is needed, graphics need to be drawn, among other things.

			item.Tag = data;
		}

		private static void Control_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) {
			e.DrawDefault = true;
		}

		private static void Control_DrawSubItem(object sender, DrawListViewSubItemEventArgs e) {
			if (e.ColumnIndex != 1) {
				e.DrawDefault = true;
				return;
			}

			var item = e.Item;
			var subItem = e.SubItem;
			var bounds = subItem.Bounds;

			var data = item.Tag as ItemData;
			var text = data.Name;

			var g = e.Graphics;
			g.Clip = new Region(bounds);

			var picWidth = 20;
			var picHeight = bounds.Height - 4;

			var rect = new Rectangle(bounds.X, bounds.Y, picWidth, picHeight);

			g.FillRectangle(data.Brush, rect);

			rect = bounds;
			rect.Offset(picWidth, 0);

			g.DrawString(text, item.Font, Brushes.Black, rect);
		}
	}

	/*
	public class Customer {
		public	int			Id			{ get; set; }
		public	string		Name		{ get; set; }
		public	string[]	Phones		{ get; set; }
		public	bool		IsActive	{ get; set; }
	}
	*/

	// 전역변수 설정
	public static	class	Global
    {
		public	static	string			mAppPath;

		public	static	NetServer		mNetServer;
		public	static	string			mDeviceID;


		public	static	List<ServiceInfo>	mServices	= new List<ServiceInfo>();

		//public	static	List<KeywordInfo>	mKeywords	= new List<KeywordInfo>();

		//public	static	LoanSite		mLoanSite = new LoanSite();      // single instance

		// -------------------------------------------------------
		public	static	MainFormV1		mMainForm;
		public	static	GateWay			mGateWay;       // single instance

		//public	static	MySQL			mMySQL		= new MySQL("localhost");     
		public	static	LiteDatabase	mLDB;


		public	static	ImageUtil		imageUtil	= new ImageUtil();
		public	static	DateUtil		dateUtil	= new DateUtil();
		public	static	IniUtil			iniUtil		= new IniUtil();
		public	static	Icon			mAppIcon;

		// ----------------------- Config 
		public	static	ConfigInfo		mConfigInfo = new ConfigInfo();

		private static void InitDatabase() {
			string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GTWave.db");
			LogUtil.LogI("INIT", $"Initializing LiteDB at: {dbPath}");

			bool isSuccess = false;
			try
			{
				mLDB = new LiteDatabase(dbPath);
				GlobalHelpers.Init(mLDB);

				// 무결성 검증 쿼리 실행
				var count = GlobalHelpers.mUserTb.Query().Count();
				isSuccess = true;
				LogUtil.LogI("INIT", $"LiteDB initialized and verified successfully. User count: {count}");
			}
			catch (Exception ex)
			{
				LogUtil.LogException("INIT", ex, "LiteDB verification failed, attempting recovery...");
				try { if (mLDB != null) { mLDB.Dispose(); mLDB = null; } } catch { }

				// 손상되었거나 호환되지 않는 이전 DB 파일 백업 후 새 DB로 재생성
				try
				{
					if (File.Exists(dbPath))
					{
						string bakPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"GTWave_corrupted_{DateTime.Now:yyyyMMddHHmmss}.bak");
						File.Move(dbPath, bakPath);
						LogUtil.LogW("INIT", $"Corrupted DB moved to backup: {bakPath}");
					}

					mLDB = new LiteDatabase(dbPath);
					GlobalHelpers.Init(mLDB);
					isSuccess = true;
					LogUtil.LogI("INIT", "LiteDB re-created and initialized successfully.");
				}
				catch (Exception reEx)
				{
					LogUtil.LogException("INIT", reEx, "LiteDB recreation failed");
				}
			}

			if (isSuccess && GlobalHelpers.mUserTb != null)
			{
				try
				{
					if (GlobalHelpers.mUserTb.Query().Where(x => x.mMemId.Equals("admin")).Count() == 0)
					{
						GlobalHelpers.mUserTb.Insert(new UserInfo
						{
							mMemId = "admin",
							mMemPw = "",
							mMemNm = "Administrator",
							mLevel = "관리자"
						});
						LogUtil.LogI("INIT", "Default 'admin' user created.");
					}
					if (GlobalHelpers.mUserTb.Query().Where(x => x.mMemId.Equals("test")).Count() == 0)
					{
						GlobalHelpers.mUserTb.Insert(new UserInfo
						{
							mMemId = "test",
							mMemPw = "",
							mMemNm = "Test User",
							mLevel = "사용자"
						});
						LogUtil.LogI("INIT", "Default 'test' user created.");
					}
				}
				catch (Exception userEx)
				{
					LogUtil.LogException("INIT", userEx, "Default user creation error");
				}
			}
		}

		public static	void	Init() {
			mAppPath = AppDomain.CurrentDomain.BaseDirectory;
			LogUtil.LogI("INIT", $"mAppPath initialized: {mAppPath}");

			InitDatabase();

			try
			{
				// [수정] 여러 경로에서 아이콘 로드 시도 (프로젝트 구조 및 빌드 출력 고려)
				string baseDir = AppDomain.CurrentDomain.BaseDirectory;
				string[] paths = {
					Path.Combine(baseDir, "Resources", "gtwave.ico"),
					Path.Combine(baseDir, "gtwave.ico"),
					Path.Combine(baseDir, "..", "..", "Resources", "gtwave.ico"), // Debug 모드 대비
					Path.Combine(baseDir, "..", "Resources", "gtwave.ico")
				};

				foreach (string path in paths)
				{
					if (File.Exists(path))
					{
						mAppIcon = new Icon(path);
						LogUtil.LogI("INIT", $"Loaded icon from: {path}");
						break;
					}
				}

				if (mAppIcon == null)
				{
					mAppIcon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
				}
			}
			catch (Exception ex)
			{
				LogUtil.LogException("INIT", ex, "Icon load failed");
				try { mAppIcon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath); } catch { }
			}

			try
			{
				string iniFullPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Const.gIniFile));
				LogUtil.LogI("INIT", $"Reading INI config: {iniFullPath} (Exists: {File.Exists(iniFullPath)})");

				StringBuilder str_temp = new StringBuilder();
				GetPrivateProfileString("System", "DeviceID", "", str_temp, 1000, Const.gIniFile);
				mDeviceID = str_temp.ToString();

				// ----------------------------------------------------------
				// 로그 관련
				// ----------------------------------------------------------
				GetPrivateProfileString("Log", "Path", "", str_temp, 1000, Const.gIniFile);
				string iniLogPath = str_temp.ToString().Trim();
				if (!string.IsNullOrEmpty(iniLogPath))
				{
					LogUtil.mLogPath = iniLogPath;
				}
				LogUtil.EnsureLogDirectoryExists();

				LogUtil.mLevelW		= (int)GetPrivateProfileInt("Log", "Level_W", 0, Const.gIniFile);
				LogUtil.mLevelD		= (int)GetPrivateProfileInt("Log", "Level_D", 0, Const.gIniFile);
				LogUtil.mLevelN		= (int)GetPrivateProfileInt("Log", "Level_N", 0, Const.gIniFile);
				LogUtil.LogI("INIT", $"Log settings -> Path: '{LogUtil.mLogPath}' ({LogUtil.GetLogDirectory()}), Level_W: {LogUtil.mLevelW}, Level_D: {LogUtil.mLevelD}, Level_N: {LogUtil.mLevelN}");
				// ----------------------------------------------------------

				// ----------------------------------------------------------
				// Network 관련
				// ----------------------------------------------------------
				NetServer.mAliveTime	= (int)GetPrivateProfileInt("Network", "AliveMode", 0, Const.gIniFile);
				if (NetServer.mAliveTime == 1)	NetServer.mAliveMode	= true;
				
				NetServer.mAliveTime	= (int)GetPrivateProfileInt("Network", "AliveTime"	, 10000, Const.gIniFile);
				NetServer.mReadTimeout	= (int)GetPrivateProfileInt("Network", "ReadTimeout",     0, Const.gIniFile);
				// ----------------------------------------------------------

				// Service 정리
				// ----------------------------------------------------------
				GetPrivateProfileString("Service", "names", "", str_temp, 1000, Const.gIniFile);
				string  services	= str_temp.ToString();

				foreach(string service in services.Split(','))
				{
					var name = service.Trim();
					if (name.Length > 0) {
						ServiceInfo info = new	ServiceInfo(name);
						GetPrivateProfileString(name, "Enable", "false", str_temp, 1000, Const.gIniFile);
						string enable = str_temp.ToString();
						if ("true".Equals(enable))	info.mEnable = true;
						else info.mEnable = false;

						GetPrivateProfileString(name, "CfgFile", "", str_temp, 1000, Const.gIniFile);
						info.mCfgFile = str_temp.ToString();
						GetPrivateProfileString(name, "SvrAddr", "localhost", str_temp, 1000, Const.gIniFile);
						info.mCfgFile = str_temp.ToString();

						info.mSvrPort = (int)GetPrivateProfileInt(name, "SvrPort", 0, Const.gIniFile);

						mServices.Add(info);
					}
				}
			}
			catch (Exception ex)
			{
				LogUtil.LogException("INIT", ex, "INI configuration read failed");
			}

			try
			{
				string cfgFullPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Const.gCfgFile));
				LogUtil.LogI("INIT", $"Loading CFG config: {cfgFullPath} (Exists: {File.Exists(cfgFullPath)})");
				mConfigInfo = new ConfigInfo();
				mConfigInfo.Load(Const.gCfgFile);
				LogUtil.LogI("INIT", "ConfigInfo loaded successfully.");
			}
			catch (Exception ex)
			{
				LogUtil.LogException("INIT", ex, "CFG configuration load failed");
			}

			// --------------- start Socket Server
		}

		public	static	void	SoundPlay(string file) {
			Thread t2 = new Thread(new ThreadStart(delegate () {
				string myFile = Path.Combine(mAppPath, @"Sound\"+file);
				System.Media.SoundPlayer player = new System.Media.SoundPlayer(myFile);
				player.Play();
            }));
            t2.Start();		// 스레드 시작               
		}

        public	static	void	RestartApp()
        {
            try {
                //run the program again and close this one
				Console.WriteLine(System.Environment.GetCommandLineArgs()[0]);

                Process.Start(System.Environment.GetCommandLineArgs()[0]);
                //or you can use Application.ExecutablePath

                //close this one
                Process.GetCurrentProcess().Kill();
            } catch { }
        }

		[DllImport("kernel32")]
		private static	extern	int		GetPrivateProfileSectionNames(byte[] lpszReturnBuffer, int nSize, string lpFileName);

		[DllImport("kernel32")]
		private static	extern	long	WritePrivateProfileString(String section, String key, String val, String filePath);

        [DllImport("kernel32")]
        private static	extern	int		GetPrivateProfileString(string section, string key, string def, StringBuilder retVal,
                                                        int size, string filePath);
		[DllImport("kernel32")]
		public	static	extern	uint	GetPrivateProfileInt( string lpAppName, string lpKeyName, int nDefault, string lpFileName );
    }

	public	static	class	Const
	{
		public	const	string	mVersion	= @"1.0.0.1";
		public	const	string	mAppName	= @"GTWave";                    // 로그파일 이름에 쓰이므로 한글 안된다....
		public	const	string	mCompany	= @"(주)지티웨이브";
		public	const	string	mAppDesc	= @"네트웍 관리 도구";

		public	const	string	mDomain		= @"gtwave.com";

		public	const	int		gMgrPort	= 9901;
		public	const	string	gSchema		= "GTWave";

		public	const	string	URL_BASE	= "http://121.172.63.134:19080/";

		public	const	string	gIniFile	= @"..\\cfg\\GTWave.ini";
		public	const	string	gCfgFile	= @"..\\cfg\\GTWave.cfg";

	}
}
