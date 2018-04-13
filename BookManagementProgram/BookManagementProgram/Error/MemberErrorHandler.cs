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
        MemberErrorCheck errorCheck;
        PrintErrorMsg printErrorMsg;
        PrintInput printInput;
        Menu menu;

        bool error;

        public MemberErrorHandler()
        {

        }

        public MemberErrorHandler(MemberManagement memberManagement, List<Member> memberList, MemberErrorCheck errorCheck, PrintErrorMsg printErrorMsg, PrintInput printInput, Menu menu)
        {
            this.memberManagement = memberManagement;
            this.memberList = memberList;
            this.errorCheck = errorCheck;
            this.printErrorMsg = printErrorMsg;
            this.printInput = printInput;
            this.menu = menu;
        }
        
        public void ManageMenuErrorHandler(Menu menu, string menuSelect)
        {
            error = errorCheck.Number7InputError(menuSelect);
            if (error == true)
            {
                printErrorMsg.ManangeMenuInputErrorMsg();
                memberManagement.ViewMenu(menu, memberList, memberManagement, errorCheck, printErrorMsg);
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
                        memberManagement.ViewDeleteMenu(memberList);
                        break;

                    case "4":
                        memberManagement.ViewSearchMenu(memberList);
                        break;

                    case "5":
                        memberManagement.ViewMemberList(memberList, memberManagement, errorCheck, printErrorMsg);
                        break;

                    case "6":
                        menu.ViewMainMenu(memberList, memberManagement, errorCheck, printErrorMsg, menu); 
                        break;

                    case "7":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void EditMenuErrorHandler(string menuSelect, bool error, List<Member> inputMemberList)
        {
            if (error == true)
            {
                printErrorMsg.ManangeMenuInputErrorMsg();
                PrintMenu.EditMemberMenu();
                memberManagement.ViewEditMenu(inputMemberList);
            }

            else
            {
                switch (menuSelect)
                {
                    case "1":
                        memberManagement.EditSearchByName(inputMemberList, printInput.EditSearchName()); //에러체크할것(타입, 공백)
                        break;

                    case "2":
                        memberManagement.EditSearchByStudentID(inputMemberList, printInput.EditSearchStudentID()); //에러체크할것(타입, 공백)
                        break;

                    case "3":
                        memberManagement.ViewMenu(menu, memberList, memberManagement, errorCheck, printErrorMsg);
                        break;

                    case "4":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void EditSearchNameListIndexErrorHandler(List<Member> inputMemberList, int inputListIndex)
        {
            ConsoleKeyInfo input;
            printErrorMsg.NoMemberErrorMsg();
            input = Console.ReadKey(true);
            error = errorCheck.ConsoleInputErrorCheck(input);

            if (error == true)
            {
                Console.WriteLine("1 과 2 만 입력이 가능합니다.");
                EditSearchNameListIndexErrorHandler(inputMemberList, inputListIndex);
            }

            else
            {
                string name;
                switch(int.Parse(input.KeyChar.ToString()))
                {
                    case 1:
                        name = printInput.EditSearchName();
                        memberManagement.EditSearchByName(inputMemberList, name);
                        break;

                    case 2:
                        memberManagement.ViewEditMenu(inputMemberList);
                        break;
                }
            }
        }

        public void EditSearchIDListIndexErrorHandler(List<Member> inputMemberList, int inputListIndex)
        {
            ConsoleKeyInfo input;
            printErrorMsg.NoMemberErrorMsg();
            input = Console.ReadKey(true);
            error = errorCheck.ConsoleInputErrorCheck(input);

            if (error == true)
            {
                Console.WriteLine("1 과 2 만 입력이 가능합니다.");
                EditSearchIDListIndexErrorHandler(inputMemberList, inputListIndex);
            }

            else
            {
                string ID;
                switch (int.Parse(input.KeyChar.ToString()))
                {
                    case 1:
                        ID = printInput.EditSearchName();
                        memberManagement.EditSearchByStudentID(inputMemberList, ID);
                        break;

                    case 2:
                        memberManagement.ViewEditMenu(inputMemberList);
                        break;
                }
            }
        }

        public void DeleteMenuErrorHandler(string menuSelect, bool error, List<Member> inputMemberList)
        {
            if (error == true)
            {
                printErrorMsg.ManangeMenuInputErrorMsg();//예외처리 필요
                memberManagement.ViewDeleteMenu(inputMemberList);
            }

            else
            {
                switch (menuSelect)
                {
                    case "1":
                        memberManagement.DeleteSearchByName(inputMemberList, printInput.DeleteSearchName()); //에러체크할것(타입, 공백)
                        break;

                    case "2":
                        memberManagement.DeleteSearchByStudentID(inputMemberList, printInput.DeleteSearchStudentID()); //에러체크할것(타입, 공백)
                        break;

                    case "3":
                        memberManagement.ViewMenu(menu, memberList, memberManagement, errorCheck, printErrorMsg);
                        break;

                    case "4":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void DeleteSearchNameListIndexErrorHandler(List<Member> inputMemberList, int inputListIndex)
        {
            ConsoleKeyInfo input;
            printErrorMsg.NoMemberErrorMsg();
            input = Console.ReadKey(true);
            error = errorCheck.ConsoleInputErrorCheck(input);

            if (error == true)
            {
                Console.WriteLine("1 과 2 만 입력이 가능합니다.");
                DeleteSearchNameListIndexErrorHandler(inputMemberList, inputListIndex);
            }

            else
            {
                string name;
                switch (int.Parse(input.KeyChar.ToString()))
                {
                    case 1:
                        name = printInput.DeleteSearchName();
                        memberManagement.DeleteSearchByName(inputMemberList, name);
                        break;

                    case 2:
                        memberManagement.ViewDeleteMenu(inputMemberList);
                        break;
                }
            }
        }

        public void DeleteSearchIDListIndexErrorHandler(List<Member> inputMemberList, int inputListIndex)
        {
            ConsoleKeyInfo input;
            printErrorMsg.NoMemberErrorMsg();
            input = Console.ReadKey(true);
            error = errorCheck.ConsoleInputErrorCheck(input);

            if (error == true)
            {
                Console.WriteLine("1 과 2 만 입력이 가능합니다.");
                DeleteSearchIDListIndexErrorHandler(inputMemberList, inputListIndex);
            }

            else
            {
                string ID;
                switch (int.Parse(input.KeyChar.ToString()))
                {
                    case 1:
                        ID = printInput.DeleteSearchStudentID();
                        memberManagement.DeleteSearchByStudentID(inputMemberList, ID);
                        break;

                    case 2:
                        memberManagement.ViewDeleteMenu(inputMemberList);
                        break;
                }
            }
        }

        public void SearchMenuErrorHandler(string menuSelect, bool error, List<Member> inputMemberList)
        {
            if (error == true)
            {
                printErrorMsg.ManangeMenuInputErrorMsg();//예외처리 필요
                memberManagement.ViewSearchMenu(inputMemberList);
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
                        memberManagement.ViewMenu(menu, memberList, memberManagement, errorCheck, printErrorMsg);
                        break;

                    case "4":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void SearchNameListIndexErrorHandler(List<Member> inputMemberList, int inputListIndex)
        {
            ConsoleKeyInfo input;
            printErrorMsg.NoMemberErrorMsg();
            input = Console.ReadKey(true);
            error = errorCheck.ConsoleInputErrorCheck(input);

            if (error == true)
            {
                Console.WriteLine("1 과 2 만 입력이 가능합니다.");
                SearchNameListIndexErrorHandler(inputMemberList, inputListIndex);
            }

            else
            {
                string name;
                switch (int.Parse(input.KeyChar.ToString()))
                {
                    case 1:
                        name = printInput.SearchName();
                        memberManagement.SearchByName(inputMemberList, name);
                        break;

                    case 2:
                        memberManagement.ViewSearchMenu(inputMemberList);
                        break;
                }
            }
        }

        public void SearchIDListIndexErrorHandler(List<Member> inputMemberList, int inputListIndex)
        {
            ConsoleKeyInfo input;
            printErrorMsg.NoMemberErrorMsg();
            input = Console.ReadKey(true);
            error = errorCheck.ConsoleInputErrorCheck(input);

            if (error == true)
            {
                Console.WriteLine("1 과 2 만 입력이 가능합니다.");
                SearchIDListIndexErrorHandler(inputMemberList, inputListIndex);
            }

            else
            {
                string ID;
                switch (int.Parse(input.KeyChar.ToString()))
                {
                    case 1:
                        ID = printInput.SearchStudentID();
                        memberManagement.SearchByStudentID(inputMemberList, ID);
                        break;

                    case 2:
                        memberManagement.ViewSearchMenu(inputMemberList);
                        break;
                }
            }
        }


        //정말 삭제하시겠습니까 에러 헨들러 작업 요망
        public void DeleteConfirmErrorHandler(bool error)
        {
            if(error == true)
            {
            }
        }

    }
}
