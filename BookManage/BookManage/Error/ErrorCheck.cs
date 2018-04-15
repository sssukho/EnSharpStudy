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
        public static ErrorCheck errorCheck;
        Menu menu;
        MemberManagement memberManagement;
        BookManagement bookManagement;
        MatchCollection mc;
        string pattern;
       
        public ErrorCheck(){ }

        public ErrorCheck(Menu menu)
        {
            this.menu = menu;
        }

        public ErrorCheck(MemberManagement memberManagement)
        {
            this.memberManagement = memberManagement;
        }

        public ErrorCheck(BookManagement bookManagement)
        {
            this.bookManagement = bookManagement;
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
            MatchCollection mc = Regex.Matches(input, pattern);
            return Judgement(mc);
        }

        public bool MemberID(string input)
        {
            pattern = @"^[0-9]{6,9}$";
            MatchCollection mc = Regex.Matches(input, pattern);
            return Judgement(mc);
        }

        public bool MemberGender(string input)
        {//@"^[남|여]{1}$";
            if (input == "남" || input =="여")
            {
                return false;
            }
            return true;
        }

        public bool MemberPhone(string input)
        {
            pattern = @"^01([0|1|6|7|8|9]?)-?([0-9]{3,4})-?([0-9]{4})$";
            MatchCollection mc = Regex.Matches(input, pattern);
            return Judgement(mc);
        }

        public bool MemberAddress(string input)
        {
            pattern = @"(([가-힣]+(\d{1,5}|\d{1,5}(,|.)\d{1,5}|)+(읍|면|동|가|리))(^구|)((\d{1,5}(~|-)\d{1,5}|\d{1,5})(가|리|)|))([ ](산(\d{1,5}(~|-)\d{1,5}|\d{1,5}))|)|(([가-힣]|(\d{1,5}(~|-)\d{1,5})|\d{1,5})+(로|길))";
            MatchCollection mc = Regex.Matches(input, pattern);
            return Judgement(mc);
        }

        public bool MemberEmail(string input)
        {
            pattern = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$";
            MatchCollection mc = Regex.Matches(input, pattern);
            return Judgement(mc);
        }

        public bool TwoNumber(string input)
        {
            pattern = @"^[1-2]{1}$";
            MatchCollection mc = Regex.Matches(input, pattern);
            return Judgement(mc);
        }

        public bool Confirm(string input)
        {
            pattern = @"^[Y|y|N|n]{1}$";
            MatchCollection mc = Regex.Matches(input, pattern);
            return Judgement(mc);
        }


        /*
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
            pattern = @"^[가-힣\s]+$";
            mc = Regex.Matches(input, pattern);
            return Judgement(mc);
        }

        public bool English(string input)
        {
            pattern = @"^[a-zA-Z\s]+$";
            mc = Regex.Matches(input, pattern);
            return Judgement(mc);
        }*/

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