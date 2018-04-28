using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    
    class InterestingLecture
    {
        Menu menu;
        List<InterestingLectureVO> interestingLectureList;
        List<LectureListVO> lectureList;
        AddLecture addLecture;
        JoinLecture joinLecture;
        RemoveLecture removeLecture;
        SearchLecture searchLecture;
        Print print;
        ErrorCheck errorCheck;
        
        public InterestingLecture(Menu menu, List<InterestingLectureVO> interestingLectureList, List<LectureListVO> lectureList, AddLecture addLecture, JoinLecture joinLecture, RemoveLecture removeLecture, SearchLecture searchLecture, Print print, ErrorCheck errorCheck)
        {
            this.menu = menu;
            this.interestingLectureList = interestingLectureList;
            this.lectureList = lectureList;
            this.addLecture = addLecture;
            this.joinLecture = joinLecture;
            this.removeLecture = removeLecture;
            this.searchLecture = searchLecture;
            this.print = print;
            this.errorCheck = errorCheck;
        }

        public void SearchLecture(int searchType)
        {
            switch(searchType)
            {
                case (int)SearchBy.DEPARTMENT:
                    searchLecture.SearchDepartment(lectureList);
                    break;

                case (int)SearchBy.LECTURE_INDEX:
                    searchLecture.SearchLectureIndex(lectureList);
                    break;

                case (int)SearchBy.LECTURE_NAME:
                    searchLecture.SearchLectureName(lectureList);
                    break;

                case (int)SearchBy.YEAR:
                    searchLecture.SearchYear(lectureList);
                    break;

                case (int)SearchBy.PROFESSOR:
                    searchLecture.SearchProfessor(lectureList);
                    break;

                case (int)SearchBy.EXIT:
                    Environment.Exit(0);
                    break;
            }
        }

        public void AddLecture()
        {
            List<InterestingLectureVO> afterAddList;
            afterAddList = addLecture.AddLectureInList(lectureList, interestingLectureList);
            
            
            if (afterAddList.Count == interestingLectureList.Count)
                menu.InterstingLectureMenu(interestingLectureList);
            else
                print.ShowLecture(afterAddList);
        }

        public void RemoveLecture()
        {

        }

        public void JoinInterstingLecture()
        {

        }
    }
}
