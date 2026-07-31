namespace GTWave {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
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
			this.control = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// control
			// 
			this.control.HideSelection = false;
			this.control.Location = new System.Drawing.Point(58, 31);
			this.control.Name = "control";
			this.control.Size = new System.Drawing.Size(632, 233);
			this.control.TabIndex = 0;
			this.control.TileSize = new System.Drawing.Size(28, 28);
			this.control.UseCompatibleStateImageBehavior = false;
			this.control.View = System.Windows.Forms.View.Tile;
			this.control.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.Control_DrawColumnHeader);
			this.control.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.control_DrawItem);
			this.control.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.Control_DrawSubItem);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.control);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView control;
	}
}