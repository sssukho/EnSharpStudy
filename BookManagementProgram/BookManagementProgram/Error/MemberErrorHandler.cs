using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class MemberErrorHandler
    {
        MemberManagement memberManagement;
        List<Member> memberList;
        ErrorCheck errorCheck;
        PrintErrorMsg printErrorMsg;
        PrintInput printInput;

        bool error;

        public MemberErrorHandler()
        {

        }

        public MemberErrorHandler(MemberManagement memberManagement, List<Member> memberList, ErrorCheck errorCheck, PrintErrorMsg printErrorMsg, PrintInput printInput)
        {
            this.memberManagement = memberManagement;
            this.memberList = memberList;
            this.errorCheck = errorCheck;
            this.printErrorMsg = printErrorMsg;
            this.printInput = printInput;
        }

        public void ManageMenuErrorHandler(string menuSelect)
        {
            error = errorCheck.MainMenuInputError(menuSelect);

            if (error == true)
            {
                printErrorMsg.ManangeMenuInputErrorMsg();
                memberManagement.ViewMenu(memberList, memberManagement, errorCheck, printErrorMsg);
            }

            else
            {
                switch (menuSelect)
                {
                    case "1":
                        memberManagement.Register(memberList);
                        break;

                    case "2":
                        memberManagement.ViewEditMenu(memberList);
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
                        memberManagement.ViewMenu(memberList, memberManagement, errorCheck, printErrorMsg);
                        break;

                    case "4":
                        Environment.Exit(0);
                        break;
                }
            }
        }

    }
}
