using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;

namespace BookManagement
{
    class Query
    {
        String databaseConnect;
        MySqlConnection connect;
        MySqlDataReader dataReader;
        MySqlCommand command;
        String sqlQuery;

        public Query()
        {
        }

        public void ConnectDB()
        {
            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL

            connect.Open(); // open MySQL      
        }

        public void CloseDB()
        {
            dataReader.Close();
            connect.Close();
        }

       public bool IsAuthenticateLogin(string id, string password)
        {
            ConnectDB();
            sqlQuery = "select id, password from member where id='" + id + "' and password='" + password + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();
            dataReader.Read();

            string serverID = dataReader["id"].ToString();
            string serverPWD = dataReader["password"].ToString();

            if (serverID.Equals(id) && serverPWD.Equals(password))
            {
                CloseDB();
                return true;
            }

            CloseDB();
            return false;
        }

        public void RegisterMemberQuery(string[] input, int type)
        {

        }

        public void ModifyQuery(string[] input, int type)
        {

        }

        public void SearchByBookNameQuery(string input, int type)
        {

        }

        public void SearchByPublisherQuery(string input)
        {

        }

        public void SearchByAuthor(string input)
        {

        }

        public void SearchByIdQuery(string input)
        {

        }

        public void RemoveQuery(string input, int type)
        {

        }

        public void ReturnBookQuery(string input)
        {

        }


    }
}
