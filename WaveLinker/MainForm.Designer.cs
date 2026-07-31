namespace WaveLinker {
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			bt_close = new Button();
			bt_scan = new Button();
			cb_ip = new ComboBox();
			label1 = new Label();
			label4 = new Label();
			lb_uptime = new Label();
			label2 = new Label();
			tb_port = new TextBox();
			gb_device0 = new GroupBox();
			lv_scan_list = new ListView();
			SSID = new ColumnHeader();
			MAC = new ColumnHeader();
			Signal = new ColumnHeader();
			SigChain = new ColumnHeader();
			RxRate = new ColumnHeader();
			TxRate = new ColumnHeader();
			TxCCQ = new ColumnHeader();
			bt_print = new Button();
			bt_stop = new Button();
			cb_auto_save = new CheckBox();
			gb_device1 = new GroupBox();
			lb_g_mode_1 = new Label();
			lb_g_freq_1 = new Label();
			lb_g_sec_1 = new Label();
			lb_g_ssid_1 = new Label();
			lb_g_bssid_1 = new Label();
			label13 = new Label();
			label14 = new Label();
			label15 = new Label();
			label16 = new Label();
			label17 = new Label();
			lb_g_sec_0 = new Label();
			label11 = new Label();
			label22 = new Label();
			label9 = new Label();
			lb_g_bssid_0 = new Label();
			label8 = new Label();
			lb_g_freq_0 = new Label();
			label10 = new Label();
			lb_g_ssid_0 = new Label();
			lb_g_mode_0 = new Label();
			gb_device0.SuspendLayout();
			gb_device1.SuspendLayout();
			SuspendLayout();
			// 
			// bt_close
			// 
			bt_close.Font = new Font("굴림체", 12F, FontStyle.Bold, GraphicsUnit.Point);
			bt_close.Location = new Point(799, 146);
			bt_close.Name = "bt_close";
			bt_close.Size = new Size(119, 23);
			bt_close.TabIndex = 7;
			bt_close.Text = "종료하기";
			bt_close.UseVisualStyleBackColor = true;
			bt_close.Click += bt_close_Click;
			// 
			// bt_scan
			// 
			bt_scan.Font = new Font("굴림체", 12F, FontStyle.Bold, GraphicsUnit.Point);
			bt_scan.Location = new Point(737, 16);
			bt_scan.Name = "bt_scan";
			bt_scan.Size = new Size(86, 25);
			bt_scan.TabIndex = 9;
			bt_scan.Text = "스캔";
			bt_scan.UseVisualStyleBackColor = true;
			bt_scan.Click += bt_scan_Click;
			// 
			// cb_ip
			// 
			cb_ip.Font = new Font("굴림", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
			cb_ip.FormattingEnabled = true;
			cb_ip.Location = new Point(69, 18);
			cb_ip.Name = "cb_ip";
			cb_ip.Size = new Size(219, 21);
			cb_ip.TabIndex = 10;
			cb_ip.Text = "192.168.10.6";
			cb_ip.SelectedIndexChanged += cb_PcNum_SelectedIndexChanged;
			cb_ip.TextChanged += cb_ip_TextChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(32, 22);
			label1.Name = "label1";
			label1.Size = new Size(23, 13);
			label1.TabIndex = 11;
			label1.Text = "IP:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			label4.Location = new Point(456, 22);
			label4.Name = "label4";
			label4.Size = new Size(58, 13);
			label4.TabIndex = 12;
			label4.Text = "UpTime:";
			// 
			// lb_uptime
			// 
			lb_uptime.AutoSize = true;
			lb_uptime.Font = new Font("굴림체", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
			lb_uptime.Location = new Point(520, 22);
			lb_uptime.Name = "lb_uptime";
			lb_uptime.Size = new Size(55, 13);
			lb_uptime.TabIndex = 13;
			lb_uptime.Text = "uptime";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(305, 21);
			label2.Name = "label2";
			label2.Size = new Size(36, 13);
			label2.TabIndex = 14;
			label2.Text = "Port:";
			// 
			// tb_port
			// 
			tb_port.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
			tb_port.Location = new Point(353, 16);
			tb_port.Name = "tb_port";
			tb_port.Size = new Size(76, 25);
			tb_port.TabIndex = 15;
			tb_port.Text = "8081";
			tb_port.TextChanged += tb_port_TextChanged;
			// 
			// gb_device0
			// 
			gb_device0.BackColor = SystemColors.Control;
			gb_device0.Controls.Add(lb_g_mode_0);
			gb_device0.Controls.Add(lb_g_freq_0);
			gb_device0.Controls.Add(lb_g_sec_0);
			gb_device0.Controls.Add(lb_g_ssid_0);
			gb_device0.Controls.Add(lb_g_bssid_0);
			gb_device0.Controls.Add(label22);
			gb_device0.Controls.Add(label11);
			gb_device0.Controls.Add(label10);
			gb_device0.Controls.Add(label9);
			gb_device0.Controls.Add(label8);
			gb_device0.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			gb_device0.Location = new Point(8, 47);
			gb_device0.Name = "gb_device0";
			gb_device0.Size = new Size(391, 122);
			gb_device0.TabIndex = 24;
			gb_device0.TabStop = false;
			gb_device0.Text = "wifi0";
			gb_device0.Enter += gb_device0_Enter;
			// 
			// lv_scan_list
			// 
			lv_scan_list.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lv_scan_list.BorderStyle = BorderStyle.FixedSingle;
			lv_scan_list.Columns.AddRange(new ColumnHeader[] { SSID, MAC, Signal, SigChain, RxRate, TxRate, TxCCQ });
			lv_scan_list.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			lv_scan_list.FullRowSelect = true;
			lv_scan_list.GridLines = true;
			lv_scan_list.Location = new Point(8, 177);
			lv_scan_list.Name = "lv_scan_list";
			lv_scan_list.Size = new Size(916, 362);
			lv_scan_list.TabIndex = 26;
			lv_scan_list.UseCompatibleStateImageBehavior = false;
			lv_scan_list.View = View.Details;
			// 
			// SSID
			// 
			SSID.Text = "SSID";
			SSID.Width = 120;
			// 
			// MAC
			// 
			MAC.Text = "MAC Addr";
			MAC.Width = 140;
			// 
			// Signal
			// 
			Signal.Text = "Signal";
			Signal.TextAlign = HorizontalAlignment.Center;
			Signal.Width = 70;
			// 
			// SigChain
			// 
			SigChain.Text = "Signal Chain";
			SigChain.TextAlign = HorizontalAlignment.Center;
			SigChain.Width = 180;
			// 
			// RxRate
			// 
			RxRate.Text = "RxRate";
			RxRate.TextAlign = HorizontalAlignment.Center;
			RxRate.Width = 100;
			// 
			// TxRate
			// 
			TxRate.Text = "TxRate";
			TxRate.TextAlign = HorizontalAlignment.Center;
			TxRate.Width = 100;
			// 
			// TxCCQ
			// 
			TxCCQ.Text = "TxCCQ";
			TxCCQ.TextAlign = HorizontalAlignment.Center;
			TxCCQ.Width = 80;
			// 
			// bt_print
			// 
			bt_print.Font = new Font("굴림체", 12F, FontStyle.Bold, GraphicsUnit.Point);
			bt_print.Location = new Point(799, 118);
			bt_print.Name = "bt_print";
			bt_print.Size = new Size(119, 24);
			bt_print.TabIndex = 27;
			bt_print.Text = "결과보기";
			bt_print.UseVisualStyleBackColor = true;
			bt_print.Click += bt_print_Click;
			// 
			// bt_stop
			// 
			bt_stop.Font = new Font("굴림체", 12F, FontStyle.Bold, GraphicsUnit.Point);
			bt_stop.Location = new Point(829, 16);
			bt_stop.Name = "bt_stop";
			bt_stop.Size = new Size(88, 25);
			bt_stop.TabIndex = 28;
			bt_stop.Text = "정지";
			bt_stop.UseVisualStyleBackColor = true;
			bt_stop.Click += bt_stop_Click;
			// 
			// cb_auto_save
			// 
			cb_auto_save.AutoSize = true;
			cb_auto_save.Checked = true;
			cb_auto_save.CheckState = CheckState.Checked;
			cb_auto_save.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
			cb_auto_save.Location = new Point(799, 63);
			cb_auto_save.Name = "cb_auto_save";
			cb_auto_save.Size = new Size(93, 25);
			cb_auto_save.TabIndex = 29;
			cb_auto_save.Text = "자동저장";
			cb_auto_save.UseVisualStyleBackColor = true;
			// 
			// gb_device1
			// 
			gb_device1.Controls.Add(lb_g_mode_1);
			gb_device1.Controls.Add(lb_g_freq_1);
			gb_device1.Controls.Add(lb_g_sec_1);
			gb_device1.Controls.Add(lb_g_ssid_1);
			gb_device1.Controls.Add(lb_g_bssid_1);
			gb_device1.Controls.Add(label13);
			gb_device1.Controls.Add(label14);
			gb_device1.Controls.Add(label15);
			gb_device1.Controls.Add(label16);
			gb_device1.Controls.Add(label17);
			gb_device1.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			gb_device1.Location = new Point(405, 49);
			gb_device1.Name = "gb_device1";
			gb_device1.Size = new Size(370, 122);
			gb_device1.TabIndex = 30;
			gb_device1.TabStop = false;
			gb_device1.Text = "wifi0";
			// 
			// lb_g_mode_1
			// 
			lb_g_mode_1.BackColor = SystemColors.ControlLightLight;
			lb_g_mode_1.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			lb_g_mode_1.Location = new Point(117, 11);
			lb_g_mode_1.Name = "lb_g_mode_1";
			lb_g_mode_1.Size = new Size(244, 20);
			lb_g_mode_1.TabIndex = 38;
			lb_g_mode_1.Text = "BSSID:";
			// 
			// lb_g_freq_1
			// 
			lb_g_freq_1.BackColor = SystemColors.ControlLightLight;
			lb_g_freq_1.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			lb_g_freq_1.Location = new Point(117, 33);
			lb_g_freq_1.Name = "lb_g_freq_1";
			lb_g_freq_1.Size = new Size(244, 20);
			lb_g_freq_1.TabIndex = 37;
			lb_g_freq_1.Text = "BSSID:";
			// 
			// lb_g_sec_1
			// 
			lb_g_sec_1.BackColor = SystemColors.ControlLightLight;
			lb_g_sec_1.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			lb_g_sec_1.Location = new Point(117, 99);
			lb_g_sec_1.Name = "lb_g_sec_1";
			lb_g_sec_1.Size = new Size(244, 20);
			lb_g_sec_1.TabIndex = 36;
			lb_g_sec_1.Text = "BSSID:";
			// 
			// lb_g_ssid_1
			// 
			lb_g_ssid_1.BackColor = SystemColors.ControlLightLight;
			lb_g_ssid_1.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			lb_g_ssid_1.Location = new Point(117, 77);
			lb_g_ssid_1.Name = "lb_g_ssid_1";
			lb_g_ssid_1.Size = new Size(244, 20);
			lb_g_ssid_1.TabIndex = 35;
			lb_g_ssid_1.Text = "BSSID:";
			// 
			// lb_g_bssid_1
			// 
			lb_g_bssid_1.BackColor = SystemColors.ControlLightLight;
			lb_g_bssid_1.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			lb_g_bssid_1.Location = new Point(117, 55);
			lb_g_bssid_1.Name = "lb_g_bssid_1";
			lb_g_bssid_1.Size = new Size(244, 20);
			lb_g_bssid_1.TabIndex = 34;
			lb_g_bssid_1.Text = "BSSID:";
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			label13.Location = new Point(26, 14);
			label13.Name = "label13";
			label13.Size = new Size(59, 13);
			label13.TabIndex = 33;
			label13.Text = "동작모드";
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			label14.Location = new Point(28, 101);
			label14.Name = "label14";
			label14.Size = new Size(67, 13);
			label14.TabIndex = 32;
			label14.Text = "SECURTY";
			// 
			// label15
			// 
			label15.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			label15.Location = new Point(28, 36);
			label15.Name = "label15";
			label15.Size = new Size(82, 18);
			label15.TabIndex = 31;
			label15.Text = "FREQ";
			// 
			// label16
			// 
			label16.AutoSize = true;
			label16.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			label16.Location = new Point(28, 80);
			label16.Name = "label16";
			label16.Size = new Size(37, 13);
			label16.TabIndex = 30;
			label16.Text = "SSID";
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			label17.Location = new Point(28, 58);
			label17.Name = "label17";
			label17.Size = new Size(46, 13);
			label17.TabIndex = 29;
			label17.Text = "BSSID";
			// 
			// lb_g_sec_0
			// 
			lb_g_sec_0.BackColor = SystemColors.ControlLightLight;
			lb_g_sec_0.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			lb_g_sec_0.Location = new Point(126, 99);
			lb_g_sec_0.Name = "lb_g_sec_0";
			lb_g_sec_0.Size = new Size(244, 20);
			lb_g_sec_0.TabIndex = 26;
			lb_g_sec_0.Text = "BSSID:";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			label11.Location = new Point(37, 101);
			label11.Name = "label11";
			label11.Size = new Size(67, 13);
			label11.TabIndex = 22;
			label11.Text = "SECURTY";
			// 
			// label22
			// 
			label22.AutoSize = true;
			label22.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			label22.Location = new Point(35, 13);
			label22.Name = "label22";
			label22.Size = new Size(59, 13);
			label22.TabIndex = 23;
			label22.Text = "동작모드";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			label9.Location = new Point(37, 80);
			label9.Name = "label9";
			label9.Size = new Size(37, 13);
			label9.TabIndex = 20;
			label9.Text = "SSID";
			// 
			// lb_g_bssid_0
			// 
			lb_g_bssid_0.BackColor = SystemColors.ControlLightLight;
			lb_g_bssid_0.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			lb_g_bssid_0.Location = new Point(126, 55);
			lb_g_bssid_0.Name = "lb_g_bssid_0";
			lb_g_bssid_0.Size = new Size(244, 20);
			lb_g_bssid_0.TabIndex = 24;
			lb_g_bssid_0.Text = "BSSID:";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			label8.Location = new Point(37, 58);
			label8.Name = "label8";
			label8.Size = new Size(46, 13);
			label8.TabIndex = 19;
			label8.Text = "BSSID";
			// 
			// lb_g_freq_0
			// 
			lb_g_freq_0.BackColor = SystemColors.ControlLightLight;
			lb_g_freq_0.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			lb_g_freq_0.Location = new Point(126, 33);
			lb_g_freq_0.Name = "lb_g_freq_0";
			lb_g_freq_0.Size = new Size(244, 20);
			lb_g_freq_0.TabIndex = 27;
			lb_g_freq_0.Text = "BSSID:";
			// 
			// label10
			// 
			label10.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			label10.Location = new Point(37, 34);
			label10.Name = "label10";
			label10.Size = new Size(82, 18);
			label10.TabIndex = 21;
			label10.Text = "FREQ";
			// 
			// lb_g_ssid_0
			// 
			lb_g_ssid_0.BackColor = SystemColors.ControlLightLight;
			lb_g_ssid_0.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			lb_g_ssid_0.Location = new Point(126, 77);
			lb_g_ssid_0.Name = "lb_g_ssid_0";
			lb_g_ssid_0.Size = new Size(244, 20);
			lb_g_ssid_0.TabIndex = 25;
			lb_g_ssid_0.Text = "BSSID:";
			// 
			// lb_g_mode_0
			// 
			lb_g_mode_0.BackColor = SystemColors.ControlLightLight;
			lb_g_mode_0.Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			lb_g_mode_0.Location = new Point(126, 11);
			lb_g_mode_0.Name = "lb_g_mode_0";
			lb_g_mode_0.Size = new Size(244, 20);
			lb_g_mode_0.TabIndex = 28;
			lb_g_mode_0.Text = "BSSID:";
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(8F, 13F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(931, 549);
			Controls.Add(gb_device1);
			Controls.Add(cb_auto_save);
			Controls.Add(bt_stop);
			Controls.Add(bt_print);
			Controls.Add(lv_scan_list);
			Controls.Add(gb_device0);
			Controls.Add(tb_port);
			Controls.Add(label2);
			Controls.Add(lb_uptime);
			Controls.Add(label4);
			Controls.Add(bt_close);
			Controls.Add(label1);
			Controls.Add(cb_ip);
			Controls.Add(bt_scan);
			Font = new Font("굴림", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "GTWave Linker";
			FormClosed += MainForm_FormClosed;
			Load += DailyForm_Load;
			gb_device0.ResumeLayout(false);
			gb_device0.PerformLayout();
			gb_device1.ResumeLayout(false);
			gb_device1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private System.Windows.Forms.Button bt_close;
		private System.Windows.Forms.Button bt_scan;
		private System.Windows.Forms.ComboBox cb_ip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lb_uptime;
		private Label label2;
		private TextBox tb_port;
		private GroupBox gb_device0;
		private ListView lv_scan_list;
		private Button bt_print;
		private Button bt_stop;
		private ColumnHeader SSID;
		private ColumnHeader MAC;
		private ColumnHeader Signal;
		private ColumnHeader SigChain;
		private ColumnHeader RxRate;
		private ColumnHeader TxRate;
		private ColumnHeader TxCCQ;
		private CheckBox cb_auto_save;
		private GroupBox gb_device1;
		private Label lb_g_mode_1;
		private Label lb_g_freq_1;
		private Label lb_g_sec_1;
		private Label lb_g_ssid_1;
		private Label lb_g_bssid_1;
		private Label label13;
		private Label label14;
		private Label label15;
		private Label label16;
		private Label label17;
		private Label lb_g_mode_0;
		private Label lb_g_freq_0;
		private Label lb_g_sec_0;
		private Label lb_g_ssid_0;
		private Label lb_g_bssid_0;
		private Label label22;
		private Label label11;
		private Label label10;
		private Label label9;
		private Label label8;
	}
}