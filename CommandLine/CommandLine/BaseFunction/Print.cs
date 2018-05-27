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
        Command command;
        public Print(Command command)
        {
            this.command = command;
        }

        public void ShowCommandLine(string inputPath)
        {
            Console.Write(inputPath + ">");
        }

        public void InitialView()
        {
            Console.SetWindowSize(120, 30);
            Console.WriteLine("Microsoft Windows [Version 10.0.16299.125]");
            Console.WriteLine("(c) 2017 Microsoft Corporation. All rights reserved.\n");
        }

        public void InputError(string inputCommand)
        {
            Console.WriteLine("'{0}'은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는", inputCommand);
            Console.WriteLine("배치 파일이 아닙니다.\n");
        }

        public void ShowDirectoryList(string inputPath)
        {
            if(Directory.Exists(inputPath))
            {
                string result;
                DirectoryInfo directoryInfo = new DirectoryInfo(inputPath);

                Console.WriteLine(" 드라이브의 불륨에는 이름이 없습니다.");
                Console.WriteLine(" 불륨 일련 번호: 0A91-13CA\n");
                Console.WriteLine(" {0} 디렉터리\n", inputPath);

                foreach(var item in directoryInfo.GetDirectories())
                {
                    if (FileAttributes.Directory == item.Attributes)
                        result = string.Format("{0, -23} {1, -10} {2,-25}", item.CreationTime.ToString().Remove(20), "<DIR>", item.Name);

                    else
                    {
                        FileInfo file = new FileInfo(item.Name);
                        result = string.Format("{0, -28} {1, -5} {2, -25}", item.CreationTime.ToString(), file.Length, item.FullName);
                    }
                        
                       // result = item.CreationTime.ToString().Remove(20) + "       " + item.FullName;

                    Console.WriteLine(result);
                }
                command.InputCommand();
            }
        }
    }
}
