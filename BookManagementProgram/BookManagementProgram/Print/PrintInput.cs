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

        public Member Register()
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

            Member newMember = new Member(name, studentId, gender, phoneNumber, email, address);
            
            return newMember;
        }

        public Member Edit(Member inputMember, MemberErrorHandler errorHandler)
        {
            Console.Clear();

            Console.WriteLine("\n\n\t---------------------------------수정할 회원 기존 정보--------------------------------");
            Console.WriteLine("\n\t이름 : {0}", inputMember.Name);
            Console.WriteLine("\t학번 : {0}", inputMember.StudentId);
            Console.WriteLine("\t성별 : {0}", inputMember.Gender);
            Console.WriteLine("\t핸드폰 번호 : {0}", inputMember.PhoneNumber);
            Console.WriteLine("\t이메일 주소 : {0}", inputMember.Email);
            Console.WriteLine("\t주소 : {0}", inputMember.Address + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.WriteLine("\n\n\t---------------------------------수정할 회원 정보 입력--------------------------------");
            Console.Write("\n\t이름 입력 : ");
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

            inputMember.Name = name;
            inputMember.StudentId = studentId;
            inputMember.Gender = gender;
            inputMember.PhoneNumber = phoneNumber;
            inputMember.Email = email;
            inputMember.Address = address;
            
            return inputMember;
        }

        public string DeleteCheck(Member inputMember, MemberErrorHandler errorHandler)
        {
            Console.Clear();
            string input;

            Console.WriteLine("\n\n\t---------------------------------삭제할 회원 기존 정보--------------------------------");
            Console.WriteLine("\n\t이름 : {0}", inputMember.Name);
            Console.WriteLine("\t학번 : {0}", inputMember.StudentId);
            Console.WriteLine("\t성별 : {0}", inputMember.Gender);
            Console.WriteLine("\t핸드폰 번호 : {0}", inputMember.PhoneNumber);
            Console.WriteLine("\t주소 : {0}", inputMember.Address + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.WriteLine("\n\n\t정말로 삭제하시겠습니까? (Y/N) : "); //에러 체크할 것
            input = Console.ReadLine();


            return input;
        }

        public string SearchName()
        {
            Console.Clear();
            string name;
            Console.Write("\n\n\t수정할 회원의 이름을 입력해주세요 : ");
            name = Console.ReadLine();

            return name;
        }

        public string SearchStudentID()
        {
            Console.Clear();
            string studentID;
            Console.Write("\n\n\t수정할 회원의 학번을 입력해주세요 : ");
            studentID = Console.ReadLine();

            return studentID;
        }
    }
}
