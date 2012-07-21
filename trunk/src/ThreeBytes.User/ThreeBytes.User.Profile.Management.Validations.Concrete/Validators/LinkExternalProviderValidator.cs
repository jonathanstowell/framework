using FluentValidation;
using ThreeBytes.User.Profile.Management.Entities;

namespace ThreeBytes.User.Profile.Management.Validations.Concrete.Validators
{
    public class LinkExternalProviderValidator : AbstractValidator<UserProfileManagementProfile>
    {
        public LinkExternalProviderValidator()
        {
        }
    }
}