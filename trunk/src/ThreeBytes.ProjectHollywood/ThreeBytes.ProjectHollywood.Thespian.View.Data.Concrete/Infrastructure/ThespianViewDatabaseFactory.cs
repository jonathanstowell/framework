using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.Thespian.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Data.Concrete.Infrastructure
{
    public class ThespianViewDatabaseFactory : AbstractDatabaseFactoryBase, IThespianViewDatabaseFactory
    {
        public ThespianViewDatabaseFactory(IProvideThespianViewSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
