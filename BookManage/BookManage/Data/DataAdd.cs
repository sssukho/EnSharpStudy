using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManage
{
    /// <DataAdd클래스>
    /// 기본 데이터 추가하는 클래스
    /// 프로그램이 시작하면서 메뉴 클래스를 호출하는데 이 때 생성자를 통해 본 클래스를
    /// 생성하여 데이터를 추가시켜준다.
    class DataAdd
    {
        public DataAdd(List<Member> memberList, List<Book> bookList)
        {
            memberList.Add(new Member("임석호", "122172", "남", "010-6253-6320", "sssukho@gmail.com", "서울시 강동구 명일동", "웹프로그래밍", "2018-04-23"));
            memberList.Add(new Member("박영호", "122111", "여", "010-1234-5678", "parkyounghov@gmail.com", "경기도 부천시 원미구", "", ""));
            memberList.Add(new Member("박지호", "14123456", "남", "010-9876-5432", "jihopark@gmail.com", "경기도 용인시 성북동", "", ""));
            memberList.Add(new Member("윤효진", "13131313", "여", "010-6821-4789", "hyojin@naver.com", "경기도 하남시 덕풍동", "소프트웨어특강", "2018-04-23"));
            memberList.Add(new Member("월세영", "15123456", "남", "010-9993-2389", "seyoung@daum.net", "경기도 남양주시 와부읍 덕소리", "", ""));

            bookList.Add(new Book("일반물리학및실험1", "땅콩", "김용덕", "8,000원", 1));
            bookList.Add(new Book("오픈소스SW개론", "피넛", "안용학", "7,000원", 1));
            bookList.Add(new Book("C#프로그래밍", "불닭", "조상욱", "9,000원", 1));
            bookList.Add(new Book("소프트웨어특강", "세종대", "데미켓", "6,500원", 1));
            bookList.Add(new Book("웹프로그래밍", "사이버대", "김태균", "3,400원", 1));
            bookList.Add(new Book("자바", "공화춘", "맥북", "24,000원", 1));
        }
    }
}
