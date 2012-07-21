using System;
using System.Collections.Generic;

namespace ThreeBytes.Core.Caching.Configuration.Entities.Abstract
{
    public interface ICacheItemConfiguration
    {
        Type ConfigurationType { get; set; }
        string ConfigurationTypeAsString { get; }

        string Alias { get; set; }
        double CacheForSeconds { get; set; }
        double CacheAllForSeconds { get; set; }
        double CacheWhenPagedForSeconds { get; set; }
        double CacheMostRecentForSeconds { get; set; }
        double CacheCurrentlyViewingUsersForSeconds { get; set; }
        ICollection<ICacheDependencyConfiguration> CacheItemDependenciesAsAliases { get; set; }
    }
}
