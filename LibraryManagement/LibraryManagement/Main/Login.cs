using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class Login
    {
        Print print;
        ErrorCheck errorCheck;
        DAO dao;

        public Login()
        {
            print = Print.GetInstance();
            errorCheck = ErrorCheck.GetInstance();
            dao = DAO.GetInstance();
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

            if (IsAdmin(id, password) == true)
            {

                new AdminMenu();
                return;
            }

            new MemberMenu();
        }

        bool IsAdmin(string id, string password)
        {

        }
    }
}
