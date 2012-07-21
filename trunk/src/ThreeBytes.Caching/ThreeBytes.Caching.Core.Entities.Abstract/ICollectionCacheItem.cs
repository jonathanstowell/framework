using System;

namespace ThreeBytes.Caching.Core.Entities.Abstract
{
    public interface ICollectionCacheItem
    {
        object Value { get; }
        DateTime CacheUntil { get; }
    }
}