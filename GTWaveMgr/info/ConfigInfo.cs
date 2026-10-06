using FireFly.utils;
using HyperBase;
using MindFusion.Svg;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace AnyBoBu.info
{
	public	class	ConfigInfo
    {
		public	int		sysTimeCheck	{ get; set; }	= 5;
		public	int		sysTimeout		{ get; set; }	= 1000;
		public	int		sysPacketSize	{ get; set; }	= 32;

		public	string	colorBack_1_1	{ get; set; }	= "#808080";
		public	string	colorBack_1_2	{ get; set; }	= "#00FF00";
		public	int		colorTime_1		{ get; set; }	= 0;

		public	string	colorBack_2_1	{ get; set; }	= "#FFA500";
		public	string	colorBack_2_2	{ get; set; }	= "#FF0000";
		public	int		colorTime_2		{ get; set; }	= 5;

		public	string	colorLine_1_1	{ get; set; }	= "#ff31ca";
		public	string	colorLine_1_2	{ get; set; }	= "#ff31ca";
		//public	string	colorCustom_1	{ get; set; }	= "";
		public	string	colorLine_2_1	{ get; set; }	= "#ff31ca";
		public	string	colorLine_2_2	{ get; set; }	= "#ff31ca";
		//public	string	colorCustom_2	{ get; set; }	= "";

		public static string GetDefaultFilePath()
		{
			if (Directory.Exists(@"C:\GTWave\data")) return @"C:\GTWave\data";
			try
			{
				string relPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\data"));
				return relPath;
			}
			catch
			{
				return @"C:\GTWave\data";
			}
		}

		public static string GetDefaultLogPath()
		{
			if (Directory.Exists(@"C:\GTWave\logs")) return @"C:\GTWave\logs";
			if (Directory.Exists(@"C:\GTWave\log")) return @"C:\GTWave\log";
			try
			{
				string relPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\logs"));
				return relPath;
			}
			catch
			{
				return @"C:\GTWave\logs";
			}
		}

		public	bool	fileAuto		{ get; set; }	= true;
		public	string	filePath		{ get; set; }	= GetDefaultFilePath();
		public	bool	logAuto			{ get; set; }	= true;
		public	string	logPath			{ get; set; }	= GetDefaultLogPath();
		public	string	logName			{ get; set; }	= "";

		public	bool	errorWindow		{ get; set; }	= true;
		public	int		errorAutoClose	{ get; set; }	= 3;
		public	bool	errorSound		{ get; set; }	= true;


		public ConfigInfo()
		{
		}

		public void ResetDefault()
		{
			sysTimeCheck	= 5;
			sysTimeout		= 1000;
			sysPacketSize	= 32;

			colorBack_1_1	= "#808080";
			colorBack_1_2	= "#00FF00";
			colorTime_1		= 0;

			colorBack_2_1	= "#FFA500";
			colorBack_2_2	= "#FF0000";
			colorTime_2		= 5;

			fileAuto		= true;
			filePath		= GetDefaultFilePath();

			logAuto			= true;
			logPath			= GetDefaultLogPath();
			logName			= "";

			errorWindow		= true;
			errorAutoClose	= Math.Max(0, sysTimeCheck - 2);
			errorSound		= true;
		}

		public	void	Save(string filePath) {
			// 
			WritePrivateProfileString("시스템 체크", "체크간격", sysTimeCheck.ToString(), filePath);
			WritePrivateProfileString("시스템 체크", "타임아웃", sysTimeout.ToString(), filePath);
			WritePrivateProfileString("시스템 체크", "패킷크기", sysPacketSize.ToString(), filePath);

			WritePrivateProfileString("색 지정", "배경색_1_1", colorBack_1_1, filePath);
			WritePrivateProfileString("색 지정", "배경색_1_2", colorBack_1_2, filePath);
			WritePrivateProfileString("색 지정", "타임아웃_1", colorTime_1.ToString(), filePath);

			WritePrivateProfileString("색 지정", "배경색_2_1", colorBack_2_1, filePath);
			WritePrivateProfileString("색 지정", "배경색_2_2", colorBack_2_2, filePath);
			WritePrivateProfileString("색 지정", "타임아웃_2", colorTime_2.ToString(), filePath);

			WritePrivateProfileString("색 지정", "라인색_1_1", colorLine_1_1, filePath);
			WritePrivateProfileString("색 지정", "라인색_1_2", colorLine_1_2, filePath);
			WritePrivateProfileString("색 지정", "라인색_2_1", colorLine_2_1, filePath);
			WritePrivateProfileString("색 지정", "라인색_2_2", colorLine_2_2, filePath);

			WritePrivateProfileString("파일 설정", "구성도 불러오기", fileAuto.ToString(), filePath);
			WritePrivateProfileString("파일 설정", "구성도 저장폴더", this.filePath, filePath);

			WritePrivateProfileString("파일 설정", "로그 불러오기", logAuto.ToString(), filePath);
			WritePrivateProfileString("파일 설정", "로그 저장폴더", logPath, filePath);
			WritePrivateProfileString("파일 설정", "로그 저장파일", logName, filePath);

			WritePrivateProfileString("장애 설정", "장애창 보이기", errorWindow.ToString(), filePath);
			WritePrivateProfileString("장애 설정", "자동 닫기", errorAutoClose.ToString(), filePath);
			WritePrivateProfileString("장애 설정", "사운드 발생", errorSound.ToString(), filePath);
		}


		public	void	Load(string filePath) {
			// 파일이 없으면...
			if (!File.Exists(filePath)) {
				Save(filePath);
				return;
			}

			StringBuilder str_temp = new StringBuilder();

			sysTimeCheck	= (int)GetPrivateProfileInt("시스템 체크", "체크 간격", 5, filePath);
			sysTimeout		= (int)GetPrivateProfileInt("시스템 체크", "타임 아웃", 1000, filePath);
			sysPacketSize	= (int)GetPrivateProfileInt("시스템 체크", "패킷 크기", 32, filePath);

			GetPrivateProfileString("색 지정", "배경색_1_1", "#808080", str_temp, 1000, filePath);
			colorBack_1_1	= str_temp.ToString();
			if (string.IsNullOrWhiteSpace(colorBack_1_1) || "#ff31ca".Equals(colorBack_1_1, StringComparison.OrdinalIgnoreCase))
				colorBack_1_1 = "#808080";

			GetPrivateProfileString("색 지정", "배경색_1_2", "#00FF00", str_temp, 1000, filePath);
			colorBack_1_2	= str_temp.ToString();
			if (string.IsNullOrWhiteSpace(colorBack_1_2) || "#ff31ca".Equals(colorBack_1_2, StringComparison.OrdinalIgnoreCase))
				colorBack_1_2 = "#00FF00";

			colorTime_1		= (int)GetPrivateProfileInt("색 지정", "타임아웃_1", 0, filePath);

			GetPrivateProfileString("색 지정", "배경색_2_1", "#FFA500", str_temp, 1000, filePath);
			colorBack_2_1	= str_temp.ToString();
			if (string.IsNullOrWhiteSpace(colorBack_2_1) || "#ff31ca".Equals(colorBack_2_1, StringComparison.OrdinalIgnoreCase))
				colorBack_2_1 = "#FFA500";

			GetPrivateProfileString("색 지정", "배경색_2_2", "#FF0000", str_temp, 1000, filePath);
			colorBack_2_2	= str_temp.ToString();
			if (string.IsNullOrWhiteSpace(colorBack_2_2) || "#ff31ca".Equals(colorBack_2_2, StringComparison.OrdinalIgnoreCase))
				colorBack_2_2 = "#FF0000";

			colorTime_2		= (int)GetPrivateProfileInt("색 지정", "타임아웃_2", 5, filePath);

			GetPrivateProfileString("색 지정", "라인색_1_1", "#ff31ca", str_temp, 1000, filePath);
			colorLine_1_1	= str_temp.ToString();
			GetPrivateProfileString("색 지정", "라인색_1_2", "#ff31ca", str_temp, 1000, filePath);
			colorLine_1_2	= str_temp.ToString();
			GetPrivateProfileString("색 지정", "라인색_2_1", "#ff31ca", str_temp, 1000, filePath);
			colorLine_2_1	= str_temp.ToString();
			GetPrivateProfileString("색 지정", "라인색_2_2", "#ff31ca", str_temp, 1000, filePath);
			colorLine_2_2	= str_temp.ToString();

			GetPrivateProfileString("파일 설정", "구성도 불러오기", "True", str_temp, 1000, filePath);
			if (bool.TryParse(str_temp.ToString(), out bool bFileAuto)) fileAuto = bFileAuto;
			GetPrivateProfileString("파일 설정", "구성도 저장폴더", "", str_temp, 1000, filePath);
			this.filePath	= str_temp.ToString();
			if (string.IsNullOrWhiteSpace(this.filePath))
				this.filePath = GetDefaultFilePath();
			
			string defaultLogDir = GetDefaultLogPath();
			GetPrivateProfileString("파일 설정", "로그 불러오기", "True", str_temp, 1000, filePath);
			if (bool.TryParse(str_temp.ToString(), out bool bLogAuto)) logAuto = bLogAuto;
			GetPrivateProfileString("파일 설정", "로그 저장폴더", defaultLogDir, str_temp, 1000, filePath);
			logPath			= str_temp.ToString();
			if (string.IsNullOrWhiteSpace(logPath) || logPath.Contains(@"bin\log"))
				logPath = defaultLogDir;

			GetPrivateProfileString("파일 설정", "로그 저장파일", "", str_temp, 1000, filePath);
			logName			= str_temp.ToString();

			GetPrivateProfileString("장애 설정", "장애창 보이기", "True", str_temp, 1000, filePath);
			if (bool.TryParse(str_temp.ToString(), out bool bErrorWindow)) errorWindow = bErrorWindow;
			int defaultClose = Math.Max(0, sysTimeCheck - 2);
			errorAutoClose	= (int)GetPrivateProfileInt("장애 설정", "자동 닫기", defaultClose, filePath);
			if (errorAutoClose < 0) errorAutoClose = 0;
			if (errorAutoClose > defaultClose) errorAutoClose = defaultClose;
			
			GetPrivateProfileString("장애 설정", "사운드 발생", "True", str_temp, 1000, filePath);
			if (bool.TryParse(str_temp.ToString(), out bool bErrorSound)) errorSound = bErrorSound;
		}

		public	void	SetInfo(MySqlDataReader reader)
		{
			if (reader == null) return;

			//groupIdx		= reader.GetInt32("PROMO_PRICE");
			//prevIdx			= reader.GetInt32("NUM_IID");
			//groupIdx		= reader["THUMBNAIL"].ToString();
			//prevIdx			= reader["THUMBNAIL"].ToString();
			/*
			title			= reader["TITLE"].ToString();
			thumbnail		= reader["THUMBNAIL"].ToString();

			regDate			= reader["REG_DATE"].ToString();
			fixDate			= reader["FIX_DATE"].ToString();
			valid			= reader["VALID"].ToString();
			bigo			= reader["BIGO"].ToString();
			*/
		}

		/*
		public	string	getString() {
			return $"{this.rootName}|{this.name}|{this.agent}|{this.desc}";
		}


		public	void	setParse(string data) {
			string[] items = data.Split('|');
			if (items.Length > 3) {
				rootName	= items[0];
				name		= items[1];
				agent		= items[2];
				desc		= items[3];
			}
		}
		*/

		[DllImport("kernel32", CharSet = CharSet.Auto)]
		private static extern long WritePrivateProfileString(String section, String key, String val, String filePath);

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal,
														int size, string filePath);
		[DllImport("kernel32")]
		public static extern uint GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);
	}
}
