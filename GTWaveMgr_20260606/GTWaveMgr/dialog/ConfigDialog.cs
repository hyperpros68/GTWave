using AnyBoBu.info;
using Awool;
using GTWave.info;
using HyperBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
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

			SetValue();

			DispConfig();
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


			//string rgb = (string)bt_color_line_1_1.BackColor.ToString();
			string rgb = Convert.ToString(ColorTranslator.ToHtml(bt_color_line_1_1.BackColor));


			Debug.WriteLine(rgb);
		}

		private	void	DispConfig() {
			tb_color_back_1_1.BackColor = ColorTranslator.FromHtml((string)tb_color_back_1_1.Tag);
			tb_color_back_1_2.BackColor = ColorTranslator.FromHtml((string)tb_color_back_1_2.Tag);
			tb_color_back_2_1.BackColor = ColorTranslator.FromHtml((string)tb_color_back_2_1.Tag);
			tb_color_back_2_2.BackColor = ColorTranslator.FromHtml((string)tb_color_back_2_2.Tag);

			bt_color_line_1_1.BackColor = ColorTranslator.FromHtml((string)bt_color_line_1_1.Tag);
			bt_color_line_1_2.BackColor = ColorTranslator.FromHtml((string)bt_color_line_1_2.Tag);
			bt_color_line_2_1.BackColor = ColorTranslator.FromHtml((string)bt_color_line_2_1.Tag);
			bt_color_line_2_2.BackColor = ColorTranslator.FromHtml((string)bt_color_line_2_2.Tag);
		}

		private void	bt_close_Click(object sender, EventArgs e)
        {
            Close();
        }

		private void	bt_default_Click(object sender, EventArgs e) {
			SetValue();
		}

		private void	SetValue() {

			nud_sys_time_chk.Value		= Global.mConfigInfo.sysTimeCheck;
			nud_sys_timeout.Value		= Global.mConfigInfo.sysTimeout;
			nud_sys_pack_size.Value		= Global.mConfigInfo.sysPacketSize;

			tb_color_back_1_1.Tag		= Global.mConfigInfo.colorBack_1_1;
			tb_color_back_1_2.Tag		= Global.mConfigInfo.colorBack_1_2;
			nud_color_time_1.Value		= Global.mConfigInfo.colorTime_1;

			tb_color_back_2_1.Tag		= Global.mConfigInfo.colorBack_2_1;
			tb_color_back_2_2.Tag		= Global.mConfigInfo.colorBack_2_2;
			nud_color_time_2.Value		= Global.mConfigInfo.colorTime_2;

			bt_color_line_1_1.Tag		= Global.mConfigInfo.colorLine_1_1;
			bt_color_line_1_2.Tag		= Global.mConfigInfo.colorLine_1_2;
			bt_color_line_2_1.Tag		= Global.mConfigInfo.colorLine_2_1;
			bt_color_line_2_2.Tag		= Global.mConfigInfo.colorLine_2_2;

			cb_file_auto.Checked		= Global.mConfigInfo.fileAuto;
			tb_file_path.Text			= Global.mConfigInfo.filePath;

			cb_log_auto.Checked			= Global.mConfigInfo.logAuto;
			tb_log_path.Text			= Global.mConfigInfo.logPath;
			lb_log_name.Text			= Global.mConfigInfo.logName;

			cb_error_window.Checked		= Global.mConfigInfo.errorWindow;
			nud_erro_auto_close.Value	= Global.mConfigInfo.errorAutoClose;
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

			Global.mConfigInfo.colorLine_1_1	= (string)bt_color_line_1_1.Tag;
			Global.mConfigInfo.colorLine_1_2	= (string)bt_color_line_1_2.Tag;

			Global.mConfigInfo.colorLine_2_1	= (string)bt_color_line_2_1.Tag;
			Global.mConfigInfo.colorLine_2_2	= (string)bt_color_line_2_2.Tag;

			Global.mConfigInfo.fileAuto         = cb_file_auto.Checked;
			Global.mConfigInfo.filePath         = tb_file_path.Text;

			Global.mConfigInfo.logAuto          = cb_log_auto.Checked;
			Global.mConfigInfo.logPath          = tb_log_path.Text;
			Global.mConfigInfo.logName			= lb_log_name.Text;

			Global.mConfigInfo.errorWindow		= cb_error_window.Checked;
			Global.mConfigInfo.errorAutoClose	= Convert.ToInt32(nud_erro_auto_close.Value);
			Global.mConfigInfo.errorSound		= cb_error_sound.Checked;
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
