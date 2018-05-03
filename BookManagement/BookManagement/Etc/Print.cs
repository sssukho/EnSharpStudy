using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BookManagement
{
    class Print
    {
        private static Print print;
        ErrorCheck errorCheck;

        public Print()
        {
            errorCheck = ErrorCheck.GetInstance(); //싱글톤구조
        }

        public static Print GetInstance()
        {
            if (print == null) print = new Print();

            return print;
        }

        public void LoginUI()
        {
            Console.SetWindowSize(40, 20);
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

        public void CompleteMsg(string type) //기능 에러없이 완료했을 경우
        {
            Console.WriteLine("\n\n\t{0} 되었습니다.", type);
            Console.WriteLine("\t2초 후에 메뉴로 돌아갑니다...");
            Thread.Sleep(2000);
        }

        public void ErrorMsg(string type) //에러가 난곳에서 스트링 타입으로 인자를 받아서 어떤 에러인지 분류
        {
            Console.WriteLine("{0} 실패입니다...", type);
            Console.WriteLine("이전 메뉴로 돌아가려면 엔터...");
            Console.ReadLine();
        }

        public void RegisterErrorMsg(string type) //등록 및 편집시 잘못 입력하면 뜨는 오류 메시지
        {
            Console.WriteLine("\n\n\t{0} 양식에 맞게 작성해주세요.", type);
            Thread.Sleep(1000);
            Console.Clear();
        }

        public void MenuErrorMsg(string type)
        {
            switch (type)
            {
                case "":
                    Console.Write("\n\n\t1과 2만");
                    break;
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

        public void ReturnErrorMsg()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t해당 회원은 빌려간 책을 먼저 반납해야 합니다.");
            Console.WriteLine("\n\t반납하러 가기 : 1번");
            Console.WriteLine("\t이전 메뉴로 : 2번");
            Console.Write("\t입력(1~2) : ");
        }

        public void InputIDMsg(string type)
        {
            Console.Clear();
            Console.Write("\n\n\t" + type + "의 학번을 입력해주세요(8자리 이내) : ");
        }

        public void ReturnMsg(string type)
        {
            Console.Clear();
            Console.Write("\n\n\t" + type + " 을 반납하시겠습니까? (Y/N) : ");
        }

        public void ExtensionMsg(string type)
        {
            Console.Clear();
            Console.Write("\n\n\t" + type + "의 반납을 연장하시겠습니까? (Y/N) : ");
        }
        public void Menu(string type)
        {
            Console.Clear();
            Console.SetWindowSize(130, 40);
            switch (type)
            {
                case "메인":
                    Console.Clear();
                    Console.WriteLine("\n\n\t----------------------------------------------------------------------------------------------");
                    Console.WriteLine("\t|                                  회원 관리 메뉴 : 1번                                       |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  도서 관리 메뉴 : 2번                                       |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  도서 대여/연장 메뉴 : 3번                                  |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
                    Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");
                    break;
                case "회원관리":
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
                    break;
                case "도서관리":
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
                    Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
                    Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");
                    break;
                case "도서수정":
                    Console.Clear();
                    Console.WriteLine("\n\n\t-------------------------------------수정할 도서 검색-----------------------------------------");
                    Console.WriteLine("\t|                                  도서명으로 검색 : 1번                                        |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  출판사로 검색 : 2번                                        |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  작가로 검색 : 3번                                        |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
                    Console.WriteLine("\t-----------------------------------------------------------------------------------------------\n");
                    break;
                case "도서삭제":
                    Console.Clear();
                    Console.WriteLine("\n\n\t-------------------------------------삭제할 도서 검색------------------------------------------");
                    Console.WriteLine("\t|                                  도서명으로 검색 : 1번                                        |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  출판사로 검색 : 2번                                        |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  작가로 검색 : 3번                                        |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
                    Console.WriteLine("\t-----------------------------------------------------------------------------------------------\n");
                    break;
                case "도서검색":
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
                    break;
                case "도서대여":
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
                    break;
                case "대여검색":
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
                    break;
            }
            Console.WriteLine("\n\t이전 메뉴로 돌아가려면 ESC");
            Console.Write("\n\t메뉴 번호 입력 : ");
        }


        public MemberVO MemberRegister() //while로 틀린 항목 다시 입력하게
        {
            string id, password, name, gender, phoneNumber, email, address, rentbook, duedate;
            Console.Clear();
            while (true)
            {
                Console.Write("\n\n\t학번 입력 (6~8자리 이내) : ");
                id = Console.ReadLine();
                if (errorCheck.MemberID(id) == false)
                    break;
                
                RegisterErrorMsg("학번");
            }

            while (true)
            {
                Console.Write("\n\n\t비밀번호 입력 (12자리 이내) : ");
                password = Console.ReadLine();

                if (errorCheck.MemberPassword(password) == false)//미리 설정해둔 정규식에 맞으면 bool 타입 false 반환
                    break;

                RegisterErrorMsg("이름");
            }

            while (true)
            {
                Console.Write("\n\n\t이름 입력 (4자리 이내) : ");
                name = Console.ReadLine();

                if (errorCheck.MemberName(name) == false)//미리 설정해둔 정규식에 맞으면 bool 타입 false 반환
                    break;

                RegisterErrorMsg("이름");
            }

            while (true)
            {
                Console.Write("\n\n\t성별 입력 (남/여): ");
                gender = Console.ReadLine();
                if (errorCheck.MemberGender(gender) == false)
                    break;
                RegisterErrorMsg("성별");
            }

            while (true)
            {
                Console.Write("\n\n\t핸드폰 번호 입력(010-1234-5678 형식) : ");
                phoneNumber = Console.ReadLine();
                if (errorCheck.MemberPhone(phoneNumber) == false)
                    break;
                RegisterErrorMsg("핸드폰 번호");
            }

            while (true)
            {
                Console.Write("\n\n\t이메일 입력 : ");
                email = Console.ReadLine();

                if (errorCheck.MemberEmail(email) == false)
                    break;
                RegisterErrorMsg("이메일");
            }

            while (true)
            {
                Console.Write("\n\n\t주소 입력 : ");
                address = Console.ReadLine();
                if (errorCheck.MemberAddress(address) == false)
                    break;
                
                RegisterErrorMsg("주소");
            }

            MemberVO newMember = new MemberVO(id, password, name, gender, phoneNumber, email, address, "기본값", "기본값");
            return newMember;
        }

        /*
        public void Search(string type)
        {
            Console.Clear();
            Console.Write("\n\n\t{0}을(를) 입력해주세요 : ", type);
        }

        public void MemberInfo(Member inputMember)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------검색한 회원 기존 정보--------------------------------");
            Console.WriteLine("\n\t이름 : {0}", inputMember.Name);
            Console.WriteLine("\t학번 : {0}", inputMember.StudentId);
            Console.WriteLine("\t성별 : {0}", inputMember.Gender);
            Console.WriteLine("\t핸드폰 번호 : {0}", inputMember.PhoneNumber);
            Console.WriteLine("\t주소 : {0}", inputMember.Address);
            Console.WriteLine("\t현재 대출한 책 : {0}", inputMember.RentBook);
            Console.WriteLine("\t반납 예정일 : {0}", inputMember.DueDate + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.Write("\n\n\t이전으로 돌아가려면 엔터...");
            Console.ReadLine();
        }

        //기본 기능은 주소/핸드폰 번호만 수정 가능
        public Member MemberEdit(Member inputMember, MemberManagement memberManagement)
        {
            string phoneNumber, address;
            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------수정할 회원 기존 정보--------------------------------");
            Console.WriteLine("\n\t이름 : {0}", inputMember.Name);
            Console.WriteLine("\t학번 : {0}", inputMember.StudentId);
            Console.WriteLine("\t성별 : {0}", inputMember.Gender);
            Console.WriteLine("\t핸드폰 번호 : {0}", inputMember.PhoneNumber);
            Console.WriteLine("\t이메일 주소 : {0}", inputMember.Email);
            Console.WriteLine("\t주소 : {0}", inputMember.Address + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.WriteLine("\n\n\t---------------------------------수정할 회원 정보 입력--------------------------------");
            while (true)
            {
                Console.Write("\n\t핸드폰 번호 입력(010-1234-5678 형식) : ");
                phoneNumber = CancelKey.ReadLineWithCancel();
                if (phoneNumber == null) memberManagement.Edit(memberManagement);
                if (errorCheck.MemberPhone(phoneNumber) == false)
                {
                    break;
                }
                RegisterErrorMsg("핸드폰 번호");
            }
            while (true)
            {
                Console.Write("\n\n\t주소 입력(동/리까지 입력) : ");
                address = CancelKey.ReadLineWithCancel();
                if (address == null) MemberEdit(inputMember, memberManagement);
                if (errorCheck.MemberAddress(address) == false)
                {
                    break;
                }
                RegisterErrorMsg("주소");
            }
            inputMember.PhoneNumber = phoneNumber;
            inputMember.Address = address;

            return inputMember;
        }

        public void MemberDelete(Member inputMember)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------삭제할 회원 기존 정보--------------------------------");
            Console.WriteLine("\n\t이름 : {0}", inputMember.Name);
            Console.WriteLine("\t학번 : {0}", inputMember.StudentId);
            Console.WriteLine("\t성별 : {0}", inputMember.Gender);
            Console.WriteLine("\t핸드폰 번호 : {0}", inputMember.PhoneNumber);
            Console.WriteLine("\t주소 : {0}", inputMember.Address + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");
            Console.Write("\n\n\t정말로 삭제하시겠습니까? (Y/N) : ");
        }

        public void AllMember(List<Member> MemberList)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------회원 명단--------------------------------");
            Console.WriteLine("\t   이름   |   학번   |   성별   |   휴대폰번호   |   이메일   |   주소   |   대출한 책   |   반납일   ");

            foreach (var item in MemberList)
            {
                Console.WriteLine("\n\t   {0}      {1}      {2}      {3}      {4}      {5}      {6}      {7}",
                    item.Name, item.StudentId, item.Gender, item.PhoneNumber, item.Email, item.Address, item.RentBook, item.DueDate);
            }
            Console.WriteLine("\n\n\t이전 메뉴로 돌아가려면 엔터...");
            Console.ReadLine();
        }

        public Book BookRegister(BookManagement bookManagement)
        {
            string bookName, publisher, author, price, count;

            Console.Clear();
            while (true)
            {
                Console.Write("\n\n\t도서 제목 입력(16자이내) : ");
                bookName = CancelKey.ReadLineWithCancel();
                if (bookName == null) bookManagement.ViewMenu();
                if (errorCheck.BookName(bookName) == false)
                {
                    break;
                }
                RegisterErrorMsg("도서제목");
            }
            while (true)
            {
                Console.Write("\n\n\t출판사 입력(8자이내) : ");
                publisher = CancelKey.ReadLineWithCancel();
                if (publisher == null) BookRegister(bookManagement);
                if (errorCheck.BookName(publisher) == false)
                {
                    break;
                }
                RegisterErrorMsg("출판사명");
            }
            while (true)
            {
                Console.Write("\n\n\t저자 입력(10자이내) : ");
                author = CancelKey.ReadLineWithCancel();
                if (author == null) BookRegister(bookManagement);
                if (errorCheck.BookAuthor(author) == false)
                {
                    break;
                }
                RegisterErrorMsg("저자");
            }
            while (true)
            {
                Console.Write("\n\n\t가격 입력(예:50000원) : ");
                price = CancelKey.ReadLineWithCancel();
                if (price == null) BookRegister(bookManagement);
                if (errorCheck.BookPrice(price) == false)
                {
                    break;
                }
                RegisterErrorMsg("가격");
            }
            while (true)
            {
                Console.Write("\n\n\t수량 입력(숫자만 입력) : ");
                count = CancelKey.ReadLineWithCancel();
                if (count == null) BookRegister(bookManagement);
                if (errorCheck.BookCount(count) == false)
                {
                    break;
                }
                RegisterErrorMsg("수량");
            }
            Book newBook = new Book(bookName, publisher, author, price, int.Parse(count));

            return newBook;
        }

        public Book BookEdit(Book inputBook, BookManagement bookManagement)
        {
            string count;
            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------수정할 도서 기존 정보--------------------------------");
            Console.WriteLine("\t도서 제목 : {0}", inputBook.BookName);
            Console.WriteLine("\t출판사 : {0}", inputBook.Publisher);
            Console.WriteLine("\t저자 : {0}", inputBook.Author);
            Console.WriteLine("\t도서 가격 : {0}", inputBook.Price);
            Console.WriteLine("\t수량 : {0}", inputBook.Count + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.WriteLine("\n\n\t---------------------------------수정할 도서 수량 입력--------------------------------");
            while (true)
            {
                Console.Write("\n\t수량을 입력해주세요 : ");
                count = CancelKey.ReadLineWithCancel();
                if (count == null) bookManagement.Edit(bookManagement);
                if (errorCheck.BookCount(count) == false)
                {
                    break;
                }
                RegisterErrorMsg("수량");
            }
            inputBook.Count = int.Parse(count);
            return inputBook;
        }

        public void BookDelete(Book inputBook)
        {
            Console.Clear();

            Console.WriteLine("\n\n\t---------------------------------삭제할 도서 기존 정보--------------------------------");
            Console.WriteLine("\t도서 제목 : {0}", inputBook.BookName);
            Console.WriteLine("\t출판사 : {0}", inputBook.Publisher);
            Console.WriteLine("\t저자 : {0}", inputBook.Author);
            Console.WriteLine("\t도서 가격 : {0}", inputBook.Price);
            Console.WriteLine("\t수량 : {0}", inputBook.Count + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.Write("\n\n\t정말로 삭제하시겠습니까? (Y/N) : ");
        }

        public void BookSearch(Book inputBook)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------검색한 도서 기존 정보--------------------------------");
            Console.WriteLine("\t도서 제목 : {0}", inputBook.BookName);
            Console.WriteLine("\t출판사 : {0}", inputBook.Publisher);
            Console.WriteLine("\t저자 : {0}", inputBook.Author);
            Console.WriteLine("\t도서 가격 : {0}", inputBook.Price);
            Console.WriteLine("\t수량 : {0}", inputBook.Count + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.Write("\n\n\t이전으로 돌아가려면 엔터...");
            Console.ReadLine();
        }

        public void AllBook(List<Book> inputBookList)
        {
            if (inputBookList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t등록된 도서가 존재하지 않습니다.");
                Console.WriteLine("\n\n\t이전 메뉴로 돌아가려면 엔터...");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------도서 명단--------------------------------");
            Console.WriteLine("\t   도서명   |   출판사   |   저자   |   가격   |   수량");

            foreach (var item in inputBookList)
            {
                Console.WriteLine("\n\t   {0}      {1}      {2}      {3}      {4}",
                    item.BookName, item.Publisher, item.Author, item.Price, item.Count);
            }

            Console.WriteLine("\n\n\t이전 메뉴로 돌아가려면 엔터...");
            Console.ReadLine();
        }*/
    }
}

