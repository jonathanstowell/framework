using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Core.Facebook.Configuration.Abstract;

namespace ThreeBytes.Core.Facebook.Configuration.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IProvideFacebookConfiguration>().ImplementedBy<ProvideFacebookConfiguration>().LifeStyle.Singleton
            );
        }
    }
}
