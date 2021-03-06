﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    //메뉴 구성
    enum InitialMenu { EXIT, MEMBER_MANAGEMENT, BOOK_MANAGEMENT, BOOK_RENT }
    enum MemberMenu { EXIT, REGISTER_MEMBER, EDIT_MEMBER, REMOVE_MEMBER, SEARCH_MEMBER, PRINT_MEMBERS }
    enum BookMenu { EXIT, REGISTER_BOOK, EDIT_BOOK, REMOVE_BOOK, SEARCH_BOOK, PRINT_BOOKS }
    enum SearchType { EXIT, SERARCH_BY_NAME, SEARCH_BY_PUBLISHER, SEARCH_BY_AUTHOR }
    enum BookRent { EXIT, RENT_BOOK, RETURN_BOOK, EXTENSION_BOOK}

    class Menu
    {
        Print print;
        ErrorCheck errorCheck;
        MemberManagement memberManagement;
        BookManagement bookManagement;

        ConsoleKeyInfo menuSelect;
        bool error;

        public Menu(Print print)
        {
            this.print = print;
            this.errorCheck = ErrorCheck.GetInstance();
            memberManagement = new MemberManagement(this);
            bookManagement = new BookManagement(this);
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
                    memberManagement.RegisterMember();
                    return;

                case (int)MemberMenu.EDIT_MEMBER:
                    memberManagement.EditMember();
                    return;

                case (int)MemberMenu.REMOVE_MEMBER:
                    memberManagement.RemoveMember();
                    return;

                case (int)MemberMenu.SEARCH_MEMBER:
                    memberManagement.SearchMember("justSearch");
                    return;

                case (int)MemberMenu.PRINT_MEMBERS:
                    memberManagement.PrintMembers();
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
                    bookManagement.RegisterBook();
                    return;

                case (int)BookMenu.EDIT_BOOK:
                    BookEditMenu();
                    return;

                case (int)BookMenu.REMOVE_BOOK:
                    BookRemoveMenu();
                    return;

                case (int)BookMenu.SEARCH_BOOK:
                    BookSearchMenu();
                    return;

                case (int)BookMenu.PRINT_BOOKS:
                    bookManagement.PrintBooks();
                    return;

                case (int)BookMenu.EXIT:
                    Environment.Exit(0);
                    return;
            }
        }

        public void BookEditMenu()
        {
            MenuInput("도서수정", "도서수정검색메뉴");
            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)SearchType.SERARCH_BY_NAME:
                    bookManagement.EditBook("도서명");
                    return;

                case (int)SearchType.SEARCH_BY_PUBLISHER:
                    bookManagement.EditBook("출판사명");
                    return;

                case (int)SearchType.SEARCH_BY_AUTHOR:
                    bookManagement.EditBook("저자명");
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
                    bookManagement.RemoveBook("도서명");
                    return;

                case (int)SearchType.SEARCH_BY_PUBLISHER:
                    bookManagement.RemoveBook("출판사명");
                    return;

                case (int)SearchType.SEARCH_BY_AUTHOR:
                    bookManagement.RemoveBook("저자명");
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
                    bookManagement.SearchBook("justSearch", "도서명");
                    return;

                case (int)SearchType.SEARCH_BY_PUBLISHER:
                    bookManagement.SearchBook("justSearch", "출판사명");
                    return;

                case (int)SearchType.SEARCH_BY_AUTHOR:
                    bookManagement.SearchBook("justSearch", "저자명");
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
                case (int)BookRent.RENT_BOOK:
                    BookRentSearchMenu();
                    return;

                case (int)BookRent.RETURN_BOOK:
                    bookManagement.ReturnBook();
                    return;

                case (int)BookRent.EXTENSION_BOOK:
                    bookManagement.ExtensionBook();
                    return;

                case (int)BookRent.EXIT:
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

        //메뉴 입력에서 예외처리 한번에 처리하기 위한 메소드
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
                        BookEditMenu();
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
