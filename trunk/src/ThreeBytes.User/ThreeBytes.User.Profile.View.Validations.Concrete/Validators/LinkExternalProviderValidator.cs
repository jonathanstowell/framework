using FluentValidation;
using ThreeBytes.User.Profile.View.Entities;

namespace ThreeBytes.User.Profile.View.Validations.Concrete.Validators
{
    public class LinkExternalProviderValidator : AbstractValidator<UserProfileViewProfile>
    {
        public LinkExternalProviderValidator()
        {

        }
    }
}