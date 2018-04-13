using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManage
{
    class Book
    {
        private string bookName;
        private string publisher;
        private string author;
        private string price;
        private int count;

        public Book() { }

        public Book(string name, string publisher, string author, string price, int count)
        {
            this.bookName = name;
            this.publisher = publisher;
            this.author = author;
            this.price = price;
            this.count = count;
        }

        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }
}
