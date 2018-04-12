using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class BookManagement : Book
    {
        Menu menu;
        List<Book> bookList;
        BookErrorCheck errorCheck;
        PrintInput printInput;
        BookErrorHandler errorHandler;
        BookManagement bookManagement;
        BookRent bookRent;
        PrintErrorMsg printErrorMsg;
        PrintCompleteMsg printCompleteMsg;

        string menuSelect;
        bool error;

        public BookManagement() : base(){}

        public void ViewMenu(Menu menu, List<Book> bookList,
            BookManagement bookManagement, BookRent bookRent, 
            BookErrorCheck errorCheck, PrintErrorMsg printErrorMsg)
        {
            this.menu = menu;
            this.bookManagement= bookManagement;
            this.bookList = bookList;
            this.errorCheck = errorCheck;
            this.printErrorMsg = printErrorMsg;
            printInput = new PrintInput();
            printCompleteMsg = new PrintCompleteMsg();

            PrintMenu.ViewBookManageMenu();
            menuSelect = Console.ReadLine();

            errorHandler = new BookErrorHandler(bookManagement, bookRent, bookList, errorCheck, printErrorMsg, printInput, menu);
            errorHandler.ManageMenuErrorHandler(menu, menuSelect);
        }

        public void Register(List<Book> bookList)
        {

        }

        public void ViewEditMenu(List<Book> bookList)
        {

        }

        public void ViewDeleteMenu(List<Book> bookList)
        {

        }

        public void ViewSearchMenu(List<Book> bookList)
        {

        }

        public void ViewBookList(List<Book> bookList, BookRent bookRent, BookManagement bookManagement, BookErrorCheck errorCheck, PrintErrorMsg printErrorMsg)
        {

        }
    }
}
