using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.UserView.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Authentication.UserView.Data.Concrete.Infrastructure
{
    public class AuthenticationUserViewUserUnitOfWork : UnitOfWork, IAuthenticationUserViewUserUnitOfWork
    {
        public AuthenticationUserViewUserUnitOfWork(IAuthenticationUserViewUserDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
