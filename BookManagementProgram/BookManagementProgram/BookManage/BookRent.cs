using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    /// <summary>
    /// 도서 대여 및 반납을 관리하는 클래스
    /// </summary>
    class BookRent
    {
        List<Member> memberList;
        List<Book> bookList;
        BookRent bookRent;
        BookRentErrorCheck errorCheck;
        BookRentErrorHandler errorHandler;
        PrintInput printInput;
        PrintErrorMsg printErrorMsg;
        PrintCompleteMsg printCompleteMsg;
        Menu menu;
        

        string menuSelect;
        bool error;
        int bookIndex; //책 인덱스
        int memberIndex; //사람 인덱스

        public BookRent() { }

        public void ViewMenu(List<Member> memberList, List<Book> bookList, Menu menu)
        {
            this.memberList = memberList;
            this.bookList = bookList;
            this.menu = menu;
            this.bookRent = new BookRent();
            this.errorCheck = new BookRentErrorCheck();
            this.printInput = new PrintInput();
            this.printErrorMsg = new PrintErrorMsg();
            this.printCompleteMsg = new PrintCompleteMsg();
            this.errorHandler = new BookRentErrorHandler(errorCheck, printErrorMsg, bookRent, memberList, bookList, menu);

            PrintMenu.ViewBookRentMenu();
            menuSelect = Console.ReadLine();

            errorHandler.MenuErrorHandler(menu, menuSelect);
        }

        public void Rental(List<Member> inputMemberList, List<Book> inputBookList) //에러체크
        {
            string name;
            ConsoleKeyInfo input;

            bookIndex = SearchByBookName(inputBookList);
            error = errorCheck.IndexErrorCheck(bookIndex);

            if (error == true) //책 검색 후 존재안함
            {
                printErrorMsg.NoBookErrorMsg();
                input = Console.ReadKey(true);

                if(int.Parse(input.KeyChar.ToString()) == 1)
                {
                    Rental(inputMemberList, inputBookList);
                }

                else if(int.Parse(input.KeyChar.ToString()) == 2)
                {
                    ViewMenu(inputMemberList, inputBookList, menu);
                }
            }

            else //책 있으면 수량체크
            {
                if (inputBookList[bookIndex].Count == 0)
                {
                    printErrorMsg.BookCountErrorMsg();
                    if (error == true) //책 검색 후 존재안함
                    {
                        printErrorMsg.NoBookErrorMsg();
                        input = Console.ReadKey(true);

                        if (int.Parse(input.KeyChar.ToString()) == 1)
                        {
                            Rental(inputMemberList, inputBookList);
                        }

                        else if (int.Parse(input.KeyChar.ToString()) == 2)
                        {
                            ViewMenu(inputMemberList, inputBookList, menu);
                        }
                    }
                }
                else
                {
                    Console.Write("\n\n\t빌릴 사람 입력 : ");//책 수량 있음
                    name = Console.ReadLine();
                    memberIndex = inputMemberList.FindIndex(member => member.Name.Equals(name));
                    if(error == true)
                    {
                        printErrorMsg.NoMemberErrorMsg();
                        input = Console.ReadKey(true);

                        if (int.Parse(input.KeyChar.ToString()) == 1)
                        {
                            Rental(inputMemberList, inputBookList);
                        }

                        else if (int.Parse(input.KeyChar.ToString()) == 2)
                        {
                            ViewMenu(inputMemberList, inputBookList, menu);
                        }
                    }
                    DoRental(inputMemberList, inputBookList, bookIndex, memberIndex);
                }
            }
        }

        public void DoRental(List<Member> inputMemberList, List<Book> inputBookList, int bookIndex, int memberIndex)
        {
            inputBookList[bookIndex].Count = inputBookList[bookIndex].Count - 1;
            inputMemberList[memberIndex].DueDate = "2018-04-20";
            inputMemberList[memberIndex].RentBook = inputBookList[bookIndex].BookName;

            printCompleteMsg.RentalCompleteMsg();
            ViewMenu(inputMemberList, inputBookList, menu); 
        }

        public int SearchByBookName(List<Book> inputBookList) //에러체크
        {
            Console.Clear();
            string bookName;
            int listIndex;
            Console.Write("\n\n\t책 제목 검색 : ");
            bookName = Console.ReadLine();

            listIndex = inputBookList.FindIndex(book => book.BookName.Equals(bookName));
            error = errorCheck.IndexErrorCheck(listIndex);

            if(error == true)
            {
                return -1;
            }

            else
            {
                return listIndex;
            }
        }

        public void Return(List<Member> inputMemberList, List<Book> inputBookList)
        {
            string bookName;
            string confirm;
            memberIndex = SearchByMemberName(inputMemberList); //사람 값 가져옴
            bookName = inputMemberList[memberIndex].RentBook; //사람이 빌려간 책 이름
            bookIndex = inputBookList.FindIndex(book => book.BookName.Equals(bookName));

            Console.WriteLine(bookName +"을 반납하시겠습니까(Y/N)?");
            confirm = Console.ReadLine();
            ///////////////예외처리
            if (confirm == "Y" || confirm == "y")
            {
                inputBookList[bookIndex].Count = inputBookList[bookIndex].Count + 1;
                inputMemberList[memberIndex].RentBook = " ";
                inputMemberList[memberIndex].DueDate = " ";
                printCompleteMsg.ReturnCompleteMsg();
            }

            else if (confirm == "N" || confirm == "n")
            {
                printCompleteMsg.NotCompleteMsg();
                ViewMenu(inputMemberList, inputBookList, menu);
            }

        }

        public int SearchByMemberName(List<Member> inputMemberList)
        {
            int listIndex;
            string memberName;
            
            Console.Write("이름을 검색해주세요 : ");
            memberName = Console.ReadLine();
            listIndex = inputMemberList.FindIndex(member => member.Name.Equals(memberName));
            error = errorCheck.IndexErrorCheck(listIndex);

            if (error == true)
            {
                return -1;
                //다시 입력1번 이전 메뉴 2번 처리할 것 
            }

            else
            {
                return listIndex;
            }
        }

        public void Extension(List<Member> inputMemberList, List<Book> inputBookList)
        {
            string bookName;
            string confirm;
            memberIndex = SearchByMemberName(inputMemberList); //사람 값 가져옴
            bookName = inputMemberList[memberIndex].RentBook; //사람이 빌려간 책 이름
            bookIndex = inputBookList.FindIndex(book => book.BookName.Equals(bookName));

            Console.WriteLine("{0}을 연장하시겠습니까(Y/N)?", bookName);
            confirm = Console.ReadLine();
            ///////////////예외처리(날짜 2018-04-27이면 연장됐다고 연장 못하게)
            if (confirm == "Y" || confirm == "y")
            {
                inputBookList[bookIndex].Count = inputBookList[bookIndex].Count + 1;
                inputMemberList[memberIndex].DueDate= "2018-04-27";

                printCompleteMsg.ExtensionCompleteMsg();
                ViewMenu(inputMemberList, inputBookList, menu);
            }

            else if (confirm == "N" || confirm == "n")
            {
                printCompleteMsg.NotCompleteMsg();
                ViewMenu(inputMemberList, inputBookList, menu);
            }
        }
    }
}
