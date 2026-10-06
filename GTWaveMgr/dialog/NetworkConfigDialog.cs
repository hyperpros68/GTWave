using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AnyBoBu.dialog
{
	public partial class NetworkConfigDialog : Form
	{
		public class NicItemInfo
		{
			public string Name { get; set; }
			public string Description { get; set; }
			public string MacAddress { get; set; }
			public List<string> IpAddresses { get; set; } = new List<string>();
			public NetworkInterface Interface { get; set; }

			public override string ToString()
			{
				return !string.IsNullOrEmpty(Description) ? Description : (Name ?? "Unknown Adapter");
			}
		}

		private const string REG_SUBKEY = @"Software\Awool\GTWaveMgr";

		public NetworkConfigDialog()
		{
			InitializeComponent();
		}

		private void NetworkConfigDialog_Load(object sender, EventArgs e)
		{
			LoadNetworkInterfaces();
		}

		private void LoadNetworkInterfaces()
		{
			try
			{
				cb_nic_card.Items.Clear();

				// 레지스트리에서 이전 설정 읽기
				string savedNicDesc = "";
				string savedNicIp = "";
				try
				{
					using (RegistryKey key = Registry.CurrentUser.OpenSubKey(REG_SUBKEY))
					{
						if (key != null)
						{
							savedNicDesc = key.GetValue("SelectedNicDesc", "").ToString();
							savedNicIp = key.GetValue("SelectedNicIp", "").ToString();
						}
					}
				}
				catch { }

				// 시스템의 모든 네트워크 인터페이스 조회
				var interfaces = NetworkInterface.GetAllNetworkInterfaces()
					.Where(nic => nic.NetworkInterfaceType != NetworkInterfaceType.Loopback
							   && nic.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
					.OrderByDescending(nic => nic.OperationalStatus == OperationalStatus.Up)
					.ToList();

				int selectIndex = -1;

				for (int i = 0; i < interfaces.Count; i++)
				{
					var nic = interfaces[i];
					var item = new NicItemInfo
					{
						Name = nic.Name,
						Description = nic.Description,
						MacAddress = nic.GetPhysicalAddress().ToString(),
						Interface = nic
					};

					// IPv4 주소 목록 추출
					try
					{
						var ipProps = nic.GetIPProperties();
						foreach (var u in ipProps.UnicastAddresses)
						{
							if (u.Address.AddressFamily == AddressFamily.InterNetwork)
							{
								item.IpAddresses.Add(u.Address.ToString());
							}
						}
					}
					catch { }

					if (item.IpAddresses.Count == 0)
					{
						item.IpAddresses.Add("0.0.0.0");
					}

					cb_nic_card.Items.Add(item);

					// 이전에 저장된 NIC와 일치하는지 확인
					if (!string.IsNullOrEmpty(savedNicDesc) && item.Description == savedNicDesc)
					{
						selectIndex = i;
					}
				}

				if (cb_nic_card.Items.Count > 0)
				{
					cb_nic_card.SelectedIndex = selectIndex >= 0 ? selectIndex : 0;

					// 저장된 IP가 있으면 해당 IP 선택
					if (!string.IsNullOrEmpty(savedNicIp) && cb_nic_ip.Items.Contains(savedNicIp))
					{
						cb_nic_ip.SelectedItem = savedNicIp;
					}
				}
				else
				{
					lbl_nic_mac.Text = "-";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("네트워크 인터페이스 정보를 불러오는 중 오류가 발생했습니다.\n" + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cb_nic_card_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (cb_nic_card.SelectedItem is NicItemInfo selectedNic)
				{
					cb_nic_ip.Items.Clear();
					foreach (var ip in selectedNic.IpAddresses)
					{
						cb_nic_ip.Items.Add(ip);
					}

					if (cb_nic_ip.Items.Count > 0)
					{
						cb_nic_ip.SelectedIndex = 0;
					}

					lbl_nic_mac.Text = !string.IsNullOrEmpty(selectedNic.MacAddress) ? selectedNic.MacAddress : "000000000000";
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("cb_nic_card_SelectedIndexChanged error: " + ex.Message);
			}
		}

		private void btn_save_Click(object sender, EventArgs e)
		{
			try
			{
				if (cb_nic_card.SelectedItem is NicItemInfo selectedNic)
				{
					string selectedIp = cb_nic_ip.Text;
					string mac = lbl_nic_mac.Text;

					using (RegistryKey key = Registry.CurrentUser.CreateSubKey(REG_SUBKEY))
					{
						if (key != null)
						{
							key.SetValue("SelectedNicDesc", selectedNic.Description ?? "");
							key.SetValue("SelectedNicName", selectedNic.Name ?? "");
							key.SetValue("SelectedNicIp", selectedIp ?? "");
							key.SetValue("SelectedNicMac", mac ?? "");
							key.Close();
						}
					}
				}

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("설정 저장 중 오류가 발생했습니다.\n" + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btn_close_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
