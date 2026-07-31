using System.Drawing;
using System.Windows.Forms;

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
			this.bt_ok = new System.Windows.Forms.Button();
			this.bt_close = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.tb_id = new System.Windows.Forms.TextBox();
			this.tb_pw = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// bt_ok
			// 
			this.bt_ok.Location = new System.Drawing.Point(35, 96);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.Size = new System.Drawing.Size(78, 30);
			this.bt_ok.TabIndex = 0;
			this.bt_ok.Text = "확 인";
			this.bt_ok.UseVisualStyleBackColor = true;
			this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
			// 
			// bt_close
			// 
			this.bt_close.Location = new System.Drawing.Point(119, 95);
			this.bt_close.Name = "bt_close";
			this.bt_close.Size = new System.Drawing.Size(78, 30);
			this.bt_close.TabIndex = 1;
			this.bt_close.Text = "취 소";
			this.bt_close.UseVisualStyleBackColor = true;
			this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(35, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "아 이 디 :";
			// 
			// tb_id
			// 
			this.tb_id.Location = new System.Drawing.Point(95, 46);
			this.tb_id.Name = "tb_id";
			this.tb_id.Size = new System.Drawing.Size(100, 21);
			this.tb_id.TabIndex = 3;
			this.tb_id.Text = "admin";
			// 
			// tb_pw
			// 
			this.tb_pw.Location = new System.Drawing.Point(95, 70);
			this.tb_pw.Name = "tb_pw";
			this.tb_pw.PasswordChar = '*';
			this.tb_pw.Size = new System.Drawing.Size(100, 21);
			this.tb_pw.TabIndex = 4;
			this.tb_pw.Text = "admin";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(31, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 12);
			this.label3.TabIndex = 6;
			this.label3.Text = "패스워드 :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(29, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(161, 12);
			this.label4.TabIndex = 7;
			this.label4.Text = "로그인 정보를 입력해 주세요";
			// 
			// DialogLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(232, 137);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tb_pw);
			this.Controls.Add(this.tb_id);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bt_close);
			this.Controls.Add(this.bt_ok);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DialogLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "로그인";
			this.ResumeLayout(false);
			this.PerformLayout();

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