using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class MemberManagement
    {
        List<Member> memberList;
        ErrorCheck errorCheck;
        Member newMember;
        PrintInput printInput;
        PrintErrorMsg printErrorMsg;

        bool error;
        string menuSelect;

        public MemberManagement()
        {
            memberList = new List<Member>();
            errorCheck = new ErrorCheck();
            printInput = new PrintInput();
            printErrorMsg = new PrintErrorMsg();
        }

        public void ViewMenu()
        {
            PrintMenu.ViewMemberManageMenu();
            menuSelect = Console.ReadLine();

            ManageMenuErrorHandler(menuSelect);
        }

        public void Register()
        {
            newMember = printInput.Register(newMember);
            error = errorCheck.RegisterErrorCheck(newMember);

            if (error == true)
            {
                printErrorMsg.RegisterInputErrorMsg();
                newMember = printInput.Register(newMember);
            }

            else
            {
                memberList.Add(newMember);
            }
        }

        public void Edit(Member member)
        {
            PrintMenu.EditMemberMenu();
            menuSelect = Console.ReadLine();

            EditMenuErrorHandler(menuSelect);
        }

        public void Delete(Member member)
        {

        }

        public void Search(Member member)
        {

        }

        public void ManageMenuErrorHandler(string menuSelect)
        {
            error = errorCheck.MainMenuInputError(menuSelect);

            if (error == true)
            {
                printErrorMsg.ManangeMenuInputErrorMsg();
                ViewMenu();
            }

            else
            {
                switch (menuSelect)
                {
                    case "1":
                        Register();
                        break;

                    case "2":
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

        public void EditMenuErrorHandler(string menuSelect)
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
                        Register();
                        break;

                    case "2":
                        break;

                    case "3":
                        break;

                    case "4":
                        break;

                }
            }
        }
    }
}
