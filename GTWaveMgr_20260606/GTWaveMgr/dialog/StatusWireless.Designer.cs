namespace AnyBoBu.dialog {
	partial class StatusWireless {
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
			this.bt_apply = new System.Windows.Forms.Button();
			this.bt_close = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.tb_desc = new System.Windows.Forms.TextBox();
			this.gb_switch = new System.Windows.Forms.GroupBox();
			this.mtb_addr = new System.Windows.Forms.MaskedTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tb_system_nm = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tb_uptime = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.gb_wifi = new System.Windows.Forms.GroupBox();
			this.lv_device_list = new System.Windows.Forms.ListView();
			this.ch_dev_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_dev_ssid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_dev_mac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_dev_signal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_sig_chain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_rx_rate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_tx_rate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tb_used_memory = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.tb_ssid = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tb_bssid = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tb_frequency = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tb_security = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tb_bitrate = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.gb_switch.SuspendLayout();
			this.gb_wifi.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// bt_apply
			// 
			this.bt_apply.Location = new System.Drawing.Point(462, 451);
			this.bt_apply.Name = "bt_apply";
			this.bt_apply.Size = new System.Drawing.Size(88, 30);
			this.bt_apply.TabIndex = 0;
			this.bt_apply.Text = "새로고침";
			this.bt_apply.UseVisualStyleBackColor = true;
			this.bt_apply.Click += new System.EventHandler(this.bt_apply_Click);
			// 
			// bt_close
			// 
			this.bt_close.Location = new System.Drawing.Point(559, 451);
			this.bt_close.Name = "bt_close";
			this.bt_close.Size = new System.Drawing.Size(88, 30);
			this.bt_close.TabIndex = 1;
			this.bt_close.Text = "닫 기";
			this.bt_close.UseVisualStyleBackColor = true;
			this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(347, 266);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(57, 12);
			this.label8.TabIndex = 142;
			this.label8.Text = "장비 설명";
			// 
			// tb_desc
			// 
			this.tb_desc.Location = new System.Drawing.Point(444, 263);
			this.tb_desc.Multiline = true;
			this.tb_desc.Name = "tb_desc";
			this.tb_desc.Size = new System.Drawing.Size(176, 24);
			this.tb_desc.TabIndex = 12;
			// 
			// gb_switch
			// 
			this.gb_switch.Controls.Add(this.tb_used_memory);
			this.gb_switch.Controls.Add(this.label7);
			this.gb_switch.Controls.Add(this.mtb_addr);
			this.gb_switch.Controls.Add(this.label5);
			this.gb_switch.Controls.Add(this.tb_system_nm);
			this.gb_switch.Controls.Add(this.label3);
			this.gb_switch.Controls.Add(this.tb_uptime);
			this.gb_switch.Controls.Add(this.label2);
			this.gb_switch.Location = new System.Drawing.Point(12, 12);
			this.gb_switch.Name = "gb_switch";
			this.gb_switch.Size = new System.Drawing.Size(635, 105);
			this.gb_switch.TabIndex = 103;
			this.gb_switch.TabStop = false;
			this.gb_switch.Text = "시스템 정보";
			// 
			// mtb_addr
			// 
			this.mtb_addr.Location = new System.Drawing.Point(429, 37);
			this.mtb_addr.Mask = "###.###.###.###";
			this.mtb_addr.Name = "mtb_addr";
			this.mtb_addr.Size = new System.Drawing.Size(109, 21);
			this.mtb_addr.TabIndex = 157;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(335, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 12);
			this.label5.TabIndex = 167;
			this.label5.Text = "IP 주소";
			// 
			// tb_system_nm
			// 
			this.tb_system_nm.Location = new System.Drawing.Point(118, 37);
			this.tb_system_nm.Name = "tb_system_nm";
			this.tb_system_nm.Size = new System.Drawing.Size(176, 21);
			this.tb_system_nm.TabIndex = 153;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 12);
			this.label3.TabIndex = 165;
			this.label3.Text = "시스템 이름";
			// 
			// tb_uptime
			// 
			this.tb_uptime.Enabled = false;
			this.tb_uptime.Location = new System.Drawing.Point(429, 69);
			this.tb_uptime.Name = "tb_uptime";
			this.tb_uptime.Size = new System.Drawing.Size(109, 21);
			this.tb_uptime.TabIndex = 155;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(335, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 12);
			this.label2.TabIndex = 164;
			this.label2.Text = "Uptime";
			// 
			// gb_wifi
			// 
			this.gb_wifi.Controls.Add(this.lv_device_list);
			this.gb_wifi.Location = new System.Drawing.Point(12, 310);
			this.gb_wifi.Name = "gb_wifi";
			this.gb_wifi.Size = new System.Drawing.Size(635, 135);
			this.gb_wifi.TabIndex = 104;
			this.gb_wifi.TabStop = false;
			this.gb_wifi.Text = "무선 연결 정보";
			// 
			// lv_device_list
			// 
			this.lv_device_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lv_device_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lv_device_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_dev_no,
            this.ch_dev_ssid,
            this.ch_dev_mac,
            this.ch_dev_signal,
            this.ch_sig_chain,
            this.ch_rx_rate,
            this.ch_tx_rate});
			this.lv_device_list.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lv_device_list.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lv_device_list.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lv_device_list.FullRowSelect = true;
			this.lv_device_list.GridLines = true;
			this.lv_device_list.HideSelection = false;
			this.lv_device_list.Location = new System.Drawing.Point(3, 17);
			this.lv_device_list.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
			this.lv_device_list.Name = "lv_device_list";
			this.lv_device_list.Size = new System.Drawing.Size(629, 115);
			this.lv_device_list.TabIndex = 114;
			this.lv_device_list.UseCompatibleStateImageBehavior = false;
			this.lv_device_list.View = System.Windows.Forms.View.Details;
			// 
			// ch_dev_no
			// 
			this.ch_dev_no.Text = "No";
			this.ch_dev_no.Width = 0;
			// 
			// ch_dev_ssid
			// 
			this.ch_dev_ssid.Text = "SSID";
			this.ch_dev_ssid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ch_dev_mac
			// 
			this.ch_dev_mac.Text = "MAC Address";
			this.ch_dev_mac.Width = 120;
			// 
			// ch_dev_signal
			// 
			this.ch_dev_signal.Text = "Signal";
			this.ch_dev_signal.Width = 100;
			// 
			// ch_sig_chain
			// 
			this.ch_sig_chain.Text = "Signal Chain";
			this.ch_sig_chain.Width = 100;
			// 
			// ch_rx_rate
			// 
			this.ch_rx_rate.Text = "RX Rate";
			this.ch_rx_rate.Width = 100;
			// 
			// ch_tx_rate
			// 
			this.ch_tx_rate.Text = "TX Rate";
			this.ch_tx_rate.Width = 100;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(15, 451);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 30);
			this.button1.TabIndex = 153;
			this.button1.Text = "외부 파일로 저정";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tb_bitrate);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.tb_security);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.tb_frequency);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.tb_bssid);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.tb_ssid);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(12, 123);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(635, 125);
			this.groupBox1.TabIndex = 154;
			this.groupBox1.TabStop = false;
			// 
			// tb_used_memory
			// 
			this.tb_used_memory.Location = new System.Drawing.Point(118, 69);
			this.tb_used_memory.Name = "tb_used_memory";
			this.tb_used_memory.Size = new System.Drawing.Size(176, 21);
			this.tb_used_memory.TabIndex = 168;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(24, 74);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(81, 12);
			this.label7.TabIndex = 169;
			this.label7.Text = "메모리 사용량";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(15, 257);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(112, 30);
			this.button2.TabIndex = 155;
			this.button2.Text = "무선 1 상태정보";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(133, 257);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(112, 30);
			this.button3.TabIndex = 156;
			this.button3.Text = "무선 2 상태정보";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// tb_ssid
			// 
			this.tb_ssid.Location = new System.Drawing.Point(121, 52);
			this.tb_ssid.Name = "tb_ssid";
			this.tb_ssid.Size = new System.Drawing.Size(176, 21);
			this.tb_ssid.TabIndex = 176;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 57);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 12);
			this.label1.TabIndex = 177;
			this.label1.Text = "SSID";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(121, 20);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(176, 21);
			this.textBox2.TabIndex = 170;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(27, 25);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 12);
			this.label6.TabIndex = 174;
			this.label6.Text = "동작모드";
			// 
			// tb_bssid
			// 
			this.tb_bssid.Location = new System.Drawing.Point(432, 22);
			this.tb_bssid.Name = "tb_bssid";
			this.tb_bssid.Size = new System.Drawing.Size(176, 21);
			this.tb_bssid.TabIndex = 178;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(335, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 12);
			this.label4.TabIndex = 179;
			this.label4.Text = "BSSID";
			// 
			// tb_frequency
			// 
			this.tb_frequency.Location = new System.Drawing.Point(432, 52);
			this.tb_frequency.Name = "tb_frequency";
			this.tb_frequency.Size = new System.Drawing.Size(176, 21);
			this.tb_frequency.TabIndex = 180;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(335, 55);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(65, 12);
			this.label9.TabIndex = 181;
			this.label9.Text = "사용주파수";
			// 
			// tb_security
			// 
			this.tb_security.Location = new System.Drawing.Point(121, 85);
			this.tb_security.Name = "tb_security";
			this.tb_security.Size = new System.Drawing.Size(176, 21);
			this.tb_security.TabIndex = 182;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(27, 90);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(51, 12);
			this.label10.TabIndex = 183;
			this.label10.Text = "Security";
			// 
			// tb_bitrate
			// 
			this.tb_bitrate.Location = new System.Drawing.Point(432, 85);
			this.tb_bitrate.Name = "tb_bitrate";
			this.tb_bitrate.Size = new System.Drawing.Size(176, 21);
			this.tb_bitrate.TabIndex = 184;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(335, 88);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(40, 12);
			this.label11.TabIndex = 185;
			this.label11.Text = "Bitrate";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(133, 451);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(112, 30);
			this.button4.TabIndex = 157;
			this.button4.Text = "상태정보 저정";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(251, 451);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(112, 30);
			this.button5.TabIndex = 158;
			this.button5.Text = "정보저장 중지";
			this.button5.UseVisualStyleBackColor = true;
			// 
			// StatusWireless
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(670, 507);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.gb_wifi);
			this.Controls.Add(this.gb_switch);
			this.Controls.Add(this.tb_desc);
			this.Controls.Add(this.bt_close);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.bt_apply);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StatusWireless";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Wireless 상태정보 창";
			this.Load += new System.EventHandler(this.WirelessDialog_Load);
			this.gb_switch.ResumeLayout(false);
			this.gb_switch.PerformLayout();
			this.gb_wifi.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button bt_apply;
		private System.Windows.Forms.Button bt_close;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tb_desc;
		private System.Windows.Forms.GroupBox gb_switch;
		private System.Windows.Forms.GroupBox gb_wifi;
		private System.Windows.Forms.ListView lv_device_list;
		private System.Windows.Forms.ColumnHeader ch_dev_no;
		private System.Windows.Forms.ColumnHeader ch_dev_ssid;
		private System.Windows.Forms.ColumnHeader ch_dev_mac;
		private System.Windows.Forms.ColumnHeader ch_dev_signal;
		private System.Windows.Forms.ColumnHeader ch_sig_chain;
		private System.Windows.Forms.ColumnHeader ch_rx_rate;
		private System.Windows.Forms.ColumnHeader ch_tx_rate;
		private System.Windows.Forms.MaskedTextBox mtb_addr;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tb_system_nm;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tb_uptime;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tb_used_memory;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tb_security;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tb_frequency;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tb_bssid;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tb_ssid;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox tb_bitrate;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
	}
}