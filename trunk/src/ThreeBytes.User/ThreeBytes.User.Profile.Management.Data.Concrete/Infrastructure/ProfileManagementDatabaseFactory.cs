using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Profile.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Profile.Management.Data.Concrete.Infrastructure
{
    public class ProfileManagementDatabaseFactory : AbstractDatabaseFactoryBase, IProfileManagementDatabaseFactory
    {
        public ProfileManagementDatabaseFactory(IProvideProfileManagementSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
