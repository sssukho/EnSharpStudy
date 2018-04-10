using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class Member
    {
        private string name;
        private string studentId;
        private string gender;
        private string phoneNumber;
        private string email;
        private string address;

        public Member()
        {

        }

        public Member(string name, string studentId, string gender, string phoneNumber, string email, string address)
        {
            this.name = name;
            this.studentId = studentId;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.address = address;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string StudentId
        {
            get { return studentId; }
            set { studentId = value; }
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
    }
}
