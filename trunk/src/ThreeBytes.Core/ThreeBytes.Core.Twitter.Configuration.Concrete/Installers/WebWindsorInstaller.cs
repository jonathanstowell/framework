using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Core.Twitter.Configuration.Abstract;

namespace ThreeBytes.Core.Twitter.Configuration.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IProvideTwitterConfiguration>().ImplementedBy<ProvideTwitterConfiguration>().LifeStyle.Singleton
            );
        }
    }
}
