﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;

namespace LibraryManagement
{
    class Print
    {
        private static Print print;
        ErrorCheck errorCheck;
        public Print()
        {
            errorCheck = ErrorCheck.GetInstance();
        }

        public static Print GetInstance()
        {
            if (print == null)
                print = new Print();

            return print;
        }

        public void LoginUI()
        {
            Console.SetWindowSize(35, 17);
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("||                              ||");
            Console.WriteLine("||                              ||");
            Console.WriteLine("||                              ||");
            Console.WriteLine("||                              ||");
            Console.WriteLine("||       도서관리프로그램       ||");
            Console.WriteLine("||                              ||");
            Console.WriteLine("||                              ||");
            Console.WriteLine("||                              ||");
            Console.WriteLine("||   (로그인하려면 엔터키...)   ||");
            Console.WriteLine("=================================");
            Console.ReadLine();
        }

        public void FormErrorMsg(string type) //등록 및 편집시 잘못 입력하면 뜨는 오류 메시지
        {
            Console.WriteLine("\n\n\t{0} 양식에 맞게 작성해주세요.", type);
            Thread.Sleep(1000);
            Console.Clear();
        }

        public void LoginError()
        {
            Console.WriteLine("아이디와 비밀번호가 맞지 않습니다.");
            Console.WriteLine("다시 입력하려면 엔터");
            Console.ReadLine();
        }

        public void Menu(string type)
        {
            Console.Clear();
            Console.SetWindowSize(110, 25);
            switch (type)
            {
                case "관리자메인":
                    AdminMainMenu();
                    break;
                case "사용자메인":
                    UserMainMenu();
                    break;
                case "회원관리":
                    MemberManagementMenu();
                    break;
                case "도서관리":
                    BookManagementMenu();
                    break;
                case "도서수정":
                    BookEditMenu();
                    break;
                case "도서삭제":
                    BookRemoveMenu();
                    break;
                case "도서검색":
                    BookSearchMenu();
                    break;
                case "도서대여":
                    BookRentalMenu();
                    break;
                case "대여검색":
                    BookRentalSearchMenu();
                    break;
                case "DB관리":
                    DBManagementMenu();
                    break;
            }
        }

        public void MenuErrorMsg(string type)
        {
            switch (type)
            {
                case "메인메뉴":
                    Console.Write("\n\n\t1 ~ 3과 0만");
                    break;
                case "검색메뉴":
                    Console.Write("\n\n\t1 ~ 3과 0만");
                    break;
                case "관리메뉴":
                    Console.Write("\n\n\t1 ~ 5와 0만");
                    break;
                case "Y/N오류":
                    Console.Write("\n\n\tY혹은 N으로만");
                    break;
            }
            Console.WriteLine(" 입력이 가능합니다.");
            Thread.Sleep(1000);
            Console.Clear();
        }

        public void AdminMainMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t----------------------------------------------------------------------------------------------");
            Console.WriteLine("\t|                                  회원 관리 메뉴 : 1번                                       |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  도서 관리 메뉴 : 2번                                       |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  DB 관리 메뉴   : 3번                                       |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
            Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");
            Console.Write("\n\t로그아웃 ESC");
            Console.Write("\n\t메뉴 번호 입력 : ");
        }

        public void UserMainMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t----------------------------------------------------------------------------------------------");
            Console.WriteLine("\t|                                  도서 대여/연장 메뉴 : 1번                                  |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  도서 검색 : 2번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  도서 명단 출력 : 3번                                       |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
            Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");
            Console.Write("\n\t로그아웃 ESC");
            Console.Write("\n\t메뉴 번호 입력 : ");
        }

        public void MemberManagementMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t----------------------------------------------------------------------------------------------");
            Console.WriteLine("\t|                                  회원 등록 : 1번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  회원 수정 : 2번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  회원 삭제 : 3번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  회원 검색 : 4번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  회원 명단 출력 : 5번                                       |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
            Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");
            Console.WriteLine("\n\t이전 메뉴로 돌아가려면 ESC");
            Console.Write("\n\t메뉴 번호 입력 : ");
        }

