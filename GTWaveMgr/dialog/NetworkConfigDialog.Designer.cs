using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnyBoBu.dialog
{
	partial class NetworkConfigDialog
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
		private void InitializeComponent()
		{
			this.gb_network = new System.Windows.Forms.GroupBox();
			this.lbl_nic_mac = new System.Windows.Forms.Label();
			this.cb_nic_ip = new System.Windows.Forms.ComboBox();
			this.lbl_nic_ip = new System.Windows.Forms.Label();
			this.cb_nic_card = new System.Windows.Forms.ComboBox();
			this.lbl_nic_card = new System.Windows.Forms.Label();
			this.btn_save = new System.Windows.Forms.Button();
			this.btn_close = new System.Windows.Forms.Button();
			this.gb_network.SuspendLayout();
			this.SuspendLayout();
			// 
			// gb_network
			// 
			this.gb_network.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gb_network.Controls.Add(this.lbl_nic_mac);
			this.gb_network.Controls.Add(this.cb_nic_ip);
			this.gb_network.Controls.Add(this.lbl_nic_ip);
			this.gb_network.Controls.Add(this.cb_nic_card);
			this.gb_network.Controls.Add(this.lbl_nic_card);
			this.gb_network.Font = new System.Drawing.Font("맑은 고딕", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.gb_network.Location = new System.Drawing.Point(16, 15);
			this.gb_network.Name = "gb_network";
			this.gb_network.Size = new System.Drawing.Size(572, 126);
			this.gb_network.TabIndex = 0;
			this.gb_network.TabStop = false;
			this.gb_network.Text = "네트워크 설정";
			// 
			// lbl_nic_mac
			// 
			this.lbl_nic_mac.AutoSize = true;
			this.lbl_nic_mac.Font = new System.Drawing.Font("맑은 고딕", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lbl_nic_mac.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.lbl_nic_mac.Location = new System.Drawing.Point(375, 78);
			this.lbl_nic_mac.Name = "lbl_nic_mac";
			this.lbl_nic_mac.Size = new System.Drawing.Size(104, 17);
			this.lbl_nic_mac.TabIndex = 4;
			this.lbl_nic_mac.Text = "000000000000";
			// 
			// cb_nic_ip
			// 
			this.cb_nic_ip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_nic_ip.Font = new System.Drawing.Font("맑은 고딕", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.cb_nic_ip.FormattingEnabled = true;
			this.cb_nic_ip.Location = new System.Drawing.Point(160, 74);
			this.cb_nic_ip.Name = "cb_nic_ip";
			this.cb_nic_ip.Size = new System.Drawing.Size(200, 25);
			this.cb_nic_ip.TabIndex = 3;
			// 
			// lbl_nic_ip
			// 
			this.lbl_nic_ip.AutoSize = true;
			this.lbl_nic_ip.Font = new System.Drawing.Font("맑은 고딕", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lbl_nic_ip.Location = new System.Drawing.Point(20, 77);
			this.lbl_nic_ip.Name = "lbl_nic_ip";
			this.lbl_nic_ip.Size = new System.Drawing.Size(126, 17);
			this.lbl_nic_ip.TabIndex = 2;
			this.lbl_nic_ip.Text = "네트워크 카드 IP 주소";
			// 
			// cb_nic_card
			// 
			this.cb_nic_card.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cb_nic_card.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_nic_card.Font = new System.Drawing.Font("맑은 고딕", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.cb_nic_card.FormattingEnabled = true;
			this.cb_nic_card.Location = new System.Drawing.Point(160, 32);
			this.cb_nic_card.Name = "cb_nic_card";
			this.cb_nic_card.Size = new System.Drawing.Size(394, 25);
			this.cb_nic_card.TabIndex = 1;
			this.cb_nic_card.SelectedIndexChanged += new System.EventHandler(this.cb_nic_card_SelectedIndexChanged);
			// 
			// lbl_nic_card
			// 
			this.lbl_nic_card.AutoSize = true;
			this.lbl_nic_card.Font = new System.Drawing.Font("맑은 고딕", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lbl_nic_card.Location = new System.Drawing.Point(20, 35);
			this.lbl_nic_card.Name = "lbl_nic_card";
			this.lbl_nic_card.Size = new System.Drawing.Size(125, 17);
			this.lbl_nic_card.TabIndex = 0;
			this.lbl_nic_card.Text = "사용할 네트워크 카드";
			// 
			// btn_save
			// 
			this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_save.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btn_save.Location = new System.Drawing.Point(412, 154);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(85, 30);
			this.btn_save.TabIndex = 1;
			this.btn_save.Text = "적용";
			this.btn_save.UseVisualStyleBackColor = true;
			this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
			// 
			// btn_close
			// 
			this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_close.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btn_close.Location = new System.Drawing.Point(503, 154);
			this.btn_close.Name = "btn_close";
			this.btn_close.Size = new System.Drawing.Size(85, 30);
			this.btn_close.TabIndex = 2;
			this.btn_close.Text = "닫기";
			this.btn_close.UseVisualStyleBackColor = true;
			this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
			// 
			// NetworkConfigDialog
			// 
			this.AcceptButton = this.btn_save;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_close;
			this.ClientSize = new System.Drawing.Size(604, 196);
			this.Controls.Add(this.btn_close);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.gb_network);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NetworkConfigDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "네트워크 설정";
			this.Load += new System.EventHandler(this.NetworkConfigDialog_Load);
			this.gb_network.ResumeLayout(false);
			this.gb_network.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gb_network;
		private System.Windows.Forms.Label lbl_nic_card;
		private System.Windows.Forms.ComboBox cb_nic_card;
		private System.Windows.Forms.Label lbl_nic_ip;
		private System.Windows.Forms.ComboBox cb_nic_ip;
		private System.Windows.Forms.Label lbl_nic_mac;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_close;
	}
}
