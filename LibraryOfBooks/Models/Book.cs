using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfBooks.Models
{
    class Book
    {
        private string _name;
        private string _author;
        private int _id;
        private bool _taken;
        private DateTime? _dayOfBorrowing;
        private Visitor _currentHolder;
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
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = string.Copy(value);
            }
        }
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value >= 0)
                {
                    _id = value;
                }
                else
                {
                 
                } 
            }
        }
        public bool Taken
        {
            get
            {
                return _taken;
            }
            set
            {
                _taken = value;
            }
        }
        public DateTime? DayOfBorrowing
        {
            get
            {
                return _dayOfBorrowing;
            }
            set
            {
                if (value.HasValue)
                    _dayOfBorrowing = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day);
                else
                    _dayOfBorrowing = null;
            }
        }
        public Visitor CurrentHolder
        {
            get
            {
                return _currentHolder;
            }
            set
            {
                _currentHolder = value;
            }
        }
        public Book()
        {
            _name = string.Empty;
            _author = string.Empty;
            
        }
        public Book(string name, string author, int id)
        {
            _name = name;
            _author = author;
            _id = id;
        }
        public void NullifyOnLibReturn()
        {
            Taken = false;
            CurrentHolder = null;
            DayOfBorrowing = null; 
        }
        public override string ToString()
        {
            return $"{_name} by author {_author} with id {_id}";
        }
    }
}
