using System;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Service.Concrete;
using ThreeBytes.ProjectHollywood.Team.View.Data.Abstract;
using ThreeBytes.ProjectHollywood.Team.View.Entities;
using ThreeBytes.ProjectHollywood.Team.View.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.Team.View.Service.Concrete
{
    public class TeamViewEmployeeService : HistoricKeyedGenericService<TeamViewEmployee>, ITeamViewEmployeeService
    {
        protected new readonly ITeamViewEmployeeRepository Repository;

        public TeamViewEmployeeService(ITeamViewEmployeeRepository repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
        }
    }
}
