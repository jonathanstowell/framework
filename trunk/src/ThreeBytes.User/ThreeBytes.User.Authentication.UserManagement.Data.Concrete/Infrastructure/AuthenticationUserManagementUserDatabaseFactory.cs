using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.UserManagement.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Authentication.UserManagement.Data.Concrete.Infrastructure
{
    public class AuthenticationUserManagementUserDatabaseFactory : AbstractDatabaseFactoryBase, IAuthenticationUserManagementUserDatabaseFactory
    {
        public AuthenticationUserManagementUserDatabaseFactory(IProvideAuthenticationUserManagementSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
