using MySql.Data.MySqlClient;


namespace Awool.info
{
	public	class	ProfilInfo
	{
		public	string	pIdx		= "";
		public	string	kind		= "";

		public	string	agent		= "";
		public	string	profil		= "";
		public	string	name		= "";
		public	string	nick		= "";
		public	string	phone		= "";
		public	string	email		= "";
		public	string	addr1		= "";
		public	string	addr2		= "";
		public	string	zip			= "";
		public	string	memo		= "";

		public	string	bank		= "";
		public	string	account		= "";
		public	string	owner		= "";

		public	string	recvOk		= "Y";
		public	string	valid		= "F";

		public	string	regDate		= "";

		public	static	bool	isRefresh	= false;

		public	ProfilInfo(string idx) {
			pIdx = idx;
		}

		public	void	setInfo(MySqlDataReader reader)
        {
			if (reader == null)		return;

			pIdx	= reader["P_IDX"].ToString();

			kind	= reader["KIND"].ToString();
			agent	= reader["AGENT"].ToString();
			profil	= reader["PROFIL"].ToString();
			name	= reader["NAME"].ToString();
			nick	= reader["NICK"].ToString();
			phone	= reader["PHONE"].ToString();
			email	= reader["EMAIL"].ToString();
			addr1	= reader["ADDR1"].ToString();
			addr2	= reader["ADDR2"].ToString();
			zip		= reader["ZIP"].ToString();
			memo	= reader["MEMO"].ToString();

			bank	= reader["BANK"].ToString();
			account = reader["ACCOUNT"].ToString();
			owner	= reader["OWNER"].ToString();

			recvOk	= reader["RECV_OK"].ToString();
			valid	= reader["VALID"].ToString();

			regDate = reader["REGDATE"].ToString();
		}

		public	static	ProfilInfo getInfo(MySqlConnection conn, string key)
		{
			ProfilInfo info = null;

			string sql = Query4Select("P_IDX = \"" + key + "\"");

			MySqlCommand command = new MySqlCommand(sql, conn);
			MySqlDataReader table = command.ExecuteReader();
			while (table.Read())
			{
				info = new ProfilInfo(key);
				info.pIdx		= table["P_IDX"].ToString();
				info.kind		= table["KIND"].ToString();

				info.agent		= table["AGENT"].ToString();
				info.profil		= table["PROFIL"].ToString();
				info.name		= table["NAME"].ToString();
				info.nick		= table["NICK"].ToString();
				info.phone		= table["PHONE"].ToString();
				info.email		= table["EMAIL"].ToString();
				info.addr1		= table["ADDR1"].ToString();
				info.addr2		= table["ADDR2"].ToString();
				info.zip		= table["ZIP"].ToString();
				info.memo		= table["MEMO"].ToString();

				info.bank		= table["BANK"].ToString();
				info.account	= table["ACCOUNT"].ToString();
				info.owner		= table["OWNER"].ToString();

				info.recvOk		= table["RECV_OK"].ToString();
				info.valid		= table["VALID"].ToString();

				info.regDate	= table["REGDATE"].ToString();
				table.Close();
				break;
			}
			table.Close();
			return info;
		}

		public	bool	isInfo(MySqlConnection conn, string where)
		{
			string sql = Query4Select(where);

			MySqlCommand command = new MySqlCommand(sql, conn);
			MySqlDataReader table = command.ExecuteReader();
			while (table.Read()) {
				if (table["P_IDX"].ToString() != pIdx) {
					table.Close();
					return true;
				}
			}
			table.Close();
			return false;
		}

		public	int		addInfo(MySqlConnection conn)
		{
			string sql = Query4Insert();

			MySqlCommand command = new MySqlCommand(sql, conn);
			MySqlDataReader table = command.ExecuteReader();
			while (table.Read()) { }
			table.Close();
			return 0;
		}

		public	int		fixInfo(MySqlConnection conn)
		{
			string sql = Query4Update();

			MySqlCommand command = new MySqlCommand(sql, conn);
			MySqlDataReader table = command.ExecuteReader();
			while (table.Read()) {}
			table.Close();
			return 0;
		}

		public	string	Query4Insert()
		{
			string sql = string.Format("INSERT INTO PROFILINFO(KIND, AGENT, PROFIL, NAME, NICK, PHONE, EMAIL, ADDR1, ADDR2, ZIP, MEMO, BANK, ACCOUNT, OWNER, RECV_OK, VALID, REGDATE) ") +
				string.Format("VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",now());",
							kind, agent, profil, name, nick, phone, email, addr1, addr2, zip, memo, bank, account, owner, recvOk, valid);
			return sql;
		}

		public	string	Query4Update()
		{
			string sql = string.Format("UPDATE PROFILINFO SET KIND = \"{0}\", AGENT = \"{1}\", PROFIL = \"{2}\", NAME = \"{3}\", NICK = \"{4}\", " +
				"PHONE = \"{5}\", EMAIL = \"{6}\", ADDR1 = \"{7}\", ADDR2 = \"{8}\", ZIP = \"{9}\", MEMO = \"{10}\", BANK = \"{11}\", ACCOUNT = \"{12}\", " +
				"OWNER = \"{13}\", RECV_OK = \"{14}\", VALID = \"{15}\"" + string.Format("WHERE P_IDX = {0};", pIdx),
				kind, agent, profil, name, nick, phone, email, addr1, addr2, zip, memo, bank, account, owner, recvOk, valid);
			return sql;
		}

		public	static	string	Query4Select(string where)
        {
			string	sql	= "SELECT * FROM PROFILINFO ";
			if (!string.IsNullOrEmpty(where))
				sql += "WHERE " + where;
			return	sql;
		}
	}
}
