using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class PrintMenu
    {
        public static void ViewMainMenu()
        {
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

            Console.Write("\t메뉴 번호 입력 : ");
        }

        public static void ViewMemberManageMenu()
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
            Console.WriteLine("\t|                                  이전 메뉴 : 6번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  프로그램 종료 : 7번                                        |");
            Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");

            Console.Write("\t메뉴 번호 입력 : ");
        }

        public static void SearchMemberMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t----------------------------------------------------------------------------------------------");
            Console.WriteLine("\t|                                  이름으로 검색 : 1번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  학번으로 검색 : 2번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  이전 메뉴 : 3번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  프로그램 종료 : 4번                                        |");
            Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");

            Console.Write("\t메뉴 번호 입력 : ");
        }

        public static void EditMemberMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t-------------------------------------수정할 회원 검색-----------------------------------------");
            Console.WriteLine("\t|                                  이름으로 검색 : 1번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  학번으로 검색 : 2번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  이전 메뉴 : 3번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  프로그램 종료 : 4번                                        |");
            Console.WriteLine("\t-----------------------------------------------------------------------------------------------\n");

            Console.Write("\t메뉴 번호 입력 : ");
        }

        public static void DeleteMemberMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t-------------------------------------삭제할 회원 검색------------------------------------------");
            Console.WriteLine("\t|                                  이름으로 검색 : 1번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  학번으로 검색 : 2번                                        |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  이전 메뉴 : 3번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  프로그램 종료 : 4번                                        |");
            Console.WriteLine("\t-----------------------------------------------------------------------------------------------\n");

            Console.Write("\t메뉴 번호 입력 : ");
        }

        public static void ViewBookManageMenu()
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
            Console.WriteLine("\t|                                  이전 메뉴 : 6번                                            |");
            Console.WriteLine("\t|                                                                                             |");
            Console.WriteLine("\t|                                  프로그램 종료 : 7번                                        |");
            Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");

            Console.Write("\t메뉴 번호 입력 : ");
        }

        public static void EditBookMenu()
        {
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

            Console.Write("\t메뉴 번호 입력 : ");
        }

        public static void DeleteBookMenu()
        {
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

            Console.Write("\t메뉴 번호 입력 : ");
        }

        public static void SearchBookMenu()
        {
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

            Console.Write("\t메뉴 번호 입력 : ");
        }

        public static void ViewBookRentMenu()
        {
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

            Console.Write("\t메뉴 번호 입력 : ");
        }


    }
}
