using System;
using System.Collections.Generic;
using ThreeBytes.Core.Caching.Configuration.Entities.Abstract;

namespace ThreeBytes.Core.Caching.Configuration.Abstract
{
    public interface IProvideCacheSettings
    {
        IDictionary<string, ICacheItemConfiguration> CacheItemConfigurations { get; }
        IDictionary<string, ICacheItemConfiguration> CacheItemAliasConfigurations { get; }
        bool Enabled();
        ICacheItemConfiguration GetConfigurationFor(Type type);
        ICacheItemConfiguration GetConfigurationFor(string key);
        ICacheItemConfiguration GetConfigurationForAlias(string alias);
    }
}
