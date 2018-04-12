using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class BookErrorCheck
    {
        public bool ManagementMenuInputError(string input)
        {
            if (input == "1" || input == "2" || input == "3" || input == "4"
                || input == "5" || input == "6" || input == "7")
            {
                return false;
            }
            return true;
        }
    }
}
