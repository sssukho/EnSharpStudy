using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CommandLine
{
    class Print
    {
        private static Print print;
        string currentPath;

        public static Print GetInstance()
        {
            if (print == null)
                print = new Print();

            return print;
        }

        public void InitialView()
        {
            Console.SetWindowSize(120, 30);
            Console.WriteLine("Microsoft Windows [Version 10.0.16299.125]");
            Console.WriteLine("(c) 2017 Microsoft Corporation. All rights reserved.\n");
        }

        public void CurrentPath()
        {
            currentPath = Directory.GetCurrentDirectory();
            Console.WriteLine(currentPath + ">");
        }
    }
}
