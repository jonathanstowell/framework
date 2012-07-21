using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.UserList.Data.Abstract;
using ThreeBytes.User.Authentication.UserList.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.UserList.Data.Concrete.Infrastructure;

namespace ThreeBytes.User.Authentication.UserList.Data.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IAuthenticationUserListUserDatabaseFactory>().ImplementedBy<AuthenticationUserListUserDatabaseFactory>().LifeStyle.PerWebRequest,
                Component.For<IAuthenticationUserListUserUnitOfWork>().ImplementedBy<AuthenticationUserListUserUnitOfWork>().LifeStyle.PerWebRequest,
                Component.For<IAuthenticationUserListUserRepository>().ImplementedBy<AuthenticationUserListUserRepository>().LifeStyle.PerWebRequest,
                Component.For<IProvideAuthenticationUserListSessionFactoryInitialisation>().ImplementedBy<ProvideAuthenticationUserListSessionFactoryInitialisation>().LifeStyle.PerWebRequest);
        }
    }
}
