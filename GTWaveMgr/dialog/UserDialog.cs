using AnyBoBu.info;
using Awool;
using GTWave.info;
using HyperBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MindFusion.Swf.Tools;

namespace AnyBoBu.dialog
{
    public partial class UserDialog : Form
    {
        public  UserInfo    uInfo       = null;
        //public  string      mViewMode   = "add";
        public  MainFormV1  mForm       = null;

        public  UserDialog()
        {
            InitializeComponent();

			bt_dup_ck.Visible = false;
		}

		private void UserDialog_Load(object sender, EventArgs e)
        {
			Refresh();
		}

        public new void    Refresh() {
			var results = GlobalHelpers.mUserTb.Query()
				//.Where(x => x.site.StartsWith("J"))
				.OrderBy(x => x.mMemNm)
				//.Select(x => new { x.site, NameUpper = x.site.ToUpper() })
				//.Limit(10)
				.ToList();

			lv_user_list.Items.Clear();
			foreach (var user in results) {
				Debug.WriteLine(user.mMemNm);
				lv_user_list.Items.Add(user.getItem());

				//user.dispListView(lv_user_list);
			}
		}

        public  void    DispInfo() {
			tb_user_id.Text     = uInfo.mMemId;
			tb_user_pw.Text     = uInfo.mMemPw;
			tb_user_pw2.Text    = uInfo.mMemPw;

			cb_user_level.Text  = uInfo.mLevel;
			tb_user_nm.Text     = uInfo.mMemNm;
			tb_user_tel.Text    = uInfo.mPhone;
			tb_email.Text       = uInfo.mEmail;
			tb_desc.Text        = uInfo.mDesc;
		}

		private void bt_ok_Click(object sender, EventArgs e)
        {
			// 중복체크 
			if (DupCheck(tb_user_id.Text)) {
				// 패스워드 확인
				if (String.IsNullOrEmpty(tb_user_pw.Text)) {
					MessageBox.Show("암호가 없습니다.", "알림창");
					return;
				}

				if (!tb_user_pw.Text.Equals(tb_user_pw2.Text)) {
					MessageBox.Show("암호확인이 틀립니다.", "알림창");
					return;
				}
				uInfo = new UserInfo();
				uInfo.mMemId	= tb_user_id.Text;
				uInfo.mMemNm	= tb_user_nm.Text;
				uInfo.mLevel	= cb_user_level.Text;
				uInfo.mMemPw	= tb_user_pw.Text;
				uInfo.mPhone	= tb_user_tel.Text;
				uInfo.mEmail	= tb_email.Text;
				uInfo.mDesc		= tb_desc.Text;

				GlobalHelpers.mUserTb.Insert(uInfo);

				bt_dup_ck.Visible = false;

				Refresh();
			}
		}

		private void bt_close_Click(object sender, EventArgs e)
        {
			bt_dup_ck.Visible = false;
		}

		private void bt_url_link_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(tb_url.Text);
        }

		private void bt_close_Click_1(object sender, EventArgs e) {
			Close();
		}

		private void bt_user_add_Click(object sender, EventArgs e) {
			bt_dup_ck.Visible = true;

			uInfo   = new UserInfo();

            DispInfo();
			tb_user_id.Focus();
		}

		private void bt_dup_ck_Click(object sender, EventArgs e) {
			if (DupCheck(tb_user_id.Text)) {
				MessageBox.Show("사용가능한 아이디 입니다.", "알림창");
			}
		}

		public	bool	DupCheck(string id) { 

            if (String.IsNullOrEmpty(id)) {
				MessageBox.Show("아이디를 입력해 주세요.", "알림창");
                return false;
			}
            
			var results = GlobalHelpers.mUserTb.Query()
				.Where(x => x.mMemId.Equals(id))
				//.OrderBy(x => x.mMemNm)
				//.Select(x => new { x.site, NameUpper = x.site.ToUpper() })
				//.Limit(10)
				.ToList();

            if (results.Count > 0) {
                MessageBox.Show("이미 등록된 아이디 입니다.", "알림창");
				return false;
			}

			return true;
		}

		private void lv_user_list_SelectedIndexChanged(object sender, EventArgs e) {
			var senderList = (ListView)sender;
			if (senderList.SelectedItems.Count > 0) {
				ListView.SelectedListViewItemCollection items = senderList.SelectedItems;
				ListViewItem item = items[0];
				uInfo = (UserInfo)(item.Tag);

                DispInfo();
			}
		}

		private void bt_user_del_Click(object sender, EventArgs e) {
			if (lv_user_list.SelectedItems.Count > 0) {
				if (MessageBox.Show("선택하신 정보가 삭제됩니다", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes) {
					ListView.SelectedListViewItemCollection items = lv_user_list.SelectedItems;
					ListViewItem item = items[0];
					uInfo = (UserInfo)(item.Tag);

					//var value = new LiteDB.BsonValue(uInfo.mMemId);//id is an int parameter passed in
					GlobalHelpers.mUserTb.DeleteMany(x => x.mMemId.Equals(uInfo.mMemId));

					Refresh();
				} 
			}

		}
	}
}
