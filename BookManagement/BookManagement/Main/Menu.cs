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
    enum BookFindMenu { EXIT, SERARCH_BY_NAME, SEARCH_BY_PUBLISHER, SEARCH_BY_AUTHOR }

    class Menu
    {
        Print print;
        ErrorCheck errorCheck;

        ConsoleKeyInfo menuSelect;
        bool error;

        public Menu()
        {
            this.print = Print.GetInstance(); //Print객체가 있으면 생성하지 않고 없으면 생성하는 메소드
            this.errorCheck = ErrorCheck.GetInstance();
            MainMenu();
        }

        public Menu(string MemberID)
        {

        }

       

        public void MainMenu()
        {
            MenuInput("메인", "메인메뉴");

            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)InitialMenu.MEMBER_MANAGEMENT:
                    MemberManagementMenu();
                    break;

                case (int)InitialMenu.BOOK_MANAGEMENT:
                    BookManagementMenu();
                    break;

                case (int)InitialMenu.BOOK_RENT:
                    BookRentMenu();
                    break;

                case (int)InitialMenu.EXIT:
                    Environment.Exit(0);
                    break;
            }

        }

        public void MemberManagementMenu()
        {
            MenuInput("회원관리", "관리메뉴");

            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)MemberMenu.REGISTER_MEMBER:
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
            MenuInput("도서관리", "관리메뉴");
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
            MenuInput("도서수정", "검색메뉴");
            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)BookFindMenu.SERARCH_BY_NAME:
                    return;

                case (int)BookFindMenu.SEARCH_BY_PUBLISHER:
                    return;

                case (int)BookFindMenu.SEARCH_BY_AUTHOR:
                    return;

                case (int)BookFindMenu.EXIT:
                    Environment.Exit(0);
                    return;
            }
        }

        public void BookRemoveMenu()
        {
            MenuInput("도서삭제", "검색메뉴");
            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)BookFindMenu.SERARCH_BY_NAME:
                    return;

                case (int)BookFindMenu.SEARCH_BY_PUBLISHER:
                    return;

                case (int)BookFindMenu.SEARCH_BY_AUTHOR:
                    return;

                case (int)BookFindMenu.EXIT:
                    Environment.Exit(0);
                    return;
            }
        }

        public void BookSearchMenu()
        {
            MenuInput("도서검색", "검색메뉴");
            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)BookFindMenu.SERARCH_BY_NAME:
                    return;

                case (int)BookFindMenu.SEARCH_BY_PUBLISHER:
                    return;

                case (int)BookFindMenu.SEARCH_BY_AUTHOR:
                    return;

                case (int)BookFindMenu.EXIT:
                    Environment.Exit(0);
                    return;
            }
        }

        public void BookRentMenu()
        {
            MenuInput("도서대여", "검색메뉴");
            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)BookFindMenu.SERARCH_BY_NAME:
                    return;

                case (int)BookFindMenu.SEARCH_BY_PUBLISHER:
                    return;

                case (int)BookFindMenu.SEARCH_BY_AUTHOR:
                    return;

                case (int)BookFindMenu.EXIT:
                    Environment.Exit(0);
                    return;
            }
        }

        public void BookRentSearchMenu()
        {
            MenuInput("대여검색", "검색메뉴");
            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)BookFindMenu.SERARCH_BY_NAME:
                    return;

                case (int)BookFindMenu.SEARCH_BY_PUBLISHER:
                    return;

                case (int)BookFindMenu.SEARCH_BY_AUTHOR:
                    return;

                case (int)BookFindMenu.EXIT:
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

                    case "도서대여메뉴":
                        BookRentMenu();
                        return;
                }
            }
        }
    }
}
