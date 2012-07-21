using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Logging.Exceptions.List.Entities;

namespace ThreeBytes.Logging.Exceptions.List.Frontend.Models
{
    public class PagedExceptionListViewModel
    {
        public IPagedResult<ExceptionList> PagedResult { get; set; }
        public IMostRecentResult<ExceptionList> MostRecentResult { get; set; }

        public PagedExceptionListViewModel(IPagedResult<ExceptionList> pagedResult)
            : this(pagedResult, null)
        {}

        public PagedExceptionListViewModel(IPagedResult<ExceptionList> pagedResult, IMostRecentResult<ExceptionList> mostRecentResult)
        {
            PagedResult = pagedResult;
            MostRecentResult = mostRecentResult;

            if (mostRecentResult == null)
                MostRecentResult = new MostRecentResult<ExceptionList>(new List<ExceptionList>(), pagedResult.OriginalRequestDateTime, pagedResult.OriginalRequestDateTime);
        }
    }
}
