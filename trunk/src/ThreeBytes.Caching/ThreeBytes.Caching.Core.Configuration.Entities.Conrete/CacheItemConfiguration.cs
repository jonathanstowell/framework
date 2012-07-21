using System;
using System.Collections.Generic;
using ThreeBytes.Core.Caching.Configuration.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Configuration.Entities.Conrete
{
    public class CacheItemConfiguration : ICacheItemConfiguration
    {
        public const double DEFAULT_CACHE_FOR = 120;

        public Type ConfigurationType { get; set; }
        public string ConfigurationTypeAsString { get { return ConfigurationType.FullName; } }
        public string Alias { get; set; }

        private double cacheForSeconds;
        public double CacheForSeconds
        {
            get { return cacheForSeconds == 0 ? DEFAULT_CACHE_FOR : cacheForSeconds; }
            set { cacheForSeconds = value; }
        }

        private double cacheAllForSeconds;
        public double CacheAllForSeconds
        {
            get { return cacheAllForSeconds == 0 ? DEFAULT_CACHE_FOR : cacheAllForSeconds; }
            set { cacheAllForSeconds = value; }
        }

        private double cacheWhenPagedForSeconds;
        public double CacheWhenPagedForSeconds
        {
            get { return cacheWhenPagedForSeconds == 0 ? DEFAULT_CACHE_FOR : cacheWhenPagedForSeconds; }
            set { cacheWhenPagedForSeconds = value; }
        }

        private double cacheMostRecentForSeconds;
        public double CacheMostRecentForSeconds
        {
            get { return cacheMostRecentForSeconds == 0 ? DEFAULT_CACHE_FOR : cacheMostRecentForSeconds; }
            set { cacheMostRecentForSeconds = value; }
        }

        private double cacheCurrentlyViewingUsersForSeconds;
        public double CacheCurrentlyViewingUsersForSeconds
        {
            get { return cacheCurrentlyViewingUsersForSeconds == 0 ? DEFAULT_CACHE_FOR : cacheCurrentlyViewingUsersForSeconds; }
            set { cacheCurrentlyViewingUsersForSeconds = value; }
        }

        public ICollection<ICacheDependencyConfiguration> CacheItemDependenciesAsAliases { get; set; }

        public CacheItemConfiguration()
        {
            CacheItemDependenciesAsAliases = new HashSet<ICacheDependencyConfiguration>();
        }
    }
}
