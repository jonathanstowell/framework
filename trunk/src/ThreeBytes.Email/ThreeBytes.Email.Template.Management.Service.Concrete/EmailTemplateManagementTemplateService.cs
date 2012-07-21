using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.Email.Template.Management.Data.Abstract;
using ThreeBytes.Email.Template.Management.Entities;
using ThreeBytes.Email.Template.Management.Service.Abstract;

namespace ThreeBytes.Email.Template.Management.Service.Concrete
{
    public class EmailTemplateManagementTemplateService : KeyedGenericService<EmailTemplateManagementTemplate>, IEmailTemplateManagementTemplateService
    {
        protected new readonly IEmailTemplateManagementTemplateRepository Repository;

        public EmailTemplateManagementTemplateService(IEmailTemplateManagementTemplateRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings) : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public bool UniqueTemplate(string name, string applicationName)
        {
            return Repository.UniqueTemplate(name, applicationName);
        }
    }
}
