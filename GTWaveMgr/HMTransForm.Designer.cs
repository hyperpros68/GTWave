namespace AnyBoBu
{
    partial class HMTransForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pb_src_image = new System.Windows.Forms.PictureBox();
            this.pb_trans_image = new System.Windows.Forms.PictureBox();
            this.lv_tuple = new System.Windows.Forms.ListView();
            this.ch_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_language = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_t_color = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cb_text_size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cb_trans_text = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cb_src_text = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cb_position = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pn_fix = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.bt_re_trans = new System.Windows.Forms.Button();
            this.pn_text_color = new System.Windows.Forms.Panel();
            this.pb_tuple_img = new System.Windows.Forms.PictureBox();
            this.tb_text_size = new System.Windows.Forms.TextBox();
            this.tb_language = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_trans_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_src_text = new System.Windows.Forms.TextBox();
            this.bt_ok_fix = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_src_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_trans_image)).BeginInit();
            this.pn_fix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_tuple_img)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lv_tuple);
            this.splitContainer1.Panel2.Controls.Add(this.pn_fix);
            this.splitContainer1.Size = new System.Drawing.Size(1341, 960);
            this.splitContainer1.SplitterDistance = 304;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pb_src_image);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pb_trans_image);
            this.splitContainer2.Size = new System.Drawing.Size(304, 960);
            this.splitContainer2.SplitterDistance = 466;
            this.splitContainer2.TabIndex = 0;
            // 
            // pb_src_image
            // 
            this.pb_src_image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_src_image.Location = new System.Drawing.Point(0, 0);
            this.pb_src_image.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pb_src_image.Name = "pb_src_image";
            this.pb_src_image.Size = new System.Drawing.Size(304, 466);
            this.pb_src_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_src_image.TabIndex = 1;
            this.pb_src_image.TabStop = false;
            // 
            // pb_trans_image
            // 
            this.pb_trans_image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_trans_image.Location = new System.Drawing.Point(0, 0);
            this.pb_trans_image.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pb_trans_image.Name = "pb_trans_image";
            this.pb_trans_image.Size = new System.Drawing.Size(304, 489);
            this.pb_trans_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_trans_image.TabIndex = 2;
            this.pb_trans_image.TabStop = false;
            this.pb_trans_image.Click += new System.EventHandler(this.pb_trans_image_Click);
            // 
            // lv_tuple
            // 
            this.lv_tuple.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_tuple.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lv_tuple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_tuple.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_no,
            this.ch_language,
            this.ch_t_color,
            this.cb_text_size,
            this.cb_trans_text,
            this.cb_src_text,
            this.cb_position});
            this.lv_tuple.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lv_tuple.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lv_tuple.FullRowSelect = true;
            this.lv_tuple.GridLines = true;
            this.lv_tuple.HideSelection = false;
            this.lv_tuple.Location = new System.Drawing.Point(0, 240);
            this.lv_tuple.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.lv_tuple.Name = "lv_tuple";
            this.lv_tuple.Size = new System.Drawing.Size(1032, 717);
            this.lv_tuple.TabIndex = 117;
            this.lv_tuple.UseCompatibleStateImageBehavior = false;
            this.lv_tuple.View = System.Windows.Forms.View.Details;
            this.lv_tuple.SelectedIndexChanged += new System.EventHandler(this.lv_tuple_SelectedIndexChanged);
            // 
            // ch_no
            // 
            this.ch_no.Text = "No";
            this.ch_no.Width = 100;
            // 
            // ch_language
            // 
            this.ch_language.Text = "언어";
            this.ch_language.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_language.Width = 40;
            // 
            // ch_t_color
            // 
            this.ch_t_color.Text = "글자색";
            this.ch_t_color.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ch_t_color.Width = 80;
            // 
            // cb_text_size
            // 
            this.cb_text_size.Text = "글자크기";
            this.cb_text_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cb_text_size.Width = 80;
            // 
            // cb_trans_text
            // 
            this.cb_trans_text.Text = "변환글자";
            this.cb_trans_text.Width = 400;
            // 
            // cb_src_text
            // 
            this.cb_src_text.Text = "원본 글자";
            this.cb_src_text.Width = 200;
            // 
            // cb_position
            // 
            this.cb_position.Text = "위치";
            this.cb_position.Width = 200;
            // 
            // pn_fix
            // 
            this.pn_fix.Controls.Add(this.checkBox1);
            this.pn_fix.Controls.Add(this.bt_re_trans);
            this.pn_fix.Controls.Add(this.pn_text_color);
            this.pn_fix.Controls.Add(this.pb_tuple_img);
            this.pn_fix.Controls.Add(this.tb_text_size);
            this.pn_fix.Controls.Add(this.tb_language);
            this.pn_fix.Controls.Add(this.label5);
            this.pn_fix.Controls.Add(this.label4);
            this.pn_fix.Controls.Add(this.label3);
            this.pn_fix.Controls.Add(this.label2);
            this.pn_fix.Controls.Add(this.tb_trans_text);
            this.pn_fix.Controls.Add(this.label1);
            this.pn_fix.Controls.Add(this.tb_src_text);
            this.pn_fix.Controls.Add(this.bt_ok_fix);
            this.pn_fix.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_fix.Location = new System.Drawing.Point(0, 0);
            this.pn_fix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pn_fix.Name = "pn_fix";
            this.pn_fix.Size = new System.Drawing.Size(1032, 244);
            this.pn_fix.TabIndex = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(475, 205);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(129, 19);
            this.checkBox1.TabIndex = 28;
            this.checkBox1.Text = "전체 언어 변경";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // bt_re_trans
            // 
            this.bt_re_trans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_re_trans.Location = new System.Drawing.Point(911, 199);
            this.bt_re_trans.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bt_re_trans.Name = "bt_re_trans";
            this.bt_re_trans.Size = new System.Drawing.Size(107, 35);
            this.bt_re_trans.TabIndex = 27;
            this.bt_re_trans.Text = "전체 재 변경";
            this.bt_re_trans.UseVisualStyleBackColor = true;
            this.bt_re_trans.Click += new System.EventHandler(this.bt_re_trans_Click);
            // 
            // pn_text_color
            // 
            this.pn_text_color.Location = new System.Drawing.Point(85, 204);
            this.pn_text_color.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pn_text_color.Name = "pn_text_color";
            this.pn_text_color.Size = new System.Drawing.Size(87, 22);
            this.pn_text_color.TabIndex = 26;
            this.pn_text_color.Click += new System.EventHandler(this.pn_text_color_Click);
            // 
            // pb_tuple_img
            // 
            this.pb_tuple_img.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_tuple_img.Location = new System.Drawing.Point(13, 11);
            this.pb_tuple_img.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pb_tuple_img.Name = "pb_tuple_img";
            this.pb_tuple_img.Size = new System.Drawing.Size(1006, 106);
            this.pb_tuple_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_tuple_img.TabIndex = 25;
            this.pb_tuple_img.TabStop = false;
            // 
            // tb_text_size
            // 
            this.tb_text_size.Location = new System.Drawing.Point(258, 201);
            this.tb_text_size.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_text_size.Name = "tb_text_size";
            this.tb_text_size.Size = new System.Drawing.Size(54, 25);
            this.tb_text_size.TabIndex = 24;
            // 
            // tb_language
            // 
            this.tb_language.Location = new System.Drawing.Point(407, 201);
            this.tb_language.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_language.Name = "tb_language";
            this.tb_language.Size = new System.Drawing.Size(55, 25);
            this.tb_language.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "번역 언어";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "글자 크기";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "글자색";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "번역 Text";
            // 
            // tb_trans_text
            // 
            this.tb_trans_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_trans_text.Location = new System.Drawing.Point(85, 165);
            this.tb_trans_text.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_trans_text.Name = "tb_trans_text";
            this.tb_trans_text.Size = new System.Drawing.Size(933, 25);
            this.tb_trans_text.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "원본 Text";
            // 
            // tb_src_text
            // 
            this.tb_src_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_src_text.Location = new System.Drawing.Point(85, 131);
            this.tb_src_text.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_src_text.Name = "tb_src_text";
            this.tb_src_text.Size = new System.Drawing.Size(933, 25);
            this.tb_src_text.TabIndex = 16;
            // 
            // bt_ok_fix
            // 
            this.bt_ok_fix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_ok_fix.Location = new System.Drawing.Point(647, 199);
            this.bt_ok_fix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bt_ok_fix.Name = "bt_ok_fix";
            this.bt_ok_fix.Size = new System.Drawing.Size(107, 35);
            this.bt_ok_fix.TabIndex = 15;
            this.bt_ok_fix.Text = "수정 완료";
            this.bt_ok_fix.UseVisualStyleBackColor = true;
            this.bt_ok_fix.Click += new System.EventHandler(this.bt_ok_fix_Click);
            // 
            // HMTransForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 960);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HMTransForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HMTransForm";
            this.Load += new System.EventHandler(this.HMTransForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_src_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_trans_image)).EndInit();
            this.pn_fix.ResumeLayout(false);
            this.pn_fix.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_tuple_img)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pb_src_image;
        private System.Windows.Forms.PictureBox pb_trans_image;
        private System.Windows.Forms.Panel pn_fix;
        private System.Windows.Forms.TextBox tb_text_size;
        private System.Windows.Forms.TextBox tb_language;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_trans_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_src_text;
        private System.Windows.Forms.Button bt_ok_fix;
        private System.Windows.Forms.ListView lv_tuple;
        private System.Windows.Forms.ColumnHeader ch_no;
        private System.Windows.Forms.ColumnHeader ch_language;
        private System.Windows.Forms.ColumnHeader ch_t_color;
        private System.Windows.Forms.ColumnHeader cb_text_size;
        private System.Windows.Forms.ColumnHeader cb_trans_text;
        private System.Windows.Forms.ColumnHeader cb_src_text;
        private System.Windows.Forms.ColumnHeader cb_position;
        private System.Windows.Forms.PictureBox pb_tuple_img;
        private System.Windows.Forms.Panel pn_text_color;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button bt_re_trans;
    }
}