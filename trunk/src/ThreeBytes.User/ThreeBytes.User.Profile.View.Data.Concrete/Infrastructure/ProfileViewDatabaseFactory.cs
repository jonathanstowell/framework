using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Profile.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Profile.View.Data.Concrete.Infrastructure
{
    public class ProfileViewDatabaseFactory : AbstractDatabaseFactoryBase, IProfileViewDatabaseFactory
    {
        public ProfileViewDatabaseFactory(IProvideProfileViewSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
