using System;
using FluentValidation;
using ThreeBytes.User.Authentication.UserList.Entities;
using ThreeBytes.User.Authentication.UserList.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserList.Validations.Concrete.Validators
{
    public class UpdateAuthenticationUserListUserEmailValidator : AbstractValidator<AuthenticationUserListUser>
    {
        private readonly IAuthenticationUserListUserService service;

        public UpdateAuthenticationUserListUserEmailValidator(IAuthenticationUserListUserService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(Resources.Resources.RequiredEmailValidationMessage)
                .EmailAddress().WithMessage(Resources.Resources.ValidEmailValidationMessage)
                .Must((user, email) => UniqueEmail(user)).WithMessage(Resources.Resources.UnqiueEmailValidationMessage);
        }

        private bool UniqueEmail(AuthenticationUserListUser user)
        {
            return service.UniqueEmail(user.Email, user.ApplicationName);
        }
    }
}