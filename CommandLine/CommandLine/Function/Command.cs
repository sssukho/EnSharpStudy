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
        public string currentPath;

        public Command()
        {
            this.print = new Print(this);
            this.errorCheck = new ErrorCheck();
            currentPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            print.InitialView();
            InputCommand(currentPath);
        }

        public void InputCommand(string inputPath)
        {
            while(true)
            {
                print.ShowCommandLine(inputPath);
                command = Console.ReadLine();
                if (command.ToUpper().Contains("CD"))
                {
                    Console.WriteLine();
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
                    Console.WriteLine();
                    ClearSystem();
                    return;
                }

                if(command.ToUpper().Contains("HELP"))
                {
                    Console.WriteLine();
                    Help();
                    return;
                }

                if(command.ToUpper().Contains("COPY"))
                {
                    Console.WriteLine();
                    Copy();
                    return;
                }

                if(command.ToUpper().Contains("MOVE"))
                {
                    Console.WriteLine();
                    Move();
                    return;
                }

                if (string.IsNullOrEmpty(command) || string.IsNullOrWhiteSpace(command)) { }

                if(command.ToUpper().Contains("EXIT"))
                {
                    Environment.Exit(0);
                }

                else
                {
                    print.InputError(command);
                }
            }
        }

        public void DirectoryList()
        {
            print.ShowDirectoryList(currentPath);
        }

        public void ChangeDirectory()
        {
            string tempPath;
            tempPath = command.Remove(0, 2);

            //cd하고 그냥 엔터
            if(string.IsNullOrEmpty(tempPath) || string.IsNullOrWhiteSpace(tempPath))
            {
                Console.Write(currentPath + "\n");
                InputCommand(currentPath);
            }

            //루트로
            if(tempPath.Equals("\\") ||  tempPath.Equals(" \\") || tempPath.Equals("/") || tempPath.Equals(" /")) 
            {
                currentPath = "C:'\'";
                currentPath = Path.GetPathRoot(currentPath); 
                InputCommand(currentPath);
                return;
            }

            //한단계 상위
            if(tempPath.Equals("..") || tempPath.Equals(" .."))
            {
                currentPath = Directory.GetParent(currentPath).FullName;
                InputCommand(currentPath);
                return;
            }

            if(tempPath.Equals("..\\..") || tempPath.Equals(" ..\\..")) //두단계 상위
            {
                currentPath = Directory.GetParent(Directory.GetParent(currentPath).FullName).FullName;
                InputCommand(currentPath);
                return;
            }

            //올바르지 않은 경로 예외처리 요망
            else
            {
                currentPath = currentPath + "\\" + command.Remove(0, 3);
                InputCommand(currentPath);
                return;
            } 
        }

        public void ClearSystem()
        {
            Console.Clear();
            InputCommand(currentPath);
        }

        public void Help()
        {
            print.ShowHelp();
            InputCommand(currentPath);
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
