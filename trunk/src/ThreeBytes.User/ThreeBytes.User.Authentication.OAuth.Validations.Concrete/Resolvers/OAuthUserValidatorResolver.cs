using System;
using FluentValidation;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Validations.Abstract;
using ThreeBytes.User.Authentication.OAuth.Validations.Concrete.Validators;

namespace ThreeBytes.User.Authentication.OAuth.Validations.Concrete.Resolvers
{
    public class OAuthUserValidatorResolver : IOAuthUserValidatorResolver
    {
        private readonly Func<CreateOAuthUserValidator> createOAuthUserValidator;
        private readonly Func<UpdateRolesLoginUserValidator> updateRolesOAuthUserValidator;
        private readonly Func<UpdateOAuthUserEmailAddressValidator> updateOAuthUserEmailAddressValidator;
        private readonly Func<LinkExternalProviderValidator> linkExternalProviderValidator;
        
        public OAuthUserValidatorResolver(Func<CreateOAuthUserValidator> createOAuthUserValidator, Func<UpdateRolesLoginUserValidator> updateRolesOAuthUserValidator, Func<UpdateOAuthUserEmailAddressValidator> updateOAuthUserEmailAddressValidator, Func<LinkExternalProviderValidator> linkExternalProviderValidator)
        {
            this.createOAuthUserValidator = createOAuthUserValidator;
            this.updateRolesOAuthUserValidator = updateRolesOAuthUserValidator;
            this.updateOAuthUserEmailAddressValidator = updateOAuthUserEmailAddressValidator;
            this.linkExternalProviderValidator = linkExternalProviderValidator;
        }

        public IValidator<OAuthUser> CreateValidator()
        {
            return createOAuthUserValidator();
        }

        public IValidator<OAuthUser> UpdateRolesValidator()
        {
            return updateRolesOAuthUserValidator();
        }

        public IValidator<OAuthUser> UpdateEmailValidator()
        {
            return updateOAuthUserEmailAddressValidator();
        }

        public IValidator<OAuthUser> LinkExternalProviderValidator()
        {
            return linkExternalProviderValidator();
        }
    }
}
