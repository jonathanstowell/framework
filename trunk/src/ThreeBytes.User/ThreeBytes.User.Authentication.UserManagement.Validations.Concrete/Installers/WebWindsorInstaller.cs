using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.User.Authentication.UserManagement.Validations.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Validations.Concrete.Resolvers;

namespace ThreeBytes.User.Authentication.UserManagement.Validations.Concrete.Installers
{
    public class WebWindsorInstaller : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
               AllTypes
                   .FromThisAssembly()
                   .BasedOn(typeof(IValidator<>))
                   .LifestyleTransient(),
               Component.For<IAuthenticationUserManagementUserValidatorResolver>().ImplementedBy<AuthenticationUserManagementUserValidatorResolver>().LifeStyle.Transient,
               Component.For<IAuthenticationUserManagementRoleValidatorResolver>().ImplementedBy<AuthenticationUserManagementRoleValidatorResolver>().LifeStyle.Transient
            );
        }
    }
}
