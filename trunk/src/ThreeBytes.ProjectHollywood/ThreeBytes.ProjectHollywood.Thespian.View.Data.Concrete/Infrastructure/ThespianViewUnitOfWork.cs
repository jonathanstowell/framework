using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.Thespian.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Data.Concrete.Infrastructure
{
    public class ThespianViewUnitOfWork : UnitOfWork, IThespianViewUnitOfWork
    {
        public ThespianViewUnitOfWork(IThespianViewDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
