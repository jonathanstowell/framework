using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.Registration.Data.Abstract;
using ThreeBytes.User.Authentication.Registration.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.Registration.Data.Concrete.Infrastructure;

namespace ThreeBytes.User.Authentication.Registration.Data.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                    Component.For<IRegistrationUserDatabaseFactory>().ImplementedBy<RegistrationUserDatabaseFactory>().LifeStyle.PerWebRequest,
                    Component.For<IRegistrationUserUnitOfWork>().ImplementedBy<RegistrationUserUnitOfWork>().LifeStyle.PerWebRequest,
                    Component.For<IRegistrationUserRepository>().ImplementedBy<RegistrationUserRepository>().LifeStyle.PerWebRequest,
                    Component.For<IExternalUserRepository>().ImplementedBy<ExternalUserRepository>().LifeStyle.PerWebRequest,
                    Component.For<IProvideRegistrationUserSessionFactoryInitialisation>().ImplementedBy<ProvideRegistrationUserSessionFactoryInitialisation>().LifeStyle.PerWebRequest
            );
        }
    }
}
