using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfBooks.Models
{
    class Visitor
    {
        private int _id;
        private string _name;
        private Dictionary<int, Book> booksInPossesion;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value > 0)
                {
                    _id = value;
                }
                else
                {

                }
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = string.Copy(value);
            }
        }
        public Visitor()
        {
            _name = string.Empty;
            booksInPossesion = new Dictionary<int, Book>(); 
        }
        public Visitor(string name, int id)
        {
            _name = name;
            _id = id;
            booksInPossesion = new Dictionary<int, Book>();
        }
        public bool AddBook(Book book)
        {
            if (book.Taken)
            {
                return false;        
            }
            else
            {
                if (booksInPossesion.Count < 3)
                {
                    book.Taken = true;
                    book.DayOfBorrowing = DateTime.Now;
                    book.CurrentHolder = this;
                    booksInPossesion.Add(book.Id, book);
                    return true;                 
                }
                else
                {                  
                    return false;
                }
            }
            
        }
        public Dictionary<int,Book> GetPossesedBooks()
        {
            return booksInPossesion;
        }
        public bool ReturnBook(int id)
        {
            if (booksInPossesion.ContainsKey(id))
            {
                booksInPossesion[id].NullifyOnLibReturn();
                booksInPossesion.Remove(id);
                return true;
            }
            else return false;
        }
        public override string ToString()
        {
            return $"Visitor {_name} with id {_id}";
        }
    }
}
