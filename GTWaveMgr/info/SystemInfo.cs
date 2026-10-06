using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyBoBu.info
{
	[Serializable]
	public	class	SystemInfo
    {
		public	int			id			{ get; set; }	= 0;

		public	string		name		{ get; set; }	= "";
		public	string		spec		{ get; set; }	= "";
		public	string		imagePath	{ get; set; }	= "";
		public	Image		image;
		public	string		desc		{ get; set; }	= "";

		public	bool		IsActive	{ get; set; }

		// -1 => no type
		// 1 -> switch
		// 2 -> wireless
		// 3 ~ 9 -> etc
		public new	int		GetType() {
			if (string.IsNullOrEmpty(name)) return -1;
			string temp = name.ToLower();
			if (temp.Contains("switch") || temp.Contains("스위치")) {
				return 1; 
			} else if (temp.Contains("wireless") || temp.Contains("무선") || temp.Contains("wifi") || temp.Contains("ap")) {
				return 2;
			}
			return -1;
		}


		public	static SystemInfo	Find(ListView lv_system, DeviceInfo device) {
			foreach (ListViewItem item in lv_system.Items) {
				if (item.Tag != null) {
					SystemInfo mSystemInfo = (SystemInfo)(item.Tag);
					if (mSystemInfo != null) {
						if (device.type.Equals(mSystemInfo.name)) {
							//tb_system_image_path.Text = mSystemInfo.imagePath;
							return	mSystemInfo;
						}
					}
				}
			}

			return null;
		}

		public	ListViewItem getItem() {
			ListViewItem item = new ListViewItem(id.ToString());
			item.Tag = this;

			//item.SubItems.Add(title);
			item.SubItems.Add(name);
			item.SubItems.Add(spec);
			item.SubItems.Add(desc);
			//item.SubItems.Add(bigo);

			return item;
		}

		public	void	setInfo(MySqlDataReader reader)
		{
			if (reader == null) return;

			//groupIdx		= reader.GetInt32("PROMO_PRICE");
			//prevIdx			= reader.GetInt32("NUM_IID");
			//groupIdx		= reader["THUMBNAIL"].ToString();
			//prevIdx			= reader["THUMBNAIL"].ToString();
			/*
			title			= reader["TITLE"].ToString();
			thumbnail		= reader["THUMBNAIL"].ToString();

			regDate			= reader["REG_DATE"].ToString();
			fixDate			= reader["FIX_DATE"].ToString();
			valid			= reader["VALID"].ToString();
			bigo			= reader["BIGO"].ToString();
			*/
		}

	}
}
