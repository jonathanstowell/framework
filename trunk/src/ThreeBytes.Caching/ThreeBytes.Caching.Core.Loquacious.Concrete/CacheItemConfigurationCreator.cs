using System;
using ThreeBytes.Caching.Core.Configuration.Entities.Conrete;
using ThreeBytes.Caching.Core.Loquacious.Abstract;
using ThreeBytes.Core.Caching.Configuration.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Loquacious.Concrete
{
    public class CacheItemConfigurationCreator : ICacheItemConfigurationCreator
    {
        private readonly ICacheItemConfiguration configuration;

        public CacheItemConfigurationCreator()
        {
            configuration = new CacheItemConfiguration();
        }

        public void ConfigurationType(Type type)
        {
            configuration.ConfigurationType = type;
        }

        public void Alias(string alias)
        {
            configuration.Alias = alias;
        }

        public void CacheForSeconds(double seconds)
        {
            configuration.CacheForSeconds = seconds;
        }

        public void CacheAllForSeconds(double seconds)
        {
            configuration.CacheAllForSeconds = seconds;
        }

        public void CacheWhenPagedForSeconds(double seconds)
        {
            configuration.CacheWhenPagedForSeconds = seconds;
        }

        public void CacheMostRecentForSeconds(double seconds)
        {
            configuration.CacheMostRecentForSeconds = seconds;
        }

        public void CacheCurrentlyViewingUsersForSeconds(double seconds)
        {
            configuration.CacheCurrentlyViewingUsersForSeconds = seconds;
        }

        public void Dependencies(Action<ICacheDependencyConfigurationCreator> action)
        {
            ICacheDependencyConfigurationCreator creator = new CacheDependencyConfigurationCreator();
            action(creator);
            configuration.CacheItemDependenciesAsAliases.Add(creator.Configuration);
        }

        public ICacheItemConfiguration Configuration
        {
            get { return configuration; }
        }
    }
}
