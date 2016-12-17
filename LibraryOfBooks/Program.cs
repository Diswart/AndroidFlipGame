using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryOfBooks.Models;
using LibraryOfBooks.Controllers;
using LibraryOfBooks.Views;
using LibraryOfBooks.DataSources;
namespace LibraryOfBooks
{
    
    class Program
    {  
        static DataSource ChooseDataSource()
        {
            Console.WriteLine("Please choose a data source\n1. Text file\n2. Data base\n3. Cloud storage");
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return new DataSource(c);
        }
        static void ChooseAction(char choice)
        {
            switch (choice)
            {
                case '1':
                   LibraryController.ListBooksFromLibrary();
                    break;
                case '2':
                    LibraryController.ListVisitorFromLibrary();
                    break;
                case '3':
                    {
                        Console.WriteLine("Enter the id of a visitor to borrow a book to");
                        int visitorId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the id of a book being borrowed");
                        int bookId = int.Parse(Console.ReadLine());
                        LibraryController.BorrowBookToVisitor(visitorId, bookId);
                    }
                    break;
                case '4':
                    {
                        Console.WriteLine("Enter the id of a visitor who returns a book");
                        int visitorId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the id of a book being returned");
                        int bookId = int.Parse(Console.ReadLine());
                        LibraryController.ReturnBookFromVisitor(visitorId, bookId);
                    }
                    break;
                case '5':
                    LibraryController.ListVisitorsWithOverdue();
                    break;
            }
        }
        static void Main(string[] args)
        {
            char choice = ' ';
            Console.WriteLine("Welcome to the Library!");
            DataSource dataSource = ChooseDataSource();
            dataSource.LoadData(LibraryController.Visitors, LibraryController.Books);
            while (choice != '0')
            {
                MenuView.Menu();
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                ChooseAction(choice);
            }
            dataSource.StoreData(LibraryController.Visitors, LibraryController.Books);
        }
    }
}

