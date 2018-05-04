using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{ //상속의 필요성
    class Program
    {
        /// <summary>
        ///  1. 사용자 아이디 : 122172  비번 : 6232
        ///  2. 가장 신경썼던 부분 : 코드 중복 최소화
        ///  3. 가장 힘들었던 부분 : 예외처리
        ///  4: 아쉬웠던 부분 : 로그아웃 기능, 관리자 모드와 일반사용자 모드 구현을 못한점
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            new Login().LoginToMenu();
        }
    }
}