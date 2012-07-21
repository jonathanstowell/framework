using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Core.Facebook.Abstract;

namespace ThreeBytes.Core.Facebook.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IFacebookClient>().ImplementedBy<FacebookClient>().LifeStyle.Singleton
            );
        }
    }
}
