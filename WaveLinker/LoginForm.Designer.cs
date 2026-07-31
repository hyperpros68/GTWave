namespace HyperBase
{
    partial class LoginForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
			cb_login_id_save = new CheckBox();
			cb_login_auto = new CheckBox();
			tb_user_id = new TextBox();
			tb_user_pw = new TextBox();
			bt_login = new Button();
			bt_cancel = new Button();
			LineHighlight1 = new Panel();
			LineHighlight2 = new Panel();
			Logo = new Label();
			HeaderMin = new Button();
			HeaderExit = new Button();
			bt_event = new Button();
			pb_bobu_ci = new PictureBox();
			Lock = new PictureBox();
			Human = new PictureBox();
			((System.ComponentModel.ISupportInitialize)pb_bobu_ci).BeginInit();
			((System.ComponentModel.ISupportInitialize)Lock).BeginInit();
			((System.ComponentModel.ISupportInitialize)Human).BeginInit();
			SuspendLayout();
			// 
			// cb_login_id_save
			// 
			cb_login_id_save.AutoSize = true;
			cb_login_id_save.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
			cb_login_id_save.ForeColor = Color.White;
			cb_login_id_save.Location = new Point(52, 364);
			cb_login_id_save.Margin = new Padding(3, 2, 3, 2);
			cb_login_id_save.Name = "cb_login_id_save";
			cb_login_id_save.Size = new Size(115, 25);
			cb_login_id_save.TabIndex = 2;
			cb_login_id_save.Text = "아이디 저장";
			cb_login_id_save.TextAlign = ContentAlignment.MiddleCenter;
			cb_login_id_save.UseVisualStyleBackColor = true;
			// 
			// cb_login_auto
			// 
			cb_login_auto.AutoSize = true;
			cb_login_auto.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
			cb_login_auto.ForeColor = Color.White;
			cb_login_auto.Location = new Point(237, 364);
			cb_login_auto.Margin = new Padding(3, 2, 3, 2);
			cb_login_auto.Name = "cb_login_auto";
			cb_login_auto.Size = new Size(115, 25);
			cb_login_auto.TabIndex = 3;
			cb_login_auto.Text = "자동 로그인";
			cb_login_auto.TextAlign = ContentAlignment.MiddleCenter;
			cb_login_auto.UseVisualStyleBackColor = true;
			// 
			// tb_user_id
			// 
			tb_user_id.BackColor = Color.FromArgb(34, 36, 49);
			tb_user_id.BorderStyle = BorderStyle.None;
			tb_user_id.Font = new Font("Arial", 20F, FontStyle.Regular, GraphicsUnit.Point);
			tb_user_id.ForeColor = Color.White;
			tb_user_id.Location = new Point(111, 184);
			tb_user_id.Margin = new Padding(0);
			tb_user_id.Name = "tb_user_id";
			tb_user_id.Size = new Size(241, 31);
			tb_user_id.TabIndex = 4;
			tb_user_id.Text = "site001";
			tb_user_id.Click += tb_user_id_Click;
			// 
			// tb_user_pw
			// 
			tb_user_pw.BackColor = Color.FromArgb(34, 36, 49);
			tb_user_pw.BorderStyle = BorderStyle.None;
			tb_user_pw.Font = new Font("Arial", 20F, FontStyle.Regular, GraphicsUnit.Point);
			tb_user_pw.ForeColor = Color.White;
			tb_user_pw.Location = new Point(111, 284);
			tb_user_pw.Margin = new Padding(0);
			tb_user_pw.Name = "tb_user_pw";
			tb_user_pw.Size = new Size(241, 31);
			tb_user_pw.TabIndex = 5;
			tb_user_pw.Text = "1234";
			tb_user_pw.Click += tb_user_pw_Click;
			// 
			// bt_login
			// 
			bt_login.BackColor = Color.FromArgb(155, 0, 0);
			bt_login.FlatAppearance.BorderSize = 0;
			bt_login.FlatStyle = FlatStyle.Flat;
			bt_login.Font = new Font("맑은 고딕", 20F, FontStyle.Bold, GraphicsUnit.Point);
			bt_login.ForeColor = Color.White;
			bt_login.Location = new Point(52, 420);
			bt_login.Margin = new Padding(0);
			bt_login.Name = "bt_login";
			bt_login.Size = new Size(300, 69);
			bt_login.TabIndex = 6;
			bt_login.Text = "로그인";
			bt_login.UseVisualStyleBackColor = false;
			bt_login.Click += bt_login_Click;
			// 
			// bt_cancel
			// 
			bt_cancel.FlatStyle = FlatStyle.Flat;
			bt_cancel.Font = new Font("맑은 고딕", 20F, FontStyle.Bold, GraphicsUnit.Point);
			bt_cancel.ForeColor = Color.Transparent;
			bt_cancel.Location = new Point(52, 508);
			bt_cancel.Margin = new Padding(3, 2, 3, 2);
			bt_cancel.Name = "bt_cancel";
			bt_cancel.Size = new Size(300, 69);
			bt_cancel.TabIndex = 7;
			bt_cancel.Text = "취소";
			bt_cancel.UseVisualStyleBackColor = true;
			bt_cancel.Click += bt_cancel_Click;
			// 
			// LineHighlight1
			// 
			LineHighlight1.BackColor = Color.White;
			LineHighlight1.Location = new Point(52, 238);
			LineHighlight1.Margin = new Padding(3, 4, 3, 4);
			LineHighlight1.Name = "LineHighlight1";
			LineHighlight1.Size = new Size(300, 2);
			LineHighlight1.TabIndex = 11;
			// 
			// LineHighlight2
			// 
			LineHighlight2.BackColor = Color.White;
			LineHighlight2.Location = new Point(52, 330);
			LineHighlight2.Margin = new Padding(3, 4, 3, 4);
			LineHighlight2.Name = "LineHighlight2";
			LineHighlight2.Size = new Size(300, 2);
			LineHighlight2.TabIndex = 12;
			// 
			// Logo
			// 
			Logo.AutoSize = true;
			Logo.Font = new Font("Bauhaus 93", 28F, FontStyle.Regular, GraphicsUnit.Point);
			Logo.ForeColor = Color.White;
			Logo.Location = new Point(126, 65);
			Logo.Name = "Logo";
			Logo.Size = new Size(140, 43);
			Logo.TabIndex = 13;
			Logo.Text = "BoBuAI";
			// 
			// HeaderMin
			// 
			HeaderMin.FlatAppearance.BorderSize = 0;
			HeaderMin.FlatStyle = FlatStyle.Flat;
			HeaderMin.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
			HeaderMin.ForeColor = Color.White;
			HeaderMin.Location = new Point(340, 0);
			HeaderMin.Margin = new Padding(0);
			HeaderMin.Name = "HeaderMin";
			HeaderMin.Size = new Size(30, 38);
			HeaderMin.TabIndex = 16;
			HeaderMin.Text = "ㅡ";
			HeaderMin.UseVisualStyleBackColor = true;
			HeaderMin.Click += HeaderMin_Click;
			// 
			// HeaderExit
			// 
			HeaderExit.FlatAppearance.BorderSize = 0;
			HeaderExit.FlatStyle = FlatStyle.Flat;
			HeaderExit.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
			HeaderExit.ForeColor = Color.White;
			HeaderExit.Location = new Point(370, 0);
			HeaderExit.Margin = new Padding(0);
			HeaderExit.Name = "HeaderExit";
			HeaderExit.Size = new Size(30, 38);
			HeaderExit.TabIndex = 17;
			HeaderExit.Text = "X";
			HeaderExit.UseVisualStyleBackColor = true;
			HeaderExit.Click += bt_cancel_Click;
			// 
			// bt_event
			// 
			bt_event.BackColor = Color.DarkSeaGreen;
			bt_event.FlatAppearance.BorderSize = 0;
			bt_event.FlatStyle = FlatStyle.Flat;
			bt_event.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
			bt_event.ForeColor = Color.White;
			bt_event.Location = new Point(8, 9);
			bt_event.Margin = new Padding(0);
			bt_event.Name = "bt_event";
			bt_event.Size = new Size(186, 42);
			bt_event.TabIndex = 18;
			bt_event.Text = "이벤트 전송";
			bt_event.UseVisualStyleBackColor = false;
			bt_event.Click += bt_event_Click;
			// 
			// pb_bobu_ci
			// 
			pb_bobu_ci.Image = (Image)resources.GetObject("pb_bobu_ci.Image");
			pb_bobu_ci.InitialImage = null;
			pb_bobu_ci.Location = new Point(64, 66);
			pb_bobu_ci.Margin = new Padding(3, 4, 3, 4);
			pb_bobu_ci.Name = "pb_bobu_ci";
			pb_bobu_ci.Size = new Size(269, 78);
			pb_bobu_ci.SizeMode = PictureBoxSizeMode.Zoom;
			pb_bobu_ci.TabIndex = 19;
			pb_bobu_ci.TabStop = false;
			// 
			// Lock
			// 
			Lock.Image = (Image)resources.GetObject("Lock.Image");
			Lock.Location = new Point(52, 262);
			Lock.Margin = new Padding(3, 4, 3, 4);
			Lock.Name = "Lock";
			Lock.Size = new Size(48, 60);
			Lock.TabIndex = 10;
			Lock.TabStop = false;
			// 
			// Human
			// 
			Human.BorderStyle = BorderStyle.FixedSingle;
			Human.Image = (Image)resources.GetObject("Human.Image");
			Human.Location = new Point(52, 170);
			Human.Margin = new Padding(3, 4, 3, 4);
			Human.Name = "Human";
			Human.Size = new Size(49, 61);
			Human.TabIndex = 9;
			Human.TabStop = false;
			// 
			// LoginForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(34, 36, 49);
			ClientSize = new Size(400, 606);
			Controls.Add(pb_bobu_ci);
			Controls.Add(bt_event);
			Controls.Add(HeaderExit);
			Controls.Add(HeaderMin);
			Controls.Add(Logo);
			Controls.Add(LineHighlight2);
			Controls.Add(LineHighlight1);
			Controls.Add(Lock);
			Controls.Add(Human);
			Controls.Add(bt_cancel);
			Controls.Add(bt_login);
			Controls.Add(tb_user_pw);
			Controls.Add(tb_user_id);
			Controls.Add(cb_login_auto);
			Controls.Add(cb_login_id_save);
			FormBorderStyle = FormBorderStyle.None;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 2, 3, 2);
			Name = "LoginForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "로그인 창";
			TopMost = true;
			FormClosed += LoginForm_FormClosed;
			Load += LoginForm_Load;
			MouseDown += LoginForm_MouseDown;
			MouseMove += LoginForm_MouseMove;
			((System.ComponentModel.ISupportInitialize)pb_bobu_ci).EndInit();
			((System.ComponentModel.ISupportInitialize)Lock).EndInit();
			((System.ComponentModel.ISupportInitialize)Human).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private System.Windows.Forms.CheckBox cb_login_id_save;
        private System.Windows.Forms.CheckBox cb_login_auto;
        private System.Windows.Forms.TextBox tb_user_id;
        private System.Windows.Forms.TextBox tb_user_pw;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.PictureBox Human;
        private System.Windows.Forms.PictureBox Lock;
        private System.Windows.Forms.Panel LineHighlight1;
        private System.Windows.Forms.Panel LineHighlight2;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.Label Logo;
        private System.Windows.Forms.Button HeaderMin;
        private System.Windows.Forms.Button HeaderExit;
        private System.Windows.Forms.Button bt_event;
        private System.Windows.Forms.PictureBox pb_bobu_ci;
    }
}

