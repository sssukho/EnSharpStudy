using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            ErrorCheck errorCheck = new ErrorCheck();
            MemberManagement memberManagement = new MemberManagement();
            BookRent bookRent = new BookRent();
            PrintErrorMsg printErrorMsg= new PrintErrorMsg();

            Menu menu = new Menu(errorCheck, memberManagement, bookRent, printErrorMsg);
        }
    }
}
