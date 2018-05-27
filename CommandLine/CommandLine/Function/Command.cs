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
        public Print print;
        public ErrorCheck errorCheck;
        public string command;
        public string path;

        public Command()
        {
            this.print = new Print(this);
            this.errorCheck = new ErrorCheck();
            path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            print.InitialView();
            InputCommand();
        }

        public void InputCommand()
        {
            while(true)
            {
                print.ShowCommandLine(path);
                command = Console.ReadLine();
                if (command.ToUpper().Contains("CD"))
                {
                    ChangeDirectory();
                    return;
                }

                if(command.ToUpper().Contains("DIR"))
                {
                    DirectoryList();
                    return;
                }

                if(command.ToUpper().Contains("CLS"))
                {
                    ClearSystem();
                    return;
                }

                if(command.ToUpper().Contains("HELP"))
                {
                    Help();
                    return;
                }

                if(command.ToUpper().Contains("COPY"))
                {
                    Copy();
                    return;
                }

                if(command.ToUpper().Contains("MOVE"))
                {
                    Move();
                    return;
                }
                print.InputError(command);
            }
        }

        public void DirectoryList()
        {
            print.ShowDirectoryList(path);
        }

        public void ChangeDirectory()
        {

            
        }

        public void ClearSystem()
        {
            Console.Clear();
            InputCommand();
        }

        public void Help()
        {

        }

        public DirectoryVO Copy()
        {

            return null;
        }

        public DirectoryVO Move()
        {

            return null;
        }
    }
}
