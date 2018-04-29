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
        List<RegisteredLectureVO> registeredLectureList;
        JoinLecture joinLecture;
        Print print;
        ErrorCheck errorCheck;

        public JoinTimeTable(Menu menu, List<RegisteredLectureVO> registeredLectureList, JoinLecture joinLecture, Print print, ErrorCheck errorCheck)
        {
            this.menu = menu;
            this.registeredLectureList = registeredLectureList;
            this.joinLecture = joinLecture;
            this.print = print;
            this.errorCheck = errorCheck;
        }

        public void JoinRegisteredTimeTable(List<RegisteredLectureVO> registeredLectureList)
        {
            joinLecture.JoinTimeTable(registeredLectureList);
            menu.JoinMenu();
        }

        public void ExportExcel(List<RegisteredLectureVO> registeredLectureList)
        {
            joinLecture.ExportExcel(registeredLectureList);
            menu.JoinMenu();
        }
    }
}
