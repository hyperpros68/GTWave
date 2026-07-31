
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

			Global.Init();
			Global.mMainForm = new MainFormV1();

			using (LoginForm login = new LoginForm())
			{
				if (login.ShowDialog() == DialogResult.OK)
				{
					Global.mMainForm.mUserInfo = login.LoggedUserInfo;
					Application.Run(Global.mMainForm);

				}
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

		public static	void	Init() {

			mLDB = new LiteDatabase("./GTWave.db");
			GlobalHelpers.Init(mLDB);

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
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("DB Init Error: " + ex.Message);
			}

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
						break;
					}
				}

				if (mAppIcon == null)
				{
					mAppIcon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
				}
			}
			catch
			{
				try { mAppIcon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath); } catch { }
			}

			/*
			UserInfo uInfo = new UserInfo();
			uInfo.mMemNm = "Test UserInfo";
			GlobalHelpers.mUserTb.Insert(uInfo);
			var result0 = GlobalHelpers.mUserTb.Query()
							.Where(p => p.mMemNm.Equals("Test"))
							//.OrderBy(p => p.prevIdx)
							//.GroupBy()
							.ToList();
			//var results = GlobalHelpers.mGroupTb.FindAll();
			foreach (UserInfo group in result0) {
				Debug.WriteLine(group.mMemNm);
			}


			// Create your new customer instance
			var customer = new GroupInfo {
					site = "John Doe",
					//Phones = new string[] { "8000-0000", "9000-0000" },
					IsActive = true
				};

			// Insert new customer document (Id will be auto-incremented)
			GlobalHelpers.mGroupTb.Insert(customer);

				// Update a document inside a collection
			customer.site = "Jane Doe";

			GlobalHelpers.mGroupTb.Update(customer);

			// Index document using document Name property
			GlobalHelpers.mGroupTb.EnsureIndex(x => x.site);

			// Use LINQ to query documents (filter, sort, transform)
			var results = GlobalHelpers.mGroupTb.Query()
				.Where(x => x.site.StartsWith("J"))
				.OrderBy(x => x.site)
				.Select(x => new { x.site, NameUpper = x.site.ToUpper() })
				.Limit(10)
				.ToList();

			foreach (var group in results) {
				Debug.WriteLine(group.site);
			}
			*/
			// Let's create an index in phone numbers (using expression). It's a multikey index
			//GlobalHelpers.mGroupTb.EnsureIndex(x => x.phones);

			// and now we can query phones
			//var r = GlobalHelpers.mGroupTb.FindOne(x => x.phones.Contains("8888-5555"));
			//}

			// Data insert and update and delete
			GroupInfo gInfo = new GroupInfo("Test");
			GlobalHelpers.mGroupTb.Insert(gInfo);
			
			//foreach (var person in GlobalHelpers.mGroupTb.FindAll()) {
			// do something
			//Debug.WriteLine(person.site);
			//}

			/*
			var result1 = GlobalHelpers.mGroupTb.Query()
							.Where(p => p.groupIdx == 0)
							//.OrderBy(p => p.prevIdx)
							//.GroupBy()
							.ToList();
			//var results = GlobalHelpers.mGroupTb.FindAll();
			foreach (GroupInfo group in result1) {
				Debug.WriteLine(group.name);
			}
			*/

			StringBuilder str_temp = new StringBuilder();
            GetPrivateProfileString("System", "DeviceID", "", str_temp, 1000, Const.gIniFile);
            mDeviceID = str_temp.ToString();

            // ----------------------------------------------------------
            // 로그 관련
            // ----------------------------------------------------------
            GetPrivateProfileString("Log", "Path", "", str_temp, 1000, Const.gIniFile);
			LogUtil.mLogPath	= str_temp.ToString();

			LogUtil.mLevelW		= (int)GetPrivateProfileInt("Log", "Level_W", 0, Const.gIniFile);
			LogUtil.mLevelD		= (int)GetPrivateProfileInt("Log", "Level_D", 0, Const.gIniFile);
			LogUtil.mLevelN		= (int)GetPrivateProfileInt("Log", "Level_N", 0, Const.gIniFile);
			// ----------------------------------------------------------

			// ----------------------------------------------------------
			// Network 관련
			// ----------------------------------------------------------
			NetServer.mAliveTime	= (int)GetPrivateProfileInt("Network", "AliveMode", 0, Const.gIniFile);
			if (NetServer.mAliveTime == 1)	NetServer.mAliveMode	= true;
			
			NetServer.mAliveTime	= (int)GetPrivateProfileInt("Network", "AliveTime"	, 10000, Const.gIniFile);
			NetServer.mReadTimeout	= (int)GetPrivateProfileInt("Network", "ReadTimeout",     0, Const.gIniFile);
			// ----------------------------------------------------------


			// ----------------------------------------------------------
			// DB 관련
			// ----------------------------------------------------------
			/*
			GetPrivateProfileString("System", "DBType", "MySQL", str_temp, 1000, Const.gIniFile);
			string DBType = str_temp.ToString();

			GetPrivateProfileString(DBType, "server", "localhost", str_temp, 1000, Const.gIniFile);
			mMySQL._server	= str_temp.ToString();
			mMySQL._port	= (int)GetPrivateProfileInt(DBType, "port", 3308, Const.gIniFile);

			GetPrivateProfileString(DBType, "schema", "awool", str_temp, 1000, Const.gIniFile);
			string schema	= str_temp.ToString();
			GetPrivateProfileString(DBType, "id", "", str_temp, 1000, Const.gIniFile);
			string id		= str_temp.ToString();
			GetPrivateProfileString(DBType, "pw", "", str_temp, 1000, Const.gIniFile);
			string pw = str_temp.ToString();
			*/
			//if (!mMySQL.Init(schema, id, pw)) {
			//	Environment.Exit(1);
			//}
			// ----------------------------------------------------------





			// Service 정리
			// ----------------------------------------------------------
			GetPrivateProfileString("Service", "names", "", str_temp, 1000, Const.gIniFile);
			string  services	= str_temp.ToString();

			services.Split(',');
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


			mAppPath = Path.GetDirectoryName(Application.ExecutablePath);

            //run the program again and close this one
			Console.WriteLine(System.Environment.GetCommandLineArgs()[0]);
			
			mConfigInfo		= new ConfigInfo();
			mConfigInfo.Load(Const.gCfgFile);

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
