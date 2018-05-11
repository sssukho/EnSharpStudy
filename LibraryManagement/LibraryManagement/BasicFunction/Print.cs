using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LibraryManagement
{
    class Print
    {
        private static Print print;

        public Print(){ }

        public static Print GetInstance()
        {
            if (print == null)
                print = new Print();

            return print;
        }

        public void LoginUI()
        {
            Console.SetWindowSize(35, 17);
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("||                              ||");
            Console.WriteLine("||                              ||");
            Console.WriteLine("||                              ||");
            Console.WriteLine("||                              ||");
            Console.WriteLine("||       도서관리프로그램       ||");
            Console.WriteLine("||                              ||");
            Console.WriteLine("||                              ||");
            Console.WriteLine("||                              ||");
            Console.WriteLine("||   (로그인하려면 엔터키...)   ||");
            Console.WriteLine("=================================");
            Console.ReadLine();
        }

        public void FormErrorMsg(string type) //등록 및 편집시 잘못 입력하면 뜨는 오류 메시지
        {
            Console.WriteLine("\n\n\t{0} 양식에 맞게 작성해주세요.", type);
            Thread.Sleep(1000);
            Console.Clear();
        }

        public void LoginError()
        {
            Console.WriteLine("아이디와 비밀번호가 맞지 않습니다.");
            Console.WriteLine("다시 입력하려면 엔터");
            Console.ReadLine();
        }
    }
}
