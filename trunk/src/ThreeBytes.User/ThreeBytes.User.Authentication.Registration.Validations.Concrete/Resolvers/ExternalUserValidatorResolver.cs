using System;
using FluentValidation;
using ThreeBytes.User.Authentication.Registration.Entities;
using ThreeBytes.User.Authentication.Registration.Validations.Abstract;
using ThreeBytes.User.Authentication.Registration.Validations.Concrete.Validators;

namespace ThreeBytes.User.Authentication.Registration.Validations.Concrete.Resolvers
{
    public class ExternalUserValidatorResolver : IExternalUserValidatorResolver
    {
        private readonly Func<CreateExternalUserValidator> createExternalUserValidator;
        private readonly Func<LinkExternalProviderToExternalUserValidator> linkExternalProviderToExternalUserValidator;

        public ExternalUserValidatorResolver(Func<CreateExternalUserValidator> createExternalUserValidator, Func<LinkExternalProviderToExternalUserValidator> linkExternalProviderToExternalUserValidator)
        {
            this.createExternalUserValidator = createExternalUserValidator;
            this.linkExternalProviderToExternalUserValidator = linkExternalProviderToExternalUserValidator;
        }

        public IValidator<ExternalUser> CreateValidator()
        {
            return createExternalUserValidator();
        }

        public IValidator<ExternalUser> LinkExternalProviderValidator()
        {
            return linkExternalProviderToExternalUserValidator();
        }
    }
}