using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LoginProgram
{
    class DAO
    {
        private MySqlConnection connect;
        private MySqlDataReader dataReader;
        private MySqlCommand command;

        private string server;
        private string database;
        private string uid;
        private string password;
        public string sqlQuery;

        public DAO()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "Login";
            uid = "root";
            password = "0000";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connect = new MySqlConnection(connectionString);
            connect.Open();
        }

        public void CloseConnection()
        {
            connect.Close();
        }

        public void SendQuery(string query)
        {
            command = new MySqlCommand(query, connect);
            dataReader = command.ExecuteReader();
        }

        public void DataReaderClose()
        {
            //dataReader 열려있으면 닫으시오~
            if (!dataReader.IsClosed)
                dataReader.Close();
        }

        public void Insert(string[] newMember)
        {
            DataReaderClose();

            //id, password, name, gender, birth, email, phone, address 순서대로.
            sqlQuery = "insert into User values('" + newMember[0] + "', '" + newMember[1] + "', '" + newMember[2] + "', '" + newMember[3] + "', '"
                + newMember[4] + "', '" + newMember[5] + "', '" + newMember[6] + "', '" + newMember[7] + "');";

            SendQuery(sqlQuery);
        }

        public void Update(string editedValue, string column, string id)
        {
            DataReaderClose();
            sqlQuery = "update User set " + column + "='" + editedValue + "' where id='" + id + "';";
            SendQuery(sqlQuery);
        }

        public void Delete(string id)
        {
            DataReaderClose();
            sqlQuery = "delete from User where id='" + id + "';";
            SendQuery(sqlQuery);
        }

        public string[] Select(string id)
        {
            DataReaderClose();
            string[] selectedUser = new string[8];

            //id, password, name, gender, birth, email, phone, address 순서대로.
            sqlQuery = "select * from user where id='" + id + "';";
            SendQuery(sqlQuery);
            dataReader.Read();

            selectedUser[0] = dataReader["id"].ToString();
            selectedUser[1] = dataReader["password"].ToString();
            selectedUser[2] = dataReader["name"].ToString();
            selectedUser[3] = dataReader["gender"].ToString();
            selectedUser[4] = dataReader["birth"].ToString();
            selectedUser[5] = dataReader["email"].ToString();
            selectedUser[6] = dataReader["phone"].ToString();
            selectedUser[7] = dataReader["address"].ToString();
            return selectedUser;
        }

        public bool IsAuthenticate(string id)
        {
            DataReaderClose();
            sqlQuery = "select id from user where id='" + id + "';";
            SendQuery(sqlQuery);
            
            if(dataReader.HasRows)
                return true;
            
            return false;
        }
    }
}
