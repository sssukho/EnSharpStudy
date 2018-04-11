using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class PrintInput
    {
        string name, studentId, gender, phoneNumber, email, address;

        public Member Register(Member newMember)
        {
            Console.Clear();
            
            Console.Write("\n\n\t이름 입력 : ");
            name = Console.ReadLine();
            Console.Write("\n\n\t학번 입력 : ");
            studentId = Console.ReadLine();
            Console.Write("\n\n\t성별 입력 : ");
            gender = Console.ReadLine();
            Console.Write("\n\n\t핸드폰 번호 입력(xxx-xxxx-xxxx 형식) : ");
            phoneNumber = Console.ReadLine();
            Console.Write("\n\n\t이메일 입력 : ");
            email = Console.ReadLine();
            Console.Write("\n\n\t주소 입력 : ");
            address = Console.ReadLine();

            if (newMember == null)
            {
                newMember = new Member(name, studentId, gender, phoneNumber, email, address);
            }

            else
            {
                newMember.Name = name;
                newMember.StudentId = studentId;
                newMember.Gender = gender;
                newMember.PhoneNumber = phoneNumber;
                newMember.Email = email;
                newMember.Address = address;
            }
            
            return newMember;
        }

        public Member Edit(Member inputMember, MemberErrorHandler errorHandler)
        {
            Console.Clear();
            

            return inputMember;
        }

        public string SearchName()
        {
            string name;
            Console.WriteLine("이름을 입력해주세요");
            name = Console.ReadLine();

            return name;
        }

        public string SearchStudentID()
        {
            string studentID;
            Console.WriteLine("학번을 입력해주세요");
            studentID = Console.ReadLine();

            return studentID;
        }
    }
}
