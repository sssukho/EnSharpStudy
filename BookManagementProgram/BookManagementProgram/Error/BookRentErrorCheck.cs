using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    /// <summary>
    /// 도서 대출 기능 수행 중 일어나는 에러 체크
    /// 에러가 나면 true값을 반환하여 코드의 가독성을 높이려 했음
    /// </summary>
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
