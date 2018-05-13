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
            dao = new DAO();
            LoginToMenu();
        }

        public void LoginToMenu()
        {
            string id;
            string password;

            print.LoginUI();

            Console.Write("아이디 ▶ "); id = Console.ReadLine();
            Console.Write("\n\n패스워드 ▶ "); password = Console.ReadLine();

            /*while (true)
            {
                
                //if (errorCheck.MemberID(id) == false)
                    break;
                print.FormErrorMsg("아이디");
            }

            while (true)
            {
                
               // if (errorCheck.MemberPassword(password) == false)
                    break;
                print.FormErrorMsg("패스워드");
            }*/

            if (AuthenticateType(id, password) == "Admin")
            {
                new AdminMenu(dao);
                return;
            }

            if(AuthenticateType(id,password) == "User")
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
