using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Logging.Exceptions.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.Logging.Exceptions.List.Data.Concrete.Infrastructure
{
    public class ExceptionsListUnitOfWork : UnitOfWork, IExceptionListUnitOfWork
    {
        public ExceptionsListUnitOfWork(IExceptionListDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
