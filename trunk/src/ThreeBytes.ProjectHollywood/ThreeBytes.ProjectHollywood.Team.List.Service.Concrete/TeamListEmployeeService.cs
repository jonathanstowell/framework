using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.ProjectHollywood.Team.List.Data.Abstract;
using ThreeBytes.ProjectHollywood.Team.List.Entities;
using ThreeBytes.ProjectHollywood.Team.List.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.Team.List.Service.Concrete
{
    public class TeamListEmployeeService : KeyedGenericService<TeamListEmployee>, ITeamListEmployeeService
    {
        protected new readonly ITeamListEmployeeRepository Repository;

        public TeamListEmployeeService(ITeamListEmployeeRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }
    }
}
