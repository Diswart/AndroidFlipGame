using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryOfBooks.Models;
namespace LibraryOfBooks.Views
{
    class BookView
    {
        public void ListBooks(Dictionary<int,Book> books)
        { 
            foreach (Book book in books.Values)
                Console.WriteLine(book.ToString());
        }
        
        public void BookBorrowed()
        { 
            Console.WriteLine("Book succesfully borrowed");       
        }
        public void BookFailedToBorrow()
        {
            Console.WriteLine("Either this book is already borrowed or this visitor already has 3 books");
        }
        public void BookReturned()
        {
            Console.WriteLine("Book succesfully returned");
        }
        public void BookFailedToReturn()
        {
            Console.WriteLine("Visitor doesn't have this book");
        }
    }
}
