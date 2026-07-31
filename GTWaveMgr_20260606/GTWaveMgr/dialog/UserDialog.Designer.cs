namespace AnyBoBu.dialog {
	partial class UserDialog {
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
			this.bt_cancel = new System.Windows.Forms.Button();
			this.bt_ok = new System.Windows.Forms.Button();
			this.cb_valid = new System.Windows.Forms.CheckBox();
			this.lv_user_list = new System.Windows.Forms.ListView();
			this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_level = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cb_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cb_tel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cb_email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cb_desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_bigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label1 = new System.Windows.Forms.Label();
			this.tb_user_id = new System.Windows.Forms.TextBox();
			this.bt_dup_ck = new System.Windows.Forms.Button();
			this.tb_user_pw = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tb_user_pw2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tb_user_nm = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cb_user_level = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tb_user_tel = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tb_email = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tb_desc = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.bt_user_del = new System.Windows.Forms.Button();
			this.bt_user_add = new System.Windows.Forms.Button();
			this.bt_close = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// bt_cancel
			// 
			this.bt_cancel.Location = new System.Drawing.Point(402, 211);
			this.bt_cancel.Name = "bt_cancel";
			this.bt_cancel.Size = new System.Drawing.Size(88, 30);
			this.bt_cancel.TabIndex = 9;
			this.bt_cancel.Text = "취 소";
			this.bt_cancel.UseVisualStyleBackColor = true;
			this.bt_cancel.Click += new System.EventHandler(this.bt_close_Click);
			// 
			// bt_ok
			// 
			this.bt_ok.Location = new System.Drawing.Point(402, 171);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.Size = new System.Drawing.Size(88, 30);
			this.bt_ok.TabIndex = 8;
			this.bt_ok.Text = "적 용";
			this.bt_ok.UseVisualStyleBackColor = true;
			this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
			// 
			// cb_valid
			// 
			this.cb_valid.AutoSize = true;
			this.cb_valid.Font = new System.Drawing.Font("굴림", 9.75F);
			this.cb_valid.Location = new System.Drawing.Point(408, 139);
			this.cb_valid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cb_valid.Name = "cb_valid";
			this.cb_valid.Size = new System.Drawing.Size(56, 17);
			this.cb_valid.TabIndex = 122;
			this.cb_valid.Text = "Vaild";
			this.cb_valid.UseVisualStyleBackColor = true;
			// 
			// lv_user_list
			// 
			this.lv_user_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lv_user_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lv_user_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lv_user_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader20,
            this.ch_id,
            this.ch_level,
            this.cb_name,
            this.cb_tel,
            this.cb_email,
            this.cb_desc,
            this.ch_bigo});
			this.lv_user_list.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lv_user_list.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lv_user_list.FullRowSelect = true;
			this.lv_user_list.GridLines = true;
			this.lv_user_list.HideSelection = false;
			this.lv_user_list.Location = new System.Drawing.Point(13, 267);
			this.lv_user_list.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.lv_user_list.Name = "lv_user_list";
			this.lv_user_list.Size = new System.Drawing.Size(489, 154);
			this.lv_user_list.TabIndex = 126;
			this.lv_user_list.UseCompatibleStateImageBehavior = false;
			this.lv_user_list.View = System.Windows.Forms.View.Details;
			this.lv_user_list.SelectedIndexChanged += new System.EventHandler(this.lv_user_list_SelectedIndexChanged);
			// 
			// columnHeader20
			// 
			this.columnHeader20.Text = "No";
			this.columnHeader20.Width = 28;
			// 
			// ch_id
			// 
			this.ch_id.Text = "아이디";
			this.ch_id.Width = 80;
			// 
			// ch_level
			// 
			this.ch_level.Text = "권 한";
			this.ch_level.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// cb_name
			// 
			this.cb_name.Text = "이 름";
			// 
			// cb_tel
			// 
			this.cb_tel.Text = "연락처";
			// 
			// cb_email
			// 
			this.cb_email.Text = "이메일";
			this.cb_email.Width = 80;
			// 
			// cb_desc
			// 
			this.cb_desc.Text = "설 명";
			this.cb_desc.Width = 80;
			// 
			// ch_bigo
			// 
			this.ch_bigo.Text = "비 고";
			this.ch_bigo.Width = 200;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(54, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 12);
			this.label1.TabIndex = 127;
			this.label1.Text = "사용자 아이디";
			// 
			// tb_user_id
			// 
			this.tb_user_id.Location = new System.Drawing.Point(141, 32);
			this.tb_user_id.Name = "tb_user_id";
			this.tb_user_id.Size = new System.Drawing.Size(176, 21);
			this.tb_user_id.TabIndex = 128;
			// 
			// bt_dup_ck
			// 
			this.bt_dup_ck.Location = new System.Drawing.Point(323, 32);
			this.bt_dup_ck.Name = "bt_dup_ck";
			this.bt_dup_ck.Size = new System.Drawing.Size(75, 23);
			this.bt_dup_ck.TabIndex = 129;
			this.bt_dup_ck.Text = "중복 체크";
			this.bt_dup_ck.UseVisualStyleBackColor = true;
			this.bt_dup_ck.Click += new System.EventHandler(this.bt_dup_ck_Click);
			// 
			// tb_user_pw
			// 
			this.tb_user_pw.Location = new System.Drawing.Point(141, 59);
			this.tb_user_pw.Name = "tb_user_pw";
			this.tb_user_pw.PasswordChar = '*';
			this.tb_user_pw.Size = new System.Drawing.Size(176, 21);
			this.tb_user_pw.TabIndex = 131;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(54, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 130;
			this.label2.Text = "패스워드";
			// 
			// tb_user_pw2
			// 
			this.tb_user_pw2.Location = new System.Drawing.Point(141, 86);
			this.tb_user_pw2.Name = "tb_user_pw2";
			this.tb_user_pw2.PasswordChar = '*';
			this.tb_user_pw2.Size = new System.Drawing.Size(176, 21);
			this.tb_user_pw2.TabIndex = 133;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(54, 91);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 12);
			this.label3.TabIndex = 132;
			this.label3.Text = "패스워드 확인";
			// 
			// tb_user_nm
			// 
			this.tb_user_nm.Location = new System.Drawing.Point(141, 139);
			this.tb_user_nm.Name = "tb_user_nm";
			this.tb_user_nm.Size = new System.Drawing.Size(176, 21);
			this.tb_user_nm.TabIndex = 135;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(54, 144);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 12);
			this.label4.TabIndex = 134;
			this.label4.Text = "사용자 이름";
			// 
			// cb_user_level
			// 
			this.cb_user_level.FormattingEnabled = true;
			this.cb_user_level.Items.AddRange(new object[] {
            "사용자",
            "관리자"});
			this.cb_user_level.Location = new System.Drawing.Point(141, 113);
			this.cb_user_level.Name = "cb_user_level";
			this.cb_user_level.Size = new System.Drawing.Size(176, 20);
			this.cb_user_level.TabIndex = 136;
			this.cb_user_level.Text = "사용자";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(54, 117);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(33, 12);
			this.label5.TabIndex = 137;
			this.label5.Text = "권 한";
			// 
			// tb_user_tel
			// 
			this.tb_user_tel.Location = new System.Drawing.Point(141, 166);
			this.tb_user_tel.Name = "tb_user_tel";
			this.tb_user_tel.Size = new System.Drawing.Size(176, 21);
			this.tb_user_tel.TabIndex = 139;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(54, 171);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(81, 12);
			this.label6.TabIndex = 138;
			this.label6.Text = "사용자 연락처";
			// 
			// tb_email
			// 
			this.tb_email.Location = new System.Drawing.Point(141, 193);
			this.tb_email.Name = "tb_email";
			this.tb_email.Size = new System.Drawing.Size(176, 21);
			this.tb_email.TabIndex = 141;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(54, 198);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(69, 12);
			this.label7.TabIndex = 140;
			this.label7.Text = "사용자 메일";
			// 
			// tb_desc
			// 
			this.tb_desc.Location = new System.Drawing.Point(141, 220);
			this.tb_desc.Name = "tb_desc";
			this.tb_desc.Size = new System.Drawing.Size(176, 21);
			this.tb_desc.TabIndex = 143;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(54, 225);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(69, 12);
			this.label8.TabIndex = 142;
			this.label8.Text = "사용자 설명";
			// 
			// bt_user_del
			// 
			this.bt_user_del.Location = new System.Drawing.Point(261, 426);
			this.bt_user_del.Name = "bt_user_del";
			this.bt_user_del.Size = new System.Drawing.Size(88, 30);
			this.bt_user_del.TabIndex = 144;
			this.bt_user_del.Text = "삭 제";
			this.bt_user_del.UseVisualStyleBackColor = true;
			this.bt_user_del.Click += new System.EventHandler(this.bt_user_del_Click);
			// 
			// bt_user_add
			// 
			this.bt_user_add.Location = new System.Drawing.Point(167, 426);
			this.bt_user_add.Name = "bt_user_add";
			this.bt_user_add.Size = new System.Drawing.Size(88, 30);
			this.bt_user_add.TabIndex = 145;
			this.bt_user_add.Text = "추 가";
			this.bt_user_add.UseVisualStyleBackColor = true;
			this.bt_user_add.Click += new System.EventHandler(this.bt_user_add_Click);
			// 
			// bt_close
			// 
			this.bt_close.Location = new System.Drawing.Point(402, 426);
			this.bt_close.Name = "bt_close";
			this.bt_close.Size = new System.Drawing.Size(88, 30);
			this.bt_close.TabIndex = 146;
			this.bt_close.Text = "닫 기";
			this.bt_close.UseVisualStyleBackColor = true;
			this.bt_close.Click += new System.EventHandler(this.bt_close_Click_1);
			// 
			// UserDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(515, 465);
			this.Controls.Add(this.bt_close);
			this.Controls.Add(this.bt_user_add);
			this.Controls.Add(this.bt_user_del);
			this.Controls.Add(this.tb_desc);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.tb_email);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.tb_user_tel);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cb_user_level);
			this.Controls.Add(this.tb_user_nm);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tb_user_pw2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tb_user_pw);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.bt_dup_ck);
			this.Controls.Add(this.tb_user_id);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lv_user_list);
			this.Controls.Add(this.cb_valid);
			this.Controls.Add(this.bt_cancel);
			this.Controls.Add(this.bt_ok);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UserDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "사용자 정보 창";
			this.Load += new System.EventHandler(this.UserDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button bt_cancel;
		private System.Windows.Forms.Button bt_ok;
		private System.Windows.Forms.CheckBox cb_valid;
		private System.Windows.Forms.ListView lv_user_list;
		private System.Windows.Forms.ColumnHeader columnHeader20;
		private System.Windows.Forms.ColumnHeader ch_id;
		private System.Windows.Forms.ColumnHeader ch_level;
		private System.Windows.Forms.ColumnHeader cb_name;
		private System.Windows.Forms.ColumnHeader cb_tel;
		private System.Windows.Forms.ColumnHeader cb_email;
		private System.Windows.Forms.ColumnHeader cb_desc;
		private System.Windows.Forms.ColumnHeader ch_bigo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tb_user_id;
		private System.Windows.Forms.Button bt_dup_ck;
		private System.Windows.Forms.TextBox tb_user_pw;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tb_user_pw2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tb_user_nm;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cb_user_level;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tb_user_tel;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tb_email;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tb_desc;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button bt_user_del;
		private System.Windows.Forms.Button bt_user_add;
		private System.Windows.Forms.Button bt_close;
	}
}