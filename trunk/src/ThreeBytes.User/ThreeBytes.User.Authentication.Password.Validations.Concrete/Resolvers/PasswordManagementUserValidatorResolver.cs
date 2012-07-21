using System;
using FluentValidation;
using ThreeBytes.User.Authentication.Password.Entities;
using ThreeBytes.User.Authentication.Password.Validations.Abstract;
using ThreeBytes.User.Authentication.Password.Validations.Concrete.Validators;

namespace ThreeBytes.User.Authentication.Password.Validations.Concrete.Resolvers
{
    public class PasswordManagementUserValidatorResolver : IPasswordManagementUserValidatorResolver
    {
        private readonly Func<CreatePasswordManagementUserValidator> createPasswordManagementUserValidator;
        private readonly Func<UnlockPasswordManagementUserValidator> unlockPasswordManagementUserValidator;
        private readonly Func<VerifyUserPasswordManagementUserValidator> verifyUserPasswordManagementUserValidator;
        private readonly Func<ResetPasswordPasswordManagementUserValidator> resetPasswordPasswordManagementUserValidator;
        private readonly Func<ResetPasswordConfirmPasswordManagementUserValidator> resetPasswordConfirmPasswordManagementUserValidator;
        private readonly Func<LockPasswordManagementUserOutValidator> lockPasswordManagementUserOutValidator;
        private readonly Func<UpdatePasswordManagementUserEmailValidator> updatePasswordManagementUserEmailValidator;

        public PasswordManagementUserValidatorResolver(Func<CreatePasswordManagementUserValidator> createPasswordManagementUserValidator, Func<UnlockPasswordManagementUserValidator> unlockPasswordManagementUserValidator, Func<VerifyUserPasswordManagementUserValidator> verifyUserPasswordManagementUserValidator, Func<ResetPasswordPasswordManagementUserValidator> resetPasswordPasswordManagementUserValidator, Func<ResetPasswordConfirmPasswordManagementUserValidator> resetPasswordConfirmPasswordManagementUserValidator, Func<LockPasswordManagementUserOutValidator> lockPasswordManagementUserOutValidator, Func<UpdatePasswordManagementUserEmailValidator> updatePasswordManagementUserEmailValidator)
        {
            this.createPasswordManagementUserValidator = createPasswordManagementUserValidator;
            this.unlockPasswordManagementUserValidator = unlockPasswordManagementUserValidator;
            this.verifyUserPasswordManagementUserValidator = verifyUserPasswordManagementUserValidator;
            this.resetPasswordPasswordManagementUserValidator = resetPasswordPasswordManagementUserValidator;
            this.resetPasswordConfirmPasswordManagementUserValidator = resetPasswordConfirmPasswordManagementUserValidator;
            this.lockPasswordManagementUserOutValidator = lockPasswordManagementUserOutValidator;
            this.updatePasswordManagementUserEmailValidator = updatePasswordManagementUserEmailValidator;
        }

        public IValidator<PasswordManagementUser> CreateValidator()
        {
            return createPasswordManagementUserValidator();
        }

        public IValidator<PasswordManagementUser> UnlockUserValidator()
        {
            return unlockPasswordManagementUserValidator();
        }

        public IValidator<PasswordManagementUser> VerifyUserValidator()
        {
            return verifyUserPasswordManagementUserValidator();
        }

        public IValidator<PasswordManagementUser> ResetPasswordValidator()
        {
            return resetPasswordPasswordManagementUserValidator();
        }

        public IValidator<PasswordManagementUser> ResetPasswordConfirmValidator()
        {
            return resetPasswordConfirmPasswordManagementUserValidator();
        }

        public IValidator<PasswordManagementUser> LockPasswordManagementUserOutValidator()
        {
            return lockPasswordManagementUserOutValidator();
        }

        public IValidator<PasswordManagementUser> UpdateEmailValidator()
        {
            return updatePasswordManagementUserEmailValidator();
        }
    }
}
