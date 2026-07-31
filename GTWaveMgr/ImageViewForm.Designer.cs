namespace AnyBoBu
{
    partial class ImageViewForm
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
            this.pb_image_view = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_image_view)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_image_view
            // 
            this.pb_image_view.Location = new System.Drawing.Point(12, 12);
            this.pb_image_view.Name = "pb_image_view";
            this.pb_image_view.Size = new System.Drawing.Size(1130, 1149);
            this.pb_image_view.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_image_view.TabIndex = 0;
            this.pb_image_view.TabStop = false;
            // 
            // ImageViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 1173);
            this.Controls.Add(this.pb_image_view);
            this.Name = "ImageViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImageViewForm";
            ((System.ComponentModel.ISupportInitialize)(this.pb_image_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pb_image_view;
    }
}