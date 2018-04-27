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
        AddLecture addLecture;
        JoinLecture joinLecture;
        RemoveLecture removeLecture;
        SearchLecture searchLecture;
        Print print;
        ErrorCheck errorCheck;
        

        public InterestingLecture(Menu menu, List<InterestingLectureVO> interestingLectureList, AddLecture addLecture, JoinLecture joinLecture, RemoveLecture removeLecture, SearchLecture searchLecture, Print print, ErrorCheck errorCheck)
        {
            this.menu = menu;
            this.interestingLectureList = interestingLectureList;
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
                    searchLecture.SearchDepartment();
                    break;

                case (int)SearchBy.LECTURE_INDEX:
                    searchLecture.SearchLectureIndex();
                    break;

                case (int)SearchBy.LECTURE_NAME:
                    searchLecture.SearchLectureName();
                    break;

                case (int)SearchBy.YEAR:
                    searchLecture.SearchYear();
                    break;

                case (int)SearchBy.PROFESSOR:
                    searchLecture.SearchProfessor();
                    break;

                case (int)SearchBy.EXIT:
                    Environment.Exit(0);
                    break;
            }
        }

        public void AddLecture()
        {

        }

        public void RemoveLecture()
        {

        }

        public void JoinInterstingLecture()
        {

        }
    }
}
