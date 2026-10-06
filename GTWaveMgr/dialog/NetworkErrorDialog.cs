using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnyBoBu.dialog
{
	public class NetworkErrorDialog : Form
	{
		private Label lblMessage;
		private PictureBox pbIcon;

		public NetworkErrorDialog()
		{
			InitializeCustomUI();
		}

		private void InitializeCustomUI()
		{
			this.Text = "네트워크 연결 오류";
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.StartPosition = FormStartPosition.CenterScreen;
			this.ClientSize = new Size(520, 260);
			this.BackColor = Color.FromArgb(255, 185, 193); // 연분홍색 배경
			this.TopMost = true;

			// 좌측 아이콘
			pbIcon = new PictureBox();
			pbIcon.Size = new Size(70, 70);
			pbIcon.Location = new Point(25, 45);
			pbIcon.SizeMode = PictureBoxSizeMode.Zoom;
			pbIcon.BackColor = Color.Transparent;
			pbIcon.Image = CreateErrorSwitchImage();
			this.Controls.Add(pbIcon);

			// 우측 메시지 레이블
			lblMessage = new Label();
			lblMessage.AutoSize = false;
			lblMessage.Location = new Point(115, 30);
			lblMessage.Size = new Size(380, 200);
			lblMessage.BackColor = Color.Transparent;
			lblMessage.ForeColor = Color.FromArgb(220, 0, 0); // 붉은색 텍스트
			lblMessage.Font = new Font("맑은 고딕", 10.5f, FontStyle.Bold);
			lblMessage.Text = "네트워크 연결이 끊어졌습니다.\n\n"
							+ "네트워크 연결을 확인해 주시기 바랍니다.\n\n"
							+ "진행 중인 모니터링을 잠시 멈춥니다.\n\n"
							+ "네트워크 연결이 복구되면 자동으로 실행합니다.";
			this.Controls.Add(lblMessage);
		}

		private Image CreateErrorSwitchImage()
		{
			Bitmap bmp = new Bitmap(70, 70);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

				// 허브/스위치 장비 그리기 (회색 사다리꼴 박스)
				Point[] switchBody = new Point[] {
					new Point(10, 25),
					new Point(60, 25),
					new Point(65, 45),
					new Point(5, 45)
				};
				using (SolidBrush brush = new SolidBrush(Color.FromArgb(170, 175, 185)))
				{
					g.FillPolygon(brush, switchBody);
				}
				using (Pen pen = new Pen(Color.FromArgb(90, 95, 105), 1.5f))
				{
					g.DrawPolygon(pen, switchBody);
				}

				// 스위치 앞면
				g.FillRectangle(new SolidBrush(Color.FromArgb(120, 125, 135)), 5, 45, 60, 10);
				g.DrawRectangle(new Pen(Color.FromArgb(80, 85, 95)), 5, 45, 60, 10);

				// 포트 램프들 (초록/주황 작은 점들)
				for (int i = 0; i < 6; i++)
				{
					g.FillRectangle(Brushes.LightGreen, 10 + (i * 9), 48, 4, 4);
				}

				// 굵은 빨간색 X 표시
				using (Pen redXPen = new Pen(Color.FromArgb(220, 20, 20), 7f))
				{
					redXPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
					redXPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
					g.DrawLine(redXPen, 15, 15, 55, 55);
					g.DrawLine(redXPen, 55, 15, 15, 55);
				}
			}
			return bmp;
		}
	}
}
