using System;
using System.Collections.Generic;
using System.Linq;
using ThreeBytes.Caching.Core.Configuration.Entities.Conrete;
using ThreeBytes.Caching.Core.Fluent.Configuration.Abstract;
using ThreeBytes.Core.Caching.Configuration.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Fluent.Configuration.Concrete
{
    public class FluentCacheItemConfiguration : CacheItemConfiguration, IFluentCacheItemConfiguration
    {
        public IFluentCacheItemConfiguration ForType(Type type)
        {
            ConfigurationType = type;
            return this;
        }

        public IFluentCacheItemConfiguration SetAlias(string alias)
        {
            Alias = alias;
            return this;
        }

        public IFluentCacheItemConfiguration CacheItemForSeconds(double seconds)
        {
            CacheForSeconds = seconds;
            return this;
        }

        public IFluentCacheItemConfiguration CacheAllItemsForSeconds(double seconds)
        {
            CacheAllForSeconds = seconds;
            return this;
        }

        IFluentCacheItemConfiguration IFluentCacheItemConfiguration.CacheMostRecentForSeconds(double seconds)
        {
            CacheMostRecentForSeconds = seconds;
            return this;
        }

        public IFluentCacheItemConfiguration CacheItemWhenPagedForSeconds(double seconds)
        {
            CacheWhenPagedForSeconds = seconds;
            return this;
        }

        public IFluentCacheItemConfiguration CacheCurrentlyViewingUsersItemsForSeconds(double seconds)
        {
            CacheCurrentlyViewingUsersForSeconds = seconds;
            return this;
        }

        public IFluentCacheItemConfiguration AddDependencies(IEnumerable<string> alias)
        {
            foreach (var alia in alias)
            {
                AddDependency(alia);
            }

            return this;
        }

        public IFluentCacheItemConfiguration AddDependency(string alias)
        {
            CacheItemDependenciesAsAliases.Add(new CacheDependencyConfiguration { Alias = alias });
            return this;
        }

        public IFluentCacheItemConfiguration RemoveDependencies(IEnumerable<string> alias)
        {
            foreach (var alia in alias)
            {
                RemoveDependency(alia);
            }

            return this;
        }

        public IFluentCacheItemConfiguration RemoveDependency(string alias)
        {
            ICacheDependencyConfiguration remove = CacheItemDependenciesAsAliases.SingleOrDefault(x => x.Alias == alias);
            CacheItemDependenciesAsAliases.Remove(remove);
            return this;
        }
    }
}
