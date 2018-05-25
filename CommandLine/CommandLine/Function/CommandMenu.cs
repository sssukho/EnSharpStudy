using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLine
{
    class CommandMenu
    {
        ErrorCheck errorCheck;
        Print print;

        public CommandMenu()
        {                
            errorCheck = ErrorCheck.GetInstance();
            print = Print.GetInstance();
            InitialView();
        }

        public void InitialView()
        {
            print.InitialView();
            print.CurrentPath();
        }

    }
}
