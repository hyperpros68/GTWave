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
			this.cb_group_nm = new System.Windows.Forms.ComboBox();
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
			this.pb_system_image = new System.Windows.Forms.PictureBox();
			this.bt_switch_status = new System.Windows.Forms.Button();
			this.bt_delete = new System.Windows.Forms.Button();
			this.tb_addr = new System.Windows.Forms.TextBox();
			this.bt_set_snmp = new System.Windows.Forms.Button();
			this.rb_json = new System.Windows.Forms.RadioButton();
			this.rb_snmp = new System.Windows.Forms.RadioButton();
			this.gb_switch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_system_image)).BeginInit();
			this.SuspendLayout();
			// 
			// bt_apply
			// 
			this.bt_apply.Location = new System.Drawing.Point(21, 496);
			this.bt_apply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.bt_apply.Name = "bt_apply";
			this.bt_apply.Size = new System.Drawing.Size(101, 38);
			this.bt_apply.TabIndex = 0;
			this.bt_apply.Text = "적 용";
			this.bt_apply.UseVisualStyleBackColor = true;
			this.bt_apply.Click += new System.EventHandler(this.bt_apply_Click);
			// 
			// cb_is_dumy
			// 
			this.cb_is_dumy.AutoSize = true;
			this.cb_is_dumy.Font = new System.Drawing.Font("굴림", 9.75F);
			this.cb_is_dumy.Location = new System.Drawing.Point(149, 199);
			this.cb_is_dumy.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cb_is_dumy.Name = "cb_is_dumy";
			this.cb_is_dumy.Size = new System.Drawing.Size(64, 21);
			this.cb_is_dumy.TabIndex = 5;
			this.cb_is_dumy.Text = "더미";
			this.cb_is_dumy.UseVisualStyleBackColor = true;
			this.cb_is_dumy.CheckedChanged += new System.EventHandler(this.cb_is_dumy_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(40, 70);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 15);
			this.label1.TabIndex = 127;
			this.label1.Text = "시스템 종류";
			// 
			// cb_group_nm
			// 
			this.cb_group_nm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_group_nm.FormattingEnabled = true;
			this.cb_group_nm.Location = new System.Drawing.Point(149, 162);
			this.cb_group_nm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cb_group_nm.Name = "cb_group_nm";
			this.cb_group_nm.Size = new System.Drawing.Size(201, 23);
			this.cb_group_nm.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(41, 169);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 15);
			this.label2.TabIndex = 130;
			this.label2.Text = "그룹명";
			// 
			// tb_device_nm
			// 
			this.tb_device_nm.Location = new System.Drawing.Point(147, 30);
			this.tb_device_nm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tb_device_nm.Name = "tb_device_nm";
			this.tb_device_nm.Size = new System.Drawing.Size(201, 25);
			this.tb_device_nm.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(40, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 15);
			this.label3.TabIndex = 132;
			this.label3.Text = "장비 이름";
			// 
			// tb_check_port
			// 
			this.tb_check_port.Location = new System.Drawing.Point(289, 229);
			this.tb_check_port.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tb_check_port.Name = "tb_check_port";
			this.tb_check_port.Size = new System.Drawing.Size(60, 25);
			this.tb_check_port.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(41, 235);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 15);
			this.label4.TabIndex = 134;
			this.label4.Text = "장비 체크";
			// 
			// cb_system_kind
			// 
			this.cb_system_kind.FormattingEnabled = true;
			this.cb_system_kind.Items.AddRange(new object[] {
            "사용자",
            "관리자"});
			this.cb_system_kind.Location = new System.Drawing.Point(147, 64);
			this.cb_system_kind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cb_system_kind.Name = "cb_system_kind";
			this.cb_system_kind.Size = new System.Drawing.Size(107, 23);
			this.cb_system_kind.TabIndex = 3;
			this.cb_system_kind.Text = "사용자";
			this.cb_system_kind.SelectedIndexChanged += new System.EventHandler(this.cb_system_kind_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(41, 201);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 15);
			this.label5.TabIndex = 137;
			this.label5.Text = "IP 주소";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(253, 236);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 15);
			this.label6.TabIndex = 138;
			this.label6.Text = "포트";
			// 
			// bt_close
			// 
			this.bt_close.Location = new System.Drawing.Point(248, 496);
			this.bt_close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.bt_close.Name = "bt_close";
			this.bt_close.Size = new System.Drawing.Size(101, 38);
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
			this.cb_check_type.Location = new System.Drawing.Point(149, 231);
			this.cb_check_type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cb_check_type.Name = "cb_check_type";
			this.cb_check_type.Size = new System.Drawing.Size(76, 23);
			this.cb_check_type.TabIndex = 7;
			// 
			// cb_conn_type
			// 
			this.cb_conn_type.FormattingEnabled = true;
			this.cb_conn_type.Items.AddRange(new object[] {
            "http",
            "https"});
			this.cb_conn_type.Location = new System.Drawing.Point(149, 264);
			this.cb_conn_type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cb_conn_type.Name = "cb_conn_type";
			this.cb_conn_type.Size = new System.Drawing.Size(76, 23);
			this.cb_conn_type.TabIndex = 9;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(253, 269);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(37, 15);
			this.label9.TabIndex = 151;
			this.label9.Text = "포트";
			// 
			// tb_conn_port
			// 
			this.tb_conn_port.Location = new System.Drawing.Point(289, 261);
			this.tb_conn_port.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tb_conn_port.Name = "tb_conn_port";
			this.tb_conn_port.Size = new System.Drawing.Size(60, 25);
			this.tb_conn_port.TabIndex = 11;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(41, 268);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(87, 15);
			this.label10.TabIndex = 149;
			this.label10.Text = "시스템 접속";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(38, 426);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 15);
			this.label8.TabIndex = 142;
			this.label8.Text = "장비 설명";
			// 
			// tb_desc
			// 
			this.tb_desc.Location = new System.Drawing.Point(135, 422);
			this.tb_desc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tb_desc.Multiline = true;
			this.tb_desc.Name = "tb_desc";
			this.tb_desc.Size = new System.Drawing.Size(214, 65);
			this.tb_desc.TabIndex = 12;
			// 
			// gb_switch
			// 
			this.gb_switch.Controls.Add(this.bt_set_snmp);
			this.gb_switch.Controls.Add(this.bt_switch);
			this.gb_switch.Location = new System.Drawing.Point(41, 339);
			this.gb_switch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gb_switch.Name = "gb_switch";
			this.gb_switch.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gb_switch.Size = new System.Drawing.Size(307, 75);
			this.gb_switch.TabIndex = 103;
			this.gb_switch.TabStop = false;
			this.gb_switch.Text = "인터페이스 설정";
			// 
			// bt_switch
			// 
			this.bt_switch.Location = new System.Drawing.Point(17, 31);
			this.bt_switch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.bt_switch.Name = "bt_switch";
			this.bt_switch.Size = new System.Drawing.Size(113, 29);
			this.bt_switch.TabIndex = 0;
			this.bt_switch.Text = "스위치 설정";
			this.bt_switch.UseVisualStyleBackColor = true;
			this.bt_switch.Click += new System.EventHandler(this.bt_switch_Click);
			// 
			// pb_system_image
			// 
			this.pb_system_image.Location = new System.Drawing.Point(262, 66);
			this.pb_system_image.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pb_system_image.Name = "pb_system_image";
			this.pb_system_image.Size = new System.Drawing.Size(87, 89);
			this.pb_system_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pb_system_image.TabIndex = 153;
			this.pb_system_image.TabStop = false;
			// 
			// bt_switch_status
			// 
			this.bt_switch_status.Location = new System.Drawing.Point(21, 451);
			this.bt_switch_status.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.bt_switch_status.Name = "bt_switch_status";
			this.bt_switch_status.Size = new System.Drawing.Size(101, 38);
			this.bt_switch_status.TabIndex = 154;
			this.bt_switch_status.Text = "상태보기";
			this.bt_switch_status.UseVisualStyleBackColor = true;
			this.bt_switch_status.Click += new System.EventHandler(this.bt_switch_status_Click);
			// 
			// bt_delete
			// 
			this.bt_delete.Location = new System.Drawing.Point(135, 496);
			this.bt_delete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.bt_delete.Name = "bt_delete";
			this.bt_delete.Size = new System.Drawing.Size(101, 38);
			this.bt_delete.TabIndex = 155;
			this.bt_delete.Text = "장치 삭제";
			this.bt_delete.UseVisualStyleBackColor = true;
			this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
			// 
			// tb_addr
			// 
			this.tb_addr.Enabled = false;
			this.tb_addr.Location = new System.Drawing.Point(207, 195);
			this.tb_addr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tb_addr.Name = "tb_addr";
			this.tb_addr.Size = new System.Drawing.Size(141, 25);
			this.tb_addr.TabIndex = 6;
			// 
			// bt_set_snmp
			// 
			this.bt_set_snmp.Location = new System.Drawing.Point(159, 32);
			this.bt_set_snmp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.bt_set_snmp.Name = "bt_set_snmp";
			this.bt_set_snmp.Size = new System.Drawing.Size(122, 29);
			this.bt_set_snmp.TabIndex = 130;
			this.bt_set_snmp.Text = "SNMP 세팅";
			this.bt_set_snmp.UseVisualStyleBackColor = true;
			this.bt_set_snmp.Click += new System.EventHandler(this.bt_set_snmp_Click);
			// 
			// rb_json
			// 
			this.rb_json.AutoSize = true;
			this.rb_json.Location = new System.Drawing.Point(43, 313);
			this.rb_json.Name = "rb_json";
			this.rb_json.Size = new System.Drawing.Size(65, 19);
			this.rb_json.TabIndex = 156;
			this.rb_json.Text = "JSON";
			this.rb_json.UseVisualStyleBackColor = true;
			// 
			// rb_snmp
			// 
			this.rb_snmp.AutoSize = true;
			this.rb_snmp.Checked = true;
			this.rb_snmp.Location = new System.Drawing.Point(120, 313);
			this.rb_snmp.Name = "rb_snmp";
			this.rb_snmp.Size = new System.Drawing.Size(69, 19);
			this.rb_snmp.TabIndex = 157;
			this.rb_snmp.TabStop = true;
			this.rb_snmp.Text = "SNMP";
			this.rb_snmp.UseVisualStyleBackColor = true;
			this.rb_snmp.CheckedChanged += new System.EventHandler(this.rb_snmp_CheckedChanged);
			// 
			// DeviceDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(382, 559);
			this.Controls.Add(this.rb_snmp);
			this.Controls.Add(this.rb_json);
			this.Controls.Add(this.tb_addr);
			this.Controls.Add(this.bt_delete);
			this.Controls.Add(this.bt_switch_status);
			this.Controls.Add(this.pb_system_image);
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
			this.Controls.Add(this.cb_group_nm);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cb_is_dumy);
			this.Controls.Add(this.bt_apply);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
		private System.Windows.Forms.ComboBox cb_group_nm;
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
		private System.Windows.Forms.PictureBox pb_system_image;
		private System.Windows.Forms.Button bt_switch;
		private System.Windows.Forms.Button bt_switch_status;
		private System.Windows.Forms.Button bt_delete;
		private System.Windows.Forms.TextBox tb_addr;
		private System.Windows.Forms.Button bt_set_snmp;
		private System.Windows.Forms.RadioButton rb_json;
		private System.Windows.Forms.RadioButton rb_snmp;
	}
}