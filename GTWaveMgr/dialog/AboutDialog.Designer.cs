namespace AnyBoBu.dialog
{
	partial class AboutDialog
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
			this.pb_logo = new System.Windows.Forms.PictureBox();
			this.lb_url = new System.Windows.Forms.Label();
			this.lb_title = new System.Windows.Forms.Label();
			this.lb_subtitle = new System.Windows.Forms.Label();
			this.lb_version = new System.Windows.Forms.Label();
			this.lb_desc = new System.Windows.Forms.Label();
			this.lb_copyright = new System.Windows.Forms.Label();
			this.panel_line = new System.Windows.Forms.Panel();
			this.lb_warn_title = new System.Windows.Forms.Label();
			this.lb_warn_desc = new System.Windows.Forms.Label();
			this.btn_ok = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
			this.SuspendLayout();
			// 
			// pb_logo
			// 
			this.pb_logo.Image = global::GTWave.Properties.Resources.GTWave_CI;
			this.pb_logo.Location = new System.Drawing.Point(24, 25);
			this.pb_logo.Name = "pb_logo";
			this.pb_logo.Size = new System.Drawing.Size(160, 48);
			this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_logo.TabIndex = 0;
			this.pb_logo.TabStop = false;
			// 
			// lb_url
			// 
			this.lb_url.AutoSize = true;
			this.lb_url.Font = new System.Drawing.Font("맑은 고딕", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_url.ForeColor = System.Drawing.Color.Black;
			this.lb_url.Location = new System.Drawing.Point(24, 78);
			this.lb_url.Name = "lb_url";
			this.lb_url.Size = new System.Drawing.Size(143, 19);
			this.lb_url.TabIndex = 1;
			this.lb_url.Text = "www.gtwave.co.kr";
			// 
			// lb_title
			// 
			this.lb_title.AutoSize = true;
			this.lb_title.Font = new System.Drawing.Font("맑은 고딕", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_title.ForeColor = System.Drawing.Color.Black;
			this.lb_title.Location = new System.Drawing.Point(215, 23);
			this.lb_title.Name = "lb_title";
			this.lb_title.Size = new System.Drawing.Size(126, 25);
			this.lb_title.TabIndex = 2;
			this.lb_title.Text = "GTWave NMS";
			// 
			// lb_subtitle
			// 
			this.lb_subtitle.AutoSize = true;
			this.lb_subtitle.Font = new System.Drawing.Font("맑은 고딕", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_subtitle.ForeColor = System.Drawing.Color.Black;
			this.lb_subtitle.Location = new System.Drawing.Point(215, 52);
			this.lb_subtitle.Name = "lb_subtitle";
			this.lb_subtitle.Size = new System.Drawing.Size(207, 19);
			this.lb_subtitle.TabIndex = 3;
			this.lb_subtitle.Text = "Network Monitoring System";
			// 
			// lb_version
			// 
			this.lb_version.AutoSize = true;
			this.lb_version.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_version.ForeColor = System.Drawing.Color.Black;
			this.lb_version.Location = new System.Drawing.Point(215, 78);
			this.lb_version.Name = "lb_version";
			this.lb_version.Size = new System.Drawing.Size(107, 20);
			this.lb_version.TabIndex = 4;
			this.lb_version.Text = "Version 1.0.1";
			// 
			// lb_desc
			// 
			this.lb_desc.Font = new System.Drawing.Font("맑은 고딕", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_desc.ForeColor = System.Drawing.Color.Black;
			this.lb_desc.Location = new System.Drawing.Point(24, 126);
			this.lb_desc.Name = "lb_desc";
			this.lb_desc.Size = new System.Drawing.Size(430, 38);
			this.lb_desc.TabIndex = 5;
			this.lb_desc.Text = "GTWave NMS는 ㈜지티웨이브 무선장비와 네트워크 스위치 등 IP 주소를 가진 네트워크 장비들의 시스템들을 모니터링 합니다.";
			// 
			// lb_copyright
			// 
			this.lb_copyright.AutoSize = true;
			this.lb_copyright.Font = new System.Drawing.Font("맑은 고딕", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_copyright.ForeColor = System.Drawing.Color.Black;
			this.lb_copyright.Location = new System.Drawing.Point(24, 178);
			this.lb_copyright.Name = "lb_copyright";
			this.lb_copyright.Size = new System.Drawing.Size(294, 17);
			this.lb_copyright.TabIndex = 6;
			this.lb_copyright.Text = "Copyright GTWave Co., Ltd.  All rights reserved";
			// 
			// panel_line
			// 
			this.panel_line.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.panel_line.Location = new System.Drawing.Point(25, 208);
			this.panel_line.Name = "panel_line";
			this.panel_line.Size = new System.Drawing.Size(425, 1);
			this.panel_line.TabIndex = 7;
			// 
			// lb_warn_title
			// 
			this.lb_warn_title.AutoSize = true;
			this.lb_warn_title.Font = new System.Drawing.Font("맑은 고딕", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_warn_title.ForeColor = System.Drawing.Color.Red;
			this.lb_warn_title.Location = new System.Drawing.Point(28, 222);
			this.lb_warn_title.Name = "lb_warn_title";
			this.lb_warn_title.Size = new System.Drawing.Size(34, 17);
			this.lb_warn_title.TabIndex = 8;
			this.lb_warn_title.Text = "경고";
			// 
			// lb_warn_desc
			// 
			this.lb_warn_desc.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lb_warn_desc.ForeColor = System.Drawing.Color.Black;
			this.lb_warn_desc.Location = new System.Drawing.Point(28, 244);
			this.lb_warn_desc.Name = "lb_warn_desc";
			this.lb_warn_desc.Size = new System.Drawing.Size(420, 56);
			this.lb_warn_desc.TabIndex = 9;
			this.lb_warn_desc.Text = "이 프로그램은 저작권법과 국제 협약의 보호를 받습니다.\r\n이 프로그램의 전부 또는 일부를 무단으로 복제, 배포하는 행위는 민사 및 형사법에 의해 엄격" +
    "히 규제되어 있으며, 기소 사유가 됩니다.";
			// 
			// btn_ok
			// 
			this.btn_ok.BackColor = System.Drawing.Color.White;
			this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btn_ok.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btn_ok.Location = new System.Drawing.Point(344, 308);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(100, 28);
			this.btn_ok.TabIndex = 10;
			this.btn_ok.Text = "확   인";
			this.btn_ok.UseVisualStyleBackColor = false;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// AboutDialog
			// 
			this.AcceptButton = this.btn_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(474, 350);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.lb_warn_desc);
			this.Controls.Add(this.lb_warn_title);
			this.Controls.Add(this.panel_line);
			this.Controls.Add(this.lb_copyright);
			this.Controls.Add(this.lb_desc);
			this.Controls.Add(this.lb_version);
			this.Controls.Add(this.lb_subtitle);
			this.Controls.Add(this.lb_title);
			this.Controls.Add(this.lb_url);
			this.Controls.Add(this.pb_logo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "GTWave NMS정보";
			((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pb_logo;
		private System.Windows.Forms.Label lb_url;
		private System.Windows.Forms.Label lb_title;
		private System.Windows.Forms.Label lb_subtitle;
		private System.Windows.Forms.Label lb_version;
		private System.Windows.Forms.Label lb_desc;
		private System.Windows.Forms.Label lb_copyright;
		private System.Windows.Forms.Panel panel_line;
		private System.Windows.Forms.Label lb_warn_title;
		private System.Windows.Forms.Label lb_warn_desc;
		private System.Windows.Forms.Button btn_ok;
	}
}
