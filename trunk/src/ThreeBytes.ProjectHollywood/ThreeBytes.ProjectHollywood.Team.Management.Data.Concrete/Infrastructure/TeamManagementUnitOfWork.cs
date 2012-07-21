using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.Team.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.Team.Management.Data.Concrete.Infrastructure
{
    public class TeamManagementUnitOfWork : UnitOfWork, ITeamManagementUnitOfWork
    {
        public TeamManagementUnitOfWork(ITeamManagementDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
