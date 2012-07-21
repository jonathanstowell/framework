using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using ThreeBytes.User.Authentication.UserManagement.Entities;
using ThreeBytes.User.Authentication.UserManagement.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserManagement.Validations.Concrete.Validators
{
    public class CreateAuthenticationUserManagementUserValidator : AbstractValidator<AuthenticationUserManagementUser>
    {
        private readonly IAuthenticationUserManagementUserService service;

        public CreateAuthenticationUserManagementUserValidator(IAuthenticationUserManagementUserService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
 
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(Resources.Resources.RequiredUsernameValidationMessage)
                .Must((user, name) => UniqueUsername(user)).WithMessage(Resources.Resources.UniqueUsernameValidationMessage);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(
                    Resources.Resources.RequiredEmailValidationMessage)
                .EmailAddress().WithMessage(
                    Resources.Resources.ValidEmailValidationMessage)
                .Must((user, email) => UniqueEmail(user)).WithMessage(
                    Resources.Resources.UnqiueEmailValidationMessage);

            RuleFor(x => x.ApplicationName)
                .NotEmpty().WithMessage(
                    Resources.Resources.RequiredApplicationNameValidationMessage)
                .Length(1, 20).WithMessage(
                    string.Format(
                        Resources.Resources.LengthApplicationNameValidationMessage, 1,
                        20));

            RuleFor(x => x.Roles)
                .Must(MustNotHaveDuplicateRoles).WithMessage(
                    Resources.Resources.MustNotHaveDuplicateRolesValidationMessage);
        }

        private bool UniqueUsername(AuthenticationUserManagementUser user)
        {
            return service.UniqueUsername(user.Username, user.ApplicationName);
        }

        private bool UniqueEmail(AuthenticationUserManagementUser user)
        {
            return service.UniqueEmail(user.Email, user.ApplicationName);
        }

        private bool MustNotHaveDuplicateRoles(IList<AuthenticationUserManagementRole> roles)
        {
            return roles.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x).Count() == 0;
        }
    }
}
