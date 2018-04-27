using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ClassRegistration
{
    class SearchLecture
    {
        Excel.Application excelApp;
        Excel.Workbook workBook;
        Excel.Sheets sheets;
        Excel.Worksheet workSheet;
        Excel.Range cellRange;
        Array data;

        public SearchLecture()
        {
            excelApp = new Excel.Application();
            workBook = excelApp.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\lectures.xlsx");
            sheets = workBook.Sheets;
            workSheet = sheets["강의시간표(schedule)"] as Excel.Worksheet;
        }

        public void SearchDepartment()
        {
            Print print = new Print();
            string department;
            print.InputMsg("개설학과 전공");
            department = Console.ReadLine();
            object missing = System.Reflection.Missing.Value;
            cellRange = workSheet.get_Range("B1", "L167");

            Excel.Range currentFind = cellRange.Find(department, missing,
                           Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues,
                           Microsoft.Office.Interop.Excel.XlLookAt.xlPart,
                           Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows,
                           Microsoft.Office.Interop.Excel.XlSearchDirection.xlNext, false, missing, missing);
            Excel.Range firstFind = null;

            while(currentFind != null)
            {
                if (firstFind == null)
                {
                    firstFind = currentFind;
                }

                else if(currentFind.get_Address(Excel.XlReferenceStyle.xlA1) == firstFind.get_Address(Excel.XlReferenceStyle.xlA1))
                {
                    break;
                }
            }
            data = currentFind.Cells.Value2;
            foreach(var item in data)
            {
                Console.WriteLine(item);
            }
            //print.ShowLecture(data);
        }

        public void SearchLectureIndex()
        {

        }

        public void SearchLectureName()
        {

        }

        public void SearchYear()
        {

        }

        public void SearchProfessor()
        {

        }

        public void SearchInterstingLecture()
        {

        }
    }
}
