using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManage
{
    /// <CancelKey클래스>
    /// 입력도중 ESC 특수키로 이전 단계로 돌아가는 기능을 수행하는 클래스
    /// ReadLineWithCancel 메소드가 다른 클래스 내에서 받은 입력값을
    /// null로 리턴하면 ESC 키가 입력이 되었음을 의미하여 다른 클래스 내에서
    /// 이전 단계로 돌아가는 기능을 수행하게 된다.

    class CancelKey
    {
        public CancelKey() { }
        public static string ReadLineWithCancel()
        {
            string inputString = null;
            StringBuilder buffer = new StringBuilder();
            ConsoleKeyInfo key = Console.ReadKey(true);
          
            while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape)
            {
                Console.Write(key.KeyChar);
                buffer.Append(key.KeyChar);
                key = Console.ReadKey(true);
            }

            if (key.Key == ConsoleKey.Enter)
            {
                inputString = buffer.ToString();
            }
            return inputString;
        }
    }
}
