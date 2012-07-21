using System;
using FluentValidation;
using ThreeBytes.User.Authentication.Registration.Entities;
using ThreeBytes.User.Authentication.Registration.Service.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Registration.Validations.Concrete.Validators
{
    public class UpdateRegistrationUserEmailValidator : AbstractValidator<RegistrationUser>
    {
        private readonly IRegistrationUserService service;

        public UpdateRegistrationUserEmailValidator(IRegistrationUserService service, IProvideUserConfiguration provideUserConfiguration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (provideUserConfiguration == null)
                throw new ArgumentNullException("provideUserConfiguration");

            this.service = service;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(Resources.Resources.RequiredEmailValidationMessage)
                .EmailAddress().WithMessage(Resources.Resources.ValidEmailValidationMessage)
                .Must((user, email) => UniqueEmail(user)).WithMessage(Resources.Resources.UnqiueEmailValidationMessage);
        }

        private bool UniqueEmail(RegistrationUser user)
        {
            return service.UniqueEmail(user.Email, user.ApplicationName);
        }
    }
}