using System.Collections.Generic;

namespace ThreeBytes.Caching.Core.Entities.Abstract
{
    public interface IPagedOrderedContainerCacheItem
    {
        IDictionary<string, IPagedCacheItem> Value { get; }
        void Add(string key, IPagedCacheItem item);
    }
}