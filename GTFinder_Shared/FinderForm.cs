using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using SharpPcap;
using SharpPcap.WinPcap;
using PacketDotNet;
using System.Diagnostics;
using System.Linq; // [추가] Linq 사용
using System.IO;   // [추가] 파일 입출력 사용

using AnyLosk.widget;
using GTFinder.info;

namespace GTFinder {
	public partial class FinderForm : Form {
		public class NetworkAdapterItem {
			public string DisplayName { get; set; }
			public string IpAddress { get; set; }
			public ICaptureDevice Device { get; set; }
			public override string ToString() => $"{DisplayName} ({IpAddress})";
		}

		// [추가] 장비 데이터 구조체
		private class DeviceData {
			public string Mac { get; set; }
			public string Ip { get; set; }
			public string Name { get; set; }
			public string Model { get; set; }
			public string Fw { get; set; }
			public string Brom { get; set; }
			public string Status { get; set; }
		}

		public class DeviceAddInfo {
			public string Mac { get; set; }
			public string Ip { get; set; }
			public string Name { get; set; }
			public string Model { get; set; }
			public string Group { get; set; }
		}

		private ICaptureDevice m_pcapDevice = null;
		private PhysicalAddress m_currentMac = PhysicalAddress.Parse("00-00-00-00-00-00");
		private List<DeviceData> _discoveredDevices = new List<DeviceData>(); // [추가] 발견된 장비 목록

		private clsUDPBroadcast m_udpCompex;
		private TxData m_txData = new TxData();
		private Dictionary<string, string> m_htSystemTable = new Dictionary<string, string>();
		private string m_strFilter = ""; // [추가] 설정 파일 필터링 문자열

		// [추가] 실행 인자 저장용 속성 (Program.ExecutionArgs 의존성 제거)
		public string ExecutionArgs { get; set; } = "";
		public List<string> GroupNames { get; set; } = new List<string>();
		public Action<List<DeviceAddInfo>> OnDevicesAdd { get; set; } = null;

		public FinderForm() {
			InitializeComponent();
			InitializeListViewColumns();

			// ▼▼▼ [추가] 우클릭 메뉴 초기화 함수 호출 ▼▼▼
			InitializeContextMenu();

            // ▼▼▼ [추가] 이벤트 연결 ▼▼▼
            cb_system_type.SelectedIndexChanged += (s, e) => RefreshListView(); // [추가] 시스템 종류 변경 시 갱신
            bt_conn.Click += bt_conn_Click;
            lv_system_list.DoubleClick += bt_conn_Click;
            pictureBox1.Click += (s, e) => {
				//string url = "http://gotinc.co.kr/";
				string url = "http://gtwave.co.kr/";
				Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
            };

			this.Shown += FinderForm_Shown;
		}

		private void FinderForm_Shown(object sender, EventArgs e) {
			AnyLosk.widget.ProgressForm.Close(this);
		}

		private void InitializeListViewColumns() {
			lv_system_list.View = View.Details;
			lv_system_list.GridLines = true;
			lv_system_list.FullRowSelect = true;
			lv_system_list.MultiSelect = true; // [추가] 멀티 선택 활성화 (Shift/Ctrl 키 지원)

			lv_system_list.Columns.Clear();
			lv_system_list.Columns.Add("Num", 40);
			lv_system_list.Columns.Add("MAC Address", 120);
			lv_system_list.Columns.Add("IPv4 Address", 100);
			lv_system_list.Columns.Add("Device Name", 100);
			lv_system_list.Columns.Add("Device Model", 100);
			lv_system_list.Columns.Add("FW", 60);
			lv_system_list.Columns.Add("BROM", 120);
			lv_system_list.Columns.Add("Status", 80);
		}

		private void PrintLog(string msg) {
			string log = $"[{DateTime.Now:HH:mm:ss.fff}] {msg}";
			System.Diagnostics.Debug.WriteLine(log);
		}

