using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LoginProgram
{
    public class DAO
    {
        public MySqlConnection connect;
        public MySqlDataReader dataReader;
        public MySqlCommand command;

        public string server;
        public string database;
        public string uid;
        public string password;
        public string sqlQuery;

        public DAO()
        {
            Initialize();
        }

        public void Initialize()
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
            //dataReader가 열리지도 않았으면 그냥 정료
            if (dataReader == null)
                return;
            
            if (!dataReader.IsClosed) //dataReader 열려있으면 닫기.
                dataReader.Close();   
        }

        public void Insert(string[] newMember)
        {
            command = connect.CreateCommand();
            command.CommandText = "Insert into user values (@id, @password, @name, @gender, @birth, @email, @phone, @address, @identityNumber)";
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = newMember[0];
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = newMember[1];
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = newMember[2];
            command.Parameters.Add("@gender", MySqlDbType.VarChar).Value = newMember[3];
            command.Parameters.Add("@birth", MySqlDbType.VarChar).Value = newMember[4];
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = newMember[5];
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = newMember[6];
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = newMember[7];
            command.Parameters.Add("@identityNumber", MySqlDbType.VarChar).Value = newMember[8];
            command.ExecuteNonQuery();
        }

        public void Update(string editedValue, string column, string id)
        {
            sqlQuery = "update User set " + column + "='" + editedValue + "' where id='" + id + "';";
            SendQuery(sqlQuery);
            DataReaderClose();
        }

        public void Delete(string id)
        {
            sqlQuery = "delete from User where id='" + id + "';";
            SendQuery(sqlQuery);
            DataReaderClose();
        }

        public string[] Select(string id)
        {
            string[] selectedUser = new string[9];

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
            selectedUser[8] = dataReader["identityNumber"].ToString();
            DataReaderClose();
            return selectedUser;
        }

        public string[] FindAccount(string phone)
        {
            string[] account = new string[2];
            sqlQuery = "select id, password from user where phone='" + phone + "';";
            SendQuery(sqlQuery);
            dataReader.Read();

            if(dataReader.HasRows)
            {
                account[0] = dataReader["id"].ToString();
                account[1] = dataReader["password"].ToString();
                DataReaderClose();
                return account;
            }
            DataReaderClose();
            return null;
        }

        public bool IsDuplicate(string input, string type)
        {
            sqlQuery = "select * from user where " + type + "='" + input + "';";
            SendQuery(sqlQuery);
            dataReader.Read();
            if (dataReader.HasRows)
            {
                DataReaderClose();
                return true;
            }
            DataReaderClose();
            return false;
        }

        public bool IsAuthenticate(string id, string password)
        {
            sqlQuery = "select id, password from user where id='" + id + "';";
            SendQuery(sqlQuery);
            dataReader.Read();

            if(dataReader["id"].ToString().Equals(id) && dataReader["password"].ToString().Equals(password))
            {
                DataReaderClose();
                return true;
            }
            DataReaderClose();
            return false;
        }
    }
}
