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
	public	class SwitchDdmInfo : SwitchBaseInfo 
	{
		public	KeyTuple	sfpDeviceName		= new KeyTuple();
		public	KeyTuple	sfpConnectorName	= new KeyTuple();
		public	KeyTuple	sfpEncodingCode		= new KeyTuple();
		public	KeyTuple	sfpBitRate			= new KeyTuple();
		public	KeyTuple	sfpTransmitDistance = new KeyTuple();
		public	KeyTuple	sfpLaserWaveLength	= new KeyTuple();
		public	KeyTuple	sfpTemmperature		= new KeyTuple();
		public	KeyTuple	sfpVoltage			= new KeyTuple();
		public	KeyTuple	sfpTxBias			= new KeyTuple();
		public	KeyTuple	sfpTxPower			= new KeyTuple();
		public	KeyTuple	sfpRxPower			= new KeyTuple();

		public void	SetValue(string oid, string val) {
			var fields = typeof(SwitchDdmInfo).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
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

		public SwitchDdmInfo Clone(int bIdx, int idx) {
			SwitchDdmInfo info = new SwitchDdmInfo();
			info.base_oid			= base_oid;

			info.sfpDeviceName		= sfpDeviceName.Clone();
			info.sfpConnectorName	= sfpConnectorName.Clone();
			info.sfpEncodingCode	= sfpEncodingCode.Clone();
			info.sfpBitRate			= sfpBitRate.Clone();
			info.sfpTransmitDistance = sfpTransmitDistance.Clone();
			info.sfpLaserWaveLength = sfpLaserWaveLength.Clone();
			info.sfpTemmperature	= sfpTemmperature.Clone();
			info.sfpVoltage			= sfpVoltage.Clone();
			info.sfpTxBias			= sfpTxBias.Clone();
			info.sfpTxPower			= sfpTxPower.Clone();
			info.sfpRxPower			= sfpRxPower.Clone();

			try {
				info.sfpDeviceName.tuple.valueParse();
				info.sfpConnectorName.tuple.valueParse();
				info.sfpEncodingCode.tuple.valueParse();
				info.sfpBitRate.tuple.valueParse();
				info.sfpTransmitDistance.tuple.valueParse();
				info.sfpLaserWaveLength.tuple.valueParse();
				info.sfpTemmperature.tuple.valueParse();
				info.sfpVoltage.tuple.valueParse();
				info.sfpTxBias.tuple.valueParse();
				info.sfpTxPower.tuple.valueParse();
				info.sfpRxPower.tuple.valueParse();
			} catch (Exception) { }

			SetLastIdx(info.sfpDeviceName, bIdx, idx);
			SetLastIdx(info.sfpConnectorName, bIdx, idx);
			SetLastIdx(info.sfpEncodingCode, bIdx, idx);
			SetLastIdx(info.sfpBitRate, bIdx, idx);
			SetLastIdx(info.sfpTransmitDistance, bIdx, idx);
			SetLastIdx(info.sfpLaserWaveLength, bIdx, idx);
			SetLastIdx(info.sfpTemmperature, bIdx, idx);
			SetLastIdx(info.sfpVoltage, bIdx, idx);
			SetLastIdx(info.sfpTxBias, bIdx, idx);
			SetLastIdx(info.sfpTxPower, bIdx, idx);
			SetLastIdx(info.sfpRxPower, bIdx, idx);

			return info;
		}

		public ListViewItem	getItem(int idx) {
			ListViewItem item = new ListViewItem(idx.ToString());
			item.Tag = this;

			item.SubItems.Add(sfpDeviceName.dispVal);
			item.SubItems.Add(sfpConnectorName.dispVal);
			item.SubItems.Add(sfpEncodingCode.dispVal);
			item.SubItems.Add(sfpBitRate.dispVal);
			item.SubItems.Add(sfpTransmitDistance.dispVal);
			/*
			item.SubItems.Add(String.Format("{0:#,0}", price));
			*/
			item.SubItems.Add(sfpLaserWaveLength.dispVal);
			item.SubItems.Add(sfpTemmperature.dispVal);
			item.SubItems.Add(sfpVoltage.dispVal);
			item.SubItems.Add(sfpTxBias.dispVal);
			item.SubItems.Add(sfpTxPower.dispVal);
			item.SubItems.Add(sfpRxPower.dispVal);

			return item;
		}
	}
}
