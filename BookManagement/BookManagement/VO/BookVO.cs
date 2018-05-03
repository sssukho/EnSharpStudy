using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    class BookVO
    {
        public string name;
        public string author;
        public string publisher;
        public int count;

        public BookVO(string name, string author, string publisher, int count)
        {
            this.name = name;
            this.author = author;
            this.publisher = publisher;
            this.count = count;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Author
        {
            get { return author; }
            set { name = value; }
        }

        public string Publisher
        {
            get { return publisher; }
            set { name = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }
}
