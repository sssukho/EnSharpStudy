using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BookManage
{
    /// <MemberManagement클래스>
    ///  모든 회원들의 데이터를 관리하는 클래스
    ///  Menu 클래스에서 생성된 회원List 데이터를 생성자로 받아와 기능들을 수행함.
  
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

        private const int NO_MEMBER = -1;

        Menu menu;
        List<Member> memberList;
        Print print;
        ErrorCheck errorCheck;
        MemberManagement memberManagement;
        string menuSelect;

        public MemberManagement(Menu menu, List<Member> memberList)
        {
            this.menu = menu;
            this.memberList = memberList;
            this.print = Print.GetInstance();
            this.errorCheck = ErrorCheck.GetInstance();
            this.memberManagement = this; 
            //등록 혹은 편집 기능을 하는 메소드가 다른 클래스에 있어서 현재 MemberManagement
            //인스턴스 전체를 가리키고 있는 this로 membermanagement 에 할당해준 뒤
            //다른 클래스로 넘길때 인자로 넘겨줌
        }

        public void ViewMenu()
        {
            while (true)
            {
                print.Menu("회원관리");
                menuSelect = CancelKey.ReadLineWithCancel();
                if (menuSelect == null) menu.ViewMenu(); //입력 중간에 ESC키 받으면 menuSelect값이 null이 되어
                                                                        //이전 메뉴로 돌아가게됨.
                if (errorCheck.Number(menuSelect, "7지선다") == false)
                {
                    break;
                }
                print.MenuErrorMsg("7지선다오류");
            }

            switch (int.Parse(menuSelect))
            {
                case REGISTER:
                    Register();
                    break;
                case EDIT:
                    Edit(this);
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

        public void Register() //멤버 등록
        {
            Member newMember;
            newMember = print.MemberRegister(memberManagement);

            memberList.Add(newMember);
            print.CompleteMsg("등록이 완료");
            ViewMenu();
        }

        public void Edit(MemberManagement memberManagement) //멤버 편집
        {
            string inputID;
            int listIndex;

            while(true)
            {
                print.Search("편집할 회원의 학번을 ");
                inputID = CancelKey.ReadLineWithCancel();
                if (inputID == null) ViewMenu();

                if (errorCheck.MemberID(inputID) == false)
                {
                    break;
                }
            }

            listIndex = memberList.FindIndex(member => member.StudentId.Equals(inputID));
            //listIndex = 회원 리스트에서 입력받은 inputID 값과 일치하는 item의 index를 반환함
            if (listIndex == NO_MEMBER) //리스트-1 => 매칭 되는 item 없다는 뜻
            {
                while (true) //입력시 정규표현식에 맞지 않으면 반복문 탈출 불가(같은 부분 지속적으로 입력받기 위함)
                {
                    print.ErrorMsg("존재하지않는회원");
                    menuSelect = CancelKey.ReadLineWithCancel(); 
                    if (menuSelect == null) ViewMenu(); //입력 중간에 ESC키를 누르면 이전 메뉴로
                    if (errorCheck.Number(menuSelect, "선택") == false) //에러 안나면 나감
                    {
                        break;
                    }
                    print.MenuErrorMsg("2지선다오류");
                }
                switch (int.Parse(menuSelect))
                {
                    case REINPUT:
                        Edit(this);
                        break;

                    case GOPREV:
                        ViewMenu();
                        break;
                }
            }

            else //리스트에 존재
            {
                memberList[listIndex] = print.MemberEdit(memberList[listIndex], this);
                print.CompleteMsg("편집이 완료");
                ViewMenu();
            }
        }

        
        public void Delete() //멤버 삭제 메소드
        {
            string inputID;
            string confirm;
            int listIndex;

            while(true)
            {
                print.Search("삭제할 회원의 학번을 ");
                inputID = CancelKey.ReadLineWithCancel();
                if (inputID == null) ViewMenu();
                if (errorCheck.MemberID(inputID) == false)
                {
                    break;
                }
            }

            listIndex = memberList.FindIndex(member => member.StudentId.Equals(inputID));
            if (listIndex == NO_MEMBER) //리스트-1 => 매칭 되는 item 없다는 뜻
            {
                while(true)
                {
                    print.ErrorMsg("존재하지않는회원");
                    menuSelect = CancelKey.ReadLineWithCancel();
                    if (menuSelect == null) ViewMenu();
                    if (errorCheck.Number(menuSelect, "선택") == false) //에러 값이 false이기 때문에 반복문 나감
                    {
                        break;
                    }
                    print.MenuErrorMsg("2지선다오류");
                }
                switch (int.Parse(menuSelect))
                {
                    case REINPUT:
                        Edit(this);
                        break;

                    case GOPREV:
                        ViewMenu();
                        break;
                }
            }
            
            else //리스트에 입력받은 학번과 일치하는 아이템 있음.
            {
                while(true)
                {
                    print.MemberDelete(memberList[listIndex]);
                    confirm = CancelKey.ReadLineWithCancel();
                    if (confirm == null) ViewMenu(); 
                    if (errorCheck.Confirm(confirm) == false) //입력 양식 안맞을때
                    {
                        break;
                    }
                    print.MenuErrorMsg("Y/N오류");
                }

                if (confirm == "Y" || confirm == "y")
                {
                    memberList.RemoveAt(listIndex);
                    print.CompleteMsg("회원 삭제가 완료 ");
                    ViewMenu();
                }

                else if (confirm == "N" || confirm == "n")
                {
                    Console.WriteLine("\n\t2초 후에 메뉴로 돌아갑니다...");
                    Thread.Sleep(2000);
                    ViewMenu();
                }
            }
        }

        public void Search() //회원 검색
        {
            string inputID;
            int listIndex;

            while (true)
            {
                print.Search("검색할 회원의 학번을 ");
                inputID = CancelKey.ReadLineWithCancel();
                if (inputID == null) ViewMenu();
                errorCheck.MemberID(inputID);
                if(errorCheck.MemberID(inputID) == false)
                {
                    break;
                }
                print.MenuErrorMsg("2지선다오류");
            }
            listIndex = memberList.FindIndex(member => member.StudentId.Equals(inputID));

            if (listIndex == NO_MEMBER) //리스트-1 => 매칭 되는 item 없다는 뜻
            {
                while(true)
                {
                    print.ErrorMsg("존재하지않는회원");
                    menuSelect = CancelKey.ReadLineWithCancel();
                    if (menuSelect == null) ViewMenu();
                    if (errorCheck.Number(menuSelect, "선택") == false)
                    {
                        break;
                    }
                    print.MenuErrorMsg("2지선다오류");
                }

                switch (int.Parse(menuSelect))
                {
                    case REINPUT:
                        Search();
                        break;

                    case GOPREV:
                        ViewMenu();
                        break;
                }
            }
            else //리스트에 입력받은 학번에 부합하는 아이템 존재
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
