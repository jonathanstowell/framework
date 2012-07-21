using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.Team.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.Team.View.Data.Concrete.Infrastructure
{
    public class TeamViewUnitOfWork : UnitOfWork, ITeamViewUnitOfWork
    {
        public TeamViewUnitOfWork(ITeamViewDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
