using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    class Login
    {
        public Login()
        {
            string id;
            string password;

            new Print().LoginUI();
            
            Console.Write("아이디 ▶ ");
            id = Console.ReadLine();
            Console.Write("\n\n패스워드 ▶ ");
            password = Console.ReadLine();
        }
    }
}
