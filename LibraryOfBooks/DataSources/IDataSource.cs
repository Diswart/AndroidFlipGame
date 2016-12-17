using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryOfBooks.Models;
namespace LibraryOfBooks.DataSources
{
    interface IDataSource
    {
        void StoreData(Dictionary<int,Visitor> visitors, Dictionary<int, Book> books);
        void LoadData(Dictionary<int, Visitor> visitors, Dictionary<int, Book> books);
    }
}
