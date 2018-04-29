﻿using System;
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
        
        public bool IsValidGrade(List<InterestingLectureVO> interestingLectureList)
        {
            double currentGrade = 0;
            foreach (var item in interestingLectureList)
            {
                currentGrade = currentGrade + double.Parse(item.Grade.ToString());
            }

            if (currentGrade > 24)
                return true;

            return false;
        }

        public bool IsValidGrade(List<RegisteredLectureVO> registeredLectureList)
        {
            double currentGrade = 0;
            foreach (var item in registeredLectureList)
            {
                currentGrade = currentGrade + double.Parse(item.Grade.ToString());
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

        public bool IsValidTime(List<RegisteredLectureVO> registeredLectureList, List<LectureListVO> foundLectureList, string inputClassIndex)
        {
            string findTime = foundLectureList.Find(lecture =>
            lecture.ClassIndex.Equals(inputClassIndex)).Time.ToString();

            if (registeredLectureList.Exists(lecture =>
             lecture.Time.Equals(findTime)) == true)
            {
                return true;
            }
            return false;
        }

        public bool IsValidPattern(string input, string type)
        {
            string pattern = "";
            switch(type)
            {
                case "lectureIndex":
                    pattern = @"^[0]{1}[0-1]{1}[0-9]{4}$";
                    break;

                case "classIndex":
                    pattern = @"^[0]{1}[0-9]{2}$";
                    break;

                case "department":
                    pattern = @"^[가-힣]{6}$";
                    break;

                case "lectureName":
                    pattern = @"^[가-힣a-zA-Z:+()#1]{4,21}$";
                    break;

                case "grade":
                    pattern = @"^[1-4]{1}$";
                    break;

                case "professor":
                    pattern = @"^[가-힣a-zA-Z]{22}";
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
