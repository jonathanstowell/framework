using System;
using FluentValidation;
using ThreeBytes.User.Authentication.UserList.Entities;
using ThreeBytes.User.Authentication.UserList.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserList.Validations.Concrete.Validators
{
    public class CreateAuthenticationUserListUserValidator : AbstractValidator<AuthenticationUserListUser>
    {
        private readonly IAuthenticationUserListUserService service;

        public CreateAuthenticationUserListUserValidator(IAuthenticationUserListUserService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;

            RuleFor(x => x.Username)
                    .NotEmpty().WithMessage(Resources.Resources.RequiredUsernameValidationMessage)
                    .Must((user, name) => UniqueUsername(user)).WithMessage(Resources.Resources.UniqueUsernameValidationMessage);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(Resources.Resources.RequiredEmailValidationMessage)
                .EmailAddress().WithMessage(Resources.Resources.ValidEmailValidationMessage)
                .Must((user, email) => UniqueEmail(user)).WithMessage(Resources.Resources.UnqiueEmailValidationMessage);

            RuleFor(x => x.ApplicationName)
                .NotEmpty().WithMessage(Resources.Resources.RequiredApplicationNameValidationMessage)
                .Length(1, 20).WithMessage(string.Format(Resources.Resources.LengthApplicationNameValidationMessage, 1, 20));
        }

        private bool UniqueUsername(AuthenticationUserListUser user)
        {
            return service.UniqueUsername(user.Username, user.ApplicationName);
        }

        private bool UniqueEmail(AuthenticationUserListUser user)
        {
            return service.UniqueEmail(user.Email, user.ApplicationName);
        }
    }
}