		private void FinderForm_Load(object sender, EventArgs e) {
			PrintLog("=== Program Started ===");
			
			// [추가] 실행 모드 확인 및 로깅
			string mode = "Standalone";
			if (ExecutionArgs == "FromGTWaveMgr") {
				mode = "Linked (From GTWaveMgr)";
				this.Text += " [Linked Mode]"; // 타이틀바 변경
				bt_close.Text = "장비 추가";   // 버튼 텍스트 변경
				bt_close.Enabled = false;      // [추가] 리스트에서 선택 시 활성화 준비
				
				// [추가] 리스트뷰 선택 변경 시 버튼 활성화 여부 제어
				lv_system_list.SelectedIndexChanged += (sl, el) => {
					bt_close.Enabled = lv_system_list.SelectedItems.Count > 0;
				};
			} else if (!string.IsNullOrEmpty(ExecutionArgs)) {
				mode = $"Custom Args ({ExecutionArgs})";
			}
			PrintLog($"Execution Mode: {mode}");

			LoadNetworkAdapters();

			// [추가] 설정 파일에서 필터 읽기
			try {
				string cfgPath = @"C:\GTWave\cfg\GTFinder.cfg";
				if (System.IO.File.Exists(cfgPath)) {
					m_strFilter = System.IO.File.ReadAllText(cfgPath).Trim();
					PrintLog($"Filter Loaded from Cfg: {m_strFilter}");
				}
			} catch (Exception ex) {
				PrintLog($"Cfg Load Error: {ex.Message}");
			}

			cb_system_type.SelectedIndex = 0;
		}

		private void InitializeContextMenu() {
			// 1. 메뉴 스트립 생성
			ContextMenuStrip ctxMenu = new ContextMenuStrip();

			// 2. 메뉴 아이템 생성
			ToolStripMenuItem menuHttp = new ToolStripMenuItem("Http 접속");
			ToolStripMenuItem menuHttps = new ToolStripMenuItem("Https 접속");

			// 4. 클릭 이벤트 연결
			menuHttp.Click += (sender, e) => OpenBrowser("http");
			menuHttps.Click += (sender, e) => OpenBrowser("https");

			// 5. 메뉴에 아이템 추가
			ctxMenu.Items.Add(menuHttp);
			ctxMenu.Items.Add(menuHttps);

			// 6. 리스트뷰에 메뉴 연결
			lv_system_list.ContextMenuStrip = ctxMenu;
		}


		// [추가] 와일드카드 매칭 로직
		private bool IsMatch(string text, string pattern) {
			if (string.IsNullOrEmpty(pattern)) return true;
			if (string.IsNullOrEmpty(text)) return false;

			try {
				string regexPattern = System.Text.RegularExpressions.Regex.Escape(pattern);
				regexPattern = regexPattern.Replace(@"\*", ".*");
				regexPattern = System.Text.RegularExpressions.Regex.Replace(regexPattern, @"\\\[(\\?)\?+\\\]", (match) => {
					int qCount = match.Value.Count(c => c == '?');
					return new string('.', qCount);
				});
				regexPattern = "^" + regexPattern + "$";
				return System.Text.RegularExpressions.Regex.IsMatch(text, regexPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
			} catch {
				return false;
			}
		}

		private void LoadNetworkAdapters() {
			try {
				var devices = CaptureDeviceList.Instance;
				if (devices.Count < 1) {
					MessageBox.Show("네트워크 어댑터를 찾을 수 없습니다.");
					return;
				}

				cbNetworkAdapter.Items.Clear();
				NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

				foreach (ICaptureDevice dev in devices) {
					string displayName = dev.Description;
					string ipAddress = "0.0.0.0";
					string friendlyName = "";

					WinPcapDevice winDev = dev as WinPcapDevice;
					if (winDev != null && winDev.Interface != null)
						friendlyName = winDev.Interface.FriendlyName;

					bool isDeviceActive = false;

					foreach (NetworkInterface nic in nics) {
						if (dev.Name.Contains(nic.Id)) {
							// [수정] 활성화된 어댑터만 표시 (Up 상태 체크)
							if (nic.OperationalStatus != OperationalStatus.Up) {
								break; // 매칭되지만 Up 상태가 아님 -> 이 dev는 스킵
							}

							isDeviceActive = true;
							if (string.IsNullOrEmpty(friendlyName)) friendlyName = nic.Name;

							// [수정] 하나의 어댑터에 여러 IP가 있을 경우 각각 추가
							foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses) {
								if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
									ipAddress = ip.Address.ToString();

									// 여기서 바로 추가 (여러 IP 대응)
									cbNetworkAdapter.Items.Add(new NetworkAdapterItem {
										DisplayName = $"{friendlyName}",
										IpAddress = ipAddress,
										Device = dev
									});
								}
							}
							break;
						}
					}
					// (기존 단일 추가 로직 제거: 위 루프 안에서 추가함)
				}

				for (int i = 0; i < cbNetworkAdapter.Items.Count; i++) {
					if (((NetworkAdapterItem)cbNetworkAdapter.Items[i]).DisplayName.Contains("이더넷")) {
						cbNetworkAdapter.SelectedIndex = i;
						break;
					}
				}
				if (cbNetworkAdapter.SelectedIndex == -1 && cbNetworkAdapter.Items.Count > 0)
					cbNetworkAdapter.SelectedIndex = 0;
			} catch (Exception ex) {
				MessageBox.Show("초기화 오류: " + ex.Message);
			}
		}

