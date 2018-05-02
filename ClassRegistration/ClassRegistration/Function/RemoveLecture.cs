using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    /// <기능>
    /// 1. 관심과목 리스트에서 학수번호를 입력받아 해당 강의 리스트에서 삭제
    /// 2. 수강신청한 리스트에서 학수번호를 입력받아 해당 강의 리스트에서 삭제
    /// </기능>
    
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

        //관심과목 리스트에서 삭제 메소드
        public List<InterestingLectureVO> RemoveFromLectureList(List<LectureListVO> lectureList, List<InterestingLectureVO> interestingLectureList)
        {
            string inputLectureIndex;

            print.ShowLecture(interestingLectureList);
            print.InputMsg("학수번호");
            inputLectureIndex = Console.ReadLine();
            
            error = errorCheck.IsValidPattern(inputLectureIndex, "lectureIndex"); //정규표현식으로 학수번호 패턴인지 확인
            if (error == true)
            {
                print.ErrorMsg("잘못된 양식의 학수번호");
                return interestingLectureList;
            }

            error = errorCheck.IsValidLecture(interestingLectureList, inputLectureIndex);
            if(error == false) //장바구니에 없는 강의
            {
                print.ErrorMsg("관심과목 리스트에 없는 강의");
                return interestingLectureList;
            }
 
            interestingLectureList.RemoveAll(lecture => lecture.LectureIndex.Equals(inputLectureIndex)); //관심과목 리스트에서 삭제

            print.ShowLecture(interestingLectureList);
            print.CompleteMsg("관심과목 삭제");
            return interestingLectureList;
        }


        //수강신청한 리스트에서 삭제 메소드
        public List<RegisteredLectureVO> RemoveFromLectureList(List<LectureListVO> lectureList, List<RegisteredLectureVO> registeredLectureList)
        {
            string inputLectureIndex;

            print.ShowLecture(registeredLectureList);
            print.InputMsg("학수번호");
            inputLectureIndex = Console.ReadLine();
            
            error = errorCheck.IsValidPattern(inputLectureIndex, "lectureIndex");//학수번호 패턴 확인
            if (error == true)
            {
                print.ErrorMsg("잘못된 양식의 학수번호");
                return registeredLectureList;
            }

            error = errorCheck.IsValidLecture(registeredLectureList, inputLectureIndex);
            if (error == false) //장바구니에 없는 강의
            {
                print.ErrorMsg("관심과목 리스트에 없는 강의");
                return registeredLectureList;
            }

            registeredLectureList.RemoveAll(lecture => lecture.LectureIndex.Equals(inputLectureIndex)); //수강신청 리스트에서 삭제

            print.ShowLecture(registeredLectureList);
            print.CompleteMsg("수강신청한 과목 삭제");
            return registeredLectureList;
        }
    }
}
