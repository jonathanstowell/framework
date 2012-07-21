using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Core.Upload.Abstract;

namespace ThreeBytes.Core.Upload.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(Component.For<IFileStore>().ImplementedBy<DiskFileStore>().LifeStyle.Singleton);
        }
    }
}
