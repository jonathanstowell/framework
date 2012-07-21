using System;
using System.Collections.Generic;

namespace ThreeBytes.Core.Data.ResultSets.Abstract
{
    public interface IPagedResult<T> where T : class
    {
        IEnumerable<T> Items { get; set; }
        DateTime OriginalRequestDateTime { get; set; }

        int PageCount { get; }
        int TotalItemCount { get; }
        int PageNumber { get; }
        int PageSize { get; }

        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        bool IsFirstPage { get; }
        bool IsLastPage { get; }
    }
}
