using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.ProjectHollywood.Thespian.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Data.Concrete.Infrastructure
{
    public class ThespianManagementDatabaseFactory : AbstractDatabaseFactoryBase, IThespianManagementDatabaseFactory
    {
        public ThespianManagementDatabaseFactory(IProvideThespianManagementSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
