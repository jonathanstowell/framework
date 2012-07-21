using System;
using FluentValidation;
using ThreeBytes.User.Authentication.Registration.Entities;
using ThreeBytes.User.Authentication.Registration.Validations.Abstract;
using ThreeBytes.User.Authentication.Registration.Validations.Concrete.Validators;

namespace ThreeBytes.User.Authentication.Registration.Validations.Concrete.Resolvers
{
    public class RegistrationUserValidatorResolver : IRegistrationUserValidatorResolver
    {
        private readonly Func<CreateRegistrationUserValidator> createRegistrationUserValidator;
        private readonly Func<VerifyUserRegistrationUserValidator> verifyUserRegistrationUserValidator;
        private readonly Func<UpdateRegistrationUserEmailValidator> updateRegistrationUserEmailValidator;

        public RegistrationUserValidatorResolver(Func<CreateRegistrationUserValidator> createRegistrationUserValidator, Func<VerifyUserRegistrationUserValidator> verifyUserRegistrationUserValidator, Func<UpdateRegistrationUserEmailValidator> updateRegistrationUserEmailValidator)
        {
            this.createRegistrationUserValidator = createRegistrationUserValidator;
            this.verifyUserRegistrationUserValidator = verifyUserRegistrationUserValidator;
            this.updateRegistrationUserEmailValidator = updateRegistrationUserEmailValidator;
        }

        public IValidator<RegistrationUser> CreateValidator()
        {
            return createRegistrationUserValidator();
        }

        public IValidator<RegistrationUser> VerifyUserValidator()
        {
            return verifyUserRegistrationUserValidator();
        }

        public IValidator<RegistrationUser> UpdateEmailValidator()
        {
            return updateRegistrationUserEmailValidator();
        }
    }
}
