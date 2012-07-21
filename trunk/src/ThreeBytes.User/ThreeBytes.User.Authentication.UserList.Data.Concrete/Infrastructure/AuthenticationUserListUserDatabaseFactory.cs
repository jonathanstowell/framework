using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.UserList.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Authentication.UserList.Data.Concrete.Infrastructure
{
    public class AuthenticationUserListUserDatabaseFactory : AbstractDatabaseFactoryBase, IAuthenticationUserListUserDatabaseFactory
    {
        public AuthenticationUserListUserDatabaseFactory(IProvideAuthenticationUserListSessionFactoryInitialisation provideAuthenticationSessionFactoryInitialisation)
            : base(provideAuthenticationSessionFactoryInitialisation)
        {
        }
    }
}