        public void BookManagementMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t----------------------------------------------------------------------------------------------");
            Console.WriteLine("\t|                                  도서 등록 : 1번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  도서 수정 : 2번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  도서 삭제 : 3번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  도서 검색 : 4번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  도서 명단 출력 : 5번                                       |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  네이버 도서 검색 : 6번                                      |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
            Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");
            Console.WriteLine("\n\t이전 메뉴로 돌아가려면 ESC");
            Console.Write("\n\t메뉴 번호 입력 : ");
        }

        public void BookEditMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t-------------------------------------수정할 도서 검색-----------------------------------------");
            Console.WriteLine("\t|                                  도서명으로 검색 : 1번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  출판사로 검색 : 2번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  저자로 검색 : 3번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
            Console.WriteLine("\t-----------------------------------------------------------------------------------------------\n");
            Console.WriteLine("\n\t이전 메뉴로 돌아가려면 ESC");
            Console.Write("\n\t메뉴 번호 입력 : ");
        }

        public void BookRemoveMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t-------------------------------------삭제할 도서 검색------------------------------------------");
            Console.WriteLine("\t|                                  도서명으로 검색 : 1번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  출판사로 검색 : 2번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  저자로 검색 : 3번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
            Console.WriteLine("\t-----------------------------------------------------------------------------------------------\n");
            Console.WriteLine("\n\t이전 메뉴로 돌아가려면 ESC");
            Console.Write("\n\t메뉴 번호 입력 : ");
        }

        public void BookSearchMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t----------------------------------------------------------------------------------------------");
            Console.WriteLine("\t|                                  도서명으로 검색 : 1번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  출판사로 검색 : 2번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  작가로 검색 : 3번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
            Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");
            Console.WriteLine("\n\t이전 메뉴로 돌아가려면 ESC");
            Console.Write("\n\t메뉴 번호 입력 : ");
        }

        public void BookRentalMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t----------------------------------------------------------------------------------------------");
            Console.WriteLine("\t|                                  도서 대여 : 1번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  도서 반납 : 2번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  도서 반납 연장 : 3번                                       |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
            Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");
            Console.WriteLine("\n\t이전 메뉴로 돌아가려면 ESC");
            Console.Write("\n\t메뉴 번호 입력 : ");
        }

        public void BookRentalSearchMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t-------------------------------------대여할 도서 검색------------------------------------------");
            Console.WriteLine("\t|                                  도서명으로 검색 : 1번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  출판사로 검색 : 2번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  작가로 검색 : 3번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
            Console.WriteLine("\t-----------------------------------------------------------------------------------------------\n");
            Console.WriteLine("\n\t이전 메뉴로 돌아가려면 ESC");
            Console.Write("\n\t메뉴 번호 입력 : ");
        }

        public void DBManagementMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t----------------------------------------------------------------------------------------------");
            Console.WriteLine("\t|                                  로그 초기화 : 1번                                          |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  로그 보기 : 2번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  바탕화면에 txt파일 저장 : 3번                              |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  바탕화면 txt 파일 삭제: 4번                                |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
            Console.WriteLine("\t-----------------------------------------------------------------------------------------------\n");
            Console.WriteLine("\n\t이전 메뉴로 돌아가려면 ESC");
            Console.Write("\n\t메뉴 번호 입력 : ");
        }

