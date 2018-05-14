using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryManagement
{
    /// <summary>
    /// 에러체크 클래스
    /// </summary>
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

        public bool IsValidMenuInput(ConsoleKeyInfo input, string type)
        {
            if (type.Contains("관리메뉴"))
                type = "관리메뉴";

            if (type.Contains("검색메뉴"))
                type = "검색메뉴";

            switch (type)
            {
                case "메인메뉴":
                    pattern = @"[0-3]{1}$";
                    break;

                case "관리메뉴":
                    pattern = @"[0-6]{1}$";
                    break;

                case "검색메뉴":
                    pattern = @"[0-3]{1}$";
                    break;

                case "도서대여메뉴":
                    pattern = @"[0-3]{1}$";
                    break;

                case "선택":
                    pattern = @"[1-2]{1}$";
                    break;
            }
            return Judgement(input.KeyChar.ToString(), pattern);
        }

        public bool MemberName(string input)
        {
            pattern = @"^[가-힣]{2,4}$";
            return Judgement(input, pattern);
        }

        public bool MemberID(string input)
        {
            if(input.Equals("관리자"))
            {
                return false; 
            }
            pattern = @"^[0-9]{6,8}$";
            return Judgement(input, pattern);
        }

        public bool MemberPassword(string input)
        {
            if(input.Equals("관리자"))
            {
                return false;
            }
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

        public bool BookPrice(string input)
        {
            pattern = @"^[0-9]{4,5}$";
            return Judgement(input, pattern);
        }

        public bool BookIsbn(string input)
        {
            return false;
        }

        public bool BookDescription(string input)
        {
            return false;
        }

        public bool BookPublishDate(string input)
        {
            pattern = @"^[0-9]{4}";
            return false;
        }

        public bool BookName(string input)
        {
            if (string.IsNullOrEmpty(input))
                return true;
            return false;
        }

        public bool BookIndex(string input)
        {
            pattern = @"^[0-9]{1,3}";
            return Judgement(input, pattern);
        }

        public bool BookPublisher(string input)
        {
            pattern = @"^[가-힣a-zA-Z]{1,30}$";
            return false;
        }

        public bool BookAuthor(string input)
        {
            pattern = @"^[가-힣a-zA-Z]{1,50}$";
            return false;
        }

        public bool BookCount(string input)
        {
            pattern = @"^[0-9]{1,2}$";
            return Judgement(input, pattern);
        }

        public bool EdittedCount(int input)
        {
            pattern = @"^[0-9]{1,3}$";
            return Judgement(input.ToString(), pattern);
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

        public bool IsValidBook(List<BookVO> inputBookList)
        {
            if (inputBookList.Count > 0)
                return true;
            else
                return false;
        }
    }
}
