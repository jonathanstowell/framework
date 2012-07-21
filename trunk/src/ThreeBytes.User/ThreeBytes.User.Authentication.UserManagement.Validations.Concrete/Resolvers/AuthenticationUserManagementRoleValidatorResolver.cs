using System;
using FluentValidation;
using ThreeBytes.User.Authentication.UserManagement.Entities;
using ThreeBytes.User.Authentication.UserManagement.Validations.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Validations.Concrete.Validators;

namespace ThreeBytes.User.Authentication.UserManagement.Validations.Concrete.Resolvers
{
    public class AuthenticationUserManagementRoleValidatorResolver : IAuthenticationUserManagementRoleValidatorResolver
    {
        private readonly Func<CreateAuthenticationUserManagementRoleValidator> createAuthenticationUserManagementRoleValidator;

        public AuthenticationUserManagementRoleValidatorResolver(Func<CreateAuthenticationUserManagementRoleValidator> createAuthenticationUserManagementRoleValidator)
        {
            this.createAuthenticationUserManagementRoleValidator = createAuthenticationUserManagementRoleValidator;
        }

        public IValidator<AuthenticationUserManagementRole> CreateValidator()
        {
            return createAuthenticationUserManagementRoleValidator();
        }
    }
}
