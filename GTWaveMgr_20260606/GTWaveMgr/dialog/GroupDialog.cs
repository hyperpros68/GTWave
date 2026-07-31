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

namespace AnyBoBu.dialog
{
    public partial class GroupDialog : Form
    {
        public  GroupInfo   gInfo       = null;
		public  TreeView    tView       = null;
		public  string      mViewMode   = "add";
        public  MainFormV1  mForm       = null;

        public GroupDialog(TreeView view)
        {
            this.tView  = view;
            InitializeComponent();
        }

        private void GroupDialog_Load(object sender, EventArgs e)
        {
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
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            // Group 명이 있는지....
            if (String.IsNullOrEmpty(tb_group_nm.Text)) {
                MessageBox.Show("그룹명을 입력해 주세요", "알림창");
                return;
            }

            if (mViewMode.Equals("fix")) {
                // DB update

                // tree update
                if (gInfo.node != null) {

                    // 같은 이름이 있는지 검사....
                    if (gInfo.node.Parent != null) {
						TreeNode node = gInfo.node.Parent;
						while (node != null) {
							if (node.Text.Equals(tb_group_nm.Text)) {
								MessageBox.Show("같은 이름이 존재 합니다.", "알림창");
								return;
							}

							if (gInfo.node.LastNode == node) {
								break;
							}

							node = node.NextNode;
						}
					} else {
						// 처음 노드로 이동
						TreeNode node   = gInfo.node.PrevNode;
						TreeNode pNode  = null;
						while (node != null) {
                            pNode   = node;
							node    = node.PrevNode;
						}

						// 처음부터 뒤져서 자기가 아니고 같은 이름이 있으면
						node = pNode;
						while (node != null) {
							if (node.Text.Equals(tb_group_nm.Text)) {
                                // 자기인지 확인
                                if (node != gInfo.node) {
								    MessageBox.Show("같은 이름이 존재 합니다.", "알림창");
								    return;
								}
							}
							node = node.NextNode;
						}
					}

					string oldPath = "";
					if (mForm != null) oldPath = mForm.GetNodePath(gInfo.node);

					gInfo.name  = tb_group_nm.Text;
					gInfo.agent = tb_agent.Text;
					gInfo.desc  = tb_desc.Text;
					gInfo.node.Text = tb_group_nm.Text;

					if (mForm != null) {
						string newPath = mForm.GetNodePath(gInfo.node);
						mForm.UpdateGroupPath(oldPath, newPath);
						mForm.SaveTree(tView, "group.mvia");
					}
				}
				Close();
				return;
            }

		    if (gInfo == null) {
                //같은 이름의 그룹이 있는지 확인
                //mNode.Nodes

				gInfo   = new GroupInfo(tb_group_nm.Text);
                gInfo.agent = tb_agent.Text;
				gInfo.desc  = tb_desc.Text;

				TreeNode node = tView.Nodes.Add(tb_group_nm.Text);
                node.Tag = gInfo;
                //node.Tag = tb_group_nm.Text;
				gInfo.node = node;

				//GlobalHelpers.mGroupTb.Insert(gInfo);
			} else {
                if (gInfo.node != null) {
                    // 같은 이름이 있는지
                    TreeNode node = gInfo.node.FirstNode;
					while (node != null) {
                        if (node.Text.Equals(tb_group_nm.Text)) {
                            MessageBox.Show("같은 이름이 존재 합니다.", "알림창");
                            return;
                        }

                        if (gInfo.node.LastNode == node) {
                            break;
                        }

                        node = node.NextNode;
                    }
					node = gInfo.node.Nodes.Add(tb_group_nm.Text);
					GroupInfo childInfo = new GroupInfo(tb_group_nm.Text);
					childInfo.name  = tb_group_nm.Text;
					childInfo.agent = tb_agent.Text;
					childInfo.desc  = tb_desc.Text;

					node.Tag    = childInfo;
                    childInfo.node = node;
				}
			}

            
            // 정보 저장
            /*
            if (MessageBox.Show("수집 정보를 등록합니다..", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                Close();
            } else Close();
            */
			if (mForm != null) {
				mForm.SaveTree(tView, "group.mvia");
			}
			Close();
		}

        private void bt_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_url_link_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(tb_url.Text);
        }
    }
}
