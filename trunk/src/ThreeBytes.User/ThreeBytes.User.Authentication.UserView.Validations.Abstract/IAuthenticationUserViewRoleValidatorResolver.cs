using FluentValidation;
using ThreeBytes.User.Authentication.UserView.Entities;

namespace ThreeBytes.User.Authentication.UserView.Validations.Abstract
{
    public interface IAuthenticationUserViewRoleValidatorResolver
    {
        IValidator<AuthenticationUserViewRole> CreateValidator();
    }
}
