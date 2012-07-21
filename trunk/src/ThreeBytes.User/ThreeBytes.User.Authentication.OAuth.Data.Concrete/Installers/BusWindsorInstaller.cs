using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.OAuth.Data.Abstract;
using ThreeBytes.User.Authentication.OAuth.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.OAuth.Data.Concrete.Infrastructure;

namespace ThreeBytes.User.Authentication.OAuth.Data.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IOAuthDatabaseFactory>().ImplementedBy<OAuthDatabaseFactory>().LifeStyle.PerThread,
                    Component.For<IOAuthUnitOfWork>().ImplementedBy<OAuthUnitOfWork>().LifeStyle.PerThread,
                    Component.For<IOAuthUserRepository>().ImplementedBy<OAuthUserRepository>().LifeStyle.PerThread,
                    Component.For<IOAuthRoleRepository>().ImplementedBy<OAuthRoleRepository>().LifeStyle.PerThread,
                    Component.For<IProvideOAuthSessionFactoryInitialisation>().ImplementedBy<ProvideOAuthSessionFactoryInitialisation>().LifeStyle.PerThread
            );
        }
    }
}
