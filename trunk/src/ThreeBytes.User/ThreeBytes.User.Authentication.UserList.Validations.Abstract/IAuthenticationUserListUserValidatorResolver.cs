using FluentValidation;
using ThreeBytes.User.Authentication.UserList.Entities;

namespace ThreeBytes.User.Authentication.UserList.Validations.Abstract
{
    public interface IAuthenticationUserListUserValidatorResolver
    {
        IValidator<AuthenticationUserListUser> CreateValidator();
        IValidator<AuthenticationUserListUser> UnlockUserValidator();
        IValidator<AuthenticationUserListUser> VerifyUserValidator();
        IValidator<AuthenticationUserListUser> LockAuthenticationUserListUserOutValidator();
        IValidator<AuthenticationUserListUser> UpdateEmailValidator();
    }
}
