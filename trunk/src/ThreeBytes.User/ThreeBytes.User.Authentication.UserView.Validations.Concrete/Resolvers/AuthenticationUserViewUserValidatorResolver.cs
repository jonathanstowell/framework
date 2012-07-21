using System;
using FluentValidation;
using ThreeBytes.User.Authentication.UserView.Entities;
using ThreeBytes.User.Authentication.UserView.Validations.Abstract;
using ThreeBytes.User.Authentication.UserView.Validations.Concrete.Validators;

namespace ThreeBytes.User.Authentication.UserView.Validations.Concrete.Resolvers
{
    public class AuthenticationUserViewUserValidatorResolver : IAuthenticationUserViewUserValidatorResolver
    {
        private readonly Func<CreateAuthenticationUserViewUserValidator> createUserViewUserValidator;
        private readonly Func<UnlockAuthenticationUserViewUserValidator> unlockUserViewUserValidator;
        private readonly Func<VerifyAuthenticationUserViewUserValidator> verifyUserViewUserValidator;
        private readonly Func<UpdateRolesAuthenticationUserViewUserValidator> updateRolesAuthenticationUserViewUserValidator;
        private readonly Func<LockAuthenticationUserViewUserOutValidator> lockAuthenticationUserViewUserOutValidator;
        private readonly Func<UpdateAuthenticationUserViewUserEmailValidator> updateAuthenticationUserViewUserEmailValidator;

        public AuthenticationUserViewUserValidatorResolver(Func<CreateAuthenticationUserViewUserValidator> createUserViewUserValidator, Func<UnlockAuthenticationUserViewUserValidator> unlockUserViewUserValidator, Func<VerifyAuthenticationUserViewUserValidator> verifyUserViewUserValidator, Func<UpdateRolesAuthenticationUserViewUserValidator> updateRolesAuthenticationUserViewUserValidator, Func<LockAuthenticationUserViewUserOutValidator> lockAuthenticationUserViewUserOutValidator, Func<UpdateAuthenticationUserViewUserEmailValidator> updateAuthenticationUserViewUserEmailValidator)
        {
            this.createUserViewUserValidator = createUserViewUserValidator;
            this.unlockUserViewUserValidator = unlockUserViewUserValidator;
            this.verifyUserViewUserValidator = verifyUserViewUserValidator;
            this.updateRolesAuthenticationUserViewUserValidator = updateRolesAuthenticationUserViewUserValidator;
            this.lockAuthenticationUserViewUserOutValidator = lockAuthenticationUserViewUserOutValidator;
            this.updateAuthenticationUserViewUserEmailValidator = updateAuthenticationUserViewUserEmailValidator;
        }

        public IValidator<AuthenticationUserViewUser> CreateValidator()
        {
            return createUserViewUserValidator();
        }

        public IValidator<AuthenticationUserViewUser> UnlockUserValidator()
        {
            return unlockUserViewUserValidator();
        }

        public IValidator<AuthenticationUserViewUser> VerifyUserValidator()
        {
            return verifyUserViewUserValidator();
        }

        public IValidator<AuthenticationUserViewUser> UpdateRolesValidator()
        {
            return updateRolesAuthenticationUserViewUserValidator();
        }

        public IValidator<AuthenticationUserViewUser> LockAuthenticationUserViewUserOutValidator()
        {
            return lockAuthenticationUserViewUserOutValidator();
        }

        public IValidator<AuthenticationUserViewUser> UpdateEmailValidator()
        {
            return updateAuthenticationUserViewUserEmailValidator();
        }
    }
}
