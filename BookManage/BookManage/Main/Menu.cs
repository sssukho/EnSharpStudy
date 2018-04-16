using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <Menu클래스>
///  회원 정보와 도서 정보를 담고 있는 리스트와 이 데이터를 다루는 기능을 하는 클래스들의  객체 생성
///  Print 와 ErrorCheck 클래스는 모든 클래스에서 사용하므로 싱글톤 구조로 객체 생성함
///  회원관리 클래스에는 회원리스트만 넘겨주고 도서관리 클래스에는 도서리스트만 넘겨준다.
///  도서 대여 및 반납 기능을 하는 클래스인 BookRent는 회원과 도서 정보를 모두 다루어야 하므로
///  생성된 두 리스트 객체를 같이 넘겨준다.
///  This로 한번 생성된 메뉴 클래스를 다른 클래스의 생성자를 통해 객체를 이동시켜주는 구조.

namespace BookManage
{
    class Menu
    {
        private const int MemberManagementMenu = 1;
        private const int BookManagementMenu = 2;
        private const int BookRentMenu = 3;
        private const int EXIT = 4;

        MemberManagement memberManagement;
        BookManagement bookManagement;
        BookRent bookRent;
        List<Book> bookList;
        List<Member> memberList;
        Print print;
        ErrorCheck errorCheck;

        string menuSelect;
        bool error;

        public Menu()
        {
            this.memberList = new List<Member>();
            this.bookList = new List<Book>();
            this.memberManagement = new MemberManagement(this, memberList);
            this.bookManagement = new BookManagement(this, bookList);
            this.bookRent = new BookRent(this, memberList, bookList);
            this.print = Print.GetInstance(); //Print객체가 있으면 생성하지 않고 없으면 생성하는 메소드
            this.errorCheck = ErrorCheck.GetInstance();
            new DataAdd(this.memberList, this.bookList); //최초 데이터 추가
        }

        public void ViewMenu()
        {
            print.Menu("메인"); //메인 메뉴 UI
            menuSelect = Console.ReadLine();
            error = errorCheck.Number(menuSelect, "4지선다");
            if (error == true)
            {
                print.MenuErrorMsg("4지선다오류"); //오류 메시지
                ViewMenu();
            } 
            else
            {
                switch (int.Parse(menuSelect))
                {
                    case MemberManagementMenu:
                        memberManagement.ViewMenu();
                        break;

                    case BookManagementMenu:
                        bookManagement.ViewMenu();
                        break;

                    case BookRentMenu:
                        bookRent.ViewMenu();
                        break;

                    case EXIT:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}