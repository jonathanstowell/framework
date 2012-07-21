using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.Login.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Authentication.Login.Data.Concrete.Infrastructure
{
    public class LoginUserDatabaseFactory : AbstractDatabaseFactoryBase, ILoginUserDatabaseFactory
    {
        public LoginUserDatabaseFactory(IProvideLoginUserSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
