using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLine
{
    class Print
    {
        private static Print print;

        public static Print GetInstance()
        {
            if (print == null)
                print = new Print();

            return print;
        }
    }
}
