using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    class Print
    {
        public void Menu(string menuType)
        {
           switch(menuType)
            {
                case "메인":
                    Console.Clear();
                    Console.WriteLine("\n\n\t----------------------------------------------------------------------------------------------");
                    Console.WriteLine("\t|                                  관심 과목 담기 : 1번                                       |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  수강 신청 : 2번                                            |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  시간표 조회 : 3번                                          |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
                    Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");
                    break;

                case "관심과목":
                    Console.Clear();
                    Console.WriteLine("\n\n\t----------------------------------------------------------------------------------------------");
                    Console.WriteLine("\t|                                  강의 검색 : 1번                                            |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  강의 추가 : 2번                                            |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  강의 삭제 : 3번                                            |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  관심과목 강의 조회 : 4번                                   |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
                    Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");
                    break;

                case "수강신청":
                    Console.Clear();
                    Console.WriteLine("\n\n\t----------------------------------------------------------------------------------------------");
                    Console.WriteLine("\t|                                  강의 검색 : 1번                                            |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  강의 추가 : 2번                                            |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  강의 삭제 : 3번                                            |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  수강신청 강의 조회 : 4번                                   |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
                    Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");
                    break;

                case "관심과목 강의검색":
                    Console.Clear();
                    Console.WriteLine("\n\n\t----------------------------------------------------------------------------------------------");
                    Console.WriteLine("\t|                                  개설학과 전공으로 검색 : 1번                               |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  학수번호로 검색 : 2번                                      |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  교과목명으로 검색 : 3번                                    |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  학년으로 검색 : 4번                                        |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  교수명으로 검색 : 5번                                      |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
                    Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");
                    break;

                case "수강신청 강의검색":
                    Console.Clear();
                    Console.WriteLine("\n\n\t----------------------------------------------------------------------------------------------");
                    Console.WriteLine("\t|                                  개설학과 전공으로 검색 : 1번                               |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  학수번호로 검색 : 2번                                      |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  교과목명으로 검색 : 3번                                    |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  학년으로 검색 : 4번                                        |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  교수명으로 검색 : 5번                                      |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  관심과목으로 검색 : 6번                                    |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
                    Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");
                    break;

                case "시간표 조회":
                    Console.Clear();
                    Console.WriteLine("\n\n\t----------------------------------------------------------------------------------------------");
                    Console.WriteLine("\t|                                  수강신청한 시간표 출력하기 : 1번                           |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  엑셀로 저장하기 : 2번                                      |");
                    Console.WriteLine("\t|                                                                                             |");
                    Console.WriteLine("\t|                                  프로그램 종료 : 0번                                        |");
                    Console.WriteLine("\t----------------------------------------------------------------------------------------------\n");
                    break;
            }
            Console.WriteLine("(이전메뉴로 돌아가려면 ESC)\n");
            Console.Write("입력 >> ");
        }


    }
}
