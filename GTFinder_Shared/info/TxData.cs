using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTFinder.info {

	public	class	TxData {

		public	byte[]	m_bytTxCompex	= new byte[152];
		//public	byte[]	m_bytTxAntcor	= new byte[3];
		//public	byte[]	m_bytTxNadaTel	= new byte[23];   // '나다텔 Send Data
		//public	byte[]	m_bytTxCellinx	= new byte[8];    // 'Cellinx Send Data                


		public	string	m_strMACAddr	= "";             //Local MAC Address
		public	string	m_strIPAddr		= "";             //Local IP Address


		public	void	InitTXData(int nType) {
			// Initialize Compex packet
			for (int idx = 0; idx < m_bytTxCompex.Length; idx++) {
				m_bytTxCompex[idx] = 0x00;
			}
			m_bytTxCompex[0] = 0x89;
			m_bytTxCompex[1] = 0x16;
			m_bytTxCompex[2] = 0x8A;
			m_bytTxCompex[3] = 0xCE;
			m_bytTxCompex[7] = 0x03;
			if (nType == (int)Const.COMPEX_TYPE.FIND) {
				m_bytTxCompex[11] = 0x01;
			} else {
				m_bytTxCompex[11] = 0x11;
			}

			// MAC Address
			string[] strArray = m_strMACAddr.Split(':');
			for (int idx = 0; idx < 6; idx++) {
				m_bytTxCompex[120 + idx] = Convert.ToByte(strArray[idx], 16);
				m_bytTxCompex[132 + idx] = 0xFF;
			}

			// IP Address
			strArray = m_strIPAddr.Split('.');
			for (int idx = 0; idx < 3; idx++) {
				m_bytTxCompex[128 + idx] = Convert.ToByte(strArray[idx], 10);
				m_bytTxCompex[140 + idx] = Convert.ToByte(strArray[idx], 10);
			}
			m_bytTxCompex[131] = Convert.ToByte(strArray[3], 10);
			m_bytTxCompex[143] = 0xFF;

			// Antcor packet
			/*
			m_bytTxAntcor[0] = 0xFF;
			m_bytTxAntcor[1] = 0xBD;
			m_bytTxAntcor[2] = 0x0D;

			// NadaTel packet
			for (int idx = 0; idx < m_bytTxNadaTel.Length; idx++) {
				m_bytTxNadaTel[idx] = 0x00;
			}
			m_bytTxNadaTel[0] = 0x34;
			m_bytTxNadaTel[1] = 0x52;
			m_bytTxNadaTel[2] = 0x34;
			m_bytTxNadaTel[3] = 0x87;
			m_bytTxNadaTel[4] = 0x01;
			m_bytTxNadaTel[5] = 0x05;
			*/
			// Cellinx packet
			/*
			m_bytTxCellinx[0] = 0x41;
			m_bytTxCellinx[1] = 0x44;
			m_bytTxCellinx[2] = 0x43;
			m_bytTxCellinx[3] = 0x54;
			m_bytTxCellinx[4] = 0x02;
			m_bytTxCellinx[5] = 0x09;
			m_bytTxCellinx[6] = 0x00;
			m_bytTxCellinx[7] = 0x03;
			m_bytTxCellinx[8] = 0xFF;
			*/
		}

		/*
		public bool IsLanguageKorean {
			get {
				// Check if the current UI culture is Korean ("ko" or "ko-KR")
				return CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "ko" ||
					   CultureInfo.CurrentUICulture.Name == "ko-KR";
			}
		}


		public bool GetOSVersionWin7() {
			switch (Environment.OSVersion.Platform) {
				case PlatformID.Win32S:
					return false;
				case PlatformID.Win32Windows:
					return false;
				case PlatformID.Win32NT:
					switch (Environment.OSVersion.Version.Major) {
						case 3:
							return false;
						case 4:
							return false;
						case 5:
							return false;
						case 6:
							switch (Environment.OSVersion.Version.Minor) {
								case 0:
									return false;
								case 1:
									return true;
								case 2:
									return true;
								default:
									return false;
							}
						default:
							return false;
					}
				case PlatformID.WinCE:
					return false;
				default:
					return false;
			}
		}
		*/
	}
}
