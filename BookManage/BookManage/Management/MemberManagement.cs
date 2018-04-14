﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BookManage
{
    class MemberManagement
    {
        private const int REGISTER = 1;
        private const int EDIT = 2;
        private const int REMOVE = 3;
        private const int SEARCH = 4;
        private const int PRINT_MEMBER_LIST = 5;
        private const int PREVIOUS = 6;
        private const int EXIT = 7;
        private const int REINPUT = 1;
        private const int GOPREV = 2;

        Menu menu;
        List<Member> memberList;
        Print print;
        ErrorCheck errorCheck;

        int menuSelect;

        public MemberManagement(Menu menu, List<Member> memberList)
        {
            this.menu = menu;
            this.memberList = memberList;
            this.print = Print.GetInstance();
            this.errorCheck = ErrorCheck.GetInstance();
        }

        public void ViewMenu()
        {
            print.Menu("회원관리");
            menuSelect = int.Parse(Console.ReadLine()); //에러체크
            
            switch(menuSelect)
            {
                case REGISTER:
                    Register();
                    break;
                case EDIT:
                    Edit();
                    break;
                case REMOVE:
                    Delete();
                    break;
                case SEARCH:
                    Search();
                    break;
                case PRINT_MEMBER_LIST:
                    PrintMemberList();
                    break;
                case PREVIOUS:
                    menu.ViewMenu();
                    break;
                case EXIT:
                    Environment.Exit(0);
                    break;
            }
        }

        public void Register()
        {
            Member newMember;
            newMember = print.MemberRegister(); //에러체크

            memberList.Add(newMember);
            print.CompleteMsg("등록이 완료");
            ViewMenu();
        }

        public void Edit()
        {
            string inputID;
            int listIndex;
            int menuInput;

            print.Search("편집할 회원의 학번을 ");
            inputID = Console.ReadLine(); //타입 에러처리
            listIndex = memberList.FindIndex(member => member.StudentId.Equals(inputID));

            if(listIndex == -1) //리스트-1 => 매칭 되는 item 없다는 뜻
            {
                print.ErrorMsg("존재하지않는회원");
                menuInput = int.Parse(Console.ReadLine()); //타입 에러처리
                if(menuInput == REINPUT)
                {
                    Edit();
                }
                if(menuInput == GOPREV)
                {
                    ViewMenu();
                }
                else
                {
                    //error처리
                }
            }
            else //리스트에 존재
            {
                memberList[listIndex] = print.MemberEdit(memberList[listIndex]);
                print.CompleteMsg("편집이 완료");
                ViewMenu();
            }
        }

        public void Delete()
        {
            string inputID;
            string confirm;
            int listIndex;
            int menuInput;

            print.Search("삭제할 회원의 학번을 ");
            inputID = Console.ReadLine(); //타입 에러처리
            listIndex = memberList.FindIndex(member => member.StudentId.Equals(inputID));
            if (listIndex == -1) //리스트-1 => 매칭 되는 item 없다는 뜻
            {
                print.ErrorMsg("존재하지않는회원");
                menuInput = int.Parse(Console.ReadLine()); //타입 에러처리
                if (menuInput == REINPUT)
                {
                    Delete();
                }
                if (menuInput == GOPREV)
                {
                    ViewMenu();
                }
                else
                {
                    //error처리
                }
            }
            else //리스트에 존재
            {
                print.MemberDelete(memberList[listIndex]);
                confirm = Console.ReadLine();

                if (confirm == "Y" || confirm == "y")
                {
                    memberList.RemoveAt(listIndex);
                    print.CompleteMsg("회원 삭제가 완료 ");
                    ViewMenu();
                }
                
                else if(confirm == "N" || confirm == "n")
                {
                    Console.WriteLine("이전 메뉴로 돌아갑니다...");
                    Console.WriteLine("\t2초 후에 메뉴로 돌아갑니다...");
                    Thread.Sleep(2000);
                    ViewMenu();
                }

                else
                {
                    print.ErrorMsg("Y/N오류"); //에러체크
                }
            }
        }

        public void Search()
        {
            string inputID;
            int listIndex;
            int menuInput;

            print.Search("검색할 회원의 학번을 ");
            inputID = Console.ReadLine(); //타입 에러처리
            listIndex = memberList.FindIndex(member => member.StudentId.Equals(inputID));

            if (listIndex == -1) //리스트-1 => 매칭 되는 item 없다는 뜻
            {
                print.ErrorMsg("존재하지않는회원");
                menuInput = int.Parse(Console.ReadLine()); //타입 에러처리
                if (menuInput == REINPUT)
                {
                    Delete();
                }
                if (menuInput == GOPREV)
                {
                    ViewMenu();
                }
                else
                {
                    //error처리
                }
            }
            else //리스트에 존재
            {
                print.MemberInfo(memberList[listIndex]);
                ViewMenu();
            }
        }

        public void PrintMemberList()
        {
            print.AllMember(memberList);
            ViewMenu();
        }

    }
}
