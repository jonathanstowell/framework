using FluentValidation;
using ThreeBytes.User.Profile.Management.Entities;

namespace ThreeBytes.User.Profile.Management.Validations.Abstract
{
    public interface IProfileManagementProfileValidatorResolver
    {
        IValidator<UserProfileManagementProfile> CreateValidator();
        IValidator<UserProfileManagementProfile> UpdateEmailAddressValidator();
        IValidator<UserProfileManagementProfile> UpdateNameValidator();
        IValidator<UserProfileManagementProfile> LinkExternalProviderValidator();
    }
}
