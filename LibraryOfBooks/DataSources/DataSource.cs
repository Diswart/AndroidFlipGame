using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryOfBooks.Models;
namespace LibraryOfBooks.DataSources
{
    class DataSource
    {
        public IDataSource _dataSource;
        public DataSource()
        {
            _dataSource = new TextFileDataSource();
        }
        public DataSource(char c)
        {
            switch (c)
            { 
                case '2':
                    _dataSource = new DataBaseDataSource();
                    break;
                case '3':
                    _dataSource = new CloudStorageDataSource();
                    break;
                default:
                    _dataSource = new TextFileDataSource();
                    break;
            }
        }
        public void LoadData(Dictionary<int,Visitor> visitors, Dictionary<int,Book> books)
        {
            _dataSource.LoadData(visitors, books);
        }
        public void StoreData(Dictionary<int,Visitor> visitors, Dictionary<int,Book> books)
        {
            _dataSource.StoreData(visitors, books);
        }
    }
}
