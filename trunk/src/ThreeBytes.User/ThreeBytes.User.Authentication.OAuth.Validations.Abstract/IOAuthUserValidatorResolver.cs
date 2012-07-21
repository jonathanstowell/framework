using FluentValidation;
using ThreeBytes.User.Authentication.OAuth.Entities;

namespace ThreeBytes.User.Authentication.OAuth.Validations.Abstract
{
    public interface IOAuthUserValidatorResolver
    {
        IValidator<OAuthUser> CreateValidator();
        IValidator<OAuthUser> UpdateRolesValidator();
        IValidator<OAuthUser> UpdateEmailValidator();
        IValidator<OAuthUser> LinkExternalProviderValidator();
    }
}
