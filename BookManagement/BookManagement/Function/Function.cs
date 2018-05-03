using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{   
    class Function
    {
        private const bool SUCCESS = true;
        private const bool FAILED = false;

        Print print;
        ErrorCheck errorCheck;
        Menu menu;
        Query query;

        public Function(Menu menu, Query query)
        {
            print = Print.GetInstance();
            errorCheck = ErrorCheck.GetInstance();
            this.menu = menu;
            this.query = query;
        }

        public void RegisterMember()
        {
            MemberVO newMember;
            newMember = print.MemberRegister();

            if(query.RegisterMemberQuery(newMember) == SUCCESS)
            {
                print.CompleteMsg("등록이 완료");
                menu.MemberManagementMenu();
            }
            
            else
            {
                menu.MemberManagementMenu();
            }
        }

        public void EditMember()
        {

        }

        public void RemoveMember()
        {

        }

        public void PrintMembers()
        {

        }

        public void RegisterBook()
        {

        }

        public void EditBook()
        {

        }

        public void RemoveBook()
        {

        }

        public void SearchBook(int searchType)
        {

        }

        public void PrintBooks()
        {

        }

        public void RentBook()
        {

        }

        public void ReturnBook()
        {

        }
    }
}
