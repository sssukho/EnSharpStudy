using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    enum MainSelect{ EXIT, INTERSTING_LECTURE, REGISTER_LECTURE, JOIN_TIMETABLE }
    enum ApplyLecture { EXIT, SEARCH_LECTURE, ADD_LECTURE, REMOVE_LECTURE, JOIN_LECTURE }
    
    class Menu
    {
        RegisterLecture registerLecture;
        InterestingLecture interstingLecture;
        JoinTimeTable joinTimeTable;
        ErrorCheck errorCheck;
        AddLecture addLecture;
        JoinLecture joinLecture;
        LoadExcel loadExcel;
        RemoveLecture removeLecture;
        SearchLecture searchLecture;
        Print print;
        List<InterestingLectureVO> interestingLectureList;
        List<RegisteredLectureVO> registeredLectureList;
        ConsoleKeyInfo input;

        public Menu()
        {
            joinTimeTable = new JoinTimeTable();
            errorCheck = new ErrorCheck();
            addLecture = new AddLecture();
            joinLecture = new JoinLecture();
            loadExcel = new LoadExcel();
            removeLecture = new RemoveLecture();
            searchLecture = new SearchLecture();
            print = new Print();
            interestingLectureList = new List<InterestingLectureVO>();
            registeredLectureList = new List<RegisteredLectureVO>();
            registerLecture = new RegisterLecture();
            interstingLecture = new InterestingLecture(this, interestingLectureList);

            MainMenu();
        }

        public Menu(List<InterestingLectureVO> interestingLectureList)
        {
            this.interestingLectureList = interestingLectureList;
            MainMenu();
        }

        public Menu(List<RegisteredLectureVO> registeredLectureList)
        {
            this.registeredLectureList = registeredLectureList;
            MainMenu();
        }

        public void MainMenu()
        {
            print.Menu("메인");
            input = Console.ReadKey();

            switch (int.Parse(input.KeyChar.ToString()))
            {
                case (int)MainSelect.INTERSTING_LECTURE:
                    InterstingLectureMenu();
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

        public void InterstingLectureMenu()
        {
            print.Menu("관심과목");
            input = Console.ReadKey();

            switch(int.Parse(input.KeyChar.ToString()))
            {
                case (int)ApplyLecture.SEARCH_LECTURE:
                    SearchInterstingLectureMenu();
                    break;

                case (int)ApplyLecture.ADD_LECTURE:
                    interstingLecture.AddLecture();
                    break;

                case (int)ApplyLecture.REMOVE_LECTURE:
                    interstingLecture.RemoveLecture();
                    break;

                case (int)ApplyLecture.JOIN_LECTURE:
                    interstingLecture.JoinInterstingLecture();
                    break;

                case (int)ApplyLecture.EXIT:
                    Environment.Exit(0);
                    break;
            }
        }

        public void SearchInterstingLectureMenu()
        {
            print.Menu("관심과목 강의검색");
            input = Console.ReadKey();

            int searchType = int.Parse(input.KeyChar.ToString());
            interstingLecture.SearchLecture(searchType);
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
