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
            BookErrorCheck errorCheck,PrintErrorMsg printErrorMsg, PrintInput printInput, Menu menu)
        {
            this.bookManagement = bookManagement;
            this.bookRent = bookRent;
            this.bookList = bookList;
            this.errorCheck = errorCheck;
            this.printErrorMsg = printErrorMsg;
            this.printInput = printInput;
            this.menu = menu;
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

                    case "6":
                        menu.ViewMainMenu(bookList, bookRent, bookManagement, errorCheck, printErrorMsg, menu);
                        break;

                    case "7":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void EditMenuErrorHandler(string menuSelect, bool error, List<Book> inputBookList)
        {
            if (error == true)
            {
                printErrorMsg.ManangeMenuInputErrorMsg();
                PrintMenu.EditMemberMenu();
                bookManagement.ViewEditMenu(inputBookList);
            }

            else
            {
                switch (menuSelect)
                {
                    case "1":
                        bookManagement.EditSearchByName(inputBookList, printInput.EditSearchBookName()); //에러체크할것(타입, 공백)
                        break;

                    case "2":
                        bookManagement.EditSearchByPublisher(inputBookList, printInput.EditSearchPublisher()); //에러체크할것(타입, 공백)
                        break;

                    case "3":
                        bookManagement.EditSearchByAuthor(inputBookList, printInput.EditSearchAuthor());
                        break;

                    case "4":
                        bookManagement.ViewMenu(menu, inputBookList, bookManagement, bookRent, errorCheck, printErrorMsg);
                        break;

                    case "5":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void EditSearchNameListIndexErrorHandler(List<Book> inputBookList, int inputListIndex)
        {
            ConsoleKeyInfo input;
            printErrorMsg.NoMemberErrorMsg();
            input = Console.ReadKey(true);
            error = errorCheck.ConsoleInputErrorCheck(input);

            if (error == true)
            {
                Console.WriteLine("1 과 2 만 입력이 가능합니다.");
                EditSearchNameListIndexErrorHandler(inputBookList, inputListIndex);
            }

            else
            {
                string name;
                switch (int.Parse(input.KeyChar.ToString()))
                {
                    case 1:
                        name = printInput.EditSearchName();
                        bookManagement.EditSearchByName(inputBookList, name);
                        break;

                    case 2:
                        bookManagement.ViewEditMenu(inputBookList);
                        break;
                }
            }
        }

        public void EditSearchPublisherListIndexErrorHandler(List<Book> inputBookList, int inputListIndex)
        {
            ConsoleKeyInfo input;
            printErrorMsg.NoMemberErrorMsg();
            input = Console.ReadKey(true);
            error = errorCheck.ConsoleInputErrorCheck(input);

            if (error == true)
            {
                Console.WriteLine("1 과 2 만 입력이 가능합니다.");
                EditSearchPublisherListIndexErrorHandler(inputBookList, inputListIndex);
            }

            else
            {
                string name;
                switch (int.Parse(input.KeyChar.ToString()))
                {
                    case 1:
                        name = printInput.EditSearchPublisher();
                        bookManagement.EditSearchByPublisher(inputBookList, name);
                        break;

                    case 2:
                        bookManagement.ViewEditMenu(inputBookList);
                        break;
                }
            }
        }

        public void EditSearchAuthorListIndexErrorHandler(List<Book> inputBookList, int inputListIndex)
        {
            ConsoleKeyInfo input;
            printErrorMsg.NoMemberErrorMsg();
            input = Console.ReadKey(true);
            error = errorCheck.ConsoleInputErrorCheck(input);

            if (error == true)
            {
                Console.WriteLine("1 과 2 만 입력이 가능합니다.");
                EditSearchAuthorListIndexErrorHandler(inputBookList, inputListIndex);
            }

            else
            {
                string name;
                switch (int.Parse(input.KeyChar.ToString()))
                {
                    case 1:
                        name = printInput.EditSearchAuthor();
                        bookManagement.EditSearchByAuthor(inputBookList, name);
                        break;

                    case 2:
                        bookManagement.ViewEditMenu(inputBookList);
                        break;
                }
            }
        }

        public void DeleteMenuErrorHandler(string menuSelect, bool error, List<Book> inputBookList)
        {
            if (error == true)
            {
                printErrorMsg.ManangeMenuInputErrorMsg();//예외처리 필요
                bookManagement.ViewDeleteMenu(inputBookList);
            }

            else
            {
                switch (menuSelect)
                {
                    case "1":
                        bookManagement.DeleteSearchByName(inputBookList, printInput.DeleteSearchBookName()); //에러체크할것(타입, 공백)
                        break;

                    case "2":
                        bookManagement.DeleteSearchByPublisher(inputBookList, printInput.DeleteSearchPublisher()); //에러체크할것(타입, 공백)
                        break;

                    case "3":
                        bookManagement.DeleteSearchByAuthor(inputBookList, printInput.DeleteSearchAuthor());
                        break;

                    case "4":
                        bookManagement.ViewMenu(menu, inputBookList, bookManagement, bookRent, errorCheck, printErrorMsg);
                        break;

                    case "5":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void DeleteSearchNameListIndexErrorHandler(List<Book> inputBookList, int inputListIndex)
        {
            ConsoleKeyInfo input;
            printErrorMsg.NoBookErrorMsg();
            input = Console.ReadKey(true);
            error = errorCheck.ConsoleInputErrorCheck(input);

            if (error == true)
            {
                Console.WriteLine("1 과 2 만 입력이 가능합니다.");
                EditSearchNameListIndexErrorHandler(inputBookList, inputListIndex);
            }

            else
            {
                string name;
                switch (int.Parse(input.KeyChar.ToString()))
                {
                    case 1:
                        name = printInput.DeleteSearchBookName();
                        bookManagement.DeleteSearchByName(inputBookList, name);
                        break;

                    case 2:
                        bookManagement.ViewDeleteMenu(inputBookList);
                        break;
                }
            }
        }

        public void DeleteSearchPublisherListIndexErrorHandler(List<Book> inputBookList, int inputListIndex)
        {
            ConsoleKeyInfo input;
            printErrorMsg.NoBookErrorMsg();
            input = Console.ReadKey(true);
            error = errorCheck.ConsoleInputErrorCheck(input);

            if (error == true)
            {
                Console.WriteLine("1 과 2 만 입력이 가능합니다.");
                EditSearchNameListIndexErrorHandler(inputBookList, inputListIndex);
            }

            else
            {
                string publisher;
                switch (int.Parse(input.KeyChar.ToString()))
                {
                    case 1:
                        publisher = printInput.DeleteSearchPublisher();
                        bookManagement.DeleteSearchByPublisher(inputBookList, publisher);
                        break;

                    case 2:
                        bookManagement.ViewDeleteMenu(inputBookList);
                        break;
                }
            }
        }

        public void DeleteSearchAuthorListIndexErrorHandler(List<Book> inputBookList, int inputListIndex)
        {
            ConsoleKeyInfo input;
            printErrorMsg.NoMemberErrorMsg();
            input = Console.ReadKey(true);
            error = errorCheck.ConsoleInputErrorCheck(input);

            if (error == true)
            {
                Console.WriteLine("1 과 2 만 입력이 가능합니다.");
                EditSearchNameListIndexErrorHandler(inputBookList, inputListIndex);
            }

            else
            {
                string author;
                switch (int.Parse(input.KeyChar.ToString()))
                {
                    case 1:
                        author = printInput.DeleteSearchAuthor();
                        bookManagement.DeleteSearchByAuthor(inputBookList, author);
                        break;

                    case 2:
                        bookManagement.ViewDeleteMenu(inputBookList);
                        break;
                }
            }
        }

        public void SearchMenuErrorHandler(string menuSelect, bool error, List<Book> inputBookList)
        {
            if (error == true)
            {
                printErrorMsg.Number5InputErrorMsg();//예외처리 필요
                bookManagement.ViewSearchMenu(inputBookList);
            }

            else
            {
                switch (menuSelect)
                {
                    case "1":
                        bookManagement.SearchByName(inputBookList, printInput.SearchBookName()); //에러체크할것(타입, 공백)
                        break;

                    case "2":
                        bookManagement.SearchByPublisher(inputBookList, printInput.SearchPublisher()); //에러체크할것(타입, 공백)
                        break;

                    case "3":
                        bookManagement.SearchByAuthor(inputBookList, printInput.SearchAuthor());
                        break;

                    case "4":
                        bookManagement.ViewMenu(menu, bookList, bookManagement, bookRent, errorCheck, printErrorMsg);
                        break;

                    case "5":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void SearchNameListIndexErrorHandler(List<Book> inputBookList, int inputListIndex)
        {
            ConsoleKeyInfo input;
            printErrorMsg.NoBookErrorMsg();
            input = Console.ReadKey(true);
            error = errorCheck.ConsoleInputErrorCheck(input);

            if (error == true)
            {
                Console.WriteLine("1 과 2 만 입력이 가능합니다.");
                SearchNameListIndexErrorHandler(inputBookList, inputListIndex);
            }

            else
            {
                string name;
                switch (int.Parse(input.KeyChar.ToString()))
                {
                    case 1:
                        name = printInput.SearchName();
                        bookManagement.SearchByName(inputBookList, name);
                        break;

                    case 2:
                        bookManagement.ViewSearchMenu(inputBookList);
                        break;
                }
            }
        }

        public void SearchAuthorListIndexErrorHandler(List<Book> inputBookList, int inputListIndex)
        {
            ConsoleKeyInfo input;
            printErrorMsg.NoBookErrorMsg();
            input = Console.ReadKey(true);
            error = errorCheck.ConsoleInputErrorCheck(input);

            if (error == true)
            {
                Console.WriteLine("1 과 2 만 입력이 가능합니다.");
                SearchAuthorListIndexErrorHandler(inputBookList, inputListIndex);
            }

            else
            {
                string author;
                switch (int.Parse(input.KeyChar.ToString()))
                {
                    case 1:
                        author = printInput.SearchName();
                        bookManagement.SearchByAuthor(inputBookList, author);
                        break;

                    case 2:
                        bookManagement.ViewSearchMenu(inputBookList);
                        break;
                }
            }
        }

        public void SearchPublisherListIndexErrorHandler(List<Book> inputBookList, int inputListIndex)
        {
            ConsoleKeyInfo input;
            printErrorMsg.NoBookErrorMsg();
            input = Console.ReadKey(true);
            error = errorCheck.ConsoleInputErrorCheck(input);

            if (error == true)
            {
                Console.WriteLine("1 과 2 만 입력이 가능합니다.");
                SearchPublisherListIndexErrorHandler(inputBookList, inputListIndex);
            }

            else
            {
                string publisher;
                switch (int.Parse(input.KeyChar.ToString()))
                {
                    case 1:
                        publisher = printInput.SearchName();
                        bookManagement.SearchByPublisher(inputBookList, publisher);
                        break;

                    case 2:
                        bookManagement.ViewSearchMenu(inputBookList);
                        break;
                }
            }
        }
    }
}
