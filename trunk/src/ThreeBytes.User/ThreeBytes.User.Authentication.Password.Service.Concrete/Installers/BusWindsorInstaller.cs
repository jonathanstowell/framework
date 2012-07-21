using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.Password.Service.Abstract;

namespace ThreeBytes.User.Authentication.Password.Service.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IPasswordManagementUserService>().ImplementedBy<PasswordManagementUserService>().LifeStyle.PerThread);
        }
    }
}
