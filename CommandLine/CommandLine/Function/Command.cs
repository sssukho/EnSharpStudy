using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLine
{
    class Command
    {
        public CommandMenu commandMenu;
        public Print print;
        public ErrorCheck errorCheck;

        public Command(CommandMenu commandMenu)
        {
            this.commandMenu = commandMenu;
            this.print = Print.GetInstance();
            this.errorCheck = ErrorCheck.GetInstance();
        }
    }
}
