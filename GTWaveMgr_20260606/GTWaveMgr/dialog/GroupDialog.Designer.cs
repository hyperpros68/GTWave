namespace AnyBoBu.dialog
{
    partial class GroupDialog
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
			this.bt_close = new System.Windows.Forms.Button();
			this.bt_ok = new System.Windows.Forms.Button();
			this.cb_valid = new System.Windows.Forms.CheckBox();
			this.tb_desc = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tb_agent = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tb_group_nm = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tb_root = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// bt_close
			// 
			this.bt_close.Location = new System.Drawing.Point(193, 155);
			this.bt_close.Name = "bt_close";
			this.bt_close.Size = new System.Drawing.Size(88, 30);
			this.bt_close.TabIndex = 9;
			this.bt_close.Text = "취 소";
			this.bt_close.UseVisualStyleBackColor = true;
			this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
			// 
			// bt_ok
			// 
			this.bt_ok.Location = new System.Drawing.Point(99, 155);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.Size = new System.Drawing.Size(88, 30);
			this.bt_ok.TabIndex = 8;
			this.bt_ok.Text = "확 인";
			this.bt_ok.UseVisualStyleBackColor = true;
			this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
			// 
			// cb_valid
			// 
			this.cb_valid.AutoSize = true;
			this.cb_valid.Font = new System.Drawing.Font("굴림", 9.75F);
			this.cb_valid.Location = new System.Drawing.Point(20, 162);
			this.cb_valid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cb_valid.Name = "cb_valid";
			this.cb_valid.Size = new System.Drawing.Size(56, 17);
			this.cb_valid.TabIndex = 122;
			this.cb_valid.Text = "Vaild";
			this.cb_valid.UseVisualStyleBackColor = true;
			// 
			// tb_desc
			// 
			this.tb_desc.Location = new System.Drawing.Point(105, 93);
			this.tb_desc.Multiline = true;
			this.tb_desc.Name = "tb_desc";
			this.tb_desc.Size = new System.Drawing.Size(176, 56);
			this.tb_desc.TabIndex = 144;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 98);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(33, 12);
			this.label3.TabIndex = 143;
			this.label3.Text = "설 명";
			// 
			// tb_agent
			// 
			this.tb_agent.Location = new System.Drawing.Point(105, 66);
			this.tb_agent.Name = "tb_agent";
			this.tb_agent.Size = new System.Drawing.Size(176, 21);
			this.tb_agent.TabIndex = 142;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 141;
			this.label2.Text = "담당자";
			// 
			// tb_group_nm
			// 
			this.tb_group_nm.Location = new System.Drawing.Point(105, 39);
			this.tb_group_nm.Name = "tb_group_nm";
			this.tb_group_nm.Size = new System.Drawing.Size(176, 21);
			this.tb_group_nm.TabIndex = 139;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 138;
			this.label1.Text = "그룹명";
			// 
			// tb_root
			// 
			this.tb_root.Location = new System.Drawing.Point(105, 12);
			this.tb_root.Name = "tb_root";
			this.tb_root.ReadOnly = true;
			this.tb_root.Size = new System.Drawing.Size(176, 21);
			this.tb_root.TabIndex = 148;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(18, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 12);
			this.label4.TabIndex = 147;
			this.label4.Text = "상위 그룹";
			// 
			// GroupDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(311, 199);
			this.Controls.Add(this.tb_root);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tb_desc);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tb_agent);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tb_group_nm);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cb_valid);
			this.Controls.Add(this.bt_close);
			this.Controls.Add(this.bt_ok);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GroupDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "그룹 정보 창";
			this.Load += new System.EventHandler(this.GroupDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.CheckBox cb_valid;
		private System.Windows.Forms.TextBox tb_desc;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tb_agent;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tb_group_nm;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tb_root;
		private System.Windows.Forms.Label label4;
	}
}