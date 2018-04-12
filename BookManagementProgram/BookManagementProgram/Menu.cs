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
            this.memberErrorCheck = errorCheck;
            this.printErrorMsg = printErrorMsg;
            
            string menuSelect;
            menuSelect = Console.ReadLine();

            MenuErrorHandler(menuSelect);
        }

        public void ViewMainMenu(List<Book> bookList, BookRent bookRent, BookManagement bookManagement, BookErrorCheck errorCheck, PrintErrorMsg printErrorMsg)
        {
            this.bookList = bookList;
            this.bookManagement = bookManagement;
            this.bookErrorCheck = errorCheck;
            this.printErrorMsg = printErrorMsg;
            this.bookRent = bookRent;

            string menuSelect;
            menuSelect = Console.ReadLine();

            MenuErrorHandler(menuSelect);
        }

        void MenuErrorHandler(string menuSelect)
        {
            bool error;
            error = memberErrorCheck.MainMenuInputError(menuSelect);

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
