using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.UserManagement.Data.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.UserManagement.Data.Concrete.Infrastructure;

namespace ThreeBytes.User.Authentication.UserManagement.Data.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IAuthenticationUserManagementUserDatabaseFactory>().ImplementedBy<AuthenticationUserManagementUserDatabaseFactory>().LifeStyle.PerWebRequest,
                Component.For<IAuthenticationUserManagementUserUnitOfWork>().ImplementedBy<AuthenticationUserManagementUserUnitOfWork>().LifeStyle.PerWebRequest,
                Component.For<IAuthenticationUserManagementUserRepository>().ImplementedBy<AuthenticationUserManagementUserRepository>().LifeStyle.PerWebRequest,
                Component.For<IAuthenticationUserManagementRoleRepository>().ImplementedBy<AuthenticationUserManagementRoleRepository>().LifeStyle.PerWebRequest,
                Component.For<IProvideAuthenticationUserManagementSessionFactoryInitialisation>().ImplementedBy<ProvideAuthenticationUserManagementSessionFactoryInitialisation>().LifeStyle.PerWebRequest
            );
        }
    }
}
