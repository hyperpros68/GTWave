using System;
using System.Windows.Forms;
using System.Drawing;

namespace GTFinder {
    public partial class ProtocolSelectForm : Form {
        public string SelectedProtocol { get; private set; } = "";

        public ProtocolSelectForm() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            this.Text = "접속 방식 선택";
            this.Size = new System.Drawing.Size(300, 150);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblMessage = new Label();
            lblMessage.Text = "접속할 프로토콜을 선택하세요.";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Dock = DockStyle.Top;
            lblMessage.Height = 50;

            Button btnHttp = new Button();
            btnHttp.Text = "HTTP (80)";
            btnHttp.DialogResult = DialogResult.Yes; // Map Yes to HTTP
            btnHttp.Location = new Point(30, 60);
            btnHttp.Size = new Size(100, 30);
            btnHttp.Click += (s, e) => { SelectedProtocol = "http"; this.Close(); };

            Button btnHttps = new Button();
            btnHttps.Text = "HTTPS (443)";
            btnHttps.DialogResult = DialogResult.No; // Map No to HTTPS
            btnHttps.Location = new Point(150, 60);
            btnHttps.Size = new Size(100, 30);
            btnHttps.Click += (s, e) => { SelectedProtocol = "https"; this.Close(); };

            this.Controls.Add(btnHttp);
            this.Controls.Add(btnHttps);
            this.Controls.Add(lblMessage);
        }
    }
}
