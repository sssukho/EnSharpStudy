using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLine
{
    class ErrorCheck
    {
        private static ErrorCheck errorCheck;

        public ErrorCheck()
        {

        }

        public static ErrorCheck GetInstance()
        {
            if (errorCheck == null)
                errorCheck = new ErrorCheck();

            return errorCheck;
        }
    }
}
