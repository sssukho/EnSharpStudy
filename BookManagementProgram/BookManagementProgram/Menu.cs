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
        MemberErrorCheck errorCheck;
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
            errorCheck = new MemberErrorCheck();
            printErrorMsg = new PrintErrorMsg();
            memberManagement = new MemberManagement();
            bookManagement = new BookManagement();
            bookRent = new BookRent();
            ViewMainMenu();
        }

        public Menu(List<Member> memberList)
        {
            this.memberList = memberList;
            ViewMainMenu();
        }

        public Menu(List<Book> bookList)
        {
            this.bookList = bookList;
            ViewMainMenu();
        }

        public void ViewMainMenu()
        {
            PrintMenu.ViewMainMenu();
            string menuSelect;
            menuSelect = Console.ReadLine();

            MenuErrorHandler(menuSelect);
        }

        public void ViewMainMenu(List<Member> memberList, MemberManagement memberManagement, MemberErrorCheck errorCheck, PrintErrorMsg printErrorMsg)
        {
            this.memberList = memberList;
            this.memberManagement = memberManagement;
            this.errorCheck = errorCheck;
            this.printErrorMsg = printErrorMsg;

            PrintMenu.ViewMainMenu();
            string menuSelect;
            menuSelect = Console.ReadLine();

            MenuErrorHandler(menuSelect);
        }

        void MenuErrorHandler(string menuSelect)
        {
            bool error;
            error = errorCheck.MainMenuInputError(menuSelect);

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
                        memberManagement.ViewMenu(menu, memberList, memberManagement, errorCheck, printErrorMsg);
                        break;

                    case "2":
                        bookRent.ViewMenu();
                        break;

                    case "3":
                        bookRent.ViewMenu();
                        break;

                    case "4":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