		private void bt_scan_Click(object sender, EventArgs e) {
			PrintLog("=== Scan Button Clicked ===");
			try {
				if (cbNetworkAdapter.SelectedItem == null) return;

				var selectedItem = cbNetworkAdapter.SelectedItem as NetworkAdapterItem;

				StopAndClose();

				m_pcapDevice = selectedItem.Device;
				m_pcapDevice.Open(DeviceMode.Promiscuous, 2000);

				PrintLog("Filter DISABLED");

				m_pcapDevice.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival);
				m_pcapDevice.StartCapture();

				byte[] payloadData = new byte[50];
				payloadData[0] = 0x01; payloadData[1] = 0x01; payloadData[2] = 0xFF; payloadData[3] = 0xFF;

				m_currentMac = PhysicalAddress.Parse("00-00-00-00-00-00");
				var winDev = m_pcapDevice as WinPcapDevice;
				if (winDev != null && winDev.MacAddress != null)
					m_currentMac = winDev.MacAddress;

				if (m_currentMac.ToString() == "000000000000") {
					foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces()) {
						if (m_pcapDevice.Name.Contains(nic.Id)) {
							m_currentMac = nic.GetPhysicalAddress();
							break;
						}
					}
				}

				PrintLog($"My MAC Address: {m_currentMac}");

				EthernetPacket ethPacket = new EthernetPacket(
					m_currentMac,
					PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"),
					(EthernetPacketType)0x268d
				);
				ethPacket.PayloadData = payloadData;

				m_pcapDevice.SendPacket(ethPacket.Bytes);
				PrintLog("Packet Sent.");

				// ▼▼▼ [추가] UDP Broadcast 검색 루틴 ▼▼▼
				if (cb_system_type.SelectedIndex == 0 || cb_system_type.SelectedIndex == 1) { // 전체 또는 무선
					m_txData.m_strIPAddr = selectedItem.IpAddress;
					m_txData.m_strMACAddr = BitConverter.ToString(m_currentMac.GetAddressBytes()).Replace("-", ":");
					m_txData.InitTXData((int)Const.COMPEX_TYPE.FIND);

					m_udpCompex = new clsUDPBroadcast();
					m_udpCompex.LocalIPAddr = selectedItem.IpAddress;
					m_udpCompex.evtReceiveData += UDPCompex_DataProcess;
					m_udpCompex.Bind();
					m_udpCompex.SendValue = m_txData.m_bytTxCompex;
					m_udpCompex.SendData();
					PrintLog("UDP Broadcast Sent (Port 7778).");
				}

