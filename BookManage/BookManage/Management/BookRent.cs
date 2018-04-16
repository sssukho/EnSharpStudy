using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BookManage
{
    /// <BookRent클래스>
    ///  도서 대출 및 반납 그리고 반납연장 기능을 하는 클래스.
    ///  빌리는 도서와 빌리는 회원간에 데이터를 사용해야하기 때문에 bookList와 memberList 둘 다
    ///  생성자를 통해 가져옴.
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
        private const int NO_MEMBER = -1;

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
                menuSelect = CancelKey.ReadLineWithCancel(); //중간에 ESC키 받으면 menuSelect 값이 null이 되어
                if (menuSelect == null) menu.ViewMenu(); //이전 메뉴로 나감
                if (errorCheck.Number(menuSelect, "5지선다") == false) //입력받은 menuSelect의 오류값이 false면(오류없음) 반복문 나감
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
                menuSelect = CancelKey.ReadLineWithCancel();
                if (menuSelect == null) ViewMenu();
                if (errorCheck.Number(menuSelect, "5지선다") == false)
                {
                    break;
                }
                print.MenuErrorMsg("5지선다오류");
            }

            switch (int.Parse(menuSelect))
            {
                case SEARCH_BY_NAME:
                    bookListIndex = SearchByName(); //이름으로 검색
                    ValidateCheckBook("byName");
                    break;

                case SEARCH_BY_PUBLISHER:
                    bookListIndex = SearchByPublisher(); //출판사명으로 검색
                    ValidateCheckBook("byPublisher");
                    break;

                case SEARCH_BY_AUTHOR:
                    bookListIndex = SearchByAuthor(); //작가로 검색
                    ValidateCheckBook("byAuthor");
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
                    menuSelect = CancelKey.ReadLineWithCancel();
                    if (menuSelect == null) RentMenu();
                    if (errorCheck.Number(menuSelect,"선택") == false)
                    {
                        break;
                    }
                    print.MenuErrorMsg("2지선다");
                }

                switch (int.Parse(menuSelect))
                {
                    case REINPUT: //다시 입력 할 때 searchType 변수로 검색 방식 설정해주고 인자값으로 넘겨줌
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
            if (bookList[bookListIndex].Count == 0) //책 수량 없음
            {
                print.CompleteMsg("수량이 소진");
                RentMenu();
            }
            else//수량이 있으면 빌릴 사람 입력
            {
                while (true)
                {
                    print.InputIDMsg("책을 빌릴 회원");
                    studentID = CancelKey.ReadLineWithCancel();
                    if (studentID == null) RentMenu();
                    if (errorCheck.MemberID(studentID) == false)
                    {
                        break;
                    }
                    print.RegisterErrorMsg("학번");
                }

                memberListIndex = memberList.FindIndex(member => member.StudentId.Equals(studentID));

                if (memberListIndex == NO_MEMBER) //학번 검색했을때 등록되지 않은 회원이었을때
                {
                    while(true)
                    {
                        print.ErrorMsg("존재하지않는회원");
                        menuSelect = CancelKey.ReadLineWithCancel();
                        if (menuSelect == null) RentMenu();
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
                        menuSelect = CancelKey.ReadLineWithCancel();
                        if (menuSelect == null) Rent(bookListIndex, searchType);
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
                    bookList[bookListIndex].Count = bookList[bookListIndex].Count - 1; //책 카운트 감소
                    memberList[memberListIndex].DueDate = "2018-04-23"; //오늘부터 일주일 설정
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
                studentID = CancelKey.ReadLineWithCancel();
                if (studentID == null) ViewMenu();
                if (errorCheck.MemberID(studentID) == false)
                {
                    break;
                }
                print.RegisterErrorMsg("학번");
            }
            
            memberListIndex = memberList.FindIndex(member => member.StudentId.Equals(studentID)); //입력받은 학번과 일치하는 회원을 리스트에서 찾아서 인덱스를 반환
            if(memberListIndex == NO_MEMBER) //입력받은 학번에 해당하는 회원 없을때
            {
                while(true)
                {
                    print.ErrorMsg("존재하지않는회원");
                    menuSelect = CancelKey.ReadLineWithCancel();
                    if (menuSelect == null) Return(); //ESC키
                    if (errorCheck.Number(menuSelect, "선택") == false)
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
            bookListIndex = bookList.FindIndex(book => //검색한 학번의 회원이 존재하면 그 회원이 빌린 책과
            memberList[memberListIndex].RentBook.Equals(book.BookName)); //도서 리스트에 있는 책에서 값이 일치하는 인덱스를 반환

            while(true)
            {
                print.ReturnMsg(bookList[bookListIndex].BookName);
                confirm = CancelKey.ReadLineWithCancel();
                if (confirm == null) Return();
                if (errorCheck.Confirm(confirm) == false)
                {
                    break;
                }
                print.MenuErrorMsg("Y/N오류");
            }

            if (confirm == "Y" || confirm == "y")
            {
                memberList[memberListIndex].RentBook = ""; //책을 반납한 회원의 빌린 책명 없애줌
                memberList[memberListIndex].DueDate = ""; //책을 반납한 회원의 반납일 없애줌
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

        public void Extension() //반납 연장
        {
            string studentID;
            string confirm;

            while(true)
            {
                print.InputIDMsg("책을 연장할 회원");
                studentID = CancelKey.ReadLineWithCancel();
                if (studentID == null) ViewMenu();
                if (errorCheck.MemberID(studentID) == false)
                {
                    break;
                }
                print.RegisterErrorMsg("학번");
            }
            
            memberListIndex = memberList.FindIndex(member => member.StudentId.Equals(studentID)); //입력받은 학번에 해당하는 회원의 인덱스
            if (memberListIndex == NO_MEMBER) //입력받은 학번에 해당하는 회원 없을때
            {
                while (true)
                {
                    print.ErrorMsg("존재하지않는회원");
                    menuSelect = CancelKey.ReadLineWithCancel();
                    if (menuSelect == null) Extension();
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
                confirm = CancelKey.ReadLineWithCancel();
                if (confirm == null) ViewMenu();
                if (errorCheck.Confirm(confirm) == false)
                {
                    break;
                }
                print.MenuErrorMsg("Y/N오류");
            }
            
            if (confirm == "Y" || confirm == "y")
            {
                memberList[memberListIndex].DueDate = "2018-04-30"; //오늘 날짜로부터 연장
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
            input = CancelKey.ReadLineWithCancel();
            if (input == null) ViewMenu();
            bookListIndex = bookList.FindIndex(book => book.BookName.Equals(input));
            return bookListIndex; //bookList에서 입력받은 도서명 값과 일치하는 인덱스를 반환
        }

        public int SearchByPublisher()
        {
            print.Search("출판사");
            input = CancelKey.ReadLineWithCancel();
            if (input == null) ViewMenu();
            bookListIndex = bookList.FindIndex(book => book.Publisher.Equals(input));
            return bookListIndex; //bookList에서 입력받은 출판사명 값과 일치하는 인덱스 반환
        }

        public int SearchByAuthor()
        {
            print.Search("저자");
            input = CancelKey.ReadLineWithCancel();
            if (input == null) ViewMenu();
            bookListIndex = bookList.FindIndex(book => book.Author.Equals(input));
            return bookListIndex; //bookList에서 입력받은 저자명 값과 일치하는 인덱스 반환
        }
    }
}
