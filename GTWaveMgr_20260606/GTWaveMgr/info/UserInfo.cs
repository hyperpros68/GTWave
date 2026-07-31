using AnyBoBu.library;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyBoBu.info
{
    public	class UserInfo
    {
		public	int		id			{ get; set; }

		public	string	mLevel		{ get; set; } = "사용자";
		public	string	mMemNm		{ get; set; } = "";
		public	string	mMemId		{ get; set; } = "";
		public	string	mMemPw		{ get; set; } = "";

		public	string	mPhone		{ get; set; } = "";
		public	string	mEmail		{ get; set; } = "";
		public	string	mDesc		{ get; set; } = "";

		public	string	mValid		{ get; set; } = "Y";
		public	string	mBigo		{ get; set; } = "";

		public ListViewItem	getItem()
        {
			ListViewItem item = new ListViewItem(id.ToString());

			item.Tag	= this;
			item.Text	= mMemId;

			//listView.Items.Add(getItem("0", "Idx", mMemIdx));
			item.SubItems.Add(mMemId);
			item.SubItems.Add(mLevel);
			item.SubItems.Add(mMemNm);
			item.SubItems.Add(mPhone);
			item.SubItems.Add(mEmail);
			item.SubItems.Add(mDesc);
			item.SubItems.Add(mBigo);

			return item;
        }

		public int addInfo(MySqlConnection conn)
		{
			return 0;
		}


		public int fixInfo(MySqlConnection conn)
		{
			return 0;
		}

		public	bool	dupCheck(MySqlConnection conn, string kind, string id)
        {
			string where = string.Format("MEM_KIND = \"{0}\" AND MEM_ID = \"{1}\"", kind, id);
			return	isInfo(conn, where);
        }

		public	bool	fixCheck(MySqlConnection conn, string idx, string kind, string id)
		{
			string where = string.Format("MEM_KIND = \"{0}\" AND MEM_ID = \"{1}\"", kind, id);
			return	isInfo(conn, idx, where);
		}

		public	bool	isInfo(MySqlConnection conn, string idx, string where)
		{
			string sql = Query4Select(where);

			MySqlCommand command = new MySqlCommand(sql, conn);
			MySqlDataReader table = command.ExecuteReader();
			while (table.Read())
			{
				if (table["MEM_IDX"].ToString() != idx)
				{
					table.Close();
					return true;
				}
			}
			table.Close();
			return false;
		}

		public	bool	isInfo(MySqlConnection conn, string where)
		{
			return	false;
		}

		public	static	string Query4Select(string where)
		{
			string sql = "SELECT * FROM MEMBER ";
			if (!string.IsNullOrEmpty(where))
				sql += "WHERE " + where;
			return sql;
		}

		public	static	string SelerList()
		{
			string sql = "SELECT BIZ_NO FROM MEMBER WHERE VALID = 'Y' GROUP BY BIZ_NO";
			return sql;
		}
	}
}
