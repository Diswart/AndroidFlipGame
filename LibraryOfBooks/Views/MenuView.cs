using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfBooks.Views
{
    static class MenuView
    {
        public static void Menu()
        {
            Console.WriteLine("What can we do for you?");
            Console.WriteLine("1. List all books");
            Console.WriteLine("2. List all visitors");
            Console.WriteLine("3. Borrow visitor a book");
            Console.WriteLine("4. Receive a book from a visitor");
            Console.WriteLine("5. List all visitors with overdue books");
            Console.WriteLine("0. Exit");
        }
    }
}
