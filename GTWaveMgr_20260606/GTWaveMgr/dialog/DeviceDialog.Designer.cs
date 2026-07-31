namespace AnyBoBu.dialog {
	partial class DeviceDialog {
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
			this.cb_is_dumy = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bt_set_snmp = new System.Windows.Forms.Button();
			this.tb_group_nm = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tb_device_nm = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tb_check_port = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cb_system_kind = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.bt_close = new System.Windows.Forms.Button();
			this.cb_check_type = new System.Windows.Forms.ComboBox();
			this.cb_conn_type = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tb_conn_port = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tb_desc = new System.Windows.Forms.TextBox();
			this.gb_switch = new System.Windows.Forms.GroupBox();
			this.bt_switch = new System.Windows.Forms.Button();
			this.gb_wifi = new System.Windows.Forms.GroupBox();
			this.cb_is_snmp = new System.Windows.Forms.CheckBox();
			this.pb_system_image = new System.Windows.Forms.PictureBox();
			this.bt_switch_status = new System.Windows.Forms.Button();
			this.bt_delete = new System.Windows.Forms.Button();
			this.tb_addr = new System.Windows.Forms.TextBox();
			this.gb_switch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_system_image)).BeginInit();
			this.SuspendLayout();
			// 
			// bt_apply
			// 
			this.bt_apply.Location = new System.Drawing.Point(18, 397);
			this.bt_apply.Name = "bt_apply";
			this.bt_apply.Size = new System.Drawing.Size(88, 30);
			this.bt_apply.TabIndex = 0;
			this.bt_apply.Text = "적 용";
			this.bt_apply.UseVisualStyleBackColor = true;
			this.bt_apply.Click += new System.EventHandler(this.bt_apply_Click);
			// 
			// cb_is_dumy
			// 
			this.cb_is_dumy.AutoSize = true;
			this.cb_is_dumy.Font = new System.Drawing.Font("굴림", 9.75F);
			this.cb_is_dumy.Location = new System.Drawing.Point(130, 159);
			this.cb_is_dumy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cb_is_dumy.Name = "cb_is_dumy";
			this.cb_is_dumy.Size = new System.Drawing.Size(52, 17);
			this.cb_is_dumy.TabIndex = 5;
			this.cb_is_dumy.Text = "더미";
			this.cb_is_dumy.UseVisualStyleBackColor = true;
			this.cb_is_dumy.CheckedChanged += new System.EventHandler(this.cb_is_dumy_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(35, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 12);
			this.label1.TabIndex = 127;
			this.label1.Text = "시스템 종류";
			// 
			// bt_set_snmp
			// 
			this.bt_set_snmp.Location = new System.Drawing.Point(168, 246);
			this.bt_set_snmp.Name = "bt_set_snmp";
			this.bt_set_snmp.Size = new System.Drawing.Size(138, 23);
			this.bt_set_snmp.TabIndex = 129;
			this.bt_set_snmp.Text = "SNMP 세팅";
			this.bt_set_snmp.UseVisualStyleBackColor = true;
			this.bt_set_snmp.Click += new System.EventHandler(this.bt_set_snmp_Click);
			// 
			// tb_group_nm
			// 
			this.tb_group_nm.Enabled = false;
			this.tb_group_nm.Location = new System.Drawing.Point(130, 130);
			this.tb_group_nm.Name = "tb_group_nm";
			this.tb_group_nm.Size = new System.Drawing.Size(176, 21);
			this.tb_group_nm.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(36, 135);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 130;
			this.label2.Text = "그룹명";
			// 
			// tb_device_nm
			// 
			this.tb_device_nm.Location = new System.Drawing.Point(129, 24);
			this.tb_device_nm.Name = "tb_device_nm";
			this.tb_device_nm.Size = new System.Drawing.Size(176, 21);
			this.tb_device_nm.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(35, 29);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 12);
			this.label3.TabIndex = 132;
			this.label3.Text = "장비 이름";
			// 
			// tb_check_port
			// 
			this.tb_check_port.Location = new System.Drawing.Point(253, 183);
			this.tb_check_port.Name = "tb_check_port";
			this.tb_check_port.Size = new System.Drawing.Size(53, 21);
			this.tb_check_port.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(36, 188);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 12);
			this.label4.TabIndex = 134;
			this.label4.Text = "장비 체크";
			// 
			// cb_system_kind
			// 
			this.cb_system_kind.FormattingEnabled = true;
			this.cb_system_kind.Items.AddRange(new object[] {
            "사용자",
            "관리자"});
			this.cb_system_kind.Location = new System.Drawing.Point(129, 51);
			this.cb_system_kind.Name = "cb_system_kind";
			this.cb_system_kind.Size = new System.Drawing.Size(94, 20);
			this.cb_system_kind.TabIndex = 3;
			this.cb_system_kind.Text = "사용자";
			this.cb_system_kind.SelectedIndexChanged += new System.EventHandler(this.cb_system_kind_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(36, 161);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 12);
			this.label5.TabIndex = 137;
			this.label5.Text = "IP 주소";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(221, 189);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(29, 12);
			this.label6.TabIndex = 138;
			this.label6.Text = "포트";
			// 
			// bt_close
			// 
			this.bt_close.Location = new System.Drawing.Point(217, 397);
			this.bt_close.Name = "bt_close";
			this.bt_close.Size = new System.Drawing.Size(88, 30);
			this.bt_close.TabIndex = 1;
			this.bt_close.Text = "닫 기";
			this.bt_close.UseVisualStyleBackColor = true;
			this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
			// 
			// cb_check_type
			// 
			this.cb_check_type.FormattingEnabled = true;
			this.cb_check_type.Items.AddRange(new object[] {
            "Ping",
            "tcping"});
			this.cb_check_type.Location = new System.Drawing.Point(130, 185);
			this.cb_check_type.Name = "cb_check_type";
			this.cb_check_type.Size = new System.Drawing.Size(67, 20);
			this.cb_check_type.TabIndex = 7;
			// 
			// cb_conn_type
			// 
			this.cb_conn_type.FormattingEnabled = true;
			this.cb_conn_type.Items.AddRange(new object[] {
            "http",
            "https"});
			this.cb_conn_type.Location = new System.Drawing.Point(130, 211);
			this.cb_conn_type.Name = "cb_conn_type";
			this.cb_conn_type.Size = new System.Drawing.Size(67, 20);
			this.cb_conn_type.TabIndex = 9;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(221, 215);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(29, 12);
			this.label9.TabIndex = 151;
			this.label9.Text = "포트";
			// 
			// tb_conn_port
			// 
			this.tb_conn_port.Location = new System.Drawing.Point(253, 209);
			this.tb_conn_port.Name = "tb_conn_port";
			this.tb_conn_port.Size = new System.Drawing.Size(53, 21);
			this.tb_conn_port.TabIndex = 11;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(36, 214);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(69, 12);
			this.label10.TabIndex = 149;
			this.label10.Text = "시스템 접속";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(33, 341);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(57, 12);
			this.label8.TabIndex = 142;
			this.label8.Text = "장비 설명";
			// 
			// tb_desc
			// 
			this.tb_desc.Location = new System.Drawing.Point(118, 338);
			this.tb_desc.Multiline = true;
			this.tb_desc.Name = "tb_desc";
			this.tb_desc.Size = new System.Drawing.Size(188, 53);
			this.tb_desc.TabIndex = 12;
			// 
			// gb_switch
			// 
			this.gb_switch.Controls.Add(this.bt_switch);
			this.gb_switch.Location = new System.Drawing.Point(168, 278);
			this.gb_switch.Name = "gb_switch";
			this.gb_switch.Size = new System.Drawing.Size(157, 54);
			this.gb_switch.TabIndex = 103;
			this.gb_switch.TabStop = false;
			this.gb_switch.Text = "스위치 인터페이스 설정";
			// 
			// bt_switch
			// 
			this.bt_switch.Location = new System.Drawing.Point(20, 21);
			this.bt_switch.Name = "bt_switch";
			this.bt_switch.Size = new System.Drawing.Size(101, 23);
			this.bt_switch.TabIndex = 0;
			this.bt_switch.Text = "스위치 설정";
			this.bt_switch.UseVisualStyleBackColor = true;
			this.bt_switch.Click += new System.EventHandler(this.bt_switch_Click);
			// 
			// gb_wifi
			// 
			this.gb_wifi.Location = new System.Drawing.Point(18, 278);
			this.gb_wifi.Name = "gb_wifi";
			this.gb_wifi.Size = new System.Drawing.Size(144, 54);
			this.gb_wifi.TabIndex = 104;
			this.gb_wifi.TabStop = false;
			this.gb_wifi.Text = "무선 시스템 설정";
			// 
			// cb_is_snmp
			// 
			this.cb_is_snmp.AutoSize = true;
			this.cb_is_snmp.Location = new System.Drawing.Point(38, 250);
			this.cb_is_snmp.Name = "cb_is_snmp";
			this.cb_is_snmp.Size = new System.Drawing.Size(112, 16);
			this.cb_is_snmp.TabIndex = 152;
			this.cb_is_snmp.Text = "SNMP 지원여부";
			this.cb_is_snmp.UseVisualStyleBackColor = true;
			this.cb_is_snmp.CheckedChanged += new System.EventHandler(this.cb_is_snmp_CheckedChanged);
			// 
			// pb_system_image
			// 
			this.pb_system_image.Location = new System.Drawing.Point(229, 53);
			this.pb_system_image.Name = "pb_system_image";
			this.pb_system_image.Size = new System.Drawing.Size(76, 71);
			this.pb_system_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pb_system_image.TabIndex = 153;
			this.pb_system_image.TabStop = false;
			// 
			// bt_switch_status
			// 
			this.bt_switch_status.Location = new System.Drawing.Point(18, 361);
			this.bt_switch_status.Name = "bt_switch_status";
			this.bt_switch_status.Size = new System.Drawing.Size(88, 30);
			this.bt_switch_status.TabIndex = 154;
			this.bt_switch_status.Text = "상태보기";
			this.bt_switch_status.UseVisualStyleBackColor = true;
			this.bt_switch_status.Click += new System.EventHandler(this.bt_switch_status_Click);
			// 
			// bt_delete
			// 
			this.bt_delete.Location = new System.Drawing.Point(118, 397);
			this.bt_delete.Name = "bt_delete";
			this.bt_delete.Size = new System.Drawing.Size(88, 30);
			this.bt_delete.TabIndex = 155;
			this.bt_delete.Text = "장치 삭제";
			this.bt_delete.UseVisualStyleBackColor = true;
			this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
			// 
			// tb_addr
			// 
			this.tb_addr.Enabled = false;
			this.tb_addr.Location = new System.Drawing.Point(181, 156);
			this.tb_addr.Name = "tb_addr";
			this.tb_addr.Size = new System.Drawing.Size(124, 21);
			this.tb_addr.TabIndex = 6;
			// 
			// DeviceDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 447);
			this.Controls.Add(this.tb_addr);
			this.Controls.Add(this.bt_delete);
			this.Controls.Add(this.bt_switch_status);
			this.Controls.Add(this.pb_system_image);
			this.Controls.Add(this.cb_is_snmp);
			this.Controls.Add(this.gb_wifi);
			this.Controls.Add(this.gb_switch);
			this.Controls.Add(this.tb_desc);
			this.Controls.Add(this.cb_conn_type);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.tb_conn_port);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.cb_check_type);
			this.Controls.Add(this.bt_close);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cb_system_kind);
			this.Controls.Add(this.tb_check_port);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tb_device_nm);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tb_group_nm);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.bt_set_snmp);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cb_is_dumy);
			this.Controls.Add(this.bt_apply);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DeviceDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Device 정보 창";
			this.Load += new System.EventHandler(this.DeviceDialog_Load);
			this.Shown += new System.EventHandler(this.DeviceDialog_Shown);
			this.gb_switch.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pb_system_image)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button bt_apply;
		private System.Windows.Forms.CheckBox cb_is_dumy;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bt_set_snmp;
		private System.Windows.Forms.TextBox tb_group_nm;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tb_device_nm;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tb_check_port;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cb_system_kind;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button bt_close;
		private System.Windows.Forms.ComboBox cb_check_type;
		private System.Windows.Forms.ComboBox cb_conn_type;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tb_conn_port;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tb_desc;
		private System.Windows.Forms.GroupBox gb_switch;
		private System.Windows.Forms.GroupBox gb_wifi;
		private System.Windows.Forms.CheckBox cb_is_snmp;
		private System.Windows.Forms.PictureBox pb_system_image;
		private System.Windows.Forms.Button bt_switch;
		private System.Windows.Forms.Button bt_switch_status;
		private System.Windows.Forms.Button bt_delete;
		private System.Windows.Forms.TextBox tb_addr;
	}
}