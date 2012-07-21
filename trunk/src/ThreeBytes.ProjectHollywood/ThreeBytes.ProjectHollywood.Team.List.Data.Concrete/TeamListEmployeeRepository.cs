using System.Collections.Generic;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.Team.List.Data.Abstract;
using ThreeBytes.ProjectHollywood.Team.List.Data.Abstract.Infrastructure;
using ThreeBytes.ProjectHollywood.Team.List.Entities;

namespace ThreeBytes.ProjectHollywood.Team.List.Data.Concrete
{
    public class TeamListEmployeeRepository : KeyedGenericRepository<TeamListEmployee>, ITeamListEmployeeRepository
    {
        public TeamListEmployeeRepository(ITeamListDatabaseFactory databaseFactory, ITeamListUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public override IList<TeamListEmployee> GetAll()
        {
            var entity = Session.QueryOver<TeamListEmployee>()
                .OrderBy(x => x.LastName).Asc
                .ThenBy(x => x.FirstName).Asc
                .List();
            
            return entity;
        }
    }
}
