using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ClassRegistration
{
    class ErrorCheck
    {
        MatchCollection mc;

        public bool IsValidGrade(List<LectureVO> inputLectureList, string type, double toGrade)
        {
            double currentGrade = 0;

            foreach (var item in inputLectureList)
            {
                currentGrade = currentGrade + double.Parse(item.Grade.ToString());
            }

            if (type.Equals("수강신청"))
            {
                if (currentGrade + toGrade > 21)
                    return true;

                return false;
            }

            else if (type.Equals("관심과목"))
            {
                if (currentGrade + toGrade > 24)
                    return true;

                return false;
            }

            return true;
        }

        public bool IsValidLecture(List<LectureVO> interestingLectureList, string inputLectureIndex)
        {
            if (interestingLectureList.Exists(lecture =>
            lecture.LectureIndex.Equals(inputLectureIndex) == true))
                return true;

            return false;
        }

        public bool IsValidTime(List<LectureVO> inputLectureList, List<LectureVO> foundLectureList, string inputClassIndex)
        {
            string foundTime;
            int foundFrontTime;
            int foundBackTime;

            foundTime = foundLectureList.Find(lecture => lecture.ClassIndex.Equals(inputClassIndex)).Time.ToString();

            

            //같은요일에서 나눠야함

            int errorCount = 0; //inputLectureList.Count랑 같아야 에러아님

            for (int i = 0; i < inputLectureList.Count; i++)
            {
                if (foundTime.Length == 12) //하루일때
                {
                    foundFrontTime = int.Parse(foundTime.Remove(0, 1).Remove(5).Remove(2, 1));
                    foundBackTime = int.Parse(foundTime.Remove(0, 7).Remove(2, 1));

                    if (foundTime.Remove(1) != inputLectureList[i].Time.Remove(1))
                    {
                        errorCount = errorCount + 1;
                    }

                    else
                    {
                        if (inputLectureList[i].Time.Length == 12) //하루일때
                        {
                            if (foundBackTime < int.Parse(inputLectureList[i].Time.Remove(0, 1).Remove(5).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }

                            if (foundFrontTime > int.Parse(inputLectureList[i].Time.Remove(0, 7).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }
                        }

                        if (inputLectureList[i].Time.Length == 13)
                        {
                            if (foundBackTime < int.Parse(inputLectureList[i].Time.Remove(0, 2).Remove(5).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }

                            if (foundFrontTime > int.Parse(inputLectureList[i].Time.Remove(0, 8).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }
                        }

                        if (inputLectureList[i].Time.Length == 26)
                        {
                            if (foundBackTime < int.Parse(inputLectureList[i].Time.Remove(0, 2).Remove(5).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }

                            if (foundFrontTime > int.Parse(inputLectureList[i].Time.Remove(0, 8).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }
                        }
                    }
                }

                if (foundTime.Length == 13) //이틀일때
                {
                    foundFrontTime = int.Parse(foundTime.Remove(0, 2).Remove(5).Remove(2, 1));
                    foundBackTime = int.Parse(foundTime.Remove(0, 8).Remove(2, 1));

                    if (foundTime.Remove(1) != inputLectureList[i].Time.Remove(1))
                    {
                        errorCount = errorCount + 1;
                    }

                    else
                    {
                        if (inputLectureList[i].Time.Length == 12) //하루일때
                        {
                            if (foundBackTime < int.Parse(inputLectureList[i].Time.Remove(0, 1).Remove(5).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }

                            if (foundFrontTime > int.Parse(inputLectureList[i].Time.Remove(0, 7).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }
                        }

                        if (inputLectureList[i].Time.Length == 13)
                        {
                            if (foundBackTime < int.Parse(inputLectureList[i].Time.Remove(0, 2).Remove(5).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }

                            if (foundFrontTime > int.Parse(inputLectureList[i].Time.Remove(0, 8).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }
                        }

                        if (inputLectureList[i].Time.Length == 26)
                        {
                            if (foundBackTime < int.Parse(inputLectureList[i].Time.Remove(0, 2).Remove(5).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }

                            if (foundFrontTime > int.Parse(inputLectureList[i].Time.Remove(0, 8).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }
                        }
                    }
                }

                if (foundTime.Length == 26) //실습일때
                {
                    foundFrontTime = int.Parse(foundTime.Remove(0, 2).Remove(5).Remove(2, 1));
                    foundBackTime = int.Parse(foundTime.Remove(0, 8).Remove(2, 1).Remove(4));

                    if (foundTime.Remove(1) != inputLectureList[i].Time.Remove(1))
                    {
                        errorCount = errorCount + 1;
                    }

                    //pracFrontTime = int.Parse(item.Time.Remove(0, 15).Remove(5).Remove(2, 1));
                    //pracBackTime = int.Parse(item.Time.Remove(0, 21).Remove(2, 1));

                    else
                    {
                        if (inputLectureList[i].Time.Length == 12) //하루일때
                        {
                            if (foundBackTime < int.Parse(inputLectureList[i].Time.Remove(0, 1).Remove(5).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }

                            if (foundFrontTime > int.Parse(inputLectureList[i].Time.Remove(0, 7).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }
                        }

                        if (inputLectureList[i].Time.Length == 13)
                        {
                            if (foundBackTime < int.Parse(inputLectureList[i].Time.Remove(0, 2).Remove(5).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }

                            if (foundFrontTime > int.Parse(inputLectureList[i].Time.Remove(0, 8).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }
                        }

                        if (inputLectureList[i].Time.Length == 26)
                        {
                            if (foundBackTime < int.Parse(inputLectureList[i].Time.Remove(0, 2).Remove(5).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }

                            if (foundFrontTime > int.Parse(inputLectureList[i].Time.Remove(0, 8).Remove(2, 1)))
                            {
                                errorCount = errorCount + 1;
                            }
                        }
                    }
                }
            }

            

            if (errorCount != inputLectureList.Count)
            {
                return true;
            }


            if (inputLectureList.Exists(lecture =>
             lecture.Time.Equals(foundTime)) == true)
            {
                return true;
            }


            return false;
        }

        public bool IsValidInputKey(string input, string type)
        {
            if (type.Equals("mainMenu"))
            {
                if (input.Equals("1") || input.Equals("2") || input.Equals("3") || input.Equals("0"))
                    return false;
                return true;
            }

            else if (type.Equals("lectureMenu"))
            {
                if (input.Equals("1") || input.Equals("2") || input.Equals("3") || input.Equals("4") ||
                    input.Equals("0"))
                    return false;
                return true;
            }

            else if (type.Equals("interstingLectureSearchMenu")) //1,2,3,4,5,0
            {
                if (input.Equals("1") || input.Equals("2") || input.Equals("3") || input.Equals("4") ||
                    input.Equals("5") || input.Equals("0"))
                    return false;
                return true;
            }

            else if (type.Equals("registerLectureSearchMenu"))
            {
                if (input.Equals("1") || input.Equals("2") || input.Equals("3") || input.Equals("4") ||
                    input.Equals("5") || input.Equals("6") || input.Equals("0"))
                    return false;
                return true;
            }

            return false;
        }

        public bool IsValidPattern(string input, string type)
        {
            string pattern = "";
            switch (type)
            {
                case "lectureIndex":
                    pattern = @"^[0]{1}[0-1]{1}[0-9]{4}$";
                    break;

                case "classIndex":
                    pattern = @"^[0]{1}[0-9]{2}$";
                    break;

                case "department":
                    pattern = @"^[가-힣]{6,8}$";
                    break;

                case "lectureName":
                    pattern = @"^[가-힣a-zA-Z:+()#1]{4,21}$";
                    break;

                case "grade":
                    pattern = @"^[1-4]{1}$";
                    break;

                case "professor":
                    pattern = @"^[가-힣a-zA-Z]{2,22}";
                    break;
            }
            return JudgePatternError(input, pattern);
        }

        public bool JudgePatternError(string input, string pattern)
        {
            mc = Regex.Matches(input, pattern);
            if (mc.Count == 0)
                return true;

            return false;
        }
    }
}
