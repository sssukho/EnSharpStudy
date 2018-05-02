using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ClassRegistration
{
    /// <기능>
    /// 1. 수강 신청한 강의 토대로 엑셀 새로운 파일로 내보내기
    /// </기능>
    class Export
    {
        Print print;
        List<RegisteredLectureVO> monday;
        List<RegisteredLectureVO> tuesday;
        List<RegisteredLectureVO> wednesday;
        List<RegisteredLectureVO> thursday;
        List<RegisteredLectureVO> friday;

        public Export(Print print, List<RegisteredLectureVO> monday, List<RegisteredLectureVO> tuesday, List<RegisteredLectureVO> wednesday, List<RegisteredLectureVO> thursday, List<RegisteredLectureVO> friday)
        {
            this.print = print;
            this.monday = monday;
            this.tuesday = tuesday;
            this.wednesday = wednesday;
            this.thursday = thursday;
            this.friday = friday;
        }

        public void ExportExcel(List<RegisteredLectureVO> registeredLectureList)
        {
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[1, 1] = "시간";
            xlWorkSheet.Cells[1, 2] = "월";
            xlWorkSheet.Cells[1, 3] = "화";
            xlWorkSheet.Cells[1, 4] = "수";
            xlWorkSheet.Cells[1, 5] = "목";
            xlWorkSheet.Cells[1, 6] = "금";
            xlWorkSheet.Cells[2, 1] = "09:00-09:30";
            xlWorkSheet.Cells[3, 1] = "09:30-10:00";
            xlWorkSheet.Cells[4, 1] = "10:00-10:30";
            xlWorkSheet.Cells[5, 1] = "10:30-11:00";
            xlWorkSheet.Cells[6, 1] = "11:00-11:30";
            xlWorkSheet.Cells[7, 1] = "11:30-12:00";
            xlWorkSheet.Cells[8, 1] = "12:00-12:30";
            xlWorkSheet.Cells[9, 1] = "12:30-13:00";
            xlWorkSheet.Cells[10, 1] = "13:00-13:30";
            xlWorkSheet.Cells[11, 1] = "13:30-14:00";
            xlWorkSheet.Cells[12, 1] = "14:00-14:30";
            xlWorkSheet.Cells[13, 1] = "14:30-15:00";
            xlWorkSheet.Cells[14, 1] = "15:00-15:30";
            xlWorkSheet.Cells[15, 1] = "15:30-16:00";
            xlWorkSheet.Cells[16, 1] = "16:00-16:30";
            xlWorkSheet.Cells[17, 1] = "16:30-17:00";
            xlWorkSheet.Cells[18, 1] = "17:00-17:30";
            xlWorkSheet.Cells[19, 1] = "17:30-18:00";
            xlWorkSheet.Cells[20, 1] = "18:00-18:30";
            xlWorkSheet.Cells[21, 1] = "18:30-19:00";
            xlWorkSheet.Cells[22, 1] = "19:00-19:30";
            xlWorkSheet.Cells[23, 1] = "19:30-20:00";
            xlWorkSheet.Cells[24, 1] = "20:00-20:30";
            xlWorkSheet.Cells[25, 1] = "20:30-21:00";

            monday.Clear();
            tuesday.Clear();
            wednesday.Clear();
            thursday.Clear();
            friday.Clear();

            string time;

            foreach (var item in registeredLectureList)
            {
                time = item.Time.ToString();
                if (time.Contains("월"))
                    monday.Add(item);
                if (time.Contains("화"))
                    tuesday.Add(item);
                if (time.Contains("수"))
                    wednesday.Add(item);
                if (time.Contains("목"))
                    thursday.Add(item);
                if (time.Contains("금"))
                    friday.Add(item);
            }
            //xlWorkSheet.Cells[i, 1].Value2
            xlWorkSheet = SetTable(xlWorkSheet, monday, tuesday, wednesday, thursday, friday);

            //document 디렉토리에 저장됨.
            xlWorkBook.SaveAs("2018-1학기시간표.xlsx", misValue, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue,
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));

            xlApp.Workbooks.Close();
            xlApp.Quit();

            Console.Clear();
            print.CompleteMsg("Document 폴더에 파일 저장");
        }

        public Excel.Worksheet SetTable(Excel.Worksheet xlWorkSheet, List<RegisteredLectureVO> monday, List<RegisteredLectureVO> tuesday, List<RegisteredLectureVO> wednesday, List<RegisteredLectureVO> thursday, List<RegisteredLectureVO> friday)
        {
            for (int i = 2; i < 26; i++)
            {
                xlWorkSheet = SetMonday(xlWorkSheet, xlWorkSheet.Cells[i, 1].Value2, i, monday);
                xlWorkSheet = SetTuesday(xlWorkSheet, xlWorkSheet.Cells[i, 1].Value2, i, tuesday);
                xlWorkSheet = SetWednesday(xlWorkSheet, xlWorkSheet.Cells[i, 1].Value2, i, wednesday);
                xlWorkSheet = SetThursday(xlWorkSheet, xlWorkSheet.Cells[i, 1].Value2, i, thursday);
                xlWorkSheet = SetFriday(xlWorkSheet, xlWorkSheet.Cells[i, 1].Value2, i, friday);
            }
            return xlWorkSheet;
        }

        public Excel.Worksheet SetMonday(Excel.Worksheet xlWorkSheet, string row, int index, List<RegisteredLectureVO> monday)
        {
            string itemFrontTime;
            string itemBackTime;
            string tableFrontTime;
            string tableBackTime;
            int frontime;
            int backtime;
            int tablefrontime;
            int tablebacktime;

            for (int j = 0; j < monday.Count; j++)
            {
                if (monday[j].Time.ToString().Length.Equals(12)) //하루인경우
                {
                    itemFrontTime = monday[j].Time.ToString().Remove(0, 1).Remove(5);
                    itemBackTime = monday[j].Time.ToString().Remove(0, 7);
                    tableFrontTime = xlWorkSheet.Cells[index, 1].Value2.Remove(5);
                    tableBackTime = xlWorkSheet.Cells[index, 1].Value2.Remove(0, 6);

                    frontime = int.Parse(itemFrontTime.Remove(2, 1));
                    backtime = int.Parse(itemBackTime.Remove(2, 1));
                    tablefrontime = int.Parse(tableFrontTime.Remove(2, 1));
                    tablebacktime = int.Parse(tableBackTime.Remove(2, 1));

                    DateTime backTime = Convert.ToDateTime("2018-01-01 " + itemBackTime);
                    DateTime frontTime = Convert.ToDateTime("2018-01-01 " + itemFrontTime);
                    TimeSpan timeDiff = backTime - frontTime;

                    if (timeDiff.Hours == 1) //1시간짜리 강의
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, monday, j, 2);
                    }
                }

                if (monday[j].Time.ToString().Length.Equals(13)) //이틀인경우
                {
                    itemFrontTime = monday[j].Time.ToString().Remove(0, 2).Remove(5);
                    itemBackTime = monday[j].Time.ToString().Remove(0, 8);
                    tableFrontTime = row.Remove(5);
                    tableBackTime = row.Remove(0, 6);

                    frontime = int.Parse(itemFrontTime.Remove(2, 1));
                    backtime = int.Parse(itemBackTime.Remove(2, 1));
                    tablefrontime = int.Parse(tableFrontTime.Remove(2, 1));
                    tablebacktime = int.Parse(tableBackTime.Remove(2, 1));

                    DateTime backTime = Convert.ToDateTime("2018-01-01 " + itemBackTime);
                    DateTime frontTime = Convert.ToDateTime("2018-01-01 " + itemFrontTime);
                    TimeSpan timeDiff = backTime - frontTime;

                    if (timeDiff.Hours == 1 && timeDiff.Minutes == 30) //1시간짜리 강의
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, monday, j, 2);
                    }

                    if (timeDiff.Hours == 2) //2시간짜리 강의
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, monday, j, 2);
                    }
                }

                if (monday[j].Time.ToString().Length.Equals(26)) //삼일인경우
                {
                    itemFrontTime = monday[j].Time.ToString().Remove(0, 15).Remove(5);
                    itemBackTime = monday[j].Time.ToString().Remove(0, 21);
                    tableFrontTime = xlWorkSheet.Cells[index, 1].Value2.Remove(5);
                    tableBackTime = xlWorkSheet.Cells[index, 1].Value2.Remove(0, 6);

                    frontime = int.Parse(itemFrontTime.Remove(2, 1));
                    backtime = int.Parse(itemBackTime.Remove(2, 1));
                    tablefrontime = int.Parse(tableFrontTime.Remove(2, 1));
                    tablebacktime = int.Parse(tableBackTime.Remove(2, 1));

                    DateTime backTime = Convert.ToDateTime("2018-01-01 " + itemBackTime);
                    DateTime frontTime = Convert.ToDateTime("2018-01-01 " + itemFrontTime);
                    TimeSpan timeDiff = backTime - frontTime;

                    if (timeDiff.Hours == 1 && timeDiff.Minutes == 30) //1시간짜리 강의
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, monday, j, 2);
                    }
                }
            }
            return xlWorkSheet;
        }

        public Excel.Worksheet SetTuesday(Excel.Worksheet xlWorkSheet, string row, int index, List<RegisteredLectureVO> tuesday)
        {
            string itemFrontTime;
            string itemBackTime;
            string tableFrontTime;
            string tableBackTime;
            int frontime;
            int backtime;
            int tablefrontime;
            int tablebacktime;

            for (int j = 0; j < tuesday.Count; j++)
            {
                if (tuesday[j].Time.ToString().Length.Equals(13)) //이틀
                {
                    itemFrontTime = tuesday[j].Time.ToString().Remove(0, 2).Remove(5);
                    itemBackTime = tuesday[j].Time.ToString().Remove(0, 8);
                    tableFrontTime = xlWorkSheet.Cells[index, 1].Value2.Remove(5);
                    tableBackTime = xlWorkSheet.Cells[index, 1].Value2.Remove(0, 6);

                    frontime = int.Parse(itemFrontTime.Remove(2, 1));
                    backtime = int.Parse(itemBackTime.Remove(2, 1));
                    tablefrontime = int.Parse(tableFrontTime.Remove(2, 1));
                    tablebacktime = int.Parse(tableBackTime.Remove(2, 1));

                    DateTime backTime = Convert.ToDateTime("2018-01-01 " + itemBackTime);
                    DateTime frontTime = Convert.ToDateTime("2018-01-01 " + itemFrontTime);
                    TimeSpan timeDiff = backTime - frontTime;

                    if (timeDiff.Hours == 1 && timeDiff.Minutes == 30) //1시간짜리 강의
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, tuesday, j, 3);
                    }

                    if (timeDiff.Hours == 2)
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, tuesday, j, 3);
                    }
                }

                if (tuesday[j].Time.ToString().Length.Equals(26)) //이틀인경우
                {
                    itemFrontTime = tuesday[j].Time.ToString().Remove(0, 15).Remove(5);
                    itemBackTime = tuesday[j].Time.ToString().Remove(0, 21);
                    tableFrontTime = row.Remove(5);
                    tableBackTime = row.Remove(0, 6);

                    frontime = int.Parse(itemFrontTime.Remove(2, 1));
                    backtime = int.Parse(itemBackTime.Remove(2, 1));
                    tablefrontime = int.Parse(tableFrontTime.Remove(2, 1));
                    tablebacktime = int.Parse(tableBackTime.Remove(2, 1));

                    DateTime backTime = Convert.ToDateTime("2018-01-01 " + itemBackTime);
                    DateTime frontTime = Convert.ToDateTime("2018-01-01 " + itemFrontTime);
                    TimeSpan timeDiff = backTime - frontTime;

                    if (timeDiff.Hours == 1 && timeDiff.Minutes == 30) //1시간 반짜리 강의
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, tuesday, j, 3);
                    }

                    if (timeDiff.Hours == 2) //2시간짜리 강의
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, tuesday, j, 3);
                    }
                }
            }
            return xlWorkSheet;
        }

        public Excel.Worksheet SetWednesday(Excel.Worksheet xlWorkSheet, string row, int index, List<RegisteredLectureVO> wednesday)
        {
            string itemFrontTime;
            string itemBackTime;
            string tableFrontTime;
            string tableBackTime;
            int frontime;
            int backtime;
            int tablefrontime;
            int tablebacktime;

            for (int j = 0; j < wednesday.Count; j++)
            {
                if (wednesday[j].Time.ToString().Length.Equals(12)) //하루
                {
                    itemFrontTime = wednesday[j].Time.ToString().Remove(0, 1).Remove(5);
                    itemBackTime = wednesday[j].Time.ToString().Remove(0, 7);
                    tableFrontTime = xlWorkSheet.Cells[index, 1].Value2.Remove(5);
                    tableBackTime = xlWorkSheet.Cells[index, 1].Value2.Remove(0, 6);

                    frontime = int.Parse(itemFrontTime.Remove(2, 1));
                    backtime = int.Parse(itemBackTime.Remove(2, 1));
                    tablefrontime = int.Parse(tableFrontTime.Remove(2, 1));
                    tablebacktime = int.Parse(tableBackTime.Remove(2, 1));

                    DateTime backTime = Convert.ToDateTime("2018-01-01 " + itemBackTime);
                    DateTime frontTime = Convert.ToDateTime("2018-01-01 " + itemFrontTime);
                    TimeSpan timeDiff = backTime - frontTime;

                    if (timeDiff.Hours == 1) //1시간짜리 강의
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, wednesday, j, 4);
                    }

                    if (timeDiff.Hours == 2)
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, wednesday, j, 4);
                    }
                }

                if (wednesday[j].Time.ToString().Length.Equals(13)) //이틀
                {
                    itemFrontTime = wednesday[j].Time.ToString().Remove(0, 2).Remove(5);
                    itemBackTime = wednesday[j].Time.ToString().Remove(0, 8);
                    tableFrontTime = xlWorkSheet.Cells[index, 1].Value2.Remove(5);
                    tableBackTime = xlWorkSheet.Cells[index, 1].Value2.Remove(0, 6);

                    frontime = int.Parse(itemFrontTime.Remove(2, 1));
                    backtime = int.Parse(itemBackTime.Remove(2, 1));
                    tablefrontime = int.Parse(tableFrontTime.Remove(2, 1));
                    tablebacktime = int.Parse(tableBackTime.Remove(2, 1));

                    DateTime backTime = Convert.ToDateTime("2018-01-01 " + itemBackTime);
                    DateTime frontTime = Convert.ToDateTime("2018-01-01 " + itemFrontTime);
                    TimeSpan timeDiff = backTime - frontTime;

                    if (timeDiff.Hours == 1 && timeDiff.Minutes == 30) //1시간짜리 강의
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, wednesday, j, 4);
                    }

                    if (timeDiff.Hours == 2)
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, wednesday, j, 4);
                    }
                }

                if (wednesday[j].Time.ToString().Length.Equals(26)) //삼일인경우
                {
                    itemFrontTime = wednesday[j].Time.ToString().Remove(0, 15).Remove(5);
                    itemBackTime = wednesday[j].Time.ToString().Remove(0, 21);
                    tableFrontTime = row.Remove(5);
                    tableBackTime = row.Remove(0, 6);

                    frontime = int.Parse(itemFrontTime.Remove(2, 1));
                    backtime = int.Parse(itemBackTime.Remove(2, 1));
                    tablefrontime = int.Parse(tableFrontTime.Remove(2, 1));
                    tablebacktime = int.Parse(tableBackTime.Remove(2, 1));

                    DateTime backTime = Convert.ToDateTime("2018-01-01 " + itemBackTime);
                    DateTime frontTime = Convert.ToDateTime("2018-01-01 " + itemFrontTime);
                    TimeSpan timeDiff = backTime - frontTime;

                    if (timeDiff.Hours == 1 && timeDiff.Minutes == 30) //1시간 반짜리 강의
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, wednesday, j, 4);
                    }
                }
            }
            return xlWorkSheet;
        }

        public Excel.Worksheet SetThursday(Excel.Worksheet xlWorkSheet, string row, int index, List<RegisteredLectureVO> thursday)
        {
            string itemFrontTime;
            string itemBackTime;
            string tableFrontTime;
            string tableBackTime;
            int frontime;
            int backtime;
            int tablefrontime;
            int tablebacktime;

            for (int j = 0; j < thursday.Count; j++)
            {
                if (thursday[j].Time.ToString().Length.Equals(13)) //이틀
                {
                    itemFrontTime = thursday[j].Time.ToString().Remove(0, 2).Remove(5);
                    itemBackTime = thursday[j].Time.ToString().Remove(0, 8);
                    tableFrontTime = xlWorkSheet.Cells[index, 1].Value2.Remove(5);
                    tableBackTime = xlWorkSheet.Cells[index, 1].Value2.Remove(0, 6);

                    frontime = int.Parse(itemFrontTime.Remove(2, 1));
                    backtime = int.Parse(itemBackTime.Remove(2, 1));
                    tablefrontime = int.Parse(tableFrontTime.Remove(2, 1));
                    tablebacktime = int.Parse(tableBackTime.Remove(2, 1));

                    DateTime backTime = Convert.ToDateTime("2018-01-01 " + itemBackTime);
                    DateTime frontTime = Convert.ToDateTime("2018-01-01 " + itemFrontTime);
                    TimeSpan timeDiff = backTime - frontTime;

                    if (timeDiff.Hours == 1 && timeDiff.Minutes == 30) //1시간짜리 강의
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, thursday, j, 5);
                    }

                    if (timeDiff.Hours == 2)
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, thursday, j, 5);
                    }
                }

                if (thursday[j].Time.ToString().Length.Equals(26)) //삼일인경우
                {
                    itemFrontTime = thursday[j].Time.ToString().Remove(0, 15).Remove(5);
                    itemBackTime = thursday[j].Time.ToString().Remove(0, 21);
                    tableFrontTime = row.Remove(5);
                    tableBackTime = row.Remove(0, 6);

                    frontime = int.Parse(itemFrontTime.Remove(2, 1));
                    backtime = int.Parse(itemBackTime.Remove(2, 1));
                    tablefrontime = int.Parse(tableFrontTime.Remove(2, 1));
                    tablebacktime = int.Parse(tableBackTime.Remove(2, 1));

                    DateTime backTime = Convert.ToDateTime("2018-01-01 " + itemBackTime);
                    DateTime frontTime = Convert.ToDateTime("2018-01-01 " + itemFrontTime);
                    TimeSpan timeDiff = backTime - frontTime;

                    if (timeDiff.Hours == 1 && timeDiff.Minutes == 30) //1시간 반짜리 강의
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, thursday, j, 5);
                    }

                    if (timeDiff.Hours == 2)
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, thursday, j, 5);
                    }
                }
            }
            return xlWorkSheet;
        }

        public Excel.Worksheet SetFriday(Excel.Worksheet xlWorkSheet, string row, int index, List<RegisteredLectureVO> friday)
        {
            string itemFrontTime;
            string itemBackTime;
            string tableFrontTime;
            string tableBackTime;
            int frontime;
            int backtime;
            int tablefrontime;
            int tablebacktime;

            for (int j = 0; j < friday.Count; j++)
            {
                if (friday[j].Time.ToString().Length.Equals(12)) //하루
                {
                    itemFrontTime = friday[j].Time.ToString().Remove(0, 1).Remove(5);
                    itemBackTime = friday[j].Time.ToString().Remove(0, 7);
                    tableFrontTime = xlWorkSheet.Cells[index, 1].Value2.Remove(5);
                    tableBackTime = xlWorkSheet.Cells[index, 1].Value2.Remove(0, 6);

                    frontime = int.Parse(itemFrontTime.Remove(2, 1));
                    backtime = int.Parse(itemBackTime.Remove(2, 1));
                    tablefrontime = int.Parse(tableFrontTime.Remove(2, 1));
                    tablebacktime = int.Parse(tableBackTime.Remove(2, 1));

                    DateTime backTime = Convert.ToDateTime("2018-01-01 " + itemBackTime);
                    DateTime frontTime = Convert.ToDateTime("2018-01-01 " + itemFrontTime);
                    TimeSpan timeDiff = backTime - frontTime;

                    if (timeDiff.Hours == 1) //1시간짜리 강의
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, friday, j, 6);
                    }

                    if (timeDiff.Hours == 3)
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, friday, j, 6);
                    }

                    if (timeDiff.Hours == 6)
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, friday, j, 6);
                    }
                }

                if (friday[j].Time.ToString().Length.Equals(13)) //이틀
                {
                    itemFrontTime = friday[j].Time.ToString().Remove(0, 2).Remove(5);
                    itemBackTime = friday[j].Time.ToString().Remove(0, 8);
                    tableFrontTime = xlWorkSheet.Cells[index, 1].Value2.Remove(5);
                    tableBackTime = xlWorkSheet.Cells[index, 1].Value2.Remove(0, 6);

                    frontime = int.Parse(itemFrontTime.Remove(2, 1));
                    backtime = int.Parse(itemBackTime.Remove(2, 1));
                    tablefrontime = int.Parse(tableFrontTime.Remove(2, 1));
                    tablebacktime = int.Parse(tableBackTime.Remove(2, 1));

                    DateTime backTime = Convert.ToDateTime("2018-01-01 " + itemBackTime);
                    DateTime frontTime = Convert.ToDateTime("2018-01-01 " + itemFrontTime);
                    TimeSpan timeDiff = backTime - frontTime;

                    if (timeDiff.Hours == 1 && timeDiff.Minutes == 30)
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, friday, j, 6);
                    }
                }

                if (friday[j].Time.ToString().Length.Equals(26)) //삼일인경우
                {
                    itemFrontTime = friday[j].Time.ToString().Remove(0, 15).Remove(5);
                    itemBackTime = friday[j].Time.ToString().Remove(0, 21);
                    tableFrontTime = row.Remove(5);
                    tableBackTime = row.Remove(0, 6);

                    frontime = int.Parse(itemFrontTime.Remove(2, 1));
                    backtime = int.Parse(itemBackTime.Remove(2, 1));
                    tablefrontime = int.Parse(tableFrontTime.Remove(2, 1));
                    tablebacktime = int.Parse(tableBackTime.Remove(2, 1));

                    DateTime backTime = Convert.ToDateTime("2018-01-01 " + itemBackTime);
                    DateTime frontTime = Convert.ToDateTime("2018-01-01 " + itemFrontTime);
                    TimeSpan timeDiff = backTime - frontTime;

                    if (timeDiff.Hours == 2) //1시간 반짜리 강의
                    {
                        xlWorkSheet = SetValue(xlWorkSheet, index, frontime, backtime, tablefrontime, tablebacktime, friday, j, 6);
                    }
                }
            }
            return xlWorkSheet;
        }

        public Excel.Worksheet SetValue(Excel.Worksheet xlWorkSheet, int sheetIndex, int frontTime, int backTime, int tableFrontTime, int tableBackTime, List<RegisteredLectureVO> day, int index, int dayType)
        {
            if (frontTime <= tableFrontTime && tableFrontTime < backTime)
            {
                if (backTime == tableBackTime)
                {
                    xlWorkSheet.Cells[sheetIndex, dayType] = day[index].Classroom;

                }
                else
                {
                    xlWorkSheet.Cells[sheetIndex, dayType] = day[index].LectureName;
                }
            }
            return xlWorkSheet;
        }
    }
}
