using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchImage
{
    class ErrorCheck
    {
        private static ErrorCheck errorCheck;

        public static ErrorCheck GetInstance()
        {
            if (errorCheck == null)
                errorCheck = new ErrorCheck();
            return errorCheck;
        }

        //검색 글자수 50글자 제한, 공백으로 검색했을 시 에러 발생값(false) 리턴
        public bool IsValidSearch(string searchWord)
        {
            if (searchWord.Length > 50 || string.IsNullOrEmpty(searchWord) || string.IsNullOrWhiteSpace(searchWord))
                return false;

            return true;
        }
    }
}
