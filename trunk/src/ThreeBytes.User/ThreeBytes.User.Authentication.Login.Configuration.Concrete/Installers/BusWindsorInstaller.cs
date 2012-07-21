using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.Login.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Login.Configuration.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IProvideLoginConfiguration>().ImplementedBy<ProvideLoginConfiguration>().LifeStyle.Singleton
            );
        }
    }
}
