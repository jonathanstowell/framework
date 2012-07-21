using FluentValidation;
using ThreeBytes.User.Authentication.OAuth.Entities;

namespace ThreeBytes.User.Authentication.OAuth.Validations.Abstract
{
    public interface IOAuthRoleValidatorResolver
    {
        IValidator<OAuthRole> CreateValidator();
    }
}
