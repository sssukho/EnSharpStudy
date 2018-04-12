using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

//에러 처리 다 핸들러로 넘기기
namespace BookManagementProgram
{
    class MemberManagement : Member
    {
        Menu menu;
        List<Member> memberList;
        MemberErrorCheck errorCheck;
        PrintInput printInput;
        MemberErrorHandler errorHandler;
        MemberManagement memberManagement;
        PrintErrorMsg printErrorMsg;
        PrintCompleteMsg printCompleteMsg;

        bool error;
        string menuSelect;

        public MemberManagement() : base() { }
        
        public void ViewMenu(Menu menu, List<Member> memberList, MemberManagement memberManagement, 
            MemberErrorCheck errorCheck, PrintErrorMsg printErrorMsg)
        {
            this.menu = menu;
            this.memberManagement = memberManagement;
            this.memberList = memberList;
            this.errorCheck = errorCheck;
            this.printErrorMsg = printErrorMsg;
            printInput = new PrintInput();
            printCompleteMsg = new PrintCompleteMsg();

            PrintMenu.ViewMemberManageMenu();
            menuSelect = Console.ReadLine();

            errorHandler = new MemberErrorHandler(memberManagement, memberList, errorCheck, printErrorMsg, printInput, menu);
            errorHandler.ManageMenuErrorHandler(menu, menuSelect); 
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
                ViewMenu(menu, memberList, memberManagement, errorCheck, printErrorMsg);
            }
        }

        public void ViewEditMenu(List<Member> memberList)
        {
            PrintMenu.EditMemberMenu();
            menuSelect = Console.ReadLine(); 
            error = errorCheck.Number4InputError(menuSelect);
            errorHandler.EditMenuErrorHandler(menuSelect, error, memberList);
        }

        public void Edit(int listIndex, List<Member> inputMemberList)
        {
            inputMemberList[listIndex] = printInput.Edit(inputMemberList[listIndex], errorHandler);
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                printErrorMsg.NoMemberErrorMsg(); //순서 에러 쳌
                Edit(listIndex, inputMemberList);
            }

            else
            {
                printCompleteMsg.EditCompleteMsg();
                ViewEditMenu(inputMemberList);
            }
        }
        
        public void EditSearchByName(List<Member> inputMemberList, string inputName)
        {
            int listIndex;
            bool error;

            listIndex = inputMemberList.FindIndex(member => member.Name.Equals(inputName));
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if(error == true)
            {
                errorHandler.EditSearchNameListIndexErrorHandler(inputMemberList, listIndex);
            }

            else
            {
                Edit(listIndex, inputMemberList);
            }
        }
        
        public void EditSearchByStudentID(List<Member> inputMemberList, string inputID)
        {
            int listIndex;
            bool error;

            listIndex = inputMemberList.FindIndex(member => member.StudentId.Equals(inputID));
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                errorHandler.EditSearchIDListIndexErrorHandler(inputMemberList, listIndex);   
            }

            else
            {
                Edit(listIndex, inputMemberList);
            }
        }

        public void ViewDeleteMenu(List<Member> inputMemberList)
        {
            PrintMenu.DeleteMemberMenu();
            menuSelect = Console.ReadLine();
            error = errorCheck.Number4InputError(menuSelect);
            errorHandler.DeleteMenuErrorHandler(menuSelect, error, inputMemberList);
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
                ViewDeleteMenu(inputMemberList);
            }
        }

        public void DeleteSearchByName(List<Member> inputMemberList, string inputName)
        {
            int listIndex;
            bool error;

            listIndex = inputMemberList.FindIndex(member => member.Name.Equals(inputName));
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                errorHandler.DeleteSearchNameListIndexErrorHandler(inputMemberList, listIndex);
            }

            else
            {
                printCompleteMsg.DeleteCompleteMsg();
                Delete(listIndex, inputMemberList);
            }
        }

        public void DeleteSearchByStudentID(List<Member> inputMemberList, string inputID)
        {
            int listIndex;
            bool error;

            listIndex = inputMemberList.FindIndex(member => member.StudentId.Equals(inputID));
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                errorHandler.DeleteSearchIDListIndexErrorHandler(inputMemberList, listIndex);
            }

            else
            {
                printCompleteMsg.DeleteCompleteMsg();
                Delete(listIndex, inputMemberList);
            }
        }

        public void ViewSearchMenu(List<Member> inputMemberList)
        {
            PrintMenu.SearchMemberMenu();
            menuSelect = Console.ReadLine();
            error = errorCheck.Number4InputError(menuSelect);
            errorHandler.SearchMenuErrorHandler(menuSelect, error, inputMemberList);
        }

        public void Search(int listIndex, List<Member> inputMemberList)
        {
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                printErrorMsg.NoMemberErrorMsg();
                Search(listIndex, inputMemberList);
            }

            else
            {
                printInput.SearchCheck(inputMemberList[listIndex], errorHandler);
                ViewSearchMenu(inputMemberList);
            }
        }

        public void SearchByName(List<Member> inputMemberList, string inputName)
        {
            int listIndex;
            bool error;

            listIndex = inputMemberList.FindIndex(member => member.Name.Equals(inputName));
            error = errorCheck.ListIndexErrorCheck(listIndex);

            if (error == true)
            {
                errorHandler.SearchNameListIndexErrorHandler(inputMemberList, listIndex);
            }

            else
            {
                Search(listIndex, inputMemberList);
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
                Search(listIndex, inputMemberList);
            }
        }

        public void ViewMemberList(List<Member> inputMemberList, MemberManagement memberManagement, MemberErrorCheck errorCheck, PrintErrorMsg printErrorMsg)
        {
            printInput.ViewAllMember(inputMemberList);
            ViewMenu(menu, memberList, memberManagement, errorCheck, printErrorMsg);
        }
    }
}
