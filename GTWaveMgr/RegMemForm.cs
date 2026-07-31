using AnyBoBu.info;
using BoBuAI.info;
using HyperBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyBoBu
{
    public partial class RegMemForm : Form
    {
        static public string trans_result;

        UserInfo    memInfo     = new UserInfo();
        string      mViewMode   = "add";
        //public      MemberForm  memberForm  = null;


        public  RegMemForm()
        {
            InitializeComponent();
        }

        public  void    setMemberInfo(UserInfo mInfo)
        {
            memInfo     = mInfo;
            mViewMode   = "fix";
        }

        private void RegMemForm_Load(object sender, EventArgs e)
        {
            sc_card.Panel1Collapsed = true;

            cb_store_kind.Items.Clear();
            cb_store_kind.SelectedIndex = 0;

            if (mViewMode == "fix") {
            /*
                cb_store_kind.Text  = memInfo.mMemKind; 
                tb_mem_name.Text    = memInfo.mMemName;
                tb_phone.Text       = memInfo.mPhone;


                tb_mem_id.Text      = memInfo.mMemId;
                tb_mem_pw.Text      = memInfo.mMemPw;
                tb_email.Text       = memInfo.mEmail;
                tb_biz_no.Text      = memInfo.mBizNo;
                tb_agent.Text       = memInfo.mAgent;
                */
                /*
				tb_host_addr.Text = memInfo.mHostAddr;
				tb_host_port.Text = memInfo.mHostPort.ToString();
				tb_host_ext.Text = memInfo.mHostExt;
				tb_vender_id.Text   = memInfo.mVenId;
                tb_access_key.Text  = memInfo.mAccKey;
                tb_secret_key.Text  = memInfo.mSecKey;

                tb_src_key.Text     = memInfo.mSrcKey;
                tb_src_id.Text      = memInfo.mSrcId;
                tb_src_pw.Text      = memInfo.mSrcPw;

                cb_bank.Text        = memInfo.mBank;
                tb_account.Text     = memInfo.mAccount;
                tb_owner.Text       = memInfo.mOwner;
                tb_comment.Text     = memInfo.mComment;
                */
                bt_dup_check.Visible = false;
            }
        }

        private void bt_save_card_Click(object sender, EventArgs e)
        {
            sc_card.Panel1Collapsed = true;
        }

        private void bt_reg_card_Click(object sender, EventArgs e)
        {
            sc_card.Panel1Collapsed = false;
        }

        private void bt_close_card_Click(object sender, EventArgs e)
        {
            sc_card.Panel1Collapsed = true;
        }

        private void bt_close_member_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_save_member_Click(object sender, EventArgs e)
        {
            // 정보 저장
            /*
            memInfo.mMemKind    = cb_store_kind.Text;
            memInfo.mMemName    = tb_mem_name.Text;
            memInfo.mMemId      = tb_mem_id.Text;
            memInfo.mMemPw      = tb_mem_pw.Text;

            memInfo.mPhone      = tb_phone.Text;
            memInfo.mEmail      = tb_email.Text;
			memInfo.mBizNo = tb_biz_no.Text;
			memInfo.mAgent = tb_agent.Text;
            */
            /*
			memInfo.mHostAddr   = tb_host_addr.Text;
            Int32.TryParse(tb_host_port.Text, out memInfo.mHostPort);
            memInfo.mHostExt    = tb_host_ext.Text;
            

            memInfo.mVenId      = tb_vender_id.Text;
            memInfo.mAccKey     = tb_access_key.Text;
            memInfo.mSecKey     = tb_secret_key.Text;

            memInfo.mSrcKey     = tb_src_key.Text;
            memInfo.mSrcId      = tb_src_id.Text;
            memInfo.mSrcPw      = tb_src_pw.Text;

            memInfo.mBank       = cb_bank.Text;
            memInfo.mAccount    = tb_account.Text;
            memInfo.mOwner      = tb_owner.Text;
            memInfo.mComment    = tb_comment.Text;
            */
            if (mViewMode == "fix")
            {
                if (MessageBox.Show("내용을 수정하시겠습니까?.", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                /*
                    if (memInfo.fixCheck(Global.mMySQL.mysql, memInfo.mMemIdx, memInfo.mMemKind, memInfo.mMemId))
                    {
                        MessageBox.Show("이미 있는 ID입니다..", "알림");
                    }
                    else
                    {
                        memInfo.fixInfo(Global.mMySQL.mysql);
                        // parents refresh
                        if (memberForm != null)     memberForm.RefreshMember();
                        Close();
                    }
                    */
                }
                return;
            }

            if (MessageBox.Show("멤버를 등록합니다..", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
            /*
                if (memInfo.dupCheck(Global.mMySQL.mysql, memInfo.mMemKind, memInfo.mMemId)) {
                    MessageBox.Show("이미 있는 ID입니다..", "알림");
                } else {
                    memInfo.addInfo(Global.mMySQL.mysql);
                    // parents refresh
                    if (memberForm != null)     memberForm.RefreshMember();
                    Close();
                }
                */
            }
        }

        private void bt_dup_check_Click(object sender, EventArgs e)
        {
        /*
            if (memInfo.dupCheck(Global.mMySQL.mysql, cb_store_kind.Text, tb_mem_id.Text)) {
                MessageBox.Show("이미 있는 ID입니다..", "알림");
            } else {
                MessageBox.Show("사용 가능한 ID입니다..", "알림");
            }
            */
        }

        static async Task Exec(string url)
        {
            HttpClient _httpClient = new HttpClient();

            var parameters = new Dictionary<string, string>();
            //parameters.Add("message", "안녕하세요");
            var encodedContent = new FormUrlEncodedContent(parameters);

            var response = await _httpClient.PostAsync(url, encodedContent).ConfigureAwait(false);
            var content = await response.Content.ReadAsByteArrayAsync();
            Console.WriteLine(content);
            trans_result = Encoding.UTF8.GetString(content);
            
        }

        private void bt_check_id_Click(object sender, EventArgs e)
        {
        /*
            string httpUrl = string.Format("http://localhost:8091/check_id?memIdx={0}",memInfo.mMemName);
            // Console.WriteLine($" -------- HTTPS ------------"); 
            // Test(httpUrl).GetAwaiter().GetResult();  
            // Main함수에서 await Test(httpsUrl) 사용못하므로, 이를 대신함            
            Console.WriteLine($"\n\n\n --------- HTTP {httpUrl}------------");
            try {
                Exec(httpUrl).GetAwaiter().GetResult();
            } catch {
                MessageBox.Show("접속정보를 확인해 주세요", "알림창", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Console.WriteLine(trans_result);
            MessageBox.Show(trans_result, "접속 체크", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Console.WriteLine($" ---------- END ------------");
            */
        }
    }
}
