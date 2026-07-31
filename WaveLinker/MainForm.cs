
using iTextSharp.text;

using System;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using IronPdf;
using System.Threading;
using ceTe.DynamicPDF.Printing;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using WaveLinker.info;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using static System.Windows.Forms.Design.AxImporter;
using iTextSharp.text.pdf;
using System.Text;
using System.Security.Policy;
using OpenQA.Selenium.DevTools.V125.FedCm;
using iTextSharp.tool.xml.html;
using iTextSharp.text.pdf.parser;
using System.Runtime.InteropServices;
using BitMiracle.LibTiff.Classic;
using System.Text.RegularExpressions;
using AnyBoBu.dialog;
using System.Text.Unicode;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace WaveLinker {
	public partial class MainForm : Form {
		private iTextSharp.text.Font fontS;
		private Paragraph lineSeparator;

		private static bool isScan = false;
		private static string scanIp = "";
		private static int scanPort = 80;

		private static string scan_id = "";
		private static string scan_pw = "";


		private static string mSaveFile = "";
		private static StreamWriter mSaveHandle = null;
		private static bool mHeadWrite = false;

		private static IWebDriver driver = null;
		private Thread scanThread = null;

		public MainForm() {
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

			InitializeComponent();
			//this.FormBorderStyle = FormBorderStyle.None;//윈도우테두리제거방법

			//한글 폰트를 읽어온다.
			iTextSharp.text.pdf.BaseFont bf = iTextSharp.text.pdf.BaseFont.CreateFont(@"C:\Windows\Fonts\malgun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
			//Font font = new Font(bf, 12, Font.BOLD | Font.UNDERLINE, CMYKColor.BLACK);
			fontS = new iTextSharp.text.Font(bf, 14.0f);
			fontS.SetStyle(1);
			fontS.SetColor(0, 0, 0);

			lineSeparator = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, CMYKColor.BLACK, Element.ALIGN_LEFT, 1)));
			// Set gap between line paragraphs.
			lineSeparator.SetLeading(0.5F, 0.5F);

			/*
			// cb_PcNum
			cb_PcNum.Items.Add("전체");
			for (int i = 0; i < Global.mSetInfo.childNum; i++) {
				cb_PcNum.Items.Add(string.Format($"{i + 1:D3}"));
			}
			cb_PcNum.SelectedIndex = 0;
			*/

			//SampleData();
		}

		private void DailyForm_Load(object sender, EventArgs e) {

			scanIp = cb_ip.Text;
			int.TryParse(tb_port.Text, out int port);
			scanPort = port;

			DispClear();
		}

		private void bt_close_Click(object sender, EventArgs e) {
			Close();
			Environment.Exit(1);
		}

		private void bt_stop_Click(object sender, EventArgs e) {
			isScan = false;
		}

		private void bt_scan_Click(object sender, EventArgs e) {

			DialogLogin dialogLogin = new DialogLogin();
			dialogLogin.ShowDialog();
			if (!dialogLogin.isOK) {
				return;
			}

			scan_id = Properties.Settings.Default.id;
			scan_pw = Properties.Settings.Default.pw;

			if (isScan) {
				MessageBox.Show("현재 Scan 진행중...");
				return;
			}

			if (cb_auto_save.Checked) {
				//mSaveFile
				SaveFileDialog saveFileDialog1 = new SaveFileDialog();
				System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(System.Windows.Forms.Application.StartupPath + @"..\Data");
				saveFileDialog1.InitialDirectory = di.FullName;
				saveFileDialog1.FileName = "WaveLinker_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
				saveFileDialog1.Filter = "sam data|*.csv";
				saveFileDialog1.Title = "Save an Data File";
				if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
					mSaveFile = saveFileDialog1.FileName;
					if (mSaveHandle != null) {
						mSaveHandle.Close();
					}
					Thread.Sleep(200);
					mSaveHandle = new StreamWriter(mSaveFile);

					Debug.WriteLine($"-------{mSaveFile}---------------");
				} else {
					MessageBox.Show("스캔작업을 취소합니다.");
					return;
				}
			}
			scanThread = new Thread(() => Scan(this));
			scanThread.Start();
		}

		public void DispClear() {
			gb_device0.Text = "";
			lb_g_bssid_0.Text = "";
			lb_g_ssid_0.Text = "";
			lb_g_sec_0.Text = "";
			lb_g_freq_0.Text = "";
			lb_g_mode_0.Text = "";

			gb_device1.Text = "";
			lb_g_bssid_1.Text = "";
			lb_g_ssid_1.Text = "";
			lb_g_sec_1.Text = "";
			lb_g_freq_1.Text = "";
			lb_g_mode_1.Text = "";
		}

		public class AssocInfo {
			public string ssid;
			public string mac;
			public string signal;
			public string sigChain;
			public string rxRate;
			public string txRate;
			public string txCcq;
		}

		public Dictionary<string, AssocInfo> list = new Dictionary<string, AssocInfo>();

		public string ParseSigChain(string sigChain) {
			string retv = "";

			retv = sigChain.Replace(System.Environment.NewLine, "");
			Regex reg = new Regex(@"\[(.+)\]");

			MatchCollection resultColl = reg.Matches(retv);
			foreach (Match mm in resultColl) {
				Group g = mm.Groups[1];
				Debug.WriteLine("  mm.Groups.Count = {0}", mm.Groups.Count);
				Debug.WriteLine("  mm.Groups[0] = {0}", mm.Groups[0]);
				Debug.WriteLine("  mm.Groups[1] = {0}", mm.Groups[1]);

				Debug.WriteLine("{0}=|{1}|=", g.Index, g.Value);
				retv = g.Value;
				break;
			}
			string[] list = retv.Split(',');
			List<int> tuple = new List<int>();
			foreach (string str in list) {
				int.TryParse(str, out int val);
				tuple.Add(val);
			}

			if (tuple != null && tuple.Count > 3) {
				if (tuple[3] > -95) {
					retv = string.Format("{0}, {1}, {2}, {3}", tuple[0], tuple[1], tuple[2], tuple[3]);
				} else {
					if (tuple[2] > -95) {
						retv = string.Format("{0}, {1}, {2}", tuple[0], tuple[1], tuple[2]);
					} else {
						retv = string.Format("{0}, {1}", tuple[0], tuple[1]);
					}
				}
			}

			return retv;
		}

		public void SampleData() {

			string readData = File.ReadAllText(@"wavelinker.txt");
			JObject data = JObject.Parse(readData);
			try {
				Debug.WriteLine(data["uptime"].ToString());
				int.TryParse(data["uptime"].ToString(), out int value);
				TimeSpan time = TimeSpan.FromSeconds(value);
				DateTime dateTime = DateTime.Today.Add(time);
				lb_uptime.Text = dateTime.ToString("dd일 hh:mm:ss");
				Debug.WriteLine($"lb_uptime => {lb_uptime.Text}");

				//lb_uptime.Text = data["uptime"].ToString();

				//DateTime dt = DateTime.Parse(data["uptime"].ToString());
				//lb_uptime.Text = dt.ToString("HH:mm:ss");

				JArray wifinets = (JArray)data["wifinets"];

				int group = 0;
				foreach (var net in wifinets) {
					string device = net["device"].ToString();
					//string device = net["device"].ToString();

					JArray networks = (JArray)net["networks"];

					string bssid = "";
					string ssid = "";
					string encryption = "";
					string frequency = "";
					string mode = "";

					foreach (var network in networks) {
						if (string.IsNullOrEmpty(bssid)) {
							bssid = network["bssid"].ToString();
							ssid = network["ssid"].ToString();
							try {
								encryption = network["encryption"].ToString();
							} catch (Exception ex) {
								encryption = "none";
							}
							try {
								frequency = network["frequency"].ToString();
							} catch (Exception ex) {
								frequency = "auto";
							}
							mode = network["mode"].ToString();
						}
						JObject assoclist = (JObject)network["assoclist"];
						foreach (var assoc in assoclist) {
							AssocInfo info = new AssocInfo();
							info.mac = assoc.Key;
							JObject detail = JObject.Parse(assoc.Value.ToString());
							info.ssid = ssid;
							info.rxRate = detail["rx_rate"].ToString();
							info.txRate = detail["tx_rate"].ToString();
							info.txCcq = detail["txccq"].ToString();
							info.signal = detail["signal"].ToString();
							info.sigChain = detail["signalchains"].ToString();
							list.Add(assoc.Key, info);
							//Debug.WriteLine(assoc.Value);
						}
					}

					if (group == 0 && !mHeadWrite) {
						gb_device0.Text = device;
						lb_g_bssid_0.Text = bssid;
						lb_g_ssid_0.Text = ssid;
						lb_g_sec_0.Text = encryption;
						lb_g_freq_0.Text = frequency;
						lb_g_mode_0.Text = mode;
						mSaveHandle.WriteLine($"{device} | {bssid} | {ssid} | {encryption} | {frequency} | {mode} | |");
						mSaveHandle.Flush();
					}

					if (group == 1 && !mHeadWrite) {
						gb_device1.Text = device;
						lb_g_bssid_1.Text = bssid;
						lb_g_ssid_1.Text = ssid;
						lb_g_sec_1.Text = encryption;
						lb_g_freq_1.Text = frequency;
						lb_g_mode_1.Text = mode;
						mSaveHandle.WriteLine($"{device} | {bssid} | {ssid} | {encryption} | {frequency} | {mode} | |");
						mSaveHandle.Flush();
					}

					group++;
				}

				if (!mHeadWrite) {
					mSaveHandle.WriteLine($"DATE | SSID | MAC address | signal | signal chain | RxRate | TxRate | TxCCQ");
					mSaveHandle.Flush();
				}

				if (!mHeadWrite) {
					mHeadWrite = true;
				}

				lv_scan_list.Items.Clear();
				foreach (KeyValuePair<string, AssocInfo> items in list) {
					Console.WriteLine("{0} ,  {1}", items.Key, items.Value);
					AssocInfo info = items.Value;

					ListViewItem item = new ListViewItem(info.ssid);
					//item.SubItems.Add(point.date);
					item.SubItems.Add($"{info.mac}");
					item.SubItems.Add($"{info.signal} dBm");

					string sigChain = ParseSigChain(info.sigChain);

					item.SubItems.Add($"{sigChain} dBm");
					float.TryParse(info.rxRate, out float rxRate);
					item.SubItems.Add($"{rxRate / 1000,6:N0}Mbps");
					float.TryParse(info.txRate, out float txRate);
					item.SubItems.Add($"{txRate / 1000,6:N0}Mbps");
					item.SubItems.Add($"{info.txCcq,6} %");
					lv_scan_list.Items.Add(item);

					string date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

					mSaveHandle.WriteLine($"{date} | {info.ssid} | {info.mac} | {info.signal} | {sigChain} | {rxRate / 1000,6:N0} | {txRate / 1000,6:N0} | {info.txCcq,6}");
					mSaveHandle.Flush();
				}

				Debug.WriteLine(wifinets.Count);
				mSaveHandle.WriteLine($"");
				mSaveHandle.Flush();
			} catch { }
		}

		public void DispScanData(JObject data) {
			Debug.WriteLine("===========================> DispScanData");

			// 파일을 만든다...................
			// 어떤 기준일까????

			list.Clear();
			Invoke(new MethodInvoker(delegate () {
				try {
					Debug.WriteLine(data["uptime"].ToString());
					int.TryParse(data["uptime"].ToString(), out int value);
					TimeSpan time = TimeSpan.FromSeconds(value);
					DateTime dateTime = DateTime.Today.Add(time);
					lb_uptime.Text = dateTime.ToString("dd일 hh:mm:ss");
					Debug.WriteLine($"lb_uptime => {lb_uptime.Text}");

					//lb_uptime.Text = data["uptime"].ToString();

					//DateTime dt = DateTime.Parse(data["uptime"].ToString());
					//lb_uptime.Text = dt.ToString("HH:mm:ss");

					JArray wifinets = (JArray)data["wifinets"];

					int group = 0;
					foreach (var net in wifinets) {
						string device = net["device"].ToString();
						//string device = net["device"].ToString();

						JArray networks = (JArray)net["networks"];

						string bssid = "";
						string ssid = "";
						string encryption = "";
						string frequency = "";
						string mode = "";

						foreach (var network in networks) {
							if (string.IsNullOrEmpty(bssid)) {
								bssid = network["bssid"].ToString();
								ssid = network["ssid"].ToString();
								try {
									encryption = network["encryption"].ToString();
								} catch (Exception ex) {
									encryption = "none";
								}
								try {
									frequency = network["frequency"].ToString();
								} catch (Exception ex) {
									frequency = "auto";
								}
								mode = network["mode"].ToString();
							}
							JObject assoclist = (JObject)network["assoclist"];
							foreach (var assoc in assoclist) {
								AssocInfo info = new AssocInfo();
								info.mac = assoc.Key;
								JObject detail = JObject.Parse(assoc.Value.ToString());
								info.ssid = ssid;
								info.rxRate = detail["rx_rate"].ToString();
								info.txRate = detail["tx_rate"].ToString();
								info.txCcq = detail["txccq"].ToString();
								info.signal = detail["signal"].ToString();
								info.sigChain = detail["signalchains"].ToString();
								list.Add(assoc.Key, info);
								//Debug.WriteLine(assoc.Value);
							}
						}

						if (group == 0 && !mHeadWrite) {
							gb_device0.Text = device;
							lb_g_bssid_0.Text = bssid;
							lb_g_ssid_0.Text = ssid;
							lb_g_sec_0.Text = encryption;
							lb_g_freq_0.Text = frequency;
							lb_g_mode_0.Text = mode;
							mSaveHandle.WriteLine($"{device} | {bssid} | {ssid} | {encryption} | {frequency} | {mode} | |");
							mSaveHandle.Flush();
						}

						if (group == 1 && !mHeadWrite) {
							gb_device1.Text = device;
							lb_g_bssid_1.Text = bssid;
							lb_g_ssid_1.Text = ssid;
							lb_g_sec_1.Text = encryption;
							lb_g_freq_1.Text = frequency;
							lb_g_mode_1.Text = mode;
							mSaveHandle.WriteLine($"{device} | {bssid} | {ssid} | {encryption} | {frequency} | {mode} | |");
							mSaveHandle.Flush();
						}

						group++;
					}

					if (!mHeadWrite) {
						mSaveHandle.WriteLine($"DATE | SSID | MAC address | signal | signal chain | RxRate | TxRate | TxCCQ");
						mSaveHandle.Flush();
					}

					if (!mHeadWrite) {
						mHeadWrite = true;
					}

					lv_scan_list.Items.Clear();
					foreach (KeyValuePair<string, AssocInfo> items in list) {
						Console.WriteLine("{0} ,  {1}", items.Key, items.Value);
						AssocInfo info = items.Value;

						ListViewItem item = new ListViewItem(info.ssid);
						//item.SubItems.Add(point.date);
						item.SubItems.Add($"{info.mac}");
						item.SubItems.Add($"{info.signal} dBm");

						string sigChain = ParseSigChain(info.sigChain);

						item.SubItems.Add($"{sigChain} dBm");
						float.TryParse(info.rxRate, out float rxRate);
						item.SubItems.Add($"{rxRate / 1000,6:N0}Mbps");
						float.TryParse(info.txRate, out float txRate);
						item.SubItems.Add($"{txRate / 1000,6:N0}Mbps");
						item.SubItems.Add($"{info.txCcq,6} %");
						lv_scan_list.Items.Add(item);

						string date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

						mSaveHandle.WriteLine($"{date} | {info.ssid} | {info.mac} | {info.signal} | {sigChain} | {rxRate / 1000,6:N0} | {txRate / 1000,6:N0} | {info.txCcq,6}");
						mSaveHandle.Flush();
					}

					Debug.WriteLine(wifinets.Count);
					mSaveHandle.WriteLine($"");
					mSaveHandle.Flush();
				} catch { }
			}));
		}

		public void SaveScanData(JObject data) {
			Debug.WriteLine("===========================> SaveScanData");
		}

		private static void KillProcess(string filePath) {

			string processName = System.IO.Path.GetFileNameWithoutExtension(filePath);

			foreach (Process process in Process.GetProcessesByName(processName)) {
				if (!string.IsNullOrWhiteSpace(filePath)) {
					try {
						if (process.MainModule != null && process.MainModule.FileName != null && string.Compare(process.MainModule.FileName, filePath, true) == 0) {
							process.Kill();
						}
					} catch {
					}
				} else {
					process.Kill();
				}
			}
		}

		private static void Scan(MainForm form) {

			//string filename = "WaveLinker_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
			//StreamWriter sw = new StreamWriter(filename, true, Encoding.UTF8);

			ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
			chromeDriverService.HideCommandPromptWindow = true;

			string Url = $"http://{scanIp}:{scanPort}/cgi-bin/luci/;stok=1e1220bc87983e65395e7344?7344?status=1&_=0.6561156622211763";
			var options = new ChromeOptions();                                  // ChromeOptions 인스턴스 생성
			options.AddArgument("--headless");
			options.AddArgument("ignore-certificate-errors");
			options.AddArgument("--window-position=-32000,-32000");
			driver = new ChromeDriver(chromeDriverService, options);
			//driver.Navigate().GoToUrl(@"http://1.220.20.218:8012/cgi-bin/luci/;stok=1e1220bc87983e65395e7344?7344?status=1&_=0.6561156622211763");

			try {
				//driver.Navigate().GoToUrl(@"http://192.168.10.6:8081/cgi-bin/luci/;stok=1e1220bc87983e65395e7344?7344?status=1&_=0.6561156622211763");
				driver.Navigate().GoToUrl(Url);

				IWebElement pwInput = driver.FindElement(By.ClassName("cbi-input-password"));
				//pwInput.SendKeys("password");
				pwInput.SendKeys(scan_pw);

				IWebElement submit = driver.FindElement(By.ClassName("cbi-button-apply"));
				//*[@id="maincontent"]/form/div[2]/input[1]
				// html / body / div[2] / div[2] / form / div[2] / input[1]
				//*[@id="maincontent"]/form/div[2]/input[1]
				//submit = chrome_driver.FindElement(By.XPath(@"//*[@id='maincontent']/form/div[2]/input[1]"));
				submit.Click();

				isScan = true;
				if (form.InvokeRequired) {
					form.Invoke(new MethodInvoker(delegate () {
						form.bt_scan.BackColor = Color.Green;
					}));
				}

				while (isScan) {
					WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
					IWebElement body = driver.FindElement(By.CssSelector("body"));
					try {
						JObject data = JObject.Parse(body.Text);
						Debug.WriteLine(data.ToString());

						if (form.InvokeRequired) {
							form.Invoke(new MethodInvoker(delegate () {
								form.DispScanData(data);
								if (form.cb_auto_save.Checked) {
									// header 를 찍는다....
									form.SaveScanData(data);
								}
							}));
						}
						Thread.Sleep(4000);
					} catch { }
					driver.Navigate().Refresh();
				}
				mSaveHandle.Close();
			} catch {
			}

			try {
				KillProcess("chromedriver.exe");
				KillProcess("Google Chrome.exe");

				driver.Quit();      // 크롬 드라이버 종료, 메모리 해제
				driver.Dispose();
				driver.Close();

				//KillProcess(Path.Combine(executingDirectoryPath, "chromedriver.exe"));
			} catch {
			}
			isScan = false;

			//sw.Close();

			if (form.InvokeRequired) {
				form.Invoke(new MethodInvoker(delegate () {
					form.bt_scan.BackColor = Color.White;
				}));
			}
		}

		private void bt_print_Click(object sender, EventArgs e) {
			string filename = "WaveLinker_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

			// 파일 IO 스트림을 취득한다.
			using (var stream = new FileStream(filename, FileMode.Create, FileAccess.Write)) {
				// Pdf형식의 document를 생성한다.
				Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);

				PdfWriter writer = PdfWriter.GetInstance(doc, stream);
				doc.Open();
				try {
					// Create a Simple table
					PdfPTable table = new PdfPTable(8);
					table.SetTotalWidth(new float[] { 10f, 10f, 30f, 11f, 8f, 8f, 8f, 5f });
					table.WidthPercentage = 100;

					PdfPCell cell = new PdfPCell(new Phrase("WaveLinker Scan List 일지[검사]", fontS));
					cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
					cell.Colspan = 8;
					cell.FixedHeight = 36;
					cell.HorizontalAlignment = Element.ALIGN_CENTER;
					table.AddCell(cell);

					string title = string.Format("Scan 기간 : {0} 부터 {1} 까지", DateTime.Now, DateTime.Now);
					cell = new PdfPCell(new Phrase(title, fontS));
					cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
					cell.Colspan = 5;
					cell.FixedHeight = 20;
					cell.HorizontalAlignment = Element.ALIGN_LEFT;
					table.AddCell(cell);
					title = string.Format("작성일자 : {0}, 처리건수 : {1}건", DateTime.Now, 3);
					cell = new PdfPCell(new Phrase(title, fontS));
					cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
					cell.Colspan = 3;
					cell.FixedHeight = 20;
					cell.HorizontalAlignment = Element.ALIGN_RIGHT;
					table.AddCell(cell);

					table.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

					table.AddCell(new Phrase("SSID", fontS));
					table.AddCell(new Phrase("MAC Addr", fontS));
					table.AddCell(new Phrase("Signal", fontS));
					table.AddCell(new Phrase("Signal Chain", fontS));
					table.AddCell(new Phrase("RxRate", fontS));
					table.AddCell(new Phrase("TxRate", fontS));
					table.AddCell(new Phrase("TxCCQ", fontS));

					/*
					foreach (var notice in notices) {
						// Set First row as header
						//table.He.HeaderRows(1);
						// Add header details
						table.AddCell("Name");
						table.AddCell("Class");
						table.AddCell("Subjects");
						table.AddCell("Result");

						// Add the data
						table.AddCell("Student1");
						table.AddCell("5th");

						table.AddCell("Fail");
					}
					*/

					doc.Add(table);
				} catch (Exception ex) {
					Console.WriteLine(ex.Message);
				} finally {
					doc.Close();
					//PrintJob printJob = new PrintJob("Printer Name", filename);
					//printJob.Print();

					// document Close
					PrintDialog printDlg = new PrintDialog();
					System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
					//printDoc.DocumentName = "Timer_20240824_135104.pdf";
					printDlg.Document = printDoc;
					printDlg.AllowSelection = true;
					printDlg.AllowSomePages = true;
					//Call ShowDialog  
					if (printDlg.ShowDialog() == DialogResult.OK) {
						//printDlg.PrinterSettings.PrinterName.
						PrintJob printJob = new PrintJob(printDlg.PrinterSettings.PrinterName, filename);
						printJob.Print();

						//printDoc.Print();
					}

				}

			}
		}

		// 날자별 합계
		// 정산 지우기는 관리자만 할수 있게...
		private void cb_PcNum_SelectedIndexChanged(object sender, EventArgs e) {
			//var groupedPost = GlobalHelpers.mDB.Find(p => p.amt_1 > 10).GroupBy(p.* Group Condition *);
			//var groupedPost = GlobalHelpers.mDB.Find(p => p.amt_1 > 10).GroupBy(p => p.pc_num);
			//var groupedPost = GlobalHelpers.mDB.FindAll().Gr.GroupBy(p=> p.pc_num);
			string pc_num = ((ComboBox)sender).Text;
			IEnumerable<ScanInfo> result = null;
			if (!"전체".Equals(pc_num)) {
				result = GlobalHelpers.mDB.Query()
							.Where(p => p.ifname.Equals(pc_num))
							.OrderBy(p => p.ifname)
							//.GroupBy()
							.ToList();
			} else {
				result = GlobalHelpers.mDB.Query()
							.OrderBy(p => p.ifname)
							//.GroupBy()
							.ToList();
			}
			int sum = 0;
			lv_scan_list.Items.Clear();
			foreach (ScanInfo point in result) {
				ListViewItem item = new ListViewItem($"{point.ifname} {point.bigo}");
				lv_scan_list.Items.Add(item);
				//sum += point.amt_1;
			}

			//lb_total_sum.Text = string.Format($"{{0:N0}}", sum);
		}

		private void cb_ip_TextChanged(object sender, EventArgs e) {
			scanIp = ((ComboBox)sender).Text;
		}

		private void tb_port_TextChanged(object sender, EventArgs e) {
			int.TryParse(((TextBox)sender).Text, out int port);
			scanPort = port;
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
			Environment.Exit(0);
		}

		private void gb_device0_Enter(object sender, EventArgs e) {

		}
	}
}
