using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryOfBooks.Models;
namespace LibraryOfBooks.Views
{
    class VisitorView
    {
        public void ListOverdue(List<Visitor> visitors)
        {
            foreach (Visitor visitor in visitors)
                Console.WriteLine("{0} has overdued some books", visitor.ToString());
        }
        public void ListVisitors(Dictionary<int, Visitor> visitors)
        {
            foreach (Visitor visitor in visitors.Values)
                Console.WriteLine(visitor.ToString());
        }
    }
}
