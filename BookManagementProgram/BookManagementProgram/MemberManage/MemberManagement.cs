using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BookManagementProgram
{
    class MemberManagement : Member
    {
        List<Member> memberList;
        ErrorCheck errorCheck;
        PrintInput printInput;
        MemberErrorHandler errorHandler;
        MemberManagement memberManagement;
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
            Member newMember;
            newMember = printInput.Register();
            error = errorCheck.RegisterErrorCheck(newMember);

            if (error == true)
            {
                printErrorMsg.RegisterInputErrorMsg();
                Register(memberList);
            }
            
            else
            {
                memberList.Add(newMember);
                printCompleteMsg.RegisterCompleteMsg();
                ViewMenu(memberList, memberManagement, errorCheck, printErrorMsg);
            }
        }

        public void ViewEditMenu(List<Member> memberList)
        {
            PrintMenu.EditMemberMenu();
            menuSelect = Console.ReadLine(); 
            error = errorCheck.EditMenuInputError(menuSelect);
            errorHandler.EditMenuErrorHandler(menuSelect, memberList);
        }

        public void Edit(int listIndex, List<Member> inputMemberList)
        {
            inputMemberList[listIndex] = printInput.Edit(inputMemberList[listIndex], errorHandler);
            error = errorCheck.EditErrorCheck(inputMemberList[listIndex]);

            if (error == true)
            {
                printErrorMsg.NoMemberErrorMsg();
                Edit(listIndex, inputMemberList);
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
            bool error;

            listIndex = inputMemberList.FindIndex(member => member.Name.Equals(inputName));
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if(error == true)
            {
                errorHandler.SearchNameListIndexErrorHandler(inputMemberList, listIndex);
            }

            else
            {
                Edit(listIndex, inputMemberList);
            }
        }
        
        public void SearchByStudentID(List<Member> inputMemberList, string inputID)
        {
            int listIndex;
            bool error;

            listIndex = inputMemberList.FindIndex(member => member.StudentId.Equals(inputID));
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                errorHandler.SearchIDListIndexErrorHandler(inputMemberList, listIndex);   
            }

            else
            {
                Edit(listIndex, inputMemberList);
            }
        }

        public void Delete(int listIndex, List<Member> inputMemberList)
        {
            string confirm;

            confirm = printInput.DeleteCheck(inputMemberList[listIndex], errorHandler);
            error = errorCheck.DeleteErrorCheck(inputMemberList[listIndex], confirm);

            if (error == true)
            {
                printErrorMsg.NoMemberErrorMsg();
                Delete(listIndex, inputMemberList);
            }

            else
            {
                inputMemberList.RemoveAt(listIndex);
                printCompleteMsg.EditCompleteMsg();
                ViewEditMenu(inputMemberList);
            }
        }
    }
}
