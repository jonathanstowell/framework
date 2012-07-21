using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.Team.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.Team.Management.Data.Concrete.Infrastructure
{
    public class TeamManagementDatabaseFactory : AbstractDatabaseFactoryBase, ITeamManagementDatabaseFactory
    {
        public TeamManagementDatabaseFactory(IProvideTeamManagementSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
