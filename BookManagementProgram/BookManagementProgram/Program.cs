using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class Program
    {
        /// <summary>
        /// 프로그램 흐름 : 회원 데이터를 담고 있는 List와 도서 정보를 담고 있는 List 객체가
        /// MemberManage 패키지내에 있는 클래스들과 BookManage 패키지 내에 있는
        /// 클래스들로 객체가 이동하는 구조.
        /// 중간중간 Error 패키지 내에 있는 클래스들을 통하여 에러 검사.
        /// 모든 클래스 객체를 하나만 생성하여 계속해서 생성자를 통하여 넘겨주면서
        /// 객체를 생성하는데 소비되는 메모리를 최소화 하려 했으나 구조가 꼬여 메뉴
        /// 이동하는데 NULL 값이 할당되어 프로그램이 중지됨.
        /// </summary>
        static void Main(string[] args)
        {
            new Menu(new Menu(), new List<Member>(), new List<Book>());
        }
    }
}
