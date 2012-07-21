using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.UserManagement.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserManagement.Service.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IAuthenticationUserManagementUserService>().ImplementedBy<AuthenticationUserManagementUserService>().LifeStyle.PerWebRequest,
                Component.For<IAuthenticationUserManagementRoleService>().ImplementedBy<AuthenticationUserManagementRoleService>().LifeStyle.PerWebRequest
            );
        }
    }
}
