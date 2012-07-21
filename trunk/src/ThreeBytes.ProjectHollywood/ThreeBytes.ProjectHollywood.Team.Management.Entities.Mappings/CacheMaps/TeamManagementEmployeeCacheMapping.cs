using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.ProjectHollywood.Team.Management.Entities.Mappings.CacheMaps
{
    public class TeamManagementEmployeeCacheMapping : CacheItemConfigurationMap
    {
        public TeamManagementEmployeeCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(TeamManagementEmployee))
                .SetAlias("TeamManagementEmployee")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
