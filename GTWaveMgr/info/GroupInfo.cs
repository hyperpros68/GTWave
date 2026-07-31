using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyBoBu.info
{
	public	class	GroupInfo
    {
		public	int			id			{ get; set; }	= 0;
		public	int			groupIdx	{ get; set; }	= 0;
		public	string		rootName	{ get; set; }	= "";
		//public	string		prevIdx		{ get; set; }	= "";

		public	string		name		{ get; set; }	= "";
		public	string		agent		{ get; set; }	= "";
		public	string		desc		{ get; set; }	= "";

		public	bool		IsActive	{ get; set; }

		public	TreeNode	node		= null;

		public GroupInfo(string name)
		{
			this.name = name;
		}

		public void setInfo(MySqlDataReader reader)
		{
			if (reader == null) return;

			groupIdx		= reader.GetInt32("PROMO_PRICE");
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

		public	string	getString() {
			return $"{this.rootName}|{this.name}|{this.agent}|{this.desc}";
		}

		public	void	setParse(string data) {
			string[] items = data.Split('|');
			if (items.Length > 3) {
				rootName	= items[0];
				name		= items[1];
				agent		= items[2];
				desc		= items[3];
			}
		}
	}
}
