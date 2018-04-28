using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    class AddLecture
    {
        Print print;
        ErrorCheck errorCheck;

        bool error;

        public AddLecture(Print print, ErrorCheck errorCheck)
        {
            this.print = print;
            this.errorCheck = errorCheck;
        }

        //다른과 학수번호 중복되는거 추가해야함
        public List<InterestingLectureVO> AddLectureInList(List<LectureListVO> lectureList, List<InterestingLectureVO> interestingLectureList)
        {
            Console.Clear();

            string inputLectureIndex;
            string inputClassIndex;

            error = errorCheck.IsValidGrade(interestingLectureList);
            if (error == true)
            {
                print.ErrorMsg("학점 초과");
                return interestingLectureList;
            }

            print.ShowLecture(lectureList);
            print.InputMsg("학수번호");
            
            inputLectureIndex = Console.ReadLine(); //입력 양식 체크

            error = errorCheck.IsValidLecture(interestingLectureList, inputLectureIndex);
            if (error == true)
            {
                print.ErrorMsg("이미 추가된 강의");
                return interestingLectureList;
            }

            //일치하는 학수번호 강의 리스트 출력
            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.LectureIndex.Equals(inputLectureIndex));
            print.ShowLecture(foundList);

            print.InputMsg("분반");
            inputClassIndex = Console.ReadLine(); //입력 양식 체크
            
            error = errorCheck.IsValidTime(interestingLectureList, foundList, inputClassIndex);
            if(error == true)
            {
                print.ErrorMsg("시간 중복 강의");
                return interestingLectureList;
            }

            //관심과목 리스트에 추가
            LectureListVO newLecture = foundList.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex));
            interestingLectureList.Add(new InterestingLectureVO(newLecture.Department, newLecture.LectureIndex, newLecture.ClassIndex, 
                newLecture.LectureName, newLecture.Division, newLecture.Year, newLecture.Grade, newLecture.Time, newLecture.Classroom, newLecture.Professor, newLecture.Language));

            print.ShowLecture(interestingLectureList);
            print.CompleteMsg("관심과목 추가");
            return interestingLectureList;
        }
    }
}
