using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class BookErrorHandler
    {
        BookManagement bookManagement;
        BookRent bookRent;
        List<Book> bookList;
        BookErrorCheck errorCheck;
        PrintErrorMsg printErrorMsg;
        PrintInput printInput;
        Menu menu;

        bool error;

        public BookErrorHandler() { }

        public BookErrorHandler(BookManagement bookManagement, BookRent bookRent, List<Book> bookList, 
            BookErrorCheck errorCheck,PrintErrorMsg printErrorMsg, PrintInput printinput, Menu menu)
        {
            this.bookManagement = bookManagement;

        }

        public void ManageMenuErrorHandler(Menu menu, string menuSelect)
        {
            error = errorCheck.ManagementMenuInputError(menuSelect);
            if (error == true)
            {
                printErrorMsg.ManangeMenuInputErrorMsg();
                bookManagement.ViewMenu(menu, bookList, bookManagement, bookRent, errorCheck, printErrorMsg);
            }

            else
            {
                switch (menuSelect)
                {
                    case "1":
                        bookManagement.Register(bookList);
                        break;

                    case "2":
                        bookManagement.ViewEditMenu(bookList);
                        break;

                    case "3":
                        bookManagement.ViewDeleteMenu(bookList);
                        break;

                    case "4":
                        bookManagement.ViewSearchMenu(bookList);
                        break;

                    case "5":
                        bookManagement.ViewBookList(bookList, bookRent, bookManagement, errorCheck, printErrorMsg);
                        break;
                    //menu가 널이었음
                    case "6":
                        menu.ViewMainMenu(bookList, memberManagement, errorCheck, printErrorMsg);
                        break;

                    case "7":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
