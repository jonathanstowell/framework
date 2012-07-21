using System;
using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.Email.Dispatch.List.Entities;
using ThreeBytes.Email.Dispatch.List.Entities.Enums;

namespace ThreeBytes.Email.Dispatch.List.Service.Abstract
{
    public interface IEmailDispatchListEmailMessageService : IKeyedGenericService<EmailDispatchListEmailMessage>
    {
        IList<EmailDispatchListEmailMessage> GetAll(string applicationName);
        IPagedResult<EmailDispatchListEmailMessage> GetAllPaged(int take, DateTime? originalRequestDateTime, string applicationName, EmailDispatchListOrderBy orderBy = EmailDispatchListOrderBy.CreationDateTime, SortBy sortBy = SortBy.Desc, int page = 1);
        IMostRecentResult<EmailDispatchListEmailMessage> GetLatestSince(DateTime datetime, string applicationName);
        IList<EmailDispatchListEmailMessage> GetMostRecent(int take, string applicationName);
        int Count(string applicationName);
    }
}
