using System;
using FluentValidation;
using ThreeBytes.User.Authentication.UserList.Entities;
using ThreeBytes.User.Authentication.UserList.Validations.Abstract;
using ThreeBytes.User.Authentication.UserList.Validations.Concrete.Validators;

namespace ThreeBytes.User.Authentication.UserList.Validations.Concrete.Resolvers
{
    public class AuthenticationUserListUserValidatorResolver : IAuthenticationUserListUserValidatorResolver
    {
        private readonly Func<CreateAuthenticationUserListUserValidator> createLoginUserValidator;
        private readonly Func<UnlockAuthenticationUserListUserValidator> unlockUserLoginUserValidator;
        private readonly Func<VerifyUserAuthenticationUserListUserValidator> verifyUserLoginUserValidator;
        private readonly Func<LockAuthenticationUserListUserOutValidator> lockAuthenticationUserListUserOutValidator;
        private readonly Func<UpdateAuthenticationUserListUserEmailValidator> updateAuthenticationUserListUserEmailValidator;
        
        public AuthenticationUserListUserValidatorResolver(Func<CreateAuthenticationUserListUserValidator> createLoginUserValidator, Func<UnlockAuthenticationUserListUserValidator> unlockUserLoginUserValidator, Func<VerifyUserAuthenticationUserListUserValidator> verifyUserLoginUserValidator, Func<LockAuthenticationUserListUserOutValidator> lockAuthenticationUserListUserOutValidator, Func<UpdateAuthenticationUserListUserEmailValidator> updateAuthenticationUserListUserEmailValidator)
        {
            this.createLoginUserValidator = createLoginUserValidator;
            this.unlockUserLoginUserValidator = unlockUserLoginUserValidator;
            this.verifyUserLoginUserValidator = verifyUserLoginUserValidator;
            this.lockAuthenticationUserListUserOutValidator = lockAuthenticationUserListUserOutValidator;
            this.updateAuthenticationUserListUserEmailValidator = updateAuthenticationUserListUserEmailValidator;
        }

        public IValidator<AuthenticationUserListUser> CreateValidator()
        {
            return createLoginUserValidator();
        }

        public IValidator<AuthenticationUserListUser> UnlockUserValidator()
        {
            return unlockUserLoginUserValidator();
        }

        public IValidator<AuthenticationUserListUser> VerifyUserValidator()
        {
            return verifyUserLoginUserValidator();
        }

        public IValidator<AuthenticationUserListUser> LockAuthenticationUserListUserOutValidator()
        {
            return lockAuthenticationUserListUserOutValidator();
        }

        public IValidator<AuthenticationUserListUser> UpdateEmailValidator()
        {
            return updateAuthenticationUserListUserEmailValidator();
        }
    }
}
