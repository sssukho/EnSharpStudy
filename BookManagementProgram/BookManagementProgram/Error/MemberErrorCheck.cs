using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
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
    
        public bool MainMenuInputError(string input)
        {
            if (input == "1" || input == "2" || input == "3" || input == "4")
            {
                return false;
            }
            return true;
        }

        public bool ManagementMenuInputError(string input)
        {
            if (input == "1" || input == "2" || input == "3" || input == "4"
                || input == "5" || input == "6" || input == "7")
            {
                return false;
            }
            return true;
        }

        public bool EditMenuInputError(string input) //4numberInputError로 통합
        {
            if(input == "1" || input == "2" || input == "3" || input == "4")
            {
                return false;
            }
            return true;
        }

        public bool DeleteMenuInputError(string input)
        {
            if (input == "1" || input == "2" || input == "3" || input == "4")
            {
                return false;
            }
            return true;
        }

        
        public bool RegisterErrorCheck(Member newMember) //타입 안맞을때
        {
            if(newMember == null)
            {
                return true;
            }
            return false;
        }

        //오류 일때가 트루(index가 음이어서 outofindex 오류 나면 인자를 listindex로
        public bool EditErrorCheck(Member inputMember)
        {
            return false;
        }

        //오류 일때가 트루(index가 음이어서 outofindex 오류 나면 인자를 listindex로
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
