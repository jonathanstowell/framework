using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Logging.Exceptions.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.Logging.Exceptions.List.Data.Concrete.Infrastructure
{
    public class ExceptionListDatabaseFactory : AbstractDatabaseFactoryBase, IExceptionListDatabaseFactory
    {
        public ExceptionListDatabaseFactory(IProvideExceptionListSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
