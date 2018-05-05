using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    class JoinTimeTable
    {
        Menu menu;
        List<LectureVO> registeredLectureList;
        JoinLecture joinLecture;
        Export export;
        Print print;
        ErrorCheck errorCheck;

        public JoinTimeTable(Menu menu, List<LectureVO> registeredLectureList, JoinLecture joinLecture, Export export, Print print, ErrorCheck errorCheck)
        {
            this.menu = menu;
            this.registeredLectureList = registeredLectureList;
            this.joinLecture = joinLecture;
            this.export = export;
            this.print = print;
            this.errorCheck = errorCheck;
        }

        public void JoinRegisteredTimeTable(List<LectureVO> totalLectureList, List<LectureVO> registeredLectureList, List<TimeTableLectureVO> timeTableLectureList)
        {
            joinLecture.JoinTimeTable(totalLectureList,registeredLectureList, timeTableLectureList);
            menu.JoinMenu();
        }

        public void ExportExcel(List<LectureVO> registeredLectureList, List<TimeTableLectureVO> timeTableLectureList)
        {
            timeTableLectureList.Clear();
            TimeTableLectureVO timeTableLecture;
            foreach (var item in registeredLectureList)
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
                    timeTableLecture = new TimeTableLectureVO(frontTime, backTime, pracFrontTime, pracBackTime, isPrac, monday, tuesday, wednesday, thursday, friday, item.Classroom, item.LectureName, pracDay);
                    timeTableLectureList.Add(timeTableLecture);
                }
            }
            export.ExportExcel(timeTableLectureList);
            menu.JoinMenu();
        }
    }
}
