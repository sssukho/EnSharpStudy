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

        public void JoinLectureList(List<LectureVO> inputLectureList)
        {
            print.ShowLecture(inputLectureList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        public void JoinTimeTable(List<LectureVO> TotalLectureList, List<LectureVO> registeredLectureList, List<TimeTableLectureVO> timeTableLectureList)
        {
            TimeTableLectureVO timeTableLecture;
            foreach(var item in registeredLectureList)
            {
                int frontTime;
                int backTime;
                int pracFrontTime;
                int pracBackTime;
                bool isPrac = false;
                bool monday = false;
                bool tuesday = false;
                bool wednesday = false;
                bool thursday = false;
                bool friday = false;
                string pracDay;

                if (item.Time.Length == 12)
                {
                    frontTime = int.Parse(item.Time.Remove(0, 1).Remove(5).Remove(2, 1));
                    backTime = int.Parse(item.Time.Remove(0, 7).Remove(2, 1));
                    pracFrontTime = 0;
                    pracBackTime = 0;
                    isPrac = false;
                    if (item.Time.Contains("월")) monday = true;
                    if (item.Time.Contains("화")) tuesday = true;
                    if (item.Time.Contains("수")) wednesday = true;
                    if (item.Time.Contains("목")) thursday = true;
                    if (item.Time.Contains("금")) friday = true;
                    pracDay = "핳";
                    timeTableLecture = new TimeTableLectureVO(frontTime, backTime, pracFrontTime, pracBackTime, isPrac, monday, tuesday, wednesday, thursday, friday, item.Classroom, item.LectureName, pracDay);
                    timeTableLectureList.Add(timeTableLecture);
                }

                else if (item.Time.Length == 13)
                {
                    frontTime = int.Parse(item.Time.Remove(0, 2).Remove(5).Remove(2, 1));
                    backTime = int.Parse(item.Time.Remove(0, 8).Remove(2, 1));
                    pracFrontTime = 0;
                    pracBackTime = 0;
                    isPrac = false;
                    if (item.Time.Contains("월")) monday = true;
                    if (item.Time.Contains("화")) tuesday = true;
                    if (item.Time.Contains("수")) wednesday = true;
                    if (item.Time.Contains("목")) thursday = true;
                    if (item.Time.Contains("금")) friday = true;
                    pracDay = "핳";
                    timeTableLecture = new TimeTableLectureVO(frontTime, backTime, pracFrontTime, pracBackTime, isPrac, monday, tuesday, wednesday, thursday, friday, item.Classroom, item.LectureName, pracDay);
                    timeTableLectureList.Add(timeTableLecture);
                }

                else if (item.Time.Length == 26)
                {
                    frontTime = int.Parse(item.Time.Remove(0, 2).Remove(5).Remove(2, 1));
                    backTime = int.Parse(item.Time.Remove(0, 8).Remove(5).Remove(2, 1));
                    pracFrontTime = int.Parse(item.Time.Remove(0, 15).Remove(5).Remove(2, 1));
                    pracBackTime = int.Parse(item.Time.Remove(0, 21).Remove(2, 1));
                    isPrac = true;
                    pracDay = item.Time.Remove(0, 14).Remove(1);
                    
                    if (item.Time.Remove(3).Contains("월")) monday = true;
                    if (item.Time.Remove(3).Contains("화")) tuesday = true;
                    if (item.Time.Remove(3).Contains("수")) wednesday = true;
                    if (item.Time.Remove(3).Contains("목")) thursday = true;
                    if (item.Time.Remove(3).Contains("금")) friday = true;
                    timeTableLecture = new TimeTableLectureVO(frontTime, backTime, pracFrontTime, pracBackTime, isPrac, monday, tuesday, wednesday, thursday, friday, item.Classroom, item.LectureName,pracDay);
                    timeTableLectureList.Add(timeTableLecture);
                }
            }

            print.ShowTimeTable(timeTableLectureList);
            print.PreviousMsg();
            timeTableLectureList.Clear();
            Console.ReadLine();
        }
    }
}
