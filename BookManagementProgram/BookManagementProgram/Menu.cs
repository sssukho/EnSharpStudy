using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
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

        public Menu()
        {

        }

        public Menu(Menu menu, List<Member> memberList, List<Book> bookList)
        {
            this.menu = menu;
            this.memberList = memberList;
            this.bookList = bookList;
            memberErrorCheck = new MemberErrorCheck();
            bookErrorCheck = new BookErrorCheck();
            printErrorMsg = new PrintErrorMsg();
            memberManagement = new MemberManagement();
            bookManagement = new BookManagement();
            bookRent = new BookRent();
            new BookDataAdd(this.bookList);
            new MemberDataAdd(this.memberList);
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
            this.bookRent = bookRent;
            this.menu = menu;
            memberErrorCheck = new MemberErrorCheck();

            PrintMenu.ViewMainMenu();

            string menuSelect;
            menuSelect = Console.ReadLine();
            
            MenuErrorHandler(menuSelect);
        }

        public void ViewMainMenu(List<Member> inputMemberList, List<Book> inputBookList)
        {
            this.memberList = inputMemberList;
            this.bookList = inputBookList;
            menu = new Menu();
            memberErrorCheck = new MemberErrorCheck();
            bookErrorCheck = new BookErrorCheck();
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
                        memberManagement.ViewMenu(menu, memberList, memberManagement, memberErrorCheck, printErrorMsg);
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
