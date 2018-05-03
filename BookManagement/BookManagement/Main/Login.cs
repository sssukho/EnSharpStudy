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
        Function function;

        public Login()
        {
            print = new Print();
            function = new Function();
        }

        public void LoginToMenu()
        {
            string id;
            string password;

            print.LoginUI();

            Console.Write("아이디 ▶ "); id = Console.ReadLine();
            Console.Write("\n\n패스워드 ▶ "); password = Console.ReadLine();

            if (function.IsAuthenticateLogin(id, password) == true)
                new Menu(print, function);

            else
            {
                Console.WriteLine("로그인 실패");
                LoginToMenu();
                return;
            }
        }
    }
}
