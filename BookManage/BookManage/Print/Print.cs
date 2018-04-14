using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BookManage
{
    class Print
    {
        Menu menu;
        public Print(Menu menu)
        {
            this.menu = menu;
        }

        public Print()
        {

        }

        public void CompleteMsg(string type)
        {
            Console.WriteLine("\n\n\t{0} 되었습니다.", type);
            Console.WriteLine("\t2초 후에 메뉴로 돌아갑니다...");
            Thread.Sleep(2000);
        }

        public void ErrorMsg(string type)
        {
            switch(type)
            {
                case "5지선다오류":
                    Console.WriteLine("\n\n\t1 ~ 5만 입력이 가능합니다.");
                    break;

                case "4지선다오류":
                    Console.WriteLine("\n\n\t1 ~ 4만 입력이 가능합니다.");
                    break;

                case "7지선다오류":
                    Console.WriteLine("\n\n\t1 ~ 7만 입력이 가능합니다.");
                    break;

                case "Y/N오류":
                    Console.WriteLine("\n\n\tY혹은 N으로만 입력이 가능합니다.");
                    break;

                case "양식오류":
                    Console.WriteLine("\n\n\t양식에 맞게 작성해주십시오.");
                    break;

                case "존재하지않는회원":
                    Console.WriteLine("\n\n\t사용자가 존재하지 않습니다.");
                    break;

                case "존재하지않는도서":
                    Console.WriteLine("\n\n\t도서가 존재하지 않습니다.");
                    break;

                case "수량오류":
                    Console.WriteLine("\n\n\t도서 수량이 없습니다.");
                    break;
            }
            Console.WriteLine("\t다시 입력 : 1번");
            Console.WriteLine("\t이전 메뉴로 : 2번");
        }

       public void Menu(string type)
        {
            Console.Clear();
            switch(type)
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
                    Console.WriteLine("\t|                                  프로그램 종료 : 4번                                        |");
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
                    Console.WriteLine("\t|                                  이전 메뉴 : 6번                                            |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  프로그램 종료 : 7번                                        |");
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
                    Console.WriteLine("\t|                                  이전 메뉴 : 6번                                            |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  프로그램 종료 : 7번                                        |");
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
                    Console.WriteLine("\t|                                  이전 메뉴 : 4번                                            |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  프로그램 종료 : 5번                                        |");
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
                    Console.WriteLine("\t|                                  이전 메뉴 : 4번                                            |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  프로그램 종료 : 5번                                        |");
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
                    Console.WriteLine("\t|                                  이전 메뉴 : 4번                                            |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  프로그램 종료 : 5번                                        |");
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
                    Console.WriteLine("\t|                                  이전 메뉴 : 4번                                            |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  프로그램 종료 : 5번                                        |");
                    Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");
                    break;
            }
            Console.Write("\n\t메뉴 번호 입력 : ");
        }

        public Member MemberRegister()
        {
            string name, studentId, gender, phoneNumber, email, address;
            Console.Clear();
            Console.Write("\n\n\t이름 입력 : ");
            name = Console.ReadLine();
            Console.Write("\n\n\t학번 입력 : ");
            studentId = Console.ReadLine();
            Console.Write("\n\n\t성별 입력 : ");
            gender = Console.ReadLine();
            Console.Write("\n\n\t핸드폰 번호 입력(xxx-xxxx-xxxx 형식) : ");
            phoneNumber = Console.ReadLine();
            Console.Write("\n\n\t이메일 입력 : ");
            email = Console.ReadLine();
            Console.Write("\n\n\t주소 입력 : ");
            address = Console.ReadLine();

            Member newMember = new Member(name, studentId, gender, phoneNumber, email, address, "", "");

            return newMember;
        }

        public void Search(string type)
        {
            Console.Clear();
            Console.Write("\n\n\t{0}을(를) 입력해주세요.", type);
        }

        public void MemberInfo(Member inputMember)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------검색한 회원 기존 정보--------------------------------");
            Console.WriteLine("\n\t이름 : {0}", inputMember.Name);
            Console.WriteLine("\t학번 : {0}", inputMember.StudentId);
            Console.WriteLine("\t성별 : {0}", inputMember.Gender);
            Console.WriteLine("\t핸드폰 번호 : {0}", inputMember.PhoneNumber);
            Console.WriteLine("\t주소 : {0}", inputMember.Address + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.Write("\n\n\t이전으로 돌아가려면 엔터...");
            Console.ReadLine();
        }

        //기본 기능은 주소/핸드폰 번호만 수정 가능
        public Member MemberEdit(Member inputMember)
        {
            string name, studentId, gender, phoneNumber, email, address;
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
            Console.Write("\n\t이름 입력 : ");
            name = Console.ReadLine();
            Console.Write("\n\n\t학번 입력(8자리이하) : ");
            studentId = Console.ReadLine();
            Console.Write("\n\n\t성별 입력(남/여) : ");
            gender = Console.ReadLine();
            Console.Write("\n\n\t핸드폰 번호 입력(xxx-xxxx-xxxx 형식) : ");
            phoneNumber = Console.ReadLine();
            Console.Write("\n\n\t이메일 입력 : ");
            email = Console.ReadLine();
            Console.Write("\n\n\t주소 입력(동/리까지 입력) : ");
            address = Console.ReadLine();

            inputMember.Name = name;
            inputMember.StudentId = studentId;
            inputMember.Gender = gender;
            inputMember.PhoneNumber = phoneNumber;
            inputMember.Email = email;
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
            Console.Write("\n\n\t정말로 삭제하시겠습니까? (Y/N) : "); //에러 체크할 것
        }

       public void AllMember(List<Member> MemberList)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------회원 명단--------------------------------");
            Console.WriteLine("\t   이름   |   학번   |   성별   |   휴대폰번호   |   이메일   |   주소 ");

            foreach (var item in MemberList)
            {
                Console.WriteLine("\n\t   {0}      {1}      {2}      {3}      {4}      {5}",
                    item.Name, item.StudentId, item.Gender, item.PhoneNumber, item.Email, item.Address);
            }
            Console.WriteLine("\n\n\t이전 메뉴로 돌아가려면 엔터...");
            Console.ReadLine();
        }

        public Book BookRegister()
        {
            string bookName, publisher, author, price;
            int count;

            Console.Clear();
            Console.Write("\n\n\t도서 제목 입력 : ");
            bookName = Console.ReadLine();
            Console.Write("\n\n\t출판사 입력 : ");
            publisher = Console.ReadLine();
            Console.Write("\n\n\t저자 입력 : ");
            author = Console.ReadLine();
            Console.Write("\n\n\t가격 입력 : ");
            price = Console.ReadLine();
            Console.Write("\n\n\t수량 입력 : ");
            count = int.Parse(Console.ReadLine());

            Book newBook = new Book(bookName, publisher, author, price, count);

            return newBook;
        }

        public Book BookEdit(Book inputBook)
        {
            int count;
            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------수정할 도서 기존 정보--------------------------------");
            Console.WriteLine("\t도서 제목 : {0}", inputBook.BookName);
            Console.WriteLine("\t출판사 : {0}", inputBook.Publisher);
            Console.WriteLine("\t저자 : {0}", inputBook.Author);
            Console.WriteLine("\t도서 가격 : {0}", inputBook.Price);
            Console.WriteLine("\t수량 : {0}", inputBook.Count + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.WriteLine("\n\n\t---------------------------------수정할 도서 수량 입력--------------------------------");
            Console.WriteLine("\n\t수량을 입력해주세요 : ");
            count = int.Parse(Console.ReadLine()); //타입 에러체크

            inputBook.Count = count;
            return inputBook;
        }

        public void BookDelete(Book inputBook)
        {
            Console.Clear();
            string input;

            Console.WriteLine("\n\n\t---------------------------------삭제할 도서 기존 정보--------------------------------");
            Console.WriteLine("\t도서 제목 : {0}", inputBook.BookName);
            Console.WriteLine("\t출판사 : {0}", inputBook.Publisher);
            Console.WriteLine("\t저자 : {0}", inputBook.Author);
            Console.WriteLine("\t도서 가격 : {0}", inputBook.Price);
            Console.WriteLine("\t수량 : {0}", inputBook.Count + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.Write("\n\n\t정말로 삭제하시겠습니까? (Y/N) : "); //에러 체크할 것
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

            Console.Write("\n\n\t이전으로 돌아가려면 엔터..."); //에러 체크할 것
            Console.ReadLine();
        }

        public void AllBook(List<Book> inputBookList)
        {
            if (inputBookList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t등록된 회원이 존재하지 않습니다.");
                Console.WriteLine("\n\n\t이전 메뉴로 돌아가려면 엔터...");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------회원 명단--------------------------------");
            Console.WriteLine("\t   도서명   |   출판사   |   저자   |   가격   |   수량");

            foreach (var item in inputBookList)
            {
                Console.WriteLine("\n\t   {0}      {1}      {2}      {3}      {4}",
                    item.BookName, item.Publisher, item.Author, item.Price, item.Count);
            }

            Console.WriteLine("\n\n\t이전 메뉴로 돌아가려면 엔터...");
            Console.ReadLine();
        }
    }
}
