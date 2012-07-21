using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.User.Authentication.Login.Entities.Mappings.CacheMaps
{
    public class LoginUserCacheMapping : CacheItemConfigurationMap
    {
        public LoginUserCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(LoginUser))
                .SetAlias("LoginUser")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
