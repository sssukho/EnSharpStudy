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
        string bookName, publisher, author, price;
        int count = 0;

        /***************************************회원 관리*************************************************/
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

            Member newMember = new Member(name, studentId, gender, phoneNumber, email, address, "", "");
            
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

            Console.Write("\n\n\t정말로 삭제하시겠습니까? (Y/N) : "); //에러 체크할 것
            input = Console.ReadLine();
            
            return input;
        }

        public string EditSearchName()
        {
            Console.Clear();
            string name;
            Console.Write("\n\n\t수정할 회원의 이름을 입력해주세요 : ");
            name = Console.ReadLine();

            return name;
        }

        public string EditSearchStudentID()
        {
            Console.Clear();
            string studentID;
            Console.Write("\n\n\t수정할 회원의 학번을 입력해주세요 : ");
            studentID = Console.ReadLine();

            return studentID;
        }

        public string DeleteSearchName()
        {
            Console.Clear();
            string name;
            Console.Write("\n\n\t삭제할 회원의 이름을 입력해주세요 : ");
            name = Console.ReadLine();

            return name;
        }

        public string DeleteSearchStudentID()
        {
            Console.Clear();
            string studentID;
            Console.Write("\n\n\t삭제할 회원의 학번을 입력해주세요 : ");
            studentID = Console.ReadLine();

            return studentID;
        }

        public string SearchCheck(Member inputMember, MemberErrorHandler errorHandler)
        {
            Console.Clear();
            string input;

            Console.WriteLine("\n\n\t---------------------------------검색한 회원 기존 정보--------------------------------");
            Console.WriteLine("\n\t이름 : {0}", inputMember.Name);
            Console.WriteLine("\t학번 : {0}", inputMember.StudentId);
            Console.WriteLine("\t성별 : {0}", inputMember.Gender);
            Console.WriteLine("\t핸드폰 번호 : {0}", inputMember.PhoneNumber);
            Console.WriteLine("\t주소 : {0}", inputMember.Address + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.Write("\n\n\t이전으로 돌아가려면 엔터..."); //에러 체크할 것
            input = Console.ReadLine();

            return input;
        }

        public string SearchName()
        {
            Console.Clear();
            string name;
            Console.Write("\n\n\t검색할 회원의 이름을 입력해주세요 : ");
            name = Console.ReadLine();

            return name;
        }

        public string SearchStudentID()
        {
            Console.Clear();
            string studentID;
            Console.Write("\n\n\t검색할 회원의 학번을 입력해주세요 : ");
            studentID = Console.ReadLine();

            return studentID;
        }

        public void ViewAllMember(List<Member> inputMemberList)
        {
            if (inputMemberList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t등록된 회원이 존재하지 않습니다.");
                Console.WriteLine("\n\n\t이전 메뉴로 돌아가려면 엔터...");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------회원 명단--------------------------------");
            Console.WriteLine("\t   이름   |   학번   |   성별   |   휴대폰번호   |   이메일   |   주소 ");
            
            foreach (var item in inputMemberList)
            {
                Console.WriteLine("\n\t   {0}      {1}      {2}      {3}      {4}      {5}", 
                    item.Name, item.StudentId, item.Gender, item.PhoneNumber, item.Email, item.Address);
            }

            Console.WriteLine("\n\n\t이전 메뉴로 돌아가려면 엔터...");
            Console.ReadLine();
        }

        /***************************************도서 관리*************************************************/

        public Book BookRegister()
        {
            Console.Clear();

            Console.Write("\n\n\t도서 제목 입력 : ");
            bookName = Console.ReadLine();
            Console.Write("\n\n\t출판사 입력 : ");
            publisher = Console.ReadLine();
            Console.Write("\n\n\t저자 입력 : ");
            author = Console.ReadLine();
            Console.Write("\n\n\t가격 입력 : ");
            price = Console.ReadLine();
            Console.Write("\n\n\t수량 입력 : ");
            count = int.Parse(Console.ReadLine());

          
            Book newBook = new Book(bookName, publisher, author, price, count);

            return newBook;
        }

        public string EditSearchBookName()
        {
            Console.Clear();
            string name;
            Console.Write("\n\n\t수정할 도서의 이름을 입력해주세요 : ");
            name = Console.ReadLine();

            return name;
        }

        public string EditSearchPublisher()
        {
            Console.Clear();
            string publisher;
            Console.Write("\n\n\t수정할 도서의 출판사를 입력해주세요 : ");
            publisher = Console.ReadLine();

            return publisher;
        }

        public string EditSearchAuthor()
        {
            Console.Clear();
            string author;
            Console.Write("\n\n\t수정할 도서의 작가를 입력해주세요 : ");
            author = Console.ReadLine();

            return author;
        }

        public Book BookEdit(Book inputBook, BookErrorHandler errorHandler)
        {
            Console.Clear();

            Console.WriteLine("\n\n\t---------------------------------수정할 도서 기존 정보--------------------------------");
            Console.WriteLine("\t도서 제목 : {0}", inputBook.BookName);
            Console.WriteLine("\t출판사 : {0}", inputBook.Publisher);
            Console.WriteLine("\t저자 : {0}", inputBook.Author);
            Console.WriteLine("\t도서 가격 : {0}", inputBook.Price);
            Console.WriteLine("\t수량 : {0}", inputBook.Count + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.WriteLine("\n\n\t---------------------------------수정할 도서 수량 입력--------------------------------");
            Console.WriteLine("\n\t수량을 입력해주세요 : ");
            count = int.Parse(Console.ReadLine()); //타입 에러체크

            inputBook.Count = count;
            return inputBook;
        }

        public string DeleteBookCheck(Book inputBook, BookErrorHandler errorHandler)
        {
            Console.Clear();
            string input;

            Console.WriteLine("\n\n\t---------------------------------삭제할 도서 기존 정보--------------------------------");
            Console.WriteLine("\t도서 제목 : {0}", inputBook.BookName);
            Console.WriteLine("\t출판사 : {0}", inputBook.Publisher);
            Console.WriteLine("\t저자 : {0}", inputBook.Author);
            Console.WriteLine("\t도서 가격 : {0}", inputBook.Price);
            Console.WriteLine("\t수량 : {0}", inputBook.Count + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.Write("\n\n\t정말로 삭제하시겠습니까? (Y/N) : "); //에러 체크할 것
            input = Console.ReadLine();

            return input;
        }

        public string DeleteSearchBookName()
        {
            Console.Clear();
            string name;
            Console.Write("\n\n\t삭제할 도서의 제목을 입력해주세요 : ");
            name = Console.ReadLine();

            return name;
        }

        public string DeleteSearchPublisher()
        {
            Console.Clear();
            string publisher;
            Console.Write("\n\n\t삭제할 도서의 출판사 입력해주세요 : ");
            publisher = Console.ReadLine();

            return publisher;
        }

        public string DeleteSearchAuthor()
        {
            Console.Clear();
            string author;
            Console.Write("\n\n\t삭제할 도서의 저자를 입력해주세요 : ");
            author = Console.ReadLine();

            return author;
        }

        public string BookSearchCheck(Book inputBook, BookErrorHandler errorHandler)
        {
            Console.Clear();
            string input;

            Console.WriteLine("\n\n\t---------------------------------검색한 도서 기존 정보--------------------------------");
            Console.WriteLine("\t도서 제목 : {0}", inputBook.BookName);
            Console.WriteLine("\t출판사 : {0}", inputBook.Publisher);
            Console.WriteLine("\t저자 : {0}", inputBook.Author);
            Console.WriteLine("\t도서 가격 : {0}", inputBook.Price);
            Console.WriteLine("\t수량 : {0}", inputBook.Count + "\n");
            Console.WriteLine("\t--------------------------------------------------------------------------------------");

            Console.Write("\n\n\t이전으로 돌아가려면 엔터..."); //에러 체크할 것
            input = Console.ReadLine();

            return input;
        }

        public string SearchBookName()
        {
            Console.Clear();
            string name;
            Console.Write("\n\n\t검색할 도서의 이름을 입력해주세요 : ");
            name = Console.ReadLine();

            return name;
        }

        public string SearchPublisher()
        {
            Console.Clear();
            string publisher;
            Console.Write("\n\n\t검색할 도서의 이름을 입력해주세요 : ");
            publisher = Console.ReadLine();

            return publisher;
        }

        public string SearchAuthor()
        {
            Console.Clear();
            string author;
            Console.Write("\n\n\t검색할 도서의 이름을 입력해주세요 : ");
            author = Console.ReadLine();

            return author;
        }

        public void ViewAllBook(List<Book> inputBookList)
        {
            if (inputBookList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t등록된 회원이 존재하지 않습니다.");
                Console.WriteLine("\n\n\t이전 메뉴로 돌아가려면 엔터...");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            Console.WriteLine("\n\n\t---------------------------------회원 명단--------------------------------");
            Console.WriteLine("\t   도서명   |   출판사   |   저자   |   가격   |   수량");

            foreach (var item in inputBookList)
            {
                Console.WriteLine("\n\t   {0}      {1}      {2}      {3}      {4}",
                    item.BookName, item.Publisher, item.Author, item.Price, item.Count);
            }

            Console.WriteLine("\n\n\t이전 메뉴로 돌아가려면 엔터...");
            Console.ReadLine();
        }
    }
}
