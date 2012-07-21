using System;
using System.Collections.Generic;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.Email.Template.List.Data.Abstract;
using ThreeBytes.Email.Template.List.Entities;
using ThreeBytes.Email.Template.List.Entities.Enums;
using ThreeBytes.Email.Template.List.Service.Abstract;

namespace ThreeBytes.Email.Template.List.Service.Concrete
{
    public class EmailTemplateListTemplateService : KeyedGenericService<EmailTemplateListTemplate>, IEmailTemplateListTemplateService
    {
        protected new readonly IEmailTemplateListTemplateRepository Repository;

        public EmailTemplateListTemplateService(IEmailTemplateListTemplateRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings) : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public IList<EmailTemplateListTemplate> GetAll(string applicationName)
        {
            return Repository.GetAll(applicationName);
        }

        public IPagedResult<EmailTemplateListTemplate> GetAllPaged(int take, DateTime? originalRequestDateTime, string applicationName, TemplateListOrderBy orderBy = TemplateListOrderBy.Name, SortBy sortBy = SortBy.Desc, int page = 1)
        {
            return Repository.GetAllPaged(take, originalRequestDateTime, applicationName, orderBy, sortBy, page);
        }

        public IMostRecentResult<EmailTemplateListTemplate> GetLatestSince(DateTime datetime, string applicationName)
        {
            return Repository.GetLatestSince(datetime, applicationName);
        }

        public IList<EmailTemplateListTemplate> GetMostRecent(int take, string applicationName)
        {
            return Repository.GetMostRecent(take, applicationName);
        }

        public int Count(string applicationName)
        {
            return Repository.Count(applicationName);
        }

        public bool UniqueTemplate(string name, string applicationName)
        {
            return Repository.UniqueTemplate(name, applicationName);
        }
    }
}
