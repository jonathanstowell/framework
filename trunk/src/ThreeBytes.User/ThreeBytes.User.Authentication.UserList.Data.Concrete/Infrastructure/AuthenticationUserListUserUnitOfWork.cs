using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.UserList.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Authentication.UserList.Data.Concrete.Infrastructure
{
    public class AuthenticationUserListUserUnitOfWork : UnitOfWork, IAuthenticationUserListUserUnitOfWork
    {
        public AuthenticationUserListUserUnitOfWork(IAuthenticationUserListUserDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
