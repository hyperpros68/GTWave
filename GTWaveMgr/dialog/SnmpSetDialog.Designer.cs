namespace AnyBoBu.dialog {
	partial class SnmpSetDialog {
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
			this.label1 = new System.Windows.Forms.Label();
			this.tb_snmp_port = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cb_verion = new System.Windows.Forms.ComboBox();
			this.bt_close = new System.Windows.Forms.Button();
			this.gb_snmp = new System.Windows.Forms.GroupBox();
			this.bt_oid_list = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.tb_desc = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tb_v2c_write = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tb_v2c_read = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tb_v3_user = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.cb_v3_auth_alg = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.tb_v3_auth_pw = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cb_v3_pri_alg = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tb_v3_pri_pw = new System.Windows.Forms.TextBox();
			this.gb_snmp.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// bt_apply
			// 
			this.bt_apply.Location = new System.Drawing.Point(129, 548);
			this.bt_apply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.bt_apply.Name = "bt_apply";
			this.bt_apply.Size = new System.Drawing.Size(101, 38);
			this.bt_apply.TabIndex = 15;
			this.bt_apply.Text = "적 용";
			this.bt_apply.UseVisualStyleBackColor = true;
			this.bt_apply.Click += new System.EventHandler(this.bt_apply_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 15);
			this.label1.TabIndex = 127;
			this.label1.Text = "Version";
			// 
			// tb_snmp_port
			// 
			this.tb_snmp_port.Location = new System.Drawing.Point(137, 14);
			this.tb_snmp_port.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tb_snmp_port.Name = "tb_snmp_port";
			this.tb_snmp_port.Size = new System.Drawing.Size(78, 25);
			this.tb_snmp_port.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(30, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 15);
			this.label3.TabIndex = 132;
			this.label3.Text = "SNMP 포트";
			// 
			// cb_verion
			// 
			this.cb_verion.FormattingEnabled = true;
			this.cb_verion.Items.AddRange(new object[] {
            "１",
            "v2c",
            "３"});
			this.cb_verion.Location = new System.Drawing.Point(137, 48);
			this.cb_verion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cb_verion.Name = "cb_verion";
			this.cb_verion.Size = new System.Drawing.Size(78, 23);
			this.cb_verion.TabIndex = 3;
			this.cb_verion.Text = "v2c";
			// 
			// bt_close
			// 
			this.bt_close.Location = new System.Drawing.Point(242, 548);
			this.bt_close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.bt_close.Name = "bt_close";
			this.bt_close.Size = new System.Drawing.Size(101, 38);
			this.bt_close.TabIndex = 16;
			this.bt_close.Text = "닫 기";
			this.bt_close.UseVisualStyleBackColor = true;
			this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
			// 
			// gb_snmp
			// 
			this.gb_snmp.Controls.Add(this.bt_oid_list);
			this.gb_snmp.Location = new System.Drawing.Point(33, 352);
			this.gb_snmp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gb_snmp.Name = "gb_snmp";
			this.gb_snmp.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gb_snmp.Size = new System.Drawing.Size(314, 74);
			this.gb_snmp.TabIndex = 101;
			this.gb_snmp.TabStop = false;
			this.gb_snmp.Text = "OID";
			// 
			// bt_oid_list
			// 
			this.bt_oid_list.Location = new System.Drawing.Point(7, 25);
			this.bt_oid_list.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.bt_oid_list.Name = "bt_oid_list";
			this.bt_oid_list.Size = new System.Drawing.Size(298, 38);
			this.bt_oid_list.TabIndex = 13;
			this.bt_oid_list.Text = "OID 목록 확인";
			this.bt_oid_list.UseVisualStyleBackColor = true;
			this.bt_oid_list.Click += new System.EventHandler(this.bt_oid_list_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(30, 436);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(83, 15);
			this.label8.TabIndex = 142;
			this.label8.Text = "SNMP 설명";
			// 
			// tb_desc
			// 
			this.tb_desc.Location = new System.Drawing.Point(33, 460);
			this.tb_desc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tb_desc.Multiline = true;
			this.tb_desc.Name = "tb_desc";
			this.tb_desc.Size = new System.Drawing.Size(306, 65);
			this.tb_desc.TabIndex = 14;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tb_v2c_write);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.tb_v2c_read);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(23, 80);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Size = new System.Drawing.Size(325, 89);
			this.groupBox1.TabIndex = 153;
			this.groupBox1.TabStop = false;
			// 
			// tb_v2c_write
			// 
			this.tb_v2c_write.Location = new System.Drawing.Point(215, 49);
			this.tb_v2c_write.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tb_v2c_write.Name = "tb_v2c_write";
			this.tb_v2c_write.Size = new System.Drawing.Size(101, 25);
			this.tb_v2c_write.TabIndex = 5;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(8, 55);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(146, 15);
			this.label7.TabIndex = 134;
			this.label7.Text = "v2c Write Community";
			// 
			// tb_v2c_read
			// 
			this.tb_v2c_read.Location = new System.Drawing.Point(215, 16);
			this.tb_v2c_read.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tb_v2c_read.Name = "tb_v2c_read";
			this.tb_v2c_read.Size = new System.Drawing.Size(101, 25);
			this.tb_v2c_read.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(147, 15);
			this.label2.TabIndex = 132;
			this.label2.Text = "v2c Read Community";
			// 
			// tb_v3_user
			// 
			this.tb_v3_user.Location = new System.Drawing.Point(223, 175);
			this.tb_v3_user.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tb_v3_user.Name = "tb_v3_user";
			this.tb_v3_user.Size = new System.Drawing.Size(115, 25);
			this.tb_v3_user.TabIndex = 6;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(30, 181);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(139, 15);
			this.label11.TabIndex = 155;
			this.label11.Text = "SNMP V3 Username";
			// 
			// cb_v3_auth_alg
			// 
			this.cb_v3_auth_alg.FormattingEnabled = true;
			this.cb_v3_auth_alg.Items.AddRange(new object[] {
            "MD5",
            "SHA",
            "SHA224",
            "SHA256",
            "SHA384",
            "SHA512"});
			this.cb_v3_auth_alg.Location = new System.Drawing.Point(223, 208);
			this.cb_v3_auth_alg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cb_v3_auth_alg.Name = "cb_v3_auth_alg";
			this.cb_v3_auth_alg.Size = new System.Drawing.Size(116, 23);
			this.cb_v3_auth_alg.TabIndex = 7;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(31, 214);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(167, 15);
			this.label12.TabIndex = 157;
			this.label12.Text = "SNMP V3 Auth Algorithm";
			// 
			// tb_v3_auth_pw
			// 
			this.tb_v3_auth_pw.Location = new System.Drawing.Point(223, 241);
			this.tb_v3_auth_pw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tb_v3_auth_pw.Name = "tb_v3_auth_pw";
			this.tb_v3_auth_pw.Size = new System.Drawing.Size(116, 25);
			this.tb_v3_auth_pw.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(31, 248);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(173, 15);
			this.label4.TabIndex = 159;
			this.label4.Text = "SNMP V3 Auth Password";
			// 
			// cb_v3_pri_alg
			// 
			this.cb_v3_pri_alg.FormattingEnabled = true;
			this.cb_v3_pri_alg.Items.AddRange(new object[] {
            "DES",
            "AES",
            "AES192",
            "AES256",
            "3DES"});
			this.cb_v3_pri_alg.Location = new System.Drawing.Point(223, 276);
			this.cb_v3_pri_alg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cb_v3_pri_alg.Name = "cb_v3_pri_alg";
			this.cb_v3_pri_alg.Size = new System.Drawing.Size(116, 23);
			this.cb_v3_pri_alg.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(31, 282);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(187, 15);
			this.label5.TabIndex = 161;
			this.label5.Text = "SNMP V3 Privacy Algorithm";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(31, 319);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(193, 15);
			this.label6.TabIndex = 163;
			this.label6.Text = "SNMP V3 Privacy Password";
			// 
			// tb_v3_pri_pw
			// 
			this.tb_v3_pri_pw.Location = new System.Drawing.Point(223, 312);
			this.tb_v3_pri_pw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tb_v3_pri_pw.Name = "tb_v3_pri_pw";
			this.tb_v3_pri_pw.Size = new System.Drawing.Size(116, 25);
			this.tb_v3_pri_pw.TabIndex = 10;
			// 
			// SnmpSetDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(377, 598);
			this.Controls.Add(this.tb_v3_pri_pw);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.cb_v3_pri_alg);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tb_v3_auth_pw);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cb_v3_auth_alg);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.tb_v3_user);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tb_desc);
			this.Controls.Add(this.gb_snmp);
			this.Controls.Add(this.bt_close);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.cb_verion);
			this.Controls.Add(this.tb_snmp_port);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bt_apply);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SnmpSetDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SNMP 설정";
			this.Load += new System.EventHandler(this.SnmpSetDialog_Load);
			this.gb_snmp.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button bt_apply;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tb_snmp_port;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cb_verion;
		private System.Windows.Forms.Button bt_close;
		private System.Windows.Forms.GroupBox gb_snmp;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tb_desc;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tb_v2c_write;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tb_v2c_read;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tb_v3_user;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox cb_v3_auth_alg;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tb_v3_auth_pw;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cb_v3_pri_alg;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button bt_oid_list;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tb_v3_pri_pw;
	}
}