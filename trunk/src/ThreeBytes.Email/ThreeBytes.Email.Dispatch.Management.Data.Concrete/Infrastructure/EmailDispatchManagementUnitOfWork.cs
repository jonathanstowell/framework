using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Dispatch.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dispatch.Management.Data.Concrete.Infrastructure
{
    public class EmailDispatchManagementUnitOfWork : UnitOfWork, IEmailDispatchManagementUnitOfWork
    {
        public EmailDispatchManagementUnitOfWork(IEmailDispatchManagementDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
