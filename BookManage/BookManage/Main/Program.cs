using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <프로그램흐름>
///  1. 메인 시작 (프로그램 시작) -> 메뉴클래스로 이동
///  2. 메뉴 클래스에서 필요한 객체들 생성 후 각각 클래스로 넘김
///  3. MemberManagement 클래스: 회원 관리 기능들을 하는 클래스
///  4. BookManagement 클래스: 도서 관리 기능들을 하는 클래스
///  5. BookRent 클래스: 회원들에게 도서 대여, 반납, 반납연장 등의 기능을 하는 클래스 
///  6. ErrorCheck: 각각의 입력에서 에러여부를 bool 값으로 리턴해주는 클래스
///  7. Print: 콘솔창 입출력을 담당하는 클래스

namespace BookManage
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.ViewMenu();
        }
    }
}
