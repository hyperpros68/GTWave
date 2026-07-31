namespace AnyBoBu.dialog {
	partial class StatusDialog {
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
			this.tb_system_nm = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.bt_close = new System.Windows.Forms.Button();
			this.mtb_addr = new System.Windows.Forms.MaskedTextBox();
			this.tb_used_cpu = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tb_used_memory = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tb_used_disk = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tb_traffic_network = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// bt_apply
			// 
			this.bt_apply.Location = new System.Drawing.Point(120, 219);
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
			this.cb_is_dumy.Location = new System.Drawing.Point(130, 60);
			this.cb_is_dumy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cb_is_dumy.Name = "cb_is_dumy";
			this.cb_is_dumy.Size = new System.Drawing.Size(52, 17);
			this.cb_is_dumy.TabIndex = 5;
			this.cb_is_dumy.Text = "더미";
			this.cb_is_dumy.UseVisualStyleBackColor = true;
			// 
			// tb_system_nm
			// 
			this.tb_system_nm.Location = new System.Drawing.Point(131, 32);
			this.tb_system_nm.Name = "tb_system_nm";
			this.tb_system_nm.Size = new System.Drawing.Size(176, 21);
			this.tb_system_nm.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(37, 37);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 12);
			this.label3.TabIndex = 132;
			this.label3.Text = "시스템 이름";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(38, 63);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 12);
			this.label5.TabIndex = 137;
			this.label5.Text = "IP 주소";
			// 
			// bt_close
			// 
			this.bt_close.Location = new System.Drawing.Point(219, 219);
			this.bt_close.Name = "bt_close";
			this.bt_close.Size = new System.Drawing.Size(88, 30);
			this.bt_close.TabIndex = 1;
			this.bt_close.Text = "닫 기";
			this.bt_close.UseVisualStyleBackColor = true;
			this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
			// 
			// mtb_addr
			// 
			this.mtb_addr.Location = new System.Drawing.Point(197, 59);
			this.mtb_addr.Mask = "###.###.###.###";
			this.mtb_addr.Name = "mtb_addr";
			this.mtb_addr.Size = new System.Drawing.Size(109, 21);
			this.mtb_addr.TabIndex = 6;
			// 
			// tb_used_cpu
			// 
			this.tb_used_cpu.Location = new System.Drawing.Point(130, 97);
			this.tb_used_cpu.Name = "tb_used_cpu";
			this.tb_used_cpu.Size = new System.Drawing.Size(176, 21);
			this.tb_used_cpu.TabIndex = 153;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 102);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 12);
			this.label1.TabIndex = 154;
			this.label1.Text = "CPU 사용량";
			// 
			// tb_used_memory
			// 
			this.tb_used_memory.Location = new System.Drawing.Point(131, 124);
			this.tb_used_memory.Name = "tb_used_memory";
			this.tb_used_memory.Size = new System.Drawing.Size(176, 21);
			this.tb_used_memory.TabIndex = 155;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(37, 129);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 12);
			this.label2.TabIndex = 156;
			this.label2.Text = "메모리 사용량";
			// 
			// tb_used_disk
			// 
			this.tb_used_disk.Location = new System.Drawing.Point(130, 151);
			this.tb_used_disk.Name = "tb_used_disk";
			this.tb_used_disk.Size = new System.Drawing.Size(176, 21);
			this.tb_used_disk.TabIndex = 157;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(36, 156);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 12);
			this.label4.TabIndex = 158;
			this.label4.Text = "Disk 사용량";
			// 
			// tb_traffic_network
			// 
			this.tb_traffic_network.Location = new System.Drawing.Point(130, 178);
			this.tb_traffic_network.Name = "tb_traffic_network";
			this.tb_traffic_network.Size = new System.Drawing.Size(176, 21);
			this.tb_traffic_network.TabIndex = 159;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(36, 183);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(81, 12);
			this.label6.TabIndex = 160;
			this.label6.Text = "네트웍 트래픽";
			// 
			// StatusDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(338, 279);
			this.Controls.Add(this.tb_traffic_network);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tb_used_disk);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tb_used_memory);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tb_used_cpu);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.mtb_addr);
			this.Controls.Add(this.bt_close);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tb_system_nm);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cb_is_dumy);
			this.Controls.Add(this.bt_apply);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StatusDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "시스템 상태 정보 창";
			this.Load += new System.EventHandler(this.WirelessDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button bt_apply;
		private System.Windows.Forms.CheckBox cb_is_dumy;
		private System.Windows.Forms.TextBox tb_system_nm;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button bt_close;
		private System.Windows.Forms.MaskedTextBox mtb_addr;
		private System.Windows.Forms.TextBox tb_used_cpu;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tb_used_memory;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tb_used_disk;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tb_traffic_network;
		private System.Windows.Forms.Label label6;
	}
}