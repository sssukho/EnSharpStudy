using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class Menu
    {
        MemberManagement memberManagement;
        BookManagement bookManagement;
        BookRent bookRent;
        ErrorCheck errorCheck;
        PrintErrorMsg printErrorMsg;
        List<Member> memberList;
        List<Book> bookList;

        public Menu(List<Member> memberList, List<Book> bookList)
        {
            this.memberList = memberList;
            this.bookList = bookList;
            this.errorCheck = new ErrorCheck();
            this.printErrorMsg = new PrintErrorMsg();
            memberManagement = new MemberManagement();
            bookManagement = new BookManagement();
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
        
        /*
        public Menu(MemberManagement memberManagement)
        {
            this.memberManagement = memberManagement;
            this.errorCheck = new ErrorCheck();
            this.printErrorMsg = new PrintErrorMsg();
            //ViewMainMenu();
        }

        public Menu(BookManagement bookManagement)
        {
            this.bookManagement = bookManagement;
            this.bookRent = new BookRent();
            this.errorCheck = new ErrorCheck();
            this.printErrorMsg = new PrintErrorMsg();
            //ViewMainMenu();
        }

        public Menu(MemberManagement memberManagement, BookManagement bookManagement)
        {
            this.memberManagement = memberManagement;
            this.bookManagement = bookManagement;
            this.bookRent = new BookRent();
            this.errorCheck = new ErrorCheck();
            this.printErrorMsg = new PrintErrorMsg();
            ViewMainMenu();
        }*/

        public void ViewMainMenu()
        {
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
                        memberManagement.ViewMenu(memberList, memberManagement, errorCheck, printErrorMsg);
                        break;

                    case "2":
                        bookRent.ViewBookManageMenu();
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
