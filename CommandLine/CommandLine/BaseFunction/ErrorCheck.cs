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

        public bool IsValidFile(string inputPath)
        {
            if(File.Exists(inputPath))
                return true;

            return false;
        }

        public bool IsValidPath(string inputPath)
        {
            if (Directory.Exists(inputPath))
                return true;

            return false;
        }

    }
}
