using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.Email.Template.View.Data.Abstract;
using ThreeBytes.Email.Template.View.Entities;
using ThreeBytes.Email.Template.View.Service.Abstract;

namespace ThreeBytes.Email.Template.View.Service.Concrete
{
    public class EmailTemplateViewTemplateService : HistoricKeyedGenericService<EmailTemplateViewTemplate>, IEmailTemplateViewTemplateService
    {
        protected new readonly IEmailTemplateViewTemplateRepository Repository;

        public EmailTemplateViewTemplateService(IEmailTemplateViewTemplateRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings) : base(repository, cache, cacheSettings)
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
