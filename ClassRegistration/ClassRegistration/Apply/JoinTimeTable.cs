﻿using System;
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
        Export export;
        Print print;
        ErrorCheck errorCheck;

        public JoinTimeTable(Menu menu, List<RegisteredLectureVO> registeredLectureList, JoinLecture joinLecture, Export export, Print print, ErrorCheck errorCheck)
        {
            this.menu = menu;
            this.registeredLectureList = registeredLectureList;
            this.joinLecture = joinLecture;
            this.export = export;
            this.print = print;
            this.errorCheck = errorCheck;
        }

        //콘솔 상에서 시간표 출력
        public void JoinRegisteredTimeTable(List<RegisteredLectureVO> registeredLectureList)
        {
            joinLecture.JoinTimeTable(registeredLectureList);
            menu.JoinMenu();
        }

        //엑셀로 내보내기
        public void ExportExcel(List<RegisteredLectureVO> registeredLectureList)
        {
            export.ExportExcel(registeredLectureList);
            menu.JoinMenu();
        }
    }
}
