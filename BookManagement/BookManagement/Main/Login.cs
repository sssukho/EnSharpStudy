using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    class Login
    { //패스워드 별처리 할 것
        public Login()
        {
            string id;
            string password;

            new Print().LoginUI();
            
            Console.Write("아이디 ▶ ");
            id = Console.ReadLine();
            Console.Write("\n\n패스워드 ▶ ");
            password = Console.ReadLine();

            if(new Query().IsAuthenticateLogin(id,password) == true)
            {
                new Menu();
            }

            else
            {
                Console.WriteLine("로그인 실패");
            }
        }
    }
}
