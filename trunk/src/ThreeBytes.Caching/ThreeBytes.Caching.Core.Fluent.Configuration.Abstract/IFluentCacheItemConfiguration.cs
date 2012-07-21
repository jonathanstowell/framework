using System;
using System.Collections.Generic;
using ThreeBytes.Core.Caching.Configuration.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Fluent.Configuration.Abstract
{
    public interface IFluentCacheItemConfiguration : ICacheItemConfiguration
    {
        IFluentCacheItemConfiguration ForType(Type type);
        IFluentCacheItemConfiguration SetAlias(string alias);
        IFluentCacheItemConfiguration CacheItemForSeconds(double seconds);
        IFluentCacheItemConfiguration CacheAllItemsForSeconds(double seconds);
        IFluentCacheItemConfiguration CacheMostRecentForSeconds(double seconds);
        IFluentCacheItemConfiguration CacheItemWhenPagedForSeconds(double seconds);
        IFluentCacheItemConfiguration CacheCurrentlyViewingUsersItemsForSeconds(double seconds);
        IFluentCacheItemConfiguration AddDependencies(IEnumerable<string> alias);
        IFluentCacheItemConfiguration AddDependency(string alias);
        IFluentCacheItemConfiguration RemoveDependencies(IEnumerable<string> alias);
        IFluentCacheItemConfiguration RemoveDependency(string alias);
    }
}
