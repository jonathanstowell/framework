using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.Thespian.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Data.Concrete.Infrastructure
{
    public class ThespianListDatabaseFactory : AbstractDatabaseFactoryBase, IThespianListDatabaseFactory
    {
        public ThespianListDatabaseFactory(IProvideThespianListSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
