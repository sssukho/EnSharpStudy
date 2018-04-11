using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class MemberErrorHandler : MemberManagement
    {
        ErrorCheck errorCheck;
        PrintErrorMsg printErrorMsg;
        MemberManagement memberManagement;
        PrintInput printInput;

        bool error;

        public MemberErrorHandler(ErrorCheck errorCheck, MemberManagement memberManagement)
        {
            this.errorCheck = errorCheck;
            this.memberManagement = memberManagement;
            this.printErrorMsg = new PrintErrorMsg();
            this.printInput = new PrintInput();
        }

        public void ManageMenuErrorHandler(string menuSelect)
        {
            error = errorCheck.MainMenuInputError(menuSelect);

            if (error == true)
            {
                printErrorMsg.ManangeMenuInputErrorMsg();
                memberManagement.ViewMenu(memberManagement);
            }

            else
            {
                switch (menuSelect)
                {
                    case "1":
                        memberManagement.Register();
                        break;

                    case "2":
                        memberManagement.ViewEditMenu();
                        break;

                    case "3":
                        break;

                    case "4":
                        break;

                    case "5":
                        break;

                    case "6":
                        break;

                    case "7":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void EditMenuErrorHandler(string menuSelect, List<Member> inputMemberList)
        {
            error = errorCheck.MainMenuInputError(menuSelect);

            if (error == true)
            {
                printErrorMsg.ManangeMenuInputErrorMsg();
                PrintMenu.EditMemberMenu();
            }

            else
            {
                switch (menuSelect)
                {
                    case "1":
                        memberManagement.SearchByName(inputMemberList, printInput.SearchName()); //에러체크할것(타입, 공백)
                        break;

                    case "2":
                        memberManagement.SearchByStudentID(inputMemberList, printInput.SearchStudentID()); //에러체크할것(타입, 공백)
                        break;

                    case "3":
                        memberManagement.ViewMenu(memberManagement);
                        break;

                    case "4":
                        Environment.Exit(0);
                        break;

                }
            }
        }

    }
}
