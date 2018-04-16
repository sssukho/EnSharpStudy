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
                if (errorCheck.Number(menuSelect, "5지선다") == false)
                {
                    break;
                }
                print.MenuErrorMsg("5지선다오류");
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
            while(true)
            {
                print.Menu("대여검색");
                menuSelect = Console.ReadLine();
                if(errorCheck.Number(menuSelect, "5지선다") == false)
                {
                    break;
                }
                print.MenuErrorMsg("5지선다오류");
            }

            switch (int.Parse(menuSelect))
            {
                case SEARCH_BY_NAME:
                    bookListIndex = SearchByName();
                    ValidateCheckBook("byName");
                    break;

                case SEARCH_BY_PUBLISHER:
                    bookListIndex = SearchByPublisher();
                    //ValidateCheckBook(bookListIndex, "byPublisher");
                    break;

                case SEARCH_BY_AUTHOR:
                    bookListIndex = SearchByAuthor();
                    //ValidateCheckBook(bookListIndex, "byAuthor");
                    break;

                case GOPREV:
                    ViewMenu();
                    break;

                case SHUT_DOWN:
                    Environment.Exit(0);
                    break;
            }
        }

        public void ValidateCheckBook(string searchType)
        {
            if (bookListIndex == NO_BOOK)
            {
                while (true)
                {
                    print.ErrorMsg("존재하지않는도서");
                    menuSelect = Console.ReadLine();
                    if (errorCheck.Number(menuSelect,"선택") == false)
                    {
                        break;
                    }
                    print.MenuErrorMsg("2지선다");
                }

                switch (int.Parse(menuSelect))
                {
                    case REINPUT:
                        if (searchType == "byName") SearchByName();
                        if (searchType == "byPublisher") SearchByPublisher();
                        if (searchType == "byAuthor") SearchByAuthor();
                        break;
                    case PREV:
                        RentMenu();
                        break;
                }
            }
            Rent(bookListIndex, searchType);
        }

        public void Rent(int bookListIndex, string searchType)
        {
            //리스트에 존재
            if (bookList[bookListIndex].Count == 0) //수량 없음
            {
                print.CompleteMsg("수량이 소진");
                RentMenu();
            }
            else//수량이 있으면 빌릴 사람 입력
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

                if (memberListIndex == -1) //학번 검색했을때 등록되지 않은 회원이었을때
                {
                    while(true)
                    {
                        print.ErrorMsg("존재하지않는회원");
                        menuSelect = Console.ReadLine();
                        if (errorCheck.Number(menuSelect,"선택") == false)
                        {
                            break;
                        }
                        print.MenuErrorMsg("2지선다오류");
                    }
                    switch(int.Parse(menuSelect))
                    {
                        case REINPUT:
                            Rent(bookListIndex, searchType);
                            break;
                        case PREV:
                            RentMenu();
                            break;
                    }
                }

                if (memberList[memberListIndex].RentBook != "") //해당 회원이 빌린 책이 있을 때                    
                {
                    while (true)
                    {
                        print.ReturnErrorMsg();
                        menuSelect = Console.ReadLine();
                        if (errorCheck.Number(menuSelect, "선택") == false)
                        {
                            break;
                        }
                        print.MenuErrorMsg("2지선다오류");
                    }
                        switch (int.Parse(menuSelect))
                        {
                            case REINPUT:
                            Return();
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

        public void Return()
        {
            string studentID;
            string confirm;

            while(true)
            {
                print.InputIDMsg("책을 반납할 회원");
                studentID = Console.ReadLine();
                if(errorCheck.MemberID(studentID) == false)
                {
                    break;
                }
                print.RegisterErrorMsg("학번");
            }
            
            memberListIndex = memberList.FindIndex(member => member.StudentId.Equals(studentID));
            if(memberListIndex == -1) //입력받은 학번에 해당하는 회원 없을때
            {
                while(true)
                {
                    print.ErrorMsg("존재하지않는회원");
                    menuSelect = Console.ReadLine();
                    if(errorCheck.Number(menuSelect, "선택") == false)
                    {
                        break;
                    }
                    print.MenuErrorMsg("2지선다오류");
                }
                switch(int.Parse(menuSelect))
                {
                    case REINPUT:
                        Return();
                        break;
                    case PREV:
                        RentMenu();
                        break;
                }
            }

            
            bookListIndex = bookList.FindIndex(book =>
            memberList[memberListIndex].RentBook.Equals(book.BookName));

            while(true)
            {
                print.ReturnMsg(bookList[bookListIndex].BookName);
                confirm = Console.ReadLine();
                if(errorCheck.Confirm(confirm) == false)
                {
                    break;
                }
                print.MenuErrorMsg("Y/N오류");
            }

            if (confirm == "Y" || confirm == "y")
            {
                memberList[memberListIndex].RentBook = "";
                memberList[memberListIndex].DueDate = "";
                bookList[bookListIndex].Count = bookList[bookListIndex].Count + 1;
                print.CompleteMsg("반납 완료");
                RentMenu();
            }

            else if (confirm == "N" || confirm == "n")
            {
                Console.WriteLine("\t2초 후에 메뉴로 돌아갑니다...");
                Thread.Sleep(2000);
                ViewMenu();
            }
        }

        public void Extension()
        {
            string studentID;
            string confirm;

            while(true)
            {
                print.InputIDMsg("책을 연장할 회원");
                studentID = Console.ReadLine();
                if(errorCheck.MemberID(studentID) == false)
                {
                    break;
                }
                print.RegisterErrorMsg("학번");
            }
            
            memberListIndex = memberList.FindIndex(member => member.StudentId.Equals(studentID));
            if (memberListIndex == -1) //입력받은 학번에 해당하는 회원 없을때
            {
                while (true)
                {
                    print.ErrorMsg("존재하지않는회원");
                    menuSelect = Console.ReadLine();
                    if (errorCheck.Number(menuSelect, "선택") == false)
                    {
                        break;
                    }
                    print.MenuErrorMsg("2지선다오류");
                }
                switch (int.Parse(menuSelect))
                {
                    case REINPUT:
                        Extension();
                        break;
                    case PREV:
                        RentMenu();
                        break;
                }
            }
            bookListIndex = bookList.FindIndex(book =>
            memberList[memberListIndex].RentBook.Equals(book.BookName));

            while(true)
            {
                print.ExtensionMsg(bookList[bookListIndex].BookName);
                confirm = Console.ReadLine();
                if(errorCheck.Confirm(confirm) == false)
                {
                    break;
                }
                print.MenuErrorMsg("Y/N오류");
            }
            
            if (confirm == "Y" || confirm == "y")
            {
                memberList[memberListIndex].DueDate = "2018-04-30";
                bookList[bookListIndex].Count = bookList[bookListIndex].Count + 1;
                print.CompleteMsg("연장 완료");
                RentMenu();
            }

            else if (confirm == "N" || confirm == "n")
            {
                Console.WriteLine("\t2초 후에 메뉴로 돌아갑니다...");
                Thread.Sleep(2000);
                RentMenu();
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
