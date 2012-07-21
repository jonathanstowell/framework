using System;
using FluentValidation;
using ThreeBytes.User.Authentication.Login.Entities;
using ThreeBytes.User.Authentication.Login.Validations.Abstract;
using ThreeBytes.User.Authentication.Login.Validations.Concrete.Validators;

namespace ThreeBytes.User.Authentication.Login.Validations.Concrete.Resolvers
{
    public class LoginUserValidatorResolver : ILoginUserValidatorResolver
    {
        private readonly Func<CreateLoginUserValidator> createLoginUserValidator;
        private readonly Func<UpdateRolesLoginUserValidator> updateRolesLoginUserValidator;
        private readonly Func<UpdatePasswordLoginUserValidator> updatePasswordLoginUserValidator;
        private readonly Func<UpdateLoginUserEmailAddressValidator> updateLoginUserEmailAddressValidator;
        private readonly Func<UnlockUserLoginUserValidator> unlockUserLoginUserValidator;
        private readonly Func<VerifyUserLoginUserValidator> verifyUserLoginUserValidator;
        private readonly Func<UserEnteredIncorrectPasswordLoginUserValidator> userEnteredIncorrectPasswordUserValidator;
        private readonly Func<AuthenticateUserValidator> authenticateUserValidator;
        
        public LoginUserValidatorResolver(Func<CreateLoginUserValidator> createLoginUserValidator, Func<UpdateRolesLoginUserValidator> updateRolesLoginUserValidator, Func<UpdatePasswordLoginUserValidator> updatePasswordLoginUserValidator, Func<UnlockUserLoginUserValidator> unlockUserLoginUserValidator, Func<VerifyUserLoginUserValidator> verifyUserLoginUserValidator, Func<UserEnteredIncorrectPasswordLoginUserValidator> userEnteredIncorrectPasswordUserValidator, Func<AuthenticateUserValidator> authenticateUserValidator, Func<UpdateLoginUserEmailAddressValidator> updateLoginUserEmailAddressValidator)
        {
            this.createLoginUserValidator = createLoginUserValidator;
            this.updateRolesLoginUserValidator = updateRolesLoginUserValidator;
            this.updatePasswordLoginUserValidator = updatePasswordLoginUserValidator;
            this.unlockUserLoginUserValidator = unlockUserLoginUserValidator;
            this.verifyUserLoginUserValidator = verifyUserLoginUserValidator;
            this.userEnteredIncorrectPasswordUserValidator = userEnteredIncorrectPasswordUserValidator;
            this.authenticateUserValidator = authenticateUserValidator;
            this.updateLoginUserEmailAddressValidator = updateLoginUserEmailAddressValidator;
        }

        public IValidator<LoginUser> CreateValidator()
        {
            return createLoginUserValidator();
        }

        public IValidator<LoginUser> UpdateRolesValidator()
        {
            return updateRolesLoginUserValidator();
        }

        public IValidator<LoginUser> UpdatePasswordValidator()
        {
            return updatePasswordLoginUserValidator();
        }

        public IValidator<LoginUser> UpdateEmailValidator()
        {
            return updateLoginUserEmailAddressValidator();
        }

        public IValidator<LoginUser> UnlockUserValidator()
        {
            return unlockUserLoginUserValidator();
        }

        public IValidator<LoginUser> UserEnteredIncorrectPasswordValidator()
        {
            return userEnteredIncorrectPasswordUserValidator();
        }

        public IValidator<LoginUser> VerifyUserValidator()
        {
            return verifyUserLoginUserValidator();
        }

        public IValidator<LoginUser> AuthenticateUserValidator()
        {
            return authenticateUserValidator();
        }
    }
}
