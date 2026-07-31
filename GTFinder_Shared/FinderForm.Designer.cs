using System.Windows.Forms;
using System.Drawing;

namespace GTFinder {
	partial class FinderForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinderForm));
			bt_scan = new Button();
			lv_system_list = new ListView();
			ch_no = new ColumnHeader();
			ch_model = new ColumnHeader();
			ch_ip = new ColumnHeader();
			ch_mac = new ColumnHeader();
			ch_name = new ColumnHeader();
			pictureBox1 = new PictureBox();
			bt_cls_list = new Button();
			bt_conn = new Button();
			bt_close = new Button();
			groupBox1 = new GroupBox();
			cbNetworkAdapter = new ComboBox();
			label2 = new Label();
			label1 = new Label();
			cb_system_type = new ComboBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// bt_scan
			// 
			bt_scan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			bt_scan.Location = new Point(714, 149);
			bt_scan.Name = "bt_scan";
			bt_scan.Size = new Size(100, 40);
			bt_scan.TabIndex = 0;
			bt_scan.Text = "검 색.";
			bt_scan.UseVisualStyleBackColor = true;
			bt_scan.Click += bt_scan_Click;
			// 
			// lv_system_list
			// 
			lv_system_list.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lv_system_list.Columns.AddRange(new ColumnHeader[] { ch_no, ch_model, ch_ip, ch_mac, ch_name });
			lv_system_list.Location = new Point(8, 12);
			lv_system_list.Name = "lv_system_list";
			lv_system_list.Size = new Size(698, 348);
			lv_system_list.TabIndex = 1;
			lv_system_list.UseCompatibleStateImageBehavior = false;
			lv_system_list.View = View.Details;
			// 
			// ch_no
			// 
			ch_no.Text = "No";
			ch_no.TextAlign = HorizontalAlignment.Center;
			ch_no.Width = 40;
			// 
			// ch_model
			// 
			ch_model.Text = "모델명";
			ch_model.Width = 120;
			// 
			// ch_ip
			// 
			ch_ip.Text = "IP 주소";
			ch_ip.TextAlign = HorizontalAlignment.Center;
			ch_ip.Width = 120;
			// 
			// ch_mac
			// 
			ch_mac.Text = "MAC 주소";
			ch_mac.TextAlign = HorizontalAlignment.Center;
			ch_mac.Width = 120;
			// 
			// ch_name
			// 
			ch_name.Text = "시스템 이름";
			ch_name.TextAlign = HorizontalAlignment.Center;
			ch_name.Width = 120;
			// 
			// pictureBox1
			// 
			pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(714, 241);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(206, 119);
			pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 2;
			pictureBox1.TabStop = false;
			// 
			// bt_cls_list
			// 
			bt_cls_list.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			bt_cls_list.Location = new Point(820, 149);
			bt_cls_list.Name = "bt_cls_list";
			bt_cls_list.Size = new Size(100, 40);
			bt_cls_list.TabIndex = 3;
			bt_cls_list.Text = "리스트 지우기";
			bt_cls_list.UseVisualStyleBackColor = true;
			bt_cls_list.Click += bt_cls_list_Click;
			// 
			// bt_conn
			// 
			bt_conn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			bt_conn.Location = new Point(714, 195);
			bt_conn.Name = "bt_conn";
			bt_conn.Size = new Size(100, 40);
			bt_conn.TabIndex = 4;
			bt_conn.Text = "시스템 접속";
			bt_conn.UseVisualStyleBackColor = true;
			bt_conn.Click += bt_conn_Click;
			// 
			// bt_close
			// 
			bt_close.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			bt_close.Location = new Point(820, 195);
			bt_close.Name = "bt_close";
			bt_close.Size = new Size(100, 40);
			bt_close.TabIndex = 5;
			bt_close.Text = "종 료";
			bt_close.UseVisualStyleBackColor = true;
			bt_close.Click += bt_close_Click;
			// 
			// groupBox1
			// 
			groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			groupBox1.Controls.Add(cbNetworkAdapter);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(cb_system_type);
			groupBox1.Location = new Point(716, 13);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(200, 135);
			groupBox1.TabIndex = 6;
			groupBox1.TabStop = false;
			groupBox1.Text = "검색 조건";
			// 
			// cbNetworkAdapter
			// 
			cbNetworkAdapter.FormattingEnabled = true;
			cbNetworkAdapter.Items.AddRange(new object[] { "모든 시스템", "네트워크 스위치", "비디오 서버 시스템" });
			cbNetworkAdapter.Location = new Point(8, 102);
			cbNetworkAdapter.Name = "cbNetworkAdapter";
			cbNetworkAdapter.Size = new Size(186, 23);
			cbNetworkAdapter.TabIndex = 4;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(10, 81);
			label2.Name = "label2";
			label2.Size = new Size(98, 15);
			label2.TabIndex = 3;
			label2.Text = "Network Adapter";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(8, 25);
			label1.Name = "label1";
			label1.Size = new Size(71, 15);
			label1.TabIndex = 2;
			label1.Text = "시스템 종류";
			// 
			// cb_system_type
			// 
			cb_system_type.FormattingEnabled = true;
			cb_system_type.Items.AddRange(new object[] { "모든 시스템", "네트워크 스위치", "GTWave 무선 시스템 ", "비디오 서버 시스템" });
			cb_system_type.Location = new Point(8, 47);
			cb_system_type.Name = "cb_system_type";
			cb_system_type.Size = new Size(186, 23);
			cb_system_type.TabIndex = 0;
			// 
			// FinderForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(928, 370);
			Controls.Add(groupBox1);
			Controls.Add(bt_close);
			Controls.Add(bt_conn);
			Controls.Add(bt_cls_list);
			Controls.Add(pictureBox1);
			Controls.Add(lv_system_list);
			Controls.Add(bt_scan);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "FinderForm";
			StartPosition = FormStartPosition.CenterParent;
			Text = "장비 찾기 (GTFinder)";
			FormClosing += FinderForm_FormClosing;
			Load += FinderForm_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Button bt_scan;
		private ListView lv_system_list;
		private ColumnHeader ch_no;
		private ColumnHeader ch_model;
		private ColumnHeader ch_ip;
		private ColumnHeader ch_mac;
		private ColumnHeader ch_name;
		private PictureBox pictureBox1;
		private Button bt_cls_list;
		private Button bt_conn;
		private Button bt_close;
		private GroupBox groupBox1;
		private Label label1;
		private ComboBox cb_system_type;
		private ComboBox cbNetworkAdapter;
		private Label label2;
	}
}
