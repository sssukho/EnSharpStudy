using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    enum MainSelect { EXIT, INTERSTING_LECTURE, REGISTER_LECTURE, JOIN_TIMETABLE }
    enum ApplyLecture { EXIT, SEARCH_LECTURE, ADD_LECTURE, REMOVE_LECTURE, JOIN_LECTURE }
    enum SearchBy { EXIT, DEPARTMENT, LECTURE_INDEX, LECTURE_NAME, YEAR, PROFESSOR, INTERESTING_LECTURE }

    class Menu
    {
        RegisterLecture registerLecture;
        InterestingLecture interestingLecture;
        JoinTimeTable joinTimeTable;
        ErrorCheck errorCheck;
        AddLecture addLecture;
        JoinLecture joinLecture;
        RemoveLecture removeLecture;
        SearchLecture searchLecture;
        Print print;
        List<InterestingLectureVO> interestingLectureList;
        List<RegisteredLectureVO> registeredLectureList;
        List<LectureListVO> lectureList;
        ConsoleKeyInfo input;

        public Menu()
        {
            joinTimeTable = new JoinTimeTable();
            errorCheck = new ErrorCheck();
            print = new Print();
            addLecture = new AddLecture(print, errorCheck);
            joinLecture = new JoinLecture();
            removeLecture = new RemoveLecture(print, errorCheck);
            searchLecture = new SearchLecture(print, errorCheck);
            interestingLectureList = new List<InterestingLectureVO>();
            registeredLectureList = new List<RegisteredLectureVO>();
            lectureList = new LoadExcel().AddData();
            registerLecture = new RegisterLecture(this, registeredLectureList, lectureList, addLecture, joinLecture, removeLecture, searchLecture, print, errorCheck);
            interestingLecture = new InterestingLecture(this, interestingLectureList, lectureList, addLecture, joinLecture, removeLecture, searchLecture, print, errorCheck);
            MainMenu();
        }

        public void MainMenu()
        {
            print.Menu("메인");
            input = Console.ReadKey();

            switch (int.Parse(input.KeyChar.ToString()))
            {
                case (int)MainSelect.INTERSTING_LECTURE:
                    InterstingLectureMenu(interestingLectureList);
                    break;

                case (int)MainSelect.REGISTER_LECTURE:
                    RegisterLectureMenu();
                    break;

                case (int)MainSelect.JOIN_TIMETABLE:
                    JoinMenu();
                    break;

                case (int)MainSelect.EXIT:
                    Environment.Exit(0);
                    break;
            }
        }

        public void InterstingLectureMenu(List<InterestingLectureVO> inputInterestingLectureList)
        {
            this.interestingLectureList = inputInterestingLectureList;

            print.Menu("관심과목");
            input = Console.ReadKey();

            switch(int.Parse(input.KeyChar.ToString()))
            {
                case (int)ApplyLecture.SEARCH_LECTURE:
                    SearchInterstingLectureMenu(inputInterestingLectureList);
                    break;

                case (int)ApplyLecture.ADD_LECTURE:
                    interestingLecture.AddLecture(inputInterestingLectureList);
                    break;

                case (int)ApplyLecture.REMOVE_LECTURE:
                    interestingLecture.RemoveLecture(inputInterestingLectureList);
                    break;

                case (int)ApplyLecture.JOIN_LECTURE:
                    interestingLecture.JoinInterstingLecture(inputInterestingLectureList);
                    break;

                case (int)ApplyLecture.EXIT:
                    Environment.Exit(0);
                    break;
            }
        }

        public void SearchInterstingLectureMenu(List<InterestingLectureVO> inputInterestingLectureList)
        {
            print.Menu("관심과목 강의검색");
            input = Console.ReadKey();

            int searchType = int.Parse(input.KeyChar.ToString());
            interestingLecture.SearchLecture(searchType, inputInterestingLectureList);
        }
        
        public void RegisterLectureMenu()
        {
            print.Menu("수강신청");
            input = Console.ReadKey();

            switch (int.Parse(input.KeyChar.ToString()))
            {
                case (int)ApplyLecture.SEARCH_LECTURE:
                    SearchRegisterLectureMenu();
                    break;

                case (int)ApplyLecture.ADD_LECTURE:
                    registerLecture.AddLecture();
                    break;

                case (int)ApplyLecture.REMOVE_LECTURE:
                    registerLecture.RemoveLecture();
                    break;

                case (int)ApplyLecture.JOIN_LECTURE:
                    registerLecture.JoinRegisterLecture();
                    break;

                case (int)ApplyLecture.EXIT:
                    Environment.Exit(0);
                    break;
            }
        }

        public void SearchRegisterLectureMenu()
        {
            print.Menu("수강신청 강의검색");
            input = Console.ReadKey();

            int searchType = int.Parse(input.KeyChar.ToString());
            registerLecture.SearchLecture(searchType);
        }

        public void JoinMenu()
        {
            print.Menu("시간표 조회");
            input = Console.ReadKey();
        }
    }
}