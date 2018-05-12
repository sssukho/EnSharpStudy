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
            OpenConnection();
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

        public void SendQuery(string query)
        {
            command = new MySqlCommand(query, connect);
            dataReader = command.ExecuteReader();
        }

        //Insert statement
        public void Insert(MemberVO inputMember)
        {
            sqlQuery = "insert into member values('" + inputMember.Id + "', '" + inputMember.Password + "', '"
                + inputMember.Name + "', '" + inputMember.Gender + "', '" + inputMember.PhoneNumber + "', '"
                + inputMember.Email + "', '" + inputMember.Address + "', '" + inputMember.RentBook + "', '"
                + inputMember.DueDate + "', '" + inputMember.ExtensionCount + "');";

            SendQuery(sqlQuery);
            dataReader.Close();
        }

        //Update statement
        public void Update(string tableName, string fieldName, string value, string primaryField, string toChangeField)
        {
            sqlQuery = "update " + tableName + " set " + fieldName + "='" + value + "' where " + primaryField + "='" + toChangeField + "';";
            dataReader.Close();
        }

        //Delete statement
        public void Delete(string tableName, string primaryField, string toChangeValue)
        {
            sqlQuery = "delete from " + tableName + " where " + primaryField + "='" + toChangeValue + "';";
            dataReader.Close();
        }

        //Select statement
        public MemberVO Select(string id)
        {
            sqlQuery = "select * from member where id='" + id + "';";
            SendQuery(sqlQuery);
            dataReader.Read();
            MemberVO selectedMember = new MemberVO(dataReader["id"].ToString(), dataReader["password"].ToString(),
                    dataReader["name"].ToString(), dataReader["gender"].ToString(), dataReader["phoneNumber"].ToString(),
                    dataReader["email"].ToString(), dataReader["address"].ToString(), dataReader["rentbook"].ToString(), dataReader["duedate"].ToString(), 3);
            dataReader.Close();

            return selectedMember;
        }

        public MySqlDataReader SelectAll(string tableName, string primaryKey, string condition)
        {
            sqlQuery = "select * from " + tableName + " where " + primaryKey + " " + condition;
            SendQuery(sqlQuery);
            return dataReader;
        }

        public List<BookVO> SelectAll(List<BookVO> inputBookList, string searchBy, string searchWord)
        {
            inputBookList.Clear();
            sqlQuery = "select * from book";
            switch(searchBy)
            {
                case "도서명":
                    sqlQuery = sqlQuery + " where name='" + searchWord + "';";
                    break;
                case "출판사명":
                    sqlQuery = sqlQuery + " where publisher='" + searchWord + "';";
                    break;
                case "저자명":
                    sqlQuery = sqlQuery + " where author='" + searchWord + "';";
                    break;
            }

            SendQuery(sqlQuery);
            while(dataReader.Read())
            {
                inputBookList.Add(new BookVO(int.Parse(dataReader["idx"].ToString()),dataReader["name"].ToString(), dataReader["author"].ToString(), 
                    dataReader["price"].ToString(), dataReader["publisher"].ToString(), dataReader["publishDate"].ToString(), 
                    int.Parse(dataReader["count"].ToString()), dataReader["isbn"].ToString(), dataReader["description"].ToString()));
            }
            dataReader.Close();
            return inputBookList;
        }

        public bool IsMemberDulplicated(string id)
        {
            sqlQuery = "select id from member where id='"+ id +"';";
            SendQuery(sqlQuery);
            if (dataReader.FieldCount == 0)
            {
                dataReader.Close();
                return false;
            }
            dataReader.Close();
            return true;
        }

        public string Select(string id, string password)
        {
            sqlQuery = "select * from member where id='" + id + "' and password='" + password + "';";
            SendQuery(sqlQuery);

            if (dataReader.FieldCount == 0)
            {
                return "NoUser";
            }

            dataReader.Read();

            if(dataReader["id"].ToString().Equals(id) && dataReader["password"].ToString().Equals(password))
            {
                if(id.Equals("관리자"))
                    return "Admin";

                return "User";
            }

            return "NoUser";
        }
        

        public List<MemberVO> Select()
        {

            return null;
        }
    }
}