				lv_system_list.Items.Clear();
				_discoveredDevices.Clear(); // [추가] 장비 목록 초기화
				lock (m_htSystemTable) { m_htSystemTable.Clear(); }
			} catch (Exception ex) {
				MessageBox.Show("Scan Error: " + ex.Message);
			}
		}

		// [핵심] TLV (Tag-Length-Value) 파싱 엔진 적용
		private void Device_OnPacketArrival(object sender, CaptureEventArgs e) {
			try {
				var rawPacket = e.Packet;
				var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
				var ethPacket = packet as EthernetPacket;

				if (ethPacket == null) return;

				// Loopback 무시
				if (ethPacket.SourceHwAddress.Equals(m_currentMac)) return;

				// 프로토콜 확인
				if ((int)ethPacket.Type != 0x268d) return;

				byte[] data = ethPacket.PayloadData;
				if (data == null || data.Length < 8) return;

				// 헤더 체크 (0x01, 0x02)
				if (data[0] != 0x01 || data[1] != 0x02) return;

				PrintLog($">>> [Rx] Valid Packet! Length: {data.Length} <<<");
				string hexDump = BitConverter.ToString(data).Replace("-", " ");
				PrintLog($"[Hex]: {hexDump}");

				// ---------------------------------------------------------
				// TLV 파싱 시작
				// ---------------------------------------------------------
				string strMac = "";
				string strIp = "";
				string strName = "";
				string strModel = "";
				string strFW = "";
				string strBROM = "";
				string strStatus = "Online";

				try {
					// Header(8 bytes) 건너뛰고 시작
					int offset = 8;

					while (offset < data.Length) {
						// 남은 데이터가 최소 Tag(1) + Length(2) = 3바이트 이상이어야 함
						if (offset + 3 > data.Length) break;

						byte tag = data[offset];
						// Length는 2바이트 Big Endian (00 06 -> 6)
						int length = (data[offset + 1] << 8) + data[offset + 2];

						// Value 읽기 범위 체크
						if (offset + 3 + length > data.Length) break;

						// Value 추출
						byte[] valueBytes = new byte[length];
						Array.Copy(data, offset + 3, valueBytes, 0, length);

						// Tag별 처리
						switch (tag) {
							case 0x0B: // MAC Address
								strMac = BitConverter.ToString(valueBytes).Replace('-', ':');
								break;

							case 0x0C: // IP Address
								if (length == 4) {
									strIp = new IPAddress(valueBytes).ToString();
								}
								break;

							case 0x0D: // Device Name
								strName = Encoding.ASCII.GetString(valueBytes).Trim('\0');
								break;

							case 0x0E: // Device Model
								strModel = Encoding.ASCII.GetString(valueBytes).Trim('\0');
								break;

							case 0x10: // Firmware
								strFW = Encoding.ASCII.GetString(valueBytes).Trim('\0');
								break;

							case 0x11: // Bootrom
								strBROM = Encoding.ASCII.GetString(valueBytes).Trim('\0');
								break;

								// 0x0F 등 알 수 없는 태그는 건너뜀
						}

						// 다음 TLV로 이동 (Tag 1 + Len 2 + Value Length)
						offset += (3 + length);
					}

					PrintLog($"Parsed -> Name: {strName}, Model: {strModel}, FW: {strFW}, BROM: {strBROM}");
				} catch (Exception parseEx) {
					PrintLog($"[Parsing Error] {parseEx.Message}");
				}

				// UI 업데이트
				this.Invoke(new Action(() => {
					// [수정] 데이터 리스트에 추가 후 필터 적용하여 표시
					// strModel 여기서 필터를 추가한다....

					AddDeviceData(strMac, strIp, strName, strModel, strFW, strBROM, strStatus);
				}));
			} catch (Exception ex) {
				PrintLog($"[Critical Error] OnPacketArrival: {ex.Message}");
			}
		}

		private void AddDeviceData(string mac, string ip, string name, string model, string fw, string brom, string status) {
			// 중복 체크 (MAC 기준)
			if (_discoveredDevices.Exists(d => d.Mac == mac)) return;


			_discoveredDevices.Add(new DeviceData {
				Mac = mac, Ip = ip, Name = name, Model = model, Fw = fw, Brom = brom, Status = status
			});

			RefreshListView();
		}

		private void RefreshListView() {
			lv_system_list.Items.Clear();
			int typeIdx = cb_system_type.SelectedIndex; // 시스템 종류 인덱스

			int nNo = 1;
			foreach (var dev in _discoveredDevices) {
				// 1. 시스템 종류 필터링 (ComboBox)
				if (typeIdx > 0) {
					bool	typeMatch	= false;
					string	model		= dev.Model?.ToUpper() ?? "";
					//string	name		= dev.Name?.ToUpper() ?? "";

					switch (typeIdx) {
						case 1: // 네트워크 스위치
							typeMatch = model.Contains("SWITCH");
							break;
						case 2: // GTWave 무선 시스템
							typeMatch = model.Contains("GTW") || model.Contains("WAVE");
							break;
						case 3: // 비디오 서버 시스템
							typeMatch = model.Contains("VIDEO") || model.Contains("SERVER");
							break;
					}
					if (!typeMatch) continue;
				}

				// 7778번은 모두 통과
				// 2. 텍스트 필터링 (Wildcard)
				//bool matchName = IsMatch(dev.Name, m_strFilter);
				bool matchModel = IsMatch(dev.Model, m_strFilter);

				//if (matchModel) {
					ListViewItem lvi = new ListViewItem((nNo++).ToString());
					lvi.SubItems.Add(dev.Mac ?? "");
					lvi.SubItems.Add(dev.Ip ?? "");
					lvi.SubItems.Add(dev.Name ?? "");
					lvi.SubItems.Add(dev.Model ?? "");
					lvi.SubItems.Add(dev.Fw ?? "");
					lvi.SubItems.Add(dev.Brom ?? "");
					lvi.SubItems.Add(dev.Status ?? "");
					lv_system_list.Items.Add(lvi);
				//}
			}
		}

		private void StopAndClose() {
			if (m_pcapDevice != null) {
				try {
					if (m_pcapDevice.Started) m_pcapDevice.StopCapture();
					m_pcapDevice.Close();
				} catch { }
				m_pcapDevice = null;
			}
			if (m_udpCompex != null) {
				try { m_udpCompex.Close(); } catch { }
				m_udpCompex = null;
			}
		}

		private void bt_close_Click(object sender, EventArgs e) {
			if (ExecutionArgs == "FromGTWaveMgr" && bt_close.Text == "장비 추가")
			{
				if (lv_system_list.SelectedItems.Count == 0)
				{
					MessageBox.Show("등록할 장비를 리스트에서 선택해주세요.");
					return;
				}

				// ▼▼▼ [추가] 그룹 선택 창 표시 ▼▼▼
				string selectedGroup = "";
				using (var gForm = new GroupSelectForm(GroupNames)) {
					if (gForm.ShowDialog() != DialogResult.OK) return; // 취소나 닫기 시 중단
					selectedGroup = gForm.SelectedGroup;
				}

				List<DeviceAddInfo> addList = new List<DeviceAddInfo>();
				foreach (ListViewItem item in lv_system_list.SelectedItems)
				{
					string mac = item.SubItems[1].Text;
					string ip = item.SubItems[2].Text;
					string name = item.SubItems[3].Text;
					string model = item.SubItems[4].Text;

					addList.Add(new DeviceAddInfo {
						Mac = mac,
						Ip = ip,
						Name = name,
						Model = model,
						Group = selectedGroup
					});
				}

				if (OnDevicesAdd != null)
				{
					OnDevicesAdd(addList);
				}
				else
				{
					try
					{
						string resultPath = @"C:\GTWave\cfg\GTFinder_result.cfg";
						StringBuilder sb = new StringBuilder();

						foreach (var d in addList)
						{
							sb.AppendLine("[DEVICE]");
							sb.AppendLine($"MAC={d.Mac}");
							sb.AppendLine($"IP={d.Ip}");
							sb.AppendLine($"NAME={d.Name}");
							sb.AppendLine($"MODEL={d.Model}");
							sb.AppendLine($"GROUP={d.Group}");
						}

						File.WriteAllText(resultPath, sb.ToString(), Encoding.UTF8);
					}
					catch (Exception ex)
					{
						PrintLog($"Error saving result: {ex.Message}");
					}
				}
				return;
			}

			StopAndClose();
			Close();
		}

		private void UDPCompex_DataProcess(clsUDPBroadcast sender, byte[] bytRecv, string strRecvIp) {
			if (bytRecv.Length < 152) return;
			
			// 자기 패킷 무시 (IP 비교)
			var selectedItem = this.Invoke((Func<NetworkAdapterItem>)(() => cbNetworkAdapter.SelectedItem as NetworkAdapterItem)) as NetworkAdapterItem;
			if (selectedItem != null && strRecvIp == selectedItem.IpAddress) return;

			// bytRecv[11] 확인 (3: RFVision 응답, 2: Compex 오리지널)
			//if (bytRecv[11] != 2 && bytRecv[11] != 3) return;
			if (bytRecv[11] != 3) return;
			//if (bytRecv[11] != 2) return;

			// 모델명 (16~47)
			string strModel = Encoding.ASCII.GetString(bytRecv, 16, 32).Split('\0')[0].Replace("\"", "");
			
			// IP 주소
			string strIp = strRecvIp;

			// MAC 주소 (120~125)
			string strMac = "";
			for (int i = 120; i <= 125; i++) {
				strMac += bytRecv[i].ToString("X2") + (i == 125 ? "" : ":");
			}

			// 중복 확인
			lock (m_htSystemTable) {
				if (m_htSystemTable.ContainsKey(strMac)) return;
				m_htSystemTable.Add(strMac, strIp);
			}

			// 시스템 이름 (48~111) - UTF8
			int nameLen = 0;
			for (int i = 48; i <= 111; i++) {
				if (bytRecv[i] == 0) break;
				nameLen++;
			}
			string strName = nameLen > 0 ? Encoding.UTF8.GetString(bytRecv, 48, nameLen).Replace("\"", "") : "";

			// UI 업데이트
			this.BeginInvoke((MethodInvoker)delegate {
				var device = new DeviceData {
					Mac = strMac,
					Ip = strIp,
					Name = strName,
					Model = strModel,
					Status = "Online"
				};
				_discoveredDevices.Add(device);
				RefreshListView();
			});
		}

		private void bt_cls_list_Click(object sender, EventArgs e) {
			lv_system_list.Items.Clear();
			_discoveredDevices.Clear(); // [추가] 데이터도 초기화
			lock (m_htSystemTable) { m_htSystemTable.Clear(); }
		}

        private void bt_conn_Click(object sender, EventArgs e) {
            // 선택된 항목이 있는지 확인
            if (lv_system_list.SelectedItems.Count == 0) {
                MessageBox.Show("접속할 장비를 리스트에서 선택해주세요.");
                return;
            }

            // 프로토콜 선택
            using (var form = new ProtocolSelectForm()) {
                if (form.ShowDialog() == DialogResult.Cancel) return; // 닫으면 취소
                
                string protocol = form.SelectedProtocol;
                if (string.IsNullOrEmpty(protocol)) return;

                OpenBrowser(protocol);
            }
        }

		private void OpenBrowser(string protocol) {
			// 선택된 항목이 있는지 확인
			if (lv_system_list.SelectedItems.Count == 0) {
				MessageBox.Show("접속할 장비를 리스트에서 선택해주세요.");
				return;
			}

			try {
                // 리스트뷰 컬럼 순서: 0:Num, 1:MAC, 2:IP, ... (디자이너 확인 필요하지만 기존 코드 참조)
                // 기존 코드: string ip = lv_system_list.SelectedItems[0].SubItems[2].Text;
                // 디자이너의 컬럼 추가 순서: No, Model, IP, MAC, Name
                // ch_no, ch_model, ch_ip, ch_mac, ch_name
                // index: 0, 1, 2, 3, 4
                // 따라서 IP는 SubItems[2]가 맞음.

				// IP 주소 가져오기 (SubItems[2])
				string ip = lv_system_list.SelectedItems[0].SubItems[2].Text;

				// IP가 유효한지 간단 체크
				if (string.IsNullOrEmpty(ip) || ip == "0.0.0.0") {
					MessageBox.Show("유효하지 않은 IP 주소입니다.");
					return;
				}

				// URL 생성
				string url = $"{protocol}://{ip}";

                // 시스템 기본 브라우저로 열기
                ProcessStartInfo psi = new ProcessStartInfo {
                    FileName = url,
                    UseShellExecute = true
                };
                Process.Start(psi);

			} catch (Exception ex) {
				MessageBox.Show($"브라우저를 여는 중 오류가 발생했습니다.\n{ex.Message}");
			}
		}

		private void FinderForm_FormClosing(object sender, FormClosingEventArgs e) {
			StopAndClose();
		}
	}

}