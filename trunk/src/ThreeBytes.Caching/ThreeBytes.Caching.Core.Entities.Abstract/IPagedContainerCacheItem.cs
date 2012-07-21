using System.Collections.Generic;

namespace ThreeBytes.Caching.Core.Entities.Abstract
{
    public interface IPagedContainerCacheItem
    {
        IDictionary<string, IPagedOrderedContainerCacheItem> Value { get; }
        void Add(string key, IPagedOrderedContainerCacheItem item);
    }
}
