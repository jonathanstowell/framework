using System;
using ThreeBytes.Caching.Core.Loquacious.Abstract;
using ThreeBytes.Core.Caching.Configuration.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Loquacious.Concrete
{
    public abstract class ClassCacheMap : IClassCacheMap
    {
        private ICacheItemConfiguration cacheMapping;
        public ICacheItemConfiguration CacheMapping 
        { 
            get
            {
                return cacheMapping;
            }
            private set { cacheMapping = value; } 
        }

        protected void Map(Action<ICacheItemConfigurationCreator> action)
        {
            ICacheItemConfigurationCreator config = new CacheItemConfigurationCreator();
            action(config);
            CacheMapping = config.Configuration;
        }
    }
}
