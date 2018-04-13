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

        public BookManagement() { }

        public void ViewMenu(Menu menu, List<Book> bookList,
            BookManagement bookManagement, BookRent bookRent, 
            BookErrorCheck errorCheck, PrintErrorMsg printErrorMsg)
        {
            this.menu = menu;
            this.bookManagement= bookManagement;
            this.bookList = bookList;
            this.bookRent = bookRent;
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
            Book newBook;
            newBook = printInput.BookRegister();
            error = errorCheck.RegisterErrorCheck(newBook);

            if (error == true)
            {
                printErrorMsg.RegisterInputErrorMsg();
                Register(bookList);
            }

            else
            {
                bookList.Add(newBook);
                printCompleteMsg.RegisterCompleteMsg();
                ViewMenu(menu, bookList, bookManagement, bookRent, errorCheck, printErrorMsg);
            }
        }

        public void ViewEditMenu(List<Book> inputBookList)
        {
            PrintMenu.EditBookMenu();
            menuSelect = Console.ReadLine();
            error = errorCheck.Number5InputError(menuSelect);
            errorHandler.EditMenuErrorHandler(menuSelect, error, inputBookList);
        }

        public void Edit(int listIndex, List<Book> inputBookList)
        {
            inputBookList[listIndex] = printInput.BookEdit(inputBookList[listIndex], errorHandler);
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                printErrorMsg.NoBookErrorMsg(); //순서 에러 쳌
                Edit(listIndex, inputBookList);
            }

            else
            {
                printCompleteMsg.EditCompleteMsg();
                ViewEditMenu(inputBookList);
            }
        }

        public void EditSearchByName(List<Book> inputBookList, string inputName)
        {
            int listIndex;
            bool error; 

            listIndex = inputBookList.FindIndex(book => book.BookName.Equals(inputName));
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                errorHandler.EditSearchNameListIndexErrorHandler(inputBookList, listIndex);
            }

            else
            {
                Edit(listIndex, inputBookList);
            }
        }

        public void EditSearchByPublisher(List<Book> inputBookList, string inputPublisher)
        {
            int listIndex;
            bool error;

            listIndex = inputBookList.FindIndex(book => book.Publisher.Equals(inputPublisher));
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                errorHandler.EditSearchPublisherListIndexErrorHandler(inputBookList, listIndex);
            }

            else
            {
                Edit(listIndex, inputBookList);
            }
        }

        public void EditSearchByAuthor(List<Book> inputBookList, string inputAuthor)
        {
            int listIndex;
            bool error;

            listIndex = inputBookList.FindIndex(book => book.Author.Equals(inputAuthor));
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                errorHandler.EditSearchAuthorListIndexErrorHandler(inputBookList, listIndex);
            }

            else
            {
                Edit(listIndex, inputBookList);
            }
        }

        public void ViewDeleteMenu(List<Book> inputBookList)
        {
            PrintMenu.DeleteBookMenu();
            menuSelect = Console.ReadLine();
            error = errorCheck.Number5InputError(menuSelect);
            errorHandler.DeleteMenuErrorHandler(menuSelect, error, inputBookList);
        }

        public void Delete(int listIndex, List<Book> inputBookList)
        {
            string confirm;

            confirm = printInput.DeleteBookCheck(inputBookList[listIndex], errorHandler);
            error = errorCheck.DeleteErrorCheck(inputBookList[listIndex], confirm);

            if (error == true)
            {
                printErrorMsg.NoBookErrorMsg();
                Delete(listIndex, inputBookList);
            }

            else
            {
                inputBookList.RemoveAt(listIndex);
                printCompleteMsg.DeleteCompleteMsg();
                ViewDeleteMenu(inputBookList);
            }
        }

        public void DeleteSearchByName(List<Book> inputBookList, string inputName)
        {
            int listIndex;
            bool error;

            listIndex = inputBookList.FindIndex(book => book.BookName.Equals(inputName));
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                errorHandler.DeleteSearchNameListIndexErrorHandler(inputBookList, listIndex);
            }

            else
            {
                printCompleteMsg.DeleteCompleteMsg();
                Delete(listIndex, inputBookList);
            }
        }

        public void DeleteSearchByPublisher(List<Book> inputBookList, string inputPublisher)
        {
            int listIndex;
            bool error;

            listIndex = inputBookList.FindIndex(book => book.BookName.Equals(inputPublisher));
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                errorHandler.DeleteSearchNameListIndexErrorHandler(inputBookList, listIndex);
            }

            else
            {
                printCompleteMsg.DeleteCompleteMsg();
                Delete(listIndex, inputBookList);
            }
        }

        public void DeleteSearchByAuthor(List<Book> inputBookList, string inputAuthor)
        {
            int listIndex;
            bool error;

            listIndex = inputBookList.FindIndex(book => book.BookName.Equals(inputAuthor));
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                errorHandler.DeleteSearchNameListIndexErrorHandler(inputBookList, listIndex);
            }

            else
            {
                printCompleteMsg.DeleteCompleteMsg();
                Delete(listIndex, inputBookList);
            }
        }

        public void ViewSearchMenu(List<Book> inputBookList)
        {
            PrintMenu.SearchBookMenu();
            menuSelect = Console.ReadLine();
            error = errorCheck.Number5InputError(menuSelect);
            errorHandler.SearchMenuErrorHandler(menuSelect, error, inputBookList);
        }

        public void ViewBookList(List<Book> inputBookList, BookRent bookRent, BookManagement bookManagement, BookErrorCheck errorCheck, PrintErrorMsg printErrorMsg)
        {
            printInput.ViewAllBook(inputBookList);
            ViewMenu(menu, bookList, bookManagement, bookRent, errorCheck, printErrorMsg);
        }

        public void Search(int listIndex, List<Book> inputBookList)
        {
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                printErrorMsg.NoMemberErrorMsg();
                Search(listIndex, inputBookList);
            }

            else
            {
                printInput.BookSearchCheck(inputBookList[listIndex], errorHandler);
                ViewSearchMenu(inputBookList);
            }
        }

        public void SearchByName(List<Book> inputBookList, string inputName)
        {
            int listIndex;
            bool error;

            listIndex = inputBookList.FindIndex(book => book.BookName.Equals(inputName));
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                errorHandler.SearchNameListIndexErrorHandler(inputBookList, listIndex);
            }

            else
            {
                Search(listIndex, inputBookList);
            }
        }

        public void SearchByPublisher(List<Book> inputBookList, string inputPublisher)
        {
            int listIndex;
            bool error;

            listIndex = inputBookList.FindIndex(book => book.Publisher.Equals(inputPublisher));
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                errorHandler.SearchPublisherListIndexErrorHandler(inputBookList, listIndex);
            }

            else
            {
                Search(listIndex, inputBookList);
            }
        }

        public void SearchByAuthor(List<Book> inputBookList, string inputAuthor)
        {
            int listIndex;
            bool error;

            listIndex = inputBookList.FindIndex(book => book.Author.Equals(inputAuthor));
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                errorHandler.SearchAuthorListIndexErrorHandler(inputBookList, listIndex);
            }

            else
            {
                Search(listIndex, inputBookList);
            }
        }
    }
}
