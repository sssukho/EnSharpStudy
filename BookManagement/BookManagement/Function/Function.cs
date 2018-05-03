using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BookManagement
{
    class Function
    {
        private const bool SUCCESS = true;
        private const bool FAILED = false;

        String databaseConnect;
        MySqlConnection connect;
        MySqlDataReader dataReader;
        MySqlCommand command;
        String sqlQuery;

        Print print;
        ErrorCheck errorCheck;
        Menu menu;

        public static MemberVO logOnMember;

        public Function() { }

        public Function(Menu menu)
        {
            print = Print.GetInstance();
            errorCheck = ErrorCheck.GetInstance();
            this.menu = menu;
        }

        public void OpenDB()
        {
            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL 
        }
        
        public void CloseDB()
        {
            dataReader.Close();
            connect.Close();
        }

        public bool IsAuthenticateLogin(string id, string password)
        {
            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL 

            sqlQuery = "select * from member where id='" + id + "' and password='" + password + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();
            dataReader.Read();

            string serverID = dataReader["id"].ToString();
            string serverPWD = dataReader["password"].ToString();

            if (serverID.Equals(id) && serverPWD.Equals(password))
            {
                SaveLogOnMember(dataReader);
                dataReader.Close();
                connect.Close();
                return true;
            }

            dataReader.Close();
            connect.Close();
            return false;
        }

        public void SaveLogOnMember(MySqlDataReader dataReader)
        {
            logOnMember = new MemberVO(dataReader["id"].ToString(), dataReader["password"].ToString(),
                   dataReader["name"].ToString(), dataReader["gender"].ToString(), dataReader["phoneNumber"].ToString(),
                   dataReader["email"].ToString(), dataReader["address"].ToString(), dataReader["rentbook"].ToString(), dataReader["duedate"].ToString(), 3);
        }

        public void RegisterMember()
        {
            MemberVO newMember;
            newMember = print.RegisterMember();

            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL 

            sqlQuery = "insert into member values('" + newMember.Id + "', '" + newMember.Password + "', '"
                + newMember.Name + "', '" + newMember.Gender + "', '" + newMember.PhoneNumber + "', '"
                + newMember.Email + "', '" + newMember.Address + "', '" + newMember.RentBook + "', '"
                + newMember.DueDate +"', '" + newMember.ExtensionCount + "');";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();

            if (errorCheck.IsValidChange(dataReader) == FAILED) //등록 에러
            {
                dataReader.Close();
                connect.Close();
                print.ErrorMsg("회원 등록");
                menu.MemberManagementMenu();
                return;
            }

            dataReader.Close();
            connect.Close();
            print.CompleteMsg("회원 등록 완료");
            menu.MemberManagementMenu();
            return;
        }

        public void EditMember()
        {
            MemberVO foundMember = SearchMember("editSearch");

            foundMember = print.EditMember(foundMember);
            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL

            sqlQuery = "update member set phoneNumber ='" + foundMember.PhoneNumber + "', address ='" + foundMember.Address + "' where id='" + foundMember.Id + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();

            if (errorCheck.IsValidChange(dataReader) == FAILED) //편집 에러
            {
                dataReader.Close();
                connect.Close();
                print.ErrorMsg("회원 정보 수정");
                menu.MemberManagementMenu();
                return;
            }

            dataReader.Close();
            connect.Close();
            print.CompleteMsg("회원 정보 수정 완료");
            menu.MemberManagementMenu();
            return;
        }

        public void RemoveMember()
        {
            string confirm;

            MemberVO foundMember = SearchMember("removeSearch");
            print.DeleteMember(foundMember);

            confirm = Console.ReadLine();
            if (errorCheck.Confirm(confirm))
            {
                print.MenuErrorMsg("Y/N오류");
                menu.MemberManagementMenu();
                return;
            }

            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL

            sqlQuery = "delete from member where id='" + foundMember.Id + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();

            if (errorCheck.IsValidChange(dataReader) == FAILED) //편집 에러
            {
                dataReader.Close();
                connect.Close();
                print.ErrorMsg("회원 삭제");
                menu.MemberManagementMenu();
                return;
            }

            dataReader.Close();
            connect.Close();
            print.CompleteMsg("회원 삭제 완료");
            menu.MemberManagementMenu();
            return;
        }

        public MemberVO SearchMember(string searchType)
        {
            string searchID;

            switch (searchType)
            {
                case "editSearch":
                    print.Search("정보를 편집할 회원의 아이디");
                    break;
                case "removeSearch":
                    print.Search("삭제할 회원의 아이디");
                    break;
                case "justSearch":
                    print.Search("검색할 회원의 아이디");
                    break;
            }

            searchID = Console.ReadLine();

            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL

            sqlQuery = "select * from member where id='" + searchID + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();
            dataReader.Read();

            if (errorCheck.IsValidMember(dataReader) == FAILED) //검색 에러
            {
                dataReader.Close();
                connect.Close();
                print.ErrorMsg("존재하는 회원 찾기");
                if (searchType.Equals("justSearch")) menu.MemberManagementMenu();
                return null;
            }

            MemberVO foundMember = new MemberVO(dataReader["id"].ToString(), dataReader["password"].ToString(),
                    dataReader["name"].ToString(), dataReader["gender"].ToString(), dataReader["phoneNumber"].ToString(),
                    dataReader["email"].ToString(), dataReader["address"].ToString(), dataReader["rentbook"].ToString(), dataReader["duedate"].ToString(), 3);

            if (searchType.Equals("justSearch"))
            {
                print.MemberInfo(foundMember);
                menu.MemberManagementMenu();
            }

            dataReader.Close();
            connect.Close();

            return foundMember;
        }

        public void PrintMembers()
        {
            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL

            sqlQuery = "select * from member;";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();

            print.PrintMembers(dataReader);
            dataReader.Close();
            connect.Close();
            menu.MemberManagementMenu();
        }

        public void RegisterBook()
        {
            BookVO newBook;
            newBook = print.RegisterBook();

            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL 

            sqlQuery = "insert into book values('" + newBook.Name + "', '" + newBook.Author + "', '"
                + newBook.Publisher + "', " + newBook.Count + ");";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();

            if (errorCheck.IsValidChange(dataReader) == FAILED) //등록 에러
            {
                dataReader.Close();
                connect.Close();
                print.ErrorMsg("도서 등록");
                menu.BookManagementMenu();
                return;
            }

            dataReader.Close();
            connect.Close();
            print.CompleteMsg("도서 등록 완료");
            menu.BookManagementMenu();
            return;
        }

        public void EditBook(string searchBy)
        {
            BookVO foundBook = SearchBook("editSearch", searchBy);
            if (foundBook == null)
            {
                menu.BookManagementMenu();
                return;
            }

            foundBook = print.EditBook(foundBook);

            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL

            sqlQuery = "update book set count ='" + foundBook.Count + "' where name='" + foundBook.Name + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();

            if (errorCheck.IsValidChange(dataReader) == FAILED) //편집 에러
            {
                dataReader.Close();
                connect.Close();
                print.ErrorMsg("도서 정보 수정");
                menu.BookManagementMenu();
                return;
            }

            dataReader.Close();
            connect.Close();
            print.CompleteMsg("도서 정보 수정 완료");
            menu.BookManagementMenu();
            return;
        }

        public void RemoveBook(string searchBy)
        {
            string confirm;

            BookVO foundBook = SearchBook("removeSearch", searchBy);
            if(foundBook == null)
            {
                menu.BookManagementMenu();
                return;
            }
            print.RemoveBook(foundBook);
            confirm = Console.ReadLine();
            if(errorCheck.Confirm(confirm))
            {
                print.MenuErrorMsg("Y/N오류");
                menu.BookManagementMenu();
            }

            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL

            sqlQuery = "delete from book where name ='" + foundBook.Name + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();

            if (errorCheck.IsValidChange(dataReader) == FAILED) //편집 에러
            {
                dataReader.Close();
                connect.Close();
                print.ErrorMsg("도서 정보 삭제");
                menu.BookManagementMenu();
                return;
            }

            dataReader.Close();
            connect.Close();
            print.CompleteMsg("도서 정보 삭제 완료");
            menu.BookManagementMenu();
            return;
        }

        public BookVO SearchBook(string searchType, string searchBy)
        {
            string searchName;
            string searchAuthor;
            string searchPublisher;

            if (searchBy.Equals("도서명"))
            {
                switch (searchType)
                {
                    case "editSearch":
                        print.Search("편집할 책 이름");
                        break;
                    case "removeSearch":
                        print.Search("삭제할 책의 이름");
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
                    menu.BookManagementMenu();
                }

                sqlQuery = "select * from book where name='" + searchName + "';";
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
                if(errorCheck.BookPublisher(searchPublisher))
                {
                    print.FormErrorMsg("출판사명");
                    menu.BookManagementMenu();
                }

                sqlQuery = "select * from book where publisher='" + searchPublisher + "';";
            }

            else if (searchBy.Equals("저자명"))
            {
                switch(searchType)
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
                    menu.BookManagementMenu();
                }

                sqlQuery = "select * from book where author='" + searchAuthor + "';";
            }

            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL
            
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();
            dataReader.Read();

            if (errorCheck.IsValidMember(dataReader) == FAILED) //검색 에러
            {
                dataReader.Close();
                connect.Close();
                print.ErrorMsg("존재하는 도서 찾기");
                if (searchType.Equals("justSearch")) menu.BookManagementMenu();
                return null;
            }

            BookVO foundBook = new BookVO(dataReader["name"].ToString(), dataReader["author"].ToString(),
                    dataReader["publisher"].ToString(), int.Parse(dataReader["count"].ToString()));

            if (searchType.Equals("justSearch"))
            {
                print.BookInfo(foundBook);
                menu.BookSearchMenu();
            }

            dataReader.Close();
            connect.Close();

            return foundBook;
        }

        public void PrintBooks()
        {
            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL

            sqlQuery = "select * from book;";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();

            print.PrintBooks(dataReader);
            dataReader.Close();
            connect.Close();
            menu.BookManagementMenu();
        }

        public void RentBook(string searchBy)
        {
            ConsoleKeyInfo input;
            BookVO foundBook = SearchBook("rentBook", searchBy);
            if (foundBook == null)
            {
                menu.BookRentSearchMenu();
                return;
            }
           
            if(foundBook.Count == 0) //빌릴 책의 수량이 없는 경우
            {
                print.NotInStockMsg();
                menu.BookRentSearchMenu();
                return;
            }

            if(logOnMember.RentBook != "없음") //빌려간 책이 있는 경우
            {
                while(true)
                {
                    print.RentErrorMsg(logOnMember.Name, logOnMember.RentBook);
                    input = Console.ReadKey();
                    if (errorCheck.IsValidMenuInput(input, "선택") == FAILED)
                        break;
                }

                if(input.KeyChar.ToString().Equals("1"))
                {
                    ReturnBook();
                    return;
                }
                menu.BookRentSearchMenu();
                return;
            }

            print.CheckRentBook(foundBook);
            while(true) //제대로 입력할때까지 반복
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
            databaseConnect = "Server=localhost;Database=bookmanage;Uid=root;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL

            sqlQuery = "update member set rentbook ='" + foundBook.Name + "', duedate ='" + "2018-05-11" + "' where id='" + logOnMember.Id + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();
            dataReader.Read();
            logOnMember.RentBook = foundBook.Name;
            logOnMember.DueDate = "2089-05-11";

            if (errorCheck.IsValidChange(dataReader) == FAILED)
            {
                dataReader.Close();
                connect.Close();
                print.ErrorMsg("대여");
                menu.BookRentSearchMenu();
                return;
            }
            dataReader.Close();
            connect.Close();

            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL

            foundBook.Count = foundBook.Count - 1;
            sqlQuery = "update book set count ='" + foundBook.Count + "' where name='" + foundBook.Name + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();

            if(errorCheck.IsValidChange(dataReader) == FAILED)
            {
                dataReader.Close();
                connect.Close();
                print.ErrorMsg("도서 수량 정보 갱신");
                menu.BookRentSearchMenu();
                return;
            }

            dataReader.Close();
            connect.Close();
            print.CompleteMsg("해당 도서 대여");
            menu.BookRentMenu();
            return;
        }

        public void ReturnBook()
        {
            ConsoleKeyInfo input;
            if(logOnMember.RentBook.Equals("없음"))
            {
                print.ErrorMsg("반납할 책이 없는");
                menu.BookRentMenu();
                return;
            }
            OpenDB();
            sqlQuery = "select * from book where name = '" + logOnMember.RentBook + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();
            dataReader.Read();
            print.CheckReturnBook(dataReader);
            CloseDB();

            while(true)
            {
                input = Console.ReadKey();
                if (errorCheck.Confirm(input.KeyChar.ToString()))
                {
                    print.MenuErrorMsg("Y/N오류");
                }
                break;
            }

            if(input.KeyChar.ToString() == "n" || input.KeyChar.ToString() == "N")
            {
                menu.BookRentMenu();
                return;
            }
           
            OpenDB();
            sqlQuery = "update member set rentbook = '없음', duedate = '없음', extensionCount = 2 where id='" + logOnMember.Id + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();
        

            if (errorCheck.IsValidChange(dataReader) == FAILED) 
            {
                CloseDB();
                print.ErrorMsg("회원 정보 갱신");
                menu.BookRentMenu();
                return;
            }
            CloseDB();

            OpenDB();
            sqlQuery = "select count from book where name='" + logOnMember.RentBook + "';";
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();
            dataReader.Read();
            int bookCount = int.Parse(dataReader["count"].ToString());
            CloseDB();

            bookCount = bookCount + 1;

            OpenDB();
            sqlQuery = "update book set count=" + bookCount + "where name='" + logOnMember.RentBook + "';";
            command = new MySqlCommand(sqlQuery, connect);
            CloseDB();
            logOnMember.RentBook = "없음";
            logOnMember.DueDate = "없음";
            logOnMember.ExtensionCount = 2;

            menu.BookRentMenu();
        }

        public void ExtensionBook()
        {
            ConsoleKeyInfo input;

            if(logOnMember.ExtensionCount == 0)
            {
                print.ExtensionErrorMsg();
                menu.BookRentMenu();
                return;
            }

            if (logOnMember.RentBook.Equals("없음"))
            {
                print.NoExtensionErrorMsg();
                menu.BookRentMenu();
                return;
            }

            if(logOnMember.DueDate.Equals("2018-05-11"))
            {
                sqlQuery = "update member set duedate = '2018-05-18', extensionCount = 1 where id = '" + logOnMember.Id + "';";
                logOnMember.DueDate = "2018-05-18";
                logOnMember.ExtensionCount = 1;
                OpenDB();
                command = new MySqlCommand(sqlQuery, connect);
                dataReader = command.ExecuteReader();
                CloseDB();
            }

            else if(logOnMember.DueDate.Equals("2018-05-18"))
            {
                sqlQuery = "update member set duedate = '2018-05-25', extensionCount = 0 where id = '" + logOnMember.Id + "';";
                logOnMember.DueDate = "2018-05-25";
                logOnMember.ExtensionCount = 0;
                OpenDB();
                command = new MySqlCommand(sqlQuery, connect);
                dataReader = command.ExecuteReader();
                CloseDB();
            }

            print.CompleteMsg("연장");
            menu.BookRentMenu();
        }
    }
}
