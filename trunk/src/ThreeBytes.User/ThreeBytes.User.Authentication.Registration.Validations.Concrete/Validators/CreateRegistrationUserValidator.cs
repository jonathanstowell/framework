using System;
using FluentValidation;
using ThreeBytes.User.Authentication.Registration.Entities;
using ThreeBytes.User.Authentication.Registration.Service.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Registration.Validations.Concrete.Validators
{
    public class CreateRegistrationUserValidator : AbstractValidator<RegistrationUser>
    {
        private readonly IRegistrationUserService service;

        public CreateRegistrationUserValidator(IRegistrationUserService service, IProvideUserConfiguration provideUserConfiguration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (provideUserConfiguration == null)
                throw new ArgumentNullException("provideUserConfiguration");

            this.service = service;

            RuleFor(x => x.Username)
                     .NotEmpty().WithMessage(Resources.Resources.RequiredUsernameValidationMessage)
                     .Length(provideUserConfiguration.MinimumUsernameLength, provideUserConfiguration.MaximumUsernameLength).WithMessage(string.Format(Resources.Resources.LengthUsernameValidationMessage, provideUserConfiguration.MinimumUsernameLength, provideUserConfiguration.MaximumUsernameLength))
                     .Must((user, name) => UniqueUsername(user)).WithMessage(Resources.Resources.UniqueUsernameValidationMessage);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(Resources.Resources.RequiredEmailValidationMessage)
                .EmailAddress().WithMessage(Resources.Resources.ValidEmailValidationMessage)
                .Must((user, email) => UniqueEmail(user)).WithMessage(Resources.Resources.UnqiueEmailValidationMessage);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(Resources.Resources.RequiredPasswordValidationMessage)
                .Length(provideUserConfiguration.MinimumPasswordLength, provideUserConfiguration.MaximumPasswordLength).WithMessage(string.Format(Resources.Resources.LengthPasswordValidationMessage, provideUserConfiguration.MinimumPasswordLength, provideUserConfiguration.MaximumPasswordLength));

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage(Resources.Resources.RequiredConfirmPasswordValidationMessage)
                .Length(provideUserConfiguration.MinimumPasswordLength, provideUserConfiguration.MaximumPasswordLength).WithMessage(string.Format(Resources.Resources.LengthConfirmPasswordValidationMessage, provideUserConfiguration.MinimumPasswordLength, provideUserConfiguration.MaximumPasswordLength))
                .Equal(user => user.Password).WithMessage(Resources.Resources.MatchConfirmPasswordAndPasswordValidationMessage);

            RuleFor(x => x.ApplicationName)
                .NotEmpty().WithMessage(Resources.Resources.RequiredApplicationNameValidationMessage)
                .Length(1, 20).WithMessage(string.Format(Resources.Resources.LengthApplicationNameValidationMessage, 1, 20));
        }

        private bool UniqueUsername(RegistrationUser user)
        {
            return service.UniqueUsername(user.Username, user.ApplicationName);
        }

        private bool UniqueEmail(RegistrationUser user)
        {
            return service.UniqueEmail(user.Email, user.ApplicationName);
        }
    }
}
