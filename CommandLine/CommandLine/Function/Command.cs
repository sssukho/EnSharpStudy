using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CommandLine
{
    class Command
    {
        public CommandMenu commandMenu;
        public Print print;
        public ErrorCheck errorCheck;

        public Command() { }

        public Command(CommandMenu commandMenu)
        {
            this.commandMenu = commandMenu;
            this.print = Print.GetInstance();
            this.errorCheck = ErrorCheck.GetInstance();
        }

        public string[] DIR()
        {
            string[] directoryList;
            directoryList = Directory.GetDirectories(Directory.GetCurrentDirectory());
            return directoryList;
        }
    }
}
