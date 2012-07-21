using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.Team.Management.Data.Abstract;
using ThreeBytes.ProjectHollywood.Team.Management.Data.Abstract.Infrastructure;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;

namespace ThreeBytes.ProjectHollywood.Team.Management.Data.Concrete
{
    public class TeamManagementEmployeeRepository : KeyedGenericRepository<TeamManagementEmployee>, ITeamManagementEmployeeRepository
    {
        public TeamManagementEmployeeRepository(ITeamManagementDatabaseFactory databaseFactory, ITeamManagementUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }
    }
}
