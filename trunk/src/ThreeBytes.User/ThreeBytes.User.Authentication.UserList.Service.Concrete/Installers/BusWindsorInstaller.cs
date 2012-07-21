using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.UserList.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserList.Service.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<IAuthenticationUserListUserService>().ImplementedBy<AuthenticationUserListUserService>().LifeStyle.PerThread);
        }
    }
}
