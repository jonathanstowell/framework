using System;
using System.Collections.Generic;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.Email.Dispatch.Widget.Data.Abstract;
using ThreeBytes.Email.Dispatch.Widget.Entities;
using ThreeBytes.Email.Dispatch.Widget.Service.Abstract;

namespace ThreeBytes.Email.Dispatch.Widget.Service.Concrete
{
    public class EmailDispatchWidgetEmailMessageService : KeyedGenericService<EmailDispatchWidgetEmailMessage>, IEmailDispatchWidgetEmailMessageService
    {
        protected new readonly IEmailDispatchWidgetEmailMessageRepository Repository;

        public EmailDispatchWidgetEmailMessageService(IEmailDispatchWidgetEmailMessageRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings) : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }

        public IList<EmailDispatchWidgetEmailMessage> GetMostRecent(int take, string applicationName)
        {
            return Repository.GetMostRecent(take, applicationName);
        }
    }
}
