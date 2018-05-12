using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    class MemberMenu
    {
        enum UserMenu { EXIT, RENT_EXTENSION, SEARCH_BOOK, PRINT_BOOKS }
        DAO dao;

        public MemberMenu(DAO dao)
        {
            this.dao = dao;
        }
    }
}
