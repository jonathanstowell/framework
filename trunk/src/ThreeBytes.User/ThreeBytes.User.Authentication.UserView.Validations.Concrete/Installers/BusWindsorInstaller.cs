using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.UserView.Validations.Abstract;
using ThreeBytes.User.Authentication.UserView.Validations.Concrete.Resolvers;

namespace ThreeBytes.User.Authentication.UserView.Validations.Concrete.Installers
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
               Component.For<IAuthenticationUserViewUserValidatorResolver>().ImplementedBy<AuthenticationUserViewUserValidatorResolver>().LifeStyle.Transient,
               Component.For<IAuthenticationUserViewRoleValidatorResolver>().ImplementedBy<AuthenticationUserViewRoleValidatorResolver>().LifeStyle.Transient
            );
        }
    }
}
