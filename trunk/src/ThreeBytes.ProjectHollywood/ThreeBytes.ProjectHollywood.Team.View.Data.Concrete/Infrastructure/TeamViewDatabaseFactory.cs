using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.Team.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.Team.View.Data.Concrete.Infrastructure
{
    public class TeamViewDatabaseFactory : AbstractDatabaseFactoryBase, ITeamViewDatabaseFactory
    {
        public TeamViewDatabaseFactory(IProvideTeamViewSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
