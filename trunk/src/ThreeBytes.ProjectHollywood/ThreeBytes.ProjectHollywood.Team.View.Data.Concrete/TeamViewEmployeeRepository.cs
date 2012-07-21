using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.Team.View.Data.Abstract;
using ThreeBytes.ProjectHollywood.Team.View.Data.Abstract.Infrastructure;
using ThreeBytes.ProjectHollywood.Team.View.Entities;

namespace ThreeBytes.ProjectHollywood.Team.View.Data.Concrete
{
    public class TeamViewEmployeeRepository : HistoricKeyedGenericRepository<TeamViewEmployee>, ITeamViewEmployeeRepository
    {
        public TeamViewEmployeeRepository(ITeamViewDatabaseFactory databaseFactory, ITeamViewUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }
    }
}
