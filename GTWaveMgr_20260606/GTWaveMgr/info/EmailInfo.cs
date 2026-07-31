using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awool.info
{
	public	class	EmailInfo
	{
		public	string	eIdx		= "";
		public	string	kind		= "";

		public	string	email		= "";
		public	string	name		= "";
		public	string	nick		= "";
		public	string	phone		= "";

		public	string	recvOk		= "Y";
		public	string	valid		= "F";

		public	string	regDate		= "";
		public	string	bigo		= "";

		public	EmailInfo(string idx) {
			eIdx = idx;
		}

		public	void	setInfo(MySqlDataReader reader)
        {
			if (reader == null)		return;
			eIdx	= reader["E_IDX"].ToString();

			kind	= reader["KIND"].ToString();
			email	= reader["EMAIL"].ToString();
			name	= reader["NAME"].ToString();
			nick	= reader["NICK"].ToString();
			phone	= reader["PHONE"].ToString();

			recvOk	= reader["RECV_OK"].ToString();
			valid	= reader["VALID"].ToString();

			regDate = reader["REGDATE"].ToString();
			bigo	= reader["BIGO"].ToString();
		}

		public static EmailInfo getInfo(MySqlConnection conn, string key)
		{
			EmailInfo info = null;

			string sql = Query4Select("E_IDX = \"" + key + "\"");

			MySqlCommand command = new MySqlCommand(sql, conn);
			MySqlDataReader table = command.ExecuteReader();
			while (table.Read())
			{
				info = new EmailInfo(key);
				info.eIdx		= table["E_IDX"].ToString();
				info.kind		= table["KIND"].ToString();

				info.email		= table["EMAIL"].ToString();
				info.name		= table["NAME"].ToString();
				info.nick		= table["NICK"].ToString();
				info.phone		= table["PHONE"].ToString();

				info.recvOk		= table["RECV_OK"].ToString();
				info.valid		= table["VALID"].ToString();

				info.regDate	= table["REGDATE"].ToString();
				info.bigo		= table["BIGO"].ToString();
				table.Close();
				break;
			}
			table.Close();
			return info;
		}

		public bool isInfo(MySqlConnection conn, string where)
		{
			string sql = Query4Select(where);

			MySqlCommand command = new MySqlCommand(sql, conn);
			MySqlDataReader table = command.ExecuteReader();
			while (table.Read()) {
				if (table["E_IDX"].ToString() != eIdx) {
					table.Close();
					return true;
				}
			}
			table.Close();
			return false;
		}

		public int addSql(MySqlConnection conn,string sql)
		{
			try {
				MySqlCommand command = new MySqlCommand(sql, conn);
				MySqlDataReader table = command.ExecuteReader();
				while (table.Read()) { }
				table.Close();
			} catch { }
			return 0;
		}

		public int addInfo(MySqlConnection conn)
		{
			string sql = Query4Insert();
			try {
				MySqlCommand command = new MySqlCommand(sql, conn);
				MySqlDataReader table = command.ExecuteReader();
				while (table.Read()) { }
				table.Close();
			} catch { }
			return 0;
		}

		public int	fixInfo(MySqlConnection conn)
		{
			string sql = Query4Update();

			MySqlCommand command = new MySqlCommand(sql, conn);
			MySqlDataReader table = command.ExecuteReader();
			while (table.Read()) {}
			table.Close();
			return 0;
		}

		public string Query4Insert()
		{
			string sql = string.Format("INSERT INTO EMAILINFO(KIND, EMAIL, NAME, NICK, PHONE, RECV_OK, VALID, REGDATE, BIGO) ") +
				string.Format("VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",now(),\"{7}\");",
							kind, email, name, nick, phone, recvOk, valid, bigo);
			return sql;
		}

		public string Query4Update()
		{
			string sql = string.Format("UPDATE EMAILINFO SET KIND = \"{0}\", EMAIL = \"{1}\", NAME = \"{2}\", NICK = \"{3}\", PHONE = \"{4}\", RECV_OK = \"{5}\", VALID = \"{6}\", BIGO = \"{7}\" " +
				string.Format("WHERE E_IDX = {0};", eIdx),
				kind, email, name, nick, phone, recvOk, valid, bigo);
			return sql;
		}

		public static	string	Query4Select(string where)
        {
			string	sql	= "SELECT * FROM EMAILINFO ";
			if (!string.IsNullOrEmpty(where))
				sql += "WHERE " + where;
			return	sql;
		}
	}
}
