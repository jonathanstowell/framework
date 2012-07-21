using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Core.Upload.Configuration.Abstract;

namespace ThreeBytes.Core.Upload.Configuration.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(Component.For<IDiskFileStoreConfiguration>().ImplementedBy<DiskFileStoreConfiguration>().LifeStyle.Singleton);
        }
    }
}
