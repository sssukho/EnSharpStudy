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
            while (true)
            {
                print.ShowCommandLine(inputPath);
                command = Console.ReadLine();
                if (command.ToUpper().Contains("CD"))
                {
                    Console.WriteLine();
                    ChangeDirectory();
                    return;
                }

                if (command.ToUpper().Contains("DIR"))
                {
                    DirectoryList();
                    return;
                }

                if (command.ToUpper().Contains("CLS"))
                {
                    Console.WriteLine();
                    ClearSystem();
                    return;
                }

                if (command.ToUpper().Contains("HELP"))
                {
                    Console.WriteLine();
                    Help();
                    return;
                }

                if (command.ToUpper().Contains("COPY"))
                {
                    Console.WriteLine();
                    Copy();
                    return;
                }

                if (command.ToUpper().Contains("MOVE"))
                {
                    Console.WriteLine();
                    Move();
                    return;
                }

                if (string.IsNullOrEmpty(command) || string.IsNullOrWhiteSpace(command))
                {
                    InputCommand(currentPath);
                    return;
                }

                if (command.ToUpper().Contains("EXIT"))
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
            if (string.IsNullOrEmpty(tempPath) || string.IsNullOrWhiteSpace(tempPath))
            {
                Console.Write(currentPath + "\n");
                InputCommand(currentPath);
            }

            //루트로
            if (tempPath.Equals("\\") || tempPath.Equals(" \\") || tempPath.Equals("/") || tempPath.Equals(" /"))
            {
                currentPath = "C:\\";
                currentPath = Path.GetPathRoot(currentPath);
                InputCommand(currentPath);
                return;
            }

            //한단계 상위
            if (tempPath.Equals("..") || tempPath.Equals(" .."))
            {
                currentPath = Directory.GetParent(currentPath).FullName;
                InputCommand(currentPath);
                return;
            }

            //두단계 상위
            if (tempPath.Equals("..\\..") || tempPath.Equals(" ..\\.."))
            {
                currentPath = Directory.GetParent(Directory.GetParent(currentPath).FullName).FullName;
                InputCommand(currentPath);
                return;
            }

            //올바르지 않은 경로 예외처리 요망

            //실제 경로로
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

        public void Copy()
        {
            command = command.Remove(0, 5);
            string[] copyCommandObject = command.Split(' ');

            int copyCount = 0;

            //sourceFile이 경로가 있는경우
            if (copyCommandObject[0].Contains("\\"))
            {
                //찾는 파일 없음
                if(!File.Exists(copyCommandObject[0]))
                {
                    print.FindingFileError();
                    InputCommand(currentPath);
                    return;
                }

                //경로가 하나만 있는 경우(copy c:\users\sb\desktop\sb\aoa.txt) 바탕화면 폴더의 aoa텍스트를 현재 경로에 복사
                if (copyCommandObject.Length == 1)
                {
                    //dest에 같은 파일명이 있으면
                    if (File.Exists(currentPath + "\\" + Path.GetFileName(copyCommandObject[0])))
                    {
                        DuplicatedFileCopyHandler(copyCommandObject);
                        return;
                    }

                    //dest에 같은 파일명 없음
                    else
                    {
                        copyCount = 1;
                        File.Copy(copyCommandObject[0], currentPath + "\\" + Path.GetFileName(copyCommandObject[0]));
                        print.CopyCompleted(copyCount);
                        InputCommand(currentPath);
                        return;
                    }
                }

                //copy c:\users\sb\desktop\a.txt c:\users\sb\desktop\sb\aoa.txt 
                if (copyCommandObject.Length == 2)
                {
                    if(copyCommandObject[1].Contains("\\"))
                    {
                        //dest에 같은 파일명 있음
                        if(File.Exists(copyCommandObject[1]))
                        {
                            DuplicatedFileCopyHandler(copyCommandObject);
                            return;
                        }

                        //dest에 같은 파일명 없음
                        else
                        {
                            copyCount = 1;
                            File.Copy(copyCommandObject[0], copyCommandObject[1]);
                            print.CopyCompleted(copyCount);
                            InputCommand(currentPath);
                            return;
                        }
                    }

                    //copy c:\users\sb\desktop\a.txt c.txt
                    else
                    {
                        if(File.Exists(currentPath + "\\" + copyCommandObject[1]))
                        {
                            DuplicatedFileCopyHandler(copyCommandObject);
                            return;
                        }

                        else
                        {
                            copyCount = 1;
                            File.Copy(copyCommandObject[0], currentPath + "\\" + copyCommandObject[1]);
                            print.CopyCompleted(copyCount);
                            InputCommand(currentPath);
                            return;
                        }
                    }
                }
            }

            else
            {
                if(!File.Exists(currentPath + "\\" + copyCommandObject[0]))
                {
                    print.FindingFileError();
                    InputCommand(currentPath);
                    return;
                }
                //copy a.txt c:\users\sb\desktop\sb\aoa.txt
                if(copyCommandObject[1].Contains("\\"))
                {
                    if (File.Exists(copyCommandObject[1]))
                    {
                        DuplicatedFileCopyHandler(copyCommandObject);
                        return;
                    }

                    else
                    {
                        copyCount = 1;
                        File.Copy(currentPath + "\\" + copyCommandObject[0], copyCommandObject[1]);
                        print.CopyCompleted(copyCount);
                        InputCommand(currentPath);
                        return;
                    }
                }

                //copy a.txt b.txt
                else
                {
                    if (File.Exists(currentPath + "\\" + copyCommandObject[1]))
                    {
                        DuplicatedFileCopyHandler(copyCommandObject);
                        return;
                    }

                    else
                    {
                        copyCount = 1;
                        File.Copy(currentPath + "\\" + copyCommandObject[0], currentPath + "\\" + copyCommandObject[1]);
                        print.CopyCompleted(copyCount);
                        InputCommand(currentPath);
                        return;
                    }
                }
            }
        }

        public void DuplicatedFileCopyHandler(string[] copyCommandObject)
        {
            string confirm;
            int copyCount = 0;

            if(copyCommandObject.Length == 1)
            {
                print.ConfirmOverwrite(Path.GetFileName(copyCommandObject[0]));
            }

            if(copyCommandObject.Length == 2)
            {
                if (copyCommandObject[1].Contains("\\"))
                    print.ConfirmOverwrite(Path.GetFileName(copyCommandObject[1]));
                else
                    print.ConfirmOverwrite(copyCommandObject[1]);
            }

            confirm = Console.ReadLine().ToUpper();

            if (confirm.Contains("YES") && confirm.Contains("ALL") && confirm.Contains("NO"))
            {
                //더 앞쪽에 나오는 확인문구로 명령어 실행(yes나 all이 나오는경우)
                if (confirm.IndexOf("YES") < confirm.IndexOf("NO") || confirm.IndexOf("ALL") < confirm.IndexOf("NO"))
                {
                    if(copyCommandObject.Length == 1)
                        File.Copy(currentPath, copyCommandObject[0], true);
                        
                    if(copyCommandObject.Length == 2)
                    {
                        if(copyCommandObject[0].Contains("\\") && copyCommandObject[1].Contains("\\"))
                            File.Copy(copyCommandObject[0], copyCommandObject[1], true);     

                        else if(copyCommandObject[0].Contains("\\") && !copyCommandObject[1].Contains("\\"))
                            File.Copy(copyCommandObject[0], currentPath + "\\" + copyCommandObject[1], true);
                            
                        else if(!copyCommandObject[0].Contains("\\") && copyCommandObject[1].Contains("\\"))
                            File.Copy(currentPath + "\\" + copyCommandObject[0], copyCommandObject[1], true);
                            
                        else if(!copyCommandObject[0].Contains("\\") && !copyCommandObject[1].Contains("\\"))
                            File.Copy(currentPath + "\\" + copyCommandObject[0], currentPath + "\\" + copyCommandObject[1], true);
                    }
                    copyCount = 1;
                }

                //더 앞쪽에 NO가 나오는 경우
                else
                {
                    copyCount = 0;
                }
                print.CopyCompleted(copyCount);
                InputCommand(currentPath);
            }

            //Yes나 All문구만 있는 경우
            else if (confirm.Contains("YES") || confirm.Contains("ALL"))
            {
                if (copyCommandObject.Length == 1)
                    File.Copy(currentPath, copyCommandObject[0], true);

                if (copyCommandObject.Length == 2)
                {
                    if (copyCommandObject[0].Contains("\\") && copyCommandObject[1].Contains("\\"))
                        File.Copy(copyCommandObject[0], copyCommandObject[1], true);

                    else if (copyCommandObject[0].Contains("\\") && !copyCommandObject[1].Contains("\\"))
                        File.Copy(copyCommandObject[0], currentPath + "\\" + copyCommandObject[1], true);

                    else if (!copyCommandObject[0].Contains("\\") && copyCommandObject[1].Contains("\\"))
                        File.Copy(currentPath + "\\" + copyCommandObject[0], copyCommandObject[1], true);

                    else if (!copyCommandObject[0].Contains("\\") && !copyCommandObject[1].Contains("\\"))
                        File.Copy(currentPath + "\\" + copyCommandObject[0], currentPath + "\\" + copyCommandObject[1], true);
                }
                copyCount = 1;
                print.CopyCompleted(copyCount);
                InputCommand(currentPath);
            }

            //No문구만 있는 경우
            else if (confirm.Contains("NO"))
            {
                copyCount = 0;
                print.CopyCompleted(copyCount);
                InputCommand(currentPath);
            }

            //아무런 글자를 입력했을 때 카피 명령 실행
            else
            {
                if (copyCommandObject.Length == 1)
                    File.Copy(currentPath, copyCommandObject[0], true);

                if (copyCommandObject.Length == 2)
                {
                    if (copyCommandObject[0].Contains("\\") && copyCommandObject[1].Contains("\\"))
                        File.Copy(copyCommandObject[0], copyCommandObject[1], true);

                    else if (copyCommandObject[0].Contains("\\") && !copyCommandObject[1].Contains("\\"))
                        File.Copy(copyCommandObject[0], currentPath + "\\" + copyCommandObject[1], true);

                    else if (!copyCommandObject[0].Contains("\\") && copyCommandObject[1].Contains("\\"))
                        File.Copy(currentPath + "\\" + copyCommandObject[0], copyCommandObject[1], true);

                    else if (!copyCommandObject[0].Contains("\\") && !copyCommandObject[1].Contains("\\"))
                        File.Copy(currentPath + "\\" + copyCommandObject[0], currentPath + "\\" + copyCommandObject[1], true);
                }
                copyCount = 1;
                print.CopyCompleted(copyCount);
                InputCommand(currentPath);
            }
        }
      

        public void Move()
        {
            command = command.Remove(0, 5);
            string[] moveCommandObject = command.Split(' ');

            int moveCount = 0;

            //sourceFile이 경로가 있는경우
            if (moveCommandObject[0].Contains("\\"))
            {
                //찾는 파일 없음
                if (!File.Exists(moveCommandObject[0]))
                {
                    print.FindingFileError();
                    InputCommand(currentPath);
                    return;
                }

                //경로가 하나만 있는 경우(copy c:\users\sb\desktop\sb\aoa.txt) 바탕화면 폴더의 aoa텍스트를 현재 경로에 복사
                if (moveCommandObject.Length == 1)
                {
                    //dest에 같은 파일명이 있으면
                    if (File.Exists(currentPath + "\\" + Path.GetFileName(moveCommandObject[0])))
                    {
                        DuplicatedFileMoveHandler(moveCommandObject);
                        return;
                    }

                    //dest에 같은 파일명 없음
                    else
                    {
                        moveCount = 1;
                        File.Move(moveCommandObject[0], currentPath + "\\" + Path.GetFileName(moveCommandObject[0]));
                        print.MoveCompleted(moveCount);
                        InputCommand(currentPath);
                        return;
                    }
                }

                //copy c:\users\sb\desktop\a.txt c:\users\sb\desktop\sb\aoa.txt 
                if (moveCommandObject.Length == 2)
                {
                    if (moveCommandObject[1].Contains("\\"))
                    {
                        //dest에 같은 파일명 있음
                        if (File.Exists(moveCommandObject[1]))
                        {
                            DuplicatedFileMoveHandler(moveCommandObject);
                            return;
                        }

                        //dest에 같은 파일명 없음
                        else
                        {
                            moveCount = 1;
                            File.Move(moveCommandObject[0], moveCommandObject[1]);
                            print.MoveCompleted(moveCount);
                            InputCommand(currentPath);
                            return;
                        }
                    }

                    //copy c:\users\sb\desktop\a.txt c.txt
                    else
                    {
                        if (File.Exists(currentPath + "\\" + moveCommandObject[1]))
                        {
                            DuplicatedFileMoveHandler(moveCommandObject);
                            return;
                        }

                        else
                        {
                            moveCount = 1;
                            File.Move(moveCommandObject[0], currentPath + "\\" + moveCommandObject[1]);
                            print.MoveCompleted(moveCount);
                            InputCommand(currentPath);
                            return;
                        }
                    }
                }
            }

            else
            {
                if (!File.Exists(currentPath + "\\" + moveCommandObject[0]))
                {
                    print.FindingFileError();
                    InputCommand(currentPath);
                    return;
                }
                //copy a.txt c:\users\sb\desktop\sb\aoa.txt
                if (moveCommandObject[1].Contains("\\"))
                {
                    if (File.Exists(moveCommandObject[1]))
                    {
                        DuplicatedFileMoveHandler(moveCommandObject);
                        return;
                    }

                    else
                    {
                        moveCount = 1;
                        File.Move(currentPath + "\\" + moveCommandObject[0], moveCommandObject[1]);
                        print.MoveCompleted(moveCount);
                        InputCommand(currentPath);
                        return;
                    }
                }

                //copy a.txt b.txt
                else
                {
                    if (File.Exists(currentPath + "\\" + moveCommandObject[1]))
                    {
                        DuplicatedFileMoveHandler(moveCommandObject);
                        return;
                    }

                    else
                    {
                        moveCount = 1;
                        File.Move(currentPath + "\\" + moveCommandObject[0], currentPath + "\\" + moveCommandObject[1]);
                        print.MoveCompleted(moveCount);
                        InputCommand(currentPath);
                        return;
                    }
                }
            }
        }

        public void DuplicatedFileMoveHandler(string[] moveCommandObject)
        {
            string confirm;
            int moveCount = 0;

            if (moveCommandObject.Length == 1)
            {
                print.ConfirmOverwrite(Path.GetFileName(moveCommandObject[0]));
            }

            if (moveCommandObject.Length == 2)
            {
                if (moveCommandObject[1].Contains("\\"))
                    print.ConfirmOverwrite(Path.GetFileName(moveCommandObject[1]));
                else
                    print.ConfirmOverwrite(moveCommandObject[1]);
            }

            confirm = Console.ReadLine().ToUpper();

            if (confirm.Contains("YES") && confirm.Contains("ALL") && confirm.Contains("NO"))
            {
                //더 앞쪽에 나오는 확인문구로 명령어 실행(yes나 all이 나오는경우)
                if (confirm.IndexOf("YES") < confirm.IndexOf("NO") || confirm.IndexOf("ALL") < confirm.IndexOf("NO"))
                {
                    if (moveCommandObject.Length == 1)
                    {
                        File.Delete(moveCommandObject[0]);
                        File.Move(currentPath, moveCommandObject[0]);
                    }   

                    if (moveCommandObject.Length == 2)
                    {
                        if (moveCommandObject[0].Contains("\\") && moveCommandObject[1].Contains("\\"))
                        {
                            File.Delete(moveCommandObject[1]);
                            File.Move(moveCommandObject[0], moveCommandObject[1]);
                        }
                            
                        else if (moveCommandObject[0].Contains("\\") && !moveCommandObject[1].Contains("\\"))
                        {
                            File.Delete(currentPath + "\\" + moveCommandObject[1]);
                            File.Move(moveCommandObject[0], currentPath + "\\" + moveCommandObject[1]);
                        }
                            
                        else if (!moveCommandObject[0].Contains("\\") && moveCommandObject[1].Contains("\\"))
                        {
                            File.Delete(moveCommandObject[1]);
                            File.Move(currentPath + "\\" + moveCommandObject[0], moveCommandObject[1]);
                        }

                        else if (!moveCommandObject[0].Contains("\\") && !moveCommandObject[1].Contains("\\"))
                        {
                            File.Delete(currentPath + "\\" + moveCommandObject[1]);
                            File.Move(currentPath + "\\" + moveCommandObject[0], currentPath + "\\" + moveCommandObject[1]);
                        }
                           
                    }
                    moveCount = 1;
                }

                //더 앞쪽에 NO가 나오는 경우
                else
                {
                    moveCount = 0;
                }
                print.MoveCompleted(moveCount);
                InputCommand(currentPath);
            }

            //Yes나 All문구만 있는 경우
            else if (confirm.Contains("YES") || confirm.Contains("ALL"))
            {
                if (moveCommandObject.Length == 1)
                {
                    File.Delete(moveCommandObject[0]);
                    File.Move(currentPath, moveCommandObject[0]);
                }
                    
                if (moveCommandObject.Length == 2)
                {
                    if (moveCommandObject[0].Contains("\\") && moveCommandObject[1].Contains("\\"))
                    {
                        File.Delete(moveCommandObject[1]);
                        File.Move(moveCommandObject[0], moveCommandObject[1]);
                    }

                    else if (moveCommandObject[0].Contains("\\") && !moveCommandObject[1].Contains("\\"))
                    {
                        File.Delete(moveCommandObject[1]);
                        File.Move(moveCommandObject[0], currentPath + "\\" + moveCommandObject[1]);
                    }   

                    else if (!moveCommandObject[0].Contains("\\") && moveCommandObject[1].Contains("\\"))
                    {
                        File.Delete(moveCommandObject[1]);
                        File.Move(currentPath + "\\" + moveCommandObject[0], moveCommandObject[1]);
                    }

                    else if (!moveCommandObject[0].Contains("\\") && !moveCommandObject[1].Contains("\\"))
                    {
                        File.Delete(currentPath + "\\" + moveCommandObject[1]);
                        File.Move(currentPath + "\\" + moveCommandObject[0], currentPath + "\\" + moveCommandObject[1]);
                    }       
                }
                moveCount = 1;
                print.MoveCompleted(moveCount);
                InputCommand(currentPath);
            }

            //No문구만 있는 경우
            else if (confirm.Contains("NO"))
            {
                moveCount = 0;
                print.MoveCompleted(moveCount);
                InputCommand(currentPath);
            }

            //아무런 글자를 입력했을 때 카피 명령 실행
            else
            {
                if (moveCommandObject.Length == 1)
                {
                    File.Delete(moveCommandObject[0]);
                    File.Move(currentPath, moveCommandObject[0]);
                }
                    
                if (moveCommandObject.Length == 2)
                {
                    if (moveCommandObject[0].Contains("\\") && moveCommandObject[1].Contains("\\"))
                    {
                        File.Delete(moveCommandObject[1]);
                        File.Move(moveCommandObject[0], moveCommandObject[1]);
                    }

                    else if (moveCommandObject[0].Contains("\\") && !moveCommandObject[1].Contains("\\"))
                    {
                        File.Delete(moveCommandObject[1]);
                        File.Move(moveCommandObject[0], currentPath + "\\" + moveCommandObject[1]);
                    }
                        
                    else if (!moveCommandObject[0].Contains("\\") && moveCommandObject[1].Contains("\\"))
                    {
                        File.Delete(moveCommandObject[1]);
                        File.Move(currentPath + "\\" + moveCommandObject[0], moveCommandObject[1]);
                    }

                    else if (!moveCommandObject[0].Contains("\\") && !moveCommandObject[1].Contains("\\"))
                    {
                        File.Delete(moveCommandObject[1]);
                        File.Move(currentPath + "\\" + moveCommandObject[0], currentPath + "\\" + moveCommandObject[1]);
                    }
                }
                moveCount = 1;
                print.MoveCompleted(moveCount);
                InputCommand(currentPath);
            }
        }
    }
}