﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LoginProgram
{
    class ErrorCheck
    {
        private static ErrorCheck errorCheck;

        MatchCollection mc;
        string pattern;

        public ErrorCheck() { }

        public static ErrorCheck GetInstance()
        {
            if (errorCheck == null)
                errorCheck = new ErrorCheck();
            return errorCheck;
        }

        public bool MemberID(string input)
        {
            pattern = @"^[A-Za-z0-9]{4,12}$"; //4~12자리 영(대,소) 숫자만 입력받기.
            return Judgement(input, pattern);
        }

        public bool MemberPassword(string input)
        {
            pattern = @"^(?=.*[a-zA-Z])((?=.*\d)|(?=.*\W)).{6,20}$"; //6~20 영문 대소문자 + 최소 1개의 숫자 혹은 특수 문자 포함
            return Judgement(input, pattern);
        }

        public bool MemberName(string input)
        {
            pattern = @"^[가-힣]{2,4}$"; //2~4 글자 한글로만
            return Judgement(input, pattern);
        }

        public bool MemberGender(string input)
        {
            pattern = @"^[남자|여자]{2}$";
            return Judgement(input, pattern); // 남자 혹은 여자 두글자로만
        }

        public bool MemberPhone(string input)
        {
            pattern = @"^01([0|1|6|7|8|9]?)-?([0-9]{3,4})-?([0-9]{4})$";
            return Judgement(input, pattern);
        }

        public bool MemberEmail(string input)
        {
            pattern = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$";
            return Judgement(input, pattern);
        }

        public bool Judgement(string input, string pattern)
        {
            mc = Regex.Matches(input, pattern);
            if (mc.Count == 0)
                return true;

            if (string.IsNullOrEmpty(input))
                return true;

            return false;
        }
    }
}
