using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.Password.Data.Abstract;
using ThreeBytes.User.Authentication.Password.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.Password.Data.Concrete.Infrastructure;

namespace ThreeBytes.User.Authentication.Password.Data.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IPasswordManagementDatabaseFactory>().ImplementedBy<PasswordManagementDatabaseFactory>().LifeStyle.PerWebRequest,
                Component.For<IPasswordManagementUnitOfWork>().ImplementedBy<PasswordManagementUnitOfWork>().LifeStyle.PerWebRequest,
                Component.For<IPasswordManagementUserRepository>().ImplementedBy<PasswordManagementUserRepository>().LifeStyle.PerWebRequest,
                Component.For<IProvidePasswordManagementSessionFactoryInitialisation>().ImplementedBy<ProvidePasswordManagementSessionFactoryInitialisation>().LifeStyle.PerWebRequest
            );
        }
    }
}
