using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.Registration.Data.Abstract;
using ThreeBytes.User.Authentication.Registration.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.Registration.Data.Concrete.Infrastructure;

namespace ThreeBytes.User.Authentication.Registration.Data.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IRegistrationUserDatabaseFactory>().ImplementedBy<RegistrationUserDatabaseFactory>().LifeStyle.PerThread,
                    Component.For<IRegistrationUserUnitOfWork>().ImplementedBy<RegistrationUserUnitOfWork>().LifeStyle.PerThread,
                    Component.For<IRegistrationUserRepository>().ImplementedBy<RegistrationUserRepository>().LifeStyle.PerThread,
                    Component.For<IExternalUserRepository>().ImplementedBy<ExternalUserRepository>().LifeStyle.PerThread,
                    Component.For<IProvideRegistrationUserSessionFactoryInitialisation>().ImplementedBy<ProvideRegistrationUserSessionFactoryInitialisation>().LifeStyle.PerThread
            );
        }
    }
}
