using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using ThreeBytes.User.Authentication.OAuth.Entities;

namespace ThreeBytes.User.Authentication.OAuth.Validations.Concrete.Validators
{
    public class LinkExternalProviderValidator : AbstractValidator<OAuthUser>
    {
        public LinkExternalProviderValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("OAuth User cannot be null.");

            RuleFor(x => x.ExternalAuthentications)
                .Must(MustNotHaveDuplicateExternalAuthentications).WithMessage(
                    Resources.Resources.MustNotHaveDuplicateRolesValidationMessage);
        }

        private bool MustNotHaveDuplicateExternalAuthentications(IList<ExternalAuthenticator> externalAuthenticators)
        {
            return externalAuthenticators.GroupBy(x => x.ExternalAuthenticationType).Where(x => x.Count() > 1).Select(x => x).Count() == 0;
        }
    }
}
