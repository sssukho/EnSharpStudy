using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SearchImage
{
    /// <summary>
    /// 검색시에 검색어와 시간 저장 및 db에 있는 log 테이블에서의
    /// 
    /// </summary>
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

        /// <param name="searchWord"> 검색어 </param>
        /// <param name="dateTime"> 검색어를 쓰고 검색 버튼을 누른 시간</param>
        public void SaveLog(string searchWord, DateTime dateTime)
        {
            connect = new MySqlConnection(databaseConnect); 
            connect.Open();

            sqlQuery = "select searchWord from log where searchWord='" + searchWord + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                if (dataReader["searchWord"].ToString().Equals(searchWord))
                {
                    dataReader.Close();
                    sqlQuery = "update log set searchWord='" + searchWord + "', searchTime='" + dateTime.ToString() + "' where searchWord='" + searchWord + "';";
                    command = new MySqlCommand(sqlQuery, connect);
                    command.ExecuteReader();
                    dataReader.Close();
                    connect.Close();
                    return;
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
            connect = new MySqlConnection(databaseConnect); 
            connect.Open();

            sqlQuery = "delete from log";
            command = new MySqlCommand(sqlQuery, connect);
            command.ExecuteReader();

            connect.Close();
        }

        public Dictionary<string, string> GetLog()
        {
            Dictionary<string, string> log = new Dictionary<string, string>();
            connect = new MySqlConnection(databaseConnect); 
            connect.Open();

            sqlQuery = "select searchWord, searchTime from log;";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                log.Add(dataReader["searchWord"].ToString(), dataReader["searchTime"].ToString());
            }

            dataReader.Close();
            connect.Close();

            return log;
        }
    }
}
