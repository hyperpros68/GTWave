namespace AnyBoBu
{
    partial class DetailForm
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
            this.lv_detail_mem = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lv_detail_mem
            // 
            this.lv_detail_mem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lv_detail_mem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_detail_mem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader16});
            this.lv_detail_mem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lv_detail_mem.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lv_detail_mem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lv_detail_mem.FullRowSelect = true;
            this.lv_detail_mem.GridLines = true;
            this.lv_detail_mem.HideSelection = false;
            this.lv_detail_mem.Location = new System.Drawing.Point(0, 105);
            this.lv_detail_mem.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lv_detail_mem.Name = "lv_detail_mem";
            this.lv_detail_mem.Size = new System.Drawing.Size(476, 479);
            this.lv_detail_mem.TabIndex = 116;
            this.lv_detail_mem.UseCompatibleStateImageBehavior = false;
            this.lv_detail_mem.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No";
            this.columnHeader1.Width = 28;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "구분";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Context";
            this.columnHeader16.Width = 1000;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 100);
            this.panel1.TabIndex = 117;
            // 
            // DetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 584);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lv_detail_mem);
            this.Name = "DetailForm";
            this.Text = "DetailForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_detail_mem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.Panel panel1;
    }
}