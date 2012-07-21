using System;
using System.Collections.Generic;
using System.Configuration;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Caching.Configuration.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Configuration.Concrete
{
    public class ProvideCacheSettings : IProvideCacheSettings
    {
        private readonly CacheConfigurationSection cacheConfigurationSection;

        private readonly IDictionary<string, ICacheItemConfiguration> cacheItemConfigurations;
        private readonly IDictionary<string, ICacheItemConfiguration> cacheItemAliasConfigurations;

        public const int DefaultCacheExpiresInThreeHundredSeconds = 300;

        public ProvideCacheSettings(IEnumerable<IClassCacheMap> configurations)
        {
            cacheConfigurationSection = (CacheConfigurationSection)ConfigurationManager.GetSection("threeBytesCache");
            cacheItemConfigurations = new Dictionary<string, ICacheItemConfiguration>();
            cacheItemAliasConfigurations = new Dictionary<string, ICacheItemConfiguration>();

            foreach (var configuration in configurations)
            {
                cacheItemConfigurations.Add(configuration.CacheMapping.ConfigurationTypeAsString, configuration.CacheMapping);
                cacheItemAliasConfigurations.Add(configuration.CacheMapping.Alias, configuration.CacheMapping);
            }
        }

        public IDictionary<string, ICacheItemConfiguration> CacheItemConfigurations
        {
            get { return cacheItemConfigurations; }
        }

        public IDictionary<string, ICacheItemConfiguration> CacheItemAliasConfigurations
        {
            get { return cacheItemAliasConfigurations; }
        }

        public bool Enabled()
        {
            return cacheConfigurationSection.Enabled;
        }

        public ICacheItemConfiguration GetConfigurationFor(Type type)
        {
            return GetConfigurationFor(type.FullName);
        }

        public ICacheItemConfiguration GetConfigurationFor(string key)
        {
            return cacheItemConfigurations.ContainsKey(key) ? cacheItemConfigurations[key] : null;
        }

        public ICacheItemConfiguration GetConfigurationForAlias(string alias)
        {
            return cacheItemAliasConfigurations.ContainsKey(alias) ? cacheItemConfigurations[alias] : null;
        }
    }
}
