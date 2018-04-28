using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    class ErrorCheck
    {
        //한번에 묶는거 생각해볼것 제네릭으로
        /*
        public bool IsValidGrade<T>(List<T> inputList)
        {
            int currentGrade = 0;
            
            if(inputList.GetType() is List<InterestingLectureVO>)
            {
                
                for(int i = 0; i < inputList.Count; i++)
                {
                    int grade;
                    grade = int.Parse(inputList.ToString(lecture=>lecture.)
                }
                

                if (currentGrade > 24)
                    return true;

                return false;
            }
                
        }*/

        public bool IsValidGrade(List<InterestingLectureVO> interestingLectureList)
        {
            int currentGrade = 0;
            foreach (var item in interestingLectureList)
            {
                currentGrade = currentGrade + int.Parse(item.Grade.ToString());
            }

            if (currentGrade > 24)
                return true;

            return false;
        }

        public bool IsValidGrade(List<RegisteredLectureVO> registeredLectureList)
        {
            int currentGrade = 0;
            foreach (var item in registeredLectureList)
            {
                currentGrade = currentGrade + int.Parse(item.Grade.ToString());
            }

            if (currentGrade > 21)
                return true;

            return false;
        }

        public bool IsValidLecture(List<InterestingLectureVO> interestingLectureList, string inputLectureIndex)
        {
            if (interestingLectureList.Exists(lecture =>
            lecture.LectureIndex.Equals(inputLectureIndex) == true))
                return true;

            return false;
        }

        public bool IsValidLecture(List<RegisteredLectureVO> registeredLectureList, string inputLectureIndex)
        {
            if (registeredLectureList.Exists(lecture =>
             lecture.LectureIndex.Equals(inputLectureIndex) == true))
                return true;

            return false;
        }

        //하루만 겹치는 거 추가 수정할 것
        public bool IsValidTime(List<InterestingLectureVO> interestingLectureList, List<LectureListVO> foundLectureList, string inputClassIndex)
        {
            string findTime = foundLectureList.Find(lecture =>
            lecture.ClassIndex.Equals(inputClassIndex)).Time.ToString();

            if (interestingLectureList.Exists(lecture =>
             lecture.Time.Equals(findTime)) == true)
            {
                return true;
            }
            return false;
        }

        public bool IsValidTime(List<RegisteredLectureVO> registeredLectureList, string inputClassIndex)
        {


            return false;
        }
    }
}
