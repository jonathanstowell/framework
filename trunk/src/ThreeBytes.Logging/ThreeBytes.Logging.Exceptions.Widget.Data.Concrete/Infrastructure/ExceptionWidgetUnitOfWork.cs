using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Logging.Exceptions.Widget.Data.Abstract.Infrastructure;

namespace ThreeBytes.Logging.Exceptions.Widget.Data.Concrete.Infrastructure
{
    public class ExceptionWidgetUnitOfWork : UnitOfWork, IExceptionWidgetUnitOfWork
    {
        public ExceptionWidgetUnitOfWork(IExceptionWidgetDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
