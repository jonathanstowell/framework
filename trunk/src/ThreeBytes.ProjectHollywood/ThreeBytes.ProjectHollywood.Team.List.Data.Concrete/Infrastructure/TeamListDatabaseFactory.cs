using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.Team.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.Team.List.Data.Concrete.Infrastructure
{
    public class TeamListDatabaseFactory : AbstractDatabaseFactoryBase, ITeamListDatabaseFactory
    {
        public TeamListDatabaseFactory(IProvideTeamListSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
