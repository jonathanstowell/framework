using System;
using ThreeBytes.Caching.Core.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Entities.Concrete
{
    [Serializable]
    public class CollectionCacheItem : ICollectionCacheItem
    {
        private readonly object value;
        private readonly DateTime cacheUntil;

        public CollectionCacheItem(object value, DateTime cacheUntil)
        {
            this.value = value;
            this.cacheUntil = cacheUntil;
        }

        public object Value
        {
            get { return value; }
        }

        public DateTime CacheUntil
        {
            get { return cacheUntil; }
        }
    }
}
