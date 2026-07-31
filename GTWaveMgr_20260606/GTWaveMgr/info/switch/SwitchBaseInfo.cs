using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IronPython.Modules._ast;
using static MindFusion.Swf.Tools;

namespace AnyBoBu.info
{
	public	class	SwitchBaseInfo
    {
		public	string	base_oid			{ get; set; }	= "";

		public	object	FindField(string name) {
			// public변수가 아니면 GetField에서 null이 리턴된다
			var result = this.GetType().GetField(name).GetValue(this);
			return result;
		}

		public	void	SetOid(OidTuple tuple) {
			KeyTuple info = (KeyTuple)FindField(tuple.key);
			if (info != null) {
				info.key = tuple.key;
				info.ext = tuple.oid;
				info.tuple = tuple;
			}
		}

		/*
		public void	SetValue(string oid, string val) {
			var fields = typeof(SwitchDdmInfo).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			for (int i = 0; i < fields.Length; i++) {
				//int필드 체크
				if (fields[i].FieldType == typeof(KeyTuple)) {
					KeyTuple tuple = (KeyTuple)FindField(fields[i].Name);
					//Debug.WriteLine(fields[i].Name);
					//Debug.WriteLine(oid);
					//Debug.WriteLine(tuple.ext);

					if (tuple.ext.Equals("." + oid)) {
						tuple.val = val;
					}
				}
			}
		}

		public	string[] GetString4Oids() {
			var fields = typeof(SwitchDdmInfo).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

			List<string> list = new List<string>();
			for (int i = 0; i < fields.Length; i++) {
				//int필드 체크
				if (fields[i].FieldType == typeof(KeyTuple)) {
					KeyTuple tuple = (KeyTuple)FindField(fields[i].Name);
					list.Add(tuple.ext);
				}
			}
			return list.ToArray();
		}

		*/
		public int		LastIdx(string oid) {
			try {
				//Debug.WriteLine(oid.Substring(0, oid.LastIndexOf(".")));
				//Debug.WriteLine(oid.Substring(oid.LastIndexOf(".") + 1));
				int last = Int32.Parse(oid.Substring(oid.LastIndexOf(".") + 1));
				return last;
			} catch {
			}
			return 0;
		}

		public	void	SetLastIdx(KeyTuple tuple, int bIdx, int idx) {
			if (LastIdx(tuple.ext) >= bIdx) {
				//Debug.WriteLine(tuple.ext.Substring(0, tuple.ext.LastIndexOf(".")));
				tuple.ext = tuple.ext.Substring(0, tuple.ext.LastIndexOf(".") + 1) + (bIdx + idx).ToString();
			}
		}

	}
}
