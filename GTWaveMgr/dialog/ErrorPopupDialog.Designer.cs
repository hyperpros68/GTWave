using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnyBoBu.dialog
{
	partial class ErrorPopupDialog
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
			this.pnlTop = new System.Windows.Forms.Panel();
			this.lblOccurTime = new System.Windows.Forms.Label();
			this.lblColGroup = new System.Windows.Forms.Label();
			this.lblColSystem = new System.Windows.Forms.Label();
			this.pnlList = new System.Windows.Forms.Panel();
			this.pnlBottom = new System.Windows.Forms.Panel();
			this.btnOk = new System.Windows.Forms.Button();
			this.pnlTop.SuspendLayout();
			this.pnlBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
			this.pnlTop.Controls.Add(this.lblOccurTime);
			this.pnlTop.Controls.Add(this.lblColGroup);
			this.pnlTop.Controls.Add(this.lblColSystem);
			this.pnlTop.Controls.Add(this.pnlList);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(384, 120);
			this.pnlTop.TabIndex = 0;
			// 
			// lblOccurTime
			// 
			this.lblOccurTime.AutoSize = true;
			this.lblOccurTime.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblOccurTime.Location = new System.Drawing.Point(12, 12);
			this.lblOccurTime.Name = "lblOccurTime";
			this.lblOccurTime.Size = new System.Drawing.Size(65, 17);
			this.lblOccurTime.TabIndex = 0;
			this.lblOccurTime.Text = "발생시간:";
			// 
			// lblColGroup
			// 
			this.lblColGroup.AutoSize = true;
			this.lblColGroup.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblColGroup.Location = new System.Drawing.Point(12, 38);
			this.lblColGroup.Name = "lblColGroup";
			this.lblColGroup.Size = new System.Drawing.Size(55, 15);
			this.lblColGroup.TabIndex = 1;
			this.lblColGroup.Text = "그룹이름";
			// 
			// lblColSystem
			// 
			this.lblColSystem.AutoSize = true;
			this.lblColSystem.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblColSystem.Location = new System.Drawing.Point(135, 38);
			this.lblColSystem.Name = "lblColSystem";
			this.lblColSystem.Size = new System.Drawing.Size(126, 15);
			this.lblColSystem.TabIndex = 2;
			this.lblColSystem.Text = "시스템 이름(IP 주소)";
			// 
			// pnlList
			// 
			this.pnlList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlList.AutoScroll = true;
			this.pnlList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
			this.pnlList.Location = new System.Drawing.Point(10, 58);
			this.pnlList.Name = "pnlList";
			this.pnlList.Size = new System.Drawing.Size(364, 52);
			this.pnlList.TabIndex = 3;
			// 
			// pnlBottom
			// 
			this.pnlBottom.BackColor = System.Drawing.SystemColors.Control;
			this.pnlBottom.Controls.Add(this.btnOk);
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBottom.Location = new System.Drawing.Point(0, 120);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Size = new System.Drawing.Size(384, 45);
			this.pnlBottom.TabIndex = 1;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btnOk.Location = new System.Drawing.Point(294, 9);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(78, 27);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "확인";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// ErrorPopupDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 165);
			this.Controls.Add(this.pnlTop);
			this.Controls.Add(this.pnlBottom);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ErrorPopupDialog";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "장애창";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ErrorPopupDialog_FormClosing);
			this.pnlTop.ResumeLayout(false);
			this.pnlTop.PerformLayout();
			this.pnlBottom.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Label lblOccurTime;
		private System.Windows.Forms.Label lblColGroup;
		private System.Windows.Forms.Label lblColSystem;
		private System.Windows.Forms.Panel pnlList;
		private System.Windows.Forms.Panel pnlBottom;
		private System.Windows.Forms.Button btnOk;
	}
}
