using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.OAuth.Data.Abstract;
using ThreeBytes.User.Authentication.OAuth.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.OAuth.Data.Concrete.Infrastructure;

namespace ThreeBytes.User.Authentication.OAuth.Data.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IOAuthDatabaseFactory>().ImplementedBy<OAuthDatabaseFactory>().LifeStyle.PerWebRequest,
                    Component.For<IOAuthUnitOfWork>().ImplementedBy<OAuthUnitOfWork>().LifeStyle.PerWebRequest,
                    Component.For<IOAuthUserRepository>().ImplementedBy<OAuthUserRepository>().LifeStyle.PerWebRequest,
                    Component.For<IOAuthRoleRepository>().ImplementedBy<OAuthRoleRepository>().LifeStyle.PerWebRequest,
                    Component.For<IProvideOAuthSessionFactoryInitialisation>().ImplementedBy<ProvideOAuthSessionFactoryInitialisation>().LifeStyle.PerWebRequest
            );
        }
    }
}
