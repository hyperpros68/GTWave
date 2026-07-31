namespace AnyBoBu.dialog
{
    partial class DialogLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
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
			bt_ok = new Button();
			bt_close = new Button();
			label1 = new Label();
			tb_id = new TextBox();
			tb_pw = new TextBox();
			label3 = new Label();
			label4 = new Label();
			SuspendLayout();
			// 
			// bt_ok
			// 
			bt_ok.Location = new Point(35, 120);
			bt_ok.Margin = new Padding(3, 4, 3, 4);
			bt_ok.Name = "bt_ok";
			bt_ok.Size = new Size(78, 38);
			bt_ok.TabIndex = 0;
			bt_ok.Text = "확 인";
			bt_ok.UseVisualStyleBackColor = true;
			bt_ok.Click += bt_ok_Click;
			// 
			// bt_close
			// 
			bt_close.Location = new Point(119, 119);
			bt_close.Margin = new Padding(3, 4, 3, 4);
			bt_close.Name = "bt_close";
			bt_close.Size = new Size(78, 38);
			bt_close.TabIndex = 1;
			bt_close.Text = "취 소";
			bt_close.UseVisualStyleBackColor = true;
			bt_close.Click += bt_close_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(35, 62);
			label1.Name = "label1";
			label1.Size = new Size(58, 15);
			label1.TabIndex = 2;
			label1.Text = "아 이 디 :";
			// 
			// tb_id
			// 
			tb_id.Location = new Point(95, 57);
			tb_id.Margin = new Padding(3, 4, 3, 4);
			tb_id.Name = "tb_id";
			tb_id.Size = new Size(100, 23);
			tb_id.TabIndex = 3;
			// 
			// tb_pw
			// 
			tb_pw.Location = new Point(95, 87);
			tb_pw.Margin = new Padding(3, 4, 3, 4);
			tb_pw.Name = "tb_pw";
			tb_pw.PasswordChar = '*';
			tb_pw.Size = new Size(100, 23);
			tb_pw.TabIndex = 4;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(31, 92);
			label3.Name = "label3";
			label3.Size = new Size(62, 15);
			label3.TabIndex = 6;
			label3.Text = "패스워드 :";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(29, 29);
			label4.Name = "label4";
			label4.Size = new Size(163, 15);
			label4.TabIndex = 7;
			label4.Text = "로그인 정보를 입력해 주세요";
			// 
			// DialogLogin
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(232, 171);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(tb_pw);
			Controls.Add(tb_id);
			Controls.Add(label1);
			Controls.Add(bt_close);
			Controls.Add(bt_ok);
			Margin = new Padding(3, 4, 3, 4);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "DialogLogin";
			StartPosition = FormStartPosition.CenterParent;
			Text = "로그인";
			Load += CrawlOptionDialog_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.TextBox tb_pw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}