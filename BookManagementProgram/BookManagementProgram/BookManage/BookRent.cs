using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementProgram
{
    class BookRent : BookManagement
    {
        public BookRent()
        {

        }

        public void ViewMenu()
        {
            PrintMenu.ViewBookRentMenu();

        }
    }
}
