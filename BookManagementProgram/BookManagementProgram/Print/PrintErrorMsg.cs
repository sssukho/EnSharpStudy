using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class PrintErrorMsg
    {
        public void MenuInputErrorMsg()
        {
            Console.WriteLine("1 ~ 4 만 입력이 가능합니다.");
            Console.WriteLine("다시 입력하려면 엔터키");
            Console.ReadLine();
        }

        public void ManangeMenuInputErrorMsg()
        {
            Console.WriteLine("1 ~ 7만 입력이 가능합니다.");
            Console.WriteLine("다시 입력하려면 엔터키");
            Console.ReadLine();
        }

        //시간 되면 케이스별로 나누기(인자받아서)
        public void RegisterInputErrorMsg()
        {
            Console.WriteLine("양식에 맞게 작성해주십시오.");
            Console.WriteLine("다시 입력하려면 엔터키");
            Console.ReadLine();
        }
    }
}
