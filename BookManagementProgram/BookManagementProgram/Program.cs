using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            new Menu(new Menu(), new List<Member>(), new List<Book>());
        }
    }
}
