using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class BookDataAdd
    {
        public BookDataAdd(List<Book> bookList)
        {
            bookList.Add(new Book("일반물리학및실험1", "땅콩", "김용덕", "8,000원", 3));
            bookList.Add(new Book("오픈소스SW개론", "피넛", "안용학", "7,000원", 2));
            bookList.Add(new Book("C#프로그래밍", "불닭", "조상욱", "9,000원", 1));
            bookList.Add(new Book("소프트웨어특강", "세종대", "데미켓", "6,500원", 1));
            bookList.Add(new Book("웹프로그래밍", "사이버대", "김태균", "3,400원", 2));
        }
    }
}
