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
		public	int		sysTimeout		{ get; set; }	= 500;
		public	int		sysPacketSize	{ get; set; }	= 32;

		public	string	colorBack_1_1	{ get; set; }	= "#ff31ca";
		public	string	colorBack_1_2	{ get; set; }	= "#ff31ca";
		public	int		colorTime_1		{ get; set; }	= 5;

		public	string	colorBack_2_1	{ get; set; }	= "#ff31ca";
		public	string	colorBack_2_2	{ get; set; }	= "#ff31ca";
		public	int		colorTime_2		{ get; set; }	= 5;

		public	string	colorLine_1_1	{ get; set; }	= "#ff31ca";
		public	string	colorLine_1_2	{ get; set; }	= "#ff31ca";
		//public	string	colorCustom_1	{ get; set; }	= "";
		public	string	colorLine_2_1	{ get; set; }	= "#ff31ca";
		public	string	colorLine_2_2	{ get; set; }	= "#ff31ca";
		//public	string	colorCustom_2	{ get; set; }	= "";

		public	bool	fileAuto		{ get; set; }	= true;
		public	string	filePath		{ get; set; }	= "";
		public	bool	logAuto			{ get; set; }	= true;
		public	string	logPath			{ get; set; }	= "";
		public	string	logName			{ get; set; }	= "";

		public	bool	errorWindow		{ get; set; }	= true;
		public	int		errorAutoClose	{ get; set; }	= 5;
		public	bool	errorSound		{ get; set; }	= true;


		public ConfigInfo()
		{
		}

		public	void	Save(string filePath) {
			// 
			WritePrivateProfileString("시스템 체크", "체크간격", sysTimeCheck.ToString(), filePath);
			WritePrivateProfileString("시스템 체크", "타임아웃", sysTimeout.ToString(), filePath);
			WritePrivateProfileString("시스템 체크", "패킷크기", sysPacketSize.ToString(), filePath);

			WritePrivateProfileString("색 지정", "배경색_1_1", colorBack_1_1, filePath);
			WritePrivateProfileString("색 지정", "배경색_1_2", colorBack_1_2, filePath);
			WritePrivateProfileString("색 지정", "타임아웃_1", sysTimeCheck.ToString(), filePath);

			WritePrivateProfileString("색 지정", "배경색_2_1", colorBack_2_1, filePath);
			WritePrivateProfileString("색 지정", "배경색_2_2", colorBack_2_2, filePath);
			WritePrivateProfileString("색 지정", "타임아웃_2", sysTimeCheck.ToString(), filePath);

			WritePrivateProfileString("색 지정", "라인색_1_1", colorLine_1_1, filePath);
			WritePrivateProfileString("색 지정", "라인색_1_2", colorLine_1_2, filePath);
			WritePrivateProfileString("색 지정", "라인색_2_1", colorLine_2_1, filePath);
			WritePrivateProfileString("색 지정", "라인색_2_2", colorLine_2_2, filePath);

			WritePrivateProfileString("파일 설정", "구성도 불러오기", fileAuto.ToString(), filePath);
			WritePrivateProfileString("파일 설정", "구성도 저장폴더", logPath, filePath);

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
			sysTimeout		= (int)GetPrivateProfileInt("시스템 체크", "타임 아웃", 500, filePath);
			sysPacketSize	= (int)GetPrivateProfileInt("시스템 체크", "패킷 크기", 32, filePath);

			GetPrivateProfileString("색 지정", "배경색_1_1", "#ff31ca", str_temp, 1000, filePath);
			colorBack_1_1	= str_temp.ToString();
			GetPrivateProfileString("색 지정", "배경색_1_2", "#ff31ca", str_temp, 1000, filePath);
			colorBack_1_2	= str_temp.ToString();
			colorTime_1		= (int)GetPrivateProfileInt("색 지정", "타임아웃_1", 32, filePath);

			GetPrivateProfileString("색 지정", "배경색_2_1", "#ff31ca", str_temp, 1000, filePath);
			colorBack_2_1	= str_temp.ToString();
			GetPrivateProfileString("색 지정", "배경색_2_2", "#ff31ca", str_temp, 1000, filePath);
			colorBack_2_2	= str_temp.ToString();
			colorTime_1		= (int)GetPrivateProfileInt("색 지정", "타임아웃_2", 32, filePath);

			GetPrivateProfileString("색 지정", "라인색_1_1", "#ff31ca", str_temp, 1000, filePath);
			colorLine_1_1	= str_temp.ToString();
			GetPrivateProfileString("색 지정", "라인색_1_2", "#ff31ca", str_temp, 1000, filePath);
			colorLine_1_2	= str_temp.ToString();
			GetPrivateProfileString("색 지정", "라인색_2_1", "#ff31ca", str_temp, 1000, filePath);
			colorLine_2_1	= str_temp.ToString();
			GetPrivateProfileString("색 지정", "라인색_2_2", "#ff31ca", str_temp, 1000, filePath);
			colorLine_2_2	= str_temp.ToString();

			GetPrivateProfileString("파일 설정", "구성도 불러오기", "True", str_temp, 1000, filePath);
			fileAuto		= Convert.ToBoolean(str_temp.ToString());
			GetPrivateProfileString("파일 설정", "구성도 저장폴더", "", str_temp, 1000, filePath);
			filePath		= str_temp.ToString();
			
			GetPrivateProfileString("파일 설정", "로그 불러오기", "True", str_temp, 1000, filePath);
			logAuto			= Convert.ToBoolean(str_temp.ToString());
			GetPrivateProfileString("파일 설정", "로그 저장폴더", "", str_temp, 1000, filePath);
			logPath			= str_temp.ToString();
			GetPrivateProfileString("파일 설정", "로그 저장파일", "", str_temp, 1000, filePath);
			logName			= str_temp.ToString();

			GetPrivateProfileString("장애 설정", "장애창 보이기", "True", str_temp, 1000, filePath);
			errorWindow		= Convert.ToBoolean(str_temp.ToString());
			errorAutoClose	= (int)GetPrivateProfileInt("장애 설정", "자동 닫기", 32, filePath);
			
			GetPrivateProfileString("장애 설정", "사운드 발생", "True", str_temp, 1000, filePath);
			errorSound		= Convert.ToBoolean(str_temp.ToString());
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
