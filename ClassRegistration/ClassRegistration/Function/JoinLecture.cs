using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


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

            List<RegisteredLectureVO> monday = new List<RegisteredLectureVO>();
            List<RegisteredLectureVO> tuesday = new List<RegisteredLectureVO>();
            List<RegisteredLectureVO> wednesday = new List<RegisteredLectureVO>();
            List<RegisteredLectureVO> thursday = new List<RegisteredLectureVO>();
            List<RegisteredLectureVO> friday = new List<RegisteredLectureVO>();

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
            
          for(int i =2; i < 24; i++)
            { 
               xlWorkSheet = SetTable(xlWorkSheet, xlWorkSheet.Cells[i, 1].Value2, i, monday, tuesday, wednesday, thursday, friday);
            }

            //document 디렉토리에 저장됨.
            xlWorkBook.SaveAs("2018-1학기시간표.xlsx", misValue, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue,
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            
            xlApp.Workbooks.Close();
            xlApp.Quit();

            Console.Clear();
            print.CompleteMsg("Document 폴더에 파일 저장");
        }

        public Excel.Worksheet SetTable(Excel.Worksheet xlWorkSheet, string time, int index, List<RegisteredLectureVO> monday, List<RegisteredLectureVO> tuesday, List<RegisteredLectureVO> wednesday, List<RegisteredLectureVO> thursday, List<RegisteredLectureVO> friday)
        {
            string itemTime;
            foreach (var item in monday)
            {
                itemTime = item.Time.ToString().Remove(0, 2).Remove(5);
                if (time.Contains(itemTime)) 
                {
                    xlWorkSheet.Cells[index, 2] = item.LectureName;
                }
            }

            foreach(var item in tuesday)
            {
                itemTime = item.Time.ToString().Remove(0, 2).Remove(5);
                if(time.Contains(itemTime))
                {
                    xlWorkSheet.Cells[index, 3] = item.LectureName;
                }
            }

            foreach(var item in wednesday)
            {
                itemTime = item.Time.ToString().Remove(0, 2).Remove(5);
                if(time.Contains(itemTime))
                {
                    xlWorkSheet.Cells[index, 4] = item.LectureName;
                }
            }

            foreach(var item in thursday)
            {
                itemTime = item.Time.ToString().Remove(0, 2).Remove(5);
                if(time.Contains(itemTime))
                {
                    xlWorkSheet.Cells[index, 5] = item.LectureName;
                }
            }

            foreach(var item in friday)
            {
                itemTime = item.Time.ToString().Remove(0, 2).Remove(5);
                if(time.Contains(itemTime))
                {
                    xlWorkSheet.Cells[index, 6] = item.LectureName;
                }
            }
            return xlWorkSheet;
        }      
    }
}
