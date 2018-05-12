using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class BookVO
    {
        private int index;
        private string name;
        private string author;
        private string price;
        private string publisher;
        private string publishDate;
        private int count;
        private string isbn;
        private string description;

        public BookVO(int index, string name, string author, string price, string publisher, string publishDate, int count, string isbn, string description)
        {
            this.index = index;
            this.name = name;
            this.author = author;
            this.price = price;
            this.publisher = publisher;
            this.publishDate = publishDate;
            this.count = count;
            this.isbn = isbn;
            this.description = description;
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
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

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        public string PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
