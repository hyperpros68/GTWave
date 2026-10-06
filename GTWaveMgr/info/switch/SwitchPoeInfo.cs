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
	public	class SwitchPoeInfo : SwitchBaseInfo 
	{
		public	KeyTuple	poeAdmin	= new KeyTuple();
		public	KeyTuple	operStatus	= new KeyTuple();
		public	KeyTuple	poeClass	= new KeyTuple();
		public	KeyTuple	poeVoltage	= new KeyTuple();
		public	KeyTuple	poePower	= new KeyTuple();
		public	KeyTuple	poeCurrent	= new KeyTuple();


		public	void	SetValue(string oid, string val) {
			var fields = typeof(SwitchPoeInfo).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
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

		public	string[] GetString4Oids() {
			var fields = typeof(SwitchPoeInfo).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

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

		public	SwitchPoeInfo	Clone(int bIdx, int idx) {
			SwitchPoeInfo info = new SwitchPoeInfo();
			info.base_oid	= base_oid;

			info.poeAdmin	= poeAdmin.Clone();
			info.operStatus = operStatus.Clone();
			info.poeClass	= poeClass.Clone();
			info.poeVoltage = poeVoltage.Clone();
			info.poePower	= poePower.Clone();
			info.poeCurrent = poeCurrent.Clone();

			try {
				info.poeAdmin.tuple.valueParse();
				info.operStatus.tuple.valueParse();
				info.poeClass.tuple.valueParse();
				info.poeVoltage.tuple.valueParse();
				info.poePower.tuple.valueParse();
				info.poeCurrent.tuple.valueParse();
			} catch (Exception) { }

			SetLastIdx(info.poeAdmin, bIdx, idx);
			SetLastIdx(info.operStatus, bIdx, idx);
			SetLastIdx(info.poeClass, bIdx, idx);
			SetLastIdx(info.poeVoltage, bIdx, idx);
			SetLastIdx(info.poePower, bIdx, idx);
			SetLastIdx(info.poeCurrent, bIdx, idx);

			return info;
		}

		public ListViewItem	getItem(int idx) {
			ListViewItem item = new ListViewItem(idx.ToString());
			item.Tag = this;

			item.SubItems.Add(poeAdmin.dispVal);
			item.SubItems.Add(operStatus.dispVal);
			item.SubItems.Add(poeClass.dispVal);
			item.SubItems.Add(poeVoltage.dispVal);
			item.SubItems.Add(poePower.dispVal);
			/*
			item.SubItems.Add(String.Format("{0:#,0}", price));
			*/
			item.SubItems.Add(poeCurrent.dispVal);

			return item;
		}

	}
}
