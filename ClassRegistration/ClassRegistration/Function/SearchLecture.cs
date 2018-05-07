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
        bool error;

        public SearchLecture(Print print, ErrorCheck errorCheck)
        {
            this.print = print;
            this.errorCheck = errorCheck;
        }

        public void SearchByDepartment(List<LectureVO> lectureList)
        {
            print.ShowLecture(lectureList);
            print.InputMsg("개설학과 전공");
            input = Console.ReadLine();
            error = errorCheck.IsValidPattern(input, "department");
            if(error == true)
            {
                print.ErrorMsg("잘못된 양식의 개설학과전공");
                return;
            }

            List<LectureVO> foundList = lectureList.FindAll(lecture => lecture.Department.Equals(input));
            
            print.ShowLecture(foundList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        public void SearchByLectureIndex(List<LectureVO> lectureList)
        {
            print.ShowLecture(lectureList);
            print.InputMsg("학수번호");
            input = Console.ReadLine();
            error = errorCheck.IsValidPattern(input, "lectureIndex");
            if(error == true)
            {
                print.ErrorMsg("잘못된 양식의 학수번호");
                return;
            }

            List<LectureVO> foundList = lectureList.FindAll(lecture => lecture.LectureIndex.Equals(input));
            print.ShowLecture(foundList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        public void SearchByLectureName(List<LectureVO> lectureList)
        {
            print.ShowLecture(lectureList);
            print.InputMsg("교과목명");
            input = Console.ReadLine();
            error = errorCheck.IsValidPattern(input, "lectureName");
            if(error == true)
            {
                print.ErrorMsg("잘못된 양식의 교과목명");
                return;
            }

            List<LectureVO> foundList = lectureList.FindAll(lecture => lecture.LectureName.Equals(input));
            print.ShowLecture(foundList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        public void SearchByYear(List<LectureVO> lectureList)
        {
            print.ShowLecture(lectureList);
            print.InputMsg("학년");
            input = Console.ReadLine();
            error = errorCheck.IsValidPattern(input, "grade");
            if(error == true)
            {
                print.ErrorMsg("잘못된 양식의 학년");
                return;
            }

            List<LectureVO> foundList = lectureList.FindAll(lecture => lecture.Year.Equals(input));
            print.ShowLecture(foundList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        public void SearchByProfessor(List<LectureVO> lectureList)
        {
            print.ShowLecture(lectureList);
            print.InputMsg("교수명");
            input = Console.ReadLine();
            error = errorCheck.IsValidPattern(input, "professor");

            if (error == true)
            {
                print.ErrorMsg("잘못된 양식의 교수명");
                return;
            }

            List<LectureVO> foundList = lectureList.FindAll(lecture => lecture.Professor.Equals(input));
            print.ShowLecture(foundList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        public void SearchInterstingLecture(List<LectureVO> interestingLectureList)
        {
            if(interestingLectureList == null)
            {
                print.ErrorMsg("비어있는 관심과목 리스트");
                return;
            }
            print.ShowLecture(interestingLectureList);
            print.PreviousMsg();
            Console.ReadLine();
        }
    }
}
