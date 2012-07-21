using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.OAuth.Service.Abstract;

namespace ThreeBytes.User.Authentication.OAuth.Service.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IOAuthUserService>().ImplementedBy<OAuthUserService>().LifeStyle.PerWebRequest,
                    Component.For<IOAuthRoleService>().ImplementedBy<OAuthRoleService>().LifeStyle.PerWebRequest
            );
        }
    }
}
