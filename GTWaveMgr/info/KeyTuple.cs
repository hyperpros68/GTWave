using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyBoBu.info
{
	public	class	KeyTuple {
		public	string	key		{ get; set; }	= "";
		public	string	ext		{ get; set; }	= "";
		public	string	val		{ get; set; }	= "";
		public	string	dispVal { get; set; }	= "";
		public	OidTuple	tuple;

		public KeyTuple Clone() {
			KeyTuple info = new KeyTuple();
			info.key = key;
			info.ext = ext;
			info.val = val;
			info.dispVal = dispVal;

			info.tuple = tuple;

			return info;
		}
	}
}
