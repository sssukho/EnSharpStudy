using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class UserMenu
    {
        enum Usermenu { EXIT, RENT_EXTENSION, SEARCH_BOOK, PRINT_BOOKS }
        enum BookRent { EXIT, BOOK_RENT, RETURN_BOOK, EXTENSION_BOOK }
        enum SearchType { EXIT, SERARCH_BY_NAME, SEARCH_BY_PUBLISHER, SEARCH_BY_AUTHOR }

        DAO dao;
        Print print;
        ErrorCheck errorCheck;
        BookManagement bookManagement;
        string logonID;

        public UserMenu(DAO dao, string logonID)
        {
            this.dao = dao;
            this.print = Print.GetInstance();
            this.errorCheck = ErrorCheck.GetInstance();
            this.logonID = logonID;
            bookManagement = new BookManagement(this, dao, logonID);
            MainMenu();
        }
        
        ConsoleKeyInfo menuSelect;
        bool error;

        public void MainMenu()
        {
            MenuInput("사용자메인", "메인메뉴");

            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)Usermenu.RENT_EXTENSION:
                    BookRentMenu();
                    return;

                case (int)Usermenu.SEARCH_BOOK:
                    BookSearchMenu();
                    return;

                case (int)Usermenu.PRINT_BOOKS:
                    bookManagement.PrintBooks("user");
                    return;

                case (int)Usermenu.EXIT:
                    dao.CloseConnection();
                    Environment.Exit(0);
                    return;
            }
        }

        public void BookSearchMenu()
        {
            MenuInput("도서검색", "도서검색메뉴");
            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)SearchType.SERARCH_BY_NAME:
                    bookManagement.SearchBook("justSearch", "도서명", "user");
                    return;

                case (int)SearchType.SEARCH_BY_PUBLISHER:
                    bookManagement.SearchBook("justSearch", "출판사명", "user");
                    return;

                case (int)SearchType.SEARCH_BY_AUTHOR:
                    bookManagement.SearchBook("justSearch", "저자명", "user");
                    return;

                case (int)SearchType.EXIT:
                    Environment.Exit(0);
                    return;
            }
        }

        public void BookRentMenu()
        {
            MenuInput("도서대여", "도서대여메뉴");
            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)BookRent.BOOK_RENT:
                    BookRentSearchMenu();
                    return;

                case (int)BookRent.RETURN_BOOK:
                    bookManagement.ReturnBook();
                    return;

                case (int)BookRent.EXTENSION_BOOK:
                    bookManagement.ExtensionBook();
                    return;

                case (int)BookRent.EXIT:
                    dao.CloseConnection();
                    Environment.Exit(0);
                    return;
            }
        }

        public void BookRentSearchMenu()
        {
            MenuInput("대여검색", "도서대여검색메뉴");
            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)SearchType.SERARCH_BY_NAME:
                    bookManagement.RentBook("도서명");
                    return;

                case (int)SearchType.SEARCH_BY_PUBLISHER:
                    bookManagement.RentBook("출판사명");
                    return;

                case (int)SearchType.SEARCH_BY_AUTHOR:
                    bookManagement.RentBook("저자명");
                    return;

                case (int)SearchType.EXIT:
                    Environment.Exit(0);
                    return;
            }
        }

        public void MenuInput(string menuType, string errorCheckType)
        {
            print.Menu(menuType);
            menuSelect = Console.ReadKey();
            error = errorCheck.IsValidMenuInput(menuSelect, errorCheckType);
            if (menuSelect.Key == ConsoleKey.Escape)
                MainMenu();

            if (error == true)
            {
                print.MenuErrorMsg(errorCheckType); //오류 메시지

                switch (errorCheckType)
                {
                    case "메인메뉴":
                        MainMenu();
                        return;

                    case "도서대여메뉴":
                        BookRentMenu();
                        return;

                    case "도서검색메뉴":
                        BookSearchMenu();
                        return;

                    case "도서대여검색메뉴":
                        BookRentSearchMenu();
                        return;
                }
            }
        }
    }
}
