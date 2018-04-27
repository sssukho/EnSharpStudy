using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{

    class RegisterLecture
    {
        Menu menu;
        List<RegisteredLectureVO> registeredLectureList;
        List<LectureListVO> lectureList;
        AddLecture addLecture;
        JoinLecture joinLecture;
        RemoveLecture removeLecture;
        SearchLecture searchLecture;
        Print print;
        ErrorCheck errorCheck;


        public RegisterLecture(Menu menu, List<RegisteredLectureVO> registeredLectureList, List<LectureListVO> lectureList, AddLecture addLecture, JoinLecture joinLecture, RemoveLecture removeLecture, SearchLecture searchLecture, Print print, ErrorCheck errorCheck)
        {
            this.menu = menu;
            this.registeredLectureList = registeredLectureList;
            this.lectureList = lectureList;
            this.addLecture = addLecture;
            this.joinLecture = joinLecture;
            this.removeLecture = removeLecture;
            this.searchLecture = searchLecture;
            this.print = print;
            this.errorCheck = errorCheck;
        }

        public void SearchLecture(int searchType)
        {
            
        }

        public void AddLecture()
        {

        }

        public void RemoveLecture()
        {

        }

        public void JoinRegisterLecture()
        {

        }
    }
}
