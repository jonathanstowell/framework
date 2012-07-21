using System;
using FluentValidation;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Validations.Abstract;
using ThreeBytes.User.Authentication.OAuth.Validations.Concrete.Validators;

namespace ThreeBytes.User.Authentication.OAuth.Validations.Concrete.Resolvers
{
    public class OAuthRoleValidatorResolver : IOAuthRoleValidatorResolver
    {
        private readonly Func<CreateOAuthRoleValidator> createOAuthRoleValidator;

        public OAuthRoleValidatorResolver(Func<CreateOAuthRoleValidator> createOAuthRoleValidator)
        {
            this.createOAuthRoleValidator = createOAuthRoleValidator;
        }

        public IValidator<OAuthRole> CreateValidator()
        {
            return createOAuthRoleValidator();
        }
    }
}
