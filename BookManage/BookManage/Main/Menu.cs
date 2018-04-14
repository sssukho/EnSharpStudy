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
        Print print;
        ErrorCheck errorCheck;

        string menuSelect;

        public Menu()
        {
            this.memberManagement = new MemberManagement(this);
            this.bookManagement = new BookManagement(this);
            this.bookRent = new BookRent(this);
            this.print = new Print(this);
        }

        public void ViewMenu()
        {
            print.Menu("메인");
            menuSelect = Console.ReadLine(); //에러쳌
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
