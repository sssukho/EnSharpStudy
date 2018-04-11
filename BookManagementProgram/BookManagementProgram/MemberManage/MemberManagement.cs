using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class MemberManagement : Member
    {
        List<Member> memberList;
        ErrorCheck errorCheck;
        PrintInput printInput;
        MemberErrorHandler errorHandler;
        MemberManagement memberManagement;
        Member member;
        PrintErrorMsg printErrorMsg;
        PrintCompleteMsg printCompleteMsg;
        
        string menuSelect;
        bool error;

        public MemberManagement() : base() { }
        
        public void ViewMenu(List<Member> memberList, MemberManagement memberManagement, ErrorCheck errorCheck, PrintErrorMsg printErrorMsg)
        {
            this.memberManagement = memberManagement;
            this.memberList = memberList;
            this.errorCheck = errorCheck;
            this.printErrorMsg = printErrorMsg;
            this.printInput = new PrintInput();
            printCompleteMsg = new PrintCompleteMsg();

            PrintMenu.ViewMemberManageMenu();
            menuSelect = Console.ReadLine();

            errorHandler = new MemberErrorHandler(memberManagement, memberList, errorCheck, printErrorMsg, printInput);
            errorHandler.ManageMenuErrorHandler(menuSelect); 
        }

       public void Register(List<Member> memberList)
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
                printCompleteMsg.RegisterCompleteMsg();
                ViewMenu(memberList, memberManagement, errorCheck, printErrorMsg);
            }
        }

        public void ViewEditMenu(List<Member> memberList)
        {
            PrintMenu.EditMemberMenu();
            menuSelect = Console.ReadLine();
            errorHandler.EditMenuErrorHandler(menuSelect, memberList);
        }

        public void Edit(int listIndex, List<Member> inputMemberList)
        {
            inputMemberList[listIndex] = printInput.Edit(member, errorHandler);
            error = errorCheck.EditErrorCheck(member);

            if (error == true)
            {
                printErrorMsg.EditInputErrorMsg();
                inputMemberList[listIndex] = printInput.Edit(member, errorHandler);
            }

            else
            {
                printCompleteMsg.EditCompleteMsg();
                ViewEditMenu(inputMemberList);
            }
        }
        
        public void SearchByName(List<Member> inputMemberList, string inputName)
        {
            int listIndex;
            listIndex = inputMemberList.FindIndex(member => member.Name.Equals(inputName));
            Edit(listIndex, inputMemberList);
        }
        
        public void SearchByStudentID(List<Member> inputMemberList, string inputID)
        {
            int listIndex;
            listIndex = inputMemberList.FindIndex(member => member.StudentId.Equals(inputID));
            Edit(listIndex, inputMemberList);
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
                ViewMenu(memberList, memberManagement, errorCheck, printErrorMsg);
            }
        }
    }
}
