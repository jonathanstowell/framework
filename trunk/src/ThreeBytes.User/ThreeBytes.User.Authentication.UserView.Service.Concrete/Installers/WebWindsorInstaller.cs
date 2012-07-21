using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.UserView.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserView.Service.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IAuthenticationUserViewUserService>().ImplementedBy<AuthenticationUserViewUserService>().LifeStyle.PerWebRequest,
                Component.For<IAuthenticationUserViewRoleService>().ImplementedBy<AuthenticationUserViewRoleService>().LifeStyle.PerWebRequest
            );
        }
    }
}
