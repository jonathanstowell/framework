using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.ProjectHollywood.Thespian.View.Data.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.View.Entities;
using ThreeBytes.ProjectHollywood.Thespian.View.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Service.Concrete
{
    public class ThespianViewThespianService : HistoricKeyedGenericService<ThespianViewThespian>, IThespianViewThespianService
    {
        public ThespianViewThespianService(IThespianViewThespianRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
        }
    }
}
