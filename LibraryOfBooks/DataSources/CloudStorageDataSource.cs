using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryOfBooks.Models;
namespace LibraryOfBooks.DataSources
{
    class CloudStorageDataSource : IDataSource
    {
        private string[] authorsNames = new string[9] { "Benjin", "Smirnov", "Slimjow", "Karet",  "Pompol", 
            "Amberty", "Stempford", "Tolstoy", "Fet" };
        private string[] visitorsNames = new string[5] { "Dergov", "Ichetov", "Luckin", "Kurov", "Agadze" };
        private Dictionary<int, Visitor> _storedVisitors;
        private Dictionary<int, Book> _storedBooks;
        public CloudStorageDataSource()
        {
            Random rnd = new Random();
            _storedVisitors = new Dictionary<int, Visitor>();
            for (int i = 0; i < visitorsNames.Length; i++)
                _storedVisitors.Add(i,new Visitor(visitorsNames[i], i));
            _storedBooks = new Dictionary<int, Book>();
            for (int i=0; i < 17; i++)
                _storedBooks.Add(i,(new Book("Book " + i, authorsNames[rnd.Next(0, 9)], i)));
        }
        public void StoreData(Dictionary<int,Visitor> visitors, Dictionary<int,Book> books)
        {
            _storedVisitors.Clear();
            _storedBooks.Clear();
            foreach(KeyValuePair<int, Visitor> pair in visitors)
            {
                _storedVisitors.Add(pair.Key, new Visitor(string.Copy(pair.Value.Name), pair.Value.Id));
            }
            foreach (KeyValuePair<int, Book> pair in books)
            {
                _storedBooks.Add(pair.Key, new Book(string.Copy(pair.Value.Name), string.Copy(pair.Value.Author), pair.Value.Id));
            }
        }

        
        public void LoadData(Dictionary<int, Visitor> visitors, Dictionary<int, Book> books)
        {
            visitors.Clear();
            books.Clear();
            foreach (KeyValuePair<int, Visitor> pair in _storedVisitors)
            {
                visitors.Add(pair.Key, new Visitor(string.Copy(pair.Value.Name), pair.Value.Id));
            }
            foreach (KeyValuePair<int, Book> pair in _storedBooks)
            {
                books.Add(pair.Key, new Book(string.Copy(pair.Value.Name), string.Copy(pair.Value.Author), pair.Value.Id));
            }
        }
       
    }
}
