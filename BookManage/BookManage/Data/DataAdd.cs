using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManage.Data
{
    class DataAdd
    {
        public DataAdd(List<Member> memberList, List<Book> bookList)
        {
            memberList.Add(new Member("임석호", "122172", "남자", "010-6253-6320", "sssukho@gmail.com", "서울시 강동구 명일동", "웹프로그래밍", "2018-04-20"));
            memberList.Add(new Member("박영호", "122111", "여자", "010-1234-5678", "parkyounghov@gmail.com", "경기도 부천시 원미구", "", ""));
            memberList.Add(new Member("박지호", "141111111", "남자", "010-9876-5432", "jihopark@gmail.com", "경기도 용인시 성북동", "", ""));
            bookList.Add(new Book("일반물리학및실험1", "땅콩", "김용덕", "8,000원", 3));
            bookList.Add(new Book("오픈소스SW개론", "피넛", "안용학", "7,000원", 2));
            bookList.Add(new Book("C#프로그래밍", "불닭", "조상욱", "9,000원", 1));
            bookList.Add(new Book("소프트웨어특강", "세종대", "데미켓", "6,500원", 1));
            bookList.Add(new Book("웹프로그래밍", "사이버대", "김태균", "3,400원", 2));
        }
    }
}
