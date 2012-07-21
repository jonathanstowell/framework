using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.Email.Dispatch.Management.Data.Abstract;
using ThreeBytes.Email.Dispatch.Management.Entities;
using ThreeBytes.Email.Dispatch.Management.Service.Abstract;

namespace ThreeBytes.Email.Dispatch.Management.Service.Concrete
{
    public class EmailDispatchManagementTemplateService : KeyedGenericService<EmailDispatchManagementTemplate>, IEmailDispatchManagementTemplateService
    {
        protected new readonly IEmailDispatchManagementTemplateRepository Repository;

        public EmailDispatchManagementTemplateService(IEmailDispatchManagementTemplateRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings) : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public EmailDispatchManagementTemplate GetBy(string name, string applicationName)
        {
            return Repository.GetBy(name, applicationName);
        }

        public bool UniqueTemplate(string name, string applicationName)
        {
            return Repository.UniqueTemplate(name, applicationName);
        }
    }
}