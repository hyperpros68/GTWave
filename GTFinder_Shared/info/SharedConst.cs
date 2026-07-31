using System;
using System.Globalization;
using System.Management;
using System.Net.NetworkInformation;

namespace GTFinder {
	public static class Const {
		public	const	int		PORT_COMPEX		= 7778;
		public	const	int		PORT_ANTCOR		= 3517;
		public	const	int		PORT_NADATEL	= 64988;
		public	const	int		PORT_CELLINX_SRC	= 32153;
		public	const	int		PORT_CELLINX_DST	= 32154;
		public	const	string	MODEL_ANTCOR		= "RFLINK-500M/X";
		public	const	string	MODEL_ANTCOR_NEW	= "RFLINK-500X";
		public	const	string	MODEL_NADATEL_264	= "NGUARD-264";
		public	const	string	PACKET_BROADCAST	= "255.255.255.255";

		public	enum	COMPEX_TYPE : int {
			FIND = 0,
			DATA = 1
		}

		public	const	string	mVersion = @"1.0.0.1";
		public	const	string	mAppName = @"GTWave";                    // 로그파일 이름에 쓰이므로 한글 안된다....
		public	const	string	mCompany = @"(주)지티웨이브";
		public	const	string	mAppDesc = @"네트웍 관리 도구";

		public	const	string mDomain = @"gtwave.com";

		public	const	int gMgrPort = 9901;
		public	const	string gSchema = "GTWave";

		public	const	string URL_BASE = "http://121.172.63.134:19080/";

		public	const	string gIniFile = @"..\\cfg\\GTWave.ini";
		public	const string gCfgFile = @"..\\cfg\\GTWave.cfg";

	}

	public class cWinStatus {

		public bool IsOSVisionWin7 {
			get {
				switch (Environment.OSVersion.Platform) {
					case PlatformID.Win32S:
						return false;
					case PlatformID.Win32Windows:
						return false;
					case PlatformID.Win32NT:
						switch (Environment.OSVersion.Version.Major) {
							case 3:
								return false;
							case 4:
								return false;
							case 5:
								return false;
							case 6:
								switch (Environment.OSVersion.Version.Minor) {
									case 0:
										return false;
									case 1:
										return true;
									case 2:
										return true;
									default:
										return false;
								}
							default:
								return false;
						}
					case PlatformID.WinCE:
						return false;
					default:
						return false;
				}
			}
		}

		public bool IsLanguageKorean {
			get {
				// Check if the current UI culture is Korean ("ko" or "ko-KR")
				return CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "ko" ||
					   CultureInfo.CurrentUICulture.Name == "ko-KR";
			}
		}

		public bool IsNetworkConnected {
			get {
				// Check if any network interface is available
				bool bConnected = NetworkInterface.GetIsNetworkAvailable();

				// If a network is detected, verify adapter connection status
				if (bConnected) {
					bConnected = false;
					using (var moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter")) {
						foreach (ManagementObject mObject in moSearcher.Get()) {
							if (mObject["NetConnectionStatus"] != null) {
								string strNetStatus = mObject["NetConnectionStatus"].ToString();
								if (strNetStatus == "2") // Connected status
								{
									bConnected = true;
									break; // Exit loop once a connected adapter is found
								}
							}
						}
					}
				}

				return bConnected;
			}
		}
	}
}
