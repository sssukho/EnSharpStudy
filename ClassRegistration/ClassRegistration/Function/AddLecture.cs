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

        public List<InterestingLectureVO> AddLectureInList(List<LectureListVO> lectureList, List<InterestingLectureVO> interestingLectureList)
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
                return interestingLectureList;
            }

            error = errorCheck.IsValidGrade(interestingLectureList);
            if (error == true)
            {
                print.ErrorMsg("학점 초과");
                return interestingLectureList;
            }

            error = errorCheck.IsValidLecture(interestingLectureList, inputLectureIndex);
            if (error == true)
            {
                print.ErrorMsg("이미 추가된 강의");
                return interestingLectureList;
            }

            //일치하는 학수번호 강의 리스트 출력
            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.LectureIndex.Equals(inputLectureIndex));
            print.ShowLecture(foundList);

            //학수번호 같은데 전공이 다른 과목 분

            if (CheckAnotherDepartment(foundList) == true)
            {
                List<LectureListVO> computerEngineering = foundList.FindAll(lecture => lecture.Department.Equals("컴퓨터공학과"));
                List<LectureListVO> informationProtection = foundList.FindAll(lecture => lecture.Department.Equals("정보보호학과")); ;
                List<LectureListVO> digitalContents = foundList.FindAll(lecture => lecture.Department.Equals("디지털콘텐츠학과"));
                List<LectureListVO> softWare = foundList.FindAll(lecture => lecture.Department.Equals("소프트웨어학과"));
                print.InputMsg("개설학과전공");
                inputDepartment = Console.ReadLine();
                error = errorCheck.IsValidPattern(inputDepartment, "department");
                if (error == true)
                {
                    print.ErrorMsg("잘못된 양식의 개설학과전공");
                    return interestingLectureList;
                }

                interestingLectureList = AddLectureByDepartment(inputDepartment, interestingLectureList, computerEngineering, informationProtection, digitalContents, softWare);
                return interestingLectureList;
            }

            print.InputMsg("분반");
            inputClassIndex = Console.ReadLine();
            error = errorCheck.IsValidPattern(inputClassIndex, "classIndex");
            if (error == true)
            {
                print.ErrorMsg("잘못된 양식의 분반");
                return interestingLectureList;
            }

            //리스트에 이미 시간이 중복되는 강의가 있는지
            error = errorCheck.IsValidTime(interestingLectureList, foundList, inputClassIndex);
            if (error == true)
            {
                print.ErrorMsg("시간 중복 강의");
                return interestingLectureList;
            }

            //관심과목 리스트에 추가
            LectureListVO newLecture = foundList.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex));
            interestingLectureList.Add(new InterestingLectureVO(newLecture.Department, newLecture.LectureIndex,
                newLecture.ClassIndex, newLecture.LectureName, newLecture.Division, newLecture.Year,
                newLecture.Grade, newLecture.Time, newLecture.Classroom, newLecture.Professor, newLecture.Language));

            print.ShowLecture(interestingLectureList);
            print.CompleteMsg("관심과목 추가");
            return interestingLectureList;
        }

        public List<RegisteredLectureVO> AddLectureInList(List<LectureListVO> lectureList, List<RegisteredLectureVO> registeredLectureList)
        {
            Console.Clear();

            string inputLectureIndex;
            string inputClassIndex;
            string inputDepartment;

            print.ShowLecture(lectureList);
            print.InputMsg("학수번호");

            inputLectureIndex = Console.ReadLine(); //입력 양식 체크

            error = errorCheck.IsValidPattern(inputLectureIndex, "lectureIndex");
            if (error == true)
            {
                print.ErrorMsg("잘못된 양식의 학수번호");
                return registeredLectureList;
            }

            error = errorCheck.IsValidGrade(registeredLectureList);
            if (error == true)
            {
                print.ErrorMsg("학점 초과");
                return registeredLectureList;
            }

            error = errorCheck.IsValidLecture(registeredLectureList, inputLectureIndex);
            if (error == true)
            {
                print.ErrorMsg("이미 추가된 강의");
                return registeredLectureList;
            }

            //일치하는 학수번호 강의 리스트 출력
            List<LectureListVO> foundList = lectureList.FindAll(lecture => lecture.LectureIndex.Equals(inputLectureIndex));
            print.ShowLecture(foundList);

            if (CheckAnotherDepartment(foundList) == true)
            {
                List<LectureListVO> computerEngineering = foundList.FindAll(lecture => lecture.Department.Equals("컴퓨터공학과"));
                List<LectureListVO> informationProtection = foundList.FindAll(lecture => lecture.Department.Equals("정보보호학과")); ;
                List<LectureListVO> digitalContents = foundList.FindAll(lecture => lecture.Department.Equals("디지털콘텐츠학과"));
                List<LectureListVO> softWare = foundList.FindAll(lecture => lecture.Department.Equals("소프트웨어학과"));
                print.InputMsg("개설학과전공");
                inputDepartment = Console.ReadLine();
                error = errorCheck.IsValidPattern(inputDepartment, "department");
                if (error == true)
                {
                    print.ErrorMsg("잘못된 양식의 개설학과전공");
                    return registeredLectureList;
                }

                registeredLectureList = AddLectureByDepartment(inputDepartment, registeredLectureList, computerEngineering, informationProtection, digitalContents, softWare);
                return registeredLectureList;
            }

            print.InputMsg("분반");
            inputClassIndex = Console.ReadLine(); //입력 양식 체크

            error = errorCheck.IsValidPattern(inputClassIndex, "classIndex");
            if (error == true)
            {
                print.ErrorMsg("잘못된 양식의 분반");
                return registeredLectureList;
            }

            error = errorCheck.IsValidTime(registeredLectureList, foundList, inputClassIndex);
            if (error == true)
            {
                print.ErrorMsg("시간 중복 강의");
                return registeredLectureList;
            }

            //수강신청 리스트에 추가
            LectureListVO newLecture = foundList.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex));
            registeredLectureList.Add(new RegisteredLectureVO(newLecture.Department, newLecture.LectureIndex, newLecture.ClassIndex,
                newLecture.LectureName, newLecture.Division, newLecture.Year, newLecture.Grade, newLecture.Time, newLecture.Classroom, newLecture.Professor, newLecture.Language));

            print.ShowLecture(registeredLectureList);
            print.CompleteMsg("수강신청 추가");
            return registeredLectureList;
        }

        public bool CheckAnotherDepartment(List<LectureListVO> foundList)
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


        public List<InterestingLectureVO> AddLectureByDepartment(string inputDepartment, List<InterestingLectureVO> interestingLectureList, List<LectureListVO> computerEngineering, List<LectureListVO> informationProtection, List<LectureListVO> digitalContents, List<LectureListVO> softWare)
        {
            string inputClassIndex;
            if (inputDepartment.Equals("컴퓨터공학과"))
            {
                print.ShowLecture(computerEngineering);
                print.InputMsg("분반");
                inputClassIndex = Console.ReadLine();
                error = errorCheck.IsValidPattern(inputClassIndex, "classIndex");
                if (error == true)
                {
                    print.ErrorMsg("잘못된 양식의 분반");
                    return interestingLectureList;
                }

                error = errorCheck.IsValidGrade(interestingLectureList);
                if (error == true)
                {
                    print.ErrorMsg("학점 초과");
                    return interestingLectureList;
                }

                //리스트에 이미 시간이 중복되는 강의가 있는지
                error = errorCheck.IsValidTime(interestingLectureList, computerEngineering, inputClassIndex);
                if (error == true)
                {
                    print.ErrorMsg("시간 중복 강의");
                    return interestingLectureList;
                }

                //관심과목 리스트에 추가
                LectureListVO newLecture = computerEngineering.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex));
                interestingLectureList.Add(new InterestingLectureVO(newLecture.Department, newLecture.LectureIndex,
                    newLecture.ClassIndex, newLecture.LectureName, newLecture.Division, newLecture.Year,
                    newLecture.Grade, newLecture.Time, newLecture.Classroom, newLecture.Professor, newLecture.Language));

                print.ShowLecture(interestingLectureList);
                print.CompleteMsg("관심과목 추가");
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
                    return interestingLectureList;
                }

                error = errorCheck.IsValidGrade(interestingLectureList);
                if (error == true)
                {
                    print.ErrorMsg("학점 초과");
                    return interestingLectureList;
                }

                //리스트에 이미 시간이 중복되는 강의가 있는지
                error = errorCheck.IsValidTime(interestingLectureList, informationProtection, inputClassIndex);
                if (error == true)
                {
                    print.ErrorMsg("시간 중복 강의");
                    return interestingLectureList;
                }

                //관심과목 리스트에 추가
                LectureListVO newLecture = informationProtection.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex));
                interestingLectureList.Add(new InterestingLectureVO(newLecture.Department, newLecture.LectureIndex,
                    newLecture.ClassIndex, newLecture.LectureName, newLecture.Division, newLecture.Year,
                    newLecture.Grade, newLecture.Time, newLecture.Classroom, newLecture.Professor, newLecture.Language));

                print.ShowLecture(interestingLectureList);
                print.CompleteMsg("관심과목 추가");
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
                    return interestingLectureList;
                }

                error = errorCheck.IsValidGrade(interestingLectureList);
                if (error == true)
                {
                    print.ErrorMsg("학점 초과");
                    return interestingLectureList;
                }

                //리스트에 이미 시간이 중복되는 강의가 있는지
                error = errorCheck.IsValidTime(interestingLectureList, digitalContents, inputClassIndex);
                if (error == true)
                {
                    print.ErrorMsg("시간 중복 강의");
                    return interestingLectureList;
                }

                //관심과목 리스트에 추가
                LectureListVO newLecture = digitalContents.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex));
                interestingLectureList.Add(new InterestingLectureVO(newLecture.Department, newLecture.LectureIndex,
                    newLecture.ClassIndex, newLecture.LectureName, newLecture.Division, newLecture.Year,
                    newLecture.Grade, newLecture.Time, newLecture.Classroom, newLecture.Professor, newLecture.Language));

                print.ShowLecture(interestingLectureList);
                print.CompleteMsg("관심과목 추가");
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
                    return interestingLectureList;
                }

                error = errorCheck.IsValidGrade(interestingLectureList);
                if (error == true)
                {
                    print.ErrorMsg("학점 초과");
                    return interestingLectureList;
                }

                //리스트에 이미 시간이 중복되는 강의가 있는지
                error = errorCheck.IsValidTime(interestingLectureList, softWare, inputClassIndex);
                if (error == true)
                {
                    print.ErrorMsg("시간 중복 강의");
                    return interestingLectureList;
                }

                //관심과목 리스트에 추가
                LectureListVO newLecture = softWare.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex));
                interestingLectureList.Add(new InterestingLectureVO(newLecture.Department, newLecture.LectureIndex,
                    newLecture.ClassIndex, newLecture.LectureName, newLecture.Division, newLecture.Year,
                    newLecture.Grade, newLecture.Time, newLecture.Classroom, newLecture.Professor, newLecture.Language));

                print.ShowLecture(interestingLectureList);
                print.CompleteMsg("관심과목 추가");
            }
            return interestingLectureList;
        }

        public List<RegisteredLectureVO> AddLectureByDepartment(string inputDepartment, List<RegisteredLectureVO> registeredLectureList, List<LectureListVO> computerEngineering, List<LectureListVO> informationProtection, List<LectureListVO> digitalContents, List<LectureListVO> softWare)
        {
            string inputClassIndex;
            if (inputDepartment.Equals("컴퓨터공학과"))
            {
                print.ShowLecture(computerEngineering);
                print.InputMsg("분반");
                inputClassIndex = Console.ReadLine();
                error = errorCheck.IsValidPattern(inputClassIndex, "classIndex");
                if (error == true)
                {
                    print.ErrorMsg("잘못된 양식의 분반");
                    return registeredLectureList;
                }

                error = errorCheck.IsValidGrade(registeredLectureList);
                if (error == true)
                {
                    print.ErrorMsg("학점 초과");
                    return registeredLectureList;
                }
                //리스트에 이미 시간이 중복되는 강의가 있는지
                error = errorCheck.IsValidTime(registeredLectureList, computerEngineering, inputClassIndex);
                if (error == true)
                {
                    print.ErrorMsg("시간 중복 강의");
                    return registeredLectureList;
                }

                //관심과목 리스트에 추가
                LectureListVO newLecture = computerEngineering.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex));
                registeredLectureList.Add(new RegisteredLectureVO(newLecture.Department, newLecture.LectureIndex,
                    newLecture.ClassIndex, newLecture.LectureName, newLecture.Division, newLecture.Year,
                    newLecture.Grade, newLecture.Time, newLecture.Classroom, newLecture.Professor, newLecture.Language));

                print.ShowLecture(registeredLectureList);
                print.CompleteMsg("수강신청 추가");
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
                    return registeredLectureList;
                }

                error = errorCheck.IsValidGrade(registeredLectureList);
                if (error == true)
                {
                    print.ErrorMsg("학점 초과");
                    return registeredLectureList;
                }

                //리스트에 이미 시간이 중복되는 강의가 있는지
                error = errorCheck.IsValidTime(registeredLectureList, informationProtection, inputClassIndex);
                if (error == true)
                {
                    print.ErrorMsg("시간 중복 강의");
                    return registeredLectureList;
                }

                //관심과목 리스트에 추가
                LectureListVO newLecture = informationProtection.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex));
                registeredLectureList.Add(new RegisteredLectureVO(newLecture.Department, newLecture.LectureIndex,
                    newLecture.ClassIndex, newLecture.LectureName, newLecture.Division, newLecture.Year,
                    newLecture.Grade, newLecture.Time, newLecture.Classroom, newLecture.Professor, newLecture.Language));

                print.ShowLecture(registeredLectureList);
                print.CompleteMsg("수강신청 추가");
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
                    return registeredLectureList;
                }

                error = errorCheck.IsValidGrade(registeredLectureList);
                if (error == true)
                {
                    print.ErrorMsg("학점 초과");
                    return registeredLectureList;
                }

                //리스트에 이미 시간이 중복되는 강의가 있는지
                error = errorCheck.IsValidTime(registeredLectureList, digitalContents, inputClassIndex);
                if (error == true)
                {
                    print.ErrorMsg("시간 중복 강의");
                    return registeredLectureList;
                }

                //관심과목 리스트에 추가
                LectureListVO newLecture = digitalContents.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex));
                registeredLectureList.Add(new RegisteredLectureVO(newLecture.Department, newLecture.LectureIndex,
                    newLecture.ClassIndex, newLecture.LectureName, newLecture.Division, newLecture.Year,
                    newLecture.Grade, newLecture.Time, newLecture.Classroom, newLecture.Professor, newLecture.Language));

                print.ShowLecture(registeredLectureList);
                print.CompleteMsg("수강신청 추가");
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
                    return registeredLectureList;
                }

                error = errorCheck.IsValidGrade(registeredLectureList);
                if (error == true)
                {
                    print.ErrorMsg("학점 초과");
                    return registeredLectureList;
                }

                //리스트에 이미 시간이 중복되는 강의가 있는지
                error = errorCheck.IsValidTime(registeredLectureList, softWare, inputClassIndex);
                if (error == true)
                {
                    print.ErrorMsg("시간 중복 강의");
                    return registeredLectureList;
                }

                //관심과목 리스트에 추가
                LectureListVO newLecture = softWare.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex));
                registeredLectureList.Add(new RegisteredLectureVO(newLecture.Department, newLecture.LectureIndex,
                    newLecture.ClassIndex, newLecture.LectureName, newLecture.Division, newLecture.Year,
                    newLecture.Grade, newLecture.Time, newLecture.Classroom, newLecture.Professor, newLecture.Language));

                print.ShowLecture(registeredLectureList);
                print.CompleteMsg("수강신청 추가");
            }
            return registeredLectureList;
        }
    }
}
