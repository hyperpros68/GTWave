using AnyBoBu.info;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace AnyBoBu.dialog
{
	public partial class ErrorPopupDialog : Form
	{
		private int mRemainingSeconds = 0;
		private Timer mAutoCloseTimer = null;

		public ErrorPopupDialog()
		{
			InitializeComponent();
		}

		public ErrorPopupDialog(List<DeviceInfo> errorDevices, int autoCloseSeconds, System.DateTime? occurTime = null)
		{
			InitializeComponent();

			System.DateTime dt = occurTime ?? System.DateTime.Now;
			CultureInfo koCulture = new CultureInfo("ko-KR");
			lblOccurTime.Text = $"발생시간: {dt.ToString("yyyy-MM-dd tt h:mm:ss", koCulture)}";

			PopulateDevices(errorDevices);

			if (autoCloseSeconds > 0)
			{
				mRemainingSeconds = autoCloseSeconds;
				mAutoCloseTimer = new Timer();
				mAutoCloseTimer.Interval = 1000;
				mAutoCloseTimer.Tick += AutoCloseTimer_Tick;
				mAutoCloseTimer.Start();
			}
		}

		private void PopulateDevices(List<DeviceInfo> devices)
		{
			pnlList.SuspendLayout();
			pnlList.Controls.Clear();

			int count = devices != null ? devices.Count : 0;
			int rowHeight = 22;
			int y = 2;

			if (devices != null)
			{
				foreach (var dev in devices)
				{
					Label lblGroup = new Label();
					lblGroup.AutoSize = false;
					lblGroup.Location = new Point(2, y);
					lblGroup.Size = new Size(120, rowHeight - 2);
					lblGroup.Font = new Font("맑은 고딕", 9F, FontStyle.Regular);
					lblGroup.ForeColor = Color.Black;
					lblGroup.BackColor = Color.Transparent;
					lblGroup.TextAlign = ContentAlignment.MiddleLeft;
					lblGroup.Text = dev.groupNm ?? "";

					Label lblSystem = new Label();
					lblSystem.AutoSize = false;
					lblSystem.Location = new Point(125, y);
					lblSystem.Size = new Size(230, rowHeight - 2);
					lblSystem.Font = new Font("맑은 고딕", 9F, FontStyle.Regular);
					lblSystem.ForeColor = Color.Black;
					lblSystem.BackColor = Color.Transparent;
					lblSystem.TextAlign = ContentAlignment.MiddleLeft;
					lblSystem.Text = $"{dev.name ?? ""}({dev.addr ?? ""})";

					pnlList.Controls.Add(lblGroup);
					pnlList.Controls.Add(lblSystem);

					y += rowHeight;
				}
			}

			pnlList.ResumeLayout();

			// 동적 창 높이 계산 (첨부 이미지의 1개일 때와 다수일 때의 형태 반영)
			int listHeight = Math.Max(24, Math.Min(y + 4, 220));
			pnlList.Height = listHeight;

			int clientHeight = 58 + listHeight + pnlBottom.Height;
			this.ClientSize = new Size(384, clientHeight);
		}

		private void AutoCloseTimer_Tick(object sender, EventArgs e)
		{
			mRemainingSeconds--;
			if (mRemainingSeconds <= 0)
			{
				if (mAutoCloseTimer != null)
				{
					mAutoCloseTimer.Stop();
					mAutoCloseTimer.Dispose();
					mAutoCloseTimer = null;
				}
				this.Close();
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ErrorPopupDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (mAutoCloseTimer != null)
			{
				mAutoCloseTimer.Stop();
				mAutoCloseTimer.Dispose();
				mAutoCloseTimer = null;
			}
		}
	}
}
