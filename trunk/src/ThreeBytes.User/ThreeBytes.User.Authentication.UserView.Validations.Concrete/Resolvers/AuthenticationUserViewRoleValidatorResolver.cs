using System;
using FluentValidation;
using ThreeBytes.User.Authentication.UserView.Entities;
using ThreeBytes.User.Authentication.UserView.Validations.Abstract;
using ThreeBytes.User.Authentication.UserView.Validations.Concrete.Validators;

namespace ThreeBytes.User.Authentication.UserView.Validations.Concrete.Resolvers
{
    public class AuthenticationUserViewRoleValidatorResolver : IAuthenticationUserViewRoleValidatorResolver
    {
        private readonly Func<CreateAuthenticationUserViewRoleValidator> createAuthenticationUserViewRoleValidator;

        public AuthenticationUserViewRoleValidatorResolver(Func<CreateAuthenticationUserViewRoleValidator> createAuthenticationUserViewRoleValidator)
        {
            this.createAuthenticationUserViewRoleValidator = createAuthenticationUserViewRoleValidator;
        }

        public IValidator<AuthenticationUserViewRole> CreateValidator()
        {
            return createAuthenticationUserViewRoleValidator();
        }
    }
}
