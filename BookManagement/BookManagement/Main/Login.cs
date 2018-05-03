using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    class Login
    { //패스워드 별처리 할 것
        Print print;
        Query query;

        public Login()
        {
            print = new Print();
            query = new Query();
        }

        public void LoginToMenu()
        {
            string id;
            string password;

            print.LoginUI();

            Console.Write("아이디 ▶ "); id = Console.ReadLine();
            Console.Write("\n\n패스워드 ▶ "); password = Console.ReadLine();

            if (query.IsAuthenticateLogin(id, password) == true)
            {
                new Menu(print, query);
            }

            else
            {
                Console.WriteLine("로그인 실패");
                LoginToMenu();
                return;
            }
        }
    }
}
