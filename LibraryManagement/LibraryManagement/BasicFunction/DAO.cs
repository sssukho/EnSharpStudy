using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LibraryManagement
{
    /// <summary>
    ///  SQL QUERY만 보내는 구조.
    ///  생성자를 통해 DB에 연결하는 정보를 초기화
    ///  원래대로라면 Insert, Update, Delete, Select 문들을 한번에 처리해야함
    /// </summary>
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
            dataReader = command.ExecuteReader(); //syntax error
        }

        //Insert statement
        public void Insert(MemberVO inputMember)
        {
            dataReader.Close();
            sqlQuery = "insert into member values('" + inputMember.Id + "', '" + inputMember.Password + "', '"
                + inputMember.Name + "', '" + inputMember.Gender + "', '" + inputMember.PhoneNumber + "', '"
                + inputMember.Email + "', '" + inputMember.Address + "', '" + inputMember.RentBook + "', '"
                + inputMember.DueDate + "', '" + inputMember.ExtensionCount + "');";

            SendQuery(sqlQuery);
            //dataReader.Close();
        }

        public void Insert(BookVO inputBook)
        {
            dataReader.Close();
            sqlQuery = "insert into book values(null, " + "'" + inputBook.Name + "', '" + inputBook.Author + "', " + inputBook.Price + ", '" +
                inputBook.Publisher + "', '" + inputBook.PublishDate + "', " + inputBook.Count + ", '" + inputBook.Isbn + "', '" +
                inputBook.Description + "');";

            SendQuery(sqlQuery);
            //dataReader.Close();
        }

        public void InsertLog(string name, string action, string keyword, DateTime dateTime)
        {
            dataReader.Close();
            if (keyword == null)
                keyword = " ";
            sqlQuery = "insert into log values(null, " + "'" + name + "', '" + action + "', '" + keyword + "', '" + dateTime.ToString() + "');";

            SendQuery(sqlQuery);
        }

        //Update statement
        public void Update(string tableName, string fieldName, string value, string primaryField, string toChangeField)
        {
            dataReader.Close();
            sqlQuery = "update " + tableName + " set " + fieldName + "='" + value + "' where " + primaryField + "='" + toChangeField + "';";
            SendQuery(sqlQuery);
            
        }

        public void Update(string tableName, string fieldName, int value, string primaryField, int toChangeField)
        {
            dataReader.Close();
            sqlQuery = "update " + tableName + " set " + fieldName + "=" + value + " where " + primaryField + "=" + toChangeField + ";";
            SendQuery(sqlQuery);
            
        }

        public void UpdateRentBook(BookVO foundBook, string logOnID)
        {
            dataReader.Close();
            sqlQuery = "update member set rentbook ='" + foundBook.Name + "', duedate ='" + "2018-05-21" + "' where id='" + logOnID + "';";
            SendQuery(sqlQuery);
            
        }

        public void UpdateRentBook(BookVO foundBook)
        {
            dataReader.Close();
            sqlQuery = "update book set count ='" + foundBook.Count + "' where name='" + foundBook.Name + "';";
            SendQuery(sqlQuery);
            
        }

        //Delete statement
        public void Delete(string tableName, string primaryField, string toChangeValue)
        {
            dataReader.Close();
            sqlQuery = "delete from " + tableName + " where " + primaryField + "='" + toChangeValue + "';";
            SendQuery(sqlQuery);
            
        }

        public void Delete(string tableName, string primaryField, int toChangeValue)
        {
            dataReader.Close();
            sqlQuery = "delete from " + tableName + " where " + primaryField + "='" + toChangeValue + "';";
            SendQuery(sqlQuery);
        }

        public void InitLog()
        {
            dataReader.Close();
            sqlQuery = "delete from log;";
            SendQuery(sqlQuery);
        }

        //Select statement
        public MemberVO Select(string id)
        {
            dataReader.Close();
            sqlQuery = "select * from member where id='" + id + "';";
            SendQuery(sqlQuery);
            dataReader.Read();
            MemberVO selectedMember = new MemberVO(dataReader["id"].ToString(), dataReader["password"].ToString(),
                    dataReader["name"].ToString(), dataReader["gender"].ToString(), dataReader["phoneNumber"].ToString(),
                    dataReader["email"].ToString(), dataReader["address"].ToString(), dataReader["rentbook"].ToString(), dataReader["duedate"].ToString(), 3);

            return selectedMember;
        }

        public MySqlDataReader SelectAll(string tableName, string primaryKey, string condition)
        {
            dataReader.Close();
            sqlQuery = "select * from " + tableName + " where " + primaryKey + " " + condition;
            SendQuery(sqlQuery);
            return dataReader;
        }

        public MySqlDataReader SelectLog()
        {
            dataReader.Close();
            sqlQuery = "select * from log;";
            SendQuery(sqlQuery);
            return dataReader;
        }

        public List<BookVO> SelectAll(List<BookVO> inputBookList, string searchBy, string searchWord)
        {
            dataReader.Close();
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
                case "just":
                    break;
            }

            SendQuery(sqlQuery);
            while(dataReader.Read())
            {
                inputBookList.Add(new BookVO(int.Parse(dataReader["idx"].ToString()),dataReader["name"].ToString(), dataReader["author"].ToString(), 
                    dataReader["price"].ToString(), dataReader["publisher"].ToString(), dataReader["publishDate"].ToString(), 
                    int.Parse(dataReader["count"].ToString()), dataReader["isbn"].ToString(), dataReader["description"].ToString()));
            }
            //dataReader.Close();
            return inputBookList;
        }

        public BookVO SelectBook(string rentBook)
        {
            dataReader.Close();
            sqlQuery = "select * from book where name = '" + rentBook + "';";
            SendQuery(sqlQuery);
            dataReader.Read();
            return new BookVO(int.Parse(dataReader["idx"].ToString()), dataReader["name"].ToString(), dataReader["author"].ToString(),
                dataReader["price"].ToString(), dataReader["publisher"].ToString(), dataReader["publishDate"].ToString(), int.Parse(dataReader["count"].ToString()), dataReader["isbn"].ToString(),
                dataReader["description"].ToString());
        }

        public void UpdateMember(string id)
        {
            dataReader.Close();
            sqlQuery = "update member set rentbook = '없음', duedate = '없음', extensionCount = 2 where id = '" + id + "';";
            SendQuery(sqlQuery);
        }

        public int SelectCount(string rentBook)
        {
            dataReader.Close();
            sqlQuery = "select count from book where name='" + rentBook + "';";
            SendQuery(sqlQuery);
            dataReader.Read();

            return int.Parse(dataReader["count"].ToString());
        }

        public void UpdateBookCount(int bookCount, string rentBook)
        {
            dataReader.Close();
            sqlQuery = "update book set count=" + bookCount + " where name='" + rentBook + "';";
            SendQuery(sqlQuery);
        }

        public void UpdateDueDate(string dueDate, int extensionCount, string id)
        {
            dataReader.Close();
            sqlQuery = "update member set duedate='" + dueDate + "', extensionCount=" + extensionCount + " where id = '" + id + "';";
            SendQuery(sqlQuery);
        }

        public bool IsBookDuplicated(BookVO inputBook)
        {
            dataReader.Close();
            sqlQuery = "select * from book where isbn='" + inputBook.Isbn + "';";
            SendQuery(sqlQuery);

            if(dataReader.HasRows)
            {
                dataReader.Close();
                return true;
            }

            dataReader.Close();
            return false;
        }

        public bool IsMemberDulplicated(string id)
        {
            dataReader.Close();
            sqlQuery = "select id from member where id='"+ id +"';";
            SendQuery(sqlQuery);
            if (dataReader.HasRows)
            {
                dataReader.Close();
                return true;
            }
            dataReader.Close();
            return false;
        }

        public string Select(string id, string password)
        {
            sqlQuery = "select * from member where id='" + id + "' and password='" + password + "';";
            SendQuery(sqlQuery);

            if (dataReader.HasRows == false)
            {
                dataReader.Close();
                return "NoUser";
            }
            dataReader.Read();

            if(dataReader["id"].ToString().Equals(id) && dataReader["password"].ToString().Equals(password))
            {
                if(id.Equals("관리자"))
                {
                    dataReader.Close();
                    return "Admin";
                }

                dataReader.Close();
                return "User";
            }

            dataReader.Close();
            return "NoUser";
        }
    }
}
