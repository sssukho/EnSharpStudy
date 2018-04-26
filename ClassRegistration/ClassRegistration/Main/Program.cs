using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRegistration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Print print = new Print();
            print.Menu("수강신청 강의검색");
        }
    }
}
