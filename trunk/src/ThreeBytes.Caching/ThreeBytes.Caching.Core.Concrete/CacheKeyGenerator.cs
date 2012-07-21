using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Caching.Configuration.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Concrete
{
    public class CacheKeyGenerator : ICacheKeyGenerator
    {
        private readonly IProvideCacheSettings settings;

        public CacheKeyGenerator(IProvideCacheSettings settings)
        {
            this.settings = settings;
        }

        public string BusinessObjectCacheKey<T>(object identifier)
        {
            return BusinessObjectCacheKey(typeof(T), identifier);
        }

        public string BusinessObjectCacheKey(Type type, object identifier)
        {
            ICacheItemConfiguration config = settings.GetConfigurationFor(type);

            if (config == null)
                return string.Empty;

            string preKey = string.IsNullOrEmpty(config.Alias) ? type.FullName : config.Alias;

            return string.Format("{0}.{1}", preKey, identifier);
        }

        public string BusinessObjectCacheKeyViaAlias(string alias, object identifier)
        {
            ICacheItemConfiguration config = settings.GetConfigurationForAlias(alias);

            string preKey = string.IsNullOrEmpty(config.Alias) ? config.ConfigurationType.FullName : config.Alias;

            return string.Format("{0}.{1}", preKey, identifier);
        }

        public string CollectionPrimaryCacheKey<T>()
        {
            return CollectionPrimaryCacheKey(typeof(T));
        }

        public string CollectionPrimaryCacheKey(Type type)
        {
            ICacheItemConfiguration config = settings.GetConfigurationFor(type);

            if (config == null)
                return string.Empty;

            string preKey = string.IsNullOrEmpty(config.Alias) ? type.FullName : config.Alias;

            return string.Format("{0}.{1}", preKey, "All");
        }

        public string CollectionPrimaryCacheKeyViaAlias(string alias)
        {
            ICacheItemConfiguration config = settings.GetConfigurationForAlias(alias);

            if (config == null)
                return string.Empty;

            string preKey = string.IsNullOrEmpty(config.Alias) ? config.ConfigurationType.FullName : config.Alias;

            return string.Format("{0}.{1}", preKey, "All");
        }

        public string CollectionSecondaryCacheKey(string order, string sortedBy)
        {
            return string.Format("{0}.{1}", order, sortedBy);
        }

        public string PagedPrimaryCacheKey<T>()
        {
            return PagedPrimaryCacheKey(typeof(T));
        }

        public string PagedPrimaryCacheKey(Type type)
        {
            ICacheItemConfiguration config = settings.GetConfigurationFor(type);

            if (config == null)
                return string.Empty;

            string preKey = string.IsNullOrEmpty(config.Alias) ? type.FullName : config.Alias;

            return string.Format("{0}.{1}", preKey, "Paged");
        }

        public string PagedPrimaryCacheKeyViaAlias(string alias)
        {
            ICacheItemConfiguration config = settings.GetConfigurationForAlias(alias);

            if (config == null)
                return string.Empty;

            string preKey = string.IsNullOrEmpty(config.Alias) ? config.ConfigurationType.FullName : config.Alias;

            return string.Format("{0}.{1}", preKey, "Paged");
        }

        public string PagedSecondaryCacheKey(DateTime? dateTime)
        {
            DateTime nowOrThen = dateTime ?? DateTime.Now;
            return string.Format("{0}.{1}", nowOrThen.Hour, nowOrThen.Minute);
        }

        public string PagedTertiaryCacheKey(string orderedBy, string sortedBy)
        {
            return string.Format("{0}.{1}", orderedBy, sortedBy);
        }

        public string MostRecentPrimaryCacheKey<T>()
        {
            return MostRecentPrimaryCacheKey(typeof(T));
        }

        public string MostRecentPrimaryCacheKey(Type type)
        {
            ICacheItemConfiguration config = settings.GetConfigurationFor(type);

            if (config == null)
                return string.Empty;

            string preKey = string.IsNullOrEmpty(config.Alias) ? type.FullName : config.Alias;

            return string.Format("{0}.{1}", preKey, "MostRecent");
        }

        public string MostRecentPrimaryCacheKeyViaAlias(string alias)
        {
            ICacheItemConfiguration config = settings.GetConfigurationForAlias(alias);

            if (config == null)
                return string.Empty;

            string preKey = string.IsNullOrEmpty(config.Alias) ? config.ConfigurationType.FullName : config.Alias;

            return string.Format("{0}.{1}", preKey, "MostRecent");
        }

        public string MostRecentSecondaryCacheKey(DateTime dateTime)
        {
            return string.Format("{0}.{1}", dateTime.Hour, dateTime.Minute);
        }

        public string CurrentlyViewingUsersCacheKey(object id, Type forType)
        {
            return string.Format("{0}:{1}:{2}", "CurrentlyViewing", forType.FullName, id);
        }
    }
}