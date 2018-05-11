using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LibraryManagement
{
    class DAO
    {
        private static DAO dao;

        private MySqlConnection connect;
        private MySqlDataReader dataReader;
        private MySqlCommand command;

        private string server;
        private string database;
        private string uid;
        private string password;
        public string sqlQuery;

        //Constructor
        public DAO()
        {
            Initialize();
        }

        public static DAO GetInstance()
        {
            if (dao == null)
                dao = new DAO();

            return dao;
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "bookmanage";
            uid = "root";
            password = "0000";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connect = new MySqlConnection(connectionString);
        }

        //open connection to database
        public void OpenConnection()
        {
            connect.Open();
        }

        //Close connection
        public void CloseConnection()
        {
            connect.Close();
        }

        //Insert statement
        public void Insert(string tableName, string value)
        {
            sqlQuery = "insert into " + tableName + " values" + value;
        }

        //Update statement
        public void Update(string tableName, string fieldName, string value, string primaryField, string toChangeField)
        {
            sqlQuery = "update " + tableName + " set " + fieldName + "='" + value + "' where " + primaryField + "='" + toChangeField + "';";
        }

        //Delete statement
        public void Delete(string tableName, string primaryField, string toChangeValue)
        {
            sqlQuery = "delete from " + tableName + " where " + primaryField + "='" + toChangeValue + "';";
        }

        //Select statement
        public List<BookVO> Select(string selectType, string tableName, string primaryKey)
        {

            return null;
        }
        

        public List<MemberVO> Select()
        {

            return null;
        }
    }
}
