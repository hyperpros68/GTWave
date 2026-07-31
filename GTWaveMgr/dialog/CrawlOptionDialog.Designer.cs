namespace AnyBoBu.dialog
{
    partial class CrawlOptionDialog
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
            this.bt_ok = new System.Windows.Forms.Button();
            this.bt_close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_min_price = new System.Windows.Forms.TextBox();
            this.tb_max_price = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(25, 91);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(88, 30);
            this.bt_ok.TabIndex = 0;
            this.bt_ok.Text = "확 인";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // bt_close
            // 
            this.bt_close.Location = new System.Drawing.Point(161, 91);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(88, 30);
            this.bt_close.TabIndex = 1;
            this.bt_close.Text = "취 소";
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "가격대";
            // 
            // tb_min_price
            // 
            this.tb_min_price.Location = new System.Drawing.Point(59, 54);
            this.tb_min_price.Name = "tb_min_price";
            this.tb_min_price.Size = new System.Drawing.Size(69, 21);
            this.tb_min_price.TabIndex = 3;
            this.tb_min_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_max_price
            // 
            this.tb_max_price.Location = new System.Drawing.Point(154, 54);
            this.tb_max_price.Name = "tb_max_price";
            this.tb_max_price.Size = new System.Drawing.Size(72, 21);
            this.tb_max_price.TabIndex = 4;
            this.tb_max_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "~";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "원";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "모집할 제품의 가격 범위";
            // 
            // CrawlOptionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 137);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_max_price);
            this.Controls.Add(this.tb_min_price);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.bt_ok);
            this.Name = "CrawlOptionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "검색 조건";
            this.Load += new System.EventHandler(this.CrawlOptionDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_min_price;
        private System.Windows.Forms.TextBox tb_max_price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}