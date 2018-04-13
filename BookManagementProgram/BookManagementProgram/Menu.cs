using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    /// <summary>
    /// 클래스 구조상 가장 상위에 있는 메인 메뉴
    /// </summary>
    class Menu
    {
        Menu menu;
        MemberManagement memberManagement;
        BookManagement bookManagement;
        BookRent bookRent;
        MemberErrorCheck memberErrorCheck;
        BookErrorCheck bookErrorCheck;
        PrintErrorMsg printErrorMsg;
        List<Member> memberList;
        List<Book> bookList;

        public Menu() { }

        public Menu(Menu menu, List<Member> memberList, List<Book> bookList)
        {
            this.memberList = memberList;
            this.bookList = bookList;
            this.menu = menu;
            memberErrorCheck = new MemberErrorCheck();
            bookErrorCheck = new BookErrorCheck();
            printErrorMsg = new PrintErrorMsg();
            memberManagement = new MemberManagement();
            bookManagement = new BookManagement();
            bookRent = new BookRent();
            new BookDataAdd(this.bookList); //처음 삽입되는 도서 데이터
            new MemberDataAdd(this.memberList); //처음 삼입되는 회원 데이터
            ViewMainMenu();
        }

        public void ViewMainMenu()
        {
            PrintMenu.ViewMainMenu();
            string menuSelect;
            menuSelect = Console.ReadLine();

            MenuErrorHandler(menuSelect);
        }

        public void ViewMainMenu(List<Member> memberList, MemberManagement memberManagement, MemberErrorCheck errorCheck, PrintErrorMsg printErrorMsg, Menu menu)
        {
            this.memberList = memberList;
            this.memberManagement = memberManagement;
            this.memberErrorCheck = errorCheck;
            this.printErrorMsg = printErrorMsg;
            this.menu = menu;
            this.bookManagement = new BookManagement();
            PrintMenu.ViewMainMenu();

            string menuSelect;
            menuSelect = Console.ReadLine();

            MenuErrorHandler(menuSelect);
        }

        public void ViewMainMenu(List<Book> bookList, BookRent bookRent, BookManagement bookManagement, BookErrorCheck errorCheck, PrintErrorMsg printErrorMsg, Menu menu)
        {
            this.bookList = bookList;
            this.bookManagement = bookManagement;
            this.bookErrorCheck = errorCheck;
            this.printErrorMsg = printErrorMsg;
            this.bookRent = new BookRent();
            this.menu = menu;
            this.memberManagement = new MemberManagement();
            memberErrorCheck = new MemberErrorCheck();

            PrintMenu.ViewMainMenu();

            string menuSelect;
            menuSelect = Console.ReadLine();
            
            MenuErrorHandler(menuSelect);
        }

        //데이터 이동시에 생기는 null 할당 예외로 인해 바꾸려고 한 생성자
        public void ViewMainMenu(List<Member> inputMemberList, List<Book> inputBookList)
        {
            this.memberList = inputMemberList;
            this.bookList = inputBookList;
            
            menu = new Menu();
            memberErrorCheck = new MemberErrorCheck();
            printErrorMsg = new PrintErrorMsg();
            memberManagement = new MemberManagement();
            bookManagement = new BookManagement();
            bookRent = new BookRent();

            PrintMenu.ViewMainMenu();

            string menuSelect;
            menuSelect = Console.ReadLine();

            MenuErrorHandler(menuSelect);
        }

        void MenuErrorHandler(string menuSelect)
        {
            bool error;
            error = memberErrorCheck.Number4InputError(menuSelect);

            if (error == true)
            {
                printErrorMsg.MenuInputErrorMsg();
                ViewMainMenu();
            }

            else
            {
                switch (menuSelect)
                {
                    case "1":
                        memberManagement.ViewMenu(menu,memberList, memberManagement, memberErrorCheck, printErrorMsg);
                        break;

                    case "2":
                        bookManagement.ViewMenu(menu, bookList, bookManagement, bookRent, bookErrorCheck, printErrorMsg);
                        break;

                    case "3":
                        bookRent.ViewMenu(memberList, bookList, menu);
                        break;

                    case "4":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
