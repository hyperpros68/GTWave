using System.Drawing;
using System.Windows.Forms;

namespace GTWave.gui {
	partial class WifiStatusForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WifiStatusForm));
			this.bt_close = new System.Windows.Forms.Button();
			this.bt_scan = new System.Windows.Forms.Button();
			this.cb_ip = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lb_uptime = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tb_port = new System.Windows.Forms.TextBox();
			this.gb_device0 = new System.Windows.Forms.GroupBox();
			this.lb_g_mode_0 = new System.Windows.Forms.Label();
			this.lb_g_freq_0 = new System.Windows.Forms.Label();
			this.lb_g_sec_0 = new System.Windows.Forms.Label();
			this.lb_g_ssid_0 = new System.Windows.Forms.Label();
			this.lb_g_bssid_0 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lv_scan_list = new System.Windows.Forms.ListView();
			this.SSID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.MAC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Signal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SigChain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.RxRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.TxRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.TxCCQ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.bt_print = new System.Windows.Forms.Button();
			this.bt_stop = new System.Windows.Forms.Button();
			this.cb_auto_save = new System.Windows.Forms.CheckBox();
			this.gb_device1 = new System.Windows.Forms.GroupBox();
			this.lb_g_mode_1 = new System.Windows.Forms.Label();
			this.lb_g_freq_1 = new System.Windows.Forms.Label();
			this.lb_g_sec_1 = new System.Windows.Forms.Label();
			this.lb_g_ssid_1 = new System.Windows.Forms.Label();
			this.lb_g_bssid_1 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.gb_device0.SuspendLayout();
			this.gb_device1.SuspendLayout();
			this.SuspendLayout();
			// 
			// bt_close
			// 
			this.bt_close.Font = new System.Drawing.Font("굴림체", 12F, System.Drawing.FontStyle.Bold);
			this.bt_close.Location = new System.Drawing.Point(799, 146);
			this.bt_close.Name = "bt_close";
			this.bt_close.Size = new System.Drawing.Size(119, 23);
			this.bt_close.TabIndex = 7;
			this.bt_close.Text = "종료하기";
			this.bt_close.UseVisualStyleBackColor = true;
			this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
			// 
			// bt_scan
			// 
			this.bt_scan.Font = new System.Drawing.Font("굴림체", 12F, System.Drawing.FontStyle.Bold);
			this.bt_scan.Location = new System.Drawing.Point(737, 16);
			this.bt_scan.Name = "bt_scan";
			this.bt_scan.Size = new System.Drawing.Size(86, 25);
			this.bt_scan.TabIndex = 9;
			this.bt_scan.Text = "스캔";
			this.bt_scan.UseVisualStyleBackColor = true;
			this.bt_scan.Click += new System.EventHandler(this.bt_scan_Click);
			// 
			// cb_ip
			// 
			this.cb_ip.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold);
			this.cb_ip.FormattingEnabled = true;
			this.cb_ip.Location = new System.Drawing.Point(69, 18);
			this.cb_ip.Name = "cb_ip";
			this.cb_ip.Size = new System.Drawing.Size(219, 21);
			this.cb_ip.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label1.Location = new System.Drawing.Point(32, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(23, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "IP:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label4.Location = new System.Drawing.Point(456, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "UpTime:";
			// 
			// lb_uptime
			// 
			this.lb_uptime.AutoSize = true;
			this.lb_uptime.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Bold);
			this.lb_uptime.Location = new System.Drawing.Point(520, 22);
			this.lb_uptime.Name = "lb_uptime";
			this.lb_uptime.Size = new System.Drawing.Size(55, 13);
			this.lb_uptime.TabIndex = 13;
			this.lb_uptime.Text = "uptime";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label2.Location = new System.Drawing.Point(305, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "Port:";
			// 
			// tb_port
			// 
			this.tb_port.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
			this.tb_port.Location = new System.Drawing.Point(353, 16);
			this.tb_port.Name = "tb_port";
			this.tb_port.Size = new System.Drawing.Size(76, 25);
			this.tb_port.TabIndex = 15;
			// 
			// gb_device0
			// 
			this.gb_device0.BackColor = System.Drawing.SystemColors.Control;
			this.gb_device0.Controls.Add(this.lb_g_mode_0);
			this.gb_device0.Controls.Add(this.lb_g_freq_0);
			this.gb_device0.Controls.Add(this.lb_g_sec_0);
			this.gb_device0.Controls.Add(this.lb_g_ssid_0);
			this.gb_device0.Controls.Add(this.lb_g_bssid_0);
			this.gb_device0.Controls.Add(this.label22);
			this.gb_device0.Controls.Add(this.label11);
			this.gb_device0.Controls.Add(this.label10);
			this.gb_device0.Controls.Add(this.label9);
			this.gb_device0.Controls.Add(this.label8);
			this.gb_device0.Font = new System.Drawing.Font("굴림", 9.75F);
			this.gb_device0.Location = new System.Drawing.Point(8, 47);
			this.gb_device0.Name = "gb_device0";
			this.gb_device0.Size = new System.Drawing.Size(391, 122);
			this.gb_device0.TabIndex = 24;
			this.gb_device0.TabStop = false;
			this.gb_device0.Text = "wifi0";
			// 
			// lb_g_mode_0
			// 
			this.lb_g_mode_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_mode_0.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_mode_0.Location = new System.Drawing.Point(126, 11);
			this.lb_g_mode_0.Name = "lb_g_mode_0";
			this.lb_g_mode_0.Size = new System.Drawing.Size(244, 20);
			this.lb_g_mode_0.TabIndex = 28;
			this.lb_g_mode_0.Text = "BSSID:";
			// 
			// lb_g_freq_0
			// 
			this.lb_g_freq_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_freq_0.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_freq_0.Location = new System.Drawing.Point(126, 33);
			this.lb_g_freq_0.Name = "lb_g_freq_0";
			this.lb_g_freq_0.Size = new System.Drawing.Size(244, 20);
			this.lb_g_freq_0.TabIndex = 27;
			this.lb_g_freq_0.Text = "BSSID:";
			// 
			// lb_g_sec_0
			// 
			this.lb_g_sec_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_sec_0.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_sec_0.Location = new System.Drawing.Point(126, 99);
			this.lb_g_sec_0.Name = "lb_g_sec_0";
			this.lb_g_sec_0.Size = new System.Drawing.Size(244, 20);
			this.lb_g_sec_0.TabIndex = 26;
			this.lb_g_sec_0.Text = "BSSID:";
			// 
			// lb_g_ssid_0
			// 
			this.lb_g_ssid_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_ssid_0.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_ssid_0.Location = new System.Drawing.Point(126, 77);
			this.lb_g_ssid_0.Name = "lb_g_ssid_0";
			this.lb_g_ssid_0.Size = new System.Drawing.Size(244, 20);
			this.lb_g_ssid_0.TabIndex = 25;
			this.lb_g_ssid_0.Text = "BSSID:";
			// 
			// lb_g_bssid_0
			// 
			this.lb_g_bssid_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_bssid_0.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_bssid_0.Location = new System.Drawing.Point(126, 55);
			this.lb_g_bssid_0.Name = "lb_g_bssid_0";
			this.lb_g_bssid_0.Size = new System.Drawing.Size(244, 20);
			this.lb_g_bssid_0.TabIndex = 24;
			this.lb_g_bssid_0.Text = "BSSID:";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label22.Location = new System.Drawing.Point(35, 13);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(59, 13);
			this.label22.TabIndex = 23;
			this.label22.Text = "동작모드";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label11.Location = new System.Drawing.Point(37, 101);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(67, 13);
			this.label11.TabIndex = 22;
			this.label11.Text = "SECURTY";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label10.Location = new System.Drawing.Point(37, 34);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(82, 18);
			this.label10.TabIndex = 21;
			this.label10.Text = "FREQ";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label9.Location = new System.Drawing.Point(37, 80);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(37, 13);
			this.label9.TabIndex = 20;
			this.label9.Text = "SSID";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label8.Location = new System.Drawing.Point(37, 58);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(46, 13);
			this.label8.TabIndex = 19;
			this.label8.Text = "BSSID";
			// 
			// lv_scan_list
			// 
			this.lv_scan_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lv_scan_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lv_scan_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SSID,
            this.MAC,
            this.Signal,
            this.SigChain,
            this.RxRate,
            this.TxRate,
            this.TxCCQ});
			this.lv_scan_list.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
			this.lv_scan_list.FullRowSelect = true;
			this.lv_scan_list.GridLines = true;
			this.lv_scan_list.HideSelection = false;
			this.lv_scan_list.Location = new System.Drawing.Point(8, 177);
			this.lv_scan_list.Name = "lv_scan_list";
			this.lv_scan_list.Size = new System.Drawing.Size(916, 362);
			this.lv_scan_list.TabIndex = 26;
			this.lv_scan_list.UseCompatibleStateImageBehavior = false;
			this.lv_scan_list.View = System.Windows.Forms.View.Details;
			// 
			// SSID
			// 
			this.SSID.Text = "SSID";
			this.SSID.Width = 120;
			// 
			// MAC
			// 
			this.MAC.Text = "MAC Addr";
			this.MAC.Width = 140;
			// 
			// Signal
			// 
			this.Signal.Text = "Signal";
			this.Signal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Signal.Width = 70;
			// 
			// SigChain
			// 
			this.SigChain.Text = "Signal Chain";
			this.SigChain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.SigChain.Width = 180;
			// 
			// RxRate
			// 
			this.RxRate.Text = "RxRate";
			this.RxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.RxRate.Width = 100;
			// 
			// TxRate
			// 
			this.TxRate.Text = "TxRate";
			this.TxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TxRate.Width = 100;
			// 
			// TxCCQ
			// 
			this.TxCCQ.Text = "TxCCQ";
			this.TxCCQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TxCCQ.Width = 80;
			// 
			// bt_print
			// 
			this.bt_print.Font = new System.Drawing.Font("굴림체", 12F, System.Drawing.FontStyle.Bold);
			this.bt_print.Location = new System.Drawing.Point(799, 118);
			this.bt_print.Name = "bt_print";
			this.bt_print.Size = new System.Drawing.Size(119, 24);
			this.bt_print.TabIndex = 27;
			this.bt_print.Text = "결과보기";
			this.bt_print.UseVisualStyleBackColor = true;
			this.bt_print.Click += new System.EventHandler(this.bt_print_Click);
			// 
			// bt_stop
			// 
			this.bt_stop.Font = new System.Drawing.Font("굴림체", 12F, System.Drawing.FontStyle.Bold);
			this.bt_stop.Location = new System.Drawing.Point(829, 16);
			this.bt_stop.Name = "bt_stop";
			this.bt_stop.Size = new System.Drawing.Size(88, 25);
			this.bt_stop.TabIndex = 28;
			this.bt_stop.Text = "정지";
			this.bt_stop.UseVisualStyleBackColor = true;
			this.bt_stop.Click += new System.EventHandler(this.bt_stop_Click);
			// 
			// cb_auto_save
			// 
			this.cb_auto_save.AutoSize = true;
			this.cb_auto_save.Checked = true;
			this.cb_auto_save.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cb_auto_save.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
			this.cb_auto_save.Location = new System.Drawing.Point(799, 63);
			this.cb_auto_save.Name = "cb_auto_save";
			this.cb_auto_save.Size = new System.Drawing.Size(93, 25);
			this.cb_auto_save.TabIndex = 29;
			this.cb_auto_save.Text = "자동저장";
			this.cb_auto_save.UseVisualStyleBackColor = true;
			// 
			// gb_device1
			// 
			this.gb_device1.Controls.Add(this.lb_g_mode_1);
			this.gb_device1.Controls.Add(this.lb_g_freq_1);
			this.gb_device1.Controls.Add(this.lb_g_sec_1);
			this.gb_device1.Controls.Add(this.lb_g_ssid_1);
			this.gb_device1.Controls.Add(this.lb_g_bssid_1);
			this.gb_device1.Controls.Add(this.label13);
			this.gb_device1.Controls.Add(this.label14);
			this.gb_device1.Controls.Add(this.label15);
			this.gb_device1.Controls.Add(this.label16);
			this.gb_device1.Controls.Add(this.label17);
			this.gb_device1.Font = new System.Drawing.Font("굴림", 9.75F);
			this.gb_device1.Location = new System.Drawing.Point(405, 49);
			this.gb_device1.Name = "gb_device1";
			this.gb_device1.Size = new System.Drawing.Size(370, 122);
			this.gb_device1.TabIndex = 30;
			this.gb_device1.TabStop = false;
			this.gb_device1.Text = "wifi0";
			// 
			// lb_g_mode_1
			// 
			this.lb_g_mode_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_mode_1.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_mode_1.Location = new System.Drawing.Point(117, 11);
			this.lb_g_mode_1.Name = "lb_g_mode_1";
			this.lb_g_mode_1.Size = new System.Drawing.Size(244, 20);
			this.lb_g_mode_1.TabIndex = 38;
			this.lb_g_mode_1.Text = "BSSID:";
			// 
			// lb_g_freq_1
			// 
			this.lb_g_freq_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_freq_1.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_freq_1.Location = new System.Drawing.Point(117, 33);
			this.lb_g_freq_1.Name = "lb_g_freq_1";
			this.lb_g_freq_1.Size = new System.Drawing.Size(244, 20);
			this.lb_g_freq_1.TabIndex = 37;
			this.lb_g_freq_1.Text = "BSSID:";
			// 
			// lb_g_sec_1
			// 
			this.lb_g_sec_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_sec_1.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_sec_1.Location = new System.Drawing.Point(117, 99);
			this.lb_g_sec_1.Name = "lb_g_sec_1";
			this.lb_g_sec_1.Size = new System.Drawing.Size(244, 20);
			this.lb_g_sec_1.TabIndex = 36;
			this.lb_g_sec_1.Text = "BSSID:";
			// 
			// lb_g_ssid_1
			// 
			this.lb_g_ssid_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_ssid_1.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_ssid_1.Location = new System.Drawing.Point(117, 77);
			this.lb_g_ssid_1.Name = "lb_g_ssid_1";
			this.lb_g_ssid_1.Size = new System.Drawing.Size(244, 20);
			this.lb_g_ssid_1.TabIndex = 35;
			this.lb_g_ssid_1.Text = "BSSID:";
			// 
			// lb_g_bssid_1
			// 
			this.lb_g_bssid_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_bssid_1.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_bssid_1.Location = new System.Drawing.Point(117, 55);
			this.lb_g_bssid_1.Name = "lb_g_bssid_1";
			this.lb_g_bssid_1.Size = new System.Drawing.Size(244, 20);
			this.lb_g_bssid_1.TabIndex = 34;
			this.lb_g_bssid_1.Text = "BSSID:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label13.Location = new System.Drawing.Point(26, 14);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(59, 13);
			this.label13.TabIndex = 33;
			this.label13.Text = "동작모드";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label14.Location = new System.Drawing.Point(28, 101);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(67, 13);
			this.label14.TabIndex = 32;
			this.label14.Text = "SECURTY";
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label15.Location = new System.Drawing.Point(28, 36);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(82, 18);
			this.label15.TabIndex = 31;
			this.label15.Text = "FREQ";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label16.Location = new System.Drawing.Point(28, 80);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(37, 13);
			this.label16.TabIndex = 30;
			this.label16.Text = "SSID";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label17.Location = new System.Drawing.Point(28, 58);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(46, 13);
			this.label17.TabIndex = 29;
			this.label17.Text = "BSSID";
			// 
			// WifiStatusForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(931, 549);
			this.Controls.Add(this.gb_device1);
			this.Controls.Add(this.cb_auto_save);
			this.Controls.Add(this.bt_stop);
			this.Controls.Add(this.bt_print);
			this.Controls.Add(this.lv_scan_list);
			this.Controls.Add(this.gb_device0);
			this.Controls.Add(this.tb_port);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lb_uptime);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.bt_close);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cb_ip);
			this.Controls.Add(this.bt_scan);
			this.Font = new System.Drawing.Font("굴림", 9.75F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "WifiStatusForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GTWave Linker";
			this.Load += new System.EventHandler(this.WifiStatusForm_Load);
			this.gb_device0.ResumeLayout(false);
			this.gb_device0.PerformLayout();
			this.gb_device1.ResumeLayout(false);
			this.gb_device1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button bt_close;
		private System.Windows.Forms.Button bt_scan;
		public	System.Windows.Forms.ComboBox cb_ip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lb_uptime;
		private Label label2;
		public	TextBox tb_port;
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