        public MemberVO RegisterMember() //while로 틀린 항목 다시 입력하게
        {
            string id, password, name, gender, phoneNumber, email, address;
            Console.Clear();
            while (true)
            {
                Console.Write("\n\n\t학번 입력 (6~8자리 이내) : ");
                id = Console.ReadLine();
                if (errorCheck.MemberID(id) == false)
                    break;

                FormErrorMsg("학번");
            }

            while (true)
            {
                Console.Write("\n\n\t비밀번호 입력 (숫자만 4자리) : ");
                password = Console.ReadLine();

                if (errorCheck.MemberPassword(password) == false)//미리 설정해둔 정규식에 맞으면 bool 타입 false 반환
                    break;

                FormErrorMsg("이름");
            }

            while (true)
            {
                Console.Write("\n\n\t이름 입력 (4자리 이내) : ");
                name = Console.ReadLine();

                if (errorCheck.MemberName(name) == false)//미리 설정해둔 정규식에 맞으면 bool 타입 false 반환
                    break;

                FormErrorMsg("이름");
            }

            while (true)
            {
                Console.Write("\n\n\t성별 입력 (남자/여자): ");
                gender = Console.ReadLine();
                if (errorCheck.MemberGender(gender) == false)
                    break;
                FormErrorMsg("성별");
            }

            while (true)
            {
                Console.Write("\n\n\t핸드폰 번호 입력(010-1234-5678 형식) : ");
                phoneNumber = Console.ReadLine();
                if (errorCheck.MemberPhone(phoneNumber) == false)
                    break;
                FormErrorMsg("핸드폰 번호");
            }

            while (true)
            {
                Console.Write("\n\n\t이메일 입력 : ");
                email = Console.ReadLine();

                if (errorCheck.MemberEmail(email) == false)
                    break;
                FormErrorMsg("이메일");
            }

            while (true)
            {
                Console.Write("\n\n\t주소 입력 : ");
                address = Console.ReadLine();
                if (errorCheck.MemberAddress(address) == false)
                    break;

                FormErrorMsg("주소");
            }

            MemberVO newMember = new MemberVO(id, password, name, gender, phoneNumber, email, address, "없음", "없음", 2);
            return newMember;
        }

        public void ErrorMsg(string type) //에러가 난곳에서 스트링 타입으로 인자를 받아서 어떤 에러인지 분류
        {
            Console.Clear();
            Console.WriteLine("\n\n\t{0} 오류입니다...", type);
            Console.WriteLine("\n\n\t이전 메뉴로 돌아가려면 엔터...");
            Console.ReadLine();
        }

        public void CompleteMsg(string type) //기능 에러없이 완료했을 경우
        {
            Console.WriteLine("\n\n\t{0} 되었습니다.", type);
            Console.WriteLine("\n\n\t이전 메뉴로 돌아가려면 엔터...");
            Console.ReadLine();
        }

