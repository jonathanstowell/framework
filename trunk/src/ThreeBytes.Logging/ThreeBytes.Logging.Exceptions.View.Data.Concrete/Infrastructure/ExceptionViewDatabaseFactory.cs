using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Logging.Exceptions.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.Logging.Exceptions.View.Data.Concrete.Infrastructure
{
    public class ExceptionViewDatabaseFactory : AbstractDatabaseFactoryBase, IExceptionViewDatabaseFactory
    {
        public ExceptionViewDatabaseFactory(IProvideExceptionViewSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
