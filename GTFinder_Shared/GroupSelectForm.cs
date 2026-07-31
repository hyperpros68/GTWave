using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace GTFinder {
    public partial class GroupSelectForm : Form {
        public string SelectedGroup { get; private set; } = "";
        private ComboBox cbGroups;

        public GroupSelectForm(List<string> groups) {
            InitializeComponent(groups);
        }

        private void InitializeComponent(List<string> groups) {
            this.Text = "그룹 선택";
            this.Size = new Size(350, 200);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            Label lbl = new Label() {
                Text = "등록할 그룹을 선택하세요.",
                Location = new Point(20, 20),
                Size = new Size(300, 25),
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("맑은 고딕", 10F)
            };

            cbGroups = new ComboBox() {
                Location = new Point(20, 55),
                Size = new Size(290, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("맑은 고딕", 10F)
            };
            if (groups != null) {
                foreach (var g in groups) {
                    if (!string.IsNullOrEmpty(g)) cbGroups.Items.Add(g);
                }
                if (cbGroups.Items.Count > 0) cbGroups.SelectedIndex = 0;
            }

            Button btnOk = new Button() {
                Text = "확인",
                Location = new Point(115, 105),
                Size = new Size(100, 40),
                DialogResult = DialogResult.OK,
                Font = new Font("맑은 고딕", 10F, FontStyle.Bold)
            };
            btnOk.Click += (s, e) => {
                SelectedGroup = cbGroups.SelectedItem?.ToString() ?? "";
                this.Close();
            };

            this.Controls.Add(lbl);
            this.Controls.Add(cbGroups);
            this.Controls.Add(btnOk);
            this.AcceptButton = btnOk;
        }
    }
}
