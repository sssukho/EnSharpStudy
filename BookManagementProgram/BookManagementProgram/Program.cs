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
            List<Member> memberList = new List<Member>();
            List<Book> bookList = new List<Book>();
            new Menu(memberList, bookList);
            //new Menu(new MemberManagement(), new BookManagement());
        }
    }
}
