using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ClassRegistration
{
    class Export
    {
        Print print;

        public Export(Print print)
        {
            this.print = print;
        }

        public void ExportExcel(List<TimeTableLectureVO> timeTableLectureList)
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
            
            xlWorkSheet = SetTable(xlWorkSheet, timeTableLectureList);

            //document 디렉토리에 저장됨.
            xlWorkBook.SaveAs("2018-1학기시간표.xlsx", misValue, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue,
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));

            xlApp.Workbooks.Close();
            xlApp.Quit();

            Console.Clear();
            print.CompleteMsg("Document 폴더에 파일 저장");
        }

        public Excel.Worksheet SetTable(Excel.Worksheet xlWorkSheet, List<TimeTableLectureVO> timeTableLectureList)
        {
            int tableFrontTime;
            int tableBackTime;
            for (int i = 2; i < 26; i++)
            {
                tableFrontTime = int.Parse(xlWorkSheet.Cells[i, 1].Value2.Remove(5).Remove(2,1));
                tableBackTime = int.Parse(xlWorkSheet.Cells[i, 1].Value2.Remove(0, 6).Remove(2,1));

                for (int j = 0; j < timeTableLectureList.Count; j++)
                {
                    if (timeTableLectureList[j].Monday == true)
                    {
                        SetValue(xlWorkSheet, i, timeTableLectureList[j].FrontTime, timeTableLectureList[j].BackTime, tableFrontTime, tableBackTime, timeTableLectureList[j].Classroom, timeTableLectureList[j].LectureName, 2);
                    }

                    if (timeTableLectureList[j].IsPrac == true && timeTableLectureList[j].PracDay.Equals("월"))
                    {
                        SetValue(xlWorkSheet, i, timeTableLectureList[j].PracFrontTime, timeTableLectureList[j].PracBackTime, tableFrontTime, tableBackTime, timeTableLectureList[j].Classroom, timeTableLectureList[j].LectureName, 2);
                    }

                    if (timeTableLectureList[j].Tuesday == true)
                    {
                        SetValue(xlWorkSheet, i, timeTableLectureList[j].FrontTime, timeTableLectureList[j].BackTime, tableFrontTime, tableBackTime, timeTableLectureList[j].Classroom, timeTableLectureList[j].LectureName, 3);
                    }

                    if (timeTableLectureList[j].IsPrac == true && timeTableLectureList[j].PracDay.Equals("화"))
                    {
                        SetValue(xlWorkSheet, i, timeTableLectureList[j].PracFrontTime, timeTableLectureList[j].PracBackTime, tableFrontTime, tableBackTime, timeTableLectureList[j].Classroom, timeTableLectureList[j].LectureName, 3);
                    }

                    if (timeTableLectureList[j].Wednesday == true)
                    {
                        SetValue(xlWorkSheet, i, timeTableLectureList[j].FrontTime, timeTableLectureList[j].BackTime, tableFrontTime, tableBackTime, timeTableLectureList[j].Classroom, timeTableLectureList[j].LectureName, 4);
                    }

                    if (timeTableLectureList[j].IsPrac == true && timeTableLectureList[j].PracDay.Equals("수"))
                    {
                        SetValue(xlWorkSheet, i, timeTableLectureList[j].PracFrontTime, timeTableLectureList[j].PracBackTime, tableFrontTime, tableBackTime, timeTableLectureList[j].Classroom, timeTableLectureList[j].LectureName, 4);
                    }

                    if (timeTableLectureList[j].Thursday == true)
                    {
                        SetValue(xlWorkSheet, i, timeTableLectureList[j].FrontTime, timeTableLectureList[j].BackTime, tableFrontTime, tableBackTime, timeTableLectureList[j].Classroom, timeTableLectureList[j].LectureName, 5);
                    }

                    if (timeTableLectureList[j].IsPrac == true && timeTableLectureList[j].PracDay.Equals("목"))
                    {
                        SetValue(xlWorkSheet, i, timeTableLectureList[j].PracFrontTime, timeTableLectureList[j].PracBackTime, tableFrontTime, tableBackTime, timeTableLectureList[j].Classroom, timeTableLectureList[j].LectureName, 5);
                    }

                    if (timeTableLectureList[j].Friday == true)
                    {
                        SetValue(xlWorkSheet, i, timeTableLectureList[j].FrontTime, timeTableLectureList[j].BackTime, tableFrontTime, tableBackTime, timeTableLectureList[j].Classroom, timeTableLectureList[j].LectureName, 6);
                    }

                    if (timeTableLectureList[j].IsPrac == true && timeTableLectureList[j].PracDay.Equals("금"))
                    {
                        SetValue(xlWorkSheet, i, timeTableLectureList[j].PracFrontTime, timeTableLectureList[j].PracBackTime, tableFrontTime, tableBackTime, timeTableLectureList[j].Classroom, timeTableLectureList[j].LectureName, 6);
                    }
                }
            }
            return xlWorkSheet;
        }

        public Excel.Worksheet SetValue(Excel.Worksheet xlWorkSheet, int sheetIndex, int frontTime, int backTime, int tableFrontTime, int tableBackTime, string classroom, string lectureName, int dayType)
        {
            if (frontTime <= tableFrontTime && tableFrontTime < backTime)
            {
                if (backTime == tableBackTime)
                    xlWorkSheet.Cells[sheetIndex, dayType] = classroom;

                else
                    xlWorkSheet.Cells[sheetIndex, dayType] = lectureName;
            }
            return xlWorkSheet;
        }
    }
}
