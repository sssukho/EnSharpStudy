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

        /// <summary>
        /// 명령어 입력 무한 루프
        /// </summary>
        /// <param name="inputPath">입력 받기 이전 줄에 출력하기 위한 경로</param>
        public void InputCommand(string inputPath)
        {
            while (true)
            {
                print.ShowCommandLine(inputPath);
                command = Console.ReadLine();

                //CD명령어
                if (command.ToUpper().Contains("CD"))
                {
                    Console.WriteLine();
                    ChangeDirectory();
                    return;
                }

                //dir 명령어
                if (command.ToUpper().Contains("DIR"))
                {
                    ShowDirectoryList();
                    return;
                }

                //cls 명령어
                if (command.ToUpper().Contains("CLS"))
                {
                    Console.WriteLine();
                    ClearSystem();
                    return;
                }

                //Help 명령어
                if (command.ToUpper().Contains("HELP"))
                {
                    Console.WriteLine();
                    Help();
                    return;
                }

                //copy 명령어
                if (command.ToUpper().Contains("COPY"))
                {
                    Console.WriteLine();
                    Copy();
                    return;
                }

                //move 명령어
                if (command.ToUpper().Contains("MOVE"))
                {
                    Console.WriteLine();
                    Move();
                    return;
                }

                //아무것도 안쓰고 엔터 칠때 오류
                if (string.IsNullOrEmpty(command) || string.IsNullOrWhiteSpace(command))
                {
                    InputCommand(currentPath);
                    return;
                }

                if (command.ToUpper().Contains("EXIT"))
                {
                    Environment.Exit(0);
                }

                //이외에는 에러처리
                else
                {
                    print.InputError(command);
                }
            }
        }

        //dir 명령어 수행
        public void ShowDirectoryList()
        {
            command = command.Trim();
            if(command.Length > 3)
            {
                string destinationPath;
                destinationPath = command.Remove(0, 4);

                if (errorCheck.IsValidPath(destinationPath))
                    print.ShowDirectoryList(destinationPath);

                print.FindingPathError("경로를");
                InputCommand(currentPath);
                return;
            }
            print.ShowDirectoryList(currentPath);
        }

        //CD 명령어 수행
        public void ChangeDirectory()
        {
            string destinationPath;
            destinationPath = command.Trim().Remove(0, 2).Trim();
            
            //cd하고 그냥 엔터
            if (string.IsNullOrEmpty(destinationPath) || string.IsNullOrWhiteSpace(destinationPath))
            {
                Console.Write(currentPath + "\n\n");
                InputCommand(currentPath);
            }
            
            //루트로
            if (destinationPath.Equals("\\") || destinationPath.Equals(" \\") || destinationPath.Equals("/") || destinationPath.Equals(" /") || 
                destinationPath.Contains("\\..\\.."))
            {
                currentPath = Path.GetPathRoot(currentPath);
                InputCommand(currentPath);
                return;
            }

            //한단계 상위
            if (destinationPath.Equals("..") || destinationPath.Equals(" ..") || destinationPath.Trim().Equals(".."))
            {
                if(currentPath.Equals("C:\\"))
                {
                    InputCommand(currentPath);
                    return;
                }
                currentPath = Directory.GetParent(currentPath).FullName;
                InputCommand(currentPath);
                return;
            }

            //두단계 상위
            if (destinationPath.Trim().Contains("..\\\\..") || destinationPath.Equals(" ..\\\\.."))
            {
                currentPath = Directory.GetParent(Directory.GetParent(currentPath).FullName).FullName;
                InputCommand(currentPath);
                return;
            }

            //아무런 변화x
            if(destinationPath.Trim().Contains("..."))
            {
                InputCommand(currentPath);
            }

            //유효한 경로인지 확인
            if (errorCheck.IsValidPath(currentPath + "\\" + command.Trim().Remove(0, 3).TrimStart()) == false)
            {
                print.FindingPathError("경로를");
                InputCommand(currentPath);
                return;
            }

            //실제 경로로
            else
            {
                if (currentPath == "C:\\")
                {
                    currentPath = currentPath + command.Remove(0, 3);
                    InputCommand(currentPath);
                }
                else
                {
                    currentPath = currentPath + "\\" + command.Trim().Remove(0, 3).TrimStart();
                    InputCommand(currentPath);
                }
            }
        }

        //cls 명령어 수행
        public void ClearSystem()
        {
            Console.Clear();
            Console.WriteLine();
            InputCommand(currentPath);
        }

        //Help 명령어 수행
        public void Help()
        {
            print.ShowHelp();
            InputCommand(currentPath);
        }

        //Copy 명령어 수행
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
                    print.FindingPathError("파일을");
                    InputCommand(currentPath);
                    return;
                }

                //경로가 하나만 있는 경우(copy c:\users\sb\desktop\sb\aoa.txt) 바탕화면 폴더의 aoa텍스트를 현재 경로에 복사
                if (copyCommandObject.Length == 1)
                {   
                    //dest에 같은 파일명이 있으면
                    if (File.Exists(currentPath + "\\" + Path.GetFileName(copyCommandObject[0])))
                    {
                        DuplicatedFileHandler(copyCommandObject, "copy");
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
                            DuplicatedFileHandler(copyCommandObject, "copy");
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
                            DuplicatedFileHandler(copyCommandObject, "copy");
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
                    print.FindingPathError("파일을");
                    InputCommand(currentPath);
                    return;
                }

                //copy a.txt c:\users\sb\desktop\sb\aoa.txt
                if(copyCommandObject[1].Contains("\\"))
                {
                    if (File.Exists(copyCommandObject[1]))
                    {
                        DuplicatedFileHandler(copyCommandObject, "copy");
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
                        DuplicatedFileHandler(copyCommandObject, "copy");
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
        
        //Move명령어 수행
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
                    print.FindingPathError("파일을");
                    InputCommand(currentPath);
                    return;
                }

                //경로가 하나만 있는 경우(move c:\users\sb\desktop\sb\aoa.txt) 바탕화면 폴더의 aoa텍스트를 현재 경로에 복사
                if (moveCommandObject.Length == 1)
                {
                    //dest에 같은 파일명이 있으면
                    if (File.Exists(currentPath + "\\" + Path.GetFileName(moveCommandObject[0])))
                    {
                        DuplicatedFileHandler(moveCommandObject, "move");
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

                //move c:\users\sb\desktop\a.txt c:\users\sb\desktop\sb\aoa.txt 
                if (moveCommandObject.Length == 2)
                {
                    if (moveCommandObject[1].Contains("\\"))
                    {
                        //dest에 같은 파일명 있음
                        if (File.Exists(moveCommandObject[1]))
                        {
                            DuplicatedFileHandler(moveCommandObject, "move");
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

                    //move c:\users\sb\desktop\a.txt c.txt
                    else
                    {
                        if (File.Exists(currentPath + "\\" + moveCommandObject[1]))
                        {
                            DuplicatedFileHandler(moveCommandObject, "move");
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
                    print.FindingPathError("파일을");
                    InputCommand(currentPath);
                    return;
                }
                //move a.txt c:\users\sb\desktop\sb\aoa.txt
                if (moveCommandObject[1].Contains("\\"))
                {
                    if (File.Exists(moveCommandObject[1]))
                    {
                        DuplicatedFileHandler(moveCommandObject,"move");
                        return;
                    }

                    else
                    {
                        moveCount = 1;
                        int flag = moveCommandObject[1].LastIndexOf('\\');
                        string DestinationPath = moveCommandObject[1].Remove(flag);

                        if (errorCheck.IsValidPath(moveCommandObject[1]) == false)
                        {
                            print.FindingPathError("경로를");
                            InputCommand(currentPath);
                            return;
                        }
                        File.Move(currentPath + "\\" + moveCommandObject[0], moveCommandObject[1]);
                        print.MoveCompleted(moveCount);
                        InputCommand(currentPath);
                        return;
                    }
                }

                //move a.txt b.txt
                else
                {
                    if (File.Exists(currentPath + "\\" + moveCommandObject[1]))
                    {
                        DuplicatedFileHandler(moveCommandObject, "move");
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

        //중복 파일의 경우 확인 문구에 대한 대답 문구 예외처리 수행
        public void OperateDividingByConfirmString(string[] inputCommand, string commandType, string confirm)
        {
            int copiedCount;
            int movedCount;

            //move명령어 일때
            if (commandType.Equals("copy"))
            {
                if (confirm.Contains("YES") && confirm.Contains("ALL") && confirm.Contains("NO"))
                {
                    //더 앞쪽에 나오는 확인문구로 명령어 실행(yes나 all이 나오는경우)
                    if (confirm.IndexOf("YES") < confirm.IndexOf("NO") || confirm.IndexOf("ALL") < confirm.IndexOf("NO"))
                    {
                        if (inputCommand.Length == 1)
                            File.Copy(currentPath, inputCommand[0], true);

                        if (inputCommand.Length == 2)
                        {
                            if (inputCommand[0].Contains("\\") && inputCommand[1].Contains("\\"))
                                File.Copy(inputCommand[0], inputCommand[1], true);

                            else if (inputCommand[0].Contains("\\") && !inputCommand[1].Contains("\\"))
                                File.Copy(inputCommand[0], currentPath + "\\" + inputCommand[1], true);

                            else if (!inputCommand[0].Contains("\\") && inputCommand[1].Contains("\\"))
                                File.Copy(currentPath + "\\" + inputCommand[0], inputCommand[1], true);

                            else if (!inputCommand[0].Contains("\\") && !inputCommand[1].Contains("\\"))
                                File.Copy(currentPath + "\\" + inputCommand[0], currentPath + "\\" + inputCommand[1], true);
                        }
                        copiedCount = 1;
                    }

                    //더 앞쪽에 NO가 나오는 경우
                    else
                    {
                        copiedCount = 0;
                    }
                    print.CopyCompleted(copiedCount);
                    InputCommand(currentPath);
                }

                //Yes나 All문구만 있는 경우
                else if (confirm.Contains("YES") || confirm.Contains("ALL"))
                {
                    if (inputCommand.Length == 1)
                        File.Copy(currentPath, inputCommand[0], true);

                    if (inputCommand.Length == 2)
                    {
                        if (inputCommand[0].Contains("\\") && inputCommand[1].Contains("\\"))
                            File.Copy(inputCommand[0], inputCommand[1], true);

                        else if (inputCommand[0].Contains("\\") && !inputCommand[1].Contains("\\"))
                            File.Copy(inputCommand[0], currentPath + "\\" + inputCommand[1], true);

                        else if (!inputCommand[0].Contains("\\") && inputCommand[1].Contains("\\"))
                            File.Copy(currentPath + "\\" + inputCommand[0], inputCommand[1], true);

                        else if (!inputCommand[0].Contains("\\") && !inputCommand[1].Contains("\\"))
                            File.Copy(currentPath + "\\" + inputCommand[0], currentPath + "\\" + inputCommand[1], true);
                    }
                    copiedCount = 1;
                    print.CopyCompleted(copiedCount);
                    InputCommand(currentPath);
                }

                //No문구만 있는 경우
                else if (confirm.Contains("NO"))
                {
                    copiedCount = 0;
                    print.CopyCompleted(copiedCount);
                    InputCommand(currentPath);
                }

                //아무런 글자를 입력했을 때 카피 명령 실행
                else
                {
                    if (inputCommand.Length == 1)
                        File.Copy(currentPath, inputCommand[0], true);

                    if (inputCommand.Length == 2)
                    {
                        if (inputCommand[0].Contains("\\") && inputCommand[1].Contains("\\"))
                            File.Copy(inputCommand[0], inputCommand[1], true);

                        else if (inputCommand[0].Contains("\\") && !inputCommand[1].Contains("\\"))
                            File.Copy(inputCommand[0], currentPath + "\\" + inputCommand[1], true);

                        else if (!inputCommand[0].Contains("\\") && inputCommand[1].Contains("\\"))
                            File.Copy(currentPath + "\\" + inputCommand[0], inputCommand[1], true);

                        else if (!inputCommand[0].Contains("\\") && !inputCommand[1].Contains("\\"))
                            File.Copy(currentPath + "\\" + inputCommand[0], currentPath + "\\" + inputCommand[1], true);
                    }
                    copiedCount = 1;
                    print.CopyCompleted(copiedCount);
                    InputCommand(currentPath);
                }
            }

            //move명령어
            if (commandType.Equals("move"))
            {
                if (confirm.Contains("YES") && confirm.Contains("ALL") && confirm.Contains("NO"))
                {
                    //더 앞쪽에 나오는 확인문구로 명령어 실행(yes나 all이 나오는경우)
                    if (confirm.IndexOf("YES") < confirm.IndexOf("NO") || confirm.IndexOf("ALL") < confirm.IndexOf("NO"))
                    {
                        if (inputCommand.Length == 1)
                        {
                            File.Delete(inputCommand[0]);
                            File.Move(currentPath, inputCommand[0]);
                        }

                        if (inputCommand.Length == 2)
                        {
                            if (inputCommand[0].Contains("\\") && inputCommand[1].Contains("\\"))
                            {
                                File.Delete(inputCommand[1]);
                                File.Move(inputCommand[0], inputCommand[1]);
                            }

                            else if (inputCommand[0].Contains("\\") && !inputCommand[1].Contains("\\"))
                            {
                                File.Delete(currentPath + "\\" + inputCommand[1]);
                                File.Move(inputCommand[0], currentPath + "\\" + inputCommand[1]);
                            }

                            else if (!inputCommand[0].Contains("\\") && inputCommand[1].Contains("\\"))
                            {
                                File.Delete(inputCommand[1]);
                                File.Move(currentPath + "\\" + inputCommand[0], inputCommand[1]);
                            }

                            else if (!inputCommand[0].Contains("\\") && !inputCommand[1].Contains("\\"))
                            {
                                File.Delete(currentPath + "\\" + inputCommand[1]);
                                File.Move(currentPath + "\\" + inputCommand[0], currentPath + "\\" + inputCommand[1]);
                            }

                        }
                        movedCount = 1;
                    }

                    //더 앞쪽에 NO가 나오는 경우
                    else
                    {
                        movedCount = 0;
                    }
                    print.MoveCompleted(movedCount);
                    InputCommand(currentPath);
                }

                //Yes나 All문구만 있는 경우
                else if (confirm.Contains("YES") || confirm.Contains("ALL"))
                {
                    if (inputCommand.Length == 1)
                    {
                        File.Delete(inputCommand[0]);
                        File.Move(currentPath, inputCommand[0]);
                    }

                    if (inputCommand.Length == 2)
                    {
                        if (inputCommand[0].Contains("\\") && inputCommand[1].Contains("\\"))
                        {
                            File.Delete(inputCommand[1]);
                            File.Move(inputCommand[0], inputCommand[1]);
                        }

                        else if (inputCommand[0].Contains("\\") && !inputCommand[1].Contains("\\"))
                        {
                            File.Delete(inputCommand[1]);
                            File.Move(inputCommand[0], currentPath + "\\" + inputCommand[1]);
                        }

                        else if (!inputCommand[0].Contains("\\") && inputCommand[1].Contains("\\"))
                        {
                            File.Delete(inputCommand[1]);
                            File.Move(currentPath + "\\" + inputCommand[0], inputCommand[1]);
                        }

                        else if (!inputCommand[0].Contains("\\") && !inputCommand[1].Contains("\\"))
                        {
                            File.Delete(currentPath + "\\" + inputCommand[1]);
                            File.Move(currentPath + "\\" + inputCommand[0], currentPath + "\\" + inputCommand[1]);
                        }
                    }
                    movedCount = 1;
                    print.MoveCompleted(movedCount);
                    InputCommand(currentPath);
                }

                //No문구만 있는 경우
                else if (confirm.Contains("NO"))
                {
                    movedCount = 0;
                    print.MoveCompleted(movedCount);
                    InputCommand(currentPath);
                }

                //아무런 글자를 입력했을 때 카피 명령 실행
                else
                {
                    if (inputCommand.Length == 1)
                    {
                        File.Delete(inputCommand[0]);
                        File.Move(currentPath, inputCommand[0]);
                    }

                    if (inputCommand.Length == 2)
                    {
                        if (inputCommand[0].Contains("\\") && inputCommand[1].Contains("\\"))
                        {
                            File.Delete(inputCommand[1]);
                            File.Move(inputCommand[0], inputCommand[1]);
                        }

                        else if (inputCommand[0].Contains("\\") && !inputCommand[1].Contains("\\"))
                        {
                            File.Delete(inputCommand[1]);
                            File.Move(inputCommand[0], currentPath + "\\" + inputCommand[1]);
                        }

                        else if (!inputCommand[0].Contains("\\") && inputCommand[1].Contains("\\"))
                        {
                            File.Delete(inputCommand[1]);
                            File.Move(currentPath + "\\" + inputCommand[0], inputCommand[1]);
                        }

                        else if (!inputCommand[0].Contains("\\") && !inputCommand[1].Contains("\\"))
                        {
                            File.Delete(inputCommand[1]);
                            File.Move(currentPath + "\\" + inputCommand[0], currentPath + "\\" + inputCommand[1]);
                        }
                    }
                    movedCount = 1;
                    print.MoveCompleted(movedCount);
                    InputCommand(currentPath);
                }
            }
        }

        //중복 파일이 있는 경우 
        public void DuplicatedFileHandler(string[] inputCommand, string commandType)
        {
            string confirm;

            if (inputCommand.Length == 1)
            {
                print.ConfirmOverwrite(Path.GetFileName(inputCommand[0]));
            }

            if (inputCommand.Length == 2)
            {
                if (inputCommand[1].Contains("\\"))
                    print.ConfirmOverwrite(Path.GetFileName(inputCommand[1]));
                else
                    print.ConfirmOverwrite(inputCommand[1]);
            }

            confirm = Console.ReadLine().ToUpper();

            if (commandType.Equals("copy"))
                OperateDividingByConfirmString(inputCommand, "copy", confirm);
            else if (commandType.Equals("move"))
                OperateDividingByConfirmString(inputCommand, "move", confirm);
        }
    }
}