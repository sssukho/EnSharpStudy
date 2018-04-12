using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class Book
    {
        private string index;
        private string name;
        private string publisher;
        private string author;
        private string price;
        private string count;

        public Book() { }

        public Book(string index, string name, string publisher, string author, string price, string count)
        {
            this.index = index;
            this.name = name;
            this.publisher= publisher;
            this.author = author;
            this.price = price;
            this.count = count;
        }

        public string Index
        {
            get { return index; }
            set { index = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
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

        public string Count
        {
            get { return count; }
            set { count = value; }
        }
    }
}
