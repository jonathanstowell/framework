using System;
using System.Collections.Generic;
using ThreeBytes.Caching.Core.Entities.Abstract;
using ThreeBytes.Caching.Core.Entities.Concrete;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Caching.Configuration.Entities.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Concrete
{
    public class CacheManager : ICacheManager
    {
        #region Constants
        public const int CacheExpiresInThreeHundredSeconds = 300;
        public const string NoOrder = "NoOrder";
        public const string NoSort = "NoSort";
        #endregion

        private readonly ICache cache;
        private readonly IProvideCacheSettings settings;
        private readonly ICacheKeyGenerator cacheKeyGenerator;

        public CacheManager(ICache cache, ICacheKeyGenerator cacheKeyGenerator, IProvideCacheSettings settings)
        {
            this.cache = cache;
            this.cacheKeyGenerator = cacheKeyGenerator;
            this.settings = settings;
        }

        public void Add<T>(T cacheItem) where T : class, IBusinessObject<T>
        {
            string key = cacheKeyGenerator.BusinessObjectCacheKey<T>(cacheItem.Id);

            if (string.IsNullOrEmpty(key))
                return;

            ICacheItemConfiguration config = settings.GetConfigurationFor(typeof(T));

            Add(key, cacheItem, DateTime.UtcNow.AddSeconds(config.CacheForSeconds));
        }

        public void AddHistoric<T>(T cacheItem) where T : class, IHistoricBusinessObject<T>
        {
            string key = cacheKeyGenerator.BusinessObjectCacheKey<T>(cacheItem.Id);

            if (string.IsNullOrEmpty(key))
                return;

            ICacheItemConfiguration config = settings.GetConfigurationFor(typeof(T));

            Add(key, cacheItem, DateTime.UtcNow.AddSeconds(config.CacheForSeconds));
        }

        public void Add<T>(IList<T> cacheItem) where T : class
        {
            Add(cacheItem, NoOrder, NoSort);
        }

        public void AddOrdered<T>(IList<T> cacheItem, string orderedBy) where T : class
        {
            Add(cacheItem, orderedBy, NoSort);
        }

        public void AddSorted<T>(string sortedBy, IList<T> cacheItem) where T : class
        {
            Add(cacheItem, NoOrder, sortedBy);
        }

        public void Add<T>(IList<T> cacheItem, string orderedBy, string sortedBy) where T : class
        {
            string key = cacheKeyGenerator.CollectionPrimaryCacheKey<T>();

            if (string.IsNullOrEmpty(key))
                return;

            ICacheItemConfiguration config = settings.GetConfigurationFor(typeof(T));

            if (config == null)
                return;

            var all = cache.Get(key) as ICollectionOrderedContainerCacheItem;

            if (all == null)
            {
                ICollectionCacheItem cacheOrderedCollection = new CollectionCacheItem(cacheItem, DateTime.UtcNow.AddSeconds(config.CacheAllForSeconds));
                ICollectionOrderedContainerCacheItem cacheThis = new CollectionOrderedContainerCacheItem();
                cacheThis.Add(cacheKeyGenerator.CollectionSecondaryCacheKey(orderedBy, sortedBy), cacheOrderedCollection);
                Add(key, cacheThis, DateTime.UtcNow.AddSeconds(config.CacheAllForSeconds));
            }
            else
            {
                ICollectionCacheItem cacheOrderedCollection = new CollectionCacheItem(cacheItem, DateTime.UtcNow.AddSeconds(config.CacheAllForSeconds));
                all.Add(cacheKeyGenerator.CollectionSecondaryCacheKey(orderedBy, sortedBy), cacheOrderedCollection);

                cache.Replace(key, all, DateTime.UtcNow.AddSeconds(config.CacheAllForSeconds));
            }
        }

        public void Add<T>(IMostRecentResult<T> cacheItem) where T : class
        {
            string key = cacheKeyGenerator.MostRecentPrimaryCacheKey<T>();

            if (string.IsNullOrEmpty(key))
                return;

            ICacheItemConfiguration config = settings.GetConfigurationFor(typeof(T));

            if (config == null)
                return;

            var all = cache.Get(key) as ICollectionOrderedContainerCacheItem;

            if (all == null)
            {
                ICollectionCacheItem cacheOrderedCollection = new CollectionCacheItem(cacheItem, DateTime.UtcNow.AddSeconds(config.CacheAllForSeconds));
                ICollectionOrderedContainerCacheItem cacheThis = new CollectionOrderedContainerCacheItem();
                cacheThis.Add(cacheKeyGenerator.MostRecentSecondaryCacheKey(cacheItem.RequestDateTime), cacheOrderedCollection);
                Add(cacheKeyGenerator.MostRecentPrimaryCacheKey<T>(), cacheThis, DateTime.UtcNow.AddSeconds(config.CacheAllForSeconds));
            }
            else
            {
                ICollectionCacheItem cacheOrderedCollection = new CollectionCacheItem(cacheItem, DateTime.UtcNow.AddSeconds(config.CacheAllForSeconds));
                all.Add(cacheKeyGenerator.MostRecentSecondaryCacheKey(cacheItem.RequestDateTime), cacheOrderedCollection);

                cache.Replace(key, all, DateTime.UtcNow.AddSeconds(config.CacheAllForSeconds));
            }
        }

        public void AddCurrentlyViewingUsers<T>(object id, Type forType, IList<T> cacheItem) where T : class
        {
            ICacheItemConfiguration config = settings.GetConfigurationFor(typeof(T));

            if (config == null)
                return;

            string key = cacheKeyGenerator.CurrentlyViewingUsersCacheKey(id, forType);

            Add(key, cacheItem, DateTime.UtcNow.AddSeconds(config.CacheCurrentlyViewingUsersForSeconds));
        }

        public void Replace(string key, object cacheItem, DateTime until)
        {
            cache.Replace(key, cacheItem, until);
        }

        public void ReplaceCurrentlyViewingUsers<T>(object id, Type forType, IList<T> cacheItem) where T : class
        {
            ICacheItemConfiguration config = settings.GetConfigurationFor(typeof(T));

            if (config == null)
                return;

            string key = cacheKeyGenerator.CurrentlyViewingUsersCacheKey(id, forType);

            Replace(key, cacheItem, DateTime.UtcNow.AddSeconds(config.CacheCurrentlyViewingUsersForSeconds));
        }

        public void Add<T>(IPagedResult<T> cacheItem) where T : class
        {
            Add(cacheItem, NoOrder, NoSort);
        }

        public void AddOrdered<T>(IPagedResult<T> cacheItem, string orderedBy) where T : class
        {
            Add(cacheItem, orderedBy, NoSort);
        }

        public void AddSorted<T>(string sortedBy, IPagedResult<T> cacheItem) where T : class
        {
            Add(cacheItem, NoOrder, sortedBy);
        }

        public void Add<T>(IPagedResult<T> cacheItem, string orderedBy, string sortedBy) where T : class
        {
            string key = cacheKeyGenerator.PagedPrimaryCacheKey<T>();

            if (string.IsNullOrEmpty(key))
                return;

            ICacheItemConfiguration config = settings.GetConfigurationFor(typeof(T));

            if (config == null)
                return;

            var all = cache.Get(key) as IPagedContainerCacheItem;

            ICollectionCacheItem collectionCacheItem = new CollectionCacheItem(cacheItem, DateTime.UtcNow.AddSeconds(config.CacheWhenPagedForSeconds));

            if (all == null)
            {
                IPagedCacheItem pagedCacheItem = new PagedCacheItem();
                pagedCacheItem.Add(cacheItem.PageNumber, collectionCacheItem);

                IPagedOrderedContainerCacheItem pagedOrderedContainerCacheItem = new PagedOrderedContainerCacheItem();
                pagedOrderedContainerCacheItem.Add(cacheKeyGenerator.PagedSecondaryCacheKey(cacheItem.OriginalRequestDateTime), pagedCacheItem);

                IPagedContainerCacheItem cacheThis = new PagedContainerCacheItem();
                cacheThis.Add(cacheKeyGenerator.PagedTertiaryCacheKey(orderedBy, sortedBy), pagedOrderedContainerCacheItem);

                Add(cacheKeyGenerator.PagedPrimaryCacheKey<T>(), cacheThis, DateTime.UtcNow.AddSeconds(config.CacheWhenPagedForSeconds));
            }
            else
            {
                IPagedOrderedContainerCacheItem pagedOrderedContainerCacheItem;

                if (all.Value.TryGetValue(cacheKeyGenerator.PagedSecondaryCacheKey(cacheItem.OriginalRequestDateTime), out pagedOrderedContainerCacheItem))
                {
                    IPagedCacheItem pagedCacheItem;

                    if (pagedOrderedContainerCacheItem.Value.TryGetValue(cacheKeyGenerator.PagedTertiaryCacheKey(orderedBy, sortedBy), out pagedCacheItem))
                    {
                        pagedCacheItem.Add(cacheItem.PageNumber, collectionCacheItem);
                    }
                    else
                    {
                        pagedCacheItem = new PagedCacheItem();
                        pagedCacheItem.Add(cacheItem.PageNumber, collectionCacheItem);
                        pagedOrderedContainerCacheItem.Add(cacheKeyGenerator.PagedTertiaryCacheKey(orderedBy, sortedBy), pagedCacheItem);
                    }
                }
                else
                {
                    IPagedCacheItem pagedCacheItem = new PagedCacheItem();
                    pagedCacheItem.Add(cacheItem.PageNumber, collectionCacheItem);

                    pagedOrderedContainerCacheItem = new PagedOrderedContainerCacheItem();
                    pagedOrderedContainerCacheItem.Add(cacheKeyGenerator.PagedSecondaryCacheKey(cacheItem.OriginalRequestDateTime), pagedCacheItem);
                }

                all.Add(cacheKeyGenerator.PagedSecondaryCacheKey(cacheItem.OriginalRequestDateTime), pagedOrderedContainerCacheItem);

                cache.Replace(key, all, DateTime.UtcNow.AddSeconds(config.CacheAllForSeconds));
            }
        }

        public void Add(string key, object item, DateTime dateTime)
        {
            cache.Add(key, item, dateTime);
        }

        public T Get<T>(string key) where T : class
        {
            return cache.Get(key) as T;
        }

        public T Get<T>(Guid id) where T : class, IBusinessObject<T>
        {
            return cache.Get(cacheKeyGenerator.BusinessObjectCacheKey<T>(id)) as T;
        }

        public T GetHistoric<T>(Guid id) where T : class, IHistoricBusinessObject<T>
        {
            return cache.Get(cacheKeyGenerator.BusinessObjectCacheKey<T>(id)) as T;
        }

        public IList<T> Get<T>() where T : class
        {
            return Get<T>(NoOrder, NoSort);
        }

        public IList<T> GetOrdered<T>(string orderedBy) where T : class
        {
            return Get<T>(orderedBy, NoSort);
        }

        public IList<T> GetSorted<T>(string sortedBy) where T : class
        {
            return Get<T>(NoOrder, sortedBy);
        }

        public IList<T> Get<T>(string orderedBy, string sortedBy) where T : class
        {
            ICollectionOrderedContainerCacheItem all = cache.Get(cacheKeyGenerator.CollectionPrimaryCacheKey<T>()) as ICollectionOrderedContainerCacheItem;

            if (all == null)
                return null;

            ICollectionCacheItem cacheOrderedCollection;

            if (all.Value.TryGetValue(cacheKeyGenerator.CollectionSecondaryCacheKey(orderedBy, sortedBy), out cacheOrderedCollection))
            {
                if (cacheOrderedCollection.CacheUntil < DateTime.Now)
                    return null;

                return cacheOrderedCollection.Value as IList<T>;
            }

            return null;
        }

        public IList<T> GetCurrentlyViewingUsers<T>(object id, Type forType) where T : class
        {
            string key = cacheKeyGenerator.CurrentlyViewingUsersCacheKey(id, forType);
            return Get<IList<T>>(key);
        }

        public IPagedResult<T> Get<T>(int page, DateTime? originalRequestDateTime) where T : class
        {
            return Get<T>(page, originalRequestDateTime, NoOrder, NoSort);
        }

        public IPagedResult<T> GetOrdered<T>(int page, DateTime? originalRequestDateTime, string orderedBy) where T : class
        {
            return Get<T>(page, originalRequestDateTime, orderedBy, NoSort);
        }

        public IPagedResult<T> GetSorted<T>(int page, DateTime? originalRequestDateTime, string sortedBy) where T : class
        {
            return Get<T>(page, originalRequestDateTime, NoOrder, sortedBy);
        }

        public IPagedResult<T> Get<T>(int page, DateTime? originalRequestDateTime, string orderedBy, string sortedBy) where T : class
        {
            var all = cache.Get(cacheKeyGenerator.PagedPrimaryCacheKey<T>()) as IPagedContainerCacheItem;

            if (all == null)
                return null;

            IPagedOrderedContainerCacheItem pagedOrderedContainerCacheItem;

            if (all.Value.TryGetValue(cacheKeyGenerator.PagedSecondaryCacheKey(originalRequestDateTime), out pagedOrderedContainerCacheItem))
            {
                IPagedCacheItem pagedCacheItem;

                if (pagedOrderedContainerCacheItem.Value.TryGetValue(cacheKeyGenerator.PagedTertiaryCacheKey(orderedBy, sortedBy), out pagedCacheItem))
                {
                    ICollectionCacheItem cacheOrderedCollection;

                    if (pagedCacheItem.Value.TryGetValue(page, out cacheOrderedCollection))
                    {
                        if (cacheOrderedCollection.CacheUntil < DateTime.Now)
                            return null;

                        return cacheOrderedCollection.Value as IPagedResult<T>;
                    }
                }
            }

            return null;
        }

        public IMostRecentResult<T> Get<T>(DateTime requestDateTime) where T : class
        {
            ICollectionOrderedContainerCacheItem all = cache.Get(cacheKeyGenerator.MostRecentPrimaryCacheKey<T>()) as ICollectionOrderedContainerCacheItem;

            if (all == null)
                return null;

            ICollectionCacheItem cacheOrderedCollection;

            if (all.Value.TryGetValue(cacheKeyGenerator.MostRecentSecondaryCacheKey(requestDateTime), out cacheOrderedCollection))
            {
                if (cacheOrderedCollection.CacheUntil < DateTime.Now)
                    return null;

                return cacheOrderedCollection.Value as IMostRecentResult<T>;
            }

            return null;
        }

        public T Fetch<T>(Guid id, Func<T> retrieveData) where T : class, IBusinessObject<T>
        {
            if (retrieveData == null)
                throw new ArgumentNullException("retrieveData");

            T item = Get<T>(id);

            return item ?? FetchAndCache(retrieveData);
        }

        public T FetchHistoric<T>(Guid id, Func<T> retrieveData) where T : class, IHistoricBusinessObject<T>
        {
            if (retrieveData == null)
                throw new ArgumentNullException("retrieveData");

            T item = GetHistoric<T>(id);

            return item ?? FetchAndCacheHistoric(retrieveData);
        }

        public IList<T> Fetch<T>(Func<IList<T>> retrieveData) where T : class
        {
            return Fetch(retrieveData, NoOrder, NoSort);
        }

        public IList<T> FetchOrdered<T>(Func<IList<T>> retrieveData, string orderedBy) where T : class
        {
            return Fetch(retrieveData, orderedBy, NoSort);
        }

        public IList<T> FetchSorted<T>(Func<IList<T>> retrieveData, string sortedBy) where T : class
        {
            return Fetch(retrieveData, NoOrder, sortedBy);
        }

        public IList<T> Fetch<T>(Func<IList<T>> retrieveData, string orderedBy, string sortedBy) where T : class
        {
            if (retrieveData == null)
                throw new ArgumentNullException("retrieveData");

            IList<T> item = Get<T>(orderedBy, sortedBy);

            return item ?? FetchAndCache(retrieveData, orderedBy, sortedBy);
        }

        public IPagedResult<T> Fetch<T>(int page, DateTime? originalRequestDateTime, Func<IPagedResult<T>> retrieveData) where T : class
        {
            return Fetch(page, originalRequestDateTime, NoOrder, NoSort, retrieveData);
        }

        public IPagedResult<T> FetchOrdered<T>(int page, DateTime? originalRequestDateTime, string orderedBy, Func<IPagedResult<T>> retrieveData) where T : class
        {
            return Fetch(page, originalRequestDateTime, orderedBy, NoSort, retrieveData);
        }

        public IPagedResult<T> FetchSorted<T>(int page, DateTime? originalRequestDateTime, string sortedBy, Func<IPagedResult<T>> retrieveData) where T : class
        {
            return Fetch(page, originalRequestDateTime, NoOrder, sortedBy, retrieveData);
        }

        public IPagedResult<T> Fetch<T>(int page, DateTime? originalRequestDateTime, string orderedBy, string sortedBy, Func<IPagedResult<T>> retrieveData) where T : class
        {
            if (retrieveData == null)
                throw new ArgumentNullException("retrieveData");

            IPagedResult<T> item = Get<T>(page, originalRequestDateTime, orderedBy, sortedBy);

            return item ?? FetchAndCache(retrieveData, orderedBy, sortedBy);
        }

        public IMostRecentResult<T> Fetch<T>(DateTime originalRequestDateTime, Func<IMostRecentResult<T>> retrieveData) where T : class
        {
            if (retrieveData == null)
                throw new ArgumentNullException("retrieveData");

            IMostRecentResult<T> item = Get<T>(originalRequestDateTime);

            return item ?? FetchAndCache(retrieveData);
        }

        public void InvalidateCacheItem<T>(T item) where T : class, IBusinessObject<T>
        {
            ICacheItemConfiguration config = settings.GetConfigurationFor(typeof(T));

            if (config == null)
                return;

            cache.Remove(cacheKeyGenerator.BusinessObjectCacheKey<T>(item.Id));
            cache.Remove(cacheKeyGenerator.CollectionPrimaryCacheKey<T>());
            cache.Remove(cacheKeyGenerator.PagedPrimaryCacheKey<T>());
            cache.Remove(cacheKeyGenerator.MostRecentPrimaryCacheKey<T>());

            foreach (var dependency in config.CacheItemDependenciesAsAliases)
            {
                InvalidateCacheItem(dependency.Alias, item.Id);
            }
        }

        public void InvalidateHistoricCacheItem<T>(T item) where T : class, IHistoricBusinessObject<T>
        {
            ICacheItemConfiguration config = settings.GetConfigurationFor(typeof(T));

            if (config == null)
                return;

            cache.Remove(cacheKeyGenerator.BusinessObjectCacheKey<T>(item.Id));
            cache.Remove(cacheKeyGenerator.CollectionPrimaryCacheKey<T>());
            cache.Remove(cacheKeyGenerator.PagedPrimaryCacheKey<T>());
            cache.Remove(cacheKeyGenerator.MostRecentPrimaryCacheKey<T>());

            foreach (var dependency in config.CacheItemDependenciesAsAliases)
            {
                InvalidateCacheItem(dependency.Alias, item.Id);
            }
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

        private IList<T> FetchAndCache<T>(Func<IList<T>> retrieveData, string orderedBy, string sortedBy) where T : class
        {
            if (retrieveData == null)
            {
                throw new ArgumentNullException("retrieveData");
            }

            IList<T> itemToBeCached = retrieveData();

            if (itemToBeCached != null)
            {
                Add(itemToBeCached, orderedBy, sortedBy);
            }

            return itemToBeCached;
        }

        private IPagedResult<T> FetchAndCache<T>(Func<IPagedResult<T>> retrieveData, string orderedBy, string sortedBy) where T : class
        {
            if (retrieveData == null)
            {
                throw new ArgumentNullException("retrieveData");
            }

            IPagedResult<T> itemToBeCached = retrieveData();

            if (itemToBeCached != null)
            {
                Add(itemToBeCached, orderedBy, sortedBy);
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

        private void InvalidateCacheItem(string alias, Guid id)
        {
            ICacheItemConfiguration config = settings.GetConfigurationForAlias(alias);

            if (config == null)
                return;

            cache.Remove(cacheKeyGenerator.BusinessObjectCacheKeyViaAlias(alias, id));
            cache.Remove(cacheKeyGenerator.CollectionPrimaryCacheKeyViaAlias(alias));
            cache.Remove(cacheKeyGenerator.PagedPrimaryCacheKeyViaAlias(alias));
            cache.Remove(cacheKeyGenerator.MostRecentPrimaryCacheKeyViaAlias(alias));

            foreach (var dependency in config.CacheItemDependenciesAsAliases)
            {
                InvalidateCacheItem(dependency.Alias, id);
            }
        }
    }
}
