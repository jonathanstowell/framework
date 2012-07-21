using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.ProjectHollywood.Team.Management.Data.Abstract;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;
using ThreeBytes.ProjectHollywood.Team.Management.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.Team.Management.Service.Concrete
{
    public class TeamManagementEmployeeService : KeyedGenericService<TeamManagementEmployee>, ITeamManagementEmployeeService
    {
        protected new readonly ITeamManagementEmployeeRepository Repository;

        public TeamManagementEmployeeService(ITeamManagementEmployeeRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }
    }
}
