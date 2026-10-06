using Microsoft.JScript;
using MindFusion.Vsx;
using MySql.Data.MySqlClient;
using SnmpSharpNet;
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
	public	class	SwitchPortInfo : SwitchBaseInfo 
	{
		public	KeyTuple	ifNumber	= new KeyTuple();
		public	KeyTuple	ifIndex		= new KeyTuple();
		public	KeyTuple	ifDescr		= new KeyTuple();
		public	KeyTuple	ifAdminStatus = new KeyTuple();
		public	KeyTuple	ifOperStatus = new KeyTuple();
		public	KeyTuple	ifSpeed		= new KeyTuple();
		public	KeyTuple	ifInOctets	= new KeyTuple();
		public	KeyTuple	ifOutOctets = new KeyTuple();


		public void	SetValue(string oid, string val) {
			var fields = typeof(SwitchPortInfo).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			for (int i = 0; i < fields.Length; i++) {
				//int필드 체크
				if (fields[i].FieldType == typeof(KeyTuple)) {
					KeyTuple info = (KeyTuple)FindField(fields[i].Name);
					//Debug.WriteLine(fields[i].Name);
					//Debug.WriteLine(oid);
					//Debug.WriteLine(tuple.ext);

					if (info.ext.Equals("." + oid)) {
						info.val = val;
						if (info.tuple != null) {
							info.dispVal = info.tuple.SetValue(val);
						} else {
							info.dispVal = val;
						}
					}
				}
			}
		}

		public	string[]	GetString4Oids() {
			var fields = typeof(SwitchPortInfo).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

			List<string> list = new List<string>();
			for (int i = 0; i < fields.Length; i++) {
				//int필드 체크
				if (fields[i].FieldType == typeof(KeyTuple)) {
					if ("ifNumber".Equals(fields[i].Name)) continue;
					if ("ifIndex".Equals(fields[i].Name)) continue;
					KeyTuple tuple = (KeyTuple)FindField(fields[i].Name);
					list.Add(tuple.ext);
				}
			}
			return list.ToArray();
		}

		/*
		public	object	FindField(string name) {
			// public변수가 아니면 GetField에서 null이 리턴된다
			var result = this.GetType().GetField(name).GetValue(this); 
			return result;
		}

		public	void	SetOid(OidTuple tuple) {
			KeyTuple info = (KeyTuple)FindField(tuple.key);
			if (info != null) {
				info.key	= tuple.key;
				info.ext	= tuple.oid;
				info.tuple	= tuple;
			}
		}

		public int		LastIdx(string oid) {
			try {
				//Debug.WriteLine(oid.Substring(0, oid.LastIndexOf(".")));
				//Debug.WriteLine(oid.Substring(oid.LastIndexOf(".")+1));
				int last = Int32.Parse(oid.Substring(oid.LastIndexOf(".")+1));
				return last;
			} catch {
			}
			return	0;
		}

		public	void	SetLastIdx(KeyTuple tuple, int bIdx, int idx) {
			if (LastIdx(tuple.ext) >= bIdx) {
				//Debug.WriteLine(tuple.ext.Substring(0, tuple.ext.LastIndexOf(".")));
				tuple.ext = tuple.ext.Substring(0, tuple.ext.LastIndexOf(".")+1) + (bIdx+idx).ToString();
			}
		}
		*/

		public SwitchPortInfo	Clone(int bIdx, int idx) {
			SwitchPortInfo info = new SwitchPortInfo();
			info.base_oid	= base_oid;

			//클래스의 필드들 모두 가져오기
			/*
			var fields = typeof(SwitchPortInfo).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			for (int i = 0; i < fields.Length; i++) {
				//int필드 체크
				if (fields[i].FieldType == typeof(KeyTuple)) {
					fields[i]..SetValue(data, 999);
				}
			}
			*/
			info.ifNumber		= ifNumber.Clone();
			info.ifIndex		= ifIndex.Clone();
			info.ifDescr		= ifDescr.Clone();
			info.ifAdminStatus	= ifAdminStatus.Clone();
			info.ifOperStatus	= ifOperStatus.Clone();
			info.ifSpeed		= ifSpeed.Clone();
			info.ifInOctets		= ifInOctets.Clone();
			info.ifOutOctets	= ifOutOctets.Clone();
			try {
				info.ifNumber.tuple.valueParse();
				info.ifIndex.tuple.valueParse();
				info.ifDescr.tuple.valueParse();
				info.ifAdminStatus.tuple.valueParse();
				info.ifOperStatus.tuple.valueParse();
				info.ifSpeed.tuple.valueParse();
				info.ifInOctets.tuple.valueParse();
				info.ifOutOctets.tuple.valueParse();
			} catch (Exception) { }

			SetLastIdx(info.ifNumber, bIdx, idx);
			SetLastIdx(info.ifIndex, bIdx, idx);
			SetLastIdx(info.ifDescr, bIdx, idx);
			SetLastIdx(info.ifAdminStatus, bIdx, idx);
			SetLastIdx(info.ifOperStatus, bIdx, idx);
			SetLastIdx(info.ifSpeed, bIdx, idx);
			SetLastIdx(info.ifInOctets, bIdx, idx);
			SetLastIdx(info.ifOutOctets, bIdx, idx);

			return info;
		}

		public	int		GetActive() {
			Int32.TryParse(ifAdminStatus.val, out int val1);
			Int32.TryParse(ifOperStatus.val, out int val2);

			if (val1 == 2) return 2;
			if (val2 == 2) return 0;
			return	1;
		}

		public	ListViewItem	getItem() {
			ListViewItem item = new ListViewItem(ifDescr.dispVal);
			item.Tag = this;

			//item.SubItems.Add(ifNumber.val);
			//item.SubItems.Add(ifIndex.val);
			//item.SubItems.Add(ifDescr.val);
			item.SubItems.Add(ifAdminStatus.dispVal);
			item.SubItems.Add(ifOperStatus.dispVal);
			/*
			item.SubItems.Add(String.Format("{0:#,0}", src_promo_cost));
			*/
			item.SubItems.Add(ifSpeed.dispVal);
			item.SubItems.Add(ifInOctets.dispVal);
			item.SubItems.Add(ifOutOctets.dispVal);

			return item;
		}

	}
}
