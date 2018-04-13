using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    /// <summary>
    /// 도서 관리 기능 수행 중 일어나는 에러 체크
    /// 에러가 나면 true 값을 반환하여 도서 관리 기능 수행 코드에서의 가독성 높이려 했음
    /// </summary>
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

        public bool Number4InputError(string input)
        {
            if (input == "1" || input == "2" || input == "3" || input == "4")
            {
                return false;
            }
            return true;
        }

        public bool Number5InputError(string input)
        {
            if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5")
            {
                return false;
            }
            return true;
        }

        public bool RegisterErrorCheck(Book newBook)
        {
            if (newBook == null)
            {
                return true;
            }
            return false;
        }

        public bool ListIndexErrorCheck(int inputListIndex)
        {
            if (inputListIndex == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        public bool DeleteErrorCheck(Book inputBook, string confirm)
        {
            if (confirm == "Y" || confirm == "y" || confirm == "N" || confirm == "n")
            {
                if (inputBook == null)
                {
                    return true;
                }
                return false;
            }

            else
            {
                return true;
            }
        }
    }
}
