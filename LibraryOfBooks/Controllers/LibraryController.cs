using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryOfBooks.Models;
using LibraryOfBooks.Views;
namespace LibraryOfBooks.Controllers
{
    static class LibraryController
    {
        static private Dictionary<int, Book> books ; 
        static private Dictionary<int, Visitor> visitors;
        static private BookView bookView;
        static private VisitorView visitorView;
        static public Dictionary<int, Book> Books
        {
            get
            {
                return books;
            }
        }
        static public Dictionary<int, Visitor> Visitors
        {
            get
            {
                return visitors;
            }
        }
        static LibraryController()
        {
            books = new Dictionary<int, Book>();
            visitors = new Dictionary<int, Visitor>();
            bookView = new BookView();
            visitorView = new VisitorView();
        }
        static public void CreateBook(Book book)
        {
            books.Add(book.Id, book);
        }
        static public void CreateVisitor(Visitor visitor)
        {
            visitors.Add(visitor.Id, visitor);
        }
        static public void ListBooksFromLibrary()
        {
            bookView.ListBooks(books);
        }
        static public void ListVisitorFromLibrary()
        {
            visitorView.ListVisitors(visitors);
        }
        static public void BorrowBookToVisitor(int visitorId, int bookId)
        {
            if(visitors[visitorId].AddBook(books[bookId]))
            {
                bookView.BookBorrowed();
            }
            else
            {
                bookView.BookFailedToBorrow();
            }
        }
        static public void ReturnBookFromVisitor(int visitorId, int bookId)
        {
            if(visitors[visitorId].ReturnBook(bookId))
            {
                bookView.BookReturned();
            }
            else
            {
                bookView.BookFailedToReturn();
            }
        }
        static public void ListVisitorsWithOverdue()
        {
            List<Visitor> visitorsWithOverdue = new List<Visitor>();
            foreach (Book book in books.Values)
            {
                if (book.DayOfBorrowing.HasValue)
                {
                    if ((DateTime.Now - book.DayOfBorrowing.Value).TotalDays > DateTime.DaysInMonth(book.DayOfBorrowing.Value.Year, book.DayOfBorrowing.Value.Month))
                    {
                        visitorsWithOverdue.Add(book.CurrentHolder);
                    }
                }
            }
            visitorView.ListOverdue(visitorsWithOverdue);
        }
        
    }
}
