using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnyBoBu.dialog
{
	public partial class AboutDialog : Form
	{
		public AboutDialog()
		{
			InitializeComponent();
			try
			{
				var bmp = global::GTWave.Properties.Resources.GTWave_CI;
				if (bmp != null)
				{
					var hIcon = bmp.GetHicon();
					this.Icon = Icon.FromHandle(hIcon);
				}
			}
			catch { }
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
