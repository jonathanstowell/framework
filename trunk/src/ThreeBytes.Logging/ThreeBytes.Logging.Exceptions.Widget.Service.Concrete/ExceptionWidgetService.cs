using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.Logging.Exceptions.Widget.Data.Abstract;
using ThreeBytes.Logging.Exceptions.Widget.Entities;
using ThreeBytes.Logging.Exceptions.Widget.Service.Abstract;

namespace ThreeBytes.Logging.Exceptions.Widget.Service.Concrete
{
    public class ExceptionWidgetService : KeyedGenericService<ExceptionWidget>, IExceptionWidgetService
    {
        protected new readonly IExceptionWidgetRepository Repository;

        public ExceptionWidgetService(IExceptionWidgetRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }
    }
}
