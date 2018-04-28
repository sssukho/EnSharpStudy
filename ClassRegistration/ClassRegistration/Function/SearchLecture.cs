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
        Print print;
        ErrorCheck errorCheck;

        string input;

        public SearchLecture(Print print, ErrorCheck errorCheck)
        {
            this.print = print;
            this.errorCheck = errorCheck;
        }

        public void SearchDepartment(List<LectureListVO> lectureList)
        {
            print.ShowLecture(lectureList);
            print.InputMsg("개설학과 전공");
            input = Console.ReadLine(); //errorcheck

            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.Department.Equals(input));
            print.ShowLecture(foundList);
        }

        public void SearchLectureIndex(List<LectureListVO> lectureList)
        {
            Console.Clear();
            print.InputMsg("학수번호");
            input = Console.ReadLine(); //errocheck

            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.LectureIndex.Equals(input));
            print.ShowLecture(foundList);
        }

        public void SearchLectureName(List<LectureListVO> lectureList)
        {
            Console.Clear();
            print.InputMsg("교과목명");
            input = Console.ReadLine();

            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.LectureName.Equals(input));
            print.ShowLecture(foundList);
        }

        public void SearchYear(List<LectureListVO> lectureList)
        {
            Console.Clear();
            print.InputMsg("학년");
            input = Console.ReadLine();

            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.Year.Equals(input));
            print.ShowLecture(foundList);
        }

        public void SearchProfessor(List<LectureListVO> lectureList)
        {
            Console.Clear();
            print.InputMsg("교수명");
            input = Console.ReadLine();

            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.Professor.Equals(input));
            print.ShowLecture(foundList);
        }

        public void SearchInterstingLecture(List<LectureListVO> lectureList)
        {

        }
    }
}
