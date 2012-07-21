using FluentValidation;
using ThreeBytes.User.Profile.View.Entities;

namespace ThreeBytes.User.Profile.View.Validations.Abstract
{
    public interface IProfileViewProfileValidatorResolver
    {
        IValidator<UserProfileViewProfile> CreateValidator();
        IValidator<UserProfileViewProfile> UpdateEmailAddressValidator();
        IValidator<UserProfileViewProfile> UpdateNameValidator();
        IValidator<UserProfileViewProfile> LinkExternalProviderValidator();
    }
}
