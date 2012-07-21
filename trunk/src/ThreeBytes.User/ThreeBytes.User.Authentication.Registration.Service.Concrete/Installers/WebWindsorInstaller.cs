using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.Registration.Service.Abstract;

namespace ThreeBytes.User.Authentication.Registration.Service.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(Component.For<IRegistrationUserService>().ImplementedBy<RegistrationUserService>().LifeStyle.PerWebRequest,
                    Component.For<IExternalUserService>().ImplementedBy<ExternalUserService>().LifeStyle.PerWebRequest);
        }
    }
}
