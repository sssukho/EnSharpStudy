using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    /******************관리자모드 기능*********************/
    //DB에 도서 등록(직접 입력)
    //DB에 있는 도서 정보 수정
    //DB에 있는 도서 정보 삭제
    //DB에 있는 도서 일반 검색
    //DB에 있는 도서 명단 출력
    //네이버 API 사용한 검색
    //네이버 API 사용한 검색을 통한 도서 등록
    //회원 등록
    //회원 수정
    //회원 삭제
    //회원 검색
    //회원 명단 출력
    //로그 초기화
    //로그 내용 확인
    //로그 내용 txt파일로 저장
    //로그 txt 파일 삭제

    /******************유저모드 기능*********************/
    //도서 대여 연장
    //도서 검색
    //도서 명단 출력

        /// <summary>
        /// mysql 접속 계정 및 비밀번호 내용 -> DAO Initialize 메소드
        /// 유저모드 아이디/비번 : 122172 / 6232
        /// 관리자모드 아이디/비번 : 관리자 / 관리자
        /// </summary>
        /// 
    class Program
    {
        static void Main(string[] args)
        {
            new Login();
        }
    }
}
