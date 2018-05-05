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
        List<LectureVO> interestingLectureList;
        List<LectureVO> lectureList;
        AddLecture addLecture;
        JoinLecture joinLecture;
        RemoveLecture removeLecture;
        SearchLecture searchLecture;
        Print print;
        ErrorCheck errorCheck;
        
        public InterestingLecture(Menu menu, List<LectureVO> interestingLectureList, List<LectureVO> lectureList, AddLecture addLecture, JoinLecture joinLecture, RemoveLecture removeLecture, SearchLecture searchLecture, Print print, ErrorCheck errorCheck)
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

        public void SearchLecture(int searchType, List<LectureVO> inputInterestingLectureList)
        {
            this.interestingLectureList = inputInterestingLectureList;
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

                case (int)SearchBy.EXIT:
                    Environment.Exit(0);
                    break;
            }
            menu.SearchInterstingLectureMenu(inputInterestingLectureList);
        }

        public void AddLecture(List<LectureVO> inputInterestingLectureList)
        {
            this.interestingLectureList = inputInterestingLectureList;
            List<LectureVO> afterAddList;
            afterAddList = addLecture.AddLectureInList(lectureList, interestingLectureList, "관심과목");

            if (afterAddList.Count == interestingLectureList.Count) //add가 제대로 안되었을때
                menu.InterstingLectureMenu(interestingLectureList);
            
            else
                menu.InterstingLectureMenu(afterAddList);
        }

        public void RemoveLecture(List<LectureVO> inputInterestingLectureList)
        {
            this.interestingLectureList = inputInterestingLectureList;
            List<LectureVO> afterRemoveList;
            afterRemoveList = removeLecture.RemoveFromLectureList(lectureList, interestingLectureList);

            if (afterRemoveList.Count == interestingLectureList.Count) //remove 제대로 안되었을때
                menu.InterstingLectureMenu(interestingLectureList);
              
            else
                menu.InterstingLectureMenu(afterRemoveList);
        }

        public void JoinInterstingLecture(List<LectureVO> inputInterestingLectureList)
        {
            this.interestingLectureList = inputInterestingLectureList;
            joinLecture.JoinLectureList(inputInterestingLectureList);
            menu.InterstingLectureMenu(interestingLectureList);
        }
    }
}
