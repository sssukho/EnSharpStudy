﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    /// <summary>
    /// 각 상황별 에러 메시지
    /// </summary>
    class PrintErrorMsg
    {
        public void MenuInputErrorMsg()
        {
            Console.WriteLine("1 ~ 4 만 입력이 가능합니다.");
            Console.WriteLine("다시 입력하려면 엔터키");
            Console.ReadLine();
        }

        public void Number5InputErrorMsg()
        {
            Console.WriteLine("1 ~ 5 만 입력이 가능합니다.");
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

        public void NoMemberErrorMsg()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t사용자가 존재하지 않습니다.");
            Console.WriteLine("\n\n\t다시 입력 : 1번 (바로 진입함)");
            Console.WriteLine("\t이전 메뉴로 : 2번 (바로 진입함)");
        }

        public void NoBookErrorMsg()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t도서가 존재하지 않습니다.");
            Console.WriteLine("\n\n\t다시 입력 : 1번 (바로 진입함)");
            Console.WriteLine("\t이전 메뉴로 : 2번 (바로 진입함)");
        }

        public void BookCountErrorMsg()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t도서 수량이 없습니다.");
            Console.WriteLine("\n\n\t다시 입력 : 1번 (바로 진입함)");
            Console.WriteLine("\t이전 메뉴로 : 2번 (바로 진입함)");
        }
    }
}
