using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BookManagement
{
    class Function
    {
        private const bool SUCCESS = true;
        private const bool FAILED = false;

        String databaseConnect;
        MySqlConnection connect;
        MySqlDataReader dataReader;
        MySqlCommand command;
        String sqlQuery;

        Print print;
        ErrorCheck errorCheck;
        Menu menu;

        public static MemberVO logOnMember;

        public Function() { }

        public Function(Menu menu)
        {
            print = Print.GetInstance();
            errorCheck = ErrorCheck.GetInstance();
            this.menu = menu;
        }

        public bool IsAuthenticateLogin(string id, string password)
        {
            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL 

            sqlQuery = "select * from member where id='" + id + "' and password='" + password + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();
            dataReader.Read();

            string serverID = dataReader["id"].ToString();
            string serverPWD = dataReader["password"].ToString();

            if (serverID.Equals(id) && serverPWD.Equals(password))
            {
                logOnMember = new MemberVO(dataReader["id"].ToString(), dataReader["password"].ToString(),
                    dataReader["name"].ToString(), dataReader["gender"].ToString(), dataReader["phoneNumber"].ToString(),
                    dataReader["email"].ToString(), dataReader["address"].ToString(), dataReader["rentbook"].ToString(), dataReader["duedate"].ToString());
                dataReader.Close();
                connect.Close();
                return true;
            }

            dataReader.Close();
            connect.Close();
            return false;
        }

        public void RegisterMember()
        {
            MemberVO newMember;
            newMember = print.MemberRegister();

            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL 

            sqlQuery = "insert into member values('" + newMember.Id + "', '" + newMember.Password + "', '"
                + newMember.Name + "', '" + newMember.Gender + "', '" + newMember.PhoneNumber + "', '"
                + newMember.Email + "', '" + newMember.Address + "', '" + newMember.RentBook + "', '"
                + newMember.DueDate + "');";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();

            if (errorCheck.IsValidRegister(dataReader) == FAILED) //등록 에러
            {
                dataReader.Close();
                connect.Close();
                print.ErrorMsg("회원 등록");
                menu.MemberManagementMenu();
                return;
            }

            dataReader.Close();
            connect.Close();
            print.CompleteMsg("회원 등록 완료");
            menu.MemberManagementMenu();
            return;
        }

        public void EditMember()
        {
            logOnMember = print.EditMember(logOnMember);
            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL

            sqlQuery = "update member set phoneNumber ='" + logOnMember.PhoneNumber + "', address ='" + logOnMember.Address + "' where id='" + logOnMember.Id + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();

            if (errorCheck.IsValidRegister(dataReader) == FAILED) //등록 에러
            {
                dataReader.Close();
                connect.Close();
                print.ErrorMsg("회원 정보 수정");
                menu.MemberManagementMenu();
                return;
            }

            dataReader.Close();
            connect.Close();
            print.CompleteMsg("회원 정보 수정 완료");
            menu.MemberManagementMenu();
            return;
        }

        public void RemoveMember()
        {

        }

        public void PrintMembers()
        {

        }

        public void RegisterBook()
        {

        }

        public void EditBook()
        {

        }

        public void RemoveBook()
        {

        }

        public void SearchBook(int searchType)
        {

        }

        public void PrintBooks()
        {

        }

        public void RentBook()
        {

        }

        public void ReturnBook()
        {

        }
    }
}
