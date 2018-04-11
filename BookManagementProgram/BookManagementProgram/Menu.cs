using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class Menu
    {
        ErrorCheck errorCheck;
        MemberManagement memberManagement;
        BookRent bookRent;
        PrintErrorMsg printErrorMsg;

        public Menu()
        {
            ViewMainMenu();
        }

        public Menu(ErrorCheck errorCheck, MemberManagement memberManagement, BookRent bookRent, PrintErrorMsg printErrorMsg)
        {
            this.errorCheck = errorCheck;
            this.memberManagement = memberManagement;
            this.bookRent = bookRent;
            this.printErrorMsg = printErrorMsg;
            ViewMainMenu();
        }

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
                        memberManagement.ViewMenu(memberManagement);
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
