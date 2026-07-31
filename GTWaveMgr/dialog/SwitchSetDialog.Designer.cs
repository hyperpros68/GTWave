namespace AnyBoBu.dialog {
	partial class SwitchSetDialog {
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
			this.tb_num_poe = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.bt_close = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.tb_switch_desc = new System.Windows.Forms.TextBox();
			this.tb_num_eth = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tb_num_sfp = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tb_num_combo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tb_idx_first = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cb_is_watch = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// bt_apply
			// 
			this.bt_apply.Location = new System.Drawing.Point(98, 330);
			this.bt_apply.Name = "bt_apply";
			this.bt_apply.Size = new System.Drawing.Size(88, 30);
			this.bt_apply.TabIndex = 0;
			this.bt_apply.Text = "적 용";
			this.bt_apply.UseVisualStyleBackColor = true;
			this.bt_apply.Click += new System.EventHandler(this.bt_apply_Click);
			// 
			// tb_num_poe
			// 
			this.tb_num_poe.Location = new System.Drawing.Point(197, 25);
			this.tb_num_poe.Name = "tb_num_poe";
			this.tb_num_poe.Size = new System.Drawing.Size(69, 21);
			this.tb_num_poe.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(49, 29);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 12);
			this.label3.TabIndex = 132;
			this.label3.Text = "PoE 포트 수";
			// 
			// bt_close
			// 
			this.bt_close.Location = new System.Drawing.Point(197, 330);
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
			this.label8.Location = new System.Drawing.Point(33, 242);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(57, 12);
			this.label8.TabIndex = 142;
			this.label8.Text = "추가 내용";
			// 
			// tb_switch_desc
			// 
			this.tb_switch_desc.Location = new System.Drawing.Point(35, 261);
			this.tb_switch_desc.Multiline = true;
			this.tb_switch_desc.Name = "tb_switch_desc";
			this.tb_switch_desc.Size = new System.Drawing.Size(260, 53);
			this.tb_switch_desc.TabIndex = 9;
			// 
			// tb_num_eth
			// 
			this.tb_num_eth.Location = new System.Drawing.Point(197, 52);
			this.tb_num_eth.Name = "tb_num_eth";
			this.tb_num_eth.Size = new System.Drawing.Size(69, 21);
			this.tb_num_eth.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(49, 57);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 12);
			this.label1.TabIndex = 144;
			this.label1.Text = "이더넷 포트 수";
			// 
			// tb_num_sfp
			// 
			this.tb_num_sfp.Location = new System.Drawing.Point(197, 80);
			this.tb_num_sfp.Name = "tb_num_sfp";
			this.tb_num_sfp.Size = new System.Drawing.Size(69, 21);
			this.tb_num_sfp.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(49, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 12);
			this.label2.TabIndex = 146;
			this.label2.Text = "SFP 포트 수";
			// 
			// tb_num_combo
			// 
			this.tb_num_combo.Location = new System.Drawing.Point(197, 108);
			this.tb_num_combo.Name = "tb_num_combo";
			this.tb_num_combo.Size = new System.Drawing.Size(69, 21);
			this.tb_num_combo.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(49, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(73, 12);
			this.label4.TabIndex = 148;
			this.label4.Text = "콤보 포트 수";
			// 
			// tb_idx_first
			// 
			this.tb_idx_first.Location = new System.Drawing.Point(197, 195);
			this.tb_idx_first.Name = "tb_idx_first";
			this.tb_idx_first.Size = new System.Drawing.Size(69, 21);
			this.tb_idx_first.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(49, 199);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(90, 12);
			this.label6.TabIndex = 152;
			this.label6.Text = "First Port Index";
			// 
			// cb_is_watch
			// 
			this.cb_is_watch.AutoSize = true;
			this.cb_is_watch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cb_is_watch.Location = new System.Drawing.Point(46, 169);
			this.cb_is_watch.Name = "cb_is_watch";
			this.cb_is_watch.Size = new System.Drawing.Size(164, 16);
			this.cb_is_watch.TabIndex = 7;
			this.cb_is_watch.Text = "시스템 모니터링 사용유무";
			this.cb_is_watch.UseVisualStyleBackColor = true;
			// 
			// SwitchSetDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(330, 377);
			this.Controls.Add(this.cb_is_watch);
			this.Controls.Add(this.tb_idx_first);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tb_num_combo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tb_num_sfp);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tb_num_eth);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tb_switch_desc);
			this.Controls.Add(this.bt_close);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.tb_num_poe);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.bt_apply);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SwitchSetDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "스위치 인터페이스 설정 창";
			this.Load += new System.EventHandler(this.SnmpSetDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button bt_apply;
		private System.Windows.Forms.TextBox tb_num_poe;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button bt_close;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tb_switch_desc;
		private System.Windows.Forms.TextBox tb_num_eth;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tb_num_sfp;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tb_num_combo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tb_idx_first;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox cb_is_watch;
	}
}