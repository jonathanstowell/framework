using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.UserView.Data.Abstract;
using ThreeBytes.User.Authentication.UserView.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.UserView.Data.Concrete.Infrastructure;

namespace ThreeBytes.User.Authentication.UserView.Data.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IAuthenticationUserViewUserDatabaseFactory>().ImplementedBy<AuthenticationUserViewUserDatabaseFactory>().LifeStyle.PerWebRequest,
                Component.For<IAuthenticationUserViewUserUnitOfWork>().ImplementedBy<AuthenticationUserViewUserUnitOfWork>().LifeStyle.PerWebRequest,
                Component.For<IAuthenticationUserViewUserRepository>().ImplementedBy<AuthenticationUserViewUserRepository>().LifeStyle.PerWebRequest,
                Component.For<IAuthenticationUserViewRoleRepository>().ImplementedBy<AuthenticationUserViewRoleRepository>().LifeStyle.PerWebRequest,
                Component.For<IProvideAuthenticationUserViewSessionFactoryInitialisation>().ImplementedBy<ProvideAuthenticationUserViewSessionFactoryInitialisation>().LifeStyle.PerWebRequest
            );
        }
    }
}
