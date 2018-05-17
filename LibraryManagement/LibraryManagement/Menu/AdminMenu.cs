using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    /// <summary>
    /// 관리자 전용 메뉴
    /// </summary>
    
    class AdminMenu
    {
        enum Adminmenu { EXIT, MEMBER_MANAGEMENT, BOOK_MANAGEMENT, DB_MANAGEMENT }
        enum MemberMenu { EXIT, REGISTER_MEMBER, EDIT_MEMBER, REMOVE_MEMBER, SEARCH_MEMBER, PRINT_MEMBERS }
        enum BookMenu { EXIT, REGISTER_BOOK, EDIT_BOOK, REMOVE_BOOK, SEARCH_BOOK, PRINT_BOOKS, SEARCH_NAVER }
        enum SearchType { EXIT, SERARCH_BY_NAME, SEARCH_BY_PUBLISHER, SEARCH_BY_AUTHOR }
        enum BookRent { EXIT, RENT_BOOK, RETURN_BOOK, EXTENSION_BOOK }
        enum DBMenu { EXIT, INIT_LOG, CHECK_LOG, SAVE_AS_TXT, DELTE_TXT}

        MemberManagement memberManagement;
        BookManagement bookManagement;
        DBManagement dbManagement;
        DAO dao;
        Print print;
        ErrorCheck errorCheck;

        public AdminMenu(DAO dao)
        {
            this.dao = dao;
            this.memberManagement = new MemberManagement(this, dao);
            this.bookManagement = new BookManagement(this, dao);
            this.dbManagement = new DBManagement(this, dao);
            print = Print.GetInstance();
            errorCheck = ErrorCheck.GetInstance();
            MainMenu();
        }

        ConsoleKeyInfo menuSelect;
        bool error;

        public void MainMenu()
        {
            MenuInput("관리자메인", "메인메뉴");

            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)Adminmenu.MEMBER_MANAGEMENT:
                    MemberManagementMenu();
                    return;

                case (int)Adminmenu.BOOK_MANAGEMENT:
                    BookManagementMenu();
                    return;

                case (int)Adminmenu.DB_MANAGEMENT:
                    DBManagementMenu();
                    return;

                case (int)Adminmenu.EXIT:
                    dao.CloseConnection();
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
                    dao.CloseConnection();
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
                    bookManagement.PrintBooks("admin");
                    return;

                case (int)BookMenu.SEARCH_NAVER:
                    bookManagement.SearchNaver();
                    return;

                case (int)BookMenu.EXIT:
                    dao.CloseConnection();
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
                    dao.CloseConnection();
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
                    bookManagement.SearchBook("justSearch", "도서명", "admin");
                    return;

                case (int)SearchType.SEARCH_BY_PUBLISHER:
                    bookManagement.SearchBook("justSearch", "출판사명", "admin");
                    return;

                case (int)SearchType.SEARCH_BY_AUTHOR:
                    bookManagement.SearchBook("justSearch", "저자명", "admin");
                    return;

                case (int)SearchType.EXIT:
                    dao.CloseConnection();
                    Environment.Exit(0);
                    return;
            }
        }

        public void DBManagementMenu()
        {
            MenuInput("DB관리", "DB관리메뉴");

            switch (int.Parse(menuSelect.KeyChar.ToString()))
            {
                case (int)DBMenu.INIT_LOG:
                    dbManagement.InitLog();
                    return;

                case (int)DBMenu.CHECK_LOG:
                    dbManagement.CheckLog();
                    return;

                case (int)DBMenu.SAVE_AS_TXT:
                    dbManagement.SaveLogFile();
                    return;

                case (int)DBMenu.DELTE_TXT:
                    dbManagement.RemoveLogFile();
                    return;

                case (int)DBMenu.EXIT:
                    dao.CloseConnection();
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
                    case "관리자메인메뉴":
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

                    case "DB관리메뉴":
                        DBManagementMenu();
                        return;
                }
            }
        }

        
    }
}
