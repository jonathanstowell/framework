using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using ThreeBytes.User.Authentication.Login.Entities;
using ThreeBytes.User.Authentication.Login.Service.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Login.Validations.Concrete.Validators
{
    public class CreateLoginUserValidator : AbstractValidator<LoginUser>
    {
        private readonly ILoginUserService service;

        public CreateLoginUserValidator(ILoginUserService service, IProvideUserConfiguration provideUserConfiguration)
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

            RuleFor(x => x.ApplicationName)
                .NotEmpty().WithMessage(Resources.Resources.RequiredApplicationNameValidationMessage)
                .Length(1, 20).WithMessage(string.Format(Resources.Resources.LengthApplicationNameValidationMessage, 1, 20));

            RuleFor(x => x.Roles)
                .Must(MustNotHaveDuplicateRoles).WithMessage(
                    Resources.Resources.MustNotHaveDuplicateRolesValidationMessage);
        }

        private bool UniqueUsername(LoginUser user)
        {
            return service.UniqueUsername(user.Username, user.ApplicationName);
        }

        private bool UniqueEmail(LoginUser user)
        {
            return service.UniqueEmail(user.Email, user.ApplicationName);
        }

        private bool MustNotHaveDuplicateRoles(IList<LoginRole> roles)
        {
            return roles.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x).Count() == 0;
        }
    }
}
