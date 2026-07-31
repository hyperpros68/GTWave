using OpenQA.Selenium.BiDi.Modules.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AutoReserve {
	public	class	TupleInfo {
		public	string	subject	{ get; set; }
		public	string	desc	{ get; set; }
		public	string	date;
		public	string	sTime;
		public	string	eTime;
		public	string	coat;

		public ListViewItem getItem() {
			ListViewItem item = new ListViewItem("");
			item.Tag	= this;
			item.Text	= subject;

			item.SubItems.Add(date);
			item.SubItems.Add($"{coat} 코트");
			item.SubItems.Add($"{sTime}시 ~ {eTime}시");
			item.SubItems.Add(subject);
			item.SubItems.Add(desc);

			return item;
		}

		public bool IsEquals(TupleInfo other) {
			if (this.date.Equals(other.date) &&
				this.sTime.Equals(other.sTime) &&
				this.eTime.Equals(other.eTime) &&
				this.coat.Equals(other.coat)) {

				return true;
			}

			return false;
		}
	}
}
