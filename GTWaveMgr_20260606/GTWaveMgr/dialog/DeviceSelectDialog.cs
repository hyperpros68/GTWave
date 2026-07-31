using AnyBoBu.info;
using AnyBoBu.utils;
using GTWave.info;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AnyBoBu.dialog
{
    public class DeviceSelectDialog : Form
    {
        private ListView lvDevices;
        private Button btnOk;
        private Button btnCancel;
        private TextBox tbSearch;
        private Label lblSearch;
        
        public DeviceInfo SelectedDevice { get; private set; }

        public DeviceSelectDialog()
        {
            InitializeComponent();
            LoadDevices();
        }

        private void InitializeComponent()
        {
            this.Text = "Device 선택";
            this.Size = new System.Drawing.Size(500, 600);
            this.StartPosition = FormStartPosition.CenterParent;

            lblSearch = new Label();
            lblSearch.Text = "검색:";
            lblSearch.Location = new Point(10, 15);
            lblSearch.Size = new Size(40, 20);

            tbSearch = new TextBox();
            tbSearch.Location = new Point(50, 12);
            tbSearch.Size = new Size(300, 21);
            tbSearch.TextChanged += TbSearch_TextChanged;

            lvDevices = new ListView();
            lvDevices.View = View.Details;
            lvDevices.FullRowSelect = true;
            lvDevices.GridLines = true;
            lvDevices.Location = new Point(10, 40);
            lvDevices.Size = new Size(460, 450);
            lvDevices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvDevices.Columns.Add("이름", 150);
            lvDevices.Columns.Add("IP", 120);
            lvDevices.Columns.Add("Type", 100);
            lvDevices.Columns.Add("장비명", 80);
            
            lvDevices.MouseDoubleClick += (s, e) => {
                if(lvDevices.SelectedItems.Count > 0) {
                    SelectedDevice = (DeviceInfo)lvDevices.SelectedItems[0].Tag;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };

            btnOk = new Button();
            btnOk.Text = "선택";
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(160, 510);
            btnOk.Anchor = AnchorStyles.Bottom;
            btnOk.Click += (s, e) => {
                if (lvDevices.SelectedItems.Count > 0)
                    SelectedDevice = (DeviceInfo)lvDevices.SelectedItems[0].Tag;
                else
                {
                    MessageBox.Show("장비를 선택해주세요.", "알림");
                    this.DialogResult = DialogResult.None;
                }
            };

            btnCancel = new Button();
            btnCancel.Text = "취소";
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(260, 510);
            btnCancel.Anchor = AnchorStyles.Bottom;

            this.Controls.Add(lblSearch);
            this.Controls.Add(tbSearch);
            this.Controls.Add(lvDevices);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
            
            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDevices(tbSearch.Text);
        }

        private void LoadDevices(string search = "")
        {
            lvDevices.Items.Clear();
            var results = GlobalHelpers.mDeviceTb.Query().OrderBy(x => x.name).ToList();
            if (!string.IsNullOrEmpty(search))
            {
                results = results.Where(x => (x.name != null && x.name.Contains(search)) || 
                                             (x.addr != null && x.addr.Contains(search))).ToList();
            }

            foreach (var device in results)
            {
                ListViewItem item = new ListViewItem(device.name ?? "");
                item.SubItems.Add(device.addr ?? "");
                item.SubItems.Add(device.type ?? "");
                item.SubItems.Add(device.groupNm ?? "");
                item.Tag = device;
                lvDevices.Items.Add(item);
            }
        }
    }
}
