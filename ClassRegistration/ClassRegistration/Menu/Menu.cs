using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    //메뉴선택 할때 필요한 매직넘버 상수화
    //시간표 출력시 요일별 띄어쓰기 칸 상수화
    enum MainSelect { EXIT, INTERSTING_LECTURE, REGISTER_LECTURE, JOIN_TIMETABLE }
    enum ApplyLecture { EXIT, SEARCH_LECTURE, ADD_LECTURE, REMOVE_LECTURE, JOIN_LECTURE }
    enum SearchBy { EXIT, DEPARTMENT, LECTURE_INDEX, LECTURE_NAME, YEAR, PROFESSOR, INTERESTING_LECTURE }
    enum JoinTimetable { EXIT, JOIN_TIMETABLE, EXPORT_EXCEL }
    enum FormType { MONDAY = 22, TUESDAY = 44, WEDNESDAY = 46, THURSDAY = 48, FRIDAY = 52 }

    /// <기능>
    /// 1. 메뉴 출력
    /// 2. 필요 객체 생성
    /// 3. 메뉴 선택에 따른 객체 이동
    /// </기능>
    /// 
    /// <!--주의할점-->
    /// 메뉴 입력시 ReadKey로 구현함 -> 엔터 불필요
    
    class Menu
    {
        //프로그램 진행하는데 있어서 필요한 객체 선언
        RegisterLecture registerLecture; //수강신청 관리
        InterestingLecture interestingLecture; //관심과목 관리
        JoinTimeTable joinTimeTable; //시간표 출력 및 엑셀로 내보내기
        ErrorCheck errorCheck;
        AddLecture addLecture; //기능: 강의 리스트에 추가
        JoinLecture joinLecture; //기능: 강의 리스트 조회
        Export export; //액셀로 내보내기
        RemoveLecture removeLecture; //기능: 강의 리스트에서 선택 강의 삭제
        SearchLecture searchLecture; // 전체 강의 리스트에서 검색
        Print print;
        List<InterestingLectureVO> interestingLectureList; //관심과목 담는 리스트
        List<RegisteredLectureVO> registeredLectureList; //수강신청한 과목 담는 리스트
        List<LectureListVO> lectureList; //엑셀로 불러온 모든 강의를 담는 리스트
        ConsoleKeyInfo input;

        bool error;

        public Menu()
        {
            errorCheck = new ErrorCheck();
            print = new Print(new List<RegisteredLectureVO>(), new List<RegisteredLectureVO>(), new List<RegisteredLectureVO>(), new List<RegisteredLectureVO>(), new List<RegisteredLectureVO>());
            addLecture = new AddLecture(print, errorCheck);
            removeLecture = new RemoveLecture(print, errorCheck);
            searchLecture = new SearchLecture(print, errorCheck);
            joinLecture = new JoinLecture(print, errorCheck);
            export = new Export(print, new List<RegisteredLectureVO>(), new List<RegisteredLectureVO>(), new List<RegisteredLectureVO>(), new List<RegisteredLectureVO>(), new List<RegisteredLectureVO>());
            interestingLectureList = new List<InterestingLectureVO>();
            registeredLectureList = new List<RegisteredLectureVO>();
            lectureList = new LoadExcel().AddData();
            registerLecture = new RegisterLecture(this, registeredLectureList, lectureList, addLecture, joinLecture, removeLecture, searchLecture, print, errorCheck);
            interestingLecture = new InterestingLecture(this, interestingLectureList, lectureList, addLecture, joinLecture, removeLecture, searchLecture, print, errorCheck);
            joinTimeTable = new JoinTimeTable(this, registeredLectureList, joinLecture, export, print, errorCheck);
            MainMenu();
        }

        public void MainMenu()
        {
            print.MainMenu();
            input = Console.ReadKey();
            //입력 오류 검사
            error = errorCheck.IsValidInputKey(input.KeyChar.ToString(), "mainMenu");
            if(error == true)
            {
                print.ErrorMsg("없는 항목");
                MainMenu();
                return;
            }

            switch (int.Parse(input.KeyChar.ToString()))
            {
                case (int)MainSelect.INTERSTING_LECTURE:
                    InterstingLectureMenu(interestingLectureList);
                    break;

                case (int)MainSelect.REGISTER_LECTURE:
                    RegisterLectureMenu(registeredLectureList);
                    break;

                case (int)MainSelect.JOIN_TIMETABLE:
                    JoinMenu();
                    break;

                case (int)MainSelect.EXIT:
                    Environment.Exit(0);
                    break;
            }
        }

        //관심과목 담기 메뉴
        public void InterstingLectureMenu(List<InterestingLectureVO> inputInterestingLectureList)
        {
            this.interestingLectureList = inputInterestingLectureList;

            print.Menu("관심과목");
            input = Console.ReadKey();
            //ESC 누르면 이전 메뉴로 이동
            if (input.Key == ConsoleKey.Escape)
                MainMenu();

            //입력받은 키중 메뉴 항목에 해당하는 키 여부 오류 체크
            error = errorCheck.IsValidInputKey(input.KeyChar.ToString(), "lectureMenu");
            if(error == true)
            {
                print.ErrorMsg("없는 항목");
                InterstingLectureMenu(interestingLectureList); //에러나면 이전 메뉴로
                return;
            }

            switch (int.Parse(input.KeyChar.ToString()))
            {
                case (int)ApplyLecture.SEARCH_LECTURE:
                    SearchInterstingLectureMenu(interestingLectureList);
                    break;

                case (int)ApplyLecture.ADD_LECTURE:
                    interestingLecture.AddLecture(interestingLectureList);
                    break;

                case (int)ApplyLecture.REMOVE_LECTURE:
                    interestingLecture.RemoveLecture(interestingLectureList);
                    break;

                case (int)ApplyLecture.JOIN_LECTURE:
                    interestingLecture.JoinInterstingLecture(interestingLectureList);
                    break;

                case (int)ApplyLecture.EXIT:
                    Environment.Exit(0);
                    break;
            }
        }

        //관심과목 메뉴 -> 강의검색 메뉴
        public void SearchInterstingLectureMenu(List<InterestingLectureVO> inputInterestingLectureList)
        {
            this.interestingLectureList = inputInterestingLectureList;
            print.Menu("관심과목 강의검색");
            input = Console.ReadKey();
            if (input.Key == ConsoleKey.Escape)
                InterstingLectureMenu(inputInterestingLectureList);

            error = errorCheck.IsValidInputKey(input.KeyChar.ToString(), "interstingLectureSearchMenu");
            if(error == true) //에러나면 이전메뉴로
            {
                print.ErrorMsg("없는 항목");
                SearchInterstingLectureMenu(interestingLectureList);
                return;
            }

            int searchType = int.Parse(input.KeyChar.ToString());
            interestingLecture.SearchLecture(searchType, inputInterestingLectureList);
        }

        //수강신청 메뉴
        public void RegisterLectureMenu(List<RegisteredLectureVO> inputRegisteredLectureList)
        {
            this.registeredLectureList = inputRegisteredLectureList;

            print.Menu("수강신청");
            input = Console.ReadKey();
            if (input.Key == ConsoleKey.Escape)
                MainMenu();

            error = errorCheck.IsValidInputKey(input.KeyChar.ToString(), "lectureMenu");
            if (error == true)
            {
                print.ErrorMsg("없는 항목");
                RegisterLectureMenu(registeredLectureList);
                return;
            }
            switch (int.Parse(input.KeyChar.ToString()))
            {
                case (int)ApplyLecture.SEARCH_LECTURE:
                    SearchRegisterLectureMenu(registeredLectureList);
                    break;

                case (int)ApplyLecture.ADD_LECTURE:
                    registerLecture.AddLecture(registeredLectureList);
                    break;

                case (int)ApplyLecture.REMOVE_LECTURE:
                    registerLecture.RemoveLecture(registeredLectureList);
                    break;

                case (int)ApplyLecture.JOIN_LECTURE:
                    registerLecture.JoinRegisterLecture(registeredLectureList);
                    break;

                case (int)ApplyLecture.EXIT:
                    Environment.Exit(0);
                    break;
            }
        }

        //수강신청 메뉴 -> 강의 검색 메뉴
        public void SearchRegisterLectureMenu(List<RegisteredLectureVO> inputRegisteredLectureList)
        {
            this.registeredLectureList = inputRegisteredLectureList;
            print.Menu("수강신청 강의검색");
            input = Console.ReadKey();
            if (input.Key == ConsoleKey.Escape)
                RegisterLectureMenu(registeredLectureList);

            error = errorCheck.IsValidInputKey(input.KeyChar.ToString(), "interstingLectureSearchMenu");
            if (error == true)
            {
                print.ErrorMsg("없는 항목");
                SearchRegisterLectureMenu(registeredLectureList);
                return;
            }

            int searchType = int.Parse(input.KeyChar.ToString());
            registerLecture.SearchLecture(searchType, registeredLectureList, interestingLectureList);
        }

        //메인메뉴 -> 시간표 조회 메뉴
        public void JoinMenu()
        {
            print.Menu("시간표 조회");
            input = Console.ReadKey();
            if (input.Key == ConsoleKey.Escape)
                MainMenu();

            switch (int.Parse(input.KeyChar.ToString()))
            {
                case (int)JoinTimetable.JOIN_TIMETABLE:
                    joinTimeTable.JoinRegisteredTimeTable(registeredLectureList);
                    break;

                case (int)JoinTimetable.EXPORT_EXCEL:
                    joinTimeTable.ExportExcel(registeredLectureList);
                    break;

                case (int)JoinTimetable.EXIT:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}