using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Core.Foursquare.Configuration.Abstract;

namespace ThreeBytes.Core.Foursquare.Configuration.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IProvideFoursquareConfiguration>().ImplementedBy<ProvideFoursquareConfiguration>().LifeStyle.Singleton
            );
        }
    }
}
