using ThreeBytes.Core.Data.nHibernate.Abstract;
using ThreeBytes.Core.Data.nHibernate.Concrete;

namespace ThreeBytes.Core.Tests.Infrastructure
{
    public class SQLiteInMemoryDatabaseFactory : AbstractDatabaseFactoryBase
    {
        public SQLiteInMemoryDatabaseFactory(IProvideSessionFactoryInitialisation provideSessionFactoryInitialisation) : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
