using System;
using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;

namespace ThreeBytes.Core.Data.ResultSets.Concrete
{
    [Serializable]
    public class PagedResult<T> : IPagedResult<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public DateTime OriginalRequestDateTime { get; set; }

        public int PageCount { get; set; }
        public int TotalItemCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }

        public PagedResult()
        {
            Items = new List<T>();
        }

        public PagedResult(IEnumerable<T> items, DateTime originalRequestDateTime, int totalItemCount, int pageNumber, int pageSize)
            : this()
        {
            Items = items;
            OriginalRequestDateTime = originalRequestDateTime;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItemCount = totalItemCount;

            Initialize(items);
        }

        protected void Initialize(IEnumerable<T> items)
        {
            if (TotalItemCount == 0)
                PageCount = 1;
            else
                PageCount = (int) Math.Ceiling(TotalItemCount/(double) PageSize);

            HasPreviousPage = (PageNumber > 1);
            HasNextPage = (PageNumber < PageCount);
            IsFirstPage = (PageNumber == 1);
            IsLastPage = (PageNumber == PageCount);
        }
    }
}
