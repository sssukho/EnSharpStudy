using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BookManage
{
    class BookRent
    {
        private const int RENT = 1;
        private const int RETURN = 2;
        private const int EXTENSION = 3;
        private const int PREVIOUS = 4;
        private const int EXIT = 5;

        private const int REINPUT = 1;
        private const int PREV = 2;

        private const int SEARCH_BY_NAME = 1;
        private const int SEARCH_BY_PUBLISHER = 2;
        private const int SEARCH_BY_AUTHOR = 3;
        private const int GOPREV = 4;
        private const int SHUT_DOWN = 5;

        private const int NO_BOOK = -1;
        Menu menu;
        List<Member> memberList;
        List<Book> bookList;
        Print print;
        ErrorCheck errorCheck;

        string menuSelect;
        int bookListIndex;
        int memberListIndex;
        string studentID;
        string input;

        public BookRent(Menu menu, List<Member> memberList, List<Book> bookList)
        {
            this.menu = menu;
            this.memberList = memberList;
            this.bookList = bookList;
            this.print = Print.GetInstance();
            this.errorCheck = ErrorCheck.GetInstance();
        }

        public void ViewMenu()
        {
            while (true)
            {
                print.Menu("도서대여");
                menuSelect = Console.ReadLine();
                if (errorCheck.Number(menuSelect, "4지선다") == false)
                {
                    break;
                }
                print.MenuErrorMsg("4지선다오류");
            }
            switch (int.Parse(menuSelect))
            {
                case RENT:
                    RentMenu();
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

        public void RentMenu()
        {
            print.Menu("대여검색");
            menuSelect = Console.ReadLine();

            switch (int.Parse(menuSelect))
            {
                case SEARCH_BY_NAME:
                    bookListIndex = SearchByName();
                    Rent(bookListIndex);
                    break;

                case SEARCH_BY_PUBLISHER:
                    bookListIndex = SearchByPublisher();
                    Rent(bookListIndex);
                    break;

                case SEARCH_BY_AUTHOR:
                    bookListIndex = SearchByAuthor();
                    Rent(bookListIndex);
                    break;

                case GOPREV:
                    ViewMenu();
                    break;

                case SHUT_DOWN:
                    Environment.Exit(0);
                    break;
            }
        }
        

        public void Rent(int bookListIndex)
        {
            if (bookListIndex == NO_BOOK)
            {
                while (true)
                {
                    print.ErrorMsg("존재하지않는도서");
                    menuSelect = Console.ReadLine();
                    if (errorCheck.TwoNumber(menuSelect) == false)
                    {
                        break;
                    }
                    print.MenuErrorMsg("2지선다");
                }
                switch (int.Parse(menuSelect))
                {
                    case REINPUT:
                        //다시 입력창으로 돌아가는 것
                        break;
                    case PREV:
                        RentMenu();
                        break;
                }
            }
            else //리스트에 존재
            {
                if (bookList[bookListIndex].Count == 0) //수량 없음
                {
                    while (true)
                    {
                        print.ErrorMsg("수량오류");
                        menuSelect = Console.ReadLine();
                        if (errorCheck.TwoNumber(menuSelect) == false)
                        {
                            break;
                        }
                        print.MenuErrorMsg("2지선다");
                    }
                    switch (int.Parse(menuSelect))
                    {
                        case REINPUT:
                            //다시 입력창으로 돌아가는 것
                            break;
                        case PREV:
                            RentMenu();
                            break;
                    }
                }
                else//빌릴사람 입력
                {
                    while (true)
                    {
                        print.InputIDMsg("책을 빌릴 회원");
                        studentID = Console.ReadLine();
                        if (errorCheck.MemberID(studentID) == false)
                        {
                            break;
                        }
                        print.RegisterErrorMsg("학번");
                    }

                    memberListIndex = memberList.FindIndex(member => member.StudentId.Equals(studentID));

                    if (memberListIndex == -1)
                    {

                    }

                    if (memberList[memberListIndex].RentBook != "") //해당 회원이 빌린 책이 있을 때                    
                    {
                        print.ErrorMsg("대여오류");
                        menuSelect = Console.ReadLine();
                        switch (int.Parse(menuSelect))
                        {
                            case REINPUT:
                                //다시 입력창으로 돌아가는 것
                                break;
                            case PREV:
                                RentMenu();
                                break;
                        }
                    }
                    else //정상적으로 해당 인원에게 책을 대출해줌. 책 카운트도 감소
                    {
                        bookList[bookListIndex].Count = bookList[bookListIndex].Count - 1;
                        memberList[memberListIndex].DueDate = "2018-04-23";
                        memberList[memberListIndex].RentBook = bookList[bookListIndex].BookName;

                        print.CompleteMsg("{0}에게 대출이 완료" + memberList[memberListIndex]);
                        ViewMenu();
                    }
                }
            }
        }

        public void Return()
        {
            string studentID;
            string confirm;
            print.InputIDMsg("책을 반납할 회원");
            studentID = Console.ReadLine();

            memberListIndex = memberList.FindIndex(member => member.StudentId.Equals(studentID));
            bookListIndex = bookList.FindIndex(book =>
            memberList[memberListIndex].RentBook.Equals(book.BookName));

            print.RetrunMsg(bookList[bookListIndex].BookName);
            confirm = Console.ReadLine();

            if (confirm == "Y" || confirm == "y")
            {
                memberList[memberListIndex].RentBook = "";
                memberList[memberListIndex].DueDate = "";
                bookList[bookListIndex].Count = bookList[bookListIndex].Count + 1;
                print.CompleteMsg("반납 완료");
                ViewMenu();
            }

            else if (confirm == "N" || confirm == "n")
            {
                Console.WriteLine("\t2초 후에 메뉴로 돌아갑니다...");
                Thread.Sleep(2000);
                ViewMenu();
            }

            else
            {
                //예외처리
            }
        }

        public void Extension()
        {
            string studentID;
            string confirm;
            print.InputIDMsg("책을 연장할 회원");
            studentID = Console.ReadLine();

            memberListIndex = memberList.FindIndex(member => member.StudentId.Equals(studentID));
            bookListIndex = bookList.FindIndex(book =>
            memberList[memberListIndex].RentBook.Equals(book.BookName));

            print.ExtensionMsg(bookList[bookListIndex].BookName);
            confirm = Console.ReadLine();

            if (confirm == "Y" || confirm == "y")
            {
                memberList[memberListIndex].DueDate = "2018-04-30";
                bookList[bookListIndex].Count = bookList[bookListIndex].Count + 1;
                print.CompleteMsg("연장 완료");
                ViewMenu();
            }

            else if (confirm == "N" || confirm == "n")
            {
                Console.WriteLine("\t2초 후에 메뉴로 돌아갑니다...");
                Thread.Sleep(2000);
                ViewMenu();
            }

            else
            {
                //예외처리
            }
        }

        public int SearchByName()
        {
            print.Search("도서명");
            input = Console.ReadLine();
            bookListIndex = bookList.FindIndex(book => book.BookName.Equals(input));
            return bookListIndex;
        }

        public int SearchByPublisher()
        {
            print.Search("출판사");
            input = Console.ReadLine();
            bookListIndex = bookList.FindIndex(book => book.Publisher.Equals(input));
            return bookListIndex;
        }

        public int SearchByAuthor()
        {
            print.Search("저자");
            input = Console.ReadLine();
            bookListIndex = bookList.FindIndex(book => book.Author.Equals(input));
            return bookListIndex;
        }
    }
}
