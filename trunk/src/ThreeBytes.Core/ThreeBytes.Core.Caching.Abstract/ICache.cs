using System;

namespace ThreeBytes.Core.Caching.Abstract
{
    public interface ICache
    {
        object Get(string key);
        bool Add(string key, object value, DateTime cacheUntil);
        bool Add(string key, object value, TimeSpan cacheFor);
        bool Replace(string key, object value);
        bool Replace(string key, object value, DateTime cacheUntil);
        bool Replace(string key, object value, TimeSpan cacheFor);
        bool Set(string key, object value);
        bool Set(string key, object value, DateTime cacheUntil);
        bool Set(string key, object value, TimeSpan cacheFor);
        bool Remove(string key);
        void Clear();
        void Destroy();
    }
}
