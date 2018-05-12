using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LibraryManagement
{
    class Print
    {
        private static Print print;

        public Print(){ }

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
            Console.WriteLine("\t|                                  DB 관리 메뉴   : 3번                                  |");
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
            Console.WriteLine("\t|                                  로그 초기화 : 1번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  바탕화면에 txt파일 저장 : 2번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  바탕화면 txt 파일 삭제: 3번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
            Console.WriteLine("\t-----------------------------------------------------------------------------------------------\n");
            Console.WriteLine("\n\t이전 메뉴로 돌아가려면 ESC");
            Console.Write("\n\t메뉴 번호 입력 : ");
        }
    }
}
