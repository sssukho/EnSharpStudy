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
        PrintInput printInput;
        MemberErrorHandler errorHandler;
        MemberManagement memberManagement;
        Member member;
        PrintErrorMsg printErrorMsg;
        
        string menuSelect;
        bool error;

        public MemberManagement()
        {
            memberList = new List<Member>();
            errorCheck = new ErrorCheck();
            printInput = new PrintInput();
            printErrorMsg = new PrintErrorMsg();
        }

        public void ViewMenu(MemberManagement memberManagement)
        {
            this.memberManagement = memberManagement;
            PrintMenu.ViewMemberManageMenu();
            menuSelect = Console.ReadLine();

            errorHandler = new MemberErrorHandler(errorCheck, memberManagement);
            errorHandler.ManageMenuErrorHandler(menuSelect); 
        }

       public void Register()
        {
            member = printInput.Register(member);
            error = errorCheck.RegisterErrorCheck(member);

            if (error == true)
            {
                printErrorMsg.RegisterInputErrorMsg();
                member = printInput.Register(member);
            }

            else
            {
                memberList.Add(member);
                PrintCompleteMsg CompleteMsg = new PrintCompleteMsg();
                CompleteMsg.RegisterCompleteMsg();
                MemberManagement memberManagement = new MemberManagement();
                memberManagement.ViewMenu(memberManagement);
            }
        }

        public void ViewEditMenu()
        {
            PrintMenu.EditMemberMenu();
            menuSelect = Console.ReadLine();
            //member가 null 값임 현재
            errorHandler.EditMenuErrorHandler(menuSelect, memberList);
        }

        public void Edit()
        {
            member = printInput.Edit(member, errorHandler);
            error = errorCheck.EditErrorCheck(member);

            if (error == true)
            {
                printErrorMsg.EditInputErrorMsg();
                
            }

            else
            {
                PrintMenu.EditMemberMenu();
                member = printInput.Edit(member, errorHandler);
            }
        }
        
        public int SearchByName(List<Member> inputMemberList, string inputName)
        {
            int listIndex;
            listIndex = inputMemberList.FindIndex(member => member.Name.Equals(inputName));

            return listIndex;
        }
        
        public int SearchByStudentID(List<Member> inputMemberList, string inputID)
        {
            int listIndex;
            listIndex = inputMemberList.FindIndex(member => member.StudentId.Equals(inputID));

            return listIndex;
        }

        public void Delete(Member member)
        {
            member = printInput.Register(member);
            error = errorCheck.RegisterErrorCheck(member);

            if (error == true)
            {
                printErrorMsg.DeleteInputErrorMsg();
                member = printInput.Register(member);
            }

            else
            {
                PrintCompleteMsg CompleteMsg = new PrintCompleteMsg();
                CompleteMsg.DeleteCompleteMsg();
                MemberManagement memberManagement = new MemberManagement();
                memberManagement.ViewMenu(memberManagement);
            }
        }
        

       
    }
}
