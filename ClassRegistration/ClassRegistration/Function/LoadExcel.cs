﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace ClassRegistration
{
    class LoadExcel
    {
        public Array GetExcel()
        {
            // Excel Application 객체 생성
            Excel.Application ExcelApp = new Excel.Application();

            // Workbook 객체 생성 및 파일 오픈
            Excel.Workbook workbook = ExcelApp.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\lectures.xlsx");

            // sheets에 읽어온 엑셀값을 넣기
            Excel.Sheets sheets = workbook.Sheets;

            // 특정 sheet의 값 가져오기
            Excel.Worksheet worksheet = sheets["강의시간표(schedule)"] as Excel.Worksheet;

            // 범위 설정
            Excel.Range cellRange = worksheet.get_Range("A1", "L167") as Excel.Range;

            // 설정한 범위만큼 데이터 담기
            Array data = cellRange.Cells.Value2;

            // 데이터 출력
            //Console.WriteLine(data.GetValue(1, 3));

            ExcelApp.Workbooks.Close();
            ExcelApp.Quit();

            return data;
        }
    }
}
