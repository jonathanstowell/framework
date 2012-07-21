using ThreeBytes.Caching.Core.Fluent.Configuration.Concrete;

namespace ThreeBytes.ProjectHollywood.Team.View.Entities.Mappings.CacheMaps
{
    public class TeamViewEmployeeCacheMapping : CacheItemConfigurationMap
    {
        public TeamViewEmployeeCacheMapping()
        {
            CacheItemConfiguration
                .ForType(typeof(TeamViewEmployee))
                .SetAlias("TeamViewEmployee")
                .CacheItemForSeconds(300)
                .CacheAllItemsForSeconds(300)
                .CacheMostRecentForSeconds(300)
                .CacheItemWhenPagedForSeconds(300);

        }
    }
}
