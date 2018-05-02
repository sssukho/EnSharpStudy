using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    /// <기능>
    /// 1. 개설학과 전공으로 강의 검색
    /// 2. 강의명으로 검색
    /// 3. 학수번호로 검색
    /// 4. 학년으로 검색
    /// 5. 교수명으로 검색
    /// 6. 관심과목으로 검색
    /// </기능>
    
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

        //개설학과 전공으로 검색
        public void SearchByDepartment(List<LectureListVO> lectureList)
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

            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.Department.Equals(input));
            
            print.ShowLecture(foundList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        //학수번호로 검색
        public void SearchByLectureIndex(List<LectureListVO> lectureList)
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

            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.LectureIndex.Equals(input));
            print.ShowLecture(foundList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        //강의명으로 검색
        public void SearchByLectureName(List<LectureListVO> lectureList)
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

            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.LectureName.Equals(input));
            print.ShowLecture(foundList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        //학년으로 검색
        public void SearchByYear(List<LectureListVO> lectureList)
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

            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.Year.Equals(input));
            print.ShowLecture(foundList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        //교수명으로 검색
        public void SearchByProfessor(List<LectureListVO> lectureList)
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

            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.Professor.Equals(input));
            print.ShowLecture(foundList);
            print.PreviousMsg();
            Console.ReadLine();
        }

        //관심과목으로 검색
        public void SearchInterstingLecture(List<InterestingLectureVO> interestingLectureList)
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
