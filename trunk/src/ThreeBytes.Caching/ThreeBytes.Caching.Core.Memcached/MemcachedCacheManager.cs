using System;
using System.Collections.Generic;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using ThreeBytes.Caching.Core.Abstract;
using ThreeBytes.Caching.Core.Configuration.Abstract;
using ThreeBytes.Caching.Core.Configuration.Entities.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Memcached
{
    public class MemcachedCacheManager : ICacheManager
    {
        #region Constants
        public const int CacheExpiresInThreeHundredSeconds = 300;
        #endregion

        #region Member variables
        private readonly IMemcachedClient client;
        private readonly IProvideCacheSettings config;
        private bool disposed;
        #endregion

        #region Constructors
        public MemcachedCacheManager(IProvideCacheSettings config)
        {
            client = new MemcachedClient();
            this.config = config;
        }

        [CLSCompliant(false)]
        public MemcachedCacheManager(IMemcachedClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            this.client = client;
        }

        [CLSCompliant(false)]
        public MemcachedCacheManager(IMemcachedClientConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }

            client = new MemcachedClient(configuration);
        }
        #endregion

        #region Methods
        public void Add<T>(T cacheItem) where T : class, IBusinessObject<T>
        {
            if (cacheItem == null)
                throw new ArgumentNullException("cacheItem");

            ICacheItemConfiguration itemConfiguration = GetCacheItemConfiguration(typeof(T));
            client.Store(StoreMode.Add, itemConfiguration.GetKey(cacheItem), cacheItem, DateTime.UtcNow.AddSeconds(itemConfiguration.CacheForSeconds));
        }

        public void AddHistoric<T>(T cacheItem) where T : class, IHistoricBusinessObject<T>
        {
            if (cacheItem == null)
                throw new ArgumentNullException("cacheItem");

            ICacheItemConfiguration itemConfiguration = GetCacheItemConfiguration(typeof(T));
            client.Store(StoreMode.Add, itemConfiguration.GetHistoricKey(cacheItem), cacheItem, DateTime.UtcNow.AddSeconds(itemConfiguration.CacheForSeconds));
        }

        public void Add<T>(IList<T> cacheItem, string orderedBy = "NoOrder") where T : class
        {
            if (cacheItem == null)
                throw new ArgumentNullException("cacheItem");

            ICacheItemConfiguration itemConfiguration = GetCacheItemConfiguration(typeof(T));

            var allCache = client.Get(itemConfiguration.GetAllKey()) as IDictionary<string, IList<T>>;

            if (allCache == null)
            {
                allCache = new Dictionary<string, IList<T>>();
                allCache.Add(itemConfiguration.GetAllKey(orderedBy), cacheItem);
                client.Store(StoreMode.Add, itemConfiguration.GetAllKey(), allCache, DateTime.UtcNow.AddSeconds(itemConfiguration.CacheAllForSeconds));
            }
            else
            {
                if (!allCache.ContainsKey(itemConfiguration.GetAllKey(orderedBy)))
                {
                    allCache.Add(itemConfiguration.GetAllKey(orderedBy), cacheItem);
                }
                else
                {
                    allCache[itemConfiguration.GetAllKey(orderedBy)] = cacheItem;
                }

                client.Store(StoreMode.Replace, itemConfiguration.GetPagedKey(), allCache, DateTime.UtcNow.AddSeconds(itemConfiguration.CacheWhenPagedForSeconds));
            }

            client.Store(StoreMode.Add, itemConfiguration.GetAllKey(), cacheItem, DateTime.UtcNow.AddSeconds(itemConfiguration.CacheAllForSeconds));
        }

        public void Add<T>(IPagedResult<T> cacheItem, string orderedBy = "NoOrder") where T : class
        {
            if (cacheItem == null)
                throw new ArgumentNullException("cacheItem");

            ICacheItemConfiguration itemConfiguration = GetCacheItemConfiguration(typeof(T));

            var allCachedItems = client.Get(itemConfiguration.GetPagedKey()) as IDictionary<string, IDictionary<string, IDictionary<int, IPagedResult<T>>>>;

            if (allCachedItems == null)
            {
                allCachedItems = new Dictionary<string, IDictionary<string, IDictionary<int, IPagedResult<T>>>>();
                var pagedCacheItems = new Dictionary<string, IDictionary<int, IPagedResult<T>>>();
                var cachePage = new Dictionary<int, IPagedResult<T>> {{cacheItem.PageNumber, cacheItem}};
                pagedCacheItems.Add(itemConfiguration.GetPagedKey(cacheItem.OriginalRequestDateTime), cachePage);
                allCachedItems.Add(itemConfiguration.GetPagedKey(orderedBy), pagedCacheItems);
                client.Store(StoreMode.Add, itemConfiguration.GetPagedKey(), allCachedItems, DateTime.UtcNow.AddSeconds(itemConfiguration.CacheWhenPagedForSeconds));
            }
            else
            {
                if (!allCachedItems.ContainsKey(itemConfiguration.GetPagedKey(orderedBy)))
                {
                    var pagedCacheItems = new Dictionary<string, IDictionary<int, IPagedResult<T>>>();
                    var cachePage = new Dictionary<int, IPagedResult<T>> {{cacheItem.PageNumber, cacheItem}};
                    pagedCacheItems.Add(itemConfiguration.GetPagedKey(cacheItem.OriginalRequestDateTime), cachePage);
                    allCachedItems.Add(itemConfiguration.GetPagedKey(orderedBy), pagedCacheItems);
                }
                else
                {
                    var pagedCacheItems = allCachedItems[itemConfiguration.GetPagedKey(orderedBy)];

                    if(!pagedCacheItems.ContainsKey(itemConfiguration.GetPagedKey(cacheItem.OriginalRequestDateTime)))
                    {
                        var cachePage = new Dictionary<int, IPagedResult<T>> { { cacheItem.PageNumber, cacheItem } };
                        pagedCacheItems.Add(itemConfiguration.GetPagedKey(cacheItem.OriginalRequestDateTime), cachePage);
                        allCachedItems[itemConfiguration.GetPagedKey(orderedBy)] = pagedCacheItems;
                    }
                    else
                    {
                        var cachePage = new Dictionary<int, IPagedResult<T>> { { cacheItem.PageNumber, cacheItem } };
                        pagedCacheItems[itemConfiguration.GetPagedKey(cacheItem.OriginalRequestDateTime)] = cachePage;
                        allCachedItems[itemConfiguration.GetPagedKey(orderedBy)] = pagedCacheItems;
                    }
                }

                client.Store(StoreMode.Replace, itemConfiguration.GetPagedKey(), allCachedItems, DateTime.UtcNow.AddSeconds(itemConfiguration.CacheWhenPagedForSeconds));
            }
        }

        public void Add<T>(IMostRecentResult<T> cacheItem) where T : class
        {
            if (cacheItem == null)
                throw new ArgumentNullException("cacheItem");

            ICacheItemConfiguration itemConfiguration = GetCacheItemConfiguration(typeof(T));

            var mostRecentItems = client.Get(itemConfiguration.GetMostRecentKey()) as IDictionary<string, IMostRecentResult<T>>;

            if (mostRecentItems == null)
            {
                mostRecentItems = new Dictionary<string, IMostRecentResult<T>>();
                mostRecentItems.Add(itemConfiguration.GetMostRecentKey(cacheItem.RequestDateTime), cacheItem);
                client.Store(StoreMode.Add, itemConfiguration.GetMostRecentKey(), cacheItem, DateTime.UtcNow.AddSeconds(itemConfiguration.CacheMostRecentForSeconds));
            }
            else
            {
               mostRecentItems.Add(itemConfiguration.GetMostRecentKey(cacheItem.RequestDateTime), cacheItem);
               client.Store(StoreMode.Replace, itemConfiguration.GetMostRecentKey(cacheItem.RequestDateTime), cacheItem, DateTime.UtcNow.AddSeconds(itemConfiguration.CacheMostRecentForSeconds));
            }
        }

        public T Get<T>(Guid id) where T : class, IBusinessObject<T>
        {
            ICacheItemConfiguration itemConfiguration = GetCacheItemConfiguration(typeof(T));
            return client.Get(itemConfiguration.GetKey<T>(id)) as T;
        }

        public T GetHistoric<T>(Guid id) where T : class, IHistoricBusinessObject<T>
        {
            ICacheItemConfiguration itemConfiguration = GetCacheItemConfiguration(typeof(T));
            return client.Get(itemConfiguration.GetHistoricKey<T>(id)) as T;
        }

        public IList<T> Get<T>(string orderedBy = "NoOrder") where T : class
        {
            ICacheItemConfiguration itemConfiguration = GetCacheItemConfiguration(typeof(T));

            var cachedAllItem = client.Get(itemConfiguration.GetAllKey()) as IDictionary<string, IList<T>>;

            if (cachedAllItem == null)
                return null;

            if (!cachedAllItem.ContainsKey(itemConfiguration.GetAllKey(orderedBy)))
                return null;

            return cachedAllItem[itemConfiguration.GetAllKey(orderedBy)];
        }

        public IPagedResult<T> Get<T>(int page, DateTime? originalRequestDateTime, string orderedBy = "NoOrder") where T : class
        {
            ICacheItemConfiguration itemConfiguration = GetCacheItemConfiguration(typeof(T));

            var allPagedCacheItem = client.Get(itemConfiguration.GetPagedKey()) as IDictionary<string, IDictionary<string, IDictionary<int, IPagedResult<T>>>>;

            if (allPagedCacheItem == null)
                return null;

            if (!allPagedCacheItem.ContainsKey(itemConfiguration.GetPagedKey(orderedBy)))
                return null;

            IDictionary<string, IDictionary<int, IPagedResult<T>>> pagedCacheItem = allPagedCacheItem[itemConfiguration.GetPagedKey(orderedBy)];

            if (!pagedCacheItem.ContainsKey(itemConfiguration.GetPagedKey(originalRequestDateTime)))
                return null;

            IDictionary<int, IPagedResult<T>> cachedItem = pagedCacheItem[itemConfiguration.GetPagedKey(originalRequestDateTime)];

            if (!cachedItem.ContainsKey(page))
                return null;

            return cachedItem[page];
        }

        public IMostRecentResult<T> Get<T>(DateTime? originalRequestDateTime) where T : class
        {
            ICacheItemConfiguration itemConfiguration = GetCacheItemConfiguration(typeof(T));

            var mostRecentCachedItem = client.Get(itemConfiguration.GetMostRecentKey(originalRequestDateTime)) as IMostRecentResult<T>;

            if (mostRecentCachedItem == null)
                return null;

            return mostRecentCachedItem;
        }

        public T Fetch<T>(Guid id, Func<T> retrieveData) where T : class, IBusinessObject<T>
        {
            if (retrieveData == null)
            {
                throw new ArgumentNullException("retrieveData");
            }

            T item = Get<T>(id);

            return item ?? FetchAndCache(retrieveData);
        }

        public T FetchHistoric<T>(Guid id, Func<T> retrieveData) where T : class, IHistoricBusinessObject<T>
        {
            if (retrieveData == null)
            {
                throw new ArgumentNullException("retrieveData");
            }

            T item = GetHistoric<T>(id);

            return item ?? FetchAndCacheHistoric(retrieveData);
        }

        public IList<T> Fetch<T>(Func<IList<T>> retrieveData, string orderedBy = "NoOrder") where T : class
        {
            if (retrieveData == null)
            {
                throw new ArgumentNullException("retrieveData");
            }

            IList<T> item = Get<T>(orderedBy);

            return item ?? FetchAndCache(retrieveData, orderedBy);
        }

        public IPagedResult<T> Fetch<T>(int page, DateTime? originalRequestDateTime, Func<IPagedResult<T>> retrieveData, string orderedBy = "NoOrder") where T : class
        {
            if (retrieveData == null)
            {
                throw new ArgumentNullException("retrieveData");
            }

            IPagedResult<T> item = Get<T>(page, originalRequestDateTime, orderedBy);

            return item ?? FetchAndCache(retrieveData, orderedBy);
        }

        public IMostRecentResult<T> Fetch<T>(DateTime? originalRequestDateTime, Func<IMostRecentResult<T>> retrieveData) where T : class
        {
            if (retrieveData == null)
            {
                throw new ArgumentNullException("retrieveData");
            }

            IMostRecentResult<T> item = Get<T>(originalRequestDateTime);

            return item ?? FetchAndCache(retrieveData);
        }

        private T FetchAndCache<T>(Func<T> retrieveData) where T : class, IBusinessObject<T>
        {
            if (retrieveData == null)
            {
                throw new ArgumentNullException("retrieveData");
            }

            T itemToBeCached = retrieveData();

            if (itemToBeCached != null)
            {
                Add(itemToBeCached);
            }

            return itemToBeCached;
        }

        private T FetchAndCacheHistoric<T>(Func<T> retrieveData) where T : class, IHistoricBusinessObject<T>
        {
            if (retrieveData == null)
            {
                throw new ArgumentNullException("retrieveData");
            }

            T itemToBeCached = retrieveData();

            if (itemToBeCached != null)
            {
                AddHistoric(itemToBeCached);
            }

            return itemToBeCached;
        }

        private IList<T> FetchAndCache<T>(Func<IList<T>> retrieveData, string orderedBy = "NoOrder") where T : class
        {
            if (retrieveData == null)
            {
                throw new ArgumentNullException("retrieveData");
            }

            IList<T> itemToBeCached = retrieveData();

            if (itemToBeCached != null)
            {
                Add(itemToBeCached, orderedBy);
            }

            return itemToBeCached;
        }

        private IPagedResult<T> FetchAndCache<T>(Func<IPagedResult<T>> retrieveData, string orderedBy = "NoOrder") where T : class
        {
            if (retrieveData == null)
            {
                throw new ArgumentNullException("retrieveData");
            }

            IPagedResult<T> itemToBeCached = retrieveData();

            if (itemToBeCached != null)
            {
                Add(itemToBeCached, orderedBy);
            }

            return itemToBeCached;
        }

        private IMostRecentResult<T> FetchAndCache<T>(Func<IMostRecentResult<T>> retrieveData) where T : class
        {
            if (retrieveData == null)
            {
                throw new ArgumentNullException("retrieveData");
            }

            IMostRecentResult<T> itemToBeCached = retrieveData();

            if (itemToBeCached != null)
            {
                Add(itemToBeCached);
            }

            return itemToBeCached;
        }

        public void InvalidateCacheItem<T>(T item) where T : class, IBusinessObject<T>
        {
            ICacheItemConfiguration itemConfiguration = GetCacheItemConfiguration(typeof(T));

            client.Remove(itemConfiguration.GetKey(item));
            client.Remove(itemConfiguration.GetAllKey());
            client.Remove(itemConfiguration.GetPagedKey());
            client.Remove(itemConfiguration.GetMostRecentKey());

            foreach (var dependency in itemConfiguration.CacheItemDependenciesAsAliases)
            {
                InvalidateCacheItem(dependency, item.Id);
            }
        }

        public void InvalidateHistoricCacheItem<T>(T item) where T : class, IHistoricBusinessObject<T>
        {
            ICacheItemConfiguration itemConfiguration = GetCacheItemConfiguration(typeof(T));

            client.Remove(itemConfiguration.GetHistoricKey(item));
            client.Remove(itemConfiguration.GetAllKey());
            client.Remove(itemConfiguration.GetPagedKey());
            client.Remove(itemConfiguration.GetMostRecentKey());

            foreach (var dependency in itemConfiguration.CacheItemDependenciesAsAliases)
            {
                InvalidateCacheItem(dependency, item.Id);
            }
        }

        private void InvalidateCacheItem(string alias, Guid id)
        {
            ICacheItemConfiguration itemConfiguration = config.GetConfigurationForAlias(alias);

            client.Remove(string.Format("{0}.{1}", alias, id));
            client.Remove(itemConfiguration.GetAllKey());
            client.Remove(itemConfiguration.GetPagedKey());
            client.Remove(itemConfiguration.GetMostRecentKey());

            foreach (var dependency in itemConfiguration.CacheItemDependenciesAsAliases)
            {
                InvalidateCacheItem(dependency, id);
            }
        }

        private ICacheItemConfiguration GetCacheItemConfiguration(Type type)
        {
            ICacheItemConfiguration itemConfiguration = config.GetConfigurationFor(type);

            if (itemConfiguration == null)
                throw new InvalidOperationException(string.Format("No Cache Configuration Found For Type {0}", type.FullName));

            return itemConfiguration;
        }
        #endregion
    }
}