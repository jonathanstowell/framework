using System;
using FluentValidation;
using ThreeBytes.User.Role.List.Entities;
using ThreeBytes.User.Role.List.Validations.Abstract;
using ThreeBytes.User.Role.List.Validations.Concrete.Validators;

namespace ThreeBytes.User.Role.List.Validations.Concrete.Resolvers
{
    public class RoleListRoleValidatorResolver : IRoleListRoleValidatorResolver
    {
        private readonly Func<CreateRoleListRoleValidator> createRoleListRoleValidator;
        private readonly Func<RenameRoleListRoleValidator> renameRoleListRoleValidator;

        public RoleListRoleValidatorResolver(Func<CreateRoleListRoleValidator> createRoleListRoleValidator, Func<RenameRoleListRoleValidator> renameRoleListRoleValidator)
        {
            this.createRoleListRoleValidator = createRoleListRoleValidator;
            this.renameRoleListRoleValidator = renameRoleListRoleValidator;
        }

        public IValidator<RoleListRole> CreateValidator()
        {
            return createRoleListRoleValidator();
        }

        public IValidator<RoleListRole> RenameValidator()
        {
            return renameRoleListRoleValidator();
        }

    }
}
