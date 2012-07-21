using System.Collections.Generic;

namespace ThreeBytes.Caching.Core.Entities.Abstract
{
    public interface IPagedCacheItem
    {
        IDictionary<int, ICollectionCacheItem> Value { get; }
        void Add(int page, ICollectionCacheItem item);
    }
}