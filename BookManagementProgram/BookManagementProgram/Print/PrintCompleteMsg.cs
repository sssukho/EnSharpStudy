using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BookManagementProgram
{
    /// <summary>
    /// 각 상황별 기능이 제대로 작동했을 시 나타나는 메시지
    /// </summary>
    class PrintCompleteMsg
    {
        public void RegisterCompleteMsg()
        {
            Console.WriteLine("\n\n\t등록이 완료 되었습니다.");
            Console.WriteLine("\t2초 후에 메뉴로 돌아갑니다...");
            Thread.Sleep(2000);
        }   

        public void EditCompleteMsg()
        {
            Console.WriteLine("\n\n\t수정이 완료 되었습니다.");
            Console.WriteLine("\t2초 후에 메뉴로 돌아갑니다...t");
            Thread.Sleep(2000);
        }

        public void DeleteCompleteMsg()
        {
            Console.WriteLine("\n\n\t삭제가 완료 되었습니다.");
            Console.WriteLine("\t2초 후에 메뉴로 돌아갑니다...t");
            Thread.Sleep(2000);
        }

        public void RentalCompleteMsg()
        {
            Console.WriteLine("\n\n\t대여 완료 되었습니다.");
            Console.WriteLine("\t2초 후에 메뉴로 돌아갑니다...t");
            Thread.Sleep(2000);
        }

        public void ReturnCompleteMsg()
        {
            Console.WriteLine("\n\n\t반납 완료 되었습니다.");
            Console.WriteLine("\t2초 후에 메뉴로 돌아갑니다...");
            Thread.Sleep(2000);
        }

        public void ExtensionCompleteMsg()
        {
            Console.WriteLine("\n\n\t1주일 뒤로 연장 되었습니다.");
            Console.WriteLine("\t2초 후에 메뉴로 돌아갑니다...t");
            Thread.Sleep(2000);
        }

        public void NotCompleteMsg()
        {
            Console.WriteLine("\t2초 후에 메뉴로 돌아갑니다...");
            Thread.Sleep(2000);
        }
    }
}
