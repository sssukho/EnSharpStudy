using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class BookRentErrorHandler
    {
        List<Member> memberList;
        List<Book> bookList;
        BookRent bookRent;
        BookRentErrorCheck errorCheck;
        //BookRentErrorHandler errorHandler;
        //PrintInput printInput;
        PrintErrorMsg printErrorMsg;
        //PrintCompleteMsg printCompleteMsg;
        Menu menu;

        bool error;

        public BookRentErrorHandler() { }

        public BookRentErrorHandler(BookRentErrorCheck errorCheck, PrintErrorMsg printErrorMsg, BookRent bookRent, List<Member> memberList, List<Book> bookList, Menu menu)
        {
            this.errorCheck = errorCheck;
            this.printErrorMsg = printErrorMsg;
            this.bookRent = bookRent;
            this.memberList = memberList;
            this.bookList = bookList;
            this.menu = menu;
        }

        public void MenuErrorHandler(Menu menu, string menuSelect)
        {
            error = errorCheck.Number5InputError(menuSelect);
            if (error == true)
            {
                printErrorMsg.Number5InputErrorMsg();
                bookRent.ViewMenu(memberList, bookList, menu);
            }

            else
            {
                switch (menuSelect)
                {
                    case "1":
                        bookRent.Rental(memberList, bookList);
                        break;

                    case "2":
                        bookRent.Return(memberList, bookList);
                        break;

                    case "3":
                        bookRent.Extension(memberList, bookList);
                        break;

                    case "4":
                        menu.ViewMainMenu(memberList, bookList);
                        break;

                    case "5":
                        Environment.Exit(0);
                        break;
                }
            }
        }
        
    }
}
