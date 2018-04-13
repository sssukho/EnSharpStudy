using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManage
{ 
    class Menu
    {
    //this
        List<Member> memberList;
        List<Book> bookList;
        MemberManagement memberManagement;
        BookManagement bookManagement;
        BookRent bookRent;
        Print print;

        string menuSelect;

        public Menu()
        {
            this.memberList = new List<Member>();
            this.bookList = new List<Book>();
            this.memberManagement = new MemberManagement(this);

        }

        public void ViewMenu()
        {
            print.Menu("메인");
            menuSelect = Console.ReadLine();
        }

    }
}
