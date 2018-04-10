using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class ErrorCheck
    {
        Member member;
        MemberManagement memberManagement;
        Book book;
        BookManagement bookManagement;
        BookRent bookRent;

        public ErrorCheck()
        {

        }

        public bool MainMenuInputError(string input)
        {
            if (input == "1" || input == "2" || input == "3" || input == "4")
            {
                switch (input)
                {
                    case "1":
                        return false;

                    case "2":
                        return false;

                    case "3":
                        return false;

                    case "4":
                        return false;
                }
            }
            return true;
        }

        public bool ManagementMenuInputError(string input)
        {
            if (input == "1" || input == "2" || input == "3" || input == "4"
                || input == "5" || input == "6" || input == "7")
            {
                switch (input)
                {
                    case "1":
                        return false;

                    case "2":
                        return false;

                    case "3":
                        return false;

                    case "4":
                        return false;

                    case "5":
                        return false;

                    case "6":
                        return false;

                    case "7":
                        return false;
                }
            }
            return true;
        }

        //등록 시킬 때 예외처리, 오류 일때가 트루
        public bool RegisterErrorCheck(Member newMember)
        {
            return true;
        }
    }
}
