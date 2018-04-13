using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    /// <summary>
    /// 회원 관리 기능 수행 중 일어나는 에러체크
    /// 에러가 나면 true값을 반환하여 코드의 가독성을 높이려 했음
    /// </summary>
    class MemberErrorCheck
    {
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

        public bool Number7InputError(string input)
        {
            if (input == "1" || input == "2" || input == "3" || input == "4"
                || input == "5" || input == "6" || input == "7")
            {
                return false;
            }
            return true;
        }

        public bool RegisterErrorCheck(Member newMember)
        {
            if(newMember == null)
            {
                return true;
            }
            return false;
        }

        public bool DeleteErrorCheck(Member inputMember, string confirm)
        {
            if(confirm == "Y" || confirm == "y" || confirm == "N" || confirm == "n")
            {
                if(inputMember == null)
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

        public bool DeleteConfirmErrorCheck(string inputCheck)
        {
            if(inputCheck == "y" || inputCheck == "Y" || inputCheck == "n" || inputCheck == "N")
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        public bool ListIndexErrorCheck(int inputListIndex)
        {
            if(inputListIndex == -1)
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
            if(char.IsDigit(input.KeyChar))
            {
                intInput = int.Parse(input.KeyChar.ToString());

                if(intInput == 1 || intInput == 2)
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
