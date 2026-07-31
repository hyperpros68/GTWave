
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using WaveLinker;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace HyperBase
{
	public partial class LoginForm : Form {
		public Point mouseLoaction;

		public LoginForm() {
			InitializeComponent();
		}

		private void LoginForm_Load(object sender, EventArgs e) {
			/*
			cb_login_id_save.Checked	= Properties.Settings.Default.Login_IDSave;
			cb_login_auto.Checked		= Properties.Settings.Default.Login_Auto;
			if (cb_login_id_save.Checked) {
				tb_user_id.Text	= Properties.Settings.Default.Login_UserID;
				tb_user_pw.Text	= Properties.Settings.Default.Login_UserPW;
			}

            Logo.Location = new Point((this.Width - Logo.Width) / 2, 43);
			*/

			//Global.mMainForm.MyNoti += Noti;
			Screen[] screens = Screen.AllScreens;
			if (screens.Length > 1) // Has more screen
			{
				Screen scrn = (screens[1].WorkingArea.Contains(this.Location)) ? screens[0] : screens[0];
				Rectangle screenRect = scrn.WorkingArea; // "Screen 클래스 : 화면 크기 구하기" 참조

				this.Show();
				this.Location = new Point(screenRect.Width / 2 - this.Size.Width / 2, screenRect.Height / 2 - this.Size.Height / 2);
			}

			TimeSpan time = TimeSpan.FromSeconds(12345);
			DateTime dateTime = DateTime.Today.Add(time);
			string displayTime = dateTime.ToString("dd일 hh:mm:ss");

			Debug.WriteLine(displayTime);
			Debug.WriteLine("----------------------");
		}

		private void bt_login_Click(object sender, EventArgs e) {
			if (this.tb_user_id.Text == "") {
				MessageBox.Show("로그인 아이디를 입력하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.tb_user_id.Focus();
			} else if (this.tb_user_pw.Text == "") {
				MessageBox.Show("로그인 비밀번호를 입력하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.tb_user_pw.Focus();
			} else {
				//mySqlLogin();
				/*
				Global.mCurSite		= TBSiteInfo.Login(tb_user_id.Text, tb_user_pw.Text);
				if (Global.mCurSite != null) {
					// 현재 자기 IP와 등록되 있는게 다르면 
					string	myIP = NetServer.GetLocalIP();
					if (!Global.mCurSite.siteWanIP.Equals(myIP)) {
						AI4DDB.Exec("UPDATE SiteInfo SET siteWanIP = '"+myIP+"';");
					}
                    Visible = false;

                    //MainForm	form	= new MainForm();
					//form.Show();
                    //CtrlMainForm Main = new CtrlMainForm();
                    //Main.Show();           
				}
				*/
				//Close();
				Hide();

				MainForm lForm	= new MainForm();
				lForm.Show();

			}
		}

		private void LoginForm_FormClosed(object sender, FormClosedEventArgs e) {
			/*
			Properties.Settings.Default.Login_Auto		= cb_login_auto.Checked;
			Properties.Settings.Default.Login_IDSave	= cb_login_id_save.Checked;

			if (cb_login_id_save.Checked) {
				Properties.Settings.Default.Login_UserID	= tb_user_id.Text;
				Properties.Settings.Default.Login_UserPW	= tb_user_pw.Text;
			}
			Properties.Settings.Default.Save();
			*/
		}

		private void bt_cancel_Click(object sender, EventArgs e) {
			MessageBox.Show("프로그램을 종료 합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//MessageBox.Show("프로그램을 종료 합니다.", "알림", MessageBoxButtons..OK, MessageBoxIcon.Warning)
			Close();
			Environment.Exit(1);
		}


		private void button1_Click(object sender, EventArgs e)
		{
			//Global.mPredict.predict("AI4D.ini");
		}

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLoaction = new Point(-e.X , -e.Y);
        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseLoaction.X,mouseLoaction.Y);
                Location = mousePos;
            }
        }

        private void HeaderMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void	tb_user_id_Click(object sender, EventArgs e)
        {
            LineHighlight1.BackColor = Color.FromArgb(155, 0, 0);
            LineHighlight2.BackColor = Color.White;
        }

        private void	tb_user_pw_Click(object sender, EventArgs e)
        {
            LineHighlight2.BackColor = Color.FromArgb(155, 0, 0);
            LineHighlight1.BackColor = Color.White;
        }

		private void	bt_event_Click(object sender, EventArgs e)
		{
			string user_name = "username";              // textbox that contains the user name
			string user_password = "password";  // textbox that contains the password
												// 112.218.138.10
		// http://1.220.20.218:8012/cgi-bin/luci/;stok=1e1220bc87983e65395e7344?7344?status=1&_=0.6561156622211763

			// HTML IDs or important user information to perform a successful login against a specific
			// user
			string login_user_name = "admin";      // username
			string login_user_password = "password";  // password

			// submit info for a successful login
			//string login_submit_info = textBox3.Text;  // login submit

			// define the website or webpage connection parameters
			string get_method = "GET";  // `POST` method for web_request
			string type_webcontent = @"c_sharp-application/encoded_url-www-form";
			//string string_login = login_user_name + "=" + user_name + "&" + login_user_password + "=" +
			//					  user_password + "&" + login_submit_info;
			string string_login = user_name + "=" + login_user_name + "&" + user_password + "=" +
								  login_user_password;
			CookieContainer container_cookie = new CookieContainer();
			HttpWebRequest web_request;

			web_request = (HttpWebRequest)WebRequest.Create(
			"http://192.168.10.6/cgi-bin/luci/;stok=1e1220bc87983e65395e7344?7344?status=1&_=0.6561156622211763?" + string_login);  // or insert the `url` string that contains
																																	// the valid website URL

			//web_request.Proxy = new System.Net.WebProxy(ProxyString, true);
			web_request.CookieContainer = container_cookie;
			web_request.Method = get_method;  // for web request
			web_request.ContentType = type_webcontent;
			web_request.KeepAlive = true;
			web_request.AllowAutoRedirect = false;


			/*
			using (Stream web_stream_request = web_request.GetRequestStream())

			// generate a proper web request
			using (StreamWriter writer = new StreamWriter(web_stream_request)) {
				writer.Write(string_login);
				//writer.Write(string_login, login_user_name, login_user_password);
			}
			*/
			using (var web_stream_response = web_request.GetResponse().GetResponseStream()) using (
				var web_response_reader = new StreamReader(web_stream_response)) {
				var user_check = web_response_reader.ReadToEnd();
				Debug.WriteLine(user_check);  // the result
			}

			MessageBox.Show("Successful login to website!");

			web_request = (HttpWebRequest)WebRequest.Create(
				"http://192.168.10.6/cgi-bin/luci/;stok=1e1220bc87983e65395e7344?7344?status=1&_=0.6561156622211763?" + string_login);  // or insert the `url` string that contains
																														// the valid website URL
			web_request.CookieContainer = container_cookie;
			web_request.Method = get_method;  // for web request
			web_request.ContentType = type_webcontent;
			web_request.KeepAlive = true;
			web_request.AllowAutoRedirect = false;

			/*
			using (Stream web_stream_request = web_request.GetRequestStream())

			// generate a proper web request
			using (StreamWriter writer = new StreamWriter(web_stream_request)) {
				writer.Write(string_login, user_name, user_password);
			}
			*/
			using (var web_stream_response = web_request.GetResponse().GetResponseStream()) using (
				var web_response_reader = new StreamReader(web_stream_response)) {
				var user_check = web_response_reader.ReadToEnd();
				Debug.WriteLine(user_check);  // the result
			}

			MessageBox.Show("Successful login to website!");


			/*
			// 연결된 모든 CtrlHandle에 이벤트를 전송한다....
			Protocol	sMsg	= new Protocol(Protocol.OP_EVT);
			WatchDog	ePkg	= new WatchDog();
			
			ePkg.SetInfo(sMsg);
			Global.mNetServer.BroadCast(sMsg);
			*/
		}

		private void bt_section_cut_Click(object sender, EventArgs e)
		{
			//DemoForm	form	= new DemoForm();
			//form.Show();
		}

		private void bt_vlc_test_Click(object sender, EventArgs e)
		{
			//Global.mMainForm.MyNoti += Noti;
			this.Invoke(new MethodInvoker(delegate ()
			{
				//Global.mMainForm.UserNotiAction("G", "ddd", "123", "msg");
			}));            
			//form.Show();
		}

	}
}
