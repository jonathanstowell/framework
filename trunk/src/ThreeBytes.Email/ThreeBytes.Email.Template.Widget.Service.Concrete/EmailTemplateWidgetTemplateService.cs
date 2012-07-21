using System;
using System.Collections.Generic;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.Email.Template.Widget.Data.Abstract;
using ThreeBytes.Email.Template.Widget.Entities;
using ThreeBytes.Email.Template.Widget.Service.Abstract;

namespace ThreeBytes.Email.Template.Widget.Service.Concrete
{
    public class EmailTemplateWidgetTemplateService : KeyedGenericService<EmailTemplateWidgetTemplate>, IEmailTemplateWidgetTemplateService
    {
        protected new readonly IEmailTemplateWidgetTemplateRepository Repository;

        public EmailTemplateWidgetTemplateService(IEmailTemplateWidgetTemplateRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings) : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public IList<EmailTemplateWidgetTemplate> GetMostRecent(int take, string applicationName)
        {
            return Repository.GetMostRecent(take, applicationName);
        }

        public bool UniqueTemplate(string name, string applicationName)
        {
            return Repository.UniqueTemplate(name, applicationName);
        }
    }
}
