using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    class Program
    {
        /// <summary>
        /// 불러오는 엑셀 파일명 : lecures.xlsx
        /// sheet 이름 : 강의시간표(schedule)
        /// 바탕화면에 있는 엑셀 파일을 불러오는 방식(엑셀 파일이 바탕화면에 위치해 있어야함)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Clear();   
            new Menu();
        }
    }
}
