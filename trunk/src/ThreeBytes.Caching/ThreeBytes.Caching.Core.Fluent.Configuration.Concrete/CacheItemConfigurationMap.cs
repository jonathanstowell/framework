using ThreeBytes.Caching.Core.Fluent.Configuration.Abstract;
using ThreeBytes.Core.Caching.Configuration.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Fluent.Configuration.Concrete
{
    public abstract class CacheItemConfigurationMap : IClassCacheMap
    {
        private IFluentCacheItemConfiguration cacheItemConfiguration;
        public IFluentCacheItemConfiguration CacheItemConfiguration
        {
            get { return cacheItemConfiguration ?? (cacheItemConfiguration = new FluentCacheItemConfiguration()); }
        }

        public ICacheItemConfiguration CacheMapping
        {
            get { return cacheItemConfiguration; }
        }
    }
}
