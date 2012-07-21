using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;
using ThreeBytes.SignalR.CurrentlyViewing.Entities.Abstract;

namespace ThreeBytes.SignalR.CurrentlyViewing.Entities.Mappings.CacheMaps
{
    public class CurrentlyViewingUserCacheMapping : CacheItemConfigurationMap
    {
        public CurrentlyViewingUserCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(ICurrentlyViewingUser))
                .SetAlias("CurrentlyViewingUser")
                .CacheCurrentlyViewingUsersItemsForSeconds(300);
        }
    }
}