        public MemberVO EditMember(MemberVO inputMember)
        {
            string phoneNumber, address;
            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------수정할 회원 기존 정보--------------------------------");
            Console.WriteLine("\n\t아이디 : {0}", inputMember.Id);
            Console.WriteLine("\t이름 : {0}", inputMember.Name);
            Console.WriteLine("\t성별 : {0}", inputMember.Gender);
            Console.WriteLine("\t핸드폰 번호 : {0}", inputMember.PhoneNumber);
            Console.WriteLine("\t이메일 주소 : {0}", inputMember.Email);
            Console.WriteLine("\t주소 : {0}", inputMember.Address + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");
            Console.WriteLine("\n\n\t---------------------------------수정할 회원 정보 입력--------------------------------");

            while (true)
            {
                Console.Write("\n\t핸드폰 번호 입력(010-1234-5678 형식) : ");
                phoneNumber = Console.ReadLine();
                if (errorCheck.MemberPhone(phoneNumber) == false)
                    break;

                FormErrorMsg("핸드폰 번호");
            }

            while (true)
            {
                Console.Write("\n\n\t주소 입력(동/리까지 입력) : ");
                address = Console.ReadLine();
                if (errorCheck.MemberAddress(address) == false)
                    break;

                FormErrorMsg("주소");
            }
            inputMember.PhoneNumber = phoneNumber;
            inputMember.Address = address;
            return inputMember;
        }

        public void DeleteMember(MemberVO inputMember)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------삭제할 회원 기존 정보--------------------------------");
            Console.WriteLine("\n\t아이디 : {0}", inputMember.Id);
            Console.WriteLine("\t이름 : {0}", inputMember.Name);
            Console.WriteLine("\t성별 : {0}", inputMember.Gender);
            Console.WriteLine("\t핸드폰 번호 : {0}", inputMember.PhoneNumber);
            Console.WriteLine("\t이메일 : {0}", inputMember.Email);
            Console.WriteLine("\t주소 : {0}", inputMember.Address + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");
            Console.Write("\n\n\t정말로 삭제하시겠습니까? (Y/N) : ");
        }

        public void PrintMembers(MySqlDataReader dataReader)
        {
            Console.SetWindowSize(185, 25);
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------회원 명단--------------------------------------------------------------");
            Console.WriteLine("아이디 |이름 |성별  |휴대폰번호          |이메일              |주소                |대출한책            |반납일              |연장 가능횟수    ");

            while (dataReader.Read())
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8}", dataReader["id"].ToString(), dataReader["name"].ToString(),
                    dataReader["gender"].ToString(), AdjustText(dataReader["phoneNumber"].ToString()), AdjustText(dataReader["email"].ToString()), 
                    AdjustText(dataReader["address"].ToString()), AdjustText(dataReader["rentbook"].ToString()), AdjustText(dataReader["duedate"].ToString()),
                    dataReader["extensionCount"].ToString());
            }
            dataReader.Close();
            Console.WriteLine("\n\n\t이전 메뉴로 돌아가려면 엔터...");
            Console.ReadLine();
        }
        
        public BookVO RegisterBook()
        {
            string name;
            string author;
            string publisher;
            string price;
            string publishDate;
            string count;
            string isbn;
            string description;

            Console.Clear();
            while (true)
            {
                Console.Write("\n\n\t도서 제목 입력(16자이내) : ");
                name = Console.ReadLine();
                if (errorCheck.BookName(name) == false)
                    break;

                FormErrorMsg("도서제목");
            }

            while (true)
            {
                Console.Write("\n\n\t저자 입력(10자이내) : ");
                author = Console.ReadLine();
                if (errorCheck.BookAuthor(author) == false)
                    break;

                FormErrorMsg("저자");
            }

            while(true)
            {
                Console.Write("\n\n\t도서 가격 입력(숫자만) : ");
                price = Console.ReadLine();
                if (errorCheck.BookPrice(price) == false)
                    break;

                FormErrorMsg("가격");
            }

            while (true)
            {
                Console.Write("\n\n\t출판일자(yyyymmdd) : ");
                publishDate = Console.ReadLine();
                if (errorCheck.BookPublishDate(publishDate) == false) //정규식 고칠것
                    break;

                FormErrorMsg("출판일자");
            }

            while (true)
            {
                Console.Write("\n\n\t출판사 입력(8자이내) : ");
                publisher = Console.ReadLine();
                if (errorCheck.BookName(publisher) == false)
                    break;

                FormErrorMsg("출판사명");
            }

            while (true)
            {
                Console.Write("\n\n\t수량 입력(숫자만 입력) : ");
                count = Console.ReadLine();
                if (errorCheck.BookCount(count) == false)
                    break;

                FormErrorMsg("수량");
            }


            Console.Write("\n\n\tISBN을 입력해주세요(양식: 1234567890 1234567890123) : ");
            isbn = Console.ReadLine();

            FormErrorMsg("ISBN");

            Console.Write("\n\n\t줄거리를 입력해주세요 : ");
            description = Console.ReadLine();

            FormErrorMsg("줄거리");

            BookVO newBook = new BookVO(0, name, author, price, publisher, publishDate, int.Parse(count), isbn, description);

            return newBook;
        }

        public void MemberInfo(MemberVO inputMember)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------검색한 회원 기존 정보--------------------------------");
            Console.WriteLine("\n\t아이디 : {0}", inputMember.Id);
            Console.WriteLine("\t학번 : {0}", inputMember.Name);
            Console.WriteLine("\t성별 : {0}", inputMember.Gender);
            Console.WriteLine("\t핸드폰 번호 : {0}", inputMember.PhoneNumber);
            Console.WriteLine("\t주소 : {0}", inputMember.Address);
            Console.WriteLine("\t현재 대출한 책 : {0}", inputMember.RentBook);
            Console.WriteLine("\t반납 예정일 : {0}", inputMember.DueDate + "\n");
            Console.WriteLine("\t연장 가능횟수 : {0}", inputMember.ExtensionCount + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.Write("\n\n\t이전으로 돌아가려면 엔터...");
            Console.ReadLine();
        }

        public int EditBook(BookVO inputBook)
        {
            string count;
            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------수정할 도서 기존 정보--------------------------------");
            Console.WriteLine("\t도서 제목 : {0}", inputBook.Name);
            Console.WriteLine("\t출판사 : {0}", inputBook.Publisher);
            Console.WriteLine("\t저자 : {0}", inputBook.Author);
            Console.WriteLine("\t수량 : {0}", inputBook.Count);
            Console.WriteLine("\t가격 : {0}", inputBook.Price);
            Console.WriteLine("\t출판 일자 : {0}", inputBook.PublishDate + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.WriteLine("\n\n\t---------------------------------수정할 도서 수량 입력--------------------------------");
            while (true)
            {
                Console.Write("\n\t수량을 입력해주세요 : ");
                count = Console.ReadLine();
                if (errorCheck.BookCount(count) == false)
                    break;

                FormErrorMsg("수량");
            }
            inputBook.Count = int.Parse(count);
            return inputBook.Count;
        }

        public void RemoveBook(BookVO inputBook)
        {
            Console.Clear();

            Console.WriteLine("\n\n\t---------------------------------삭제할 도서 기존 정보--------------------------------");
            Console.WriteLine("\t도서 제목 : {0}", inputBook.Name);
            Console.WriteLine("\t출판사 : {0}", inputBook.Publisher);
            Console.WriteLine("\t저자 : {0}", inputBook.Author);
            Console.WriteLine("\t수량 : {0}", inputBook.Count);
            Console.WriteLine("\t가격 : {0}", inputBook.Price);
            Console.WriteLine("\t출판 일자 : {0}", inputBook.PublishDate + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");
        }

        public void BookInfo(BookVO inputBook)
        {
            Console.Clear();

            Console.WriteLine("\n\n\t---------------------------------검색한 도서 정보--------------------------------");
            Console.WriteLine("\t도서 제목 : {0}", inputBook.Name);
            Console.WriteLine("\t출판사 : {0}", inputBook.Publisher);
            Console.WriteLine("\t저자 : {0}", inputBook.Author);
            Console.WriteLine("\t수량 : {0}", inputBook.Count);
            Console.WriteLine("\t가격 : {0}", inputBook.Price);
            Console.WriteLine("\t출판 일자 : {0}", inputBook.PublishDate + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");
        }

        public void Search(string type)
        {
            Console.Clear();
            Console.Write("\n\n\t{0}을(를) 입력해주세요 : ", type);
        }

        public void InputBookCount()
        {
            Console.Write("\n\t검색할 개수를 입력해주세요 : ");
        }

        public void PrintBooks(List<BookVO> inputBookList)
        {
            Console.SetWindowSize(210, 60);
            Console.Clear();
            Console.WriteLine("=============================도서명단====================================\n");
            
            foreach(var item in inputBookList)
            {
                Console.WriteLine("================================================================================================================================");
                Console.WriteLine("고유번호 : " + item.Index);
                Console.WriteLine("도서명 : " + item.Name);
                Console.WriteLine("저자 : " + item.Author);
                Console.WriteLine("가격 : " + item.Price);
                Console.WriteLine("출판사 : " + item.Publisher);
                Console.WriteLine("출판일자 : " + item.PublishDate);
                Console.WriteLine("수량 : " + item.Count);
                Console.WriteLine("ISBN : " + item.Isbn);
                Console.WriteLine("줄거리 : " + item.Description);
                Console.WriteLine("================================================================================================================================");
            }
        }

        public string AdjustText(string input)
        {
            int inputSize = Encoding.Default.GetBytes(input).Length;
            
            if (inputSize > 20)
            {
                input = input.Remove(9);
            }

            if (inputSize < 20)
            {
                for (int i = inputSize; i < 20; i++)
                    input = input + " ";
            }

            return input;
        }

        public void Check(string input)
        {
            Console.Write("\n\n\t{0}하실 책 고유번호를 입력해주세요({0}안하고 나가려면 q입력) : ", input);
        }
        
        public void PreviousCheck()
        {
            Console.Write("\n\t 이전메뉴로 돌아가려면 엔터");
            Console.ReadLine();
        }

        public void YNcheck()
        {
            Console.Write("\n해당 책을 DB에 등록하시겠습니까?(Y/N) : ");
        }

        public void NotInStockMsg()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t해당 도서의 재고가 없습니다.");
            Console.WriteLine("\t이전 메뉴로 돌아가려면 엔터");
            Console.ReadLine();
        }

        public void RentErrorMsg(string name, string bookName)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t{0}님 께서는 빌려가신 <{1}>을 먼저 반납해야 합니다.", name, bookName);
            Console.WriteLine("\n\t반납하러 가기 : 1번");
            Console.WriteLine("\t이전 메뉴로 : 2번");
            Console.Write("\t입력(1~2) : ");
        }
        public void CheckRentBook(BookVO inputBook)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------대여할 도서 기존 정보--------------------------------");
            Console.WriteLine("\t도서 제목 : {0}", inputBook.Name);
            Console.WriteLine("\t출판사 : {0}", inputBook.Publisher);
            Console.WriteLine("\t저자 : {0}", inputBook.Author);
            Console.WriteLine("\t수량 : {0}", inputBook.Count);
            Console.WriteLine("\t가격 : {0}", inputBook.Price);
            Console.WriteLine("\t출판 일자 : {0}", inputBook.PublishDate + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.Write("\n\n\t해당 도서를 빌리시겠습니까?(Y/N) : ");
        }

        public void CheckReturnBook(BookVO inputBook)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------반납할 도서 기존 정보--------------------------------");
            Console.WriteLine("\t도서 제목 : {0}", inputBook.Name);
            Console.WriteLine("\t출판사 : {0}", inputBook.Publisher);
            Console.WriteLine("\t저자 : {0}", inputBook.Author);
            Console.WriteLine("\t수량 : {0}", inputBook.Count);
            Console.WriteLine("\t가격 : {0}", inputBook.Price);
            Console.WriteLine("\t출판 일자 : {0}", inputBook.PublishDate + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.Write("\n\n\t해당 도서를 반납하시겠습니까?(Y/N) : ");
        }

        public void ExtensionErrorMsg()
        {
            Console.WriteLine("\n\n\t연장횟수 초과했습니다.");
            Console.WriteLine("\n\n\t이전 메뉴로 돌아가려면 엔터...");
            Console.ReadLine();
        }

        public void NoExtensionErrorMsg()
        {
            Console.WriteLine("\n\n\t연장할 도서가 없습니다.");
            Console.WriteLine("\n\n\t이전 메뉴로 돌아가려면 엔터...");
            Console.ReadLine();
        }

        public void PrintLog(MySqlDataReader dataReader)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------로그 기록--------------------------------");
            while(dataReader.Read())
            {
                Console.WriteLine("\t {0}    {1}         {2}          {3}", dataReader["id"].ToString(), dataReader["action"].ToString(), dataReader["keyword"].ToString(), dataReader["time"].ToString());
            }   
        }

        public void RemoveLogError()
        {
            Console.Clear();
            Console.WriteLine("\n\t삭제할 로그 내역 파일이 없습니다");
        }

    }
}
