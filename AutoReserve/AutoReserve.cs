using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AutoReserve {
	internal static class AutoReserve {
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Application.Run(new MainForm());
		}


		/*
		login url -> https://sports.cfmc.or.kr/rent/application/index/2025/01/14/1/CHEONAN01/05/29

		logout xpath -> //*[@id="tnb"]/ul/li[2] -> <a href="https://sports.cfmc.or.kr:443/member/logout">로그아웃</a>
		login  xpath -> //*[@id="tnb"]/ul/li[2] -> <a href="https://sports.cfmc.or.kr:443/member/login">로그인</a>
			//*[@id="tnb"]/ul/li[2]

			ID : gooki15, PW : gaon123

		*/
		public class Global {
			public static string mAppPath;

			public static string mAppVersion;
			//public static SetInfo mSetInfo = new SetInfo();



			//public static ImageUtil imageUtil = new ImageUtil();
			//public static DateUtil dateUtil = new DateUtil();
			//public static IniUtil iniUtil = new IniUtil();
			public static int Init() {
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
				foreach (string str in list) {
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
			public const string mAppName = @"AutoReserve";                  // 로그파일 이름에 쓰이므로 한글 안된다....
			public const string mCompany = @"AutoReserve";
			public const string mAppDesc = @"자동예약";

			public const string mDomain = @"";

			//public const string gIniFile = @"..\\cfg\\LuckKiosk.ini";
		}
	}
}