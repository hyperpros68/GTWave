using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyBoBu.library
{
    public  class   MySQL
    {
        public  string  _server = "localhost"; //DB 서버 주소, 로컬일 경우 localhost
        public  int     _port   = 3306; //DB 서버 포트
        public  string  _schema = "new_schema"; //DB 이름
        public  string  _id     = ""; //계정 아이디
        public  string  _pw     = ""; //계정 비밀번호
        public  string  _connectionAddress = "";

        public  MySqlConnection mysql;

        public  MySQL(string addr)
        {
            _server = addr;
        }

        public  bool    Init(string schema, string id, string pw)
        {
            _schema = schema;
            _id     = id;
            _pw     = pw;

            _connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", 
                _server, _port, _schema, _id, _pw);

            mysql = new MySqlConnection(_connectionAddress);
            if (mysql == null)  
                return  false;

            try {
                mysql.Open();
            } catch (Exception ex) {
                MessageBox.Show($"{ex.Message}", $"{_server} 연결 오류", MessageBoxButtons.YesNo);
                return false;
            }
            return  true;
        }
    }

}
