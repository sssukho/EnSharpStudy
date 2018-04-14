using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManage
{
    class ErrorCheck
    {
        Menu menu;
        public static ErrorCheck errorCheck;

        public ErrorCheck()
        {

        }

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
    }
}
