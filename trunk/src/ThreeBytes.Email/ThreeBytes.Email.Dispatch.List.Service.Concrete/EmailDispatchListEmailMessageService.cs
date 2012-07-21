using System;
using System.Collections.Generic;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.Email.Dispatch.List.Data.Abstract;
using ThreeBytes.Email.Dispatch.List.Entities;
using ThreeBytes.Email.Dispatch.List.Entities.Enums;
using ThreeBytes.Email.Dispatch.List.Service.Abstract;

namespace ThreeBytes.Email.Dispatch.List.Service.Concrete
{
    public class EmailDispatchListEmailMessageService : KeyedGenericService<EmailDispatchListEmailMessage>, IEmailDispatchListEmailMessageService
    {
        protected new readonly IEmailDispatchListEmailMessageRepository Repository;

        public EmailDispatchListEmailMessageService(IEmailDispatchListEmailMessageRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings) : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public IList<EmailDispatchListEmailMessage> GetAll(string applicationName)
        {
            return Repository.GetAll(applicationName);
        }

        public IPagedResult<EmailDispatchListEmailMessage> GetAllPaged(int take, DateTime? originalRequestDateTime, string applicationName, EmailDispatchListOrderBy orderBy = EmailDispatchListOrderBy.CreationDateTime, SortBy sortBy = SortBy.Desc, int page = 1)
        {
            return Repository.GetAllPaged(take, originalRequestDateTime, applicationName, orderBy, sortBy, page);
        }

        public IMostRecentResult<EmailDispatchListEmailMessage> GetLatestSince(DateTime datetime, string applicationName)
        {
            return Repository.GetLatestSince(datetime, applicationName);
        }

        public IList<EmailDispatchListEmailMessage> GetMostRecent(int take, string applicationName)
        {
            return Repository.GetMostRecent(take, applicationName);
        }

        public int Count(string applicationName)
        {
            return Repository.Count(applicationName);
        }
    }
}
