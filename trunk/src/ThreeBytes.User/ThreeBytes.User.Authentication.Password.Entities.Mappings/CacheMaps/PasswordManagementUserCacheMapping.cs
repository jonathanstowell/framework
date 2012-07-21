using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.User.Authentication.Password.Entities.Mappings.CacheMaps
{
    public class PasswordManagementUserCacheMapping : CacheItemConfigurationMap
    {
        public PasswordManagementUserCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(PasswordManagementUser))
                .SetAlias("PasswordManagementUser")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
