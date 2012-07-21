using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;

namespace ThreeBytes.User.Authentication.Email.Validations.Installers
{
    public class BusWindsorInstaller : IBusWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                AllTypes
                .FromThisAssembly()
                .BasedOn(typeof(IValidator<>))
                .WithService
                .Base());
        }
    }
}
