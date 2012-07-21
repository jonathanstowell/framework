using System;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using ThreeBytes.Core.Caching.Abstract;

namespace ThreeBytes.Caching.Core.Memcached
{
    public class MemcachedCache : ICache
    {
        #region Member variables
        private readonly IMemcachedClient client;
        #endregion

        #region Constructors
        public MemcachedCache()
        {
            client = new MemcachedClient();
        }

        public MemcachedCache(IMemcachedClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            this.client = client;
        }

        public MemcachedCache(IMemcachedClientConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }

            client = new MemcachedClient(configuration);
        }
        #endregion

        public object Get(string key)
        {
            return client.Get(key);
        }

        public bool Add(string key, object value, DateTime cacheUntil)
        {
            return client.Store(StoreMode.Add, key, value, cacheUntil);
        }

        public bool Add(string key, object value, TimeSpan cacheFor)
        {
            return client.Store(StoreMode.Add, key, value, cacheFor);
        }

        public bool Replace(string key, object value)
        {
            return client.Store(StoreMode.Replace, key, value);
        }

        public bool Replace(string key, object value, DateTime cacheUntil)
        {
            return client.Store(StoreMode.Replace, key, value, cacheUntil);
        }

        public bool Replace(string key, object value, TimeSpan cacheFor)
        {
            return client.Store(StoreMode.Replace, key, value, cacheFor);
        }

        public bool Set(string key, object value)
        {
            return client.Store(StoreMode.Set, key, value);
        }

        public bool Set(string key, object value, DateTime cacheUntil)
        {
            return client.Store(StoreMode.Set, key, value, cacheUntil);
        }

        public bool Set(string key, object value, TimeSpan cacheFor)
        {
            return client.Store(StoreMode.Set, key, value, cacheFor);
        }

        public bool Remove(string key)
        {
            return client.Remove(key);
        }

        public void Clear()
        {
            client.FlushAll();
        }

        public void Destroy()
        {
            client.Dispose();
        }
    }
}
