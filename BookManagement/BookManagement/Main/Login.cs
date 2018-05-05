using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BookManagement
{
    /// <summary>
    /// Program.cs 을 실행하면 가장 맨 처음에 들려야 하는 클래스.
    /// 로그인 인증 방식 : 기존 db에 저장되어 있는 아이디와 비밀번호 모두 같으면 인증.
    /// logOnMember 변수 static 선언 이유 : 안드로이드 스튜디오에서 SharedPreferences
    /// 처럼 로그인한 계정의 정보를 저장해두고 책 대여 및 반납 등의 기등을 수행하기 위해서.
    /// (관리자 모드와 사용자 모드에서 사용자의 아이디 정보를 저장해서 사용하려고 했음)
    /// </summary>
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

        //로그인 인증
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
