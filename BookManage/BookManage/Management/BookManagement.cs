﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BookManage
{
    class BookManagement
    {
        private const int REGISTRATION = 1;
        private const int EDIT = 2;
        private const int REMOVE = 3;
        private const int SEARCH = 4;
        private const int PRINT_BOOK_LIST = 5;
        private const int PREVIOUS = 6;
        private const int EXIT = 7;

        private const int REINPUT = 1;
        private const int GOPREV = 2;

        private const int SEARCH_BY_NAME = 1;
        private const int SEARCH_BY_PUBLISHER = 2;
        private const int SEARCH_BY_AUTHOR = 3;
        private const int PREV = 4;
        private const int SHUT_DOWN = 5;

        private const int NO_BOOK = -1;

        Menu menu;
        List<Book> bookList;
        Print print;
        ErrorCheck errorCheck;

        int menuSelect;
        int listIndex;
        string input;

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

                case PRINT_BOOK_LIST:
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
            print.Menu("도서수정");
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

                case PREV:
                    menu.ViewMenu();
                    break;

                case SHUT_DOWN:
                    Environment.Exit(0);
                    break;
            }

            if (listIndex == NO_BOOK)
            {
                print.ErrorMsg("존재하지않는회원");
                menuSelect = int.Parse(Console.ReadLine()); //타입 에러, 1,2번 말고 딴 번호
                switch(menuSelect)
                {
                    case REINPUT:
                        //다시 입력창으로 돌아가는 거 
                        break;
                    case GOPREV:
                        ViewMenu();
                        break;
                }

            }
            else //리스트에 존재
            {
                bookList[listIndex] = print.BookEdit(bookList[listIndex]);
                print.CompleteMsg("수량 수정 완료");
                ViewMenu();
            }
        }

        public void Delete()
        {
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

                case PREV:
                    menu.ViewMenu();
                    break;

                case SHUT_DOWN:
                    Environment.Exit(0);
                    break;
            }

            if (listIndex == NO_BOOK)
            {
                print.ErrorMsg("존재하지않는회원");
                menuSelect = int.Parse(Console.ReadLine()); //타입 에러처리
                switch (menuSelect)
                {
                    case REINPUT:
                        //다시 입력창으로 돌아가는 것
                        break;
                    case GOPREV:
                        ViewMenu();
                        break;
                }
            }
            else //리스트에 존재
            {
                string confirm;
                print.BookDelete(bookList[listIndex]);
                confirm = Console.ReadLine();

                if (confirm == "Y" || confirm == "y")
                {
                    bookList.RemoveAt(listIndex);
                    print.CompleteMsg("도서 삭제가 완료 ");
                    ViewMenu();
                }

                else if (confirm == "N" || confirm == "n")
                {
                    Console.WriteLine("이전 메뉴로 돌아갑니다...");
                    Console.WriteLine("\t2초 후에 메뉴로 돌아갑니다...");
                    Thread.Sleep(2000);
                    ViewMenu();
                }

                else
                {
                    print.ErrorMsg("Y/N오류"); //에러체크
                }
            }
        }

        public void Search()
        {
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

                case PREV:
                    menu.ViewMenu();
                    break;

                case SHUT_DOWN:
                    Environment.Exit(0);
                    break;
            }

            if (listIndex == NO_BOOK)
            {
                print.ErrorMsg("존재하지않는회원");
                menuSelect = int.Parse(Console.ReadLine()); //타입 에러처리
                switch (menuSelect)
                {
                    case REINPUT:
                        //다시 입력창으로 돌아가는 것
                        break;
                    case GOPREV:
                        ViewMenu();
                        break;
                }
            }
            else //리스트에 존재
            {
                print.BookSearch(bookList[listIndex]);
                ViewMenu();
            }
        }

        public void PrintBookList()
        {
            print.AllBook(bookList);
            ViewMenu();
        }

        

    }
}
