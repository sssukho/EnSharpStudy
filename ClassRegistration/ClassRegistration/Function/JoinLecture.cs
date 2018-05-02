using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ClassRegistration
{
    /// <기능>
    /// 1. 관심 과목 리스트 조회
    /// 2. 수강신청 과목 리스트 조회
    /// 3. 수강신청 과목 시간표로 조회
    /// </기능>
    class JoinLecture
    {
        Print print;
        ErrorCheck errorCheck;

        public JoinLecture(Print print, ErrorCheck errorCheck)
        {
            this.print = print;
            this.errorCheck = errorCheck;
        }

        //관심과목 리스트 조회
        public void JoinLectureList(List<InterestingLectureVO> interestingLectureList)
        {
            print.ShowLecture(interestingLectureList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        //수강신청 리스트 조회
        public void JoinLectureList(List<RegisteredLectureVO> registeredLectureList)
        {
            print.ShowLecture(registeredLectureList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        //수강신청한 강의들 시간표로 출력
        public void JoinTimeTable(List<RegisteredLectureVO> registeredLectureList)
        {
            print.ShowTimeTable(registeredLectureList);
            print.PreviousMsg();
            Console.ReadLine();
        }
    }
}
