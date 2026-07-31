using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyBoBu.info
{
    public	class MemberInfo
    {
		public	string	mMemIdx		= "";

		public	string	mMemKind	= "";
		public	string	mMemName	= "";
		public	string	mMemId		= "";
		public	string	mMemPw		= "";
		public	string	mPhone		= "";
		public	string	mEmail		= "";

		public	string	mStoreId	= "";
		public	string	mStorePw	= "";
		public	string	mStoreNm	= "";
		public	string	mStoreUrl	= "";

		public	string	mVenId		= "";
		public	string	mAccKey		= "";
		public	string	mSecKey		= "";

		public	string	mZip		= "";
		public	string	mAddr1		= "";
		public	string	mAddr2		= "";
		public	string	mBank		= "";
		public	string	mAccount	= "";
		public	string	mOwner		= "";
		public	string	mInName		= "";
		public	string	mComment	= "";
		public	string	mValid		= "";
		public	string	mBigo		= "";

		public	MemberInfo(string idx)
		{
			mMemIdx = idx;
		}

		public	ListViewItem	getItem(string no, string key, string val)
        {
			ListViewItem item = new ListViewItem(no);
			item.SubItems.Add(key);
			item.SubItems.Add(val);
			return item;
        }

		public	void	dispListView(ListView listView)
        {
			listView.Items.Clear();

			ListViewItem item = new ListViewItem();

			listView.Items.Add(getItem("0", "Idx", mMemIdx));
			listView.Items.Add(getItem("1", "kind", mMemKind));
			listView.Items.Add(getItem("2", "name", mMemName));
			listView.Items.Add(getItem("3", "id", mMemId));
			listView.Items.Add(getItem("4", "phone", mPhone));
			listView.Items.Add(getItem("5", "email", mEmail));

			listView.Items.Add(getItem("7", "store name", mStoreNm));
			listView.Items.Add(getItem("8", "store url", mStoreUrl));

			listView.Items.Add(getItem("9", "vender id", mVenId));
			listView.Items.Add(getItem("10", "access key", mAccKey));
			listView.Items.Add(getItem("11", "secret key", mSecKey));

			listView.Items.Add(getItem("12", "은행", mBank));
			listView.Items.Add(getItem("13", "계좌", mAccount));
			listView.Items.Add(getItem("14", "예금주", mOwner));
		}

		public	void	setInfo(MySqlDataReader reader)
        {
			if (reader == null) return;

			mMemIdx		= reader["MEM_IDX"].ToString();

			mMemKind	= reader["MEM_KIND"].ToString();
			mMemName	= reader["MEM_NAME"].ToString();
			mMemId		= reader["MEM_ID"].ToString();
			mMemPw		= reader["MEM_PW"].ToString();
			mPhone		= reader["PHONE"].ToString();
			mEmail		= reader["EMAIL"].ToString();

			mStoreId	= reader["STORE_ID"].ToString();
			mStorePw	= reader["STORE_PW"].ToString();
			mStoreNm	= reader["STORE_NM"].ToString();
			mStoreUrl	= reader["STORE_URL"].ToString();

			mVenId		= reader["S_VEN_ID"].ToString();
			mAccKey		= reader["S_ACC_KEY"].ToString();
			mSecKey		= reader["S_SEC_KEY"].ToString();

			mZip		= reader["ZIP"].ToString();
			mAddr1		= reader["ADDR1"].ToString();
			mAddr2		= reader["ADDR2"].ToString();
			mBank		= reader["BANK"].ToString();
			mAccount	= reader["ACCOUNT"].ToString();
			mOwner		= reader["OWNER"].ToString();
			mInName		= reader["IN_NAME"].ToString();
			mComment	= reader["COMMENT"].ToString();
			mValid		= reader["VALID"].ToString();
			mBigo		= reader["BIGO"].ToString();
		}

		public static MemberInfo getInfo(MySqlConnection conn, string key)
		{
			MemberInfo info = null;

			string sql = Query4Select("KEY_IDX = \"" + key + "\"");

			MySqlCommand command = new MySqlCommand(sql, conn);
			MySqlDataReader table = command.ExecuteReader();
			while (table.Read())
			{
				info = new MemberInfo(key);
				info.setInfo(table);

				table.Close();
				break;
			}
			table.Close();
			return info;
		}

		public int addInfo(MySqlConnection conn)
		{
			string sql = Query4Insert();

			MySqlCommand command = new MySqlCommand(sql, conn);
			MySqlDataReader table = command.ExecuteReader();
			while (table.Read()) { }
			table.Close();
			return 0;
		}

		public string Query4Insert()
		{
			string sql = string.Format("INSERT INTO MEMBER(MEM_KIND, MEM_NAME, MEM_ID, MEM_PW, PHONE, EMAIL, S_VEN_ID, S_ACC_KEY, S_SEC_KEY, " +
				"STORE_ID, STORE_PW, STORE_NM, STORE_URL, ZIP, ADDR1, ADDR2, BANK, ACCOUNT, OWNER, IN_NAME, COMMENT, VALID, BIGO) ") +
				string.Format("VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\"," +
								"\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\",\"{18}\",\"{19}\",\"{20}\",\"{21}\",\"{22}\");",
							mMemKind, mMemName, mMemId, mMemPw, mPhone, mEmail, mVenId, mAccKey, mSecKey, mStoreId, mStorePw, mStoreNm, mStoreUrl, 
							mZip, mAddr1, mAddr2, mBank, mAccount, mOwner, mInName, mComment, mValid, mBigo);
			return sql;
		}

		public int fixInfo(MySqlConnection conn)
		{
			string sql = Query4Update();

			MySqlCommand command = new MySqlCommand(sql, conn);
			MySqlDataReader table = command.ExecuteReader();
			while (table.Read()) { }
			table.Close();
			return 0;
		}

		public string Query4Update()
		{
			string sql = string.Format("UPDATE MEMBER SET MEM_KIND = \"{0}\", MEM_NAME = \"{1}\", MEM_ID = \"{2}\", MEM_PW = \"{3}\", " +
				" PHONE = \"{4}\", EMAIL = \"{5}\", STORE_ID = \"{6}\", STORE_PW = \"{7}\", STORE_NM = \"{8}\", STORE_URL = \"{9}\", " +
				" ZIP = \"{10}\", ADDR1 = \"{11}\", ADDR2 = \"{12}\", BANK = \"{13}\", ACCOUNT = \"{14}\", OWNER = \"{15}\", " +
				" IN_NAME = \"{16}\", COMMENT = \"{17}\", VALID = \"{18}\", BIGO = \"{19}\", S_VEN_ID = \"{20}\", S_ACC_KEY = \"{21}\", S_SEC_KEY = \"{22}\" " +
				string.Format("WHERE MEM_IDX = {0};", mMemIdx),
				mMemKind, mMemName, mMemId, mMemPw, mPhone, mEmail, mStoreId, mStorePw, mStoreNm, mStoreUrl,
				mZip, mAddr1, mAddr2, mBank, mAccount, mOwner, mInName, mComment, mValid, mBigo, mVenId, mAccKey, mSecKey);

			return sql;
		}

		public	bool	dupCheck(MySqlConnection conn, string kind, string id)
        {
			string where = string.Format("MEM_KIND = \"{0}\" AND MEM_ID = \"{1}\"", kind, id);
			return	isInfo(conn, where);
        }

		public bool fixCheck(MySqlConnection conn, string idx, string kind, string id)
		{
			string where = string.Format("MEM_KIND = \"{0}\" AND MEM_ID = \"{1}\"", kind, id);
			return isInfo(conn, idx, where);
		}

		public bool isInfo(MySqlConnection conn, string idx, string where)
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

		public bool	isInfo(MySqlConnection conn, string where)
		{
			string sql = Query4Select(where);

			MySqlCommand command = new MySqlCommand(sql, conn);
			MySqlDataReader table = command.ExecuteReader();
			while (table.Read()) {
				if (table["MEM_IDX"].ToString() != mMemIdx) {
					table.Close();
					return true;
				}
			}
			table.Close();
			return	false;
		}

		public	static	string Query4Select(string where)
		{
			string sql = "SELECT * FROM MEMBER ";
			if (!string.IsNullOrEmpty(where))
				sql += "WHERE " + where;
			return sql;
		}
	}
}
