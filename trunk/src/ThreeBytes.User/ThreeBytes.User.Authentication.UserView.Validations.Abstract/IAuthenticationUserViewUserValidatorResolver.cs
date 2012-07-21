using FluentValidation;
using ThreeBytes.User.Authentication.UserView.Entities;

namespace ThreeBytes.User.Authentication.UserView.Validations.Abstract
{
    public interface IAuthenticationUserViewUserValidatorResolver
    {
        IValidator<AuthenticationUserViewUser> CreateValidator();
        IValidator<AuthenticationUserViewUser> UnlockUserValidator();
        IValidator<AuthenticationUserViewUser> VerifyUserValidator();
        IValidator<AuthenticationUserViewUser> UpdateRolesValidator();
        IValidator<AuthenticationUserViewUser> LockAuthenticationUserViewUserOutValidator();
        IValidator<AuthenticationUserViewUser> UpdateEmailValidator();
    }
}
