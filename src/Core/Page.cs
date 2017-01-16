using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class Page<T>
    {
        public Page(int pageNumber, int numPages, int pageSize, IEnumerable<T> contents)
        {
            PageNumber = pageNumber;
            NumPages = numPages;
            PageSize = pageSize;
            Contents = contents;
        }

        public int PageNumber { get; private set; }
        public int NumPages { get; private set; }
        public int PageSize { get; private set; }
        public IEnumerable<T> Contents { get; private set; }
    }
}
