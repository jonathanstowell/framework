using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Dispatch.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dispatch.List.Data.Concrete.Infrastructure
{
    public class EmailDispatchListUnitOfWork : UnitOfWork, IEmailDispatchListUnitOfWork
    {
        public EmailDispatchListUnitOfWork(IEmailDispatchListDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
