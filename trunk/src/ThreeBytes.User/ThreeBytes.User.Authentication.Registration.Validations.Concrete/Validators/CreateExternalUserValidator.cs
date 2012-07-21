using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using ThreeBytes.User.Authentication.Registration.Entities;
using ThreeBytes.User.Authentication.Registration.Service.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Registration.Validations.Concrete.Validators
{
    public class CreateExternalUserValidator : AbstractValidator<ExternalUser>
    {
        private readonly IExternalUserService service;

        public CreateExternalUserValidator(IExternalUserService service, IProvideUserConfiguration provideUserConfiguration)
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

            RuleFor(x => x.ApplicationName)
                .NotEmpty().WithMessage(Resources.Resources.RequiredApplicationNameValidationMessage)
                .Length(1, 20).WithMessage(string.Format(Resources.Resources.LengthApplicationNameValidationMessage, 1, 20));

            RuleFor(x => x.ExternalAuthentications)
                .Must(MustNotHaveDuplicateExternalAuthentications).WithMessage(
                    Resources.Resources.MustNotHaveDuplicateRolesValidationMessage);
        }

        private bool UniqueUsername(ExternalUser user)
        {
            return service.UniqueUsername(user.Username, user.ApplicationName);
        }

        private bool MustNotHaveDuplicateExternalAuthentications(IList<ExternalAuthenticator> externalAuthenticators)
        {
            return externalAuthenticators.GroupBy(x => x.ExternalAuthenticationType).Where(x => x.Count() > 1).Select(x => x).Count() == 0;
        }
    }
}
