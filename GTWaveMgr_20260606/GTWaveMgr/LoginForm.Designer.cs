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
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
			this.cb_login_id_save = new System.Windows.Forms.CheckBox();
			this.cb_login_auto = new System.Windows.Forms.CheckBox();
			this.tb_user_id = new System.Windows.Forms.TextBox();
			this.tb_user_pw = new System.Windows.Forms.TextBox();
			this.bt_login = new System.Windows.Forms.Button();
			this.bt_cancel = new System.Windows.Forms.Button();
			this.LineHighlight1 = new System.Windows.Forms.Panel();
			this.LineHighlight2 = new System.Windows.Forms.Panel();
			this.Logo = new System.Windows.Forms.Label();
			this.HeaderMin = new System.Windows.Forms.Button();
			this.HeaderExit = new System.Windows.Forms.Button();
			this.pb_bobu_ci = new System.Windows.Forms.PictureBox();
			this.Lock = new System.Windows.Forms.PictureBox();
			this.Human = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pb_bobu_ci)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Lock)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Human)).BeginInit();
			this.SuspendLayout();
			// 
			// cb_login_id_save
			// 
			this.cb_login_id_save.AutoSize = true;
			this.cb_login_id_save.Font = new System.Drawing.Font("맑은 고딕", 12F);
			this.cb_login_id_save.ForeColor = System.Drawing.Color.White;
			this.cb_login_id_save.Location = new System.Drawing.Point(52, 291);
			this.cb_login_id_save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cb_login_id_save.Name = "cb_login_id_save";
			this.cb_login_id_save.Size = new System.Drawing.Size(115, 25);
			this.cb_login_id_save.TabIndex = 2;
			this.cb_login_id_save.Text = "아이디 저장";
			this.cb_login_id_save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cb_login_id_save.UseVisualStyleBackColor = true;
			// 
			// cb_login_auto
			// 
			this.cb_login_auto.AutoSize = true;
			this.cb_login_auto.Font = new System.Drawing.Font("맑은 고딕", 12F);
			this.cb_login_auto.ForeColor = System.Drawing.Color.White;
			this.cb_login_auto.Location = new System.Drawing.Point(237, 291);
			this.cb_login_auto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cb_login_auto.Name = "cb_login_auto";
			this.cb_login_auto.Size = new System.Drawing.Size(115, 25);
			this.cb_login_auto.TabIndex = 3;
			this.cb_login_auto.Text = "자동 로그인";
			this.cb_login_auto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cb_login_auto.UseVisualStyleBackColor = true;
			// 
			// tb_user_id
			// 
			this.tb_user_id.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
			this.tb_user_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tb_user_id.Font = new System.Drawing.Font("Arial", 20F);
			this.tb_user_id.ForeColor = System.Drawing.Color.White;
			this.tb_user_id.Location = new System.Drawing.Point(111, 147);
			this.tb_user_id.Margin = new System.Windows.Forms.Padding(0);
			this.tb_user_id.Name = "tb_user_id";
			this.tb_user_id.Size = new System.Drawing.Size(241, 31);
			this.tb_user_id.TabIndex = 4;
			this.tb_user_id.Text = "test";
			this.tb_user_id.Click += new System.EventHandler(this.tb_user_id_Click);
			// 
			// tb_user_pw
			// 
			this.tb_user_pw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
			this.tb_user_pw.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tb_user_pw.Font = new System.Drawing.Font("Arial", 20F);
			this.tb_user_pw.ForeColor = System.Drawing.Color.White;
			this.tb_user_pw.Location = new System.Drawing.Point(111, 227);
			this.tb_user_pw.Margin = new System.Windows.Forms.Padding(0);
			this.tb_user_pw.Name = "tb_user_pw";
			this.tb_user_pw.PasswordChar = '*';
			this.tb_user_pw.Size = new System.Drawing.Size(241, 31);
			this.tb_user_pw.TabIndex = 5;
			this.tb_user_pw.Text = "11";
			this.tb_user_pw.Click += new System.EventHandler(this.tb_user_pw_Click);
			// 
			// bt_login
			// 
			this.bt_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.bt_login.FlatAppearance.BorderSize = 0;
			this.bt_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_login.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
			this.bt_login.ForeColor = System.Drawing.Color.White;
			this.bt_login.Location = new System.Drawing.Point(52, 336);
			this.bt_login.Margin = new System.Windows.Forms.Padding(0);
			this.bt_login.Name = "bt_login";
			this.bt_login.Size = new System.Drawing.Size(300, 55);
			this.bt_login.TabIndex = 6;
			this.bt_login.Text = "로그인";
			this.bt_login.UseVisualStyleBackColor = false;
			this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
			// 
			// bt_cancel
			// 
			this.bt_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_cancel.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
			this.bt_cancel.ForeColor = System.Drawing.Color.Transparent;
			this.bt_cancel.Location = new System.Drawing.Point(52, 406);
			this.bt_cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.bt_cancel.Name = "bt_cancel";
			this.bt_cancel.Size = new System.Drawing.Size(300, 55);
			this.bt_cancel.TabIndex = 7;
			this.bt_cancel.Text = "취소";
			this.bt_cancel.UseVisualStyleBackColor = true;
			this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
			// 
			// LineHighlight1
			// 
			this.LineHighlight1.BackColor = System.Drawing.Color.White;
			this.LineHighlight1.Location = new System.Drawing.Point(52, 190);
			this.LineHighlight1.Name = "LineHighlight1";
			this.LineHighlight1.Size = new System.Drawing.Size(300, 2);
			this.LineHighlight1.TabIndex = 11;
			// 
			// LineHighlight2
			// 
			this.LineHighlight2.BackColor = System.Drawing.Color.White;
			this.LineHighlight2.Location = new System.Drawing.Point(52, 264);
			this.LineHighlight2.Name = "LineHighlight2";
			this.LineHighlight2.Size = new System.Drawing.Size(300, 2);
			this.LineHighlight2.TabIndex = 12;
			// 
			// Logo
			// 
			this.Logo.AutoSize = true;
			this.Logo.Font = new System.Drawing.Font("Bauhaus 93", 28F);
			this.Logo.ForeColor = System.Drawing.Color.White;
			this.Logo.Location = new System.Drawing.Point(126, 52);
			this.Logo.Name = "Logo";
			this.Logo.Size = new System.Drawing.Size(140, 43);
			this.Logo.TabIndex = 13;
			this.Logo.Text = "BoBuAI";
			// 
			// HeaderMin
			// 
			this.HeaderMin.FlatAppearance.BorderSize = 0;
			this.HeaderMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.HeaderMin.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
			this.HeaderMin.ForeColor = System.Drawing.Color.White;
			this.HeaderMin.Location = new System.Drawing.Point(340, 0);
			this.HeaderMin.Margin = new System.Windows.Forms.Padding(0);
			this.HeaderMin.Name = "HeaderMin";
			this.HeaderMin.Size = new System.Drawing.Size(30, 30);
			this.HeaderMin.TabIndex = 16;
			this.HeaderMin.Text = "ㅡ";
			this.HeaderMin.UseVisualStyleBackColor = true;
			this.HeaderMin.Click += new System.EventHandler(this.HeaderMin_Click);
			// 
			// HeaderExit
			// 
			this.HeaderExit.FlatAppearance.BorderSize = 0;
			this.HeaderExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.HeaderExit.Font = new System.Drawing.Font("맑은 고딕", 12F);
			this.HeaderExit.ForeColor = System.Drawing.Color.White;
			this.HeaderExit.Location = new System.Drawing.Point(370, 0);
			this.HeaderExit.Margin = new System.Windows.Forms.Padding(0);
			this.HeaderExit.Name = "HeaderExit";
			this.HeaderExit.Size = new System.Drawing.Size(30, 30);
			this.HeaderExit.TabIndex = 17;
			this.HeaderExit.Text = "X";
			this.HeaderExit.UseVisualStyleBackColor = true;
			this.HeaderExit.Click += new System.EventHandler(this.bt_cancel_Click);
			// 
			// pb_bobu_ci
			// 
			this.pb_bobu_ci.Image = ((System.Drawing.Image)(resources.GetObject("pb_bobu_ci.Image")));
			this.pb_bobu_ci.InitialImage = null;
			this.pb_bobu_ci.Location = new System.Drawing.Point(64, 53);
			this.pb_bobu_ci.Name = "pb_bobu_ci";
			this.pb_bobu_ci.Size = new System.Drawing.Size(269, 62);
			this.pb_bobu_ci.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_bobu_ci.TabIndex = 19;
			this.pb_bobu_ci.TabStop = false;
			// 
			// Lock
			// 
			this.Lock.Image = ((System.Drawing.Image)(resources.GetObject("Lock.Image")));
			this.Lock.Location = new System.Drawing.Point(52, 210);
			this.Lock.Name = "Lock";
			this.Lock.Size = new System.Drawing.Size(48, 48);
			this.Lock.TabIndex = 10;
			this.Lock.TabStop = false;
			// 
			// Human
			// 
			this.Human.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Human.Image = ((System.Drawing.Image)(resources.GetObject("Human.Image")));
			this.Human.Location = new System.Drawing.Point(52, 136);
			this.Human.Name = "Human";
			this.Human.Size = new System.Drawing.Size(49, 49);
			this.Human.TabIndex = 9;
			this.Human.TabStop = false;
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
			this.ClientSize = new System.Drawing.Size(400, 485);
			this.Controls.Add(this.pb_bobu_ci);
			this.Controls.Add(this.HeaderExit);
			this.Controls.Add(this.HeaderMin);
			this.Controls.Add(this.Logo);
			this.Controls.Add(this.LineHighlight2);
			this.Controls.Add(this.LineHighlight1);
			this.Controls.Add(this.Lock);
			this.Controls.Add(this.Human);
			this.Controls.Add(this.bt_cancel);
			this.Controls.Add(this.bt_login);
			this.Controls.Add(this.tb_user_pw);
			this.Controls.Add(this.tb_user_id);
			this.Controls.Add(this.cb_login_auto);
			this.Controls.Add(this.cb_login_id_save);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "로그인 창";
			this.TopMost = true;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
			this.Load += new System.EventHandler(this.LoginForm_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseMove);
			((System.ComponentModel.ISupportInitialize)(this.pb_bobu_ci)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Lock)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Human)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

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
        private System.Windows.Forms.PictureBox pb_bobu_ci;
    }
}

