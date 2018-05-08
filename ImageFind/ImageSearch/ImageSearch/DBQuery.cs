using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ImageSearch
{
    class DBQuery
    {
        private static DBQuery dbQuery;

        string databaseConnect = "Server=localhost;Database=imagesearch;Uid=root;Pwd=0000";
        MySqlConnection connect;
        MySqlCommand command;
        MySqlDataReader dataReader;
        String sqlQuery;

        public DBQuery() { }

        public static DBQuery GetInstance()
        {
            if (dbQuery == null) dbQuery = new DBQuery();
            return dbQuery;
        }

        public void SaveLog(string searchWord, DateTime dateTime)
        {
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL 

            sqlQuery = "select searchWord from log where searchWord='" + searchWord + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                if (dataReader["searchWord"].ToString().Equals(searchWord))
                {
                    dataReader.Close();
                    sqlQuery = "update log set searchWord='" + searchWord + "', searchTime='" + dateTime.ToString() + "');";
                    command = new MySqlCommand(sqlQuery, connect);
                    command.ExecuteReader();
                    break;
                }
            }
            dataReader.Close();
            sqlQuery = "insert into log values(null, '" + searchWord + "', '" + dateTime.ToString() + "');";
            command = new MySqlCommand(sqlQuery, connect);
            command.ExecuteReader();
            connect.Close();
        }

        public void RemoveLog()
        {
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL 

            sqlQuery = "delete from log";
            command = new MySqlCommand(sqlQuery, connect);
            command.ExecuteReader();

            connect.Close();
        }

        public MySqlDataReader GetLog()
        {
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL 

            sqlQuery = "select searchWord, searchTime from log;";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();
            connect.Close();

            return dataReader;
        }
    }
}
