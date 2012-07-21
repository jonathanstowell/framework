using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.OAuth.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Authentication.OAuth.Data.Concrete.Infrastructure
{
    public class OAuthDatabaseFactory : AbstractDatabaseFactoryBase, IOAuthDatabaseFactory
    {
        public OAuthDatabaseFactory(IProvideOAuthSessionFactoryInitialisation provideSessionFactoryInitialisation)
            : base(provideSessionFactoryInitialisation)
        {
        }
    }
}
