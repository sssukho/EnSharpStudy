using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    enum InitialMenu { EXIT, MEMBER_MANAGEMENT, BOOK_MANAGEMENT, BOOK_RENT }
    enum MemberMenu { EXIT, REGISTER_MEMBER, MODIFY_MEMBER, REMOVE_MEMBER, SEARCH_MEMBER, PRINT_MEMBERS }
    enum BookMenu { EXIT, REGISTER_BOOK, MODIFY_BOOK, REMOVE_BOOK, SEARCH_BOOK, PRINT_BOOKS }
    enum SearchType { EXIT, SERARCH_BY_NAME, SEARCH_BY_PUBLISHER, SEARCH_BY_AUTHOR }

    class Menu
    {
        Print print;
        ErrorCheck errorCheck;
        Function function;
        Query query;

        ConsoleKeyInfo menuSelect;
        bool error;

        public Menu(Print print, Query query)
        {
            this.print = print;
            this.query = query;
            this.errorCheck = ErrorCheck.GetInstance();
            this.function = new Function(this, query);
            MainMenu();
        }

        public void MainMenu()
        {
            MenuInput("메인", "메인메뉴");

            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)InitialMenu.MEMBER_MANAGEMENT:
                    MemberManagementMenu();
                    return;

                case (int)InitialMenu.BOOK_MANAGEMENT:
                    BookManagementMenu();
                    return;

                case (int)InitialMenu.BOOK_RENT:
                    BookRentMenu();
                    return;

                case (int)InitialMenu.EXIT:
                    Environment.Exit(0);
                    return;
            }
        }

        public void MemberManagementMenu()
        {
            MenuInput("회원관리", "회원관리메뉴");

            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)MemberMenu.REGISTER_MEMBER:
                    function.RegisterMember();
                    return;

                case (int)MemberMenu.MODIFY_MEMBER:
                    return;

                case (int)MemberMenu.REMOVE_MEMBER:
                    return;

                case (int)MemberMenu.SEARCH_MEMBER:
                    return;

                case (int)MemberMenu.PRINT_MEMBERS:
                    return;

                case (int)MemberMenu.EXIT:
                    Environment.Exit(0);
                    return;
            }
        }

        public void BookManagementMenu()
        {
            MenuInput("도서관리", "도서관리메뉴");
            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)BookMenu.REGISTER_BOOK:
                    return;

                case (int)BookMenu.MODIFY_BOOK:
                    return;

                case (int)BookMenu.REMOVE_BOOK:
                    return;

                case (int)BookMenu.SEARCH_BOOK:
                    return;

                case (int)BookMenu.PRINT_BOOKS:
                    return;

                case (int)BookMenu.EXIT:
                    Environment.Exit(0);
                    return;
            }
        }

        public void BookModifyMenu()
        {
            MenuInput("도서수정", "도서수정검색메뉴");
            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)SearchType.SERARCH_BY_NAME:
                    return;

                case (int)SearchType.SEARCH_BY_PUBLISHER:
                    return;

                case (int)SearchType.SEARCH_BY_AUTHOR:
                    return;

                case (int)SearchType.EXIT:
                    Environment.Exit(0);
                    return;
            }
        }

        public void BookRemoveMenu()
        {
            MenuInput("도서삭제", "도서삭제검색메뉴");
            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)SearchType.SERARCH_BY_NAME:
                    return;

                case (int)SearchType.SEARCH_BY_PUBLISHER:
                    return;

                case (int)SearchType.SEARCH_BY_AUTHOR:
                    return;

                case (int)SearchType.EXIT:
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
                    return;

                case (int)SearchType.SEARCH_BY_PUBLISHER:
                    return;

                case (int)SearchType.SEARCH_BY_AUTHOR:
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
                case (int)SearchType.SERARCH_BY_NAME:
                    return;

                case (int)SearchType.SEARCH_BY_PUBLISHER:
                    return;

                case (int)SearchType.SEARCH_BY_AUTHOR:
                    return;

                case (int)SearchType.EXIT:
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
                    return;

                case (int)SearchType.SEARCH_BY_PUBLISHER:
                    return;

                case (int)SearchType.SEARCH_BY_AUTHOR:
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

                    case "회원관리메뉴":
                        MemberManagementMenu();
                        return;

                    case "도서관리메뉴":
                        BookManagementMenu();
                        return;

                    case "도서수정검색메뉴":
                        BookModifyMenu();
                        return;

                    case "도서삭제검색메뉴":
                        BookRemoveMenu();
                        return;

                    case "도서검색검색메뉴":
                        BookSearchMenu();
                        return;

                    case "도서대여메뉴":
                        BookRentMenu();
                        return;

                    case "도서대여검색메뉴":
                        BookRentSearchMenu();
                        return;
                }
            }
        }
    }
}
