using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManage
{
    class BookManagement
    {
        private const int REGISTRATION = 1;
        private const int EDIT = 2;
        private const int REMOVE = 3;
        private const int SEARCH = 4;
        private const int PRINT_MEMBER_LIST = 5;
        private const int PREVIOUS = 6;
        private const int EXIT = 7;
        private const int REINPUT = 1;
        private const int GOPREV = 2;
        private const int SEARCH_BY_NAME = 1;
        private const int SEARCH_BY_PUBLISHER = 2;
        private const int SEARCH_BY_AUTHOR = 3;
        private const int NO_BOOK = -1;

        Menu menu;
        List<Book> bookList;
        Print print;
        ErrorCheck errorCheck;

        int menuSelect;
        int listIndex;

        public BookManagement(Menu menu)
        {
            this.menu = menu;
            this.bookList = new List<Book>();
            this.print = new Print();
            this.errorCheck = new ErrorCheck();
        } 

        public List<Book> BookList
        {
            set { bookList = value; }
            get { return bookList; }
        }

        public void ViewMenu()
        {
            print.Menu("도서관리");
            menuSelect = int.Parse(Console.ReadLine());

            switch(menuSelect)
            {
                case REGISTRATION:
                    Register();
                    break;

                case EDIT:
                    Edit();
                    break;

                case REMOVE:
                    Delete();
                    break;

                case SEARCH:
                    Search();
                    break;

                case PRINT_MEMBER_LIST:
                    PrintBookList();
                    break;

                case PREVIOUS:
                    menu.ViewMenu();
                    break;

                case EXIT:
                    Environment.Exit(0);
                    break;
            }
        }
        
        public void Register()
        {
            Book newBook;
            newBook = print.BookRegister(); //에러체크

            bookList.Add(newBook);
            print.CompleteMsg("등록이 완료");
            ViewMenu();
        }

        public void Edit()
        {
            /*
            string input;
            int listIndex;
            int menuInput;

            print.Search("편집할 회원의 학번을 ");
            input = Console.ReadLine(); //타입 에러처리
            listIndex = bookList.FindIndex(book => );

            if (listIndex == NO_BOOK)
            {
                print.ErrorMsg("존재하지않는회원");
                menuInput = int.Parse(Console.ReadLine()); //타입 에러처리
                if (menuInput == REINPUT)
                {
                    Edit();
                }
                if (menuInput == GOPREV)
                {
                    ViewMenu();
                }
                else
                {
                    //error처리
                }
            }
            else //리스트에 존재
            {
                memberList[listIndex] = print.MemberEdit(memberList[listIndex]);
            }*/
        }

        public void Delete()
        {

        }

        public void Search()
        {
            string input;
            int type = 0;


            print.Menu("도서검색");
            menuSelect = int.Parse(Console.ReadLine());

            switch (menuSelect)
            {
                case SEARCH_BY_NAME:
                    print.Search("도서명");
                    input = Console.ReadLine();
                    listIndex = bookList.FindIndex(book => book.BookName.Equals(input));
                    break;

                case SEARCH_BY_PUBLISHER:
                    print.Search("출판사");
                    input = Console.ReadLine();
                    listIndex = bookList.FindIndex(book => book.Publisher.Equals(input));
                    break;

                case SEARCH_BY_AUTHOR:
                    print.Search("저자");
                    input = Console.ReadLine();
                    listIndex = bookList.FindIndex(book => book.Author.Equals(input));
                    break;
            }

            if (listIndex == NO_BOOK)
            {
                print.ErrorMsg("존재하지않는회원");
                menuSelect = int.Parse(Console.ReadLine()); //타입 에러처리
                if (menuSelect == REINPUT)
                {
                    Search();
                }
                if (menuSelect == GOPREV)
                {
                    ViewMenu();
                }
                else
                {
                    //error처리
                }
            }
            else //리스트에 존재
            {
                print.BookSearch(bookList[listIndex]);
            }
        }

        public void PrintBookList()
        {

        }

        

    }
}
