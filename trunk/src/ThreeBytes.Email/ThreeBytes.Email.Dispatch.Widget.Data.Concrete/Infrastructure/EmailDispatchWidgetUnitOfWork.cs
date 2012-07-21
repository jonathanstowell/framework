using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Dispatch.Widget.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dispatch.Widget.Data.Concrete.Infrastructure
{
    public class EmailDispatchWidgetUnitOfWork : UnitOfWork, IEmailDispatchWidgetUnitOfWork
    {
        public EmailDispatchWidgetUnitOfWork(IEmailDispatchWidgetDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
