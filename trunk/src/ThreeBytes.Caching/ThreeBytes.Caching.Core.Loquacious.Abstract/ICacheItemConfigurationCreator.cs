using System;
using ThreeBytes.Core.Caching.Configuration.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Loquacious.Abstract
{
    public interface ICacheItemConfigurationCreator
    {
        void ConfigurationType(Type type);
        void Alias(string alias);
        void CacheForSeconds(double seconds);
        void CacheAllForSeconds(double seconds);
        void CacheWhenPagedForSeconds(double seconds);
        void CacheMostRecentForSeconds(double seconds);
        void CacheCurrentlyViewingUsersForSeconds(double seconds);
        void Dependencies(Action<ICacheDependencyConfigurationCreator> action);
        ICacheItemConfiguration Configuration { get; }
    }
}
