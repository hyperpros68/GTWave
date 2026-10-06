namespace AnyBoBu.dialog
{
    partial class OidListDialog
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
			this.lbl_template = new System.Windows.Forms.Label();
			this.tb_template_file = new System.Windows.Forms.TextBox();
			this.bt_close = new System.Windows.Forms.Button();
			this.bt_apply = new System.Windows.Forms.Button();
			this.tb_value = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tb_desc = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tb_disp_nm = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.bt_add = new System.Windows.Forms.Button();
			this.bt_del = new System.Windows.Forms.Button();
			this.lv_oid_list = new System.Windows.Forms.ListView();
			this.ch_oid_key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_oid_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_oid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_oid_value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_oid_desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.bt_load = new System.Windows.Forms.Button();
			this.tb_key = new System.Windows.Forms.TextBox();
			this.bt_save = new System.Windows.Forms.Button();
			this.tb_oid = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cb_type = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// lbl_template
			// 
			this.lbl_template.AutoSize = true;
			this.lbl_template.Location = new System.Drawing.Point(12, 16);
			this.lbl_template.Name = "lbl_template";
			this.lbl_template.Size = new System.Drawing.Size(81, 12);
			this.lbl_template.TabIndex = 152;
			this.lbl_template.Text = "OID Template";
			// 
			// tb_template_file
			// 
			this.tb_template_file.BackColor = System.Drawing.SystemColors.Window;
			this.tb_template_file.Location = new System.Drawing.Point(100, 12);
			this.tb_template_file.Name = "tb_template_file";
			this.tb_template_file.ReadOnly = true;
			this.tb_template_file.Size = new System.Drawing.Size(118, 21);
			this.tb_template_file.TabIndex = 153;
			// 
			// bt_close
			// 
			this.bt_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bt_close.Location = new System.Drawing.Point(205, 525);
			this.bt_close.Name = "bt_close";
			this.bt_close.Size = new System.Drawing.Size(85, 30);
			this.bt_close.TabIndex = 12;
			this.bt_close.Text = "종  료";
			this.bt_close.UseVisualStyleBackColor = true;
			this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
			// 
			// bt_apply
			// 
			this.bt_apply.Location = new System.Drawing.Point(20, 241);
			this.bt_apply.Name = "bt_apply";
			this.bt_apply.Size = new System.Drawing.Size(70, 30);
			this.bt_apply.TabIndex = 6;
			this.bt_apply.Text = "적  용";
			this.bt_apply.UseVisualStyleBackColor = true;
			this.bt_apply.Click += new System.EventHandler(this.bt_apply_Click);
			// 
			// tb_value
			// 
			this.tb_value.Location = new System.Drawing.Point(105, 179);
			this.tb_value.Multiline = true;
			this.tb_value.Name = "tb_value";
			this.tb_value.Size = new System.Drawing.Size(176, 56);
			this.tb_value.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 184);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 12);
			this.label3.TabIndex = 143;
			this.label3.Text = "값 표시";
			// 
			// tb_desc
			// 
			this.tb_desc.Location = new System.Drawing.Point(105, 152);
			this.tb_desc.Name = "tb_desc";
			this.tb_desc.Size = new System.Drawing.Size(176, 21);
			this.tb_desc.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 157);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 141;
			this.label2.Text = "비고";
			// 
			// tb_disp_nm
			// 
			this.tb_disp_nm.Location = new System.Drawing.Point(105, 71);
			this.tb_disp_nm.Name = "tb_disp_nm";
			this.tb_disp_nm.Size = new System.Drawing.Size(176, 21);
			this.tb_disp_nm.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 76);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 138;
			this.label1.Text = "표시이름";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(18, 49);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(25, 12);
			this.label4.TabIndex = 147;
			this.label4.Text = "key";
			// 
			// bt_add
			// 
			this.bt_add.Location = new System.Drawing.Point(117, 241);
			this.bt_add.Name = "bt_add";
			this.bt_add.Size = new System.Drawing.Size(70, 30);
			this.bt_add.TabIndex = 7;
			this.bt_add.Text = "추  가";
			this.bt_add.UseVisualStyleBackColor = true;
			this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
			// 
			// bt_del
			// 
			this.bt_del.Location = new System.Drawing.Point(211, 241);
			this.bt_del.Name = "bt_del";
			this.bt_del.Size = new System.Drawing.Size(70, 30);
			this.bt_del.TabIndex = 8;
			this.bt_del.Text = "삭  제";
			this.bt_del.UseVisualStyleBackColor = true;
			this.bt_del.Click += new System.EventHandler(this.bt_del_Click);
			// 
			// lv_oid_list
			// 
			this.lv_oid_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lv_oid_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lv_oid_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lv_oid_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_oid_key,
            this.ch_oid_name,
            this.ch_oid,
            this.ch_oid_value,
            this.ch_oid_desc});
			this.lv_oid_list.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lv_oid_list.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lv_oid_list.FullRowSelect = true;
			this.lv_oid_list.GridLines = true;
			this.lv_oid_list.HideSelection = false;
			this.lv_oid_list.Location = new System.Drawing.Point(6, 280);
			this.lv_oid_list.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.lv_oid_list.Name = "lv_oid_list";
			this.lv_oid_list.Size = new System.Drawing.Size(284, 237);
			this.lv_oid_list.TabIndex = 9;
			this.lv_oid_list.UseCompatibleStateImageBehavior = false;
			this.lv_oid_list.View = System.Windows.Forms.View.Details;
			this.lv_oid_list.SelectedIndexChanged += new System.EventHandler(this.lv_oid_list_SelectedIndexChanged);
			this.lv_oid_list.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_oid_list_MouseDoubleClick);
			// 
			// ch_oid_key
			// 
			this.ch_oid_key.Text = "Key";
			this.ch_oid_key.Width = 80;
			// 
			// ch_oid_name
			// 
			this.ch_oid_name.Text = "표시이름";
			this.ch_oid_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ch_oid_name.Width = 80;
			// 
			// ch_oid
			// 
			this.ch_oid.Text = "OID 값";
			this.ch_oid.Width = 80;
			// 
			// ch_oid_value
			// 
			this.ch_oid_value.Text = "값 표시";
			this.ch_oid_value.Width = 80;
			// 
			// ch_oid_desc
			// 
			this.ch_oid_desc.Text = "비고";
			// 
			// bt_load
			// 
			this.bt_load.Location = new System.Drawing.Point(223, 11);
			this.bt_load.Name = "bt_load";
			this.bt_load.Size = new System.Drawing.Size(68, 23);
			this.bt_load.TabIndex = 154;
			this.bt_load.Text = "파일찾기";
			this.bt_load.UseVisualStyleBackColor = true;
			this.bt_load.Click += new System.EventHandler(this.bt_load_Click);
			// 
			// tb_key
			// 
			this.tb_key.Location = new System.Drawing.Point(105, 44);
			this.tb_key.Name = "tb_key";
			this.tb_key.Size = new System.Drawing.Size(176, 21);
			this.tb_key.TabIndex = 0;
			// 
			// bt_save
			// 
			this.bt_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bt_save.Location = new System.Drawing.Point(90, 525);
			this.bt_save.Name = "bt_save";
			this.bt_save.Size = new System.Drawing.Size(105, 30);
			this.bt_save.TabIndex = 11;
			this.bt_save.Text = "파일 저장하기";
			this.bt_save.UseVisualStyleBackColor = true;
			this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
			// 
			// tb_oid
			// 
			this.tb_oid.Location = new System.Drawing.Point(105, 99);
			this.tb_oid.Name = "tb_oid";
			this.tb_oid.Size = new System.Drawing.Size(176, 21);
			this.tb_oid.TabIndex = 2;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(18, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 12);
			this.label5.TabIndex = 149;
			this.label5.Text = "OID 값";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(18, 131);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 12);
			this.label6.TabIndex = 151;
			this.label6.Text = "자료 Type";
			// 
			// cb_type
			// 
			this.cb_type.FormattingEnabled = true;
			this.cb_type.Items.AddRange(new object[] {
            "Int",
            "OctetString",
            "String"});
			this.cb_type.Location = new System.Drawing.Point(105, 127);
			this.cb_type.Name = "cb_type";
			this.cb_type.Size = new System.Drawing.Size(176, 20);
			this.cb_type.TabIndex = 3;
			// 
			// OidListDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(302, 565);
			this.Controls.Add(this.tb_template_file);
			this.Controls.Add(this.lbl_template);
			this.Controls.Add(this.cb_type);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tb_oid);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.bt_save);
			this.Controls.Add(this.tb_key);
			this.Controls.Add(this.bt_load);
			this.Controls.Add(this.lv_oid_list);
			this.Controls.Add(this.bt_del);
			this.Controls.Add(this.bt_add);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tb_value);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tb_desc);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tb_disp_nm);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bt_close);
			this.Controls.Add(this.bt_apply);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OidListDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "OID 목록 관리";
			this.Load += new System.EventHandler(this.OidListDialog_Load);
			this.Shown += new System.EventHandler(this.OidListDialog_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.Button bt_apply;
		private System.Windows.Forms.TextBox tb_value;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tb_desc;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tb_disp_nm;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button bt_add;
		private System.Windows.Forms.Button bt_del;
		private System.Windows.Forms.ListView lv_oid_list;
		private System.Windows.Forms.ColumnHeader ch_oid_key;
		private System.Windows.Forms.ColumnHeader ch_oid_name;
		private System.Windows.Forms.ColumnHeader ch_oid;
		private System.Windows.Forms.ColumnHeader ch_oid_value;
		private System.Windows.Forms.Button bt_load;
		private System.Windows.Forms.TextBox tb_key;
		private System.Windows.Forms.ColumnHeader ch_oid_desc;
		private System.Windows.Forms.Button bt_save;
		private System.Windows.Forms.TextBox tb_oid;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lbl_template;
		private System.Windows.Forms.TextBox tb_template_file;
		private System.Windows.Forms.ComboBox cb_type;
	}
}