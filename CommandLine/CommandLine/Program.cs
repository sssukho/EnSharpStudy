using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLine
{
    class Program
    {
        /****************클래스 역할***********************
         * ErrorCheck : 유효 파일 및 유효 경로인지 확인
         * Print : 각종 출력문 출력
         * Command : 명령어 입력 및 세부 기능들
         * **************************************************/
        static void Main(string[] args)
        {
            Console.Clear();
            new Command();
        }
    }
}
