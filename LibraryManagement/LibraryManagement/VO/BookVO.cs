using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class BookVO
    {
        private string name;
        private string author;
        private string price;
        private string publisher;
        private string publishDate;
        private int count;
        private string isbn;
        private string explanation;

        public BookVO(string name, string author, string price, string publisher, string publishDate, int count, string isbn, string explanation)
        {
            this.name = name;
            this.author = author;
            this.price = price;
            this.publisher = publisher;
            this.publishDate = publishDate;
            this.count = count;
            this.isbn = isbn;
            this.explanation = explanation;
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

        public string Explanation
        {
            get { return explanation; }
            set { explanation = value; }
        }
    }
}
