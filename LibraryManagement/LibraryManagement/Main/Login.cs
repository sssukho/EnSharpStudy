using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    /// <summary>
    /// 관리자 모드와 일반 유저 모드를 구분하기 위한 로그인 클래스
    /// </summary>
    class Login
    {
        Print print;
        ErrorCheck errorCheck;
        DAO dao;

        public Login()
        {
            print = Print.GetInstance();
            errorCheck = ErrorCheck.GetInstance();
            dao = new DAO();
            LoginToMenu();
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

            //아이디 비번 일치 확인(관리자)
            if (AuthenticateType(id, password) == "Admin")
            {
                new AdminMenu(dao);
                return;
            }

            //아이디 비번 일치 확인(유저모드)
            if (AuthenticateType(id, password) == "User")
            {
                new UserMenu(dao, id);
                return;
            }

            print.LoginError();
            LoginToMenu();
        }

        string AuthenticateType(string id, string password)
        {
            return dao.Select(id, password);
        }
    }
}
