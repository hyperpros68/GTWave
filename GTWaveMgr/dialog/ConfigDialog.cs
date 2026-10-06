using AnyBoBu.info;
using Awool;
using GTWave.info;
using HyperBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AnyBoBu.dialog
{
    public partial class ConfigDialog : Form
    {
        public  GroupInfo   gInfo       = null;

		public  string      mViewMode   = "add";
        public  MainFormV1  mForm       = null;

        public ConfigDialog()
        {
            InitializeComponent();
        }

        private void ConfigDialog_Load(object sender, EventArgs e)
        {
			nud_sys_pack_size.Padding = new System.Windows.Forms.Padding(50,15,0,5);

			UpdateAutoCloseRange();

			Action<TextBox> setupColorBox = (tb) => {
				tb.Enabled = true;
				tb.ReadOnly = true;
				tb.Cursor = Cursors.Hand;
				tb.Click += (s, ev) => {
					using (ColorDialog cd = new ColorDialog()) {
						if (!string.IsNullOrEmpty((string)tb.Tag)) {
							try { cd.Color = ColorTranslator.FromHtml((string)tb.Tag); } catch { }
						}
						if (cd.ShowDialog() == DialogResult.OK) {
							string hex = ColorTranslator.ToHtml(cd.Color);
							tb.Tag = hex;
							tb.BackColor = cd.Color;
						}
					}
				};
			};
			setupColorBox(tb_color_back_1_1);
			setupColorBox(tb_color_back_1_2);
			setupColorBox(tb_color_back_2_1);
			setupColorBox(tb_color_back_2_2);

			SetValue();

			DispConfig();

			nud_sys_time_chk.ValueChanged += Nud_sys_time_chk_ValueChanged;
			/*
			if (mViewMode.Equals("fix")) {
                tb_root.Text        = gInfo.rootName;
				tb_agent.Text = gInfo.agent;
				tb_desc.Text = gInfo.desc;
				tb_group_nm.Text    = gInfo.name;
            } else {
                if (gInfo == null) {
                    tb_root.Text = "루트";
                } else {
                    tb_root.Text = gInfo.name;
                }
            }
            */
		}

		private void UpdateAutoCloseRange()
		{
			// 입력할 수 있는 범위 : 0~시스템 체크시간 -2초
			int maxLimit = Math.Max(0, (int)nud_sys_time_chk.Value - 2);
			nud_erro_auto_close.Minimum = 0;
			nud_erro_auto_close.Maximum = maxLimit;
			if (nud_erro_auto_close.Value > maxLimit)
			{
				nud_erro_auto_close.Value = maxLimit;
			}
		}

		private void Nud_sys_time_chk_ValueChanged(object sender, EventArgs e)
		{
			UpdateAutoCloseRange();
		}

		private	void	DispConfig() {
			if (!string.IsNullOrEmpty((string)tb_color_back_1_1.Tag))
				tb_color_back_1_1.BackColor = ColorTranslator.FromHtml((string)tb_color_back_1_1.Tag);
			if (!string.IsNullOrEmpty((string)tb_color_back_1_2.Tag))
				tb_color_back_1_2.BackColor = ColorTranslator.FromHtml((string)tb_color_back_1_2.Tag);
			if (!string.IsNullOrEmpty((string)tb_color_back_2_1.Tag))
				tb_color_back_2_1.BackColor = ColorTranslator.FromHtml((string)tb_color_back_2_1.Tag);
			if (!string.IsNullOrEmpty((string)tb_color_back_2_2.Tag))
				tb_color_back_2_2.BackColor = ColorTranslator.FromHtml((string)tb_color_back_2_2.Tag);
		}

		private void	bt_close_Click(object sender, EventArgs e)
        {
            Close();
        }

		private void	bt_default_Click(object sender, EventArgs e) {
			Global.mConfigInfo.ResetDefault();
			SetValue();
			DispConfig();
		}

		private void	SetValue() {

			nud_sys_time_chk.Value		= Global.mConfigInfo.sysTimeCheck;
			nud_sys_timeout.Value		= Global.mConfigInfo.sysTimeout;
			nud_sys_pack_size.Value		= Global.mConfigInfo.sysPacketSize;

			string c1_1 = Global.mConfigInfo.colorBack_1_1;
			if (string.IsNullOrWhiteSpace(c1_1) || "#ff31ca".Equals(c1_1, StringComparison.OrdinalIgnoreCase)) c1_1 = "#808080";
			tb_color_back_1_1.Tag		= c1_1;

			string c1_2 = Global.mConfigInfo.colorBack_1_2;
			if (string.IsNullOrWhiteSpace(c1_2) || "#ff31ca".Equals(c1_2, StringComparison.OrdinalIgnoreCase)) c1_2 = "#00FF00";
			tb_color_back_1_2.Tag		= c1_2;

			nud_color_time_1.Value		= Global.mConfigInfo.colorTime_1;

			string c2_1 = Global.mConfigInfo.colorBack_2_1;
			if (string.IsNullOrWhiteSpace(c2_1) || "#ff31ca".Equals(c2_1, StringComparison.OrdinalIgnoreCase)) c2_1 = "#FFA500";
			tb_color_back_2_1.Tag		= c2_1;

			string c2_2 = Global.mConfigInfo.colorBack_2_2;
			if (string.IsNullOrWhiteSpace(c2_2) || "#ff31ca".Equals(c2_2, StringComparison.OrdinalIgnoreCase)) c2_2 = "#FF0000";
			tb_color_back_2_2.Tag		= c2_2;

			nud_color_time_2.Value		= Global.mConfigInfo.colorTime_2;

			cb_file_auto.Checked		= Global.mConfigInfo.fileAuto;
			tb_file_path.Text			= string.IsNullOrWhiteSpace(Global.mConfigInfo.filePath)
				? ConfigInfo.GetDefaultFilePath()
				: Global.mConfigInfo.filePath;

			cb_log_auto.Checked			= Global.mConfigInfo.logAuto;
			string curLogPath			= Global.mConfigInfo.logPath;
			if (string.IsNullOrWhiteSpace(curLogPath) || curLogPath.Contains(@"bin\log"))
				curLogPath = ConfigInfo.GetDefaultLogPath();
			tb_log_path.Text			= curLogPath;
			lb_log_name.Text			= Global.mConfigInfo.logName;

			cb_error_window.Checked		= Global.mConfigInfo.errorWindow;

			UpdateAutoCloseRange();
			int maxSec = Math.Max(0, (int)nud_sys_time_chk.Value - 2);
			int closeVal = Global.mConfigInfo.errorAutoClose;
			if (closeVal < 0) closeVal = 0;
			if (closeVal > maxSec) closeVal = maxSec;
			nud_erro_auto_close.Value	= closeVal;

			cb_error_sound.Checked		= Global.mConfigInfo.errorSound;
		}

		private void bt_save_ok_Click(object sender, EventArgs e) {
			Global.mConfigInfo.sysTimeCheck     = Convert.ToInt32(nud_sys_time_chk.Value);
			Global.mConfigInfo.sysTimeout       = Convert.ToInt32(nud_sys_timeout.Value);
			Global.mConfigInfo.sysPacketSize    = Convert.ToInt32(nud_sys_pack_size.Value);

			Global.mConfigInfo.colorBack_1_1    = (string)tb_color_back_1_1.Tag;
			Global.mConfigInfo.colorBack_1_2    = (string)tb_color_back_1_2.Tag;
			Global.mConfigInfo.colorTime_1      = Convert.ToInt32(nud_color_time_1.Value);

			Global.mConfigInfo.colorBack_2_1    = (string)tb_color_back_2_1.Tag;
			Global.mConfigInfo.colorBack_2_2    = (string)tb_color_back_2_2.Tag;
			Global.mConfigInfo.colorTime_2      = Convert.ToInt32(nud_color_time_2.Value);

			Global.mConfigInfo.fileAuto         = cb_file_auto.Checked;
			Global.mConfigInfo.filePath         = tb_file_path.Text;

			Global.mConfigInfo.logAuto          = cb_log_auto.Checked;
			Global.mConfigInfo.logPath          = tb_log_path.Text;
			Global.mConfigInfo.logName			= lb_log_name.Text;

			Global.mConfigInfo.errorWindow		= cb_error_window.Checked;
			Global.mConfigInfo.errorAutoClose	= Convert.ToInt32(nud_erro_auto_close.Value);
			Global.mConfigInfo.errorSound		= cb_error_sound.Checked;

			Global.mConfigInfo.Save(Const.gCfgFile);
			Close();
		}

		private void bt_file_select_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog fbd = new FolderBrowserDialog())
			{
				fbd.Description = "구성도 저장 폴더를 선택하세요.";
				if (!string.IsNullOrWhiteSpace(tb_file_path.Text) && Directory.Exists(tb_file_path.Text))
				{
					fbd.SelectedPath = tb_file_path.Text;
				}
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					tb_file_path.Text = fbd.SelectedPath;
				}
			}
		}

		private void bt_log_select_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog fbd = new FolderBrowserDialog())
			{
				fbd.Description = "로그 저장 폴더를 선택하세요.";
				if (!string.IsNullOrWhiteSpace(tb_log_path.Text) && Directory.Exists(tb_log_path.Text))
				{
					fbd.SelectedPath = tb_log_path.Text;
				}
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					tb_log_path.Text = fbd.SelectedPath;
				}
			}
		}

		private void bt_color_cus_1_Click(object sender, EventArgs e) {
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK) {
				bt_color_line_1_2.BackColor = cd.Color;
				bt_color_line_1_2.Tag = Convert.ToString(ColorTranslator.ToHtml(cd.Color));
			}
		}

		private void bt_color_line_1_1_Click(object sender, EventArgs e) {
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK) {
				bt_color_line_1_1.BackColor = cd.Color;
				bt_color_line_1_2.Tag = Convert.ToString(ColorTranslator.ToHtml(cd.Color));
			}
		}

		private void bt_color_line_1_2_Click(object sender, EventArgs e) {
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK) {
				bt_color_line_1_2.BackColor = cd.Color;
				bt_color_line_1_2.Tag = Convert.ToString(ColorTranslator.ToHtml(cd.Color));
			}
		}

		private void bt_color_line_2_1_Click(object sender, EventArgs e) {
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK) {
				bt_color_line_2_1.BackColor = cd.Color;
				bt_color_line_1_2.Tag = Convert.ToString(ColorTranslator.ToHtml(cd.Color));
			}
		}

		private void bt_color_line_2_2_Click(object sender, EventArgs e) {
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK) {
				bt_color_line_2_2.BackColor = cd.Color;
				bt_color_line_1_2.Tag = Convert.ToString(ColorTranslator.ToHtml(cd.Color));
			}
		}
	}
}
