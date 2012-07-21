using System;
using FluentValidation;
using ThreeBytes.User.Role.Management.Entities;
using ThreeBytes.User.Role.Management.Validations.Abstract;
using ThreeBytes.User.Role.Management.Validations.Concrete.Validators;

namespace ThreeBytes.User.Role.Management.Validations.Concrete.Resolvers
{
    public class RoleManagementRoleValidatorResolver : IRoleManagementRoleValidatorResolver
    {
        private readonly Func<CreateRoleManagementRoleValidator> createRoleManagementRoleValidator;
        private readonly Func<RenameRoleManagementRoleValidator> renameRoleManagementRoleValidator;

        public RoleManagementRoleValidatorResolver(Func<CreateRoleManagementRoleValidator> createRoleManagementRoleValidator, Func<RenameRoleManagementRoleValidator> renameRoleManagementRoleValidator)
        {
            this.createRoleManagementRoleValidator = createRoleManagementRoleValidator;
            this.renameRoleManagementRoleValidator = renameRoleManagementRoleValidator;
        }

        public IValidator<RoleManagementRole> CreateValidator()
        {
            return createRoleManagementRoleValidator();
        }

        public IValidator<RoleManagementRole> RenameValidator()
        {
            return renameRoleManagementRoleValidator();
        }
    }
}
