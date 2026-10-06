using GTWave.info;
using LiteDB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyBoBu.info
{
	[Serializable]
	public	class	DeviceInfo
    {
		public	int			id			{ get; set; }	= 0;
		public	string		type		{ get; set; }	= "";
		public	string		groupNm		{ get; set; }	= "";

		public	string		name		{ get; set; }	= "";

		public	bool		isDumy		{ get; set; }	= false;
		public	string		addr		{ get; set; }	= "";
		public	string		checkType	{ get; set; }	= "ping";
		public	int			checkPort	{ get; set; }	= 0;
		public	string		connType	{ get; set; }	= "http";
		public	int			connPort	{ get; set; }	= 80;

		public	string		agent		{ get; set; }	= "";
		public	string		desc		{ get; set; }	= "";

		public	bool		IsActive	{ get; set; }


		public	bool		isSnmp		{ get; set; }
		public	string		protocolType	{ get; set; }	= "SNMP";
		public	string		setSnmp		= null;
		public	string		setSwitch	= null;
		public	string		setWifi		= null;


		public	DeviceInfo(int id) {
			this.id = id;
		}

		public	DeviceInfo	Clone() {
			DeviceInfo info = new DeviceInfo(this.id);
			info.type = type;
			info.groupNm = groupNm;
			info.name = name;
			info.isDumy = isDumy;
			info.addr = addr;
			info.checkType = checkType;
			info.checkPort = checkPort;
			info.connType = connType;
			info.connPort = connPort;
			info.agent = agent;
			info.desc = desc;
			info.IsActive = IsActive;
			info.isSnmp = isSnmp;
			info.protocolType = protocolType;
			info.setSnmp = setSnmp;
			info.setSwitch = setSwitch;
			info.setWifi = setWifi;

			return info;
		}

		public bool	Equals(DeviceInfo info) {
			if (!info.name.Equals(this.name))	return false;

			if (info.addr == null) info.addr = "";
			if (this.addr == null) this.addr = "";

			//if (string.IsNullOrEmpty(info.addr) != this.addr)			return false;

			if (info.addr != null && this.addr != null) {
				if (!info.addr.Equals(this.addr)) return false;
			}

			return true;
		}

		public static DeviceInfo Load2Db(int id, ILiteCollection<DeviceInfo> db) {
			if (db == null) return null;

			var results = GlobalHelpers.mDeviceTb.Query()
				.Where(x => x.id == id)
				//				.OrderBy(x => x.groupNm)
				.OrderBy(x => x.name)
				//.Select(x => new { x.site, NameUpper = x.site.ToUpper() })
				//.Limit(10)
				.ToList();

			if (results.Count == 0) return null;

			return results[0];
		}

		public void setInfo(MySqlDataReader reader)
		{
			if (reader == null) return;

			//groupIdx		= reader.GetInt32("PROMO_PRICE");
			//prevIdx		= reader.GetInt32("NUM_IID");
			//groupIdx		= reader["THUMBNAIL"].ToString();
			//prevIdx		= reader["THUMBNAIL"].ToString();
			/*
			title			= reader["TITLE"].ToString();
			thumbnail		= reader["THUMBNAIL"].ToString();

			regDate			= reader["REG_DATE"].ToString();
			fixDate			= reader["FIX_DATE"].ToString();
			valid			= reader["VALID"].ToString();
			bigo			= reader["BIGO"].ToString();
			*/
		}

		public	string	getString() {
			return $"{this.name}|{this.name}|{this.agent}|{this.desc}";
		}

		public	void	setParse(string data) {
			string[] items = data.Split('|');
			if (items.Length > 3) {
				name		= items[1];
				agent		= items[2];
				desc		= items[3];
			}
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

			item.SubItems.Add(type);
			item.SubItems.Add(name);
			item.SubItems.Add(isDumy.ToString());
			item.SubItems.Add(addr);
			item.SubItems.Add(checkType);
			/*
			item.SubItems.Add(String.Format("{0:#,0}", price));
			item.SubItems.Add(String.Format("{0:#,0}", src_promo_cost));
			item.SubItems.Add(loc);
			item.SubItems.Add(cate_id);
			*/
			item.SubItems.Add(desc);

			return item;
		}

		public	static	DeviceInfo getInfo(MySqlConnection conn, string key)
		{
			DeviceInfo info = null;
			/*
			string sql = Query4Select("GOODS_IDX = \"" + key + "\"", "");

			MySqlCommand command = new MySqlCommand(sql, conn);
			MySqlDataReader table = command.ExecuteReader();
			while (table.Read())
			{
				info = new DeviceInfo(key);
				info.setInfo(table);

				table.Close();
				break;
			}
			table.Close();
			*/
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
