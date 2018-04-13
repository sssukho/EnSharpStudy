using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    /// <summary>
    /// 프로그램 빌드한뒤 가장 상위에 있는 메인 메뉴를 호출할 때 데이터 추가함
    /// </summary>
    class MemberDataAdd
    {
        public MemberDataAdd(List<Member> inputMemberList)
        {
            inputMemberList.Add(new Member("임석호", "122172", "남자", "010-6253-6320", "sssukho@gmail.com", "서울시 강동구 명일동", "웹프로그래밍", "2018-04-20"));
            inputMemberList.Add(new Member("박영호", "122111", "여자", "010-1234-5678", "parkyounghov@gmail.com", "경기도 부천시 원미구", "", ""));
            inputMemberList.Add(new Member("박지호", "141111111", "남자", "010-9876-5432", "jihopark@gmail.com", "경기도 용인시 성북동", "", ""));
        }
    }
}
