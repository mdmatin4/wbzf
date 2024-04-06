using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Utility
{
    public class PaginatedList<T> : List<T> where T : class
    {
        public int PageIndex { get; private set; }
        public int TotalCount { get; private set; }
        public int PageSize { get; private set; }
        private int _pageSize;
        public PaginatedList(List<T> items, int totalCount, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalCount = totalCount;
            PageSize = pageSize;
            _pageSize = pageSize;


            AddRange(items);
        }

        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)_pageSize);

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static PaginatedList<T> Create(List<T> items, int totalCount, int pageIndex, int pageSize)
        {
            return new PaginatedList<T>(items, totalCount, pageIndex, pageSize);
        }
    }
}
