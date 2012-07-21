using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Core.Foursquare.Abstract;

namespace ThreeBytes.Core.Foursquare.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IFoursquareClient>().ImplementedBy<FoursquareClient>().LifeStyle.Singleton
            );
        }
    }
}
