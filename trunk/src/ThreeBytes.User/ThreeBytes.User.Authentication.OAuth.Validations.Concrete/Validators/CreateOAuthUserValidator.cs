using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Service.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.OAuth.Validations.Concrete.Validators
{
    public class CreateOAuthUserValidator : AbstractValidator<OAuthUser>
    {
        private readonly IOAuthUserService service;

        public CreateOAuthUserValidator(IOAuthUserService service, IProvideUserConfiguration provideUserConfiguration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (provideUserConfiguration == null)
                throw new ArgumentNullException("provideUserConfiguration");

            this.service = service;

            RuleFor(x => x).NotNull().WithName("General").WithMessage("OAuth User cannot be null.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(Resources.Resources.RequiredUsernameValidationMessage)
                .Length(provideUserConfiguration.MinimumUsernameLength, provideUserConfiguration.MaximumUsernameLength).WithMessage(string.Format(Resources.Resources.LengthUsernameValidationMessage, provideUserConfiguration.MinimumUsernameLength, provideUserConfiguration.MaximumUsernameLength))
                .Must((user, name) => UniqueUsername(user)).WithMessage(Resources.Resources.UniqueUsernameValidationMessage);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(Resources.Resources.RequiredEmailValidationMessage)
                .EmailAddress().WithMessage(Resources.Resources.ValidEmailValidationMessage)
                .Must((user, email) => UniqueEmail(user)).WithMessage(Resources.Resources.UnqiueEmailValidationMessage);

            RuleFor(x => x.ApplicationName)
                .NotEmpty().WithMessage(Resources.Resources.RequiredApplicationNameValidationMessage)
                .Length(1, 20).WithMessage(string.Format(Resources.Resources.LengthApplicationNameValidationMessage, 1, 20));

            RuleFor(x => x.Roles)
                .Must(MustNotHaveDuplicateRoles).WithMessage(
                    Resources.Resources.MustNotHaveDuplicateRolesValidationMessage);

            RuleFor(x => x.ExternalAuthentications)
                .Must(MustNotHaveDuplicateExternalAuthentications).WithMessage(
                    Resources.Resources.MustNotHaveDuplicateRolesValidationMessage);
        }

        private bool UniqueUsername(OAuthUser user)
        {
            return service.UniqueUsername(user.Username, user.ApplicationName);
        }

        private bool UniqueEmail(OAuthUser user)
        {
            return service.UniqueEmail(user.Email, user.ApplicationName);
        }

        private bool MustNotHaveDuplicateRoles(IList<OAuthRole> roles)
        {
            return roles.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x).Count() == 0;
        }

        private bool MustNotHaveDuplicateExternalAuthentications(IList<ExternalAuthenticator> externalAuthenticators)
        {
            return externalAuthenticators.GroupBy(x => x.ExternalAuthenticationType).Where(x => x.Count() > 1).Select(x => x).Count() == 0;
        }
    }
}
