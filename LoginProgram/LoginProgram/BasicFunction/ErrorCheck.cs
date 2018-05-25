using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/*********************************************************
    * 회원 가입 및 편집 정규표현식
       1. 아이디 : 4~12자리 영(대, 소) 숫자만 입력 가능
       2. 비밀번호 : 6~20 영문 대소문자 + 최소 1개의 숫자 혹은 특수문자 포함
       3. 이름 :  2~4글자 한글로만
       4. 핸드폰 번호: 01x-xxxx-xxxx 혹은 01x-xxx-xxxx
       5. 이메일 주소 : 골벵이 들어가야하고 영문만
       6. 거주지 주소 : 배달의민족 개발자 블로그에서 가져옴
       7. 생년월일 : yyyy-mm-dd
       8. 주민등록번호 : yymmdd-xxxxxxx
       ***************************************************/
namespace LoginProgram
{
    class ErrorCheck
    {
        private static ErrorCheck errorCheck;

        MatchCollection mc;
        private string pattern;

        public ErrorCheck() { }

        public static ErrorCheck GetInstance()
        {
            if (errorCheck == null)
                errorCheck = new ErrorCheck();
            return errorCheck;
        }

        public string InputErrorType(string id, string password, string name, string birth, string email, string phone, string address, string identifyNumber)
        {
            if (errorCheck.MemberID(id))
                return "아이디";

            if (errorCheck.MemberPassword(password))
                return "비밀번호";
            
            if (errorCheck.MemberName(name))
                return "이름";
            
            if (errorCheck.MemberBirth(birth))
                return "생년월일";
            
            if (errorCheck.MemberEmail(email))
                return "이메일";
            
            if (errorCheck.MemberPhone(phone))
                return "핸드폰 번호";
            
            if (errorCheck.MemberAddress(address))
                return "주소";
            
            if (errorCheck.MemberIdentifyNumber(identifyNumber))
                return "주민등록번호";

            return "none";
        }

        public bool MemberID(string input)
        {
            pattern = @"^[A-Za-z0-9]{4,12}$";
            return Judgement(input, pattern);
        }

        public bool MemberPassword(string input)
        {
            pattern = @"^(?=.*[a-zA-Z])((?=.*\d)|(?=.*\W)).{6,20}$";
            return Judgement(input, pattern);
        }

        public bool MemberName(string input)
        {
            pattern = @"^[가-힣]{2,4}$"; 
            return Judgement(input, pattern);
        }

        public bool MemberGender(string input)
        {
            pattern = @"^[남자|여자]{2}$";
            return Judgement(input, pattern);
        }

        public bool MemberPhone(string input)
        {
            pattern = @"^01([0|1|6|7|8|9]?)-\d{3,4}-\d{4}$";
            return Judgement(input, pattern);
        }

        public bool MemberEmail(string input)
        {
            pattern = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$";
            return Judgement(input, pattern);
        }

        public bool MemberAddress(string input)
        {
            pattern = @"(([가-힣]+(\d{1,5}|\d{1,5}(,|.)\d{1,5}|)+(읍|면|동|가|리))(^구|)((\d{1,5}(~|-)\d{1,5}|\d{1,5})(가|리|)|))([ ](산(\d{1,5}(~|-)\d{1,5}|\d{1,5}))|)|(([가-힣]|(\d{1,5}(~|-)\d{1,5})|\d{1,5})+(로|길))";
            return Judgement(input, pattern);
        }

        public bool MemberIdentifyNumber(string input)
        {
            pattern = @"^(?:[0-9]{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[1,2][0-9]|3[0,1]))-[1-4][0-9]{6}$";
            return Judgement(input, pattern);
        }

        public bool MemberBirth(string input) 
        {
            pattern = @"^(19|20)\d{2}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[0-1])$";
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
