using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryManagement
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

        public bool MemberName(string input)
        {
            pattern = @"^[가-힣]{2,4}$";
            return Judgement(input, pattern);
        }

        public bool MemberID(string input)
        {
            pattern = @"^[0-9]{6,8}$";
            return Judgement(input, pattern);
        }

        public bool MemberPassword(string input)
        {
            pattern = @"^[0-9]{4}$";
            return Judgement(input, pattern);
        }

        public bool MemberGender(string input)
        {
            pattern = @"^[남자|여자]{2}$";
            return Judgement(input, pattern);
        }

        public bool MemberPhone(string input)
        {
            pattern = @"^01([0|1|6|7|8|9]?)-?([0-9]{3,4})-?([0-9]{4})$";
            return Judgement(input, pattern);
        }

        public bool MemberAddress(string input)
        {
            pattern = @"(([가-힣]+(\d{1,5}|\d{1,5}(,|.)\d{1,5}|)+(읍|면|동|가|리))(^구|)((\d{1,5}(~|-)\d{1,5}|\d{1,5})(가|리|)|))([ ](산(\d{1,5}(~|-)\d{1,5}|\d{1,5}))|)|(([가-힣]|(\d{1,5}(~|-)\d{1,5})|\d{1,5})+(로|길))";
            return Judgement(input, pattern);
        }

        public bool MemberEmail(string input)
        {
            pattern = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$";
            return Judgement(input, pattern);
        }

        public bool Confirm(string input)
        {
            pattern = @"^[Y|y|N|n]{1}$";
            return Judgement(input, pattern);
        }

        public bool BookName(string input)
        {
            pattern = @"^[가-힣a-zA-Z0-9|!@#$%^&*()]{1,30}$";
            return Judgement(input, pattern);
        }

        public bool BookPublisher(string input)
        {
            pattern = @"^[가-힣a-zA-Z]{1,30}$";
            return Judgement(input, pattern);
        }

        public bool BookAuthor(string input)
        {
            pattern = @"^[가-힣a-zA-Z]{1,10}$";
            return Judgement(input, pattern);
        }

        public bool BookCount(string input)
        {
            pattern = @"^[0-9]{1,2}$";
            return Judgement(input, pattern);
        }

        public bool Judgement(string input, string pattern)
        {
            mc = Regex.Matches(input, pattern);
            if (mc.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
