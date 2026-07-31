using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyBoBu.info
{
	public	class	OidTuple {
		public	int			id			{ get; set; }	= 0;
		public	int			deviceId	{ get; set; }	= 0;
		public	string		key			{ get; set; }	= "";

		// SysInfo, SysStatus, PortStatus, PoeStatus, DdmStatus
		public	string		kind		{ get; set; }	= "";

		public	string		name		{ get; set; }	= "";
		public	string		oid			{ get; set; }	= "";
		public	string		type		{ get; set; }	= "";
		public	string		value		{ get; set; }	= "";
		public	string		desc		{ get; set; }	= "";

		public	string		scanVal		{ get; set; }	= "";

		public	Hashtable	values		= new Hashtable();

		Dictionary<int, String> keys = new Dictionary<int, String>();

		public	OidTuple(int deviceId)
		{
			this.deviceId = deviceId;
		}
		/*
		public	string	getString4Value() {
			StringBuilder sb = new StringBuilder();
			string val = string.Empty;
			foreach (var value in values) {
				//string line = $"";
				Debug.WriteLine($"{value}");
				sb.Append(value);
			}
		}
		*/

		public string SetValue(string val) {
			if (values != null && values.Count > 0) {
				try {
					string retv = (string)values[val];
					if (retv == null) retv = "";
					return	$"{retv}({val})";
				} catch (Exception e) { }
			}
			return val;
		}

		public string	getString() {
			StringBuilder sb = new StringBuilder();
			string val = string.Empty;
			foreach (var value in values) {
				//string line = $"";
				Debug.WriteLine($"{value}");
				sb.Append(value);
			}
			return $"{this.key},{this.name},{this.oid},{this.type},{this.value},{this.desc}";
		}

		public	void	setParse(string data) {
			string[] items = data.Split(',');
			if (items.Length > 4) {
				key		= items[0].Trim();
				name	= items[1].Trim();
				oid		= items[2].Trim();
				type	= items[3].Trim();
				value	= items[4].Trim();
				try {
					desc = items[5].Trim();
				} catch { }
				valueParse(value);
			}
		}

		public	ListViewItem	getItem() {
			ListViewItem item = new ListViewItem(key);
			item.Tag = this;

			//item.SubItems.Add(key);
			item.SubItems.Add(name);
			item.SubItems.Add(oid);
			item.SubItems.Add(value);
			item.SubItems.Add(desc);

			return item;
		}

		public void valueParse() {
			valueParse(value);
		}

		// 0:kr; 1:eng
		public void	valueParse(string desc) {
			if (string.IsNullOrEmpty(desc)) {
				return;
			}
			string[] items = desc.Split(';');

			values.Clear();
			foreach (string item in items) {
				try {
					string[] tuple = item.Split(new char[] { ':' });
					if (tuple.Count() > 1) {
						values.Add(tuple[0].Trim(), tuple[1].Trim());
					}
				} catch (Exception ee) { }
			}
		}

		public	bool	valid() {
			if (string.IsNullOrEmpty(key))	return false;
			
			return	true;
		}	

		public string	dispValue(string key) {
			string value = (string)values[key];
			if (!string.IsNullOrEmpty(value)) {
				return value;
			}
			return	"";
		}
	}
}
