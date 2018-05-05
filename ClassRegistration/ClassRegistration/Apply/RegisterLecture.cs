using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{

    class RegisterLecture
    {
        Menu menu;
        List<LectureVO> registeredLectureList;
        List<LectureVO> lectureList;
        AddLecture addLecture;
        JoinLecture joinLecture;
        RemoveLecture removeLecture;
        SearchLecture searchLecture;
        Print print;
        ErrorCheck errorCheck;


        public RegisterLecture(Menu menu, List<LectureVO> registeredLectureList, List<LectureVO> lectureList, AddLecture addLecture, JoinLecture joinLecture, RemoveLecture removeLecture, SearchLecture searchLecture, Print print, ErrorCheck errorCheck)
        {
            this.menu = menu;
            this.registeredLectureList = registeredLectureList;
            this.lectureList = lectureList;
            this.addLecture = addLecture;
            this.joinLecture = joinLecture;
            this.removeLecture = removeLecture;
            this.searchLecture = searchLecture;
            this.print = print;
            this.errorCheck = errorCheck;
        }

        public void SearchLecture(int searchType, List<LectureVO> inputRegisteredLectureList, List<LectureVO> inputInterestingLectureList)
        {
            this.registeredLectureList = inputRegisteredLectureList;
            switch(searchType)
            {
                case (int)SearchBy.DEPARTMENT:
                    searchLecture.SearchByDepartment(lectureList);
                    break;

                case (int)SearchBy.LECTURE_INDEX:
                    searchLecture.SearchByLectureIndex(lectureList);
                    break;

                case (int)SearchBy.LECTURE_NAME:
                    searchLecture.SearchByLectureName(lectureList);
                    break;

                case (int)SearchBy.YEAR:
                    searchLecture.SearchByYear(lectureList);
                    break;

                case (int)SearchBy.PROFESSOR:
                    searchLecture.SearchByProfessor(lectureList);
                    break;

                case (int)SearchBy.INTERESTING_LECTURE:
                    searchLecture.SearchInterstingLecture(inputInterestingLectureList);
                    break;

                case (int)SearchBy.EXIT:
                    Environment.Exit(0);
                    break;
            }
            menu.SearchRegisterLectureMenu(inputRegisteredLectureList);
        }

        public List<LectureVO> AddLecture(List<LectureVO> inputRegisteredLectureList)
        {
            this.registeredLectureList = inputRegisteredLectureList;
            List<LectureVO> afterAddList;
            afterAddList = addLecture.AddLectureInList(lectureList, registeredLectureList, "수강신청");

            if (afterAddList.Count == registeredLectureList.Count)
            {
                menu.RegisterLectureMenu(registeredLectureList);
                return inputRegisteredLectureList;
            }

            else
            {
                menu.RegisterLectureMenu(afterAddList);
                return inputRegisteredLectureList;
            }
                
        }

        public void RemoveLecture(List<LectureVO> inputRegisteredLectureList)
        {
            this.registeredLectureList = inputRegisteredLectureList;
            List<LectureVO> afterRemoveList;
            afterRemoveList = removeLecture.RemoveFromLectureList(lectureList, registeredLectureList);

            if (afterRemoveList.Count == registeredLectureList.Count)
                menu.RegisterLectureMenu(registeredLectureList);
            else
                menu.RegisterLectureMenu(afterRemoveList);
        }

        public void JoinRegisterLecture(List<LectureVO> inputRegisteredLectureList)
        {
            this.registeredLectureList = inputRegisteredLectureList;
            joinLecture.JoinLectureList(inputRegisteredLectureList);
            menu.RegisterLectureMenu(registeredLectureList);
        }
    }
}
