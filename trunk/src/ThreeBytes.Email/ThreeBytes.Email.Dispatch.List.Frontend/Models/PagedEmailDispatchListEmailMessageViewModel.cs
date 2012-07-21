using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Email.Dispatch.List.Entities;

namespace ThreeBytes.Email.Dispatch.List.Frontend.Models
{
    public class PagedEmailDispatchListEmailMessageViewModel
    {
        public IPagedResult<EmailDispatchListEmailMessage> PagedResult { get; set; }
        public IMostRecentResult<EmailDispatchListEmailMessage> MostRecentResult { get; set; }

        public PagedEmailDispatchListEmailMessageViewModel(IPagedResult<EmailDispatchListEmailMessage> pagedResult)
            : this(pagedResult, null)
        {}

        public PagedEmailDispatchListEmailMessageViewModel(IPagedResult<EmailDispatchListEmailMessage> pagedResult, IMostRecentResult<EmailDispatchListEmailMessage> mostRecentResult)
        {
            PagedResult = pagedResult;
            MostRecentResult = mostRecentResult;

            if (mostRecentResult == null)
                MostRecentResult = new MostRecentResult<EmailDispatchListEmailMessage>(new List<EmailDispatchListEmailMessage>(), pagedResult.OriginalRequestDateTime, pagedResult.OriginalRequestDateTime);
        }
    }
}
