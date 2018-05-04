using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BookManagement
{
    class Login
    {
        Print print;
        ErrorCheck errorCheck;

        String databaseConnect;
        MySqlConnection connect;
        MySqlDataReader dataReader;
        MySqlCommand command;
        String sqlQuery;

        public static MemberVO logOnMember;

        public Login()
        {
            print = new Print();
            errorCheck = ErrorCheck.GetInstance();
        }

        public void LoginToMenu()
        {
            string id;
            string password;

            print.LoginUI();

            while (true)
            {
                Console.Write("아이디 ▶ "); id = Console.ReadLine();
                if (errorCheck.MemberID(id) == false)
                    break;
                print.FormErrorMsg("아이디");
            }

            while (true)
            {
                Console.Write("\n\n패스워드 ▶ "); password = Console.ReadLine();
                if (errorCheck.MemberPassword(password) == false)
                    break;
                print.FormErrorMsg("패스워드");
            }

            if (IsAuthenticateLogin(id, password) == false)
            {
                print.LoginError();
                LoginToMenu();
                return;
            }
            new Menu(print);
        }

        public bool IsAuthenticateLogin(string id, string password) //로그인 클래스로
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
                   dataReader["email"].ToString(), dataReader["address"].ToString(), dataReader["rentbook"].ToString(), dataReader["duedate"].ToString(), 3);
                dataReader.Close();
                connect.Close();
                return true;
            }

            dataReader.Close();
            connect.Close();
            return false;
        }
    }
}
