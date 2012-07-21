using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Core.Twitter.Abstract;

namespace ThreeBytes.Core.Twitter.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<ITwitterClient>().ImplementedBy<TwitterClient>().LifeStyle.Singleton
            );
        }
    }
}
