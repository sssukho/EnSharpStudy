using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManage
{
    /// <Member클래스>
    /// 회원 정보가 들어있는 VO로서 데이터 불러오고 저장함
    
    class Member
    {
        private string name;
        private string studentId;
        private string gender;
        private string phoneNumber;
        private string email;
        private string address;
        private string rentBook;
        private string dueDate;

        public Member() { }

        public Member(string name, string studentId, string gender, string phoneNumber, string email, string address, string rentBook, string dueDate)
        {
            this.name = name;
            this.studentId = studentId;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.address = address;
            this.rentBook = rentBook;
            this.dueDate = dueDate;
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
    }
}
