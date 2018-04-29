using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    /// <summary>
    /// 관심과목 및 수강신청한 강의 조회
    /// </summary>
    class JoinLecture
    {
        Print print;
        ErrorCheck errorCheck;

        public JoinLecture(Print print, ErrorCheck errorCheck)
        {
            this.print = print;
            this.errorCheck = errorCheck;
        }

        public void JoinLectureList(List<InterestingLectureVO> interestingLectureList)
        {
            print.ShowLecture(interestingLectureList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        public void JoinLectureList(List<RegisteredLectureVO> registeredLectureList)
        {
            print.ShowLecture(registeredLectureList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        public void JoinTimeTable(List<RegisteredLectureVO> registeredLectureList)
        {
            print.ShowTimeTable(registeredLectureList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        public void ExportExcel(List<RegisteredLectureVO> registeredLectureList)
        {

        }
    }
}
