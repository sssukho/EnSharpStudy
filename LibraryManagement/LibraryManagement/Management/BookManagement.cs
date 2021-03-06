﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace LibraryManagement
{
    /// <summary>
    /// 도서관리 기능을 담당하는 클래스 (유저 및 관리자 모두 사용)
    /// 1. 도서 등록
    /// 2. 도서 정보 수정
    /// 3. 도서 정보 삭제
    /// 4. 도서 일반 검색
    /// 5. 도서 명단 출력
    /// 6. 도서 대여 및 반납 기능
    /// 7. 도서 연장
    /// 8. 네이버 API 사용한 검색
    /// 9. 네이버 API 사용한 검색을 통한 도서 등록
    /// </summary>
    class BookManagement
    {
        Print print;
        ErrorCheck errorCheck;
        AdminMenu adminMenu;
        UserMenu userMenu;
        DAO dao;

        List<BookVO> bookList;
        string clientID = "GpbWEBciTaEoY0H5w4Ci";
        string clientSecret = "1OzWZ3NUCH";

        string logonID;
        MemberVO logOnMember;

        public BookManagement(AdminMenu adminMenu, DAO dao)
        {
            print = Print.GetInstance();
            errorCheck = ErrorCheck.GetInstance();
            this.adminMenu = adminMenu;
            bookList = new List<BookVO>();
            this.dao = dao;
        }

        public BookManagement(UserMenu userMenu, DAO dao, string logonID)
        {
            print = Print.GetInstance();
            errorCheck = ErrorCheck.GetInstance();
            this.userMenu = userMenu;
            this.dao = dao;
            bookList = new List<BookVO>();
            this.logonID = logonID;
            logOnMember = dao.Select(logonID);
        }

        public void RegisterBook()
        {
            BookVO newBook;
            newBook = print.RegisterBook();
            if (dao.IsBookDuplicated(newBook))
            {
                print.ErrorMsg("중복된 책");
                adminMenu.BookManagementMenu();
                return;
            }

            dao.Insert(newBook);
            adminMenu.BookManagementMenu();
        }

        public void NaverRegisterBook(List<BookVO> inputBookList, int bookIndex)
        {     
            BookVO foundBook = inputBookList.Find(book => book.Index.Equals(bookIndex));
            string registerCheck;

            while (true)
            {
                print.BookInfo(foundBook);
                print.YNcheck();
                registerCheck = Console.ReadLine();
                if (errorCheck.Confirm(registerCheck) == false)
                    break;

                print.FormErrorMsg("Y/N");
            }
            
            if(registerCheck.ToUpper().Equals("Y"))
            {
                if(dao.IsBookDuplicated(foundBook))
                {
                    print.ErrorMsg("중복된 책");
                    adminMenu.BookManagementMenu();
                    return;
                }
                dao.Insert(foundBook);
                dao.Insert("관리자", "도서등록", foundBook.Name, DateTime.Now);
                print.CompleteMsg("도서 등록 완료");
            }
            adminMenu.BookManagementMenu();
            return;
        }
    
        public void EditBook(string searchBy)
        {
            List<BookVO> foundBookList = SearchBook("editSearch", searchBy, "admin");
            if (foundBookList == null)
            {
                adminMenu.BookManagementMenu();
                return;
            }
            
            string bookIndex;
            while(true)
            {
                print.PrintBooks(foundBookList);
                print.Check("편집");
                bookIndex = Console.ReadLine();
                if (errorCheck.BookIndex(bookIndex) == false || bookIndex.ToUpper().Equals("Q"))
                {
                    if (bookIndex.ToUpper().Equals("Q"))
                    {
                        adminMenu.BookManagementMenu();
                        return;
                    }
                    break;
                }
                print.FormErrorMsg("고유번호");
            }

            //foundBookList에서의 bookVO 중에서 idx값이 bookIndex와 같은것.
            BookVO foundBook = foundBookList.Find(book => book.Index.Equals(int.Parse(bookIndex)));
            if(foundBook == null)
            {
                print.ErrorMsg("입력하신 고유번호와 일치하는 책 없음");
                adminMenu.BookManagementMenu();
                return;
            }

            int edittedCount = print.EditBook(foundBook);
            dao.Update("book", "count", edittedCount, "idx", int.Parse(bookIndex));
            dao.Insert("관리자", "도서편집", foundBook.Name, DateTime.Now);
            print.CompleteMsg("도서 정보 수정 완료");
            adminMenu.BookManagementMenu();
            return;
        }
        
        public void RemoveBook(string searchBy)
        {
            List<BookVO> foundBookList= SearchBook("removeSearch", searchBy, "admin");

            if (foundBookList == null)
            {
                adminMenu.BookManagementMenu();
                return;
            }

            string bookIndex;
            while (true)
            {
                print.PrintBooks(foundBookList);
                print.Check("삭제");
                bookIndex = Console.ReadLine();
                if (errorCheck.BookIndex(bookIndex) == false || bookIndex.ToUpper().Equals("Q"))
                {
                    if (bookIndex.ToUpper().Equals("Q"))
                    {
                        adminMenu.BookManagementMenu();
                        return;
                    }
                    break;
                }
                print.FormErrorMsg("고유번호");
            }

            dao.Delete("book", "idx", int.Parse(bookIndex));
            dao.Insert("관리자", "도서삭제", foundBookList.Find(book=>book.Index.Equals(int.Parse(bookIndex))).Name, DateTime.Now);
            print.CompleteMsg("도서 정보 삭제 완료");
            adminMenu.BookManagementMenu();
            return;
        }

        public List<BookVO> SearchBook(string searchType, string searchBy, string user)
        {
            string searchName;
            string searchAuthor;
            string searchPublisher;

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
                    if (user.Equals("admin"))
                        adminMenu.BookManagementMenu();
                    else
                        userMenu.MainMenu();
                }
                bookList = dao.SelectAll(bookList, searchBy, searchName); //db에 있는 인덱스값 그대로 불러옴
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
                    if (user.Equals("admin"))
                        adminMenu.BookManagementMenu();
                    else
                        userMenu.MainMenu();
                }

                bookList = dao.SelectAll(bookList, searchBy, searchPublisher);
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
                    if (user.Equals("admin"))
                        adminMenu.BookManagementMenu();
                    else
                        userMenu.MainMenu();
                }
                bookList = dao.SelectAll(bookList, searchBy, searchAuthor);
            }

            if (errorCheck.IsValidBook(bookList) == false) //검색 에러
            {
                print.ErrorMsg("입력한 도서 없음");
                if (searchType.Equals("justSearch"))
                {
                    if (user.Equals("admin"))
                        adminMenu.BookManagementMenu();
                    else
                        userMenu.BookSearchMenu();
                }
                return null;
            }
            
            if(searchType.Equals("justSearch"))
            {
                print.PrintBooks(bookList);
                print.PreviousCheck();
                if (user.Equals("admin"))
                    adminMenu.BookSearchMenu();
                else
                    userMenu.BookSearchMenu();
                return null;
            }
            return bookList;
        }

        public void PrintBooks(string userType)
        {
            print.PrintBooks(dao.SelectAll(bookList, "just", null));
            print.PreviousCheck();
            if (userType.Equals("admin"))
                adminMenu.BookManagementMenu();
            else
                userMenu.MainMenu();
        }

        public void RentBook(string searchBy)
        {
            ConsoleKeyInfo input;
            List<BookVO> foundList = SearchBook("rentBook", searchBy, "user");
            if (foundList == null)
            {
                userMenu.BookRentSearchMenu();
                return;
            }

            string indexInput;
            while (true)
            {
                print.PrintBooks(foundList);
                print.Check("대여");
                indexInput = Console.ReadLine();

                //입력 양식 및 q를 눌렀을때 혹은 찾은 bookList에 입력한 해당 고유번호가 존재할때만
                if (errorCheck.BookIndex(indexInput) == false || indexInput.ToUpper().Equals("Q"))
                {
                    if (indexInput.ToUpper().Equals("Q"))
                    {
                        adminMenu.BookManagementMenu();
                        return;
                    }

                    if (foundList.Find(book => book.Index.Equals(int.Parse(indexInput))) != null)
                        break;
                }

                //if (foundList.Find(book => book.Index.Equals(int.Parse(indexInput))) != null && errorCheck.BookIndex(indexInput) == false)
                  //  break;

                print.FormErrorMsg("고유번호");
            }

            BookVO foundBook = foundList.Find(book => book.Index.Equals(int.Parse(indexInput)));
            if (foundBook.Count == 0) //빌릴 책의 수량이 없는 경우
            {
                print.NotInStockMsg();
                userMenu.BookRentSearchMenu();
                return;
            }
            
            if (logOnMember.RentBook != "없음") //빌려간 책이 있는 경우
            {
                while (true)
                {
                    print.RentErrorMsg(logOnMember.Name, logOnMember.RentBook);
                    input = Console.ReadKey();
                    if (errorCheck.IsValidMenuInput(input, "선택") == false)
                        break;
                }

                if (input.KeyChar.ToString().Equals("1"))
                {
                    ReturnBook();
                    return;
                }
                userMenu.BookRentSearchMenu();
                return;
            }

            print.CheckRentBook(foundBook);
            while (true) //제대로 입력할때까지 반복
            {
                print.CheckRentBook(foundBook);
                input = Console.ReadKey();
                if (errorCheck.Confirm(input.KeyChar.ToString()) == false)
                    break;

                print.MenuErrorMsg("Y/N오류");
            }

            if (input.KeyChar.ToString().ToUpper().Equals("N")) //대여 안함
            {
                userMenu.BookRentSearchMenu();
                return;
            }

            //대여함
            dao.Update(foundBook, logonID);
            logOnMember.RentBook = foundBook.Name;
            logOnMember.DueDate = DateTime.Today.ToString().Remove(11);

            foundBook.Count = foundBook.Count - 1;

            dao.Update(foundBook);

            print.CompleteMsg("해당 도서 대여");
            dao.Insert(logOnMember.Name, "도서대여", foundBook.Name, DateTime.Now);
            userMenu.BookRentMenu();
            return;
        }

        public void ReturnBook()
        {
            ConsoleKeyInfo input;
            int bookCount;
            if (logOnMember.RentBook.Equals("없음"))
            {
                print.ErrorMsg("반납할 책이 없는");
                userMenu.BookRentMenu();
                return;
            }

            BookVO rentBook = dao.SelectBook(logOnMember.RentBook);
            print.CheckReturnBook(rentBook);

            while (true)
            {
                input = Console.ReadKey();
                if (errorCheck.Confirm(input.KeyChar.ToString()))
                {
                    print.MenuErrorMsg("Y/N오류");
                }
                break;
            }

            if (input.KeyChar.ToString().ToUpper().Equals("N"))
            {
                userMenu.BookRentMenu();
                return;
            }

            dao.Update(logOnMember.Id);

            bookCount = dao.SelectCount(logOnMember.RentBook);
            bookCount = bookCount + 1;

            dao.Update(bookCount, logOnMember.RentBook);

            logOnMember.RentBook = "없음";
            logOnMember.DueDate = "없음";
            logOnMember.ExtensionCount = 2;

            dao.Insert(logOnMember.Name, "도서반납", rentBook.Name, DateTime.Now);
            userMenu.BookRentMenu();
        }

        public void ExtensionBook()
        {
            string after1Week = DateTime.Today.AddDays(7).ToString().Remove(11);
            string after2Week = DateTime.Today.AddDays(14).ToString().Remove(11);

            if (logOnMember.ExtensionCount == 0)
            {
                print.ExtensionErrorMsg();
                userMenu.BookRentMenu();
                return;
            }

            if (logOnMember.RentBook.Equals("없음"))
            {
                print.NoExtensionErrorMsg();
                userMenu.BookRentMenu();
                return;
            }

            if (logOnMember.DueDate.Equals(DateTime.Today.ToString().Remove(11)))
            {
                dao.Update(after1Week, 1, logOnMember.Id, 1); 
                logOnMember.DueDate = after1Week;
                logOnMember.ExtensionCount = 1;
            }

            else if (logOnMember.DueDate.Equals(after1Week))
            {
                dao.Update(after2Week, 0, logOnMember.Id, 2); 
                logOnMember.DueDate = after2Week;
                logOnMember.ExtensionCount = 0;
            }

            print.CompleteMsg("연장");
            dao.Insert(logOnMember.Name, "대여연장", logOnMember.RentBook, DateTime.Now);
            userMenu.BookRentMenu();
        }

        public void SearchNaver()
        {
            string bookName;
            string searchCount;
            string indexInput;

            print.Search("네이버로 검색할 검색어(통합검색)");
            bookName = Console.ReadLine();
            print.InputBookCount();
            searchCount = Console.ReadLine();

            if (errorCheck.BookName(bookName))
            {
                print.FormErrorMsg("통합검색");
                adminMenu.BookManagementMenu();
            }

            bookList = ParsingJson(HttpRequest(bookName, int.Parse(searchCount)), bookList);

            while (true)
            {
                print.PrintBooks(bookList);
                print.Check("등록");
                indexInput = Console.ReadLine();
                if (errorCheck.BookIndex(indexInput) == false || indexInput.ToUpper().Equals("Q"))
                {
                    if (indexInput.ToUpper().Equals("Q"))
                    {
                        adminMenu.BookManagementMenu();
                        return;
                    }
                    break;
                }

                print.FormErrorMsg("고유번호");
            }

            dao.Insert("관리자", "네이버검색", bookName, DateTime.Now);
            while(true)
            {
                if (errorCheck.BookIndex(indexInput) == false || indexInput.ToUpper().Equals("Q"))
                {
                    if (indexInput.ToUpper().Equals("Q"))
                    {
                        adminMenu.BookManagementMenu();
                        return;
                    }
                    break;
                }
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

        public List<BookVO> ParsingJson(string json, List<BookVO> bookList)
        {
            bookList.Clear();
            JObject obj = JObject.Parse(json);
            JArray array = JArray.Parse(obj["items"].ToString()); //검색어와 일치하는 부분은 태그로 감싸져있음

            string title;
            string author;
            string price;
            string publisher;
            string pubdate;
            string isbn;
            string description;

            int i = 1;
            
            foreach (JObject item in array)
            {
                title = RemoveTag(item["title"].ToString());
                author = RemoveTag(item["author"].ToString());
                price = RemoveTag(item["price"].ToString());
                publisher = RemoveTag(item["publisher"].ToString());
                pubdate = RemoveTag(item["pubdate"].ToString());
                isbn = RemoveTag(item["isbn"].ToString());
                description = RemoveTag(item["description"].ToString());
                description = HttpUtility.HtmlDecode(description.Replace("'",""));
                
                BookVO newBook = new BookVO(i, title, author, price,publisher, pubdate, 5, isbn, description);

                bookList.Add(newBook);
                i = i + 1;
            }
            return bookList;
        }

        public string RemoveTag(string input)
        {
            string output;
            //get rid of HTML tags
            output = Regex.Replace(input, "<[^>]*>", string.Empty);
            //get rid of multiple blank lines
            output = Regex.Replace(output, @"^\s*$\n", string.Empty, System.Text.RegularExpressions.RegexOptions.Multiline);
            return output;
        }
    }
}
