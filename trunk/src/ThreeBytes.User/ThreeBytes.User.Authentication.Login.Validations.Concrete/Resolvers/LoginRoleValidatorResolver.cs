using System;
using FluentValidation;
using ThreeBytes.User.Authentication.Login.Entities;
using ThreeBytes.User.Authentication.Login.Validations.Abstract;
using ThreeBytes.User.Authentication.Login.Validations.Concrete.Validators;

namespace ThreeBytes.User.Authentication.Login.Validations.Concrete.Resolvers
{
    public class LoginRoleValidatorResolver : ILoginRoleValidatorResolver
    {
        private readonly Func<CreateLoginRoleValidator> createLoginRoleValidator;

        public LoginRoleValidatorResolver(Func<CreateLoginRoleValidator> createLoginRoleValidator)
        {
            this.createLoginRoleValidator = createLoginRoleValidator;
        }

        public IValidator<LoginRole> CreateValidator()
        {
            return createLoginRoleValidator();
        }
    }
}
