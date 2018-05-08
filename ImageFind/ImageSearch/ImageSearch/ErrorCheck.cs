using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSearch
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

        public bool IsValidSearch(string searchWord)
        {
            if (searchWord.Length > 50)
                return false;

            return true;
        }
    }
}