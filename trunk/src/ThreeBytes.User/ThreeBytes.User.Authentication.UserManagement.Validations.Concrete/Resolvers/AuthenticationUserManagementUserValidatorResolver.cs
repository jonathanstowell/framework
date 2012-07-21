using System;
using FluentValidation;
using ThreeBytes.User.Authentication.UserManagement.Entities;
using ThreeBytes.User.Authentication.UserManagement.Validations.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Validations.Concrete.Validators;

namespace ThreeBytes.User.Authentication.UserManagement.Validations.Concrete.Resolvers
{
    public class AuthenticationUserManagementUserValidatorResolver : IAuthenticationUserManagementUserValidatorResolver
    {
        private readonly Func<CreateAuthenticationUserManagementUserValidator> createUserManagementUserValidator;
        private readonly Func<UnlockAuthenticationUserManagementUserValidator> unlockUserManagementUserValidator;
        private readonly Func<VerifyAuthenticationUserManagementUserValidator> verifyUserManagementUserValidator;
        private readonly Func<UpdateRolesAuthenticationUserManagementUserValidator> updateRolesAuthenticationUserManagementUserValidator;
        private readonly Func<LockAuthenticationUserManagementUserOutValidator> lockAuthenticationUserManagementUserOutValidator;
        private readonly Func<UpdateAuthenticationUserManagementUserEmailValidator> updateAuthenticationUserManagementUserEmailValidator;

        public AuthenticationUserManagementUserValidatorResolver(Func<CreateAuthenticationUserManagementUserValidator> createUserManagementUserValidator, Func<UnlockAuthenticationUserManagementUserValidator> unlockUserManagementUserValidator, Func<VerifyAuthenticationUserManagementUserValidator> verifyUserManagementUserValidator, Func<UpdateRolesAuthenticationUserManagementUserValidator> updateRolesAuthenticationUserManagementUserValidator, Func<LockAuthenticationUserManagementUserOutValidator> lockAuthenticationUserManagementUserOutValidator, Func<UpdateAuthenticationUserManagementUserEmailValidator> updateAuthenticationUserManagementUserEmailValidator)
        {
            this.createUserManagementUserValidator = createUserManagementUserValidator;
            this.unlockUserManagementUserValidator = unlockUserManagementUserValidator;
            this.verifyUserManagementUserValidator = verifyUserManagementUserValidator;
            this.updateRolesAuthenticationUserManagementUserValidator = updateRolesAuthenticationUserManagementUserValidator;
            this.lockAuthenticationUserManagementUserOutValidator = lockAuthenticationUserManagementUserOutValidator;
            this.updateAuthenticationUserManagementUserEmailValidator = updateAuthenticationUserManagementUserEmailValidator;
        }

        public IValidator<AuthenticationUserManagementUser> CreateValidator()
        {
            return createUserManagementUserValidator();
        }

        public IValidator<AuthenticationUserManagementUser> UnlockUserValidator()
        {
            return unlockUserManagementUserValidator();
        }

        public IValidator<AuthenticationUserManagementUser> VerifyUserValidator()
        {
            return verifyUserManagementUserValidator();
        }

        public IValidator<AuthenticationUserManagementUser> UpdateRolesValidator()
        {
            return updateRolesAuthenticationUserManagementUserValidator();
        }

        public IValidator<AuthenticationUserManagementUser> LockAuthenticationUserManagementUserOutValidator()
        {
            return lockAuthenticationUserManagementUserOutValidator();
        }

        public IValidator<AuthenticationUserManagementUser> UpdateEmailValidator()
        {
            return updateAuthenticationUserManagementUserEmailValidator();
        }
    }
}
