using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BookManagement
{
    class Query
    {
        String databaseConnect;
        MySqlConnection connect;
        MySqlDataReader dataReader;
        MySqlCommand command;
        
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
