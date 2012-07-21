using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.Thespian.Management.Data.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Management.Data.Abstract.Infrastructure;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Data.Concrete
{
    public class ThespianManagementThespianRepository : KeyedGenericRepository<ThespianManagementThespian>, IThespianManagementThespianRepository
    {
        public ThespianManagementThespianRepository(IThespianManagementDatabaseFactory databaseFactory, IThespianManagementUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }
    }
}
