using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace LibraryManagement
{
    /// <summary>
    /// 도서관리 기능을 담당하는 클래스
    /// 1. 도서 등록
    /// 2. 도서 정보 수정
    /// 3. 도서 정보 삭제
    /// 4. 도서 일반 검색
    /// 5. 도서 명단 출력
    /// 6. 도서 대여 및 반납 기능
    /// 7. 도서 연장
    /// </summary>
    class BookManagement
    {
        Print print;
        ErrorCheck errorCheck;
        AdminMenu adminMenu;
        DAO dao;

        List<BookVO> bookList;
        string clientID = "GpbWEBciTaEoY0H5w4Ci";
        string clientSecret = "1OzWZ3NUCH";
        
        public BookManagement(AdminMenu adminMenu, DAO dao)
        {
            print = Print.GetInstance();
            errorCheck = ErrorCheck.GetInstance();
            this.adminMenu = adminMenu;
            bookList = new List<BookVO>();
            this.dao = dao;
        }

        public void RegisterBook()
        {
            BookVO newBook;
            newBook = print.RegisterBook();

            dao.Insert(newBook);
            adminMenu.BookManagementMenu();
        }

        public void NaverRegisterBook(List<BookVO> inputBookList, int bookIndex)
        {
            print.BookInfo(inputBookList[bookIndex]);
            string registerCheck = Console.ReadLine();

            if(registerCheck.ToUpper().Equals("Y"))
            {
                dao.Insert(inputBookList[bookIndex]);
                print.CompleteMsg("도서 등록 완료");
            }
            adminMenu.BookManagementMenu();
            return;
        }

    /*
        public void EditBook(string searchBy)
        {
            BookVO foundBook = SearchBook("editSearch", searchBy);
            if (foundBook == null)
            {
                menu.BookManagementMenu();
                return;
            }

            foundBook = print.EditBook(foundBook);

            sqlQuery = "update book set count ='" + foundBook.Count + "' where name='" + foundBook.Name + "';";
            SendQuery();
            dataReader.Read();

            if (errorCheck.IsValidChange(dataReader) == false) //편집 에러
            {
                CloseDB();
                print.ErrorMsg("도서 정보 수정");
                menu.BookManagementMenu();
                return;
            }

            CloseDB();
            print.CompleteMsg("도서 정보 수정 완료");
            menu.BookManagementMenu();
            return;
        }

        public void RemoveBook(string searchBy)
        {
            string confirm;

            BookVO foundBook = SearchBook("removeSearch", searchBy);
            print.RemoveBook(foundBook);

            if (foundBook == null)
            {
                menu.BookManagementMenu();
                return;
            }

            print.RemoveBook(foundBook);
            confirm = Console.ReadLine();

            if (errorCheck.Confirm(confirm))
            {
                print.MenuErrorMsg("Y/N오류");
                menu.BookManagementMenu();
            }

            sqlQuery = "delete from book where name ='" + foundBook.Name + "';";
            SendQuery();
            dataReader.Read();

            if (errorCheck.IsValidChange(dataReader) == false) //편집 에러
            {
                CloseDB();
                print.ErrorMsg("도서 정보 삭제");
                menu.BookManagementMenu();
                return;
            }

            CloseDB();
            print.CompleteMsg("도서 정보 삭제 완료");
            menu.BookManagementMenu();
            return;
        }*/

        public List<BookVO> SearchBook(string searchType, string searchBy)
        {
            string searchName;
            string searchAuthor;
            string searchPublisher;
            string indexInput;

            if (searchBy.Equals("도서명"))
            {
                switch (searchType)
                {
                    case "registerSearch":
                        print.Search("등록할 책 이름");
                        break;
                    case "editSearch":
                        print.Search("편집할 책 이름");
                        break;
                    case "removeSearch":
                        print.Search("삭제할 책 이름");
                        break;
                    case "justSearch":
                        print.Search("검색할 책 이름");
                        break;
                    case "rentBook":
                        print.Search("대여할 책 이름");
                        break;
                }
                searchName = Console.ReadLine();
                if (errorCheck.BookName(searchName))
                {
                    print.FormErrorMsg("도서제목");
                    adminMenu.BookManagementMenu();
                }

                bookList = dao.SelectAll(bookList, searchBy, searchName);
                print.PrintBooks(bookList);
            }

            else if (searchBy.Equals("출판사명"))
            {
                switch (searchType)
                {
                    case "editSearch":
                        print.Search("편집할 책 출판사명");
                        break;
                    case "removeSearch":
                        print.Search("삭제할 책의 출판사명");
                        break;
                    case "justSearch":
                        print.Search("검색할 책 출판사명");
                        break;
                    case "rentBook":
                        print.Search("대여할 책 출판사명");
                        break;
                }

                searchPublisher = Console.ReadLine();
                if (errorCheck.BookPublisher(searchPublisher))
                {
                    print.FormErrorMsg("출판사명");
                    adminMenu.BookManagementMenu();
                }

                bookList = dao.SelectAll(bookList, searchBy, searchPublisher);
                print.PrintBooks(bookList);
            }

            else if (searchBy.Equals("저자명"))
            {
                switch (searchType)
                {
                    case "editSearch":
                        print.Search("편집할 책 저자명");
                        break;
                    case "removeSearch":
                        print.Search("삭제할 책의 저자명");
                        break;
                    case "justSearch":
                        print.Search("검색할 책 저자명");
                        break;
                    case "rentBook":
                        print.Search("대여할 책 저자명");
                        break;
                }

                searchAuthor = Console.ReadLine();
                if (errorCheck.BookAuthor("저자명"))
                {
                    print.FormErrorMsg("저자명");
                    adminMenu.BookManagementMenu();
                }

                bookList = dao.SelectAll(bookList, searchBy, searchAuthor);
                print.PrintBooks(bookList);
            }

            if (errorCheck.IsValidBook(bookList) == false) //검색 에러
            {
                print.ErrorMsg("존재하는 도서 찾기");
                if (searchType.Equals("justSearch"))
                    adminMenu.BookManagementMenu();
                return null;
            }
            
            indexInput = Console.ReadLine(); //입력예외처리 할 것
            if(searchType.Equals("justSearch"))
            {
                print.PrintBooks(bookList);
                print.PreviousCheck();
                adminMenu.BookSearchMenu();
                return null;
            }
            return bookList;
        }

        public void PrintBooks()
        {
            print.PrintBooks(dao.SelectAll(bookList, "just", null));   
            adminMenu.BookManagementMenu();
        }

        /*
        public void RentBook(string searchBy)
        {
            ConsoleKeyInfo input;
            BookVO foundBook = SearchBook("rentBook", searchBy);
            if (dataReader == null)
            {
                menu.BookRentSearchMenu();
                return;
            }

            if (foundBook.Count == 0) //빌릴 책의 수량이 없는 경우
            {
                print.NotInStockMsg();
                menu.BookRentSearchMenu();
                return;
            }

            if (Login.logOnMember.RentBook != "없음") //빌려간 책이 있는 경우
            {
                while (true)
                {
                    print.RentErrorMsg(Login.logOnMember.Name, Login.logOnMember.RentBook);
                    input = Console.ReadKey();
                    if (errorCheck.IsValidMenuInput(input, "선택") == false)
                        break;
                }

                if (input.KeyChar.ToString().Equals("1"))
                {
                    ReturnBook();
                    return;
                }
                menu.BookRentSearchMenu();
                return;
            }

            print.CheckRentBook(foundBook);
            while (true) //제대로 입력할때까지 반복
            {
                input = Console.ReadKey();
                if (errorCheck.Confirm(input.KeyChar.ToString()) == false)
                    break;

                print.MenuErrorMsg("Y/N오류");
            }

            if (input.KeyChar.ToString().Equals("N") || input.KeyChar.ToString().Equals("n")) //대여 안함
            {
                menu.BookRentSearchMenu();
                return;
            }

            //대여함
            sqlQuery = "update member set rentbook ='" + foundBook.Name + "', duedate ='" + "2018-05-11" + "' where id='" + Login.logOnMember.Id + "';";
            SendQuery();
            Login.logOnMember.RentBook = foundBook.Name;
            Login.logOnMember.DueDate = "2018-05-11";

            if (errorCheck.IsValidChange(dataReader) == false)
            {
                CloseDB();
                print.ErrorMsg("대여");
                menu.BookRentSearchMenu();
                return;
            }
            CloseDB();

            foundBook.Count = foundBook.Count - 1;

            sqlQuery = "update book set count ='" + foundBook.Count + "' where name='" + foundBook.Name + "';";
            SendQuery();

            if (errorCheck.IsValidChange(dataReader) == false)
            {
                CloseDB();
                print.ErrorMsg("도서 수량 정보 갱신");
                menu.BookRentSearchMenu();
                return;
            }

            CloseDB();
            print.CompleteMsg("해당 도서 대여");
            menu.BookRentMenu();
            return;
        }

        public void ReturnBook()
        {
            ConsoleKeyInfo input;
            int bookCount;
            if (Login.logOnMember.RentBook.Equals("없음"))
            {
                print.ErrorMsg("반납할 책이 없는");
                menu.BookRentMenu();
                return;
            }

            sqlQuery = "select * from book where name = '" + Login.logOnMember.RentBook + "';";
            SendQuery();
            dataReader.Read();
            print.CheckReturnBook(dataReader);
            CloseDB();

            while (true)
            {
                input = Console.ReadKey();
                if (errorCheck.Confirm(input.KeyChar.ToString()))
                {
                    print.MenuErrorMsg("Y/N오류");
                }
                break;
            }

            if (input.KeyChar.ToString().Equals("n") || input.KeyChar.ToString().Equals("N"))
            {
                menu.BookRentMenu();
                return;
            }

            sqlQuery = "update member set rentbook = '없음', duedate = '없음', extensionCount = 2 where id='" + Login.logOnMember.Id + "';";
            SendQuery();

            if (errorCheck.IsValidChange(dataReader) == false)
            {
                CloseDB();
                print.ErrorMsg("회원 정보 갱신");
                menu.BookRentMenu();
                return;
            }
            CloseDB();

            sqlQuery = "select count from book where name='" + Login.logOnMember.RentBook + "';";
            SendQuery();
            dataReader.Read();
            bookCount = int.Parse(dataReader["count"].ToString());
            CloseDB();

            bookCount = bookCount + 1;

            sqlQuery = "update book set count=" + bookCount + " where name='" + Login.logOnMember.RentBook + "';";
            SendQuery();
            CloseDB();

            Login.logOnMember.RentBook = "없음";
            Login.logOnMember.DueDate = "없음";
            Login.logOnMember.ExtensionCount = 2;

            menu.BookRentMenu();
        }

        public void ExtensionBook()
        {
            if (Login.logOnMember.ExtensionCount == 0)
            {
                print.ExtensionErrorMsg();
                menu.BookRentMenu();
                return;
            }

            if (Login.logOnMember.RentBook.Equals("없음"))
            {
                print.NoExtensionErrorMsg();
                menu.BookRentMenu();
                return;
            }

            if (Login.logOnMember.DueDate.Equals("2018-05-11"))
            {
                sqlQuery = "update member set duedate = '2018-05-18', extensionCount = 1 where id = '" + Login.logOnMember.Id + "';";
                Login.logOnMember.DueDate = "2018-05-18";
                Login.logOnMember.ExtensionCount = 1;
                SendQuery();
                CloseDB();
            }

            else if (Login.logOnMember.DueDate.Equals("2018-05-18"))
            {
                sqlQuery = "update member set duedate = '2018-05-25', extensionCount = 0 where id = '" + Login.logOnMember.Id + "';";
                Login.logOnMember.DueDate = "2018-05-25";
                Login.logOnMember.ExtensionCount = 0;
                SendQuery();
                CloseDB();
            }

            print.CompleteMsg("연장");
            menu.BookRentMenu();
        }*/

        public void SearchNaver()
        {
            string bookName;
            string searchCount;
            string indexInput;

            print.Search("네이버로 검색할 도서명");
            bookName = Console.ReadLine();
            print.InputBookCount();
            searchCount = Console.ReadLine();

            if (errorCheck.BookName(bookName))
            {
                print.FormErrorMsg("도서명");
                adminMenu.BookManagementMenu();
            }

            bookList = ParsingJson(HttpRequest(bookName, int.Parse(searchCount)), bookList);
            print.PrintBooks(bookList);
            print.RegisterCheck();
            indexInput = Console.ReadLine(); //입력예외처리 할 것
            if (indexInput.ToUpper().Equals("Q"))
            {
                adminMenu.BookManagementMenu();
                return;
            }

            NaverRegisterBook(bookList, int.Parse(indexInput));
        }

        public string HttpRequest(string searchWord, int count)
        {
            string url = string.Format("https://openapi.naver.com/v1/search/book.json"); // 결과가 JSON 포맷

            StringBuilder getParams = new StringBuilder();
            getParams.Append("?query=" + WebUtility.UrlEncode(searchWord) + "&display=" + count);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + getParams);
            request.Headers.Add("X-Naver-Client-Id", clientID); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", clientSecret);       // 클라이언트 시크릿

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();
            if (status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string text = reader.ReadToEnd();
                
                return text;
            }
            return null;
        }

        //json형태로 받아온 string 값을 썸네일의 URL을 파싱하여 리턴
        public List<BookVO> ParsingJson(string json, List<BookVO> bookList)
        {
            bookList.Clear();
            JObject obj = JObject.Parse(json);
            JArray array = JArray.Parse(obj["items"].ToString()); //검색어와 일치하는 부분은 태그로 감싸져있음

            int i = 1;
            
            foreach (JObject item in array)
            {
                BookVO newBook = new BookVO(i, item["title"].ToString(), item["author"].ToString(), item["price"].ToString(),
                    item["publisher"].ToString(), item["pubdate"].ToString(), 5, item["isbn"].ToString(), item["description"].ToString());

                bookList.Add(newBook);
                i = i + 1;
            }

            return bookList;
        }
    }
}
