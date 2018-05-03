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

       public bool IsAuthenticateLogin(string id, string password)
        {
            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL 

            sqlQuery = "select id, password from member where id='" + id + "' and password='" + password + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();
            dataReader.Read();

            string serverID = dataReader["id"].ToString();
            string serverPWD = dataReader["password"].ToString();

            if (serverID.Equals(id) && serverPWD.Equals(password))
            {
                dataReader.Close();
                connect.Close();
                return true;
            }

            dataReader.Close();
            connect.Close();
            return false;
        }

        public bool RegisterMemberQuery(MemberVO newMember)
        {
            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL 

            sqlQuery = "insert into member values('" + newMember.Id + "', '" + newMember.Password + "', '" 
                + newMember.Name + "', '" + newMember.Gender + "', '" + newMember.PhoneNumber + "', '"
                + newMember.Email + "', '" + newMember.Address + "', '" + newMember.RentBook + "', '"
                + newMember.DueDate + "');";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();
            dataReader.Close();

            if (dataReader.RecordsAffected == -1) //이미 존재하고 있는 아이디일때
            {
                dataReader.Close();
                connect.Close();
                return false;
            }

            dataReader.Close();
            connect.Close();
            return true;
        }

        public void ModifyQuery(string[] input, int type)
        {
            //update
        }

        public void SearchByBookNameQuery(string input, int type)
        {
            //select * from book where name ='" + bookName "';
        }

        public void SearchByPublisherQuery(string input)
        {
            //select
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
