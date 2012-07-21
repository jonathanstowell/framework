using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.ProjectHollywood.Thespian.Management.Data.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities;
using ThreeBytes.ProjectHollywood.Thespian.Management.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Service.Concrete
{
    public class ThespianManagementThespianService : KeyedGenericService<ThespianManagementThespian>, IThespianManagementThespianService
    {
        public ThespianManagementThespianService(IThespianManagementThespianRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
        }
    }
}
