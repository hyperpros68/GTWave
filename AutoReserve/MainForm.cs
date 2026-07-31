using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace AutoReserve {
	public partial class MainForm : Form {

		ChromeDriver chromeDriver;

		int		mCoatNum	= 10;
		int		mTimeMin	= 6;
		int		mTimeMax	= 24;

		//string	base_url	= "https://sports.cfmc.or.kr/";
		string	base_url	= "https://sports.cfmc.or.kr/rent/reservation/index/2025/01/14/1/CHEONAN01/05/29";

		List<TupleInfo> mReserve = new List<TupleInfo>();

		public class Data {
			public string Name { get; set; }
			public string Value { get; set; }
		}

		public MainForm() {
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e) {

			ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
			chromeDriverService.HideCommandPromptWindow = true;
			chromeDriver = new ChromeDriver(chromeDriverService);
			chromeDriver.Navigate().GoToUrl(base_url);

			// coat 추가
			BindingList<Data> _coatItems = new BindingList<Data>();
			for (int i = 0; i < mCoatNum; i++) {
				_coatItems.Add(new Data { Name = $"{i + 1:D2} 코트", Value = (i + 1).ToString() });
				//cb_coat.Items.Add(new { Text = $"{i + 1:D2} 코트", Value = (i + 1).ToString() });
			}
			cb_coat.DataSource = _coatItems;
			cb_coat.DisplayMember = "Name";
			cb_coat.ValueMember = "Value";

			cb_coat.SelectedIndex = 0;


			// 시작 시간
			BindingList<Data> _stimeItems = new BindingList<Data>();
			for (int i = mTimeMin; i <= mTimeMax; i++) {
				_stimeItems.Add(new Data { Name = $"{i:D2} 시", Value = i.ToString() });
			}
			cb_s_date.DataSource = _stimeItems;
			cb_s_date.DisplayMember = "Name";
			cb_s_date.ValueMember = "Value";

			cb_s_date.SelectedIndex = 0;


			// 종료 시간
			BindingList<Data> _etimeItems = new BindingList<Data>();
			for (int i = mTimeMin; i <= mTimeMax; i++) {
				_etimeItems.Add(new Data { Name = $"{i:D2} 시", Value = i.ToString() });
			}
			cb_e_date.DataSource = _etimeItems;
			cb_e_date.DisplayMember = "Name";
			cb_e_date.ValueMember = "Value";

			cb_e_date.SelectedIndex = 0;

			LoadList(lv_reserve, "reserve.mvia");
			// //*[@id='btn_prev']
			// 확인을 누른다...
			var button_to_click = chromeDriver.FindElement(By.XPath("//*[@id='btn_prev']"));
			button_to_click.Click();

			var login = chromeDriver.FindElement(By.XPath("//*[@id=\"tnb\"]/ul/li[2]"));
			Debug.WriteLine(login.Text);
			if ("로그인".Equals(login.Text)) {
				MessageBox.Show("로그인을 진행해 주세요", "알림창");
				login.Click();
			}

			while(true) {
				Thread.Sleep(2000);

				var logined = chromeDriver.FindElement(By.XPath("//*[@id=\"tnb\"]/ul/li[2]"));
				Debug.WriteLine(logined.Text);
				try {
					if ("로그아웃".Equals(logined.Text)) {
						Debug.WriteLine(logined.Text);
						break;
					}
				} catch { }
			}

		}

		private void bt_start_Click(object sender, EventArgs e) {
			DateTime dt = dtp_date.Value;
			string str = string.Format("{0}월 {1}일을 선택", dt.Month, dt.Day);
			MessageBox.Show(str, "선택 날짜");
		}

		private void bt_add_Click(object sender, EventArgs e) {

			TupleInfo tuple = new TupleInfo();
			tuple.date = dtp_date.Text;

			tuple.coat = ((Data)(cb_coat.SelectedItem)).Value;
			tuple.sTime = ((Data)(cb_s_date.SelectedItem)).Value;
			tuple.eTime = ((Data)(cb_e_date.SelectedItem)).Value;
			tuple.subject = tb_subject.Text;
			tuple.desc = tb_desc.Text;

			//같은 내용이 있는지 확인
			foreach (ListViewItem item in lv_reserve.Items) {
				TupleInfo info = (TupleInfo)item.Tag;
				if (tuple.IsEquals(info)) {
					MessageBox.Show("같은 예약이 있습니다.", "알림창");
					return;
				}
			}

			lv_reserve.Items.Add(tuple.getItem());
		}

		public void SaveList(ListView list, string filename) {
			try {
				StreamWriter sw = new StreamWriter(filename);
				foreach (ListViewItem item in lv_reserve.Items) {
					TupleInfo info = (TupleInfo)item.Tag;
					//string line = $"{info.date}, {info.coat}, {info.sTime}, {info.eTime}";
					sw.WriteLine($"{info.date}| {info.coat}| {info.sTime}| {info.eTime}| {info.subject}| {info.desc}");
				}
				sw.Close();
			} catch (Exception e) {
				Console.WriteLine("Exception: " + e.Message);
			} finally {
				Console.WriteLine("Executing finally block.");
			}
		}

		public void LoadList(ListView list, string filename) {
			lv_reserve.Items.Clear();
			String line;
			try {
				//Pass the file path and file name to the StreamReader constructor
				StreamReader sr = new StreamReader(filename);
				//Read the first line of text
				line = sr.ReadLine();
				//Continue to read until you reach end of file
				while (line != null) {
					//write the line to console window
					Console.WriteLine(line);
					string[] items = line.Split("|");
					TupleInfo info = new TupleInfo();
					info.date		= items[0].Trim();
					info.coat		= items[1].Trim();
					info.sTime		= items[2].Trim();
					info.eTime		= items[3].Trim();
					info.subject	= items[4].Trim();
					info.desc		= items[5].Trim();

					ListViewItem item = info.getItem();
					item.Tag = info;
					lv_reserve.Items.Add(item);

					//Read the next line
					line = sr.ReadLine();
				}
				//close the file
				sr.Close();
			} catch (Exception e) {
				Console.WriteLine("Exception: " + e.Message);
			} finally {
				Console.WriteLine("Executing finally block.");
			}
			/*
			try {
				using (Stream file = File.Open(filename, FileMode.Open)) {
					BinaryFormatter bf = new BinaryFormatter();
					object obj = bf.Deserialize(file);

					ListViewItem[] nodeList = (obj as IEnumerable<ListViewItem>).ToArray();

					list.Items.AddRange(nodeList);

					foreach (ListViewItem item in list.Items) {
						TupleInfo info = new TupleInfo();
						info.date = item.SubItems[1].Text;
						info.coat = item.SubItems[2].Text;


						item.Tag = info;
					}


					//List<String> output = new List<string>();
					// TreeView의 모든 루트 노드부터 시작
					//foreach (TreeNode tn in tree.Nodes) {
					//	AddNodeText(tn, output);
					//}
					//Debug.WriteLine(output.ToArray());
				}
			} catch { }
			*/
		}

		private void bt_del_Click(object sender, EventArgs e) {
			if (lv_reserve.SelectedItems.Count == 0) {
				MessageBox.Show("선택된 항목이 없습니다.", "알림창");
				return;
			}

			lv_reserve.Items.Remove(lv_reserve.SelectedItems[0]);
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
			chromeDriver.Close();
			chromeDriver.Quit();

			SaveList(lv_reserve, "reserve.mvia");
		}

		private void bt_stop_Click(object sender, EventArgs e) {
			Close();
		}

		private void bt_all_del_Click(object sender, EventArgs e) {
			lv_reserve.Items.Clear();
		}
	}
}
