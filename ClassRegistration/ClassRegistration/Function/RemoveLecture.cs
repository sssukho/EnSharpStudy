using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    class RemoveLecture
    {
        Print print;
        ErrorCheck errorCheck;

        bool error;

        public RemoveLecture(Print print, ErrorCheck errorCheck)
        {
            this.print = print;
            this.errorCheck = errorCheck;
        }

        public List<InterestingLectureVO> RemoveLectureList(List<LectureListVO> lectureList, List<InterestingLectureVO> interestingLectureList)
        {
            string inputLectureIndex;

            print.ShowLecture(interestingLectureList);
            print.InputMsg("학수번호");
            inputLectureIndex = Console.ReadLine();

            error = errorCheck.IsValidLecture(interestingLectureList, inputLectureIndex);
            if(error == false) //장바구니에 없는 강의
            {
                print.ErrorMsg("관심과목 리스트에 없는 강의");
                return interestingLectureList;
            }

            //관심과목 리스트에서 삭제
            interestingLectureList.RemoveAll(lecture => lecture.LectureIndex.Equals(inputLectureIndex));

            return interestingLectureList;
        }
    }
}
