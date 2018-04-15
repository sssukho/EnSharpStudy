using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace BookManage
{
    class ErrorCheck
    {
        Menu menu;
        public static ErrorCheck errorCheck;
        MatchCollection mc;
        string pattern;

        public ErrorCheck(){ }

        public ErrorCheck(Menu menu)
        {
            this.menu = menu;
        }

        public static ErrorCheck GetInstance()
        {
            if(errorCheck == null)
            {
                errorCheck = new ErrorCheck();
            }
            return errorCheck;
        }

        public bool MemberName(string input)
        {
            pattern = @"^[가-힣]{2,4}$";
            mc = Regex.Matches(input, pattern);
            return Judgement(mc);
        }

        public bool PhoneNumber(string input)
        {
            pattern = @"/^01([0|1|6|7|8|9]?)-?([0-9]{3,4})-?([0-9]{4})$/;";
            mc = Regex.Matches(input, pattern);
            return Judgement(mc);
        }

        public bool Address(string input)
        {
            pattern = @"(([가-힣]+(\d{1,5}|\d{1,5}(,|.)\d{1,5}|)+(읍|면|동|가|리))(^구|)((\d{1,5}(~|-)\d{1,5}|\d{1,5})(가|리|)|))([ ](산(\d{1,5}(~|-)\d{1,5}|\d{1,5}))|)|(([가-힣]|(\d{1,5}(~|-)\d{1,5})|\d{1,5})+(로|길))";
            mc = Regex.Matches(input, pattern);
            return Judgement(mc);
        }

        public bool EmailAddress(string input)
        {
            pattern = @"/[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$";
            mc = Regex.Matches(input, pattern);
            return Judgement(mc);
        }

        public string RemoveBlank(string input)
        {
            pattern = "\\s+";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(input, replacement);
            return result;
        }

        public bool Korean(string input)
        {
            pattern = @"/^[가-힣\s]+$/";
            mc = Regex.Matches(input, pattern);
            return Judgement(mc);
        }

        public bool English(string input)
        {
            pattern = @"/^[a-zA-Z\s]+$/";
            mc = Regex.Matches(input, pattern);
            return Judgement(mc);
        }

        public bool Number(string input, string type)
        {
            switch(type)
            {
                case "4지선다":
                    pattern = @"[1-4]{1}";
                    break;

                case "5지선다":
                    pattern = @"[1-5]{1}";
                    break;

                case "7지선다":
                    pattern = @"[1-7]{1}";
                    break;

                case "선택":
                    pattern = @"[1-2]{1}";
                    break;
            }

            mc = Regex.Matches(input, pattern);
            return Judgement(mc);
        }

        public bool MemberRegister(Member newMember)
        {
            bool nameError, 
            nameError = MemberName(newMember.Name);
            if(nameError == true)
            {
                return true;
            }
            

        }

        public bool Judgement(MatchCollection mc)
        {
            if(mc.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}