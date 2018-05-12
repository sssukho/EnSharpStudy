using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class MemberManagement
    {
        Print print;
        ErrorCheck errorCheck;
        AdminMenu adminMenu;
        DAO dao;

        public MemberManagement(AdminMenu adminMenu, DAO dao)
        {
            print = Print.GetInstance();
            errorCheck = ErrorCheck.GetInstance();
            this.adminMenu = adminMenu;
            this.dao = dao;
        }

        //회원등록
        public void RegisterMember()
        {
            MemberVO newMember;
            newMember = print.RegisterMember();

            if(dao.IsMemberDulplicated(newMember.Id) == true)
            {
                print.ErrorMsg("중복 아이디");
                adminMenu.MemberManagementMenu();
                return;
            }

            dao.Insert(newMember);

            print.CompleteMsg("회원 등록 완료");
            adminMenu.MemberManagementMenu();
            return;
        }

        //회원정보 수정
        public void EditMember()
        {
            MemberVO foundMember = SearchMember("editSearch");

            foundMember = print.EditMember(foundMember);

            dao.Update("member", "phoneNumber", foundMember.PhoneNumber, "id", foundMember.Id);
            dao.Update("member", "address", foundMember.Address, "id", foundMember.Id);
            
            print.CompleteMsg("회원 정보 수정 완료");
            adminMenu.MemberManagementMenu();
            return;
        }

        //회원 정보 삭제
        public void RemoveMember()
        {
            string confirm;

            MemberVO foundMember = SearchMember("removeSearch");
            print.DeleteMember(foundMember);

            confirm = Console.ReadLine();
            if (errorCheck.Confirm(confirm))
            {
                print.MenuErrorMsg("Y/N오류");
                adminMenu.MemberManagementMenu();
                return;
            }

            dao.Delete("member", "id", foundMember.Id);

            print.CompleteMsg("회원 삭제 완료");
            adminMenu.MemberManagementMenu();
            return;
        }

        //회원 검색
        public MemberVO SearchMember(string searchType)
        {
            string searchID;

            switch (searchType)
            {
                case "editSearch":
                    print.Search("정보를 편집할 회원의 아이디");
                    break;
                case "removeSearch":
                    print.Search("삭제할 회원의 아이디");
                    break;
                case "justSearch":
                    print.Search("검색할 회원의 아이디");
                    break;
            }

            searchID = Console.ReadLine();

            MemberVO foundMember = dao.Select(searchID);

            if (searchType.Equals("justSearch"))
            {
                print.MemberInfo(foundMember);
                adminMenu.MemberManagementMenu();
            }
            return foundMember;
        }

        //회원명단 출력
        public void PrintMembers()
        {
            sqlQuery = "select * from member where id not in('관리자');";
            SendQuery();

            print.PrintMembers(dataReader);
            CloseDB();
            menu.MemberManagementMenu();
        }
    }
}
