using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClassRegistration
{
    class Print
    {
        public void MainMenu()
        {
            Console.SetWindowSize(110, 20);
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
            Console.Write("입력 >> ");
        }
        public void Menu(string menuType)
        {
            Console.SetWindowSize(110, 30);
            switch (menuType)
            {
                case "관심과목":
                    Console.Clear();
                    Console.WriteLine("\n\n\t\t                           관심과목담기 메뉴");
                    Console.WriteLine("\n\t----------------------------------------------------------------------------------------------");
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
                    Console.WriteLine("\n\n\t\t                           수강신청 메뉴");
                    Console.WriteLine("\n\t----------------------------------------------------------------------------------------------");
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
                    Console.WriteLine("\n\n\t\t                           관심과목 강의검색");
                    Console.WriteLine("\n\t----------------------------------------------------------------------------------------------");
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
                    Console.WriteLine("\n\n\t\t                           수강신청 강의검색");
                    Console.WriteLine("\n\t----------------------------------------------------------------------------------------------");
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
                    Console.WriteLine("\n\n\t\t                           시간표 조회 메뉴");
                    Console.WriteLine("\n\t----------------------------------------------------------------------------------------------");
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

        public void ListForm()
        {
            Console.SetWindowSize(160, 40);
            Console.WriteLine();
            Console.WriteLine("개설학과전공     학수번호 분반  교과목명                         이수구분 학년학점 요일및강의시간                강의실        교수명              강의언어");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public void InputMsg(string type)
        {
            Console.Write("\n{0}를(을) 입력해주세요 : ", type);
        }

        public void PreviousMsg()
        {
            Console.WriteLine("\n(이전 메뉴로 돌아가려면 Enter)");
        }

        public void ErrorMsg(string type)
        {
            Console.Clear();
            Console.WriteLine("\n\n{0} 입니다.", type);
            Console.WriteLine("2초 후에 이전 메뉴로 돌아갑니다..");
            Thread.Sleep(2000);
        }

        public void CompleteMsg(string type)
        {
            Console.WriteLine("\n\n{0} 완료되었습니다!", type);
            PreviousMsg();
            Console.ReadLine();
        }

        public void ShowLecture(List<LectureListVO> foundLectures)
        {
            Console.Clear();
            ListForm();

            for (int i = 0; i  < foundLectures.Count; i++)
            {
                if (foundLectures[i].Classroom == null)
                    foundLectures[i].Classroom = " ";
                Console.Write("{0}  {1}  {2}   {3} {4}  {5}  {6}  {7}  {8}  {9}  {10}", SetForm(foundLectures[i].Department.ToString(), 16), foundLectures[i].LectureIndex, foundLectures[i].ClassIndex, SetForm(foundLectures[i].LectureName.ToString(), 32), foundLectures[i].Division, foundLectures[i].Year, foundLectures[i].Grade, SetForm(foundLectures[i].Time.ToString(),29), SetForm(foundLectures[i].Classroom.ToString(), 11), SetForm(foundLectures[i].Professor.ToString(), 22), foundLectures[i].Language);
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public void ShowLecture(List<InterestingLectureVO> foundLectures)
        {
            Console.Clear();
            ListForm();

            for (int i = 0; i < foundLectures.Count; i++)
            {
                if (foundLectures[i].Classroom == null)
                    foundLectures[i].Classroom = " ";
                Console.Write("{0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}  {8}  {9}  {10}", SetForm(foundLectures[i].Department.ToString(), 16), foundLectures[i].LectureIndex, foundLectures[i].ClassIndex, SetForm(foundLectures[i].LectureName.ToString(), 32), foundLectures[i].Division, foundLectures[i].Year, foundLectures[i].Grade, SetForm(foundLectures[i].Time.ToString(), 29), SetForm(foundLectures[i].Classroom.ToString(), 11), SetForm(foundLectures[i].Professor.ToString(), 22), foundLectures[i].Language);
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public void ShowLecture(List<RegisteredLectureVO> foundLectures)
        {
            Console.Clear();
            ListForm();
            for(int i = 0; i < foundLectures.Count; i++)
            {
                if (foundLectures[i].Classroom == null)
                    foundLectures[i].Classroom = " ";
                Console.Write("{0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}  {8}  {9}  {10}", SetForm(foundLectures[i].Department.ToString(), 16), foundLectures[i].LectureIndex, foundLectures[i].ClassIndex, SetForm(foundLectures[i].LectureName.ToString(), 32), foundLectures[i].Division, foundLectures[i].Year, foundLectures[i].Grade, SetForm(foundLectures[i].Time.ToString(), 29), SetForm(foundLectures[i].Classroom.ToString(), 11), SetForm(foundLectures[i].Professor.ToString(), 22), foundLectures[i].Language);
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public string SetForm(string input, int letterSize)
        {
            int inputSize = Encoding.Default.GetBytes(input).Length;
            if (inputSize != letterSize)
            {
                for(int i = inputSize; i < letterSize; i ++)
                {
                    input = input + " ";
                }
            }
            return input;
        }

        public void ShowTimeTable(List<RegisteredLectureVO> registeredLectureList)
        {
            Console.Clear();

            const string timeFormat = "{0, -16} {1, -21} {2, -21} {3, -21} {4, -21} {5, -21}";

            string row1 = string.Format(timeFormat, "09:00~09:30 |");
            string row2 = string.Format(timeFormat, "09:30~10:00 |");
            string row3 = string.Format(timeFormat, "10:00~10:30 |");
            string row4 = string.Format(timeFormat, "10:30~11:00 |");
            string row5 = string.Format(timeFormat, "11:00~11:30 |");
            string row6 = string.Format(timeFormat, "11:30~12:00 |");
            string row7 = string.Format(timeFormat, "12:00~12:30 |");
            string row8 = string.Format(timeFormat, "12:30~13:00 |");
            string row9 = string.Format(timeFormat, "13:00~13:30 |");
            string row10 = string.Format(timeFormat, "13:30~14:00 |");
            string row11 = string.Format(timeFormat, "14:00~14:30 |");
            string row12 = string.Format(timeFormat, "14:30~15:00 |");
            string row13 = string.Format(timeFormat, "15:00~15:30 |");
            string row14 = string.Format(timeFormat, "15:30~16:00 |");
            string row15 = string.Format(timeFormat, "16:00~16:30 |");
            string row16 = string.Format(timeFormat, "16:30~17:00 |");
            string row17 = string.Format(timeFormat, "17:00~17:30 |");
            string row18 = string.Format(timeFormat, "17:30~18:00 |");
            string row19 = string.Format(timeFormat, "18:00~18:30 |");
            string row20 = string.Format(timeFormat, "18:30~19:00 |");
            string row21 = string.Format(timeFormat, "19:00~19:30 |");
            string row22 = string.Format(timeFormat, "19:30~20:00 |");

            registeredLectureList.
        }
    }
}
