using AnyBoBu.info;
using Awool;
using GTWave.info;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HyperBase
{
	public partial class LoginForm : Form
    {
        public Point mouseLoaction;
		public UserInfo LoggedUserInfo { get; private set; }

		public LoginForm()
		{
			InitializeComponent();
			if (Global.mAppIcon != null)
			{
				this.Icon = (System.Drawing.Icon)Global.mAppIcon.Clone();
			}
        }

		private void LoginForm_Load(object sender, EventArgs e)
		{
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
		}

		private void bt_login_Click(object sender, EventArgs e)
		{
			if (this.tb_user_id.Text == "")
			{
				MessageBox.Show("로그인 아이디를 입력하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.tb_user_id.Focus();
			}
			else if (this.tb_user_pw.Text == "")
			{
				MessageBox.Show("로그인 비밀번호를 입력하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.tb_user_pw.Focus();
			} else {

				var results = GlobalHelpers.mUserTb.Query()
						.Where(x => x.mMemId.Equals(tb_user_id.Text))
						//.OrderBy(x => x.mMemNm)
						//.Select(x => new { x.site, NameUpper = x.site.ToUpper() })
						//.Limit(10)
						.ToList();

				if (results.Count == 0) {
					MessageBox.Show("없는 아이디 입니다.", "알림창");
					return;
				}

				UserInfo uInfo = results[0];
				if (!string.IsNullOrEmpty(uInfo.mMemPw) && !tb_user_pw.Text.Equals(uInfo.mMemPw)) {
					MessageBox.Show("암호가 틀립니다.", "알림창");
					return;
				}
				this.LoggedUserInfo = uInfo;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
		{
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

		private void bt_cancel_Click(object sender, EventArgs e)
		{
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
