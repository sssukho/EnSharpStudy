using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    class MemberVO
    {
        string id;
        string password;
        string name;
        string gender;
        string phoneNumber;
        string email;
        string address;
        string rentBook;
        string dueDate;
        int extensionCount;

        public MemberVO(string id, string password, string name, string gender, string phoneNumber, string email, string address, string rentBook, string dueDate, int extensionCount)
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.address = address;
            this.rentBook = rentBook;
            this.dueDate = dueDate;
            this.extensionCount = extensionCount;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Password
        {
            get { return password; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string RentBook
        {
            get { return rentBook; }
            set { rentBook = value; }
        }

        public string DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public int ExtensionCount
        {
            get { return extensionCount; }
            set { extensionCount = value; }
        }
    }
}
