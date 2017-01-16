using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample
{
    public class PageModel<TModel, TSource>
    {
        public PageModel(Page<TSource> page, Func<TSource, TModel> modelFactory)
        {
            PageNumber = page.PageNumber;
            NumPages = page.NumPages;
            PageSize = page.PageSize;
            Contents = page.Contents.Select(modelFactory);
        }

        public int PageNumber { get; private set; }
        public int NumPages { get; private set; }
        public int PageSize { get; private set; }
        public IEnumerable<TModel> Contents { get; private set; }
    }
}