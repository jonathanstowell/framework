using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.Login.Data.Abstract;
using ThreeBytes.User.Authentication.Login.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.Login.Data.Concrete.Infrastructure;

namespace ThreeBytes.User.Authentication.Login.Data.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                Component.For<ILoginUserDatabaseFactory>().ImplementedBy<LoginUserDatabaseFactory>().LifeStyle.PerWebRequest,
                Component.For<ILoginUserUnitOfWork>().ImplementedBy<LoginUserUnitOfWork>().LifeStyle.PerWebRequest,
                Component.For<ILoginUserRepository>().ImplementedBy<LoginUserRepository>().LifeStyle.PerWebRequest,
                Component.For<ILoginRoleRepository>().ImplementedBy<LoginRoleRepository>().LifeStyle.PerWebRequest,
                Component.For<IProvideLoginUserSessionFactoryInitialisation>().ImplementedBy<ProvideLoginUserSessionFactoryInitialisation>().LifeStyle.PerWebRequest
            );
        }
    }
}
