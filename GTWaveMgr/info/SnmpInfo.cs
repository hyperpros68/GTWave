using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyBoBu.info
{
	public	class	SnmpInfo
    {
		public	int			id			{ get; set; }	= 0;
		public	int			deviceId	{ get; set; }	= 0;

		public	int			port		{ get; set; }	= 161;
		public string		version		{ get; set; }	= "v2c";

		public	string		readComm	{ get; set; }	= "public";
		public	string		writeComm	{ get; set; }	= "private";

		public	string		v3Username	{ get; set; }	= "admin";
		public	string		v3AuthAlg	{ get; set; }	= "MD5";
		public	string		v3AuthPw	{ get; set; }	= "";
		public	string		v3PriAlg	{ get; set; }	= "DES";
		public	string		v3PriPw		{ get; set; }	= "";

		public	string		oidTempFile	{ get; set; }	= "";

		public	string		desc		{ get; set; }	= "";

		public	bool		IsActive	{ get; set; }

		public	SnmpInfo(int deviceId) {
			this.deviceId	= deviceId;
		}

		public void setInfo(MySqlDataReader reader)
		{
			if (reader == null) return;

			//groupIdx		= reader.GetInt32("PROMO_PRICE");
			//prevIdx			= reader.GetInt32("NUM_IID");
			//groupIdx		= reader["THUMBNAIL"].ToString();
			//prevIdx			= reader["THUMBNAIL"].ToString();
		}


		public	int		getImages(MySqlConnection conn)
        {
		/*
			string sql = BGoodsImg.Query4Select($"GOODS_IDX = \"{groupIdx}\"", "");
			MySqlCommand command = new MySqlCommand(sql, conn);
			MySqlDataReader table = command.ExecuteReader();

			mImgs.Clear();
			double seq = 0;
			while (table.Read()){
				//BGoodsImg imgInfo = new BGoodsImg(groupIdx, seq);
				//imgInfo.setInfo(table);
				//mImgs.Add(imgInfo);
			}
			table.Close();
			*/
			return 0;
        } 

		public	ListViewItem getItem()
		{
			ListViewItem item = new ListViewItem(id.ToString());
			item.Tag	= this;

			item.SubItems.Add(port.ToString());
			item.SubItems.Add(version);
			//item.SubItems.Add(checkType);
			/*
			item.SubItems.Add(String.Format("{0:#,0}", price));
			item.SubItems.Add(String.Format("{0:#,0}", src_promo_cost));
			item.SubItems.Add(loc);
			item.SubItems.Add(cate_id);
			*/
			item.SubItems.Add(desc);

			return item;
		}

		public	static SnmpInfo getInfo(MySqlConnection conn, string key)
		{
			SnmpInfo info = null;
			return info;
		}

		public static	string Query4Select(string where, string order)
		{
			string sql = "SELECT * FROM b_goods_list";
			//sql += " WHERE A.NUM_IID = B.NUM_IID ";
			if (!string.IsNullOrEmpty(where))
				sql += "WHERE " + where;
			if (!string.IsNullOrEmpty(order))
				sql += " ORDER BY " + order;
			return sql;
		}
	}
}
