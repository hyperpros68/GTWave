namespace AutoReserve {
	partial class MainForm {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			label1 = new Label();
			lv_reserve = new ListView();
			ch_check = new ColumnHeader();
			ch_date = new ColumnHeader();
			ch_coat = new ColumnHeader();
			ch_time = new ColumnHeader();
			ch_subject = new ColumnHeader();
			ch_desc = new ColumnHeader();
			dtp_date = new DateTimePicker();
			cb_coat = new ComboBox();
			bt_start = new Button();
			label3 = new Label();
			cb_s_date = new ComboBox();
			label4 = new Label();
			cb_e_date = new ComboBox();
			bt_stop = new Button();
			bt_del = new Button();
			bt_add = new Button();
			bt_all_del = new Button();
			tb_subject = new TextBox();
			tb_desc = new TextBox();
			label2 = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("맑은 고딕", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
			label1.Location = new Point(17, 25);
			label1.Name = "label1";
			label1.Size = new Size(344, 50);
			label1.TabIndex = 0;
			label1.Text = "예약 자동 프로그램";
			// 
			// lv_reserve
			// 
			lv_reserve.Columns.AddRange(new ColumnHeader[] { ch_check, ch_date, ch_coat, ch_time, ch_subject, ch_desc });
			lv_reserve.FullRowSelect = true;
			lv_reserve.Location = new Point(12, 88);
			lv_reserve.Name = "lv_reserve";
			lv_reserve.Size = new Size(349, 265);
			lv_reserve.TabIndex = 1;
			lv_reserve.UseCompatibleStateImageBehavior = false;
			lv_reserve.View = View.Details;
			// 
			// ch_check
			// 
			ch_check.Text = "Ch";
			ch_check.Width = 20;
			// 
			// ch_date
			// 
			ch_date.Text = "일 자";
			ch_date.TextAlign = HorizontalAlignment.Center;
			ch_date.Width = 78;
			// 
			// ch_coat
			// 
			ch_coat.Text = "코트";
			ch_coat.TextAlign = HorizontalAlignment.Center;
			ch_coat.Width = 54;
			// 
			// ch_time
			// 
			ch_time.Text = "예약시간";
			ch_time.TextAlign = HorizontalAlignment.Center;
			ch_time.Width = 80;
			// 
			// ch_subject
			// 
			ch_subject.Text = "행사명";
			ch_subject.TextAlign = HorizontalAlignment.Center;
			ch_subject.Width = 100;
			// 
			// ch_desc
			// 
			ch_desc.Text = "이용 목적";
			ch_desc.Width = 200;
			// 
			// dtp_date
			// 
			dtp_date.CustomFormat = "yyyy-MM-dd";
			dtp_date.Format = DateTimePickerFormat.Custom;
			dtp_date.Location = new Point(24, 368);
			dtp_date.Name = "dtp_date";
			dtp_date.Size = new Size(107, 23);
			dtp_date.TabIndex = 3;
			// 
			// cb_coat
			// 
			cb_coat.FormattingEnabled = true;
			cb_coat.Location = new Point(24, 399);
			cb_coat.Name = "cb_coat";
			cb_coat.Size = new Size(88, 23);
			cb_coat.TabIndex = 4;
			// 
			// bt_start
			// 
			bt_start.Location = new Point(26, 531);
			bt_start.Name = "bt_start";
			bt_start.Size = new Size(141, 23);
			bt_start.TabIndex = 9;
			bt_start.Text = "예약 시작 ";
			bt_start.UseVisualStyleBackColor = true;
			bt_start.Click += bt_start_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(26, 470);
			label3.Name = "label3";
			label3.Size = new Size(51, 15);
			label3.TabIndex = 8;
			label3.Text = "[행사명]";
			// 
			// cb_s_date
			// 
			cb_s_date.FormattingEnabled = true;
			cb_s_date.Location = new Point(24, 431);
			cb_s_date.Name = "cb_s_date";
			cb_s_date.Size = new Size(72, 23);
			cb_s_date.TabIndex = 5;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(106, 434);
			label4.Name = "label4";
			label4.Size = new Size(15, 15);
			label4.TabIndex = 10;
			label4.Text = "~";
			// 
			// cb_e_date
			// 
			cb_e_date.FormattingEnabled = true;
			cb_e_date.Location = new Point(131, 431);
			cb_e_date.Name = "cb_e_date";
			cb_e_date.Size = new Size(74, 23);
			cb_e_date.TabIndex = 6;
			// 
			// bt_stop
			// 
			bt_stop.Location = new Point(199, 531);
			bt_stop.Name = "bt_stop";
			bt_stop.Size = new Size(141, 23);
			bt_stop.TabIndex = 10;
			bt_stop.Text = "예약 종료";
			bt_stop.UseVisualStyleBackColor = true;
			bt_stop.Click += bt_stop_Click;
			// 
			// bt_del
			// 
			bt_del.Location = new Point(230, 369);
			bt_del.Name = "bt_del";
			bt_del.Size = new Size(110, 23);
			bt_del.TabIndex = 12;
			bt_del.Text = "희망 시간 삭제";
			bt_del.UseVisualStyleBackColor = true;
			bt_del.Click += bt_del_Click;
			// 
			// bt_add
			// 
			bt_add.Location = new Point(230, 430);
			bt_add.Name = "bt_add";
			bt_add.Size = new Size(110, 23);
			bt_add.TabIndex = 11;
			bt_add.Text = "희망 시간 추가";
			bt_add.UseVisualStyleBackColor = true;
			bt_add.Click += bt_add_Click;
			// 
			// bt_all_del
			// 
			bt_all_del.Location = new Point(230, 394);
			bt_all_del.Name = "bt_all_del";
			bt_all_del.Size = new Size(110, 23);
			bt_all_del.TabIndex = 13;
			bt_all_del.Text = "시간 전체 삭제";
			bt_all_del.UseVisualStyleBackColor = true;
			bt_all_del.Click += bt_all_del_Click;
			// 
			// tb_subject
			// 
			tb_subject.Location = new Point(91, 464);
			tb_subject.Name = "tb_subject";
			tb_subject.Size = new Size(143, 23);
			tb_subject.TabIndex = 7;
			// 
			// tb_desc
			// 
			tb_desc.Location = new Point(91, 494);
			tb_desc.Name = "tb_desc";
			tb_desc.Size = new Size(249, 23);
			tb_desc.TabIndex = 8;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(26, 499);
			label2.Name = "label2";
			label2.Size = new Size(67, 15);
			label2.TabIndex = 16;
			label2.Text = "[이용 목적]";
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(369, 566);
			Controls.Add(tb_desc);
			Controls.Add(label2);
			Controls.Add(tb_subject);
			Controls.Add(bt_all_del);
			Controls.Add(bt_add);
			Controls.Add(bt_del);
			Controls.Add(bt_stop);
			Controls.Add(label4);
			Controls.Add(cb_e_date);
			Controls.Add(label3);
			Controls.Add(cb_s_date);
			Controls.Add(bt_start);
			Controls.Add(cb_coat);
			Controls.Add(dtp_date);
			Controls.Add(lv_reserve);
			Controls.Add(label1);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "MainForm";
			Text = "예약 자동 프로그램";
			FormClosed += MainForm_FormClosed;
			Load += MainForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private ListView lv_reserve;
		private ColumnHeader ch_check;
		private ColumnHeader ch_date;
		private ColumnHeader ch_coat;
		private ColumnHeader ch_time;
		private DateTimePicker dtp_date;
		private ComboBox cb_coat;
		private Button bt_start;
		private Label label3;
		private ComboBox cb_s_date;
		private Label label4;
		private ComboBox cb_e_date;
		private Button bt_stop;
		private Button bt_del;
		private Button bt_add;
		private Button bt_all_del;
		private ColumnHeader ch_subject;
		private ColumnHeader ch_desc;
		private TextBox tb_subject;
		private TextBox tb_desc;
		private Label label2;
	}
}
