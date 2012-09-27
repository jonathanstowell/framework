using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.UserList.Validations.Abstract;
using ThreeBytes.User.Authentication.UserList.Validations.Concrete.Resolvers;

namespace ThreeBytes.User.Authentication.UserList.Validations.Concrete.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
               AllTypes
                   .FromThisAssembly()
                   .BasedOn(typeof(IValidator<>))
                   .LifestyleTransient(),
               Component.For<IAuthenticationUserListUserValidatorResolver>().ImplementedBy<AuthenticationUserListUserValidatorResolver>().LifeStyle.Transient);
        }
    }
}
