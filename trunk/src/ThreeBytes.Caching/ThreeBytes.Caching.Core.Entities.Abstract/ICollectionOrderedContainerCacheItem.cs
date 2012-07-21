using System.Collections.Generic;

namespace ThreeBytes.Caching.Core.Entities.Abstract
{
    public interface ICollectionOrderedContainerCacheItem
    {
        IDictionary<string, ICollectionCacheItem> Value { get; }
        void Add(string key, ICollectionCacheItem item);
    }
}
