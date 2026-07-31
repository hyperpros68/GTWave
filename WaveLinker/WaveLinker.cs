using HyperBase;
using LiteDB;

using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using WaveLinker.info;

namespace WaveLinker {
	internal static class WaveLinker {
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static	void	Main() {
			System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"..\Data");
			if (!di.Exists) { di.Create(); }
			Global.Init();
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Application.Run(new LoginForm());

		}

		public	class	Global {
			public	static	string mAppPath;

			public	static	string mAppVersion;
			//public static SetInfo mSetInfo = new SetInfo();

			// https://jacking75.github.io/NET_lib_LiteDB/
			public	static	LiteDatabase mLDB;


			//public static ImageUtil imageUtil = new ImageUtil();
			//public static DateUtil dateUtil = new DateUtil();
			//public static IniUtil iniUtil = new IniUtil();
			public	static	int		Init() {
				/*
				mLDB	= new LiteDatabase("./kiosk_amt.db");
				//int ret = mSetInfo.Load(Const.gIniFile);
				//if (ret < 1) {
				//	MessageBox.Show($"초기화 에러입니다.[CODE:{ret}]");
				//	return -1;
				//}
				//StringBuilder str_temp = new StringBuilder();
				//GetPrivateProfileString("System", "DeviceID", "", str_temp, 1000, Const.gIniFile);

				//mDeviceID = str_temp.ToString();
				// 생성자 인수는 파일 이름
				// Get a collection (or create, if doesn't exist)
				GlobalHelpers.mDB = mLDB.GetCollection<ScanInfo>("ScanInfo");
				//GlobalHelpers.mDB.EnsureIndex(x => x. )
				*/
				mAppPath = Path.GetDirectoryName(Application.ExecutablePath);

				//run the program again and close this one
				Debug.WriteLine(System.Environment.GetCommandLineArgs()[0]);

				//string aaa = "[  -71,  -68,  -67,  -96]";
				//string aaa = "[  -71,  -68,  -67,  -95]";
				//string aaa = "[  -71,  -68,  -97,  -95]";
				string aaa = "[  -71,  -68,  -97,  -94]";
				string retv = "";

				Regex reg = new Regex(@"\[(.+)\]");

				MatchCollection resultColl = reg.Matches(aaa);

				foreach (Match mm in resultColl) {
					Group g = mm.Groups[1];
					Debug.WriteLine("  mm.Groups.Count = {0}", mm.Groups.Count);
					Debug.WriteLine("  mm.Groups[0] = {0}", mm.Groups[0]);
					Debug.WriteLine("  mm.Groups[1] = {0}", mm.Groups[1]);

					Debug.WriteLine("{0}=|{1}|=", g.Index, g.Value);
					retv = g.Value;
					break;
				}
				string[] list = retv.Split(',');
				Debug.WriteLine("ProductName :" + Application.ProductName);

				List<int> tuple = new List<int>();
				foreach(string str in list) {
					int.TryParse(str, out int val);
					tuple.Add(val);
				}
				// 있는지 확인....
				Debug.WriteLine(Assembly.GetEntryAssembly().Location);


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
				Debug.WriteLine("retv : " + retv);
				/*
				switch(tuple) {
					case 2:
						break;

				}
				*/
				Debug.WriteLine(Path.GetFileName(Assembly.GetEntryAssembly().Location));
				Debug.WriteLine("ProductName :" + Application.ProductName);

				//System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(System.Windows.Forms.Application.StartupPath + @"\Data");
				//Firewall.Add(Application.ProductName, Application.ExecutablePath, Firewall.Direction.INBOUND, Firewall.Action.ALLOW);
				//Firewall.Add(Application.ProductName, Application.ExecutablePath, Firewall.Direction.OUTBOUND, Firewall.Action.ALLOW);

				return 0;
			}
		}

		public static class Const {
			public const string mVersion = @"1.0.0.1";
			public const string mAppName = @"GTWave";                  // 로그파일 이름에 쓰이므로 한글 안된다....
			public const string mCompany = @"GTWave";
			public const string mAppDesc = @"단말";

			public const string mDomain = @"https://www.gtwave.co.kr/";

			//public const string gIniFile = @"..\\cfg\\LuckKiosk.ini";
		}

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileSectionNames(byte[] lpszReturnBuffer, int nSize, string lpFileName);

		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(String section, String key, String val, String filePath);

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal,
														int size, string filePath);
		[DllImport("kernel32")]
		public static extern uint GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);
	}
}