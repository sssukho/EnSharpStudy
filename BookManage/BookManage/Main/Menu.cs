using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManage
{ 
    class Menu
    {
        private const int MemberManagementMenu = 1;
        private const int BookManagementMenu = 2;
        private const int BookRentMenu = 3;
        private const int EXIT = 4;
        
        MemberManagement memberManagement;
        BookManagement bookManagement;
        BookRent bookRent;
        List<Book> bookList;
        List<Member> memberList;
        Print print;
        ErrorCheck errorCheck;

        string menuSelect;
        bool error;

        public Menu()
        {
            this.memberList = new List<Member>();
            this.bookList = new List<Book>();
            this.memberManagement = new MemberManagement(this, memberList);
            this.bookManagement = new BookManagement(this, bookList);
            this.bookRent = new BookRent(this, memberList, bookList);
            this.print = Print.GetInstance();
            this.errorCheck = ErrorCheck.GetInstance();
            new DataAdd(this.memberList, this.bookList);
        }

        public void ViewMenu()
        {
            print.Menu("메인");
            menuSelect = Console.ReadLine(); 
            error = errorCheck.Number(menuSelect, "4지선다");
            if(error == true)
            {
                print.MenuErrorMsg("4지선다오류");
                ViewMenu();
            }
            else
            {
                switch (int.Parse(menuSelect))
                {
                    case MemberManagementMenu:
                        memberManagement.ViewMenu();
                        break;

                    case BookManagementMenu:
                        bookManagement.ViewMenu();
                        break;

                    case BookRentMenu:
                        bookRent.ViewMenu();
                        break;

                    case EXIT:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}