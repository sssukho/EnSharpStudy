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

        //강의 검색
        public void SearchLecture(int searchType, List<InterestingLectureVO> inputInterestingLectureList)
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

        //강의 추가
        public void AddLecture(List<InterestingLectureVO> inputInterestingLectureList)
        {
            this.interestingLectureList = inputInterestingLectureList;
            List<InterestingLectureVO> afterAddList;
            afterAddList = addLecture.AddLectureInList(lectureList, interestingLectureList);

            if (afterAddList.Count == interestingLectureList.Count) //add가 제대로 안되었을때
                menu.InterstingLectureMenu(interestingLectureList);
            
            else
                menu.InterstingLectureMenu(afterAddList);
        }

        //강의 삭제
        public void RemoveLecture(List<InterestingLectureVO> inputInterestingLectureList)
        {
            this.interestingLectureList = inputInterestingLectureList;
            List<InterestingLectureVO> afterRemoveList;
            afterRemoveList = removeLecture.RemoveFromLectureList(lectureList, interestingLectureList);

            if (afterRemoveList.Count == interestingLectureList.Count) //remove 제대로 안되었을때
                menu.InterstingLectureMenu(interestingLectureList);
              
            else
                menu.InterstingLectureMenu(afterRemoveList);
        }

        //강의 조회
        public void JoinInterstingLecture(List<InterestingLectureVO> inputInterestingLectureList)
        {
            this.interestingLectureList = inputInterestingLectureList;
            joinLecture.JoinLectureList(inputInterestingLectureList);
            menu.InterstingLectureMenu(interestingLectureList);
        }
    }
}
