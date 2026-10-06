using AnyBoBu.info;
using Awool;
using FireFly.utils;
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
			try {
				Screen primary = Screen.PrimaryScreen;
				Rectangle screenRect = primary.WorkingArea;
				this.StartPosition = FormStartPosition.Manual;
				this.Location = new Point(screenRect.Left + (screenRect.Width - this.Width) / 2, screenRect.Top + (screenRect.Height - this.Height) / 2);
			} catch { }
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
				try
				{
					if (GlobalHelpers.mUserTb == null)
					{
						MessageBox.Show("데이터베이스가 준비되지 않았습니다. 프로그램을 다시 시작해 주세요.", "알림창", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

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
				catch (Exception ex)
				{
					LogUtil.LogException("LOGIN", ex, "Login DB query failed");
					MessageBox.Show("로그인 처리 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
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
