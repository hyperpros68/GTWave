using AnyBoBu.info;
using AnyLosk.widget;
using Awool;
using GTWave.info;
using HyperBase;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyBoBu.dialog
{
	public partial class OidListDialog : Form {
		public DeviceInfo	dInfo		= null;
		public OidTuple		oInfo		= null;
		public string		mViewMode	= "add";
		public MainFormV1	mForm		= null;

		public OidListDialog() {
			dInfo = new DeviceInfo(-1);
			InitializeComponent();
		}

		private void OidListDialog_Load(object sender, EventArgs e) {

			/*
			oInfo = new OidTuple(0);
			oInfo.desc = "0:kr; 1:eng";

			oInfo.valueParse("0:kr; 1:eng");
			string key = "1";
			string val = oInfo.dispValue(key);
			Debug.WriteLine($"{key} -> {val}");
			key = "2";
			val = oInfo.dispValue(key);
			Debug.WriteLine($"{key} -> {val}");
			*/

			DispOidList();

		}

		public void DispOidList() {
			tb_key.Text		= "";
			tb_disp_nm.Text = "";
			tb_oid.Text		= "";
			cb_type.SelectedIndex	= 0;
			tb_desc.Text	= "";
			tb_value.Text	= "";

			lv_oid_list.Items.Clear();

			var results = GlobalHelpers.mOidTupleTb.Query()
				.Where(x => x.deviceId.Equals(dInfo.id))
				.OrderBy(x => x.key)
				//.Select(x => new { x.site, NameUpper = x.site.ToUpper() })
				//.Limit(10)
				.ToList();

			foreach (var tuple in results) {
				//Debug.WriteLine(tuple.name);
				lv_oid_list.Items.Add(tuple.getItem());

				//user.dispListView(lv_user_list);
				//AddSystemNode(shapeList, system);
			}
		}

		private void bt_close_Click(object sender, EventArgs e) {
			Close();
		}

		private void lv_oid_list_SelectedIndexChanged(object sender, EventArgs e) {
			ListView list = (ListView)sender;
			if (list.SelectedItems.Count == 0)
				return;

			ListViewItem item = list.SelectedItems[0];
			oInfo = (OidTuple)(item.Tag);

			tb_key.Text		= oInfo.key;
			tb_disp_nm.Text = oInfo.name;
			tb_oid.Text		= oInfo.oid;
			cb_type.Text	= oInfo.type;
			tb_desc.Text	= oInfo.desc;
			tb_value.Text	= oInfo.value;

			// 이름은 수정을 하지 못하게
			//tb_key.Enabled = false;
			//tb_disp_nm.Focus();

			mViewMode = "fix";
		}

		private void bt_del_Click(object sender, EventArgs e) {
			if (lv_oid_list.SelectedItems.Count > 0) {
				if (MessageBox.Show("선택하신 정보가 삭제됩니다", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes) {
					ListView.SelectedListViewItemCollection items = lv_oid_list.SelectedItems;
					ListViewItem item = items[0];
					OidTuple info = (OidTuple)(item.Tag);

					//var value = new LiteDB.BsonValue(uInfo.mMemId);//id is an int parameter passed in
					GlobalHelpers.mOidTupleTb.DeleteMany(x => x.id.Equals(info.id));

					DispOidList();
				}
			} else {
				MessageBox.Show("삭제할 내용을 선택해 주세요", "알림창");
			}
		}

		private void bt_add_Click(object sender, EventArgs e) {
			oInfo = new OidTuple(dInfo.id);
			tb_key.Text		= oInfo.key;
			tb_disp_nm.Text = oInfo.name;
			tb_oid.Text		= oInfo.oid;
			cb_type.Text	= oInfo.type;
			tb_desc.Text	= oInfo.desc;
			tb_value.Text	= oInfo.value;

			tb_key.Focus();

			mViewMode = "add";
		}

		private void bt_apply_Click(object sender, EventArgs e) {
			if (oInfo == null) {
				MessageBox.Show("작업(추가, 수정)을 선택해 주세요.", "알림창");
				return;
			}

			try {
				if ("add".Equals(mViewMode)) {
					var results = GlobalHelpers.mOidTupleTb.Query()
						.Where(x => x.key.Equals(tb_key.Text) && x.deviceId == dInfo.id)
						.ToList();

					if (results.Count > 0) {
						MessageBox.Show("같은 키값이 존재 합니다. 키값을 수정해 주세요.", "알림창");
						tb_key.Focus();
						return;
					}

					oInfo.key	= tb_key.Text;
					oInfo.name	= tb_disp_nm.Text;
					oInfo.oid	= tb_oid.Text;
					oInfo.desc	= tb_desc.Text;
					oInfo.type	= cb_type.Text;
					oInfo.value = tb_value.Text;

					//pb_system_image.Image = mSystemInfo.image;

					// DB add
					GlobalHelpers.mOidTupleTb.Insert(oInfo);

					lv_oid_list.Items.Add(oInfo.getItem());
					MessageBox.Show("정상적으로 추가 되었습니다.", "알림창");
				} else if ("fix".Equals(mViewMode)) {
					/*
					var results = GlobalHelpers.mSystemTb.Query()
						.Where(x => x.name.Equals(tb_system_name.Text))
						.ToList();

					if (results.Count > 0) {
						MessageBox.Show("같은 이름이 존재 합니다. 이름을 수정해 주세요.", "알림창");
						tb_system_name.Focus();
						return;
					}
                    */
					oInfo.key	= tb_key.Text;
					oInfo.name	= tb_disp_nm.Text;
					oInfo.oid	= tb_oid.Text;
					oInfo.type	= cb_type.Text;
					oInfo.desc	= tb_desc.Text;
					oInfo.value = tb_value.Text;

					GlobalHelpers.mOidTupleTb.Update(oInfo);
					DispOidList();
				}
			} catch (Exception ex) {
				MessageBox.Show("적용이 실패 했습니다. 다시 시도해 주세요.", "알림창");
			}
		}

		private void bt_save_Click(object sender, EventArgs e) {
			string mSaveFile = "";
			StreamWriter mSaveHandle = null;

			System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(System.Windows.Forms.Application.StartupPath + @"\\..\\data");
			saveFileDialog.InitialDirectory = di.FullName;
			saveFileDialog.FileName = "OIDTemplete_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
			saveFileDialog.Filter = "oid data|*.txt";
			saveFileDialog.Title = "Save an OID Templete File";
			if (saveFileDialog.ShowDialog() == DialogResult.OK) {
				mSaveFile = saveFileDialog.FileName;
				if (mSaveHandle != null) {
					mSaveHandle.Close();
				}
				Thread.Sleep(200);
				mSaveHandle = new StreamWriter(mSaveFile);
				foreach (ListViewItem item in lv_oid_list.Items) {
					OidTuple info = (OidTuple)item.Tag;
					mSaveHandle.WriteLine(info.getString());
				}
				mSaveHandle.Close();

				Debug.WriteLine($"-------{mSaveFile}---------------");
			} else {
				MessageBox.Show("저장 작업을 취소합니다.");
				return;
			}
		}

		private void OidListDialog_Shown(object sender, EventArgs e) {
			lv_oid_list.Focus();
			if (lv_oid_list.Items.Count > 0) {
				lv_oid_list.Items[0].Focused = true;
				lv_oid_list.Items[0].Selected = true;
			}
		}

		private void lv_oid_list_MouseDoubleClick(object sender, MouseEventArgs e) {
			var senderList = (ListView)sender;
			if (senderList.SelectedItems.Count > 0) {
				ListView.SelectedListViewItemCollection items = senderList.SelectedItems;
				ListViewItem item = items[0];
				oInfo = (OidTuple)(item.Tag);

				tb_key.Enabled = false;

				tb_key.Text		= oInfo.key;
				tb_disp_nm.Text = oInfo.name;
				tb_oid.Text		= oInfo.oid;
				cb_type.Text	= oInfo.type;
				tb_desc.Text	= oInfo.value;
				tb_value.Text	= oInfo.desc;

				tb_disp_nm.Focus();
			}
		}

		private void bt_load_Click(object sender, EventArgs e) {
			System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(System.Windows.Forms.Application.StartupPath + @"\\..\\data");
			using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog()) {
				openFileDialog.InitialDirectory = di.FullName;
				openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;

				if (openFileDialog.ShowDialog() == DialogResult.OK) {
					//Get the path of specified file
					//ProgressForm.Start();

					if (MessageBox.Show("현재 내용은 삭제됩니다\n계속 진행 하시겠습니다까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes) {

						// 내용 삭제
						GlobalHelpers.mOidTupleTb.DeleteMany(x => x.deviceId.Equals(dInfo.id));

						Debug.WriteLine($"FileName = {openFileDialog.FileName}");
						using (StreamReader sr = new StreamReader(openFileDialog.FileName)) {
							string line = "null";
							lv_oid_list.Items.Clear();
							while (line != null) {
								line = sr.ReadLine();
								if (line == null || line.Length < 10)
									continue;
								Debug.WriteLine($"line = {line}");

								OidTuple tuple = new OidTuple(dInfo.id);
								tuple.setParse(line);
								if (!tuple.valid()) continue;

								GlobalHelpers.mOidTupleTb.Insert(tuple);
								lv_oid_list.Items.Add(tuple.getItem());

								Debug.WriteLine($"OID Tuple -> {tuple.key}:{tuple.name}{tuple.oid}");
							}
						}
					}
				}
			}
		}
	}
}
