using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManage
{
    class BookRent
    {
        private const int RENT = 1;
        private const int RETURN = 2;
        private const int EXTENSION = 3;
        private const int PREVIOUS = 4;
        private const int EXIT = 5;

        Menu menu;
        List<Member> memberList;
        List<Book> bookList;
        Print print;
        ErrorCheck errorCheck;

        int menuSelect;

        public BookRent(Menu menu)
        {
            this.menu = menu;
            this.print = new Print();
            this.errorCheck = new ErrorCheck();
        }

        public List<Member> MemberList
        {
            set { memberList = value; }
            get { return memberList; }
        }

        public List<Book> BookList
        {
            set { bookList = value; }
            get { return bookList; }
        }

        public void ViewMenu()
        {
            print.Menu("도서대여");
            menuSelect = int.Parse(Console.ReadLine());

            switch (menuSelect)
            {
                case RENT:
                    Rent();
                    break;

                case RETURN:
                    Return();
                    break;

                case EXTENSION:
                    Extension();
                    break;

                case PREVIOUS:
                    menu.ViewMenu();
                    break;
            }
        }

        public void Rent()
        {

        }

        public void Return()
        {

        }

        public void Extension()
        {

        }
    }
}
