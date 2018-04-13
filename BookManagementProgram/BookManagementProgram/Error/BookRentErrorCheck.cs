using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class BookRentErrorCheck
    {
        public bool Number5InputError(string input)
        {
            if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5")
            {
                return false;
            }
            return true;
        }

        public bool IndexErrorCheck(int input)
        {
            if(input == -1)
            {
                return true;
            }

            return false;
        }

        public bool ConsoleInputErrorCheck(ConsoleKeyInfo input)
        {
            int intInput;
            if (char.IsDigit(input.KeyChar))
            {
                intInput = int.Parse(input.KeyChar.ToString());

                if (intInput == 1 || intInput == 2)
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }
            return true;
        }
    }
}
