using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.Login.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Authentication.Login.Data.Concrete.Infrastructure
{
    public class LoginUserUnitOfWork : UnitOfWork, ILoginUserUnitOfWork
    {
        public LoginUserUnitOfWork(ILoginUserDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
