using System;

namespace ThreeBytes.Caching.Core.Entities.Abstract
{
    public interface ICacheItem
    {
        DateTime Timestamp { get; }
        object Value { get; }
        object Version { get; }
    }
}
