using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void SearchByDepartment(List<LectureListVO> lectureList)
        {
            print.ShowLecture(lectureList);
            print.InputMsg("개설학과 전공");
            input = Console.ReadLine(); //errorcheck

            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.Department.Equals(input));
            print.ShowLecture(foundList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        public void SearchByLectureIndex(List<LectureListVO> lectureList)
        {
            print.ShowLecture(lectureList);
            print.InputMsg("학수번호");
            input = Console.ReadLine(); //errocheck

            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.LectureIndex.Equals(input));
            print.ShowLecture(foundList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        public void SearchByLectureName(List<LectureListVO> lectureList)
        {
            print.ShowLecture(lectureList);
            print.InputMsg("교과목명");
            input = Console.ReadLine(); //errorCheck

            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.LectureName.Equals(input));
            print.ShowLecture(foundList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        public void SearchByYear(List<LectureListVO> lectureList)
        {
            print.ShowLecture(lectureList);
            print.InputMsg("학년");
            input = Console.ReadLine(); //errorCheck

            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.Year.Equals(input));
            print.ShowLecture(foundList);
            print.PreviousMsg();
            Console.ReadLine();

        }

        public void SearchByProfessor(List<LectureListVO> lectureList)
        {
            print.ShowLecture(lectureList);
            print.InputMsg("교수명");
            input = Console.ReadLine(); //errorCheck

            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.Professor.Equals(input));
            print.ShowLecture(foundList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        public void SearchInterstingLecture(List<LectureListVO> lectureList, List<InterestingLectureVO> interestingLectureList)
        {

        }
    }
}
