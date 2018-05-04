using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BookManagement
{
    /// <summary>
    /// 회원관리 기능을 담당하는 클래스
    /// 1. 회원 등록
    /// 2. 회원 정보 수정
    /// 3. 회원 삭제
    /// 4. 회원 일반검색
    /// 5. 회원 명단 출력
    /// </summary>
    class MemberManagement
    {
        Print print;
        ErrorCheck errorCheck;
        Menu menu;

        String databaseConnect;
        MySqlConnection connect;
        MySqlDataReader dataReader;
        MySqlCommand command;
        String sqlQuery;

        public MemberManagement(Menu menu)
        {
            print = Print.GetInstance();
            errorCheck = ErrorCheck.GetInstance();
            this.menu = menu;
        }

        //db연결 및 쿼리메시지 한번에 전송 메소드
        public void SendQuery()
        {
            databaseConnect = "Server=localhost;Database=bookmanage;Uid=study;Pwd=0000";
            connect = new MySqlConnection(databaseConnect);  // conncet MySQL
            connect.Open(); // open MySQL 
            command = new MySqlCommand(sqlQuery, connect);
            dataReader = command.ExecuteReader();
        }

        public void CloseDB()
        {
            dataReader.Close();
            connect.Close();
        }

        //회원등록
        public void RegisterMember()
        {
            MemberVO newMember;
            newMember = print.RegisterMember();

            sqlQuery = "select id from member;";
            SendQuery();
            
            //id중복체크
            while (dataReader.Read())
            {
                if (dataReader["id"].ToString().Equals(newMember.Id))
                {
                    CloseDB();
                    print.ErrorMsg("중복 아이디");
                    menu.MemberManagementMenu();
                    return;
                }
            }

            CloseDB();
            sqlQuery = "insert into member values('" + newMember.Id + "', '" + newMember.Password + "', '"
                + newMember.Name + "', '" + newMember.Gender + "', '" + newMember.PhoneNumber + "', '"
                + newMember.Email + "', '" + newMember.Address + "', '" + newMember.RentBook + "', '"
                + newMember.DueDate + "', '" + newMember.ExtensionCount + "');";

            SendQuery();
            dataReader.Read();
            if (errorCheck.IsValidChange(dataReader) == false) //등록 에러
            {
                CloseDB();
                print.ErrorMsg("회원 등록");
                menu.MemberManagementMenu();
                return;
            }

            CloseDB();
            print.CompleteMsg("회원 등록 완료");
            menu.MemberManagementMenu();
            return;
        }

        //회원정보 수정
        public void EditMember()
        {
            MemberVO foundMember = SearchMember("editSearch");

            foundMember = print.EditMember(foundMember);

            sqlQuery = "update member set phoneNumber ='" + foundMember.PhoneNumber + "', address ='" + foundMember.Address + "' where id='" + foundMember.Id + "';";
            SendQuery();
            dataReader.Read();

            if (errorCheck.IsValidChange(dataReader) == false) //편집 에러
            {
                CloseDB();
                print.ErrorMsg("회원 정보 수정");
                menu.MemberManagementMenu();
                return;
            }

            CloseDB();
            print.CompleteMsg("회원 정보 수정 완료");
            menu.MemberManagementMenu();
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
                menu.MemberManagementMenu();
                return;
            }

            sqlQuery = "delete from member where id='" + foundMember.Id + "';";
            SendQuery();
            dataReader.Read();

            if (errorCheck.IsValidChange(dataReader) == false) //편집 에러
            {
                CloseDB();
                print.ErrorMsg("회원 삭제");
                menu.MemberManagementMenu();
                return;
            }

            CloseDB();
            print.CompleteMsg("회원 삭제 완료");
            menu.MemberManagementMenu();
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

            sqlQuery = "select * from member where id='" + searchID + "';";
            SendQuery();
            dataReader.Read();

            if (errorCheck.IsValidMember(dataReader) == false) //검색 에러
            {
                CloseDB();
                print.ErrorMsg("존재하는 회원 찾기");
                if (searchType.Equals("justSearch")) menu.MemberManagementMenu();
                return null;
            }

            MemberVO foundMember = new MemberVO(dataReader["id"].ToString(), dataReader["password"].ToString(),
                    dataReader["name"].ToString(), dataReader["gender"].ToString(), dataReader["phoneNumber"].ToString(),
                    dataReader["email"].ToString(), dataReader["address"].ToString(), dataReader["rentbook"].ToString(), dataReader["duedate"].ToString(), 3);

            CloseDB();
            if (searchType.Equals("justSearch"))
            {
                print.MemberInfo(foundMember);
                menu.MemberManagementMenu();
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
