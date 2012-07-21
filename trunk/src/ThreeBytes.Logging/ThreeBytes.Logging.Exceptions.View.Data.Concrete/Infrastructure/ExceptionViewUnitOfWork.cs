using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Logging.Exceptions.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.Logging.Exceptions.View.Data.Concrete.Infrastructure
{
    public class ExceptionViewUnitOfWork : UnitOfWork, IExceptionViewUnitOfWork
    {
        public ExceptionViewUnitOfWork(IExceptionViewDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
