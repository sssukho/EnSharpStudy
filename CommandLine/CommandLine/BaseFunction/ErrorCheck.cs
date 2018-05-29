using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CommandLine
{
    class ErrorCheck
    {
        public ErrorCheck() { }

        /// <summary>
        /// 유효 파일인지 검사
        /// </summary>
        /// <param name="inputPath"> 검사할 파일의 경로</param>
        /// <returns>유효 여부(true, false)</returns>
        public bool IsValidFile(string inputPath)
        {
            if(File.Exists(inputPath))
                return true;

            return false;
        }

        /// <summary>
        /// 유효 디렉토리(경로) 인지 검사
        /// </summary>
        /// <param name="inputPath">검사할 디렉토리(경로)의 경로</param>
        /// <returns>유효 여부(true, false)</returns>
        public bool IsValidPath(string inputPath)
        {
            if (Directory.Exists(inputPath))
                return true;

            return false;
        }

    }
}
