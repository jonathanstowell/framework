using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.Password.Data.Abstract;
using ThreeBytes.User.Authentication.Password.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.Password.Data.Concrete.Infrastructure;

namespace ThreeBytes.User.Authentication.Password.Data.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IPasswordManagementDatabaseFactory>().ImplementedBy<PasswordManagementDatabaseFactory>().LifeStyle.PerThread,
                Component.For<IPasswordManagementUnitOfWork>().ImplementedBy<PasswordManagementUnitOfWork>().LifeStyle.PerThread,
                Component.For<IPasswordManagementUserRepository>().ImplementedBy<PasswordManagementUserRepository>().LifeStyle.PerThread,
                Component.For<IProvidePasswordManagementSessionFactoryInitialisation>().ImplementedBy<ProvidePasswordManagementSessionFactoryInitialisation>().LifeStyle.PerThread
            );
        }
    }
}
