using System;
using System.Collections.Generic;
using ThreeBytes.Caching.Core.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Entities.Concrete
{
    [Serializable]
    public class CollectionOrderedContainerCacheItem : ICollectionOrderedContainerCacheItem
    {
        private readonly IDictionary<string, ICollectionCacheItem> value;

        public CollectionOrderedContainerCacheItem()
        {
            value = new Dictionary<string, ICollectionCacheItem>();
        }

        public IDictionary<string, ICollectionCacheItem> Value
        {
            get { return value; }
        }

        public void Add(string key, ICollectionCacheItem item)
        {
            if (value.ContainsKey(key))
                value[key] = item;
            else
                value.Add(key, item);
        }
    }
}
