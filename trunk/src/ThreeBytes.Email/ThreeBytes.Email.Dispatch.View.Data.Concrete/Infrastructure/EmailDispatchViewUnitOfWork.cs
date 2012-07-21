using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Dispatch.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dispatch.View.Data.Concrete.Infrastructure
{
    public class EmailDispatchViewUnitOfWork : UnitOfWork, IEmailDispatchViewUnitOfWork
    {
        public EmailDispatchViewUnitOfWork(IEmailDispatchViewDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
