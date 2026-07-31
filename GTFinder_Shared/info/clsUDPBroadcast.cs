using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GTFinder.info {
	public class clsUDPBroadcast {
		public const int PORT_COMPEX = 7778;

		private UdpClient m_udpClient = null;
		private string	m_strLocalIp;      //Local IP Address
		private int		m_nLocalPort;         //Local Port
		private string	m_strRemoteIp;     //Remote IP Address
		private int		m_nRemotePort;        //Remote Port
		private bool	m_bBroadCast;
		private byte[]	m_bytTxData;

		public delegate void ReceiveDataHandler(clsUDPBroadcast sender, byte[] bytRecv, string strRecvIp);
		public event ReceiveDataHandler evtReceiveData;

		//UDP Status
		public class UDP_State {
			public IPEndPoint ePoint;
			public UdpClient uClient;
		}

		//Local IP Address
		public string LocalIPAddr {
			get { return m_strLocalIp; }
			set { m_strLocalIp = value; }
		}

		//Local Port
		public int LocalPort {
			get { return m_nLocalPort; }
			set { m_nLocalPort = value; }
		}

		//Remote IP Address
		public string RemoteIPAddr {
			get { return m_strRemoteIp; }
			set { m_strRemoteIp = value; }
		}

		//Remote Port
		public int RemotePort {
			get { return m_nRemotePort; }
			set { m_nRemotePort = value; }
		}

		//Boardcast ON/OFF
		public bool BoardCast {
			get { return m_bBroadCast; }
			set { m_bBroadCast = value; }
		}

		//전송할 패킷 내용
		public byte[] SendValue {
			get { return m_bytTxData; }
			set {
				m_bytTxData = new byte[value.Length];
				Array.Copy(value, m_bytTxData, value.Length);
			}
		}

		public clsUDPBroadcast() {
			m_strLocalIp = "";
			m_nLocalPort = PORT_COMPEX;
			m_strRemoteIp = "255.255.255.255";
			m_nRemotePort = PORT_COMPEX;
			m_bBroadCast = true;
		}

		//초기화
		public clsUDPBroadcast(string strLocalIP, int nPort) {
			m_strLocalIp = strLocalIP;
			m_nLocalPort = nPort;
			m_strRemoteIp = "255.255.255.255";
			m_nRemotePort = nPort;
			m_bBroadCast = true;
		}

		//초기화
		public void Bind() {
			if (m_udpClient != null) {
				try { m_udpClient.Close(); } catch { }
			}
			m_udpClient = new UdpClient();

			IPAddress ipAddr = IPAddress.Any;
			if (!string.IsNullOrEmpty(m_strLocalIp)) {
				IPAddress.TryParse(m_strLocalIp, out ipAddr);
			}

			IPEndPoint endPoint = new IPEndPoint(ipAddr, m_nLocalPort);
			UDP_State uState = new UDP_State();
			uState.uClient = m_udpClient;
			uState.ePoint = endPoint;

			try {
				if (m_udpClient.Client.IsBound == false) {
					// ExclusiveAddressUse를 false로 설정하여 소켓이 이미 사용 중인 경우에도 바인딩할 수 있게 함 (필요한 경우)
					// m_udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
					m_udpClient.Client.Bind(endPoint);
				}

				m_udpClient.EnableBroadcast = m_bBroadCast;
				m_udpClient.BeginReceive(new AsyncCallback(subRcvData), uState);
			} catch (Exception ex) {
				Console.WriteLine("[Bind] " + ex.Message);
			}
		}

		//데이터 처리 루틴
		private void subRcvData(IAsyncResult ar) {
			UDP_State uState = (UDP_State)ar.AsyncState;
			UdpClient uClient = uState.uClient;
			IPEndPoint ePoint = uState.ePoint;
			string strRecvIp = "";
			byte[] bytRecv = null;

			try {
				lock (uClient) {
					bytRecv = uClient.EndReceive(ar, ref ePoint);
					strRecvIp = ePoint.Address.ToString();
				}
				
				evtReceiveData?.Invoke(this, bytRecv, strRecvIp);

				uClient.BeginReceive(new AsyncCallback(subRcvData), uState);
			} catch (Exception ex) {
				Console.WriteLine("[subRcvData] " + ex.Message);
			}
		}

		//데이터 전송
		public void SendData() {
			if (m_udpClient == null || m_bytTxData == null) return;

			IPAddress ipAddr = IPAddress.Parse(m_strRemoteIp);
			IPEndPoint endPoint = new IPEndPoint(ipAddr, m_nRemotePort);

			try {
				m_udpClient.Send(m_bytTxData, m_bytTxData.Length, endPoint);
			} catch (Exception ex) {
				Console.WriteLine("[SendData] " + ex.Message);
			}
		}

		//소켓 닫기
		public void Close() {
			if (m_udpClient != null) {
				m_udpClient.Close();
				m_udpClient = null;
			}
		}
	}
}
