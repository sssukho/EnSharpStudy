using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ClassRegistration
{
    class LoadExcel
    {
        Excel.Application excelApp;
        Excel.Workbook workBook;
        Excel.Sheets sheets;
        Excel.Worksheet workSheet;

        public LoadExcel()
        {
            excelApp = new Excel.Application();
            workBook = excelApp.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\lectures.xlsx");
            sheets = workBook.Sheets;
            workSheet = sheets["강의시간표(schedule)"] as Excel.Worksheet;
        }

        public List<LectureListVO> AddData()
        {
            List<LectureListVO> lectureList = new List<LectureListVO>();
            Excel.Range range = workSheet.get_Range("B2", "L167");
            Array data = range.Cells.Value2;

            for (int i = 1; i < 167; i++)
            {

                lectureList.Add(new LectureListVO(data.GetValue(i, 1), data.GetValue(i, 2), data.GetValue(i, 3), data.GetValue(i, 4), data.GetValue(i, 5), data.GetValue(i, 6), data.GetValue(i, 7), data.GetValue(i, 8), data.GetValue(i, 9), data.GetValue(i, 10), data.GetValue(i, 11)));
            }
           
            excelApp.Workbooks.Close();
            excelApp.Quit();
            return lectureList;
        }
    }
}
