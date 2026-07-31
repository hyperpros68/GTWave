using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Runtime.InteropServices;


namespace AnyLosk.widget {
    public partial class ProgressForm : Form {
        private static bool isCloseCall = false;
        private float angle = 0f;

        public static void Start() {
            System.Diagnostics.Process process = System.Diagnostics.Process.GetCurrentProcess();
            Control mainWindow = Control.FromHandle(process.MainWindowHandle);

            isCloseCall = false;
            Thread thread = new Thread(new ParameterizedThreadStart(ThreadShowWait));
            thread.Start(new object[] { mainWindow });
        }

        public static void Close(Form formFront) {
            isCloseCall = true;
            if(formFront != null && formFront.Handle != IntPtr.Zero)
            {
                SetForegroundWindow(formFront.Handle);
                formFront.BringToFront();
            }
        }
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private static void ThreadShowWait(object obj) {
            object[] objParam = obj as object[];
            ProgressForm progressForm = new ProgressForm();
            Control mainWindow = objParam[0] as Control;

            if (mainWindow != null) {
                progressForm.StartPosition = FormStartPosition.Manual;
                progressForm.Location = new Point(mainWindow.Location.X + (mainWindow.Width - progressForm.Width) / 2,
                    mainWindow.Location.Y + (mainWindow.Height - progressForm.Height) / 2);
            } else {
                progressForm.StartPosition = FormStartPosition.CenterParent;
            }
            progressForm.Show();
            progressForm.BringToFront();

            while (!isCloseCall) {
                if (progressForm != null && !progressForm.IsDisposed) {
                    try {
                        progressForm.UpdateAnimation();
                        Application.DoEvents();
                    } catch { }
                }
                Thread.Sleep(30);
            }

            if (progressForm != null && !progressForm.IsDisposed) {
                progressForm.CloseForce();
                progressForm = null;
            }
        }

        private bool cannotClose = true;

        public ProgressForm() {
            InitializeComponent();
            this.Opacity = 0.85f;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.BackColor = Color.White;
            //this.TransparencyKey = Color.White; 
            
            // PictureBox 설정
            this.pictureBox1.Image = null; // 기존 이미지 제거
            this.pictureBox1.Paint += PictureBox1_Paint;
            this.DoubleBuffered = true;
        }

        public void UpdateAnimation() {
            angle = (angle + 15f) % 360f;
            if(pictureBox1 != null && !pictureBox1.IsDisposed)
                pictureBox1.Invalidate();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e) {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            int size = Math.Min(pictureBox1.Width, pictureBox1.Height);
            int thickness = 8;
            int padding = 20;
            int diameter = size - (padding * 2);
            
            if (diameter <= 0) return;

            int x = (pictureBox1.Width - diameter) / 2;
            int y = (pictureBox1.Height - diameter) / 2;

            // Draw Background Circle (Optional, for better look)
            using (Pen bgPen = new Pen(Color.FromArgb(230, 230, 230), thickness)) {
                e.Graphics.DrawEllipse(bgPen, x, y, diameter, diameter);
            }

            // Draw Rotating Arc
            using (Pen pen = new Pen(Color.FromArgb(0, 122, 204), thickness)) // Modern Blue
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                e.Graphics.DrawArc(pen, x, y, diameter, diameter, angle, 240); // 240 degree arc
            }
        }

        protected override void OnClosing(CancelEventArgs e) {
            if (cannotClose) {
                e.Cancel = true;
                return;

            }
            base.OnClosing(e);
        }

        public void CloseForce() {
            cannotClose = false;
            this.Close();
        }
    }
}
