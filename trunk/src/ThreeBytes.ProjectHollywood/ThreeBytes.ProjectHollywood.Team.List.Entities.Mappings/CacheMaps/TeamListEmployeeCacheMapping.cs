using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.ProjectHollywood.Team.List.Entities.Mappings.CacheMaps
{
    public class TeamListEmployeeCacheMapping : CacheItemConfigurationMap
    {
        public TeamListEmployeeCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(TeamListEmployee))
                .SetAlias("TeamListEmployee")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
