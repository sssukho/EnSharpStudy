using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class Book
    {
        private string index { set; get; } //책 번호
        private string bookName { set; get; } //책 제목
        private string bookPublisher { set; get; } //책 출판사
        private string bookAuthor { set; get; } //저자
        private string bookPrice { set; get; }//가격
        private string bookCount { set; get; } //수량

        List<Book> bookList;

        public Book()
        {
            bookList = new List<Book>();
        }

        public Book(string index, string bookName, string bookPublisher, string bookAuthor, string bookPrice, string bookCount)
        {
            this.index = index;
            this.bookName = bookName;
            this.bookPublisher = bookPublisher;
            this.bookAuthor = bookAuthor;
            this.bookPrice = bookPrice;
            this.bookCount = bookCount;
        }
    }
}
