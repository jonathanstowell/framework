using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.User.Authentication.Login.Entities.Mappings.CacheMaps
{
    public class LoginRoleCacheMapping : CacheItemConfigurationMap
    {
        public LoginRoleCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(LoginRole))
                .SetAlias("LoginRole")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
