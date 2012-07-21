using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.Logging.Exceptions.List.Data.Abstract;
using ThreeBytes.Logging.Exceptions.List.Entities;
using ThreeBytes.Logging.Exceptions.List.Service.Abstract;

namespace ThreeBytes.Logging.Exceptions.List.Service.Concrete
{
    public class ExceptionListService : KeyedGenericService<ExceptionList>, IExceptionListService
    {
        public ExceptionListService(IExceptionListEmailMessageRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
        }
    }
}
