using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.Thespian.View.Data.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.View.Data.Abstract.Infrastructure;
using ThreeBytes.ProjectHollywood.Thespian.View.Entities;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Data.Concrete
{
    public class ThespianViewThespianRepository : HistoricKeyedGenericRepository<ThespianViewThespian>, IThespianViewThespianRepository
    {
        public ThespianViewThespianRepository(IThespianViewDatabaseFactory databaseFactory, IThespianViewUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }
    }
}
