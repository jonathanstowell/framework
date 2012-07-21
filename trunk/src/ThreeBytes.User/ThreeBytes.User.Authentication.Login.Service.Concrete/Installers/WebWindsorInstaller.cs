using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.Login.Service.Abstract;

namespace ThreeBytes.User.Authentication.Login.Service.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<ILoginUserService>().ImplementedBy<LoginUserService>().LifeStyle.PerWebRequest,
                Component.For<ILoginRoleService>().ImplementedBy<LoginRoleService>().LifeStyle.PerWebRequest
            );
        }
    }
}
