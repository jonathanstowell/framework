using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.Logging.Exceptions.View.Data.Abstract;
using ThreeBytes.Logging.Exceptions.View.Entities;
using ThreeBytes.Logging.Exceptions.View.Service.Abstract;

namespace ThreeBytes.Logging.Exceptions.View.Service.Concrete
{
    public class ExceptionViewService : KeyedGenericService<ExceptionView>, IExceptionViewService
    {
        public ExceptionViewService(IExceptionViewRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
        }
    }
}
