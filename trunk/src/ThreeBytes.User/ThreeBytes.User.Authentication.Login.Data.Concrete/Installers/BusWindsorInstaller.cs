using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.Login.Data.Abstract;
using ThreeBytes.User.Authentication.Login.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.Login.Data.Concrete.Infrastructure;

namespace ThreeBytes.User.Authentication.Login.Data.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<ILoginUserDatabaseFactory>().ImplementedBy<LoginUserDatabaseFactory>().LifeStyle.PerThread,
                Component.For<ILoginUserUnitOfWork>().ImplementedBy<LoginUserUnitOfWork>().LifeStyle.PerThread,
                Component.For<ILoginUserRepository>().ImplementedBy<LoginUserRepository>().LifeStyle.PerThread,
                Component.For<ILoginRoleRepository>().ImplementedBy<LoginRoleRepository>().LifeStyle.PerThread,
                Component.For<IProvideLoginUserSessionFactoryInitialisation>().ImplementedBy<ProvideLoginUserSessionFactoryInitialisation>().LifeStyle.PerThread
            );    
        }
    }
}
