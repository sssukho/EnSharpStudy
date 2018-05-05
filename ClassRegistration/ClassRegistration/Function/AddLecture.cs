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

        public List<LectureVO> AddLectureInList(List<LectureVO> lectureList, List<LectureVO> inputLectureList, string type)
        {
            Console.Clear();

            string inputLectureIndex;
            string inputClassIndex;
            string inputDepartment;

            print.ShowLecture(lectureList);
            print.InputMsg("학수번호");
            inputLectureIndex = Console.ReadLine();
            error = errorCheck.IsValidPattern(inputLectureIndex, "lectureIndex");
            if (error == true)
            {
                print.ErrorMsg("잘못된 양식의 학수번호");
                return inputLectureList;
            }

            error = errorCheck.IsValidLecture(inputLectureList, inputLectureIndex);
            if (error == true)
            {
                print.ErrorMsg("이미 추가된 강의");
                return inputLectureList;
            }

            //일치하는 학수번호 강의 리스트 출력
            List<LectureVO> foundList = lectureList.FindAll(lecture => lecture.LectureIndex.Equals(inputLectureIndex));
            print.ShowLecture(foundList);

            //학수번호 같은데 전공이 다른 과목
            if (CheckAnotherDepartment(foundList) == true)
            {
                List<LectureVO> computerEngineering = foundList.FindAll(lecture => lecture.Department.Equals("컴퓨터공학과"));
                List<LectureVO> informationProtection = foundList.FindAll(lecture => lecture.Department.Equals("정보보호학과")); ;
                List<LectureVO> digitalContents = foundList.FindAll(lecture => lecture.Department.Equals("디지털콘텐츠학과"));
                List<LectureVO> softWare = foundList.FindAll(lecture => lecture.Department.Equals("소프트웨어학과"));
                print.InputMsg("개설학과전공");
                inputDepartment = Console.ReadLine();
                error = errorCheck.IsValidPattern(inputDepartment, "department");
                if (error == true)
                {
                    print.ErrorMsg("잘못된 양식의 개설학과전공");
                    return inputLectureList;
                }

                inputLectureList = AddLectureByDepartment(inputDepartment, foundList, inputLectureList, computerEngineering, informationProtection, digitalContents, softWare, type);
                return inputLectureList;
            }

            print.InputMsg("분반");
            inputClassIndex = Console.ReadLine();
            error = errorCheck.IsValidPattern(inputClassIndex, "classIndex");
            if (error == true)
            {
                print.ErrorMsg("잘못된 양식의 분반");
                return inputLectureList;
            }

            //리스트에 이미 시간이 중복되는 강의가 있는지
            error = errorCheck.IsValidTime(inputLectureList, foundList, inputClassIndex);
            if (error == true)
            {
                print.ErrorMsg("시간 중복 강의");
                return inputLectureList;
            }

            double toGrade = double.Parse(foundList[0].Grade);

            //추가직전에 학점초과 되는지 여부 체크
            error = errorCheck.IsValidGrade(inputLectureList, type, toGrade);
            if (error == true)
            {
                print.ErrorMsg("학점 초과");
                return inputLectureList;
            }

            //리스트에 추가
            LectureVO newLecture = foundList.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex));
            inputLectureList.Add(new LectureVO(newLecture.Department, newLecture.LectureIndex,
                newLecture.ClassIndex, newLecture.LectureName, newLecture.Division, newLecture.Year,
                newLecture.Grade, newLecture.Time, newLecture.Classroom, newLecture.Professor, newLecture.Language));

            print.ShowLecture(inputLectureList);
            print.CompleteMsg(type + " 추가");
            return inputLectureList;
        }

        public bool CheckAnotherDepartment(List<LectureVO> foundList)
        {
            string currentDepartment;
            currentDepartment = foundList[0].Department.ToString();
            for (int i = 1; i < foundList.Count; i++)
            {
                if (currentDepartment != foundList[i].Department.ToString())
                    return true;
            }

            return false;
        }

        public List<LectureVO> AddLectureByDepartment(string inputDepartment, List<LectureVO> foundLectureList, List<LectureVO> inputLectureList, List<LectureVO> computerEngineering, List<LectureVO> informationProtection, List<LectureVO> digitalContents, List<LectureVO> softWare, string type)
        {
            string inputClassIndex;
            double toGrade;
            if (inputDepartment.Equals("컴퓨터공학과"))
            {
                print.ShowLecture(computerEngineering);
                print.InputMsg("분반");
                inputClassIndex = Console.ReadLine();
                error = errorCheck.IsValidPattern(inputClassIndex, "classIndex");
                if (error == true)
                {
                    print.ErrorMsg("잘못된 양식의 분반");
                    return inputLectureList;
                }

                if (foundLectureList.Count == 0)
                    toGrade = 0;
                else
                {
                    toGrade = double.Parse(foundLectureList[0].Grade);
                }
                error = errorCheck.IsValidGrade(inputLectureList, type, toGrade);
                if (error == true)
                {
                    print.ErrorMsg("학점 초과");
                    return inputLectureList;
                }

                //리스트에 이미 시간이 중복되는 강의가 있는지
                error = errorCheck.IsValidTime(inputLectureList, computerEngineering, inputClassIndex);
                if (error == true)
                {
                    print.ErrorMsg("시간 중복 강의");
                    return inputLectureList;
                }

                //리스트에 추가
                LectureVO newLecture = computerEngineering.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex));
                inputLectureList.Add(new LectureVO(newLecture.Department, newLecture.LectureIndex,
                    newLecture.ClassIndex, newLecture.LectureName, newLecture.Division, newLecture.Year,
                    newLecture.Grade, newLecture.Time, newLecture.Classroom, newLecture.Professor, newLecture.Language));

                print.ShowLecture(inputLectureList);
                print.CompleteMsg(type + " 과목 추가");
            }

            else if (inputDepartment.Equals("정보보호학과"))
            {
                print.ShowLecture(informationProtection);
                print.InputMsg("분반");
                inputClassIndex = Console.ReadLine();
                error = errorCheck.IsValidPattern(inputClassIndex, "classIndex");
                if (error == true)
                {
                    print.ErrorMsg("잘못된 양식의 분반");
                    return inputLectureList;
                }

                if (foundLectureList.Count == 0)
                    toGrade = 0;
                else
                {
                    toGrade = double.Parse(foundLectureList[0].Grade);
                }
                error = errorCheck.IsValidGrade(inputLectureList, type, toGrade);
                if (error == true)
                {
                    print.ErrorMsg("학점 초과");
                    return inputLectureList;
                }

                //리스트에 이미 시간이 중복되는 강의가 있는지
                error = errorCheck.IsValidTime(inputLectureList, informationProtection, inputClassIndex);
                if (error == true)
                {
                    print.ErrorMsg("시간 중복 강의");
                    return inputLectureList;
                }

                //관심과목 리스트에 추가
                LectureVO newLecture = informationProtection.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex));
                inputLectureList.Add(new LectureVO(newLecture.Department, newLecture.LectureIndex,
                    newLecture.ClassIndex, newLecture.LectureName, newLecture.Division, newLecture.Year,
                    newLecture.Grade, newLecture.Time, newLecture.Classroom, newLecture.Professor, newLecture.Language));

                print.ShowLecture(inputLectureList);
                print.CompleteMsg(type + " 추가");
            }

            else if (inputDepartment.Equals("디지털콘텐츠학과"))
            {
                print.ShowLecture(digitalContents);
                print.InputMsg("분반");
                inputClassIndex = Console.ReadLine();
                error = errorCheck.IsValidPattern(inputClassIndex, "classIndex");
                if (error == true)
                {
                    print.ErrorMsg("잘못된 양식의 분반");
                    return inputLectureList;
                }

                if (foundLectureList.Count == 0)
                    toGrade = 0;
                else
                {
                    toGrade = double.Parse(foundLectureList[0].Grade);
                }
                error = errorCheck.IsValidGrade(inputLectureList, type, toGrade);
                if (error == true)
                {
                    print.ErrorMsg("학점 초과");
                    return inputLectureList;
                }
                //리스트에 이미 시간이 중복되는 강의가 있는지
                error = errorCheck.IsValidTime(inputLectureList, digitalContents, inputClassIndex);
                if (error == true)
                {
                    print.ErrorMsg("시간 중복 강의");
                    return inputLectureList;
                }

                //관심과목 리스트에 추가
                LectureVO newLecture = digitalContents.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex));
                inputLectureList.Add(new LectureVO(newLecture.Department, newLecture.LectureIndex,
                    newLecture.ClassIndex, newLecture.LectureName, newLecture.Division, newLecture.Year,
                    newLecture.Grade, newLecture.Time, newLecture.Classroom, newLecture.Professor, newLecture.Language));

                print.ShowLecture(inputLectureList);
                print.CompleteMsg(type + " 추가");
            }

            else if (inputDepartment.Equals("소프트웨어학과"))
            {
                print.ShowLecture(softWare);
                print.InputMsg("분반");
                inputClassIndex = Console.ReadLine();
                error = errorCheck.IsValidPattern(inputClassIndex, "classIndex");
                if (error == true)
                {
                    print.ErrorMsg("잘못된 양식의 분반");
                    return inputLectureList;
                }

                if (foundLectureList.Count == 0)
                    toGrade = 0;
                else
                {
                    toGrade = double.Parse(foundLectureList[0].Grade);
                }
                error = errorCheck.IsValidGrade(inputLectureList, type, toGrade);
                if (error == true)
                {
                    print.ErrorMsg("학점 초과");
                    return inputLectureList;
                }

                //리스트에 이미 시간이 중복되는 강의가 있는지
                error = errorCheck.IsValidTime(inputLectureList, softWare, inputClassIndex);
                if (error == true)
                {
                    print.ErrorMsg("시간 중복 강의");
                    return inputLectureList;
                }

                //관심과목 리스트에 추가
                LectureVO newLecture = softWare.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex));
                inputLectureList.Add(new LectureVO(newLecture.Department, newLecture.LectureIndex,
                    newLecture.ClassIndex, newLecture.LectureName, newLecture.Division, newLecture.Year,
                    newLecture.Grade, newLecture.Time, newLecture.Classroom, newLecture.Professor, newLecture.Language));

                print.ShowLecture(inputLectureList);
                print.CompleteMsg(type + " 추가");
            }
            return inputLectureList;
        }
    }
}
