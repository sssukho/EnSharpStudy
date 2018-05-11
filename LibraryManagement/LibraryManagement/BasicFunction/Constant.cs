using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.BasicFunction
{
    class Constant
    {
        enum AdminMenu { EXIT, MEMBER_MANAGEMENT, BOOK_MANAGEMENT, DB_MANAGEMENT}
        enum UserMenu { EXIT, SEARCH_BOOK, PRINT_BOOKS, }
        enum MemberMenu { EXIT, REGISTER_MEMBER, EDIT_MEMBER, REMOVE_MEMBER, SEARCH_MEMBER, PRINT_MEMBERS }
        enum BookMenu { EXIT, REGISTER_BOOK, EDIT_BOOK, REMOVE_BOOK, SEARCH_BOOK, PRINT_BOOKS }
        enum SearchType { EXIT, SERARCH_BY_NAME, SEARCH_BY_PUBLISHER, SEARCH_BY_AUTHOR }
        enum BookRent { EXIT, RENT_BOOK, RETURN_BOOK, EXTENSION_BOOK }
    }
}
