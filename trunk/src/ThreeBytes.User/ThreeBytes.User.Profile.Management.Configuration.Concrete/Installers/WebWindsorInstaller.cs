using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Profile.Management.Configuration.Abstract;

namespace ThreeBytes.User.Profile.Management.Configuration.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
               Component.For<IProvideProfileManagementFoursquareConfiguration>().ImplementedBy<ProvideProfileManagementFoursquareConfiguration>().LifeStyle.Singleton
           );
        }
    }
}
