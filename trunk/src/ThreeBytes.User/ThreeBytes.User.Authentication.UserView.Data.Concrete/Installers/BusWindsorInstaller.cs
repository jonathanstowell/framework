using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.UserView.Data.Abstract;
using ThreeBytes.User.Authentication.UserView.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.UserView.Data.Concrete.Infrastructure;

namespace ThreeBytes.User.Authentication.UserView.Data.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IAuthenticationUserViewUserDatabaseFactory>().ImplementedBy<AuthenticationUserViewUserDatabaseFactory>().LifeStyle.PerThread,
                Component.For<IAuthenticationUserViewUserUnitOfWork>().ImplementedBy<AuthenticationUserViewUserUnitOfWork>().LifeStyle.PerThread,
                Component.For<IAuthenticationUserViewUserRepository>().ImplementedBy<AuthenticationUserViewUserRepository>().LifeStyle.PerThread,
                Component.For<IAuthenticationUserViewRoleRepository>().ImplementedBy<AuthenticationUserViewRoleRepository>().LifeStyle.PerThread,
                Component.For<IProvideAuthenticationUserViewSessionFactoryInitialisation>().ImplementedBy<ProvideAuthenticationUserViewSessionFactoryInitialisation>().LifeStyle.PerThread
            );
        }
    }
}
