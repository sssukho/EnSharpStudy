﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BookManage
{
    /// <BookManagement클래스>
    ///  모든 도서들의 데이터를 관리하는 클래스
    ///  Menu 클래스에서 생성된 도서List 데이터를 생성자로 받아와 기능들을 수행함.

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
        BookManagement bookManagement;

        string menuSelect;
        int listIndex;
        string input;

        public BookManagement(Menu menu, List<Book> bookList)
        {
            this.menu = menu;
            this.bookList = bookList;
            this.print = Print.GetInstance();
            this.errorCheck = ErrorCheck.GetInstance();
            bookManagement = this;
        } 

        public void ViewMenu()
        {
            while(true)
            {
                print.Menu("도서관리");
                menuSelect = CancelKey.ReadLineWithCancel();
                if (menuSelect == null) menu.ViewMenu();
                if (errorCheck.Number(menuSelect, "7지선다") == false)
                {
                    break;
                }
                print.MenuErrorMsg("7지선다오류");
            }

            switch(int.Parse(menuSelect))
            {
                case REGISTRATION:
                    Register();
                    break;

                case EDIT:
                    Edit(this);
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
            newBook = print.BookRegister(bookManagement); //에러체크

            bookList.Add(newBook);
            print.CompleteMsg("등록이 완료");
            ViewMenu();
        }

        public void Edit(BookManagement bookManagement)
        {
            while(true)
            {
                print.Menu("도서수정");
                menuSelect = CancelKey.ReadLineWithCancel();
                if (menuSelect == null) ViewMenu();
                if (errorCheck.Number(menuSelect, "5지선다") == false)
                {
                    break;
                }
                print.MenuErrorMsg("5지선다오류");
            }
            switch (int.Parse(menuSelect))
            {
                case SEARCH_BY_NAME:
                    listIndex = SearchByName();
                    break;

                case SEARCH_BY_PUBLISHER:
                    listIndex = SearchByPublisher();
                    break;

                case SEARCH_BY_AUTHOR:
                    listIndex = SearchByAuthor();
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
                while(true)
                {
                    print.ErrorMsg("존재하지않는도서");
                    menuSelect = CancelKey.ReadLineWithCancel();
                    if (menuSelect == null) Edit(this);
                    if (errorCheck.Number(menuSelect, "선택") == false)
                    {
                        break;
                    }
                }

                switch (int.Parse(menuSelect))
                {
                    case REINPUT:
                        Edit(this);
                        break;
                    case GOPREV:
                        Edit(this);
                        break;
                }
            }
            else //리스트에 존재
            {
                bookList[listIndex] = print.BookEdit(bookList[listIndex], this);
                print.CompleteMsg("수량 수정 완료");
                ViewMenu();
            }
        }

        public void Delete()
        {
            while(true)
            {
                print.Menu("도서검색");
                menuSelect = CancelKey.ReadLineWithCancel();
                if (menuSelect == null) ViewMenu();
                if (errorCheck.Number(menuSelect, "5지선다") == false)
                {
                    break;
                }
                print.MenuErrorMsg("5지선다오류");
            }

            switch (int.Parse(menuSelect))
            {
                case SEARCH_BY_NAME:
                    listIndex = SearchByName();
                    break;

                case SEARCH_BY_PUBLISHER:
                    listIndex = SearchByPublisher();
                    break;

                case SEARCH_BY_AUTHOR:
                    listIndex = SearchByAuthor();
                    break;

                case PREV:
                    ViewMenu();
                    break;

                case SHUT_DOWN:
                    Environment.Exit(0);
                    break;
            }

            if (listIndex == NO_BOOK)
            {
                print.ErrorMsg("존재하지않는도서");
                menuSelect = CancelKey.ReadLineWithCancel();
                if (menuSelect == null) Delete();
                switch (int.Parse(menuSelect))
                {
                    case REINPUT:
                        Delete();
                        break;
                    case GOPREV:
                        ViewMenu();
                        break;
                }
            }
            else //리스트에 존재
            {
                string confirm;
                while(true)
                {
                    print.BookDelete(bookList[listIndex]);
                    confirm = CancelKey.ReadLineWithCancel();
                    if (confirm == null) Delete();
                    if (errorCheck.Confirm(confirm) == false)
                    {
                        break;
                    }
                    print.MenuErrorMsg("Y/N오류");
                }
                
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
            }
        }

        public void Search()
        {
            while(true)
            {
                print.Menu("도서검색");
                menuSelect = CancelKey.ReadLineWithCancel();
                if (menuSelect == null) ViewMenu();
                if (errorCheck.Number(menuSelect, "5지선다") == false)
                {
                    break;
                }
                print.MenuErrorMsg("5지선다오류");
            }
            switch (int.Parse(menuSelect))
            {
                case SEARCH_BY_NAME:
                    SearchByName();
                    break;

                case SEARCH_BY_PUBLISHER:
                    SearchByPublisher();
                    break;

                case SEARCH_BY_AUTHOR:
                    SearchByAuthor();
                    break;

                case PREV:
                    ViewMenu();
                    break;

                case SHUT_DOWN:
                    Environment.Exit(0);
                    break;
            }

            if (listIndex == NO_BOOK)
            {
                while(true)
                {
                    print.ErrorMsg("존재하지않는도서");
                    menuSelect = CancelKey.ReadLineWithCancel();
                    if (menuSelect == null) Search();
                    if (errorCheck.Number(menuSelect,"선택") == false)
                    {
                        break;
                    }
                    print.MenuErrorMsg("2지선다오류");
                }
               
                switch (int.Parse(menuSelect))
                {
                    case REINPUT:
                        Search();
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

        public int SearchByName()
        {
            print.Search("도서명");
            input = CancelKey.ReadLineWithCancel();
            if (input == null) ViewMenu(); //시간나면
            listIndex = bookList.FindIndex(book => book.BookName.Equals(input));
            return listIndex;
        }

        public int SearchByPublisher()
        {
            print.Search("출판사");
            input = CancelKey.ReadLineWithCancel();
            if (input == null) ViewMenu(); //시간나면 타입별 받앙서
            listIndex = bookList.FindIndex(book => book.Publisher.Equals(input));
            return listIndex;
        }

        public int SearchByAuthor()
        {
            print.Search("저자");
            input = CancelKey.ReadLineWithCancel();
            if (input == null) ViewMenu(); //이것도
            listIndex = bookList.FindIndex(book => book.Author.Equals(input));
            return listIndex;
        }

        public void PrintBookList()
        {
            print.AllBook(bookList);
            ViewMenu();
        }
    }
}
