using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.UserManagement.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Authentication.UserManagement.Data.Concrete.Infrastructure
{
    public class AuthenticationUserManagementUserUnitOfWork : UnitOfWork, IAuthenticationUserManagementUserUnitOfWork
    {
        public AuthenticationUserManagementUserUnitOfWork(IAuthenticationUserManagementUserDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